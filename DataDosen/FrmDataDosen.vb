Imports MySql.Data.MySqlClient
Public Class FrmDataDosen
    Public NikBaruDariFormUtama As String ' Untuk menampung NIK kiriman
    Dim SQLInsert, SQLUpdate As String
    Dim CMD As MySqlCommand
    Dim DR As MySqlDataReader
    Dim Kode_Jurusan As String
    Public KodeProdiDariFormDosen As String

    Function ValidasiKarakterTerlarang() As Boolean
        Dim inputFields() As String = {
            TextNidnDsn.Text,
            TextEmailDsn.Text,
            TextNamaDsn.Text,
            TextNoTelpDsn.Text
            }
        For Each teks In inputFields
            If teks.Contains("'") Then
                MsgBox("Input tidak boleh mengandung tanda petik satu (')", vbExclamation, "Validasi")
                Return False
            End If
        Next
        Return True
    End Function

    Sub jenisKelamin()
        CmbJkDsn.Items.Clear()
        CmbJkDsn.Items.Add("Laki-laki")
        CmbJkDsn.Items.Add("Perempuan")
    End Sub

    Sub TampilNamaProdi()
        Call KoneksiDB()
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter("SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Kd_Prodi", DBKoneksi)
        da.Fill(dt)

        CmbProdiDsn.DataSource = dt
        CmbProdiDsn.DisplayMember = "Nm_Prodi"
        CmbProdiDsn.ValueMember = "Kd_Prodi"
    End Sub

    Private Sub CmbProdiDsn_DropDown(sender As Object, e As EventArgs) Handles CmbProdiDsn.DropDown
        CmbProdiDsn.SelectedIndex = -1
    End Sub

    Private Sub FrmDataDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KoneksiDB()

        ' Isi ComboBox jika kosong
        If CmbJkDsn.Items.Count = 0 Then jenisKelamin()
        If CmbProdiDsn.DataSource Is Nothing Then TampilNamaProdi()

        ' Jika ada kiriman Kode Prodi dari luar
        If Not String.IsNullOrEmpty(KodeProdiDariFormDosen) Then
            CmbProdiDsn.SelectedValue = KodeProdiDariFormDosen
        End If

        ' Jika ada kiriman NIK dari luar (Saat Tambah Data Baru)
        If Not String.IsNullOrEmpty(NikBaruDariFormUtama) Then
            LbNikDsn.Text = NikBaruDariFormUtama
        End If
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        Call KoneksiDB()

        If TextNidnDsn.Text = "" OrElse CmbProdiDsn.SelectedIndex = -1 Then
            MsgBox("Silahkan lengkapi semua data.", vbExclamation, "Validasi")
            Exit Sub
        End If

        If Not ValidasiKarakterTerlarang() Then Exit Sub

        Try
            If BtnSimpan.Text = "SIMPAN" Then
                SQLInsert = "INSERT INTO tbl_dosen (Kd_Dosen, Kd_Prodi, NIDN_Dosen, Nm_Dosen, Jk_Dosen, Notlp_Dosen, Email_Dosen) " &
                        "VALUES (@NIK, @Prodi, @NIDN, @Nama, @Jk, @Notlp, @Email)"
                CMD = New MySqlCommand(SQLInsert, DBKoneksi)
            ElseIf BtnSimpan.Text = "UBAH" Then
                SQLUpdate = "UPDATE tbl_dosen SET NIDN_Dosen=@NIDN, Nm_Dosen=@Nama, Jk_Dosen=@Jk, Notlp_Dosen=@Notlp, Email_Dosen=@Email WHERE Kd_Dosen=@NIK"
                CMD = New MySqlCommand(SQLUpdate, DBKoneksi)
            End If

            CMD.Parameters.AddWithValue("@NIK", LbNikDsn.Text)
            CMD.Parameters.AddWithValue("@Prodi", CmbProdiDsn.SelectedValue) ' gunakan SelectedValue kalau Prodi punya kode
            CMD.Parameters.AddWithValue("@NIDN", TextNidnDsn.Text)
            CMD.Parameters.AddWithValue("@Nama", TextNamaDsn.Text)
            CMD.Parameters.AddWithValue("@Jk", CmbJkDsn.Text)
            CMD.Parameters.AddWithValue("@Notlp", TextNoTelpDsn.Text)
            CMD.Parameters.AddWithValue("@Email", TextEmailDsn.Text)

            ' gunakan ExecuteNonQuery untuk INSERT/UPDATE
            CMD.ExecuteNonQuery()

            MsgBox("Data Berhasil Disimpan", vbInformation, "Informasi")

            ' Tutup form input
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("Terjadi Kesalahan: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        Call KoneksiDB()

        If LbNikDsn.Text = "" Then
            MsgBox("NIK belum dipilih", vbExclamation, "Validasi")
            Exit Sub
        End If

        Dim Konfirmasi As DialogResult = MsgBox("Apakah anda akan menghapus data ini?", vbQuestion + vbOKCancel, "Konfirmasi")
        If Konfirmasi = vbOK Then
            Try
                Using CMD As New MySqlCommand("DELETE FROM tbl_dosen WHERE Kd_Dosen = @NIK", DBKoneksi)
                    CMD.Parameters.AddWithValue("@NIK", LbNikDsn.Text)
                    Dim rowsAffected As Integer = CMD.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MsgBox("Data Berhasil Dihapus", vbInformation, "Informasi")

                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MsgBox("Data tidak ditemukan atau sudah terhapus", vbExclamation, "Informasi")
                    End If
                End Using

            Catch ex As Exception
                MsgBox("Gagal Menghapus data: " & ex.Message, vbCritical, "Error")
            End Try
        Else
            MsgBox("Penghapusan dibatalkan", vbInformation, "Informasi")
        End If
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

    Public Sub ResetFormBioDosen()
        ' Kosongkan Teks
        LbNikDsn.Text = ""
        LbkdProdiDsn.Text = ""
        TextNidnDsn.Clear()
        TextNamaDsn.Clear()
        TextNoTelpDsn.Clear()
        TextEmailDsn.Clear()

        ' Reset ComboBox
        CmbProdiDsn.SelectedIndex = -1
        CmbJkDsn.SelectedIndex = -1

        ' AKTIFKAN KEMBALI INPUT (Ini kuncinya)
        CmbProdiDsn.Enabled = True
        TextNidnDsn.Enabled = True
        TextNamaDsn.Enabled = True
        TextNoTelpDsn.Enabled = True
        TextEmailDsn.Enabled = True
        CmbJkDsn.Enabled = True

        ' Atur Ulang Tombol
        BtnSimpan.Text = "SIMPAN"
        BtnSimpan.Enabled = True
        BtnSimpan.BackColor = Color.DodgerBlue ' Sesuaikan warna aktif Anda

        BtnHapus.Enabled = False
        BtnHapus.BackColor = Color.Red

        BtnKeluar.Text = "BATAL"
    End Sub

End Class