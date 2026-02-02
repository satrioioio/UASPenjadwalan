Imports MySql.Data.MySqlClient
Public Class FormBioPenjadwalanMatkul
    Public Property ProdiTerpilih As String
    Public Property SemesterTerpilih As String
    Public Property TATerpilih As String
    Public Property IsEditMode As Boolean
    Public Property Edit_KdPengampu As String

    Private Sub FormBioPenjadwalanMatkul_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call IsiComboHari()
        Call IsiComboRuangan()
        Call TampilkanProdi()

        ' 2. Pasang data filter dari form utama
        If IsEditMode = False Then
            ' Mode Tambah: Isi otomatis berdasarkan filter awal
            CbNamaProdi.SelectedValue = ProdiTerpilih
            CbNamaSemester.Text = SemesterTerpilih
            CbTahunAkademik.Text = TATerpilih

            ' Mengunci filter agar input konsisten dengan grid utama
            CbNamaProdi.Enabled = False
            CbNamaSemester.Enabled = False
            CbTahunAkademik.Enabled = False
            BtnHapus.Enabled = False ' Tidak bisa hapus jika data baru
            BtnHapus.BackColor = Color.Red
        Else
            ' Mode Edit: Ambil data berdasarkan Kode Pengampu
            'Call LoadDataEdit(Edit_KdPengampu)
            BtnHapus.Enabled = True
        End If
    End Sub

    Sub IsiComboHari()
        Try
            Call KoneksiDb()
            Dim sql As String = "SELECT Id_Hari, Nm_Hari FROM tbl_hari ORDER BY Id_Hari ASC"
            Dim DA As New MySqlDataAdapter(sql, DBKoneksi)
            Dim DT As New DataTable
            DA.Fill(DT)

            CbNamaHari.DataSource = DT
            CbNamaHari.DisplayMember = "Nm_Hari"
            CbNamaHari.ValueMember = "Id_Hari"

            CbNamaHari.SelectedIndex = -1 ' Supaya kosong di awal
        Catch ex As Exception
            MsgBox("Gagal memuat data hari: " & ex.Message)
        End Try
    End Sub

    Sub IsiComboRuangan()
        Try
            Call KoneksiDb()
            Dim sql As String = "SELECT Kd_Ruangan, Nm_Ruangan FROM tbl_ruangkelas ORDER BY Nm_Ruangan ASC"
            Dim DA As New MySqlDataAdapter(sql, DBKoneksi)
            Dim DT As New DataTable
            DA.Fill(DT)

            CbRuangKelas.DataSource = DT
            CbRuangKelas.DisplayMember = "Nm_Ruangan"
            CbRuangKelas.ValueMember = "Kd_Ruangan"

            CbRuangKelas.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("Gagal memuat data ruangan: " & ex.Message)
        End Try
    End Sub

    Sub TampilkanProdi()
        Try
            Call KoneksiDb()
            Dim sql As String = "SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Nm_Prodi ASC"
            Dim DA As New MySqlDataAdapter(sql, DBKoneksi)
            Dim DT As New DataTable
            DA.Fill(DT)

            CbNamaProdi.DataSource = DT
            CbNamaProdi.DisplayMember = "Nm_Prodi"
            CbNamaProdi.ValueMember = "Kd_Prodi"
        Catch ex As Exception
            MsgBox("Gagal memuat data prodi: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        If TxtKdPengampu.Text = "" Then Exit Sub

        Try
            Call KoneksiDb()
            ' Query Join untuk mengambil detail dosen dan matkul
            Dim sql As String = "SELECT p.Kd_Dosen, d.Nm_Dosen, d.NIDN_Dosen, " &
                               "p.Kd_Matkul, m.Nm_Matkul, m.Sks_Matkul, m.Teori_Matkul, m.Praktek_Matkul, m.Semester_Matkul " &
                               "FROM tbl_dosenpengampu_matkul p " &
                               "JOIN tbl_dosen d ON p.Kd_Dosen = d.Kd_Dosen " &
                               "JOIN tbl_matakuliah m ON p.Kd_Matkul = m.Kd_Matkul " &
                               "WHERE p.Kd_Pengampu = @kd"

            Dim cmd As New MySqlCommand(sql, DBKoneksi)
            cmd.Parameters.AddWithValue("@kd", TxtKdPengampu.Text)
            Dim dr As MySqlDataReader = cmd.ExecuteReader

            If dr.Read Then
                ' Mengisi TextBox sesuai desain Anda
                lbNikDosen.Text = dr("Kd_Dosen").ToString()
                lbNidn.Text = dr("NIDN_Dosen").ToString()
                lbNamaDosen.Text = dr("Nm_Dosen").ToString()
                lbKodeMatkul.Text = dr("Kd_Matkul").ToString()
                lbNamaMatkul.Text = dr("Nm_Matkul").ToString()
                LbSks.Text = dr("Sks_Matkul").ToString()
                lbSksTeori.Text = dr("Teori_Matkul").ToString()
                lbSksPraktek.Text = dr("Praktek_Matkul").ToString()
                lbSmester.Text = dr("Semester_Matkul").ToString()
            Else
                MsgBox("Kode Pengampu tidak ditemukan!", vbExclamation)
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("Error Cari: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        ' 1. Validasi Input Dasar
        If TxtKdPengampu.Text = "" Or CbNamaHari.SelectedIndex = -1 Or TxtJamAwal.Text = "" Or TxtJamAkhir.Text = "" Then
            MsgBox("Lengkapi data hari, jam, dan kode pengampu!", vbExclamation)
            Exit Sub
        End If

        Dim detailBentrokDosen As String = ""
        Dim detailBentrokRuangan As String = ""

        Try
            Call KoneksiDb()

            ' Query Dasar untuk mengecek Overlap Waktu
            ' Rumus: (JamAwalBaru < JamAkhirLama) AND (JamAkhirBaru > JamAwalLama)
            Dim sqlBase As String = "SELECT j.Kd_Pengampu, d.Nm_Dosen, m.Nm_Matkul, r.Nm_Ruangan, j.JamAwal, j.JamAkhir, h.Nm_Hari " &
                               "FROM tbl_jadwal_matkul j " &
                               "JOIN tbl_dosenpengampu_matkul p ON j.Kd_Pengampu = p.Kd_Pengampu " &
                               "JOIN tbl_dosen d ON p.Kd_Dosen = d.Kd_Dosen " &
                               "JOIN tbl_matakuliah m ON p.Kd_Matkul = m.Kd_Matkul " &
                               "JOIN tbl_hari h ON j.Id_Hari = h.Id_Hari " &
                               "JOIN tbl_ruangkelas r ON j.Kd_Ruangan = r.Kd_Ruangan " &
                               "WHERE j.Id_Hari = @hari " &
                               "AND (@jamAwal < j.JamAkhir AND @jamAkhir > j.JamAwal) "

            ' Tambahkan pengecekan jika mode EDIT (abaikan jadwal diri sendiri)
            If IsEditMode Then sqlBase &= " AND j.Kd_Pengampu <> @kdPengampu "

            ' --- CEK BENTROK DOSEN ---
            Using cmdDosen As New MySqlCommand(sqlBase & " AND p.Kd_Dosen = @kdDosen", DBKoneksi)
                cmdDosen.Parameters.AddWithValue("@hari", CbNamaHari.SelectedValue)
                cmdDosen.Parameters.AddWithValue("@kdDosen", lbNikDosen.Text)
                cmdDosen.Parameters.AddWithValue("@jamAwal", TxtJamAwal.Text)
                cmdDosen.Parameters.AddWithValue("@jamAkhir", TxtJamAkhir.Text)
                If IsEditMode Then cmdDosen.Parameters.AddWithValue("@kdPengampu", TxtKdPengampu.Text)

                Dim drD As MySqlDataReader = cmdDosen.ExecuteReader
                While drD.Read
                    detailBentrokDosen &= "- Matkul: " & drD("Nm_Matkul").ToString() & " (" & drD("JamAwal").ToString() & "-" & drD("JamAkhir").ToString() & ")" & vbCrLf
                End While
                drD.Close()
            End Using

            ' --- CEK BENTROK RUANGAN ---
            Using cmdRuang As New MySqlCommand(sqlBase & " AND j.Kd_Ruangan = @kdRuang", DBKoneksi)
                cmdRuang.Parameters.AddWithValue("@hari", CbNamaHari.SelectedValue)
                cmdRuang.Parameters.AddWithValue("@kdRuang", CbRuangKelas.SelectedValue)
                cmdRuang.Parameters.AddWithValue("@jamAwal", TxtJamAwal.Text)
                cmdRuang.Parameters.AddWithValue("@jamAkhir", TxtJamAkhir.Text)
                If IsEditMode Then cmdRuang.Parameters.AddWithValue("@kdPengampu", TxtKdPengampu.Text)

                Dim drR As MySqlDataReader = cmdRuang.ExecuteReader
                While drR.Read
                    detailBentrokRuangan &= "- Dosen: " & drR("Nm_Dosen").ToString() & " (" & drR("JamAwal").ToString() & "-" & drR("JamAkhir").ToString() & ")" & vbCrLf
                End While
                drR.Close()
            End Using

            ' --- TAMPILKAN VALIDASI ---
            If detailBentrokDosen <> "" Or detailBentrokRuangan <> "" Then
                Dim pesanHeader As String = "TIDAK DAPAT MENYIMPAN JADWAL!" & vbCrLf & "--------------------------------" & vbCrLf
                Dim pesanBody As String = ""

                If detailBentrokDosen <> "" Then
                    pesanBody &= "⚠️ JADWAL DOSEN BENTROK (" & lbNamaDosen.Text & "):" & vbCrLf & detailBentrokDosen & vbCrLf
                End If

                If detailBentrokRuangan <> "" Then
                    pesanBody &= "⚠️ RUANGAN SUDAH DIPAKAI (" & CbRuangKelas.Text & "):" & vbCrLf & detailBentrokRuangan & vbCrLf
                End If

                ' Tampilkan ke Form Informasi Bentrok
                Dim frmShowBentrok As New FormInformasi
                frmShowBentrok.PesanBentrok = pesanHeader & pesanBody
                frmShowBentrok.ShowDialog()
                Exit Sub ' Stop proses simpan
            End If

            ' 2. Jika Lolos, Jalankan Query Insert/Update
            ' ... (lanjutkan ke proses simpan ke database) ...
            MsgBox("Jadwal Berhasil Disimpan!", vbInformation)
            Me.Close()

        Catch ex As Exception
            MsgBox("Gagal Validasi: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
    End Sub
End Class