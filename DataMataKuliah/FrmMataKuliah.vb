Imports MySql.Data.MySqlClient
Public Class FrmMataKuliah
    Private isloading As Boolean = True

    ' 1. Load Data Prodi untuk Filter Jurusan
    Sub TampilkanFilterNamaProdi()
        Try
            Call KoneksiDB()
            Dim sqlProdi As String = "SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Kd_Prodi"
            Using DA As New MySqlDataAdapter(sqlProdi, DBKoneksi)
                Dim DT As New DataTable
                DA.Fill(DT)

                Dim row As DataRow = DT.NewRow()
                row("Kd_Prodi") = "ALL"
                row("Nm_Prodi") = "-- SEMUA PRODI --"
                DT.Rows.InsertAt(row, 0)

                CmbNamaProdi.DataSource = DT
                CmbNamaProdi.DisplayMember = "Nm_Prodi"
                CmbNamaProdi.ValueMember = "Kd_Prodi"
                CmbNamaProdi.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MsgBox("Gagal Memuat Data Prodi: " & ex.Message, vbCritical)
        End Try
    End Sub

    ' 2. Isi ComboBox Kategori dengan Ganjil/Genap
    Sub IsiKategoriSemester()
        CbKatSemester.Items.Clear()
        CbKatSemester.Items.Add("Ganjil")
        CbKatSemester.Items.Add("Genap")
        CbKatSemester.SelectedIndex = -1
    End Sub

    ' 3. EVENT: Ketika Kategori (Ganjil/Genap) dipilih, isi ComboBox Angka
    Private Sub CbKatSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbKatSemester.SelectedIndexChanged
        ' Jangan bersihkan jika sedang loading awal
        CbAngkaSemester.Items.Clear()

        If CbKatSemester.Text = "Ganjil" Then
            CbAngkaSemester.Items.AddRange(New Object() {"1", "3", "5", "7"})
        ElseIf CbKatSemester.Text = "Genap" Then
            CbAngkaSemester.Items.AddRange(New Object() {"2", "4", "6", "8"})
        End If

        CbAngkaSemester.SelectedIndex = -1
    End Sub

    ' 4. EVENT: Ketika Angka Semester dipilih, jalankan filter Database
    Private Sub CbAngkaSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbAngkaSemester.SelectedIndexChanged
        If Not isloading Then
            TampilkanDataMatkul()
        End If
    End Sub

    ' 5. Query Utama untuk Menampilkan Data
    Sub TampilkanDataMatkul(Optional kataKunci As String = "")
        Try
            Call KoneksiDB()

            Dim kdProdi As String = If(CmbNamaProdi.SelectedValue Is Nothing, "ALL", CmbNamaProdi.SelectedValue.ToString())
            Dim semester As String = CbAngkaSemester.Text

            ' Query dasar dengan JOIN sesuai ERD
            Dim sql As String = "SELECT DISTINCT m.Kd_Matkul, m.Nm_Matkul, m.Sks_Matkul, " &
                            "m.Teori_Matkul, m.Praktek_Matkul, m.Semester_Matkul " &
                            "FROM tbl_matakuliah m " &
                            "LEFT JOIN tbl_dosenpengampu_matkul pm ON m.Kd_Matkul = pm.Kd_Matkul " &
                            "LEFT JOIN tbl_dosen d ON pm.Kd_Dosen = d.Kd_Dosen " &
                            "WHERE 1=1 "

            ' Filter Prodi
            If kdProdi <> "ALL" Then
                sql &= " AND d.Kd_Prodi = @KdProdi"
            End If

            ' Filter Semester
            If semester <> "" Then
                sql &= " AND m.Semester_Matkul = @Semester"
            End If

            ' Filter CARI DATA (Berdasarkan Nama atau Kode)
            If kataKunci <> "" Then
                sql &= " AND (m.Nm_Matkul LIKE @Cari OR m.Kd_Matkul LIKE @Cari)"
            End If

            sql &= " ORDER BY m.Kd_Matkul ASC"

            Using CMD As New MySqlCommand(sql, DBKoneksi)
                If kdProdi <> "ALL" Then CMD.Parameters.AddWithValue("@KdProdi", kdProdi)
                If semester <> "" Then CMD.Parameters.AddWithValue("@Semester", semester)
                If kataKunci <> "" Then CMD.Parameters.AddWithValue("@Cari", "%" & kataKunci & "%")

                Using DA As New MySqlDataAdapter(CMD)
                    Dim DT As New DataTable
                    DA.Fill(DT)
                    DataGridMatkul.DataSource = DT
                End Using
            End Using

            AktifkanDataGridMatkul()
        Catch ex As Exception
            MsgBox("Gagal Mencari Data: " & ex.Message, vbCritical)
        End Try
    End Sub

    ' 6. Pengaturan Tampilan Grid
    Sub AktifkanDataGridMatkul()
        If DataGridMatkul.Columns.Count = 0 Then Exit Sub
        With DataGridMatkul
            .EnableHeadersVisualStyles = False
            .ColumnHeadersHeight = 35
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Dim headers() As String = {"Kode Matkul", "Nama Matkul", "SKS", "Teori", "Praktek", "Semester"}
            For i As Integer = 0 To Math.Min(headers.Length - 1, .Columns.Count - 1)
                .Columns(i).HeaderText = headers(i)
            Next
        End With
    End Sub

    Private Sub FrmMatkul_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isloading = True
        Call TampilkanFilterNamaProdi()
        Call IsiKategoriSemester()
        Call TampilkanDataMatkul()
        isloading = False
    End Sub

    Private Sub CmbNamaProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbNamaProdi.SelectedIndexChanged
        If isloading Then Exit Sub
        If CmbNamaProdi.SelectedIndex < 0 OrElse CmbNamaProdi.SelectedValue Is Nothing Then Exit Sub

        Dim kdProdiTerpilih As String = CmbNamaProdi.SelectedValue.ToString()
        Dim namaProdiTerpilih As String = CmbNamaProdi.Text

        ' Tampilkan data ke DataGrid terlebih dahulu
        Call TampilkanDataMatkul()

        ' Validasi: Jika bukan "ALL" dan Prodi tersebut belum punya Matkul
        If kdProdiTerpilih <> "ALL" AndAlso ProdiBelumAdaMatkul(kdProdiTerpilih) Then

            ' Tampilkan pesan konfirmasi
            Dim pesan As String = $"Belum ada Mata Kuliah untuk prodi {namaProdiTerpilih}." & vbCrLf &
                                  "Apakah Anda ingin membuat Data Mata Kuliah untuk prodi ini?"
            Dim respon As DialogResult = MessageBox.Show(pesan, "Data Kosong", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Jika User memilih "Yes"
            If respon = DialogResult.Yes Then
                ' Buka form FormBioMatkul
                Dim frmInput As New FrmDataMataKuliah()

                ' --- BAGIAN INI YANG DITAMBAHKAN ---
                ' Kirim nama prodi yang baru saja dipilih ke Form Input
                frmInput.NmProdiTerpilih = namaProdiTerpilih
                ' ------------------------------------

                ' Buka sebagai dialog
                If frmInput.ShowDialog() = DialogResult.OK Then
                    ' Refresh Grid jika user menekan Simpan di form input
                    Call TampilkanDataMatkul()
                End If
            End If
        End If
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Call TampilkanDataMatkul(TxtCari.Text.Trim)
    End Sub

    Private Sub DataGridMatkul_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridMatkul.CellMouseDoubleClick
        Try
            If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() = "ALL" Then Exit Sub
            If e.RowIndex < 0 OrElse DataGridMatkul.Rows.Count = 0 Then Exit Sub

            Dim KodeMatkul As String = DataGridMatkul.Rows(e.RowIndex).Cells("Kd_Matkul").Value.ToString()

            Call KoneksiDB()
            QUERY = "SELECT * FROM tbl_matakuliah WHERE Kd_Matkul = @KdMatkul"

            CMD = New MySqlCommand(QUERY, DBKoneksi)
            CMD.Parameters.AddWithValue("@KdMatkul", KodeMatkul)
            DR = CMD.ExecuteReader()

            If DR.Read() Then
                Dim formEdit As New FrmDataMataKuliah
                With formEdit
                    ' 1. KODE & NAMA
                    .LbKodeMatkul.Text = DR("Kd_Matkul").ToString()
                    .TextNamaMatkul.Text = DR("Nm_Matkul").ToString()

                    ' 2. JURUSAN (Kirim ke Variabel Public juga biar aman)
                    .NmProdiTerpilih = CmbNamaProdi.Text

                    ' 3. --- PERBAIKAN: KIRIM KE VARIABEL PENAMPUNG ---
                    .VarSks = DR("Sks_Matkul").ToString()
                    .VarTeori = DR("Teori_Matkul").ToString()
                    .VarPraktek = DR("Praktek_Matkul").ToString()
                    ' -------------------------------------------------

                    ' 4. SEMESTER
                    Dim sem As String = DR("Semester_Matkul").ToString()
                    .AngkaSemesterTerpilih = sem ' Kirim ke variabel public agar ditangkap di Load

                    ' Logika Ganjil/Genap
                    If Val(sem) Mod 2 = 1 Then
                        .NamaSemesterTerpilih = "Ganjil"
                    Else
                        .NamaSemesterTerpilih = "Genap"
                    End If

                    ' 5. UI Setup
                    .BtnSimpan.Text = "UBAH"
                    .BtnSimpan.BackColor = Color.Orange
                    .BtnHapus.Enabled = True
                    .BtnHapus.BackColor = Color.Red
                    .BtnKeluar.Text = "BATAL"
                End With

                If formEdit.ShowDialog() = DialogResult.OK Then
                    Call TampilkanDataMatkul()
                End If
            End If
            DR.Close()
        Catch ex As Exception
            MsgBox("Error Edit: " & ex.Message)
        End Try
    End Sub

    'function
    ' FUNGSI GENERATE KODE (Dipindahkan ke sini)
    Function GenerateKodeMatkul(namaProdi As String, angkaSemester As String) As String
        Dim prefix As String = "MK" ' Default
        Dim kodeBaru As String = ""

        ' 1. Tentukan Singkatan (Prefix)
        namaProdi = namaProdi.ToUpper()
        If namaProdi.Contains("PERANGKAT LUNAK") Then
            prefix = "TRPL"
        ElseIf namaProdi.Contains("MANUFACTUR") Then
            prefix = "TRM"
        ElseIf namaProdi.Contains("REKAYASA MEKATRONIKA") Then
            prefix = "TRMK"
        ElseIf namaProdi.Contains("LISTRIK") Then
            prefix = "TRL"
        End If

        ' 2. Pastikan semester valid
        Dim semester As String = If(angkaSemester = "", "1", angkaSemester)

        ' 3. Kode Default (jika belum ada data)
        kodeBaru = prefix & semester & "01"

        Try
            Call KoneksiDB()

            ' 4. Cari kode terakhir
            Dim polaPencarian As String = prefix & semester & "%"
            Dim sql As String = "SELECT Kd_Matkul FROM tbl_matakuliah " &
                                "WHERE Kd_Matkul LIKE @Pola " &
                                "ORDER BY LENGTH(Kd_Matkul) DESC, Kd_Matkul DESC LIMIT 1"

            Using cmd As New MySqlCommand(sql, DBKoneksi)
                cmd.Parameters.AddWithValue("@Pola", polaPencarian)
                Dim rd As MySqlDataReader = cmd.ExecuteReader()

                If rd.Read() Then
                    Dim kodeTerakhir As String = rd.GetString(0)
                    Dim urutanStr As String = kodeTerakhir.Substring(kodeTerakhir.Length - 2)
                    Dim urutanBaru As Integer = CInt(urutanStr) + 1
                    kodeBaru = prefix & semester & urutanBaru.ToString("00")
                End If
                rd.Close()
            End Using
        Catch ex As Exception
            MsgBox("Gagal generate kode: " & ex.Message)
        End Try

        Return kodeBaru
    End Function

    'validasi apakah prodi blm ada
    Function ProdiBelumAdaMatkul(kdProdi As String) As Boolean
        Try
            Call KoneksiDB()

            ' Query untuk menghitung jumlah mata kuliah unik yang terhubung dengan Prodi yang dipilih
            ' Relasi: Mata Kuliah -> Dosen Pengampu -> Dosen -> Prodi
            Dim sql As String = "SELECT COUNT(DISTINCT pm.Kd_Matkul) " &
                                "FROM tbl_dosen d " &
                                "INNER JOIN tbl_dosenpengampu_matkul pm ON d.Kd_Dosen = pm.Kd_Dosen " &
                                "WHERE d.Kd_Prodi = @KdProdi"

            Using CMD As New MySqlCommand(sql, DBKoneksi)
                CMD.Parameters.AddWithValue("@KdProdi", kdProdi)
                ' Jika hasilnya 0, berarti belum ada matkul (Return True)
                Dim jumlahMatkul As Integer = Convert.ToInt32(CMD.ExecuteScalar())
                Return jumlahMatkul = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error validasi prodi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub BtnTambahData_Click(sender As Object, e As EventArgs) Handles BtnTambahData.Click
        ' Validasi Filter
        If CmbNamaProdi.SelectedIndex < 0 Or CmbNamaProdi.Text = "-- SEMUA PRODI --" Then
            MsgBox("Silahkan pilih Prodi terlebih dahulu.", vbExclamation)
            Exit Sub
        End If
        If CbAngkaSemester.Text = "" Then
            MsgBox("Silahkan tentukan semester terlebih dahulu.", vbExclamation)
            Exit Sub
        End If

        Dim frmInput As New FrmDataMataKuliah()

        ' --- KIRIM DATA UNTUK TAMBAH BARU ---
        frmInput.NmProdiTerpilih = CmbNamaProdi.Text
        frmInput.NamaSemesterTerpilih = CbKatSemester.Text
        frmInput.AngkaSemesterTerpilih = CbAngkaSemester.Text

        ' Generate Kode
        frmInput.LbKodeMatkul.Text = GenerateKodeMatkul(CmbNamaProdi.Text, CbAngkaSemester.Text)

        If frmInput.ShowDialog() = DialogResult.OK Then
            Call TampilkanDataMatkul()
        End If
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Dim pesan As DialogResult = MessageBox.Show(
     "Apakah Anda yakin ingin keluar dari halaman Mata Kuliah?",
     "Konfirmasi Keluar",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Question)

        ' Jika user menekan tombol 'Yes', maka form akan ditutup
        If pesan = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class