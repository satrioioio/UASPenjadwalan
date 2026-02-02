Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmLapdataPenjadwalanMatkul
    Sub TampilkanNamaProdi()
        Call KoneksiDB()
        Dim DT As New DataTable
        Dim DA As New MySqlDataAdapter("SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Kd_Prodi", DBKoneksi)
        DA.Fill(DT)

        CmbNamaProdi.DataSource = DT
        CmbNamaProdi.DisplayMember = "Nm_Prodi"
        CmbNamaProdi.ValueMember = "Kd_Prodi"
    End Sub

    Sub TampilkanSemester()
        CmbNamaSemester.Items.Clear()
        CmbNamaSemester.Items.Add("GANJIL")
        CmbNamaSemester.Items.Add("GENAP")
        CmbNamaSemester.SelectedIndex = 0
    End Sub

    Sub TampilkanTahunAkademik()
        Call KoneksiDB()
        Dim DT As New DataTable
        ' Mengambil tahun akademik unik dari tabel pengampu
        Dim DA As New MySqlDataAdapter("SELECT DISTINCT Tahun_Akademik FROM tbl_dosenpengampu_matkul", DBKoneksi)
        DA.Fill(DT)

        CmbTahunAkademik.DataSource = DT
        CmbTahunAkademik.DisplayMember = "Tahun_Akademik"
    End Sub

    Sub TampilkanJenisKelas()
        CmbJenisKelas.Items.Clear()
        CmbJenisKelas.Items.Add("Reguler")
        CmbJenisKelas.Items.Add("Karyawan")
        CmbJenisKelas.SelectedIndex = 0
    End Sub

    Private Sub FrmLapJadwalKuliah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilkanNamaProdi()
        Call TampilkanSemester()
        Call TampilkanTahunAkademik()
        Call TampilkanJenisKelas()

        CmbNamaProdi.SelectedIndex = -1
        CmbTahunAkademik.SelectedIndex = -1
        CmbNamaSemester.SelectedIndex = -1
        CmbJenisKelas.SelectedIndex = -1
    End Sub



    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If MsgBox("Apakah anda yakin ingin keluar?", vbQuestion + vbYesNo, "Konfirmasi") = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnCetakLaporan_Click(sender As Object, e As EventArgs) Handles BtnCetakLaporan.Click
        Try
            Call KoneksiDB()
            ' Logika Ganjil/Genap (Ganjil = Semester 1,3,5... | Genap = Semester 2,4,6...)
            Dim jenisSemester As Integer = If(CmbNamaSemester.Text = "GANJIL", 1, 0)

            ' 1. Ambil data ke DataTable terlebih dahulu
            Dim SQL As String = "SELECT * FROM v_jadwal_lengkap " &
                                "WHERE Nm_Prodi = @Prodi " &
                                "AND Tahun_Akademik = @Tahun " &
                                "AND Nama_Kelas = @Kelas " &
                                "AND Semester_Matkul % 2 = @Jenis"

            Dim DA As New MySqlDataAdapter(SQL, DBKoneksi)
            DA.SelectCommand.Parameters.AddWithValue("@Prodi", CmbNamaProdi.Text)
            DA.SelectCommand.Parameters.AddWithValue("@Tahun", CmbTahunAkademik.Text)
            DA.SelectCommand.Parameters.AddWithValue("@Kelas", CmbJenisKelas.Text)
            DA.SelectCommand.Parameters.AddWithValue("@Jenis", jenisSemester)

            Dim DT As New DataTable
            DA.Fill(DT)

            ' 2. Validasi Jika Data Kosong
            If DT.Rows.Count = 0 Then
                MsgBox("Jadwal tidak ditemukan untuk kriteria tersebut!", vbInformation, "Informasi")
                CrystalReportViewer1.ReportSource = Nothing
                Exit Sub
            End If

            ' --- OPREK DATA RUANGAN DISINI (JALAN NINJA) ---
            For Each row As DataRow In DT.Rows
                Dim rm As String = row("Nm_Ruangan").ToString().ToUpper()
                ' Menghapus "RUANG KELAS " dan mengambil bagian sebelum "-"
                Dim bersih As String = rm.Replace("RUANG KELAS ", "").Split("-"c)(0)
                row("Nm_Ruangan") = bersih.Trim() ' Timpa data asli dengan yang singkat
            Next
            ' -----------------------------------------------

            ' 3. Load Report dan Set DataSource pake DataTable yang sudah di-oprek
            Dim LapJadwal As New ReportDocument
            ' Sesuaikan path .rpt lu ya!
            LapJadwal.Load("C:\UAS_DbPenjadwalan24022\DbPenjadwalan24022\DataLaporanPenjadwalanMatakuliah\CryLapdataPenjadwalanMataKuliah.rpt")
            LapJadwal.SetDataSource(DT)

            ' 4. Tampilkan
            CrystalReportViewer1.ReportSource = LapJadwal
            CrystalReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox("Gagal memproses laporan: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub
End Class