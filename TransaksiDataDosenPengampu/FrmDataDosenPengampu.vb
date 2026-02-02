Imports MySql.Data.MySqlClient

Public Class FrmDataDosenPengampu

    ' ==========================================
    ' 1. VARIABEL PENAMPUNG (Public)
    ' ==========================================
    ' Variabel ini akan diisi oleh Form Utama sebelum form ini dibuka
    Public StrProdi As String = ""
    Public StrSemester As String = ""
    Public StrKodeDosen As String = "" ' Jika nanti butuh edit data
    Public StrKelas As String = ""
    Public StrTahunAkademik As String = ""

    ' ==========================================
    ' 2. FORM LOAD (Isi ComboBox Disini)
    ' ==========================================

    ' Fungsi untuk mencegah karakter berbahaya (SQL Injection sederhana)
    Function ValidasiKarakterTerlarang() As Boolean
        Dim inputFields() As String = {
            TextNoIdentitas.Text,
            TextKodeMatkul.Text,
            TextTahunAkademik.Text
        }
        For Each teks In inputFields
            If teks.Contains("'") Then
                MsgBox("Input tidak boleh mengandung tanda petik satu (')", vbExclamation, "Validasi")
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub FrmDataDosenPengampu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KoneksiDB()

        ' A. Isi Dulu ComboBox
        Call TampilProdi()
        Call IsiSemester()
        Call IsiKelas()

        ' B. SET NILAI DARI VARIABEL PENAMPUNG

        ' --- Set Prodi ---
        If StrProdi <> "" Then
            Dim indexProdi As Integer = CmbProdi.FindStringExact(StrProdi)
            If indexProdi <> -1 Then
                CmbProdi.SelectedIndex = indexProdi
            Else
                CmbProdi.Text = StrProdi
            End If
        End If

        ' --- Set Semester ---
        If StrSemester <> "" Then
            CmbSemester.Text = StrSemester.ToUpper()
        End If

        ' --- Set Kelas ---
        If StrKelas <> "" Then
            CmbKelas.Text = StrKelas
        End If

        ' --- Set Tahun Akademik (LOGIKA BARU) ---
        If StrTahunAkademik <> "" Then
            ' Jika Mode Edit (Data dikirim dari form utama)
            TextTahunAkademik.Text = StrTahunAkademik
        Else
            ' Jika Mode Tambah Data (Kosong), Isi Otomatis sesuai Tahun Sekarang
            Dim Thn As Integer = Date.Now.Year
            Dim Bln As Integer = Date.Now.Month

            ' Logika: Jika bulan 7 ke atas (Juli-Des), masuk tahun ajaran Thn/Thn+1
            ' Jika bulan 6 ke bawah (Jan-Juni), masih tahun ajaran Thn-1/Thn
            If Bln >= 7 Then
                TextTahunAkademik.Text = Thn & "/" & (Thn + 1)
            Else
                TextTahunAkademik.Text = (Thn - 1) & "/" & Thn
            End If
        End If

        ' C. PENGATURAN KUNCI (Edit/Tambah)
        If LbKodePengampu.Text <> "" And StrProdi <> "" Then
            ' Saat Edit, kunci field primary agar tidak berantakan
            CmbProdi.Enabled = False
            'CmbSemester.Enabled = False
            LbKodePengampu.Enabled = False
        End If
    End Sub

    Sub TampilProdi()
        Try
            Dim sql As String = "SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Kd_Prodi"
            Using da As New MySqlDataAdapter(sql, DBKoneksi)
                Dim dt As New DataTable
                da.Fill(dt)

                CmbProdi.DataSource = dt
                CmbProdi.DisplayMember = "Nm_Prodi"
                CmbProdi.ValueMember = "Kd_Prodi"
                CmbProdi.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MsgBox("Gagal Load Prodi: " & ex.Message)
        End Try
    End Sub

    Sub IsiSemester()
        CmbSemester.Items.Clear()
        CmbSemester.Items.Add("Ganjil")
        CmbSemester.Items.Add("Genap")
        CmbSemester.SelectedIndex = -1
    End Sub

    Private Sub BtnCariNoidentitas_Click(sender As Object, e As EventArgs) Handles BtnCariNoidentitas.Click
        ' 1. Validasi: Pastikan kotak tidak kosong
        If TextNoIdentitas.Text.Trim() = "" Then
            MsgBox("Silahkan masukkan Kode Dosen (Nomor Identitas) terlebih dahulu!", vbExclamation, "Peringatan")
            TextNoIdentitas.Focus()
            Exit Sub
        End If

        Try
            Call KoneksiDB()

            ' 2. Query Pencarian ke Tabel Master Dosen
            Dim sql As String = "SELECT NIDN_Dosen, Nm_Dosen FROM tbl_dosen WHERE Kd_Dosen = @Kd"

            CMD = New MySqlCommand(sql, DBKoneksi)
            CMD.Parameters.AddWithValue("@Kd", TextNoIdentitas.Text.Trim())

            DR = CMD.ExecuteReader()

            ' 3. Cek Hasilnya
            If DR.Read() Then
                ' Jika Ditemukan -> Isi Label
                LbNidn.Text = DR("NIDN_Dosen").ToString()
                LbNamaDosen.Text = DR("Nm_Dosen").ToString()
            Else
                ' Jika Tidak Ditemukan -> Kosongkan/Beri Tanda
                MsgBox("Kode Dosen tidak ditemukan di database master!", vbInformation, "Info")
                LbNidn.Text = "-"
                LbNamaDosen.Text = "-"
                TextNoIdentitas.Focus()
            End If

            DR.Close()

        Catch ex As Exception
            MsgBox("Terjadi kesalahan saat mencari dosen: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub BtnCariKodeMatkul_Click(sender As Object, e As EventArgs) Handles BtnCariKodeMatkul.Click
        ' 1. Validasi Input Kosong
        If TextKodeMatkul.Text.Trim() = "" Then
            MsgBox("Silahkan masukkan Kode Matakuliah!", vbExclamation, "Peringatan")
            TextKodeMatkul.Focus()
            Exit Sub
        End If

        ' Pastikan Semester di ComboBox sudah dipilih karena kita butuh untuk validasi
        If CmbSemester.Text = "" Then
            MsgBox("Silahkan pilih Semester (Ganjil/Genap) terlebih dahulu!", vbExclamation, "Peringatan")
            CmbSemester.Focus()
            Exit Sub
        End If

        Try
            Call KoneksiDB()

            ' 2. Cari Data Matakuliah
            Dim sql As String = "SELECT * FROM tbl_matakuliah WHERE Kd_Matkul = @Kd"
            CMD = New MySqlCommand(sql, DBKoneksi)
            CMD.Parameters.AddWithValue("@Kd", TextKodeMatkul.Text.Trim())
            DR = CMD.ExecuteReader()

            If DR.Read() Then
                ' 3. Ambil Angka Semester dari Database
                Dim semesterDb As Integer = Val(DR("Semester_Matkul"))

                ' Tentukan Status Semester dari Database (Ganjil/Genap)
                Dim statusSemesterDb As String = ""
                If semesterDb Mod 2 <> 0 Then
                    statusSemesterDb = "GANJIL"
                Else
                    statusSemesterDb = "GENAP"
                End If

                ' 4. VALIDASI: Bandingkan dengan CmbSemester
                ' Jika Matkul Ganjil tapi Cmb pilih GENAP (atau sebaliknya) -> ERROR
                If statusSemesterDb <> CmbSemester.Text.ToUpper() Then
                    MsgBox("Validasi Gagal!" & vbCrLf &
                           "Matakuliah ini ada di Semester " & semesterDb & " (" & statusSemesterDb & ")." & vbCrLf &
                           "Sedangkan Anda memilih Semester " & CmbSemester.Text & "." & vbCrLf &
                           "Silahkan pilih matakuliah yang sesuai.", vbCritical, "Semester Tidak Sesuai")

                    ' Bersihkan label agar user tidak salah paham
                    KosongkanLabelMatkul()
                    TextKodeMatkul.Focus()
                Else
                    ' 5. JIKA COCOK -> Isi Semua Label
                    LbNamaMatkul.Text = DR("Nm_Matkul").ToString()
                    LbSks.Text = DR("Sks_Matkul").ToString()
                    LbSksTeori.Text = DR("Teori_Matkul").ToString()
                    LbSksPraktek.Text = DR("Praktek_Matkul").ToString()
                    LbSemester.Text = DR("Semester_Matkul").ToString() ' Ini angka semesternya (1, 2, 3...)
                End If

            Else
                MsgBox("Kode Matakuliah tidak ditemukan!", vbInformation, "Info")
                KosongkanLabelMatkul()
                TextKodeMatkul.Focus()
            End If
            DR.Close()

        Catch ex As Exception
            MsgBox("Error mencari matkul: " & ex.Message, vbCritical)
        End Try
    End Sub

    ' Sub Tambahan untuk membersihkan label jika data salah/tidak ketemu
    Sub KosongkanLabelMatkul()
        LbNamaMatkul.Text = "-"
        LbSks.Text = "-"
        LbSksTeori.Text = "-"
        LbSksPraktek.Text = "-"
        LbSemester.Text = "-"
    End Sub

    Sub IsiKelas()
        ' 1. Putuskan hubungan DataSource (jika sebelumnya ada binding)
        CmbKelas.DataSource = Nothing
        CmbKelas.Items.Clear()

        ' 2. Isi Pilihan secara Manual
        CmbKelas.Items.Add("Reguler")
        CmbKelas.Items.Add("Karyawan")

        ' Tambahkan opsi lain jika ada, misal:
        ' CmbKelas.Items.Add("Eksekutif")

        ' 3. Reset Pilihan
        CmbKelas.SelectedIndex = -1
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If BtnKeluar.Text = "KELUAR" Then
            Dim Pesan As DialogResult = MessageBox.Show(
            "Anda yakin mau keluar?", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If Pesan = DialogResult.Yes Then
                Me.Close()
            End If

        ElseIf BtnKeluar.Text = "BATAL" Then
            Dim Konfirmasi As DialogResult = MessageBox.Show(
            "Batalkan input data?", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If Konfirmasi = DialogResult.Yes Then
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        ' 1. Validasi Input Kosong
        If LbKodePengampu.Text = "" Or TextNoIdentitas.Text = "" Or TextKodeMatkul.Text = "" Or CmbKelas.Text = "" Or TextTahunAkademik.Text = "" Then
            MsgBox("Silahkan lengkapi semua data (Kode Dosen, Kode Matkul, Kelas, dan Tahun Akademik).", vbExclamation, "Validasi")
            Exit Sub
        End If

        ' 2. Validasi Karakter Terlarang
        If Not ValidasiKarakterTerlarang() Then Exit Sub

        Try
            Call KoneksiDB()
            Dim Query As String = ""

            ' 3. Tentukan INSERT atau UPDATE
            If BtnSimpan.Text = "SIMPAN" Then
                ' Query Tambah Data
                Query = "INSERT INTO tbl_dosenpengampu_matkul (Kd_Pengampu, Kd_Dosen, Kd_Matkul, Nama_Kelas, Tahun_Akademik) " &
                        "VALUES (@Id, @Dosen, @Matkul, @Kelas, @Thn)"
            ElseIf BtnSimpan.Text = "UBAH" Then
                ' Query Update Data
                Query = "UPDATE tbl_dosenpengampu_matkul SET Kd_Dosen=@Dosen, Kd_Matkul=@Matkul, Nama_Kelas=@Kelas, Tahun_Akademik=@Thn " &
                        "WHERE Kd_Pengampu=@Id"
            End If

            ' 4. Eksekusi Query
            Using CMD As New MySqlCommand(Query, DBKoneksi)
                CMD.Parameters.AddWithValue("@Id", LbKodePengampu.Text)
                CMD.Parameters.AddWithValue("@Dosen", TextNoIdentitas.Text)
                CMD.Parameters.AddWithValue("@Matkul", TextKodeMatkul.Text)
                CMD.Parameters.AddWithValue("@Kelas", CmbKelas.Text)
                CMD.Parameters.AddWithValue("@Thn", TextTahunAkademik.Text)

                CMD.ExecuteNonQuery()
            End Using

            MsgBox("Data Berhasil Disimpan", vbInformation, "Informasi")

            ' Tutup form dan beritahu form utama untuk refresh
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Gagal Menyimpan Data: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        ' Validasi ID Kosong
        If LbKodePengampu.Text = "" Then
            MsgBox("Tidak ada data yang dipilih untuk dihapus.", vbExclamation)
            Exit Sub
        End If

        ' Konfirmasi Penghapusan
        Dim Konfirmasi As DialogResult = MsgBox("Apakah Anda yakin ingin menghapus data pengampu ini?" & vbCrLf &
                                                "PERINGATAN: Data Jadwal yang terkait juga akan terhapus!",
                                                vbQuestion + vbYesNo, "Konfirmasi Hapus")
        If Konfirmasi = vbYes Then
            Try
                Call KoneksiDB()

                ' LANGKAH 1: Hapus dulu data di tabel ANAK (tbl_jadwal_matkul)
                ' Kita pakai Try-Catch terpisah atau abaikan error jika data jadwal tidak ada
                Dim sqlJadwal As String = "DELETE FROM tbl_jadwal_matkul WHERE Kd_Pengampu = @Id"
                Using CMDJadwal As New MySqlCommand(sqlJadwal, DBKoneksi)
                    CMDJadwal.Parameters.AddWithValue("@Id", LbKodePengampu.Text)
                    CMDJadwal.ExecuteNonQuery()
                End Using

                ' LANGKAH 2: Baru hapus data di tabel INDUK (tbl_dosenpengampu_matkul)
                Dim sqlPengampu As String = "DELETE FROM tbl_dosenpengampu_matkul WHERE Kd_Pengampu = @Id"
                Using CMDPengampu As New MySqlCommand(sqlPengampu, DBKoneksi)
                    CMDPengampu.Parameters.AddWithValue("@Id", LbKodePengampu.Text)
                    Dim rowsAffected As Integer = CMDPengampu.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MsgBox("Data Berhasil Dihapus", vbInformation, "Info")
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MsgBox("Data tidak ditemukan atau sudah terhapus.", vbExclamation)
                    End If
                End Using

            Catch ex As Exception
                MsgBox("Gagal Menghapus: " & ex.Message, vbCritical)
            End Try
        End If
    End Sub
End Class