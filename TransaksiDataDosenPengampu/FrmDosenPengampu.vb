Imports MySql.Data.MySqlClient
Public Class FrmDosenPengampu

    Dim CurrentPage As Integer = 1
    Dim PageSize As Integer = 10
    Dim TotalData As Integer = 0
    Dim TotalPage As Integer = 0
    Dim Offset As Integer = 0
    Dim PageCache As New Dictionary(Of String, DataTable)
    Dim LastCacheKey As String = ""

    Function GetChacheKey(page As Integer) As String
        Dim Prodi As String = If(CmbNamaProdi.SelectedValue Is Nothing, "", CmbNamaProdi.SelectedValue.ToString())
        Dim Semester As String = CmbNamaSemester.Text ' <-- Tambahkan ini
        Dim NamaDosen As String = TextKodeDosen.Text.Trim()
        Dim Limit As String = CbEntries.Text

        ' Masukkan semester ke dalam return string
        Return $"{Prodi}|{Semester}|{NamaDosen}|{Limit}|PAGE:{page}"
    End Function

    ' Fungsi untuk membuat Kode Pengampu Otomatis (PMK0001, PMK0002, dst)
    Function GenerateKodePengampu() As String
        Dim kodeBaru As String = "PMK0001"
        Try
            Call KoneksiDB()
            ' Ambil 1 kode terakhir yang paling besar
            Dim sql As String = "SELECT Kd_Pengampu FROM tbl_dosenpengampu_matkul ORDER BY Kd_Pengampu DESC LIMIT 1"
            CMD = New MySqlCommand(sql, DBKoneksi)
            DR = CMD.ExecuteReader()

            If DR.Read() Then
                Dim kodeTerakhir As String = DR("Kd_Pengampu").ToString() ' Contoh: PMK0031

                ' Ambil angka di belakang (4 digit)
                If kodeTerakhir.Length > 3 Then
                    Dim angkaStr As String = kodeTerakhir.Substring(3) ' Ambil "0031"
                    Dim angka As Integer = Val(angkaStr) + 1 ' Jadi 32

                    ' Gabungkan kembali: PMK + 0032
                    kodeBaru = "PMK" & angka.ToString("0000")
                End If
            End If
            DR.Close()
        Catch ex As Exception
            MsgBox("Gagal generate kode: " & ex.Message)
        End Try
        Return kodeBaru
    End Function

    Sub CleaPagingCache()
        PageCache.Clear()
        LastCacheKey = ""
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

    Sub NumberEntriesHalaman()
        CbEntries.Items.Add("10")
        CbEntries.Items.Add("15")
        CbEntries.Items.Add("20")
        CbEntries.Items.Add("25")
        CbEntries.Items.Add("50")
        CbEntries.Items.Add("100")
        CbEntries.SelectedIndex = 0
    End Sub

    Private isloading As Boolean = True

    Sub RefreshPaging()
        CurrentPage = 1
        PageCache.Clear()
        HitungTotalData()
        LoadPage()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        CurrentPage = 1
        BindingNavigatorPositionItem.Text = CurrentPage
        UpdateNavigatorState()
        TampilkanDataGridDosenPengampu()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        If CurrentPage > 1 Then
            CurrentPage -= 1
            BindingNavigatorPositionItem.Text = CurrentPage
            UpdateNavigatorState()
            TampilkanDataGridDosenPengampu()
        End If
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        If CurrentPage < TotalPage Then
            CurrentPage += 1
            BindingNavigatorPositionItem.Text = CurrentPage
            UpdateNavigatorState()
            TampilkanDataGridDosenPengampu()
            UpdateNavigatorState()
        End If
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        CurrentPage = TotalPage
        BindingNavigatorPositionItem.Text = CurrentPage
        UpdateNavigatorState()
        TampilkanDataGridDosenPengampu()
    End Sub

    Sub AktifkanDataGridDosenPengampu()
        With DataGridDosenPengampu
            .EnableHeadersVisualStyles = False
            .Font = New Font(DataGridDosenPengampu.Font, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Arial", 9)
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 35
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill   ' ✅ kolom isi penuh form

            ' Atur header dan alignment
            .Columns(0).HeaderText = "KODE"
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).HeaderText = "KODE DOSEN"
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(2).HeaderText = "NIDN"
            .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(3).HeaderText = "NAMA DOSEN"
            .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(4).HeaderText = "KODE MATAKULIAH"
            .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(5).HeaderText = "NAMA MATAKULIAH"
            .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(6).HeaderText = "SKS"
            .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(7).HeaderText = "SKS TEORI"
            .Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(8).HeaderText = "SKS PRAKTIK"
            .Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(9).HeaderText = "SEMESTER"
            .Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(10).HeaderText = "KELAS"
            .Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(11).HeaderText = "TAHUN AKADEMIK"
            .Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(12).HeaderText = "NAMA SEMESTER"
            .Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Sub LoadPage()
        ' 1. Hitung Offset & Cache Key
        Offset = (CurrentPage - 1) * PageSize
        Dim cacheKey As String = GetChacheKey(CurrentPage)

        ' 2. Cek Cache (Jika ada, langsung pakai)
        If PageCache.ContainsKey(cacheKey) Then
            DataGridDosenPengampu.DataSource = PageCache(cacheKey)
            UpdateNavigatorState()
            Exit Sub
        End If

        Call KoneksiDB()

        ' 3. Query Utama (JOIN 4 Tabel agar data lengkap)
        QUERY = "SELECT pm.Kd_Pengampu, d.Kd_Dosen, d.NIDN_Dosen, d.Nm_Dosen, " &
                "m.Kd_Matkul, m.Nm_Matkul, m.Sks_Matkul, m.Teori_Matkul, m.Praktek_Matkul, " &
                "m.Semester_Matkul, pm.Nama_Kelas, pm.Tahun_Akademik, " &
                "CASE WHEN m.Semester_Matkul % 2 != 0 THEN 'GANJIL' ELSE 'GENAP' END AS Nama_Semester " &
                "FROM tbl_dosenpengampu_matkul pm " &
                "JOIN tbl_dosen d ON pm.Kd_Dosen = d.Kd_Dosen " &
                "JOIN tbl_matakuliah m ON pm.Kd_Matkul = m.Kd_Matkul " &
                "JOIN tbl_prodi p ON d.Kd_Prodi = p.Kd_Prodi"

        Dim whereClauses As New List(Of String)

        ' 4. Filter Jurusan
        If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() <> "ALL" Then
            whereClauses.Add("d.Kd_Prodi = @KdProdi")
        End If

        ' 5. Filter Semester (Ganjil/Genap)
        If CmbNamaSemester.Text = "GANJIL" Then
            whereClauses.Add("m.Semester_Matkul % 2 != 0")
        ElseIf CmbNamaSemester.Text = "GENAP" Then
            whereClauses.Add("m.Semester_Matkul % 2 = 0")
        End If

        ' 6. Filter Kode Dosen
        If TextKodeDosen.Text.Trim() <> "" Then
            whereClauses.Add("d.Kd_Dosen LIKE @KodeDosen")
        End If

        ' Gabungkan WHERE jika ada kondisi filter
        If whereClauses.Count > 0 Then
            QUERY &= " WHERE " & String.Join(" AND ", whereClauses)
        End If

        ' Tambahkan LIMIT & OFFSET untuk Pagination
        QUERY &= " ORDER BY pm.Kd_Pengampu ASC LIMIT @Offset, @Limit"

        ' 7. Eksekusi Query
        Using DA As New MySqlDataAdapter(QUERY, DBKoneksi)
            ' Parameter Wajib Paging
            DA.SelectCommand.Parameters.AddWithValue("@Offset", Offset)
            DA.SelectCommand.Parameters.AddWithValue("@Limit", PageSize)

            ' Parameter Filter (Hanya ditambahkan jika filter aktif)
            If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() <> "ALL" Then
                DA.SelectCommand.Parameters.AddWithValue("@KdProdi", CmbNamaProdi.SelectedValue.ToString())
            End If

            If TextKodeDosen.Text.Trim() <> "" Then
                DA.SelectCommand.Parameters.AddWithValue("@KodeDosen", "%" & TextKodeDosen.Text.Trim() & "%")
            End If

            Dim dt As New DataTable
            DA.Fill(dt)

            ' Simpan ke Cache & Tampilkan
            PageCache(cacheKey) = dt
            DataGridDosenPengampu.DataSource = dt
        End Using

        ' 8. Atur UI (Header & Navigasi)
        AktifkanDataGridDosenPengampu()
        UpdateNavigatorState()
    End Sub

    Sub UpdateNavigator()
        BindingNavigatorPositionItem.Text = CurrentPage.ToString()
        BindingNavigatorCountItem.Text = $"of {TotalPage}"

        BindingNavigatorMoveFirstItem.Enabled = CurrentPage > 1
        BindingNavigatorMovePreviousItem.Enabled = CurrentPage > 1
        BindingNavigatorMoveNextItem.Enabled = CurrentPage < TotalPage
        BindingNavigatorMoveLastItem.Enabled = CurrentPage < TotalPage
    End Sub

    Sub UpdateNavigatorState()
        BindingNavigatorMoveFirstItem.Enabled = (CurrentPage > 1)
        BindingNavigatorMovePreviousItem.Enabled = (CurrentPage > 1)

        BindingNavigatorMoveNextItem.Enabled = (CurrentPage < TotalPage)
        BindingNavigatorMoveLastItem.Enabled = (CurrentPage < TotalPage)

        BindingNavigatorPositionItem.Text = CurrentPage.ToString()
        BindingNavigatorCountItem.Text = $"of {TotalPage}"
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

    Sub TampilkanDataGridDosenPengampu()
        Try
            ' ... (Bagian PageSize & Cache tetap sama) ...
            PageSize = Val(CbEntries.Text)
            If PageSize <= 0 Then PageSize = 10
            Offset = (CurrentPage - 1) * PageSize

            Dim CacheKey As String = GetChacheKey(CurrentPage)

            If PageCache.ContainsKey(CacheKey) Then
                DataGridDosenPengampu.DataSource = PageCache(CacheKey)
                UpdateNavigatorState()
                Exit Sub
            End If

            Call KoneksiDB()

            ' ... (Query SELECT tetap sama) ...
            QUERY = "SELECT pm.Kd_Pengampu, d.Kd_Dosen, d.NIDN_Dosen, d.Nm_Dosen, " &
                    "m.Kd_Matkul, m.Nm_Matkul, m.Sks_Matkul, m.Teori_Matkul, m.Praktek_Matkul, " &
                    "m.Semester_Matkul, pm.Nama_Kelas, pm.Tahun_Akademik, " &
                    "CASE WHEN m.Semester_Matkul % 2 != 0 THEN 'GANJIL' ELSE 'GENAP' END AS Nama_Semester " &
                    "FROM tbl_dosenpengampu_matkul pm " &
                    "JOIN tbl_dosen d ON pm.Kd_Dosen = d.Kd_Dosen " &
                    "JOIN tbl_matakuliah m ON pm.Kd_Matkul = m.Kd_Matkul " &
                    "JOIN tbl_prodi p ON d.Kd_Prodi = p.Kd_Prodi"

            Dim whereClauses As New List(Of String)

            ' Filter Jurusan
            If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() <> "ALL" Then
                whereClauses.Add("d.Kd_Prodi = @KdProdi")
            End If

            ' ✅ PERBAIKAN UTAMA: Gunakan .ToUpper()
            ' Ini agar "Ganjil", "ganjil", atau "GANJIL" terbaca sama
            If CmbNamaSemester.Text.ToUpper() = "GANJIL" Then
                whereClauses.Add("m.Semester_Matkul % 2 != 0")
            ElseIf CmbNamaSemester.Text.ToUpper() = "GENAP" Then
                whereClauses.Add("m.Semester_Matkul % 2 = 0")
            End If

            ' Filter Kode Dosen
            If TextKodeDosen.Text.Trim() <> "" Then
                whereClauses.Add("d.Kd_Dosen LIKE @KodeDosen")
            End If

            ' Gabung WHERE
            If whereClauses.Count > 0 Then
                QUERY &= " WHERE " & String.Join(" AND ", whereClauses)
            End If

            QUERY &= " ORDER BY pm.Kd_Pengampu ASC LIMIT @Offset, @Limit"

            Using DA As New MySqlDataAdapter(QUERY, DBKoneksi)
                DA.SelectCommand.Parameters.AddWithValue("@Offset", Offset)
                DA.SelectCommand.Parameters.AddWithValue("@Limit", PageSize)

                If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() <> "ALL" Then
                    DA.SelectCommand.Parameters.AddWithValue("@KdProdi", CmbNamaProdi.SelectedValue.ToString())
                End If
                If TextKodeDosen.Text.Trim() <> "" Then
                    DA.SelectCommand.Parameters.AddWithValue("@KodeDosen", "%" & TextKodeDosen.Text.Trim() & "%")
                End If

                Dim DT As New DataTable
                DA.Fill(DT)
                PageCache(CacheKey) = DT
                DataGridDosenPengampu.DataSource = DT
                DataGridDosenPengampu.ReadOnly = True

                ' Update label baris
                LbJumlahBaris.Text = "Baris di halaman " & CurrentPage & ": " & DT.Rows.Count
            End Using

            ' Hitung Total Data & Update Navigasi
            HitungTotalData()
            UpdateNavigatorState()

        Catch ex As Exception
            MessageBox.Show("Error Tampil Data: " & ex.Message)
        End Try
        AktifkanDataGridDosenPengampu()
    End Sub

    Sub HitungTotalData()
        Try
            Call KoneksiDB()

            Dim QUERY As String = "SELECT COUNT(*) " &
                                  "FROM tbl_dosenpengampu_matkul pm " &
                                  "JOIN tbl_dosen d ON pm.Kd_Dosen = d.Kd_Dosen " &
                                  "JOIN tbl_matakuliah m ON pm.Kd_Matkul = m.Kd_Matkul " &
                                  "JOIN tbl_prodi p ON d.Kd_Prodi = p.Kd_Prodi"

            Dim whereClauses As New List(Of String)

            If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() <> "ALL" Then
                whereClauses.Add("d.Kd_Prodi = @KdProdi")
            End If

            ' ✅ PERBAIKAN DI SINI JUGA
            If CmbNamaSemester.Text.ToUpper() = "GANJIL" Then
                whereClauses.Add("m.Semester_Matkul % 2 != 0")
            ElseIf CmbNamaSemester.Text.ToUpper() = "GENAP" Then
                whereClauses.Add("m.Semester_Matkul % 2 = 0")
            End If

            If TextKodeDosen.Text.Trim() <> "" Then
                whereClauses.Add("d.Kd_Dosen LIKE @KodeDosen")
            End If

            If whereClauses.Count > 0 Then
                QUERY &= " WHERE " & String.Join(" AND ", whereClauses)
            End If

            Using CMD As New MySqlCommand(QUERY, DBKoneksi)
                If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() <> "ALL" Then
                    CMD.Parameters.AddWithValue("@KdProdi", CmbNamaProdi.SelectedValue.ToString())
                End If
                If TextKodeDosen.Text.Trim() <> "" Then
                    CMD.Parameters.AddWithValue("@KodeDosen", "%" & TextKodeDosen.Text.Trim() & "%")
                End If

                TotalData = Convert.ToInt32(CMD.ExecuteScalar())
            End Using

            If PageSize <= 0 Then PageSize = 10
            TotalPage = Math.Ceiling(TotalData / PageSize)
            If TotalPage < 1 Then TotalPage = 1

            LbTotalBaris.Text = "Jumlah Baris Entri: " & TotalData
            LbHasilBagiHalaman.Text = "Jumlah Halaman: " & TotalPage

        Catch ex As Exception
            MessageBox.Show("Error HitungTotalData: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CariDataDosen(kodeDosen As String)
        ' Jika kotak kosong, bersihkan label dan keluar
        If kodeDosen = "" Then
            LbNidnPengampu.Text = "-"
            LbNamaDosenPengampu.Text = "-"
            Exit Sub
        End If

        Try
            Call KoneksiDB()

            ' Ambil NIDN dan Nama dari tabel Master Dosen
            Dim sql As String = "SELECT NIDN_Dosen, Nm_Dosen FROM tbl_dosen WHERE Kd_Dosen = @Kd"

            Using cmd As New MySqlCommand(sql, DBKoneksi)
                cmd.Parameters.AddWithValue("@Kd", kodeDosen)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        ' Jika kode ditemukan, isi label
                        LbNidnPengampu.Text = dr("NIDN_Dosen").ToString()
                        LbNamaDosenPengampu.Text = dr("Nm_Dosen").ToString()
                    Else
                        ' Jika kode tidak ada di database
                        LbNidnPengampu.Text = "Tidak Ditemukan"
                        LbNamaDosenPengampu.Text = "Tidak Ditemukan"
                    End If
                End Using
            End Using

        Catch ex As Exception
            ' Abaikan error kecil saat mengetik
        End Try
    End Sub

    Sub TampilkanFilterProdi()
        Try
            Call KoneksiDB()

            ' Ambil data prodi dari database
            QUERY = "SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Kd_Prodi"
            DA = New MySqlDataAdapter(QUERY, DBKoneksi)

            Dim DT As New DataTable
            DA.Fill(DT)

            ' Tambahkan opsi "-- SEMUA PRODI --" di paling atas
            Dim row As DataRow = DT.NewRow()
            row("Kd_Prodi") = "ALL"
            row("Nm_Prodi") = "-- SEMUA PRODI --"
            DT.Rows.InsertAt(row, 0)

            ' Sesuaikan dengan nama ComboBox di FrmDosenPengampu (CmbNamaProdi)
            CmbNamaProdi.DataSource = DT
            CmbNamaProdi.DisplayMember = "Nm_Prodi"
            CmbNamaProdi.ValueMember = "Kd_Prodi"
            CmbNamaProdi.SelectedIndex = 0

            ' (Opsional) Jika tidak ada label kode jurusan di form ini, baris di bawah bisa dihapus
            ' lbKodeJurusan.Text = "" 

        Catch ex As Exception
            MsgBox("Gagal memuat data Prodi: " & ex.Message, vbCritical)
        End Try
    End Sub

    Sub IsiFilterSemester()
        CmbNamaSemester.Items.Clear()
        CmbNamaSemester.Items.Add("Ganjil")
        CmbNamaSemester.Items.Add("Genap")
        CmbNamaSemester.SelectedIndex = -1
    End Sub

    ' Sub untuk menyegarkan data setelah Simpan/Ubah/Hapus
    Public Sub RefreshData()
        Try
            ' Kita reset ke halaman 1, tapi Filter (Kode Dosen/Jurusan) JANGAN dihapus
            ' agar user tetap melihat data yang barusan dia edit.
            CurrentPage = 1
            PageCache.Clear()
            BindingNavigatorPositionItem.Text = "1"

            HitungTotalData()
            TampilkanDataGridDosenPengampu()
            UpdateNavigatorState()
        Catch ex As Exception
            MessageBox.Show("Gagal refresh data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmDosenPengampu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isloading = True ' Cegah event change berjalan saat loading awal

            ' 1. Buka Koneksi
            Call KoneksiDB()

            ' 2. Isi ComboBox Entries (PENTING AGAR TIDAK ERROR OVERFLOW)
            Call NumberEntriesHalaman()

            ' 3. Isi Filter Jurusan & Semester
            Call TampilkanFilterProdi()
            Call IsiFilterSemester()

            ' 4. Reset Paging & Tampilkan Data
            CurrentPage = 1
            PageCache.Clear()
            BindingNavigatorPositionItem.Text = "1"

            Call TampilkanDataGridDosenPengampu()

        Catch ex As Exception
            MsgBox("Error Load: " & ex.Message)
        Finally
            isloading = False
        End Try
    End Sub

    Private Sub CmbNamaProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbNamaProdi.SelectedIndexChanged
        ' 1. Validasi Awal (Guard Clause)
        If isloading Then Exit Sub
        If CmbNamaProdi.SelectedIndex < 0 Then Exit Sub
        If CmbNamaProdi.SelectedValue Is Nothing Then Exit Sub

        Try
            Dim Kode_Prodi As String = CmbNamaProdi.SelectedValue.ToString()

            ' 2. Jika pilih ALL -> Tampilkan semua, reset halaman
            If Kode_Prodi = "ALL" Then
                ' Jika ada tombol tambah, bisa di-disable disini jika perlu
                ' BtnTambah.Enabled = False 

                ' Reset Paging
                CurrentPage = 1
                PageCache.Clear()
                BindingNavigatorPositionItem.Text = "1"

                ' Hitung ulang total data & Tampilkan
                HitungTotalData()
                TampilkanDataGridDosenPengampu()
                Exit Sub
            Else
                ' Jika pilih Prodi tertentu
                ' BtnTambah.Enabled = True
            End If

            ' 3. Jika bukan ALL (Prodi Tertentu) -> Reset Paging & Filter
            CurrentPage = 1
            PageCache.Clear()
            BindingNavigatorPositionItem.Text = "1"

            ' Hitung ulang total data & Tampilkan
            HitungTotalData()
            TampilkanDataGridDosenPengampu()

        Catch ex As Exception
            MsgBox("Error Memilih Prodi: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub CmbNamaSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbNamaSemester.SelectedIndexChanged
        ' 1. Cek apakah form masih loading (agar tidak error saat start)
        If isloading Then Exit Sub

        Try
            ' 2. Reset Paging ke Halaman 1
            ' Setiap kali filter semester berubah, kita wajib mulai dari halaman awal lagi
            CurrentPage = 1
            PageCache.Clear() ' Hapus cache lama karena datanya sudah berubah (difilter)
            BindingNavigatorPositionItem.Text = "1"

            ' 3. Panggil Fungsi Utama
            ' Fungsi ini akan membaca teks di CmbNamaSemester (Ganjil/Genap)
            ' dan otomatis memasukkan rumus SQL: m.Semester_Matkul % 2 ...
            HitungTotalData()
            TampilkanDataGridDosenPengampu()

        Catch ex As Exception
            MsgBox("Error Memilih Semester: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub TextKodeDosen_TextChanged(sender As Object, e As EventArgs) Handles TextKodeDosen.TextChanged
        ' Cegah error saat form baru loading
        If isloading Then Exit Sub

        ' 1. Cari Data Dosen untuk mengisi Label (NIDN & Nama)
        Call CariDataDosen(TextKodeDosen.Text.Trim())

        ' 2. Update DataGrid (Filter otomatis jalan karena TampilkanDataGrid membaca TextKodeDosen)
        ' Reset ke halaman 1 agar hasil pencarian akurat
        CurrentPage = 1
        PageCache.Clear()
        BindingNavigatorPositionItem.Text = "1"

        HitungTotalData()
        TampilkanDataGridDosenPengampu()
    End Sub

    Private Sub BtnTambahData_Click(sender As Object, e As EventArgs) Handles BtnTambahData.Click
        ' 1. Validasi Input
        If CmbNamaProdi.SelectedIndex < 0 OrElse CmbNamaProdi.SelectedValue Is Nothing OrElse CmbNamaProdi.SelectedValue.ToString() = "ALL" Then
            MsgBox("Silahkan pilih 'Nama Jurusan' yang spesifik terlebih dahulu!", vbExclamation, "Peringatan")
            CmbNamaProdi.Focus()
            Exit Sub
        End If

        If CmbNamaSemester.SelectedIndex < 0 OrElse CmbNamaSemester.Text = "" Then
            MsgBox("Silahkan pilih 'Nama Semester' terlebih dahulu!", vbExclamation, "Peringatan")
            CmbNamaSemester.Focus()
            Exit Sub
        End If

        Try
            Dim frmInput As New FrmDataDosenPengampu
            Dim KodeBaru As String = GenerateKodePengampu()

            With frmInput
                ' ✅ PERBAIKAN: Kirim ke Variabel Public, bukan ke Control langsung
                .StrProdi = CmbNamaProdi.Text          ' Kirim Teks Prodi
                .StrSemester = CmbNamaSemester.Text    ' Kirim Teks Semester

                ' Kode Pengampu & Label (Langsung ke control tidak apa-apa karena text sederhana)
                .LbKodePengampu.Text = KodeBaru

                ' Atur Tombol
                .BtnSimpan.Text = "SIMPAN"
                .BtnHapus.Enabled = False
                .BtnHapus.BackColor = Color.Red
                .BtnKeluar.Text = "KELUAR"
            End With

            ' Tampilkan Form
            If frmInput.ShowDialog() = DialogResult.OK Then
                ' Refresh Data Grid
                CurrentPage = 1
                PageCache.Clear()
                BindingNavigatorPositionItem.Text = "1"

                HitungTotalData()
                TampilkanDataGridDosenPengampu()
            End If

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub DataGridDosenPengampu_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridDosenPengampu.CellMouseDoubleClick
        ' 1. Guard Clauses
        If isloading Then Exit Sub
        If e.RowIndex < 0 OrElse DataGridDosenPengampu.Rows.Count = 0 Then Exit Sub

        ' 2. Validasi Filter ALL
        If CmbNamaProdi.SelectedValue IsNot Nothing AndAlso CmbNamaProdi.SelectedValue.ToString() = "ALL" Then
            Exit Sub
        End If

        Try
            Dim IDPengampu As String = DataGridDosenPengampu.Rows(e.RowIndex).Cells("Kd_Pengampu").Value.ToString()
            Call KoneksiDB()

            ' 3. Ambil Data
            Dim sql As String = "SELECT pm.*, d.NIDN_Dosen, d.Nm_Dosen, m.Nm_Matkul, m.Sks_Matkul, m.Teori_Matkul, m.Praktek_Matkul, m.Semester_Matkul " &
                                "FROM tbl_dosenpengampu_matkul pm " &
                                "JOIN tbl_dosen d ON pm.Kd_Dosen = d.Kd_Dosen " &
                                "JOIN tbl_matakuliah m ON pm.Kd_Matkul = m.Kd_Matkul " &
                                "WHERE pm.Kd_Pengampu = @id"

            CMD = New MySqlCommand(sql, DBKoneksi)
            CMD.Parameters.AddWithValue("@id", IDPengampu)
            DR = CMD.ExecuteReader()

            If DR.Read() Then
                Dim formEdit As New FrmDataDosenPengampu

                With formEdit
                    ' --- Kirim Data ke Variabel Penampung ---
                    .StrProdi = CmbNamaProdi.Text
                    .StrSemester = CmbNamaSemester.Text
                    .StrKelas = DR("Nama_Kelas").ToString()
                    .StrTahunAkademik = DR("Tahun_Akademik").ToString()

                    ' --- Isi Kontrol ---
                    .LbKodePengampu.Text = DR("Kd_Pengampu").ToString()
                    .TextNoIdentitas.Text = DR("Kd_Dosen").ToString()
                    .LbNidn.Text = DR("NIDN_Dosen").ToString()
                    .LbNamaDosen.Text = DR("Nm_Dosen").ToString()

                    .TextKodeMatkul.Text = DR("Kd_Matkul").ToString()
                    .LbNamaMatkul.Text = DR("Nm_Matkul").ToString()
                    .LbSks.Text = DR("Sks_Matkul").ToString()
                    .LbSksTeori.Text = DR("Teori_Matkul").ToString()
                    .LbSksPraktek.Text = DR("Praktek_Matkul").ToString()
                    .LbSemester.Text = DR("Semester_Matkul").ToString()

                    ' --- Atur Tombol & Mode ---
                    .BtnSimpan.Text = "UBAH"
                    .BtnSimpan.BackColor = Color.CornflowerBlue
                    .BtnHapus.Enabled = True
                    .BtnHapus.BackColor = Color.CornflowerBlue
                    .BtnKeluar.Text = "BATAL"

                    ' Enable Semester agar user bisa lihat/ubah jika perlu
                    .CmbSemester.Enabled = True
                End With

                DR.Close()

                ' 4. Tampilkan Form Edit & Cek Hasilnya
                If formEdit.ShowDialog() = DialogResult.OK Then

                    ' ✅ LOGIKA BARU DI SINI:
                    ' Ambil Angka Semester Terakhir dari Form Input (yang baru saja disimpan)
                    Dim AngkaSemesterBaru As Integer = Val(formEdit.LbSemester.Text)

                    ' Cek apakah Ganjil atau Genap, lalu ubah Filter di Form Utama
                    If AngkaSemesterBaru > 0 Then
                        If AngkaSemesterBaru Mod 2 <> 0 Then
                            CmbNamaSemester.Text = "GANJIL" ' Pindah filter ke Ganjil
                        Else
                            CmbNamaSemester.Text = "GENAP"  ' Pindah filter ke Genap
                        End If
                    End If

                    ' Refresh Data (Otomatis akan mengikuti filter CmbNamaSemester yang baru diset diatas)
                    RefreshData()
                End If
            Else
                DR.Close()
            End If

        Catch ex As Exception
            MsgBox("Error membuka data: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Pesan = MsgBox("Anda yakin mau keluar dari from data dosen", vbQuestion + vbYesNo, "Informasi")
        If Pesan = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub CbEntries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbEntries.SelectedIndexChanged
        If CbEntries.SelectedIndex = -1 Then Exit Sub

        PageSize = CInt(CbEntries.Text)
        RefreshPaging()
    End Sub


End Class