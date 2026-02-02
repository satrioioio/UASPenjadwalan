Imports MySql.Data.MySqlClient
Public Class FormPenjadwalanMatkul
    Dim PosisiHalaman As Integer = 0
    Dim JumlahBarisPerHalaman As Integer = 10 ' Sesuai "Tampil Data: 10" di gambar
    Dim TotalBaris As Integer = 0
    Dim IsLoading As Boolean = True

    Sub TampilkanProdi()
        Try
            Call KoneksiDb()
            Dim sql As String = "SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Nm_Prodi ASC"
            Dim DA As New MySqlDataAdapter(sql, DBKoneksi)
            Dim DT As New DataTable
            DA.Fill(DT)

            ' Tambah baris "ALL" ke dalam DataTable prodi
            Dim dr As DataRow = DT.NewRow()
            dr("Kd_Prodi") = "ALL"
            dr("Nm_Prodi") = "ALL"
            DT.Rows.InsertAt(dr, 0)

            CbNmJurusan.DataSource = DT
            CbNmJurusan.DisplayMember = "Nm_Prodi"
            CbNmJurusan.ValueMember = "Kd_Prodi"

            ' Set default ke "ALL"
            CbNmJurusan.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Gagal memuat prodi: " & ex.Message)
        End Try
    End Sub

    Private Sub FormPenjadwalanMatkul_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsLoading = True

        CbEntries.Items.Clear()
        CbEntries.Items.AddRange(New Object() {"10", "15", "20", "25"})
        CbEntries.SelectedIndex = 0 ' Pilih angka 10 secara default
        JumlahBarisPerHalaman = 10

        ' Inisialisasi pilihan Semester dengan "ALL"
        CbNmSemester.Items.Clear()
        CbNmSemester.Items.AddRange(New Object() {"ALL", "GANJIL", "GENAP"})
        CbNmSemester.SelectedIndex = 0

        ' Inisialisasi pilihan Tahun Akademik dengan "ALL"
        CbThAkademik.Items.Clear()
        CbThAkademik.Items.AddRange(New Object() {"ALL", "2023/2024", "2024/2025", "2025/2026"})
        CbThAkademik.SelectedIndex = 0

        Call TampilkanProdi()

        IsLoading = False
        ' Memanggil data untuk pertama kali (memaparkan semua data)
        Call TampilkanDataJadwal()
    End Sub

    Sub AturGridPenjadwalan()
        If DataGridView1.ColumnCount > 0 Then
            With DataGridView1
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                .Columns(0).HeaderText = "NO"
                .Columns(0).Width = 40
                .Columns(1).HeaderText = "KODE PENGAMPU"
                .Columns(2).HeaderText = "TAHUN AKADEMIK"
                .Columns(3).HeaderText = "HARI"
                .Columns(4).HeaderText = "NAMA SEMESTER"
                .Columns(5).HeaderText = "JAM AWAL"
                .Columns(6).HeaderText = "JAM AKHIR"
                .Columns(7).HeaderText = "NAMA DOSEN"
                .Columns(8).HeaderText = "SEMESTER"
                .Columns(9).HeaderText = "KODE"
                .Columns(10).HeaderText = "NAMA MATAKULIAH"
                .Columns(11).HeaderText = "SKS"
                .Columns(12).HeaderText = "SKS TEORI"
                .Columns(13).HeaderText = "SKS PRAKTIK"
                .Columns(14).HeaderText = "NAMA RUANG"

                ' Membuat Row Header tidak terlihat jika nomor sudah ada di kolom 0
                .RowHeadersVisible = False
                .AllowUserToAddRows = False
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
        End If
    End Sub

    Sub TampilkanDataJadwal()
        If IsLoading Then Exit Sub
        Try
            Call KoneksiDb()

            Dim prodi As String = If(CbNmJurusan.SelectedValue Is Nothing, "ALL", CbNmJurusan.SelectedValue.ToString())
            Dim semFilter As String = CbNmSemester.Text
            Dim ta As String = CbThAkademik.Text
            ' Ambil teks pencarian dari TextBox
            Dim teksCari As String = "%" & TxtCariNama.Text & "%"

            ' Logika WHERE Utama
            Dim kriteria As String = "WHERE (d.Kd_Prodi = @prodi OR @prodi = 'ALL') " &
                                 "AND (p.Tahun_Akademik = @ta OR @ta = 'ALL') " &
                                 "AND (d.Nm_Dosen LIKE @cari) " ' Tambahkan filter Nama Dosen

            ' Filter Ganjil/Genap
            If semFilter = "GANJIL" Then
                kriteria &= "AND (m.Semester_Matkul % 2 <> 0) "
            ElseIf semFilter = "GENAP" Then
                kriteria &= "AND (m.Semester_Matkul % 2 = 0) "
            End If

            ' 1. Hitung Total Baris (PENTING untuk Navigasi/Halaman)
            Dim sqlTotal As String = "SELECT COUNT(*) FROM tbl_jadwal_matkul j " &
                                "JOIN tbl_dosenpengampu_matkul p ON j.Kd_Pengampu = p.Kd_Pengampu " &
                                "JOIN tbl_dosen d ON p.Kd_Dosen = d.Kd_Dosen " &
                                "JOIN tbl_matakuliah m ON p.Kd_Matkul = m.Kd_Matkul " & kriteria

            Using cmdTotal As New MySqlCommand(sqlTotal, DBKoneksi)
                cmdTotal.Parameters.AddWithValue("@prodi", prodi)
                cmdTotal.Parameters.AddWithValue("@ta", ta)
                cmdTotal.Parameters.AddWithValue("@cari", teksCari)
                TotalBaris = Convert.ToInt32(cmdTotal.ExecuteScalar)
            End Using

            ' 2. Jika data benar-benar kosong, munculkan pesan
            If TotalBaris = 0 Then
                If TxtCariNama.Text.Trim <> "" Then
                    MessageBox.Show("Data dosen '" & TxtCariNama.Text & "' tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                DataGridView1.DataSource = Nothing
                UpdateFooterPagination()
                Exit Sub
            End If

            ' 3. Query Ambil Data dengan LIMIT & OFFSET
            Dim sql As String = "SELECT j.Kd_Pengampu, p.Tahun_Akademik, h.Nm_Hari, " &
                           "IF(m.Semester_Matkul % 2 = 0, 'GENAP', 'GANJIL') as Nama_Semester, " &
                           "j.JamAwal, j.JamAkhir, d.Nm_Dosen, m.Semester_Matkul as Sem, m.Kd_Matkul, " &
                           "m.Nm_Matkul, m.Sks_Matkul, m.Teori_Matkul, m.Praktek_Matkul, r.Nm_Ruangan " &
                           "FROM tbl_jadwal_matkul j " &
                           "JOIN tbl_dosenpengampu_matkul p ON j.Kd_Pengampu = p.Kd_Pengampu " &
                           "JOIN tbl_dosen d ON p.Kd_Dosen = d.Kd_Dosen " &
                           "JOIN tbl_matakuliah m ON p.Kd_Matkul = m.Kd_Matkul " &
                           "JOIN tbl_hari h ON j.Id_Hari = h.Id_Hari " &
                           "JOIN tbl_ruangkelas r ON j.Kd_Ruangan = r.Kd_Ruangan " &
                           kriteria & " LIMIT @limit OFFSET @offset"

            Using CMD As New MySqlCommand(sql, DBKoneksi)
                CMD.Parameters.AddWithValue("@prodi", prodi)
                CMD.Parameters.AddWithValue("@ta", ta)
                CMD.Parameters.AddWithValue("@cari", teksCari)
                CMD.Parameters.AddWithValue("@limit", JumlahBarisPerHalaman)
                CMD.Parameters.AddWithValue("@offset", PosisiHalaman * JumlahBarisPerHalaman)

                Dim DA As New MySqlDataAdapter(CMD)
                Dim DT As New DataTable
                DA.Fill(DT)

                ' Proses Penomoran (NO)
                Dim DTFinal As New DataTable
                DTFinal.Columns.Add("NO", GetType(Integer))
                DTFinal.Merge(DT)
                For i As Integer = 0 To DTFinal.Rows.Count - 1
                    DTFinal.Rows(i)("NO") = (PosisiHalaman * JumlahBarisPerHalaman) + i + 1
                Next

                DataGridView1.DataSource = DTFinal
                Call AturGridPenjadwalan()
                UpdateFooterPagination()
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Sub UpdateFooterPagination()
        Dim totalHalaman As Integer = Math.Ceiling(TotalBaris / JumlahBarisPerHalaman)
        If totalHalaman <= 0 Then totalHalaman = 1

        Dim halamanSekarang As Integer = PosisiHalaman + 1

        ' Update Label Footer
        lbTotalHal.Text = TotalBaris.ToString()
        lbJumlahHal.Text = totalHalaman.ToString()
        lbJmlhEntries.Text = DataGridView1.Rows.Count.ToString()

        ' Update Tampilan di BindingNavigator (Sesuaikan nama objeknya)
        ' Biasanya ToolStripTextBox1 untuk kotak angka dan ToolStripLabel1 untuk "of {0}"
        BindingNavigatorPositionItem.Text = halamanSekarang.ToString()
        BindingNavigatorCountItem.Text = "of " & totalHalaman.ToString()
    End Sub

    Private Sub CbNmJurusan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbNmJurusan.SelectedIndexChanged
        If IsLoading Then Exit Sub
        ' Logika 2 digit kode prodi
        If CbNmJurusan.SelectedValue IsNot Nothing AndAlso CbNmJurusan.SelectedValue.ToString() <> "ALL" Then
            Dim kodeFull As String = CbNmJurusan.SelectedValue.ToString()
            lbKdProdi.Text = Microsoft.VisualBasic.Strings.Right(kodeFull, 2)
        Else
            lbKdProdi.Text = "00" ' Default jika ALL
        End If

        PosisiHalaman = 0
        Call TampilkanDataJadwal()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        If (PosisiHalaman + 1) * JumlahBarisPerHalaman < TotalBaris Then
            PosisiHalaman += 1
            Call TampilkanDataJadwal()
        End If
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        If PosisiHalaman > 0 Then
            PosisiHalaman -= 1
            Call TampilkanDataJadwal()
        End If
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        ' Hitung maksimal halaman yang tersedia
        Dim maxHalaman As Integer = Math.Ceiling(TotalBaris / JumlahBarisPerHalaman) - 1
        If PosisiHalaman < maxHalaman Then
            PosisiHalaman += 1
            Call TampilkanDataJadwal()
        End If
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        Dim maxHalaman As Integer = Math.Ceiling(TotalBaris / JumlahBarisPerHalaman) - 1
        If PosisiHalaman < maxHalaman Then
            PosisiHalaman = maxHalaman
            Call TampilkanDataJadwal()
        End If
    End Sub

    Private Sub CbEntries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbEntries.SelectedIndexChanged
        If IsLoading Then Exit Sub
        ' Validasi agar tidak error saat program baru jalan
        If CbEntries.SelectedItem IsNot Nothing Then
            ' Update jumlah baris berdasarkan pilihan (10, 15, 20, 25)
            JumlahBarisPerHalaman = Val(CbEntries.Text)

            ' Reset ke halaman pertama (indeks 0)
            PosisiHalaman = 0

            ' Refresh Data
            Call TampilkanDataJadwal()
        End If
    End Sub

    Private Sub CbNmSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbNmSemester.SelectedIndexChanged
        If IsLoading Then Exit Sub
        PosisiHalaman = 0 ' Reset ke halaman pertama saat filter berubah
        Call TampilkanDataJadwal()
    End Sub

    Private Sub CbThAkademik_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbThAkademik.SelectedIndexChanged
        If IsLoading Then Exit Sub
        PosisiHalaman = 0 ' Reset ke halaman pertama saat filter berubah
        Call TampilkanDataJadwal()
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        ' Menampilkan dialog konfirmasi
        Dim pesan As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar dari form ini?",
                                                    "Konfirmasi Keluar",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question)

        ' Jika user menekan tombol Yes, maka form ditutup
        If pesan = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        ' 1. Validasi: Pastikan jurusan, semester, dan tahun akademik BUKAN "ALL"
        If CbNmJurusan.Text = "ALL" Or CbNmSemester.Text = "ALL" Or CbThAkademik.Text = "ALL" Then
            MessageBox.Show("Silakan pilih Jurusan, Semester, dan Tahun Akademik yang spesifik terlebih dahulu sebelum menambah data!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. Jika validasi lolos, buka form biografi
        Dim frmTambah As New FormBioPenjadwalanMatkul
        'frmTambah.IsEditMode = False

        ' 3. Kirim data yang sudah dipilih di awal ke Form tujuan
        ' Sesuaikan nama objek ComboBox di FormBioPengampuMatakuliah Anda
        frmTambah.ProdiTerpilih = CbNmJurusan.SelectedValue.ToString()
        frmTambah.SemesterTerpilih = CbNmSemester.Text
        frmTambah.TATerpilih = CbThAkademik.Text

        frmTambah.ShowDialog()

        ' Refresh grid setelah input selesai
        Call TampilkanDataJadwal()
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        ' Reset ke halaman pertama setiap kali melakukan pencarian baru
        PosisiHalaman = 0
        ' Panggil fungsi tampilkan data
        Call TampilkanDataJadwal()
    End Sub

    Private Sub TxtCariNama_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCariNama.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Menghilangkan bunyi beep
            BtnCari.PerformClick()    ' Menjalankan fungsi tombol cari
        End If
    End Sub
End Class