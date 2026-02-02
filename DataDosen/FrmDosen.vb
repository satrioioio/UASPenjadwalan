Imports MySql.Data.MySqlClient
Public Class FrmDosen
    Dim CurrentPage As Integer = 1
    Dim PageSize As Integer = 10
    Dim TotalData As Integer = 0
    Dim TotalPage As Integer = 0
    Dim Offset As Integer = 0
    Dim PageCache As New Dictionary(Of String, DataTable)
    Dim LastCacheKey As String = ""

    Function GetChacheKey(page As Integer) As String
        Dim Prodi As String = If(CmbNamaProdi.SelectedValue Is Nothing, "", CmbNamaProdi.SelectedValue.ToString())
        Dim NamaDosen As String = TextCariNama.Text.Trim()
        Dim Limit As String = ComboBoxEntries.Text
        Return $"{Prodi}|{NamaDosen}|{Limit}|PAGE:{page}"
    End Function

    Sub AktifkanFormUtama()
        DataGridDosen.Enabled = True
        TextCariNama.Enabled = True
        CmbNamaProdi.Enabled = True
        BtnCari.Enabled = True
    End Sub


    Function AmbilNikBaru() As String
        Dim hasilNik As String = "130001"
        Try
            Call KoneksiDB()
            Dim QUERY_CEK = "SELECT MAX(Kd_Dosen) From tbl_dosen"
            Using CMD_NIK As New MySqlCommand(QUERY_CEK, DBKoneksi)
                Dim obj = CMD_NIK.ExecuteScalar()
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    hasilNik = (CLng(obj) + 1).ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal generate NIK: " & ex.Message)
        End Try
        Return hasilNik
    End Function

    Sub CleaPagingCache()
        PageCache.Clear()
        LastCacheKey = ""
    End Sub

    Sub NumberEntriesHalaman()
        ComboBoxEntries.Items.Add("10")
        ComboBoxEntries.Items.Add("15")
        ComboBoxEntries.Items.Add("20")
        ComboBoxEntries.Items.Add("25")
        ComboBoxEntries.Items.Add("50")
        ComboBoxEntries.Items.Add("100")
        ComboBoxEntries.SelectedIndex = 0
    End Sub

    Private Sub FormatRowHeader(grid As DataGridView, starIndex As Integer, PageSize As Integer)
        grid.SuspendLayout()
        grid.AllowUserToAddRows = False
        grid.RowHeadersVisible = True
        grid.RowHeadersWidth = 58
        grid.RowHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)

        For i As Integer = 0 To grid.Rows.Count - 1
            grid.Rows(i).HeaderCell.Value = (starIndex + i + 1).ToString()
        Next
        grid.ResumeLayout()
    End Sub

    Private isloading As Boolean = True

    Sub RefreshPaging()
        CurrentPage = 1
        PageCache.Clear()
        HitungTotalData()
        LoadPage()
    End Sub

    Sub AktifkanDataGridDosen()
        With DataGridDosen
            .EnableHeadersVisualStyles = False
            .Font = New Font(DataGridDosen.Font, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Arial", 9)
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 35
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .Columns(0).HeaderText = "NIK"
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).HeaderText = "NIDN"
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(2).HeaderText = "Nama Dosen"
            .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(3).HeaderText = "Jenis Kelamin"
            .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(4).HeaderText = "Nomor Hp"
            .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(5).HeaderText = "E-mail Dosen"
            .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With
    End Sub

    Sub HitungTotalData()
        Try
            Call KoneksiDB()

            Dim QUERY As String = "SELECT COUNT(*) " &
                              "FROM tbl_dosen INNER JOIN tbl_prodi ON tbl_dosen.Kd_prodi = tbl_prodi.Kd_Prodi"

            Dim whereClauses As New List(Of String)

            Dim kdProdi As String = GetSelectedProdi()
            If kdProdi <> "ALL" Then
                whereClauses.Add("tbl_prodi.Kd_Prodi = @KdProdi")
            End If

            If TextCariNama.Text.Trim() <> "" Then
                whereClauses.Add("tbl_dosen.Nm_Dosen LIKE @NamaDosen")
            End If

            If whereClauses.Count > 0 Then
                QUERY &= " WHERE " & String.Join(" AND ", whereClauses)
            End If

            Using CMD As New MySqlCommand(QUERY, DBKoneksi)
                If kdProdi <> "ALL" Then
                    CMD.Parameters.AddWithValue("@KdProdi", kdProdi)
                End If
                If TextCariNama.Text.Trim() <> "" Then
                    CMD.Parameters.AddWithValue("@NamaDosen", "%" & TextCariNama.Text.Trim() & "%")
                End If

                TotalData = Convert.ToInt32(CMD.ExecuteScalar())
            End Using

            TotalPage = Math.Ceiling(TotalData / PageSize)
            If TotalPage < 1 Then TotalPage = 1

            LbTotalBaris.Text = "Total Jumlah Data: " & TotalData
            LbHasilBagiHalaman.Text = "Jumlah Halaman: " & TotalPage

        Catch ex As Exception
            MessageBox.Show("Error HitungTotalData: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetSelectedProdi() As String
        If CmbNamaProdi.SelectedValue Is Nothing Then
            Return "ALL"
        End If

        Dim nilai As String = CmbNamaProdi.SelectedValue.ToString().Trim()
        If String.IsNullOrEmpty(nilai) Then
            Return "ALL"
        End If

        Return nilai
    End Function


    Sub LoadPage()
        Offset = (CurrentPage - 1) * PageSize
        Dim cacheKey As String = $"{CurrentPage}-{PageSize}-{TextCariNama.Text}"

        If PageCache.ContainsKey(cacheKey) Then
            DataGridDosen.DataSource = PageCache(cacheKey)
            Exit Sub
        End If

        Call KoneksiDB()

        QUERY = "SELECT Kd_Dosen, NIDN_Dosen, Nm_Dosen, Jk_Dosen, NoHp_Dosen, Email_Dosen FROM tbl_dosen WHERE Kd_Prodi = @KdProdi"

        If TextCariNama.Text <> "" Then
            QUERY &= " AND Nm_Dosen LIKE @NamaDosen"
        End If

        QUERY &= " ORDER BY Kd_Dosen ASC LIMIT @offset, @Limit"

        Using DA As New MySqlDataAdapter(QUERY, DBKoneksi)
            DA.SelectCommand.Parameters.AddWithValue("@KdProdi", CmbNamaProdi.SelectedValue)
            DA.SelectCommand.Parameters.AddWithValue("@Offset", Offset)
            DA.SelectCommand.Parameters.AddWithValue("@Limit", PageSize)

            If TextCariNama.Text <> "" Then
                DA.SelectCommand.Parameters.AddWithValue("@NamaDosen", "%" & TextCariNama.Text & "%")
            End If

            Dim dt As New DataTable
            DA.Fill(dt)

            PageCache(cacheKey) = dt
            DataGridDosen.DataSource = dt
        End Using

        UpdateNavigator()
    End Sub

    Sub UpdateNavigator()
        BindingNavigatorPositionItem.Text = CurrentPage.ToString()
        BindingNavigatorCountItem.Text = $"of {TotalPage}"

        BindingNavigatorMoveFirstItem.Enabled = CurrentPage > 1
        BindingNavigatorMovePreviousItem.Enabled = CurrentPage > 1
        BindingNavigatorMoveNextItem.Enabled = CurrentPage < TotalPage
        BindingNavigatorMoveLastItem.Enabled = CurrentPage < TotalPage
    End Sub

    Sub TampilkanDataGridDosen()
        Try
            PageSize = Val(ComboBoxEntries.Text)
            Offset = (CurrentPage - 1) * PageSize

            Dim CacheKey As String = GetChacheKey(CurrentPage)

            If PageCache.ContainsKey(CacheKey) Then
                Dim dtCache As DataTable = PageCache(CacheKey)
                DataGridDosen.DataSource = dtCache
                FormatRowHeader(DataGridDosen, Offset, PageSize)

                LbJumlahBaris.Text = "Baris di halaman " & CurrentPage & ": " & dtCache.Rows.Count
                LbTotalBaris.Text = "Jumlah Baris Entri: " & TotalData
                LbHasilBagiHalaman.Text = "Jumlah Halaman: " & TotalPage

                UpdateNavigatorState()
                Exit Sub
            End If

            QUERY = "SELECT tbl_dosen.Kd_Dosen, tbl_dosen.NIDN_Dosen, tbl_dosen.Nm_Dosen, " &
                "tbl_dosen.Jk_Dosen, tbl_dosen.NoHp_Dosen, tbl_dosen.Email_Dosen " &
                "FROM tbl_dosen INNER JOIN tbl_prodi ON tbl_dosen.Kd_prodi = tbl_prodi.Kd_Prodi"

            Dim whereClauses As New List(Of String)

            Dim kdProdi As String = GetSelectedProdi()
            If kdProdi <> "ALL" Then
                whereClauses.Add("tbl_prodi.Kd_Prodi = @KdProdi")
            End If

            If TextCariNama.Text.Trim() <> "" Then
                whereClauses.Add("tbl_dosen.Nm_Dosen LIKE @NamaDosen")
            End If

            If whereClauses.Count > 0 Then
                QUERY &= " WHERE " & String.Join(" AND ", whereClauses)
            End If

            QUERY &= " ORDER BY tbl_dosen.Kd_Dosen ASC LIMIT @Offset, @Limit"

            Using DA As New MySqlDataAdapter(QUERY, DBKoneksi)
                DA.SelectCommand.Parameters.AddWithValue("@Offset", Offset)
                DA.SelectCommand.Parameters.AddWithValue("@Limit", PageSize)

                If kdProdi <> "ALL" Then
                    DA.SelectCommand.Parameters.AddWithValue("@KdProdi", kdProdi)
                End If

                If TextCariNama.Text.Trim() <> "" Then
                    DA.SelectCommand.Parameters.AddWithValue("@NamaDosen", "%" & TextCariNama.Text.Trim() & "%")
                End If

                Dim DT As New DataTable
                DA.Fill(DT)

                PageCache(CacheKey) = DT

                DataGridDosen.DataSource = DT
                FormatRowHeader(DataGridDosen, Offset, PageSize)
                DataGridDosen.ReadOnly = True

                LbJumlahBaris.Text = "Baris di halaman " & CurrentPage & ": " & DT.Rows.Count
            End Using

            Dim countQuery As String = "SELECT COUNT(*) FROM tbl_dosen INNER JOIN tbl_prodi ON tbl_dosen.Kd_prodi = tbl_prodi.Kd_Prodi"
            If whereClauses.Count > 0 Then
                countQuery &= " WHERE " & String.Join(" AND ", whereClauses)
            End If

            Using cmdCount As New MySqlCommand(countQuery, DBKoneksi)
                If kdProdi <> "ALL" Then
                    cmdCount.Parameters.AddWithValue("@KdProdi", kdProdi)
                End If
                If TextCariNama.Text.Trim() <> "" Then
                    cmdCount.Parameters.AddWithValue("@NamaDosen", "%" & TextCariNama.Text.Trim() & "%")
                End If

                TotalData = Convert.ToInt32(cmdCount.ExecuteScalar())
                TotalPage = Math.Ceiling(TotalData / PageSize)
            End Using

            LbTotalBaris.Text = "Jumlah Baris Entri: " & TotalData
            LbHasilBagiHalaman.Text = "Jumlah Halaman: " & TotalPage

            UpdateNavigatorState()

        Catch ex As Exception
            MessageBox.Show("Error TampilkanDataGridDosen: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        AktifkanDataGridDosen()
        HitungTotalData()
        UpdateNavigatorState()
    End Sub

    Sub HitungRowDataGrid()
        Try
            Call KoneksiDB()
            BindingNavigatorPositionItem.Text = 1
            Nomor = (Val(BindingNavigatorPositionItem.Text) - 1) * Val(ComboBoxEntries.Text)
            Batas = ComboBoxEntries.Text
            Call KoneksiDB()
            CMD = New MySqlCommand(" SELECT CEILING(COUNT(*)) As Hasil FROM tbl_dosen INNER JOIN tbl_prodi ON tbl_dosen.Kd_Prodi = tbl_prodi.Kd_Prodi", DBKoneksi)

            DR = CMD.ExecuteReader
            DR.Read()
            TotalData = DR!Hasil
            DR.Close()

            LbTotalBaris.Text = "Total Baris All: " & TotalData & ""
        Catch ex As Exception
            MessageBox.Show("Error HitungRowDataGrid: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBoxEntries_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBoxEntries.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBoxEntries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEntries.SelectedIndexChanged
        If ComboBoxEntries.SelectedIndex = -1 Then Exit Sub

        PageSize = CInt(ComboBoxEntries.Text)
        RefreshPaging()
    End Sub

    Private Sub BindingNavigatorPositionItem_Leave(sender As Object, e As EventArgs) Handles BindingNavigatorPositionItem.Leave
        If Val(BindingNavigatorPositionItem.Text) < 1 Then BindingNavigatorPositionItem.Text = "1"
        If Val(BindingNavigatorPositionItem.Text) > Val(LbHasilBagiHalaman.Text) Then
            BindingNavigatorPositionItem.Text = LbHasilBagiHalaman.Text
        End If
    End Sub

    Sub TampilkanFilterNamaProdi()
        Try
            Call KoneksiDB()
            QUERY = "SELECT tbl_prodi.Kd_Prodi, tbl_prodi.Nm_Prodi FROM tbl_prodi ORDER BY tbl_prodi.Kd_Prodi"
            DA = New MySqlDataAdapter(QUERY, DBKoneksi)

            Dim DT As New DataTable
            DA.Fill(DT)

            Dim row As DataRow = DT.NewRow()
            row("Kd_Prodi") = "ALL"
            row("Nm_Prodi") = "ALL"
            DT.Rows.InsertAt(row, 0)


            CmbNamaProdi.DataSource = DT
            CmbNamaProdi.DisplayMember = "Nm_Prodi"
            CmbNamaProdi.ValueMember = "Kd_Prodi"
            CmbNamaProdi.SelectedIndex = 0
            LbkdprodiMhs.Text = ""
        Catch ex As Exception
            MsgBox("Gagal memuat data Prodi: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub CmbNamaProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbNamaProdi.SelectedIndexChanged
        If isloading Then Exit Sub
        If CmbNamaProdi.SelectedIndex < 0 Then Exit Sub
        If CmbNamaProdi.SelectedValue Is Nothing Then Exit Sub

        Try
            Kode_Jurusan = CmbNamaProdi.SelectedValue.ToString()
            LbkdprodiMhs.Text = Microsoft.VisualBasic.Right(Kode_Jurusan, 2)

            If Kode_Jurusan = "ALL" Then
                BtnTambahData.Enabled = False
                BtnTambahData.BackColor = Color.Red

                CurrentPage = 1
                PageCache.Clear()
                BindingNavigatorPositionItem.Text = "1"

                RefreshPaging()
                TampilkanDataGridDosen()
                Exit Sub
            Else
                BtnTambahData.Enabled = True
                BtnTambahData.BackColor = Color.White
            End If

            If ProdiBelumAdaDosen(Kode_Jurusan) Then
                If MessageBox.Show("Data Dosen Jurusan " & CmbNamaProdi.Text & " Belum Ada." & vbCrLf &
        "Apakah ingin menambahkan data dosen?", "Informasi",
        MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                    Using frmInput As New FrmDataDosen
                        Dim nikDihasilkan = AmbilNikBaru()

                        frmInput.LbkdProdiDsn.Text = Kode_Jurusan
                        frmInput.KodeProdiDariFormDosen = Kode_Jurusan
                        frmInput.LbNikDsn.Text = nikDihasilkan

                        ' Atur tampilan tombol
                        frmInput.BtnHapus.Enabled = False
                        frmInput.BtnHapus.BackColor = Color.Red
                        frmInput.CmbProdiDsn.Enabled = False
                        frmInput.BtnKeluar.Text = "BATAL"

                        If frmInput.ShowDialog() = DialogResult.OK Then
                            RefreshPaging()
                        End If
                    End Using
                End If
                Exit Sub
            End If

            CurrentPage = 1
            PageCache.Clear()
            BindingNavigatorPositionItem.Text = "1"

            RefreshPaging()
            TampilkanDataGridDosen()

        Catch ex As Exception
            MsgBox("Error Memilih Prodi: " & ex.Message, vbCritical)
        End Try
    End Sub

    Function ProdiBelumAdaDosen(kdProdi As String) As Boolean
        Try
            Call KoneksiDB()

            QUERY = "SELECT COUNT(*) FROM tbl_dosen WHERE Kd_Prodi = @KdProdi"

            Using CMD As New MySqlCommand(QUERY, DBKoneksi)
                CMD.Parameters.AddWithValue("@KdProdi", kdProdi)
                Return CInt(CMD.ExecuteScalar()) = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error validasi prodi: " & ex.Message)
            Return False
        End Try
    End Function

    Function ProdiAda(kdProdi As String) As Boolean
        Call KoneksiDB()
        QUERY = "SELECT COUNT(*) FROM tbl_prodi WHERE Kd_Prodi = @KdProdi"
        CMD = New MySqlCommand(QUERY, DBKoneksi)
        CMD.Parameters.AddWithValue("@KdProdi", kdProdi)
        Return CInt(CMD.ExecuteScalar()) > 0
    End Function

    Sub TampilkanDosenFilterByProdi()
        If CmbNamaProdi.SelectedIndex < 0 Then Exit Sub
        Dim kdProdi As String = CmbNamaProdi.SelectedValue.ToString()
        Dim Offset As Integer = (CurrentPage - 1) * PageSize

        If Not ProdiAda(kdProdi) Then
            MsgBox("Jurusan/Prodi tidak terdaftar di database", vbCritical, "Validasi")
        End If

        Try
            Call KoneksiDB()

            QUERY = "SELECT Kd_Dosen, NIDN_Dosen, Nm_Dosen, jk_Dosen, NoHp_Dosen, Email_Dosen FROM tbl_dosen WHERE Kd_Prodi = @KdProdi ORDER BY Kd_Dosen ASC LIMIT @Limit OFFSET @Offset"

            CMD = New MySqlCommand(QUERY, DBKoneksi)
            CMD.Parameters.AddWithValue("@KdProdi", kdProdi)
            CMD.Parameters.AddWithValue("@Limit", PageSize)
            CMD.Parameters.AddWithValue("@Offset", Offset)

            DA = New MySqlDataAdapter(CMD)
            Dim DT As New DataTable
            DA.Fill(DT)

            DataGridDosen.DataSource = DT
            DataGridDosen.Enabled = True

            Call FormatRowHeader(DataGridDosen, Offset, PageSize)
        Catch ex As Exception
            MsgBox("Kesalahan filter Prodi: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub FrmDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isloading = True

            ' Koneksi database
            Call KoneksiDB()

            ' Hitung jumlah baris awal & setup entries per halaman
            Call HitungRowDataGrid()
            Call NumberEntriesHalaman()

            ' Isi ComboBox Prodi
            Call TampilkanFilterNamaProdi()

            ' default ke ALL saat form dibuka
            If CmbNamaProdi.Items.Count > 0 Then
                CmbNamaProdi.SelectedValue = "ALL"
                LbkdprodiMhs.Text = "LL"
                BtnTambahData.Enabled = False   ' disable tombol tambah data saat ALL
                BtnTambahData.BackColor = Color.Red
            End If

            CurrentPage = 1
            PageCache.Clear()
            BindingNavigatorPositionItem.Text = "1"

            ' Tampilkan data dosen langsung
            RefreshPaging()
            TampilkanDataGridDosen()

            ' Tombol Enter = Cari
            Me.AcceptButton = BtnCari

            ' Grid tidak bisa di-edit langsung
            DataGridDosen.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Error saat load form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isloading = False
        End Try
    End Sub

    Public Sub RefreshData()
        Try
            TextCariNama.Text = ""
            CurrentPage = 1
            PageCache.Clear()
            BindingNavigatorPositionItem.Text = "1"
            TampilkanDataGridDosen()
            HitungTotalData()
            UpdateNavigatorState()
        Catch ex As Exception
            MessageBox.Show("Gagal refresh data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Try
            Call KoneksiDB()

            If TextCariNama.Text.Trim() = "" Then
                MsgBox("Silahkan input nama yang akan dicari dahulu", vbExclamation)
                TextCariNama.Focus()
                Exit Sub
            End If

            Dim kdProdi As String = GetSelectedProdi()

            QUERY = "SELECT DISTINCT tbl_dosen.Kd_Dosen, tbl_dosen.NIDN_Dosen, tbl_dosen.Nm_Dosen, " &
                "tbl_dosen.Jk_Dosen, tbl_dosen.NoHp_Dosen, tbl_dosen.Email_Dosen " &
                "FROM tbl_dosen INNER JOIN tbl_prodi ON tbl_dosen.Kd_Prodi = tbl_prodi.Kd_Prodi " &
                "WHERE tbl_dosen.Nm_Dosen LIKE @NamaDosen"

            If kdProdi <> "ALL" Then
                QUERY &= " AND tbl_prodi.Kd_Prodi = @KdProdi"
            End If

            Using DA As New MySqlDataAdapter(QUERY, DBKoneksi)
                DA.SelectCommand.Parameters.AddWithValue("@NamaDosen", "%" & TextCariNama.Text.Trim() & "%")

                If kdProdi <> "ALL" Then
                    DA.SelectCommand.Parameters.AddWithValue("@KdProdi", kdProdi)
                End If

                Dim DS As New DataSet
                DA.Fill(DS)

                DataGridDosen.DataSource = DS.Tables(0)
                DataGridDosen.Enabled = True

                If DS.Tables(0).Rows.Count = 0 Then
                    MsgBox("Data Dosen tidak ditemukan", vbInformation)
                    TextCariNama.Text = ""
                    CurrentPage = 1
                    PageCache.Clear()
                    BindingNavigatorPositionItem.Text = "1"

                    RefreshPaging()
                    TampilkanDataGridDosen()
                End If
            End Using

        Catch ex As Exception
            MsgBox("Terjadi kesalahan saat pencarian data: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub BtnTambahData_Click(sender As Object, e As EventArgs) Handles BtnTambahData.Click
        If BtnTambahData.Text = "Aktif Form" Then
            BtnTambahData.Text = "Tambah Data"
            BtnTambahData.BackColor = Color.White
            AktifkanFormUtama()
            Exit Sub
        End If

        If CmbNamaProdi.SelectedIndex = -1 Then
            MsgBox("Silahkan pilih nama prodi terlebih dahulu", vbCritical, "Peringatan")
            CmbNamaProdi.Focus()
            Exit Sub
        End If

        If CmbNamaProdi.SelectedValue Is Nothing Then
            MsgBox("Silahkan pilih nama prodi terlebih dahulu", vbCritical, "Peringatan")
            CmbNamaProdi.Focus()
            Exit Sub
        End If

        If CmbNamaProdi.SelectedValue.ToString() = "ALL" Then
            MsgBox("Silahkan pilih nama prodi terlebih dahulu", vbCritical, "Peringatan")
            CmbNamaProdi.Focus()
            Exit Sub
        End If

        Dim frmInput As New FrmDataDosen

        Call BuatNIKDosen(LbkdprodiMhs.Text)

        With frmInput
            .KodeProdiDariFormDosen = CmbNamaProdi.SelectedValue.ToString()
            .LbkdProdiDsn.Text = CmbNamaProdi.SelectedValue.ToString()
            .LbNikDsn.Text = FrmDataDosen.LbNikDsn.Text

            .CmbProdiDsn.Enabled = False
            .BtnHapus.Enabled = False
            .BtnHapus.BackColor = Color.Red
            .BtnKeluar.Text = "BATAL"

            If .ShowDialog() = DialogResult.OK Then
                RefreshData()
            End If
        End With
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If BtnKeluar.Text = "Keluar" Then
            If MessageBox.Show("Anda yakin mau keluar dari program?",
                           "Konfirmasi",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Close()
            End If
        Else
            BtnKeluar.Text = "Keluar"

            BtnTambahData.Text = "Aktif Form"
            BtnTambahData.Enabled = True
            BtnTambahData.BackColor = Color.LightGray

            AktifkanFormUtama()
        End If
    End Sub

    Sub BuatNIKDosen(KodeProdi As String)
        Call KoneksiDB()

        Try
            QUERY = "SELECT MAX(Kd_Dosen) From tbl_dosen"

            Using CMD As New MySqlCommand(QUERY, DBKoneksi)
                Dim Hasil As Object = CMD.ExecuteScalar()
                Dim KodeBaru As Long = 130001

                If Hasil IsNot Nothing AndAlso Not IsDBNull(Hasil) Then
                    KodeBaru = CLng(Hasil.ToString()) + 1
                End If
                FrmDataDosen.LbNikDsn.Text = KodeBaru
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat membuat nim: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridDosen_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridDosen.CellMouseDoubleClick
        Try
            If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() = "ALL" Then
                Exit Sub
            End If

            If e.RowIndex < 0 OrElse DataGridDosen.Rows.Count = 0 Then Exit Sub

            Dim NIKDosen As String = DataGridDosen.Rows(e.RowIndex).Cells("Kd_Dosen").Value.ToString()

            Call KoneksiDB()
            QUERY = "SELECT DISTINCT tbl_dosen.Kd_Dosen, tbl_dosen.NIDN_Dosen, tbl_dosen.Nm_Dosen, " &
                "tbl_dosen.Jk_Dosen, tbl_dosen.NoHp_Dosen, tbl_dosen.Email_Dosen " &
                "FROM tbl_dosen INNER JOIN tbl_prodi ON tbl_dosen.Kd_Prodi = tbl_prodi.Kd_Prodi " &
                "WHERE tbl_prodi.Nm_Prodi = @NmProdi AND tbl_dosen.Kd_Dosen = @KdDosen"

            CMD = New MySqlCommand(QUERY, DBKoneksi)
            CMD.Parameters.AddWithValue("@NmProdi", CmbNamaProdi.Text)
            CMD.Parameters.AddWithValue("@KdDosen", NIKDosen)

            DR = CMD.ExecuteReader()

            If DR.Read() Then
                Dim formEdit As New FrmDataDosen
                With formEdit
                    .TampilNamaProdi()
                    .jenisKelamin()
                    .LbkdProdiDsn.Text = CmbNamaProdi.SelectedValue.ToString()
                    .LbNikDsn.Text = DR("Kd_Dosen").ToString()
                    .TextNidnDsn.Text = DR("NIDN_Dosen").ToString()
                    .TextNamaDsn.Text = DR("Nm_Dosen").ToString()
                    .CmbJkDsn.Text = DR("Jk_Dosen").ToString().Trim()
                    .TextNoTelpDsn.Text = DR("NoHp_Dosen").ToString()
                    .TextEmailDsn.Text = DR("Email_Dosen").ToString()

                    .CmbProdiDsn.SelectedValue = CmbNamaProdi.SelectedValue
                    .CmbProdiDsn.Enabled = False
                    .BtnSimpan.Text = "UBAH"
                    .BtnSimpan.BackColor = Color.CornflowerBlue
                    .BtnKeluar.Text = "BATAL"
                    .BtnKeluar.BackColor = Color.CornflowerBlue
                    .BtnHapus.Enabled = True
                    .BtnHapus.BackColor = Color.CornflowerBlue
                End With

                If formEdit.ShowDialog() = DialogResult.OK Then
                    TextCariNama.Clear()
                    PageCache.Clear()
                    CurrentPage = 1
                    BindingNavigatorPositionItem.Text = "1"
                    RefreshPaging()
                    TampilkanDataGridDosen()
                End If
            Else
                MsgBox("Data dosen tidak ditemukan")
            End If

            DR.Close()

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menampilkan dari datagrid: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextCariNama_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCariNama.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            BtnCari.PerformClick()
        End If
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        CurrentPage = 1
        BindingNavigatorPositionItem.Text = CurrentPage
        UpdateNavigatorState()
        TampilkanDataGridDosen()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        If CurrentPage > 1 Then
            CurrentPage -= 1
            BindingNavigatorPositionItem.Text = CurrentPage
            UpdateNavigatorState()
            TampilkanDataGridDosen()
        End If
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        If CurrentPage < TotalPage Then
            CurrentPage += 1
            BindingNavigatorPositionItem.Text = CurrentPage
            UpdateNavigatorState()
            TampilkanDataGridDosen()
            UpdateNavigatorState()
        End If
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        CurrentPage = TotalPage
        BindingNavigatorPositionItem.Text = CurrentPage
        UpdateNavigatorState()
        TampilkanDataGridDosen()
    End Sub

    Sub ReffreshPaging()
        CurrentPage = 1
        HitungTotalData()
        TampilkanDataGridDosen()
        UpdateNavigatorState()
    End Sub

    Sub UpdateNavigatorState()
        BindingNavigatorMoveFirstItem.Enabled = (CurrentPage > 1)
        BindingNavigatorMovePreviousItem.Enabled = (CurrentPage > 1)

        BindingNavigatorMoveNextItem.Enabled = (CurrentPage < TotalPage)
        BindingNavigatorMoveLastItem.Enabled = (CurrentPage < TotalPage)

        BindingNavigatorPositionItem.Text = CurrentPage.ToString()
        BindingNavigatorCountItem.Text = $"of {TotalPage}"
    End Sub
End Class
