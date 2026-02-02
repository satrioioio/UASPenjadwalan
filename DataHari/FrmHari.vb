Imports MySql.Data.MySqlClient
Public Class FrmHari
    Private Sub FrmHari_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KoneksiDB()
        TampilkanDataHari()

        BtnSimpan.Enabled = False
        BtnHapus.Enabled = False

        BtnSimpan.BackColor = Color.Red
        BtnHapus.BackColor = Color.Red

        DataGridHari.Enabled = False
    End Sub

    Sub AktifkanDataGridHari()
        With DataGridHari
            .EnableHeadersVisualStyles = False
            .Font = New Font(DataGridHari.Font, FontStyle.Bold)
            DataGridHari.DefaultCellStyle.Font = New Font("Arial", 9)
            DataGridHari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            DataGridHari.ColumnHeadersHeight = 35

            DataGridHari.Columns(0).Width = 80
            DataGridHari.Columns(0).HeaderText = "Kode Hari"
            DataGridHari.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridHari.Columns(1).Width = 300
            DataGridHari.Columns(1).HeaderText = "Nama Hari"
            DataGridHari.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Sub TampilkanDataHari()
        Call KoneksiDB()

        Dim sql As String = "SELECT Id_Hari, Nm_Hari FROM tbl_Hari ORDER BY Id_Hari ASC"
        DA = New MySqlDataAdapter(sql, DBKoneksi)
        DS = New DataSet()
        DS.Clear()
        DA.Fill(DS, "tbl_Hari")

        DataGridHari.DataSource = DS.Tables("tbl_Hari")
        DataGridHari.ReadOnly = True

        Call AktifkanDataGridHari()
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        Call KoneksiDB()

        ' Validasi input kosong
        If TextKodeHari.Text = "" Or TextNamaHari.Text = "" Then
            MsgBox("Silakan lengkapi semua data.", vbExclamation, "Validasi")
            Exit Sub
        End If

        Try
            ' Cek apakah kode atau nama Hari sudah ada
            Dim sqlCheck As String = "SELECT COUNT(*) FROM tbl_hari WHERE id_Hari=@Kode OR Nm_Hari=@Nama"
            Dim cmdCheck As New MySqlCommand(sqlCheck, DBKoneksi)
            cmdCheck.Parameters.AddWithValue("@Kode", TextKodeHari.Text.Trim())
            cmdCheck.Parameters.AddWithValue("@Nama", TextNamaHari.Text.Trim())

            Dim exists As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            If exists > 0 Then
                MsgBox("Kode atau Nama Hari sudah ada, tidak boleh duplikat!", vbCritical, "Validasi")
                Exit Sub
            End If

            ' Jika belum ada, lakukan insert
            If BtnTambah.Text = "Tambah" Then
                SQLInsert = "INSERT INTO tbl_hari (id_Hari, Nm_Hari) VALUES (@Kode, @Nama)"
                CMD = New MySqlCommand(SQLInsert, DBKoneksi)
                CMD.Parameters.AddWithValue("@Kode", TextKodeHari.Text.Trim())
                CMD.Parameters.AddWithValue("@Nama", TextNamaHari.Text.Trim())
                CMD.ExecuteNonQuery()
            End If

            MsgBox("Data berhasil disimpan", vbInformation, "Informasi")

            ' Refresh data di form utama
            Call TampilkanDataHari()

            ' Clear input
            TextKodeHari.Clear()
            TextNamaHari.Clear()

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Call KoneksiDB()

        Dim sql As String = "SELECT Id_Hari, Nm_Hari " &
                        "FROM tbl_Hari " &
                        "WHERE Nm_Hari LIKE '%" & TextCariHari.Text & "%'"

        DA = New MySqlDataAdapter(sql, DBKoneksi)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbl_Hari")

        DataGridHari.DataSource = DS.Tables("tbl_Hari")
        DataGridHari.Enabled = True

        Call AktifkanDataGridHari()
    End Sub

    Private Sub DataGridHari_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridHari.CellContentClick
        Call KoneksiDB()

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridHari.Rows(e.RowIndex)

            ' Isi textbox dengan data dari grid
            TextKodeHari.Text = row.Cells(0).Value.ToString()
            TextNamaHari.Text = row.Cells(1).Value.ToString()

            ' Atur tombol
            BtnSimpan.Enabled = True
            BtnHapus.Enabled = True
            BtnTambah.Enabled = False

            ' (Opsional) ubah warna tombol agar terlihat aktif/nonaktif
            BtnSimpan.BackColor = Color.Orange
            BtnHapus.BackColor = Color.Orange
            BtnTambah.BackColor = Color.Red

            BtnKeluar.Text = "Batal"
        End If
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If BtnKeluar.Text = "Batal" Then
            ' Reset form ke mode Tambah Hari
            TextKodeHari.Clear()
            TextNamaHari.Clear()
            TextCariHari.Clear()
            TextKodeHari.Focus()

            BtnSimpan.Enabled = False
            BtnHapus.Enabled = False
            BtnTambah.Enabled = True

            BtnSimpan.BackColor = Color.Red
            BtnHapus.BackColor = Color.Red
            BtnTambah.BackColor = Color.Orange

            BtnKeluar.Text = "Keluar"

            Call TampilkanDataHari()
        Else
            ' Kalau tombol masih "Keluar", tutup form
            Dim Pesan As DialogResult = MsgBox("Anda yakin mau keluar dari form data grid Hari?", vbQuestion + vbOKCancel, "Informasi")
            If Pesan = vbOK Then
                FrmMenuUtama.Show()     ' Tampilkan kembali form Login
                Me.Close()       ' Tutup form saat ini
            End If
            Me.Close()
            FrmMenuUtama.Show()
        End If
    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        Call KoneksiDB()
        ' Konfirmasi sebelum hapus
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?",
                                                 "Konfirmasi Hapus",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim SQLDelete As String = "DELETE FROM tbl_Hari WHERE Id_Hari = @Kode"
                CMD = New MySqlCommand(SQLDelete, DBKoneksi)
                CMD.Parameters.AddWithValue("@Kode", TextKodeHari.Text)

                CMD.ExecuteNonQuery()

                MsgBox("Data berhasil dihapus", vbInformation, "Informasi")

                ' Refresh DataGrid agar data terbaru tampil
                Call TampilkanDataHari()

                ' Reset form ke mode Tambah Hari
                TextKodeHari.Clear()
                TextNamaHari.Clear()
                TextKodeHari.Focus()

                BtnSimpan.Enabled = False
                BtnHapus.Enabled = False
                BtnTambah.Enabled = True

                BtnSimpan.BackColor = Color.Red
                BtnHapus.BackColor = Color.Red
                BtnTambah.BackColor = Color.Orange

                BtnKeluar.Text = "Keluar"

            Catch ex As Exception
                MsgBox("Terjadi kesalahan: " & ex.Message, vbCritical, "Error")
            End Try
        End If
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        Call KoneksiDB()

        If TextKodeHari.Text = "" Or TextNamaHari.Text = "" Then
            MsgBox("Silakan lengkapi semua data.", vbExclamation, "Validasi")
            Exit Sub
        End If

        Try
            ' Validasi: cek apakah nama Hari sudah dipakai oleh kode lain
            Dim sqlCheck As String = "SELECT COUNT(*) FROM tbl_Hari WHERE Nm_Hari=@Nama AND Id_Hari<>@Kode"
            Dim cmdCheck As New MySqlCommand(sqlCheck, DBKoneksi)
            cmdCheck.Parameters.AddWithValue("@Nama", TextNamaHari.Text.Trim())
            cmdCheck.Parameters.AddWithValue("@Kode", TextKodeHari.Text.Trim())

            Dim exists As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            If exists > 0 Then
                MsgBox("Nama Hari sudah ada, tidak boleh duplikat!", vbCritical, "Validasi")
                Exit Sub
            End If

            ' Perintah UPDATE untuk edit data
            Dim SQLUpdate As String = "UPDATE tbl_Hari SET Nm_Hari = @Nama WHERE Id_Hari = @Kode"
            CMD = New MySqlCommand(SQLUpdate, DBKoneksi)
            CMD.Parameters.AddWithValue("@Kode", TextKodeHari.Text.Trim())
            CMD.Parameters.AddWithValue("@Nama", TextNamaHari.Text.Trim())

            CMD.ExecuteNonQuery()

            MsgBox("Data berhasil diperbarui", vbInformation, "Informasi")

            ' Refresh DataGrid agar data terbaru tampil
            Call TampilkanDataHari()

            ' Reset form ke mode Tambah Hari
            TextKodeHari.Clear()
            TextNamaHari.Clear()
            TextKodeHari.Focus()

            BtnSimpan.Enabled = False
            BtnHapus.Enabled = False
            BtnTambah.Enabled = True

            BtnSimpan.BackColor = Color.Red
            BtnHapus.BackColor = Color.Red
            BtnTambah.BackColor = Color.Orange

            BtnKeluar.Text = "Keluar"

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub
End Class