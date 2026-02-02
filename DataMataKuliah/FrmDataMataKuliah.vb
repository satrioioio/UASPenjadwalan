Imports MySql.Data.MySqlClient
Public Class FrmDataMataKuliah
    ' ==========================================
    ' VARIABEL GLOBAL
    ' ==========================================
    ' Variabel penampung data dari FrmMatkul (Parent Form)
    Public NmProdiTerpilih As String = ""
    Public NamaSemesterTerpilih As String = ""
    Public AngkaSemesterTerpilih As String = ""

    ' Variabel Penampung Data Edit (Agar tidak tertimpa rumus otomatis saat load)
    Public VarSks As String = ""
    Public VarTeori As String = ""
    Public VarPraktek As String = ""

    ' Flag untuk mencegah looping perhitungan rumus
    Private isCalculating As Boolean = False

    Private Sub FrmDataMataKuliah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' A. Isi Dulu Item ComboBox SKS (1-20)
        CmbSksMatkul.Items.Clear()
        For i As Integer = 1 To 20
            CmbSksMatkul.Items.Add(i.ToString())
        Next

        ' B. Isi Dulu Item ComboBox Semester (Ganjil/Genap)
        ' PENTING: Harus di-add dulu sebelum di-set Text-nya
        CmbNmSemesterMatkul.Items.Clear()
        CmbNmSemesterMatkul.Items.Add("Ganjil")
        CmbNmSemesterMatkul.Items.Add("Genap")

        ' C. Tangkap & Tampilkan Nama Jurusan
        If NmProdiTerpilih <> "" Then
            CmbNmJurusanMatkul.Items.Clear()
            CmbNmJurusanMatkul.Items.Add(NmProdiTerpilih) ' Tambahkan item dulu
            CmbNmJurusanMatkul.Text = NmProdiTerpilih      ' Baru pilih itemnya
            CmbNmJurusanMatkul.Enabled = False             ' Kunci
        End If

        ' D. Tangkap & Tampilkan Nama Semester
        If NamaSemesterTerpilih <> "" Then
            CmbNmSemesterMatkul.Text = NamaSemesterTerpilih
        End If

        ' E. Tangkap & Tampilkan Angka Semester
        If AngkaSemesterTerpilih <> "" Then
            CmbSemesterMatkul.Text = AngkaSemesterTerpilih
        End If

        ' F. Isi Data Edit (SKS, Teori, Praktek) dari Variabel Penampung
        ' Ini dilakukan terakhir agar rumus otomatis tidak mereset nilai jadi 0
        If VarSks <> "" Then CmbSksMatkul.Text = VarSks
        If VarTeori <> "" Then TextTeoriMatkul.Text = VarTeori
        If VarPraktek <> "" Then TextPraktekMatkul.Text = VarPraktek

        ' Hitung Menit (Update Label)
        Call HitungMenit()
    End Sub

    ' ==========================================
    ' 2. TOMBOL SIMPAN / UBAH
    ' ==========================================
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        Call KoneksiDB()

        ' Validasi Input
        If LbKodeMatkul.Text = "" Or TextNamaMatkul.Text = "" Or CmbSksMatkul.Text = "" Or CmbSemesterMatkul.Text = "" Then
            MsgBox("Silahkan lengkapi semua data mata kuliah.", vbExclamation, "Validasi")
            Exit Sub
        End If

        ' Validasi Tanda Petik (Mencegah Error SQL)
        If TextNamaMatkul.Text.Contains("'") Then
            MsgBox("Nama Mata Kuliah tidak boleh mengandung tanda petik satu (')", vbExclamation, "Validasi")
            Exit Sub
        End If

        Try
            If BtnSimpan.Text = "SIMPAN" Then
                ' Query Insert
                SQLInsert = "INSERT INTO tbl_matakuliah (Kd_Matkul, Nm_Matkul, Sks_Matkul, Teori_Matkul, Praktek_Matkul, Semester_Matkul) " &
                            "VALUES (@Kd, @Nm, @Sks, @Teori, @Praktek, @Sem)"
                CMD = New MySqlCommand(SQLInsert, DBKoneksi)

            ElseIf BtnSimpan.Text = "UBAH" Then
                ' Query Update
                SQLUpdate = "UPDATE tbl_matakuliah SET Nm_Matkul=@Nm, Sks_Matkul=@Sks, Teori_Matkul=@Teori, Praktek_Matkul=@Praktek, Semester_Matkul=@Sem " &
                            "WHERE Kd_Matkul=@Kd"
                CMD = New MySqlCommand(SQLUpdate, DBKoneksi)
            End If

            ' Masukkan Parameter
            CMD.Parameters.AddWithValue("@Kd", LbKodeMatkul.Text)
            CMD.Parameters.AddWithValue("@Nm", TextNamaMatkul.Text)
            CMD.Parameters.AddWithValue("@Sks", CmbSksMatkul.Text)

            ' Handle Nilai Kosong (Default 0)
            Dim valTeori As Integer = If(TextTeoriMatkul.Text = "", 0, Val(TextTeoriMatkul.Text))
            Dim valPraktek As Integer = If(TextPraktekMatkul.Text = "", 0, Val(TextPraktekMatkul.Text))

            CMD.Parameters.AddWithValue("@Teori", valTeori)
            CMD.Parameters.AddWithValue("@Praktek", valPraktek)
            CMD.Parameters.AddWithValue("@Sem", CmbSemesterMatkul.Text)

            CMD.ExecuteNonQuery()

            MsgBox("Data Berhasil Disimpan", vbInformation, "Informasi")

            ' Tutup Form & Refresh Grid Parent
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Terjadi Kesalahan: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    ' ==========================================
    ' 3. TOMBOL HAPUS
    ' ==========================================
    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        Call KoneksiDB()

        If LbKodeMatkul.Text = "" Then
            MsgBox("Kode Mata Kuliah belum dipilih", vbExclamation, "Validasi")
            Exit Sub
        End If

        If MsgBox("Apakah anda yakin ingin menghapus data ini?", vbQuestion + vbYesNo, "Konfirmasi") = vbYes Then
            Try
                ' Hapus Data
                SQLHapus = "DELETE FROM tbl_matakuliah WHERE Kd_Matkul = @Kd"
                CMD = New MySqlCommand(SQLHapus, DBKoneksi)
                CMD.Parameters.AddWithValue("@Kd", LbKodeMatkul.Text)

                Dim rowsAffected As Integer = CMD.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MsgBox("Data Berhasil Dihapus", vbInformation, "Informasi")
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MsgBox("Data tidak ditemukan atau sudah terhapus", vbExclamation, "Informasi")
                End If

            Catch ex As Exception
                MsgBox("Gagal Menghapus (Mungkin data digunakan di tabel lain): " & ex.Message, vbCritical, "Error")
            End Try
        End If
    End Sub

    ' ==========================================
    ' 4. TOMBOL KELUAR
    ' ==========================================
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If BtnKeluar.Text = "KELUAR" Then
            If MsgBox("Anda yakin mau keluar?", vbQuestion + vbYesNo, "Konfirmasi") = vbYes Then Me.Close()
        ElseIf BtnKeluar.Text = "BATAL" Then
            If MsgBox("Batalkan input data?", vbQuestion + vbYesNo, "Konfirmasi") = vbYes Then
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    ' ==========================================
    ' 5. LOGIKA PERHITUNGAN SKS & MENIT
    ' ==========================================
    Sub HitungMenit()
        Try
            Dim sksTeori As Integer = If(TextTeoriMatkul.Text = "", 0, Val(TextTeoriMatkul.Text))
            Dim sksPraktek As Integer = If(TextPraktekMatkul.Text = "", 0, Val(TextPraktekMatkul.Text))

            Dim menitTeori As Integer = sksTeori * 50
            Dim menitPraktek As Integer = sksPraktek * 170
            Dim totalMenit As Integer = menitTeori + menitPraktek

            LbTeoriMatkul.Text = menitTeori.ToString() & " Menit"
            LbPraktekMatkul.Text = menitPraktek.ToString() & " Menit"
            LbHasilTeoriPraktek.Text = totalMenit.ToString() & " Menit"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextTeoriMatkul_TextChanged(sender As Object, e As EventArgs) Handles TextTeoriMatkul.TextChanged
        If isCalculating Then Exit Sub
        Try
            isCalculating = True
            Dim sksTotal As Integer = Val(CmbSksMatkul.Text)
            Dim sksTeori As Integer = Val(TextTeoriMatkul.Text)

            If sksTeori > sksTotal Then
                MsgBox("SKS Teori tidak boleh > Total SKS")
                TextTeoriMatkul.Text = sksTotal
                sksTeori = sksTotal
            End If

            TextPraktekMatkul.Text = sksTotal - sksTeori
            Call HitungMenit()
        Finally
            isCalculating = False
        End Try
    End Sub

    Private Sub TextPraktekMatkul_TextChanged(sender As Object, e As EventArgs) Handles TextPraktekMatkul.TextChanged
        If isCalculating Then Exit Sub
        Try
            isCalculating = True
            Dim sksTotal As Integer = Val(CmbSksMatkul.Text)
            Dim sksPraktek As Integer = Val(TextPraktekMatkul.Text)

            If sksPraktek > sksTotal Then
                MsgBox("SKS Praktek tidak boleh > Total SKS")
                TextPraktekMatkul.Text = sksTotal
                sksPraktek = sksTotal
            End If

            TextTeoriMatkul.Text = sksTotal - sksPraktek
            Call HitungMenit()
        Finally
            isCalculating = False
        End Try
    End Sub

    Private Sub CmbSksMatkul_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSksMatkul.SelectedIndexChanged
        If Not isCalculating Then
            TextTeoriMatkul.Text = CmbSksMatkul.Text
            TextPraktekMatkul.Text = "0"
            Call HitungMenit()
        End If
    End Sub
End Class