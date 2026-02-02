Imports MySql.Data.MySqlClient

Public Class FrmLogin

    ' Event saat Form Login dimuat
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup ComboBox
        CmbUserType.Items.Clear()
        CmbUserType.Items.Add("Administrator")
        CmbUserType.Items.Add("Dosen")
        CmbUserType.SelectedIndex = -1

        ' Pastikan karakter password jadi bintang/bulat (keamanan visual)
        TextPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Call KoneksiDB()

        ' 1. Validasi Input Kosong
        If TextUser.Text = "" Or TextPassword.Text = "" Or CmbUserType.Text = "" Then
            MsgBox("Data Login (User, Password, Level) tidak boleh kosong!", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        Try
            ' 2. Cek Database
            Dim query As String = "SELECT * FROM tbl_user WHERE Nm_User=@user AND Pass_User=@pass AND Level_User=@level"
            CMD = New MySqlCommand(query, DBKoneksi)
            CMD.Parameters.AddWithValue("@user", TextUser.Text)
            CMD.Parameters.AddWithValue("@pass", TextPassword.Text)
            CMD.Parameters.AddWithValue("@level", CmbUserType.Text)

            Dim DR As MySqlDataReader = CMD.ExecuteReader()

            If DR.Read() Then
                ' === LOGIN BERHASIL ===

                Dim Level As String = DR("Level_User").ToString()
                Dim Nama As String = DR("Nm_User").ToString()

                ' PENTING: Kita panggil fungsi yang ada di FrmMenuUtama.
                ' Jadi kita tidak perlu atur enable/disable menu disini. Biar MenuUtama yang atur dirinya sendiri.
                FrmMenuUtama.LoginBerhasil(Level, Nama)

                MsgBox("Selamat Datang, " & Nama, MsgBoxStyle.Information, "Login Sukses")

                Me.Close() ' Tutup form login
            Else
                ' === LOGIN GAGAL ===
                MsgBox("Login Gagal! Periksa Username, Password, atau Level Anda.", MsgBoxStyle.Critical, "Gagal")
                TextUser.Focus()
                TextUser.SelectAll()
            End If
            DR.Close()

        Catch ex As Exception
            MsgBox("Error Database: " & ex.Message)
        End Try
    End Sub

    ' Fitur Tambahan: Tekan ENTER di password langsung Login
    Private Sub TextPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TextPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnLogin.PerformClick() ' Otomatis klik tombol login
        End If
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Me.Close()
    End Sub

End Class