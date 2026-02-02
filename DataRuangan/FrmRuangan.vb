Imports MySql.Data.MySqlClient
Public Class FrmRuangan
    Private Sub FrmRuangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KoneksiDB()
        TampilkanDataRuangan()

        BtnSimpan.Enabled = False
        BtnHapus.Enabled = False

        BtnSimpan.BackColor = Color.Red
        BtnHapus.BackColor = Color.Red

        DataGridRuangan.Enabled = False
    End Sub

    Sub AktifkanDataGridRuangan()
        With DataGridRuangan
            .EnableHeadersVisualStyles = False
            .Font = New Font(DataGridRuangan.Font, FontStyle.Bold)
            DataGridRuangan.DefaultCellStyle.Font = New Font("Arial", 9)
            DataGridRuangan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            DataGridRuangan.ColumnHeadersHeight = 35

            DataGridRuangan.Columns(0).Width = 80
            DataGridRuangan.Columns(0).HeaderText = "Kode Ruangan"
            DataGridRuangan.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridRuangan.Columns(1).Width = 300
            DataGridRuangan.Columns(1).HeaderText = "Nama Ruangan"
            DataGridRuangan.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridRuangan.Columns(2).Width = 80
            DataGridRuangan.Columns(2).HeaderText = "Kapasitas Ruangan"
            DataGridRuangan.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Sub TampilkanDataRuangan()
        Call KoneksiDB()

        Dim sql As String = "SELECT Kd_Ruangan, Nm_Ruangan, Jml_Kapasitas FROM tbl_ruangkelas ORDER BY Kd_Ruangan ASC"
        DA = New MySqlDataAdapter(sql, DBKoneksi)
        DS = New DataSet()
        DS.Clear()
        DA.Fill(DS, "tbl_ruangkelas")

        DataGridRuangan.DataSource = DS.Tables("tbl_ruangkelas")
        DataGridRuangan.ReadOnly = True

        Call AktifkanDataGridRuangan()
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        Call KoneksiDB()

        ' Validasi input kosong
        If TextKodeRuangan.Text = "" Or TextNamaRuangan.Text = "" Or TextKapasitasRuangan.Text = "" Then
            MsgBox("Silakan lengkapi semua data.", vbExclamation, "Validasi")
            Exit Sub
        End If

        Try
            ' Cek apakah kode atau nama Ruangan sudah ada
            Dim sqlCheck As String = "SELECT COUNT(*) FROM tbl_ruangkelas WHERE Kd_Ruangan=@Kode OR Nm_Ruangan=@Nama"
            Dim cmdCheck As New MySqlCommand(sqlCheck, DBKoneksi)
            cmdCheck.Parameters.AddWithValue("@Kode", TextKodeRuangan.Text.Trim())
            cmdCheck.Parameters.AddWithValue("@Nama", TextNamaRuangan.Text.Trim())


            Dim exists As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            If exists > 0 Then
                MsgBox("Kode atau Nama Ruangan sudah ada, tidak boleh duplikat!", vbCritical, "Validasi")
                Exit Sub
            End If

            ' Jika belum ada, lakukan insert
            If BtnTambah.Text = "Tambah" Then
                SQLInsert = "INSERT INTO tbl_ruangkelas (Kd_Ruangan, Nm_Ruangan, jml_Kapasitas) VALUES (@Kode, @Nama, @Kapasitas)"
                CMD = New MySqlCommand(SQLInsert, DBKoneksi)
                CMD.Parameters.AddWithValue("@Kode", TextKodeRuangan.Text.Trim())
                CMD.Parameters.AddWithValue("@Nama", TextNamaRuangan.Text.Trim())
                CMD.Parameters.AddWithValue("@Kapasitas", TextKapasitasRuangan.Text.Trim())

                CMD.ExecuteNonQuery()
            End If

            MsgBox("Data berhasil disimpan", vbInformation, "Informasi")

            ' Refresh data di form utama
            Call TampilkanDataRuangan()

            ' Clear input
            TextKodeRuangan.Clear()
            TextNamaRuangan.Clear()
            TextKapasitasRuangan.Clear()

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Call KoneksiDB()

        Dim sql As String = "SELECT Kd_Ruangan, Nm_Ruangan, jml_Kapasitas " &
                        "FROM tbl_ruangkelas " &
                        "WHERE Nm_Ruangan LIKE '%" & TextCariRuangan.Text & "%'"

        DA = New MySqlDataAdapter(sql, DBKoneksi)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbl_ruangkelas")

        DataGridRuangan.DataSource = DS.Tables("tbl_ruangkelas")
        DataGridRuangan.Enabled = True

        Call AktifkanDataGridRuangan()
    End Sub

    Private Sub DataGridRuangan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridRuangan.CellContentClick
        Call KoneksiDB()

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridRuangan.Rows(e.RowIndex)

            ' Isi textbox dengan data dari grid
            TextKodeRuangan.Text = row.Cells(0).Value.ToString()
            TextNamaRuangan.Text = row.Cells(1).Value.ToString()
            TextKapasitasRuangan.Text = row.Cells(2).Value.ToString()

            ' Atur tombol
            BtnSimpan.Enabled = True
            BtnHapus.Enabled = True
            BtnTambah.Enabled = False

            ' (Opsional) ubah warna tombol agar terlihat aktif/nonaktif
            BtnSimpan.BackColor = Color.Orange
            BtnHapus.BackColor = Color.Orange
            BtnTambah.BackColor = Color.Red

            'LbJudul.Text = "Edit Ruangan"
            BtnKeluar.Text = "Batal"
        End If
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If BtnKeluar.Text = "Batal" Then
            ' Reset form ke mode Tambah Ruangan
            TextKodeRuangan.Clear()
            TextNamaRuangan.Clear()
            TextKapasitasRuangan.Clear()
            TextKodeRuangan.Focus()

            BtnSimpan.Enabled = False
            BtnHapus.Enabled = False
            BtnTambah.Enabled = True

            BtnSimpan.BackColor = Color.Red
            BtnHapus.BackColor = Color.Red
            BtnTambah.BackColor = Color.Orange

            BtnKeluar.Text = "Keluar"

            Call TampilkanDataRuangan()
        Else
            ' Kalau tombol masih "Keluar", tutup form
            Dim Pesan As DialogResult = MsgBox("Anda yakin mau keluar dari form data grid Ruangan?", vbQuestion + vbOKCancel, "Informasi")
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
                Dim SQLDelete As String = "DELETE FROM tbl_ruangkelas WHERE Kd_Ruangan = @Kode"
                CMD = New MySqlCommand(SQLDelete, DBKoneksi)
                CMD.Parameters.AddWithValue("@Kode", TextKodeRuangan.Text)

                CMD.ExecuteNonQuery()

                MsgBox("Data berhasil dihapus", vbInformation, "Informasi")

                ' Refresh DataGrid agar data terbaru tampil
                Call TampilkanDataRuangan()

                ' Reset form ke mode Tambah Ruangan
                TextKodeRuangan.Clear()
                TextNamaRuangan.Clear()
                TextKapasitasRuangan.Clear()
                TextKodeRuangan.Focus()

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

        If TextKodeRuangan.Text = "" Or TextNamaRuangan.Text = "" Then
            MsgBox("Silakan lengkapi semua data.", vbExclamation, "Validasi")
            Exit Sub
        End If

        Try
            ' Validasi: cek apakah nama Ruangan sudah dipakai oleh kode lain
            Dim sqlCheck As String = "SELECT COUNT(*) FROM tbl_ruangkelas WHERE Nm_Ruangan=@Nama AND Kd_Ruangan<>@Kode"
            Dim cmdCheck As New MySqlCommand(sqlCheck, DBKoneksi)
            cmdCheck.Parameters.AddWithValue("@Nama", TextNamaRuangan.Text.Trim())
            cmdCheck.Parameters.AddWithValue("@Kode", TextKodeRuangan.Text.Trim())

            Dim exists As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            If exists > 0 Then
                MsgBox("Nama Ruangan sudah ada, tidak boleh duplikat!", vbCritical, "Validasi")
                Exit Sub
            End If

            ' Perintah UPDATE untuk edit data
            Dim SQLUpdate As String = "UPDATE tbl_ruangkelas SET Nm_Ruangan = @Nama, jml_Kapasitas = @Kapasitas WHERE Kd_Ruangan = @Kode"
            CMD = New MySqlCommand(SQLUpdate, DBKoneksi)
            CMD.Parameters.AddWithValue("@Kode", TextKodeRuangan.Text.Trim())
            CMD.Parameters.AddWithValue("@Nama", TextNamaRuangan.Text.Trim())
            CMD.Parameters.AddWithValue("@Kapasitas", Convert.ToInt32(TextKapasitasRuangan.Text.Trim()))

            CMD.ExecuteNonQuery()

            MsgBox("Data berhasil diperbarui", vbInformation, "Informasi")

            ' Refresh DataGrid agar data terbaru tampil
            Call TampilkanDataRuangan()

            ' Reset form ke mode Tambah Ruangan
            TextKodeRuangan.Clear()
            TextNamaRuangan.Clear()
            TextKapasitasRuangan.Clear()
            TextKodeRuangan.Focus()

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