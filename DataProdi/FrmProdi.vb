Public Class FrmProdi
    Private Sub FrmProdi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KoneksiDB()
        TampilkanDataProdi()

        BtnSimpan.Enabled = False
        BtnHapus.Enabled = False

        BtnSimpan.BackColor = Color.Red
        BtnHapus.BackColor = Color.Red

        DataGridProdi.Enabled = False
    End Sub
    Sub AktifkanDataGridProdi()
        With DataGridProdi
            .EnableHeadersVisualStyles = False
            .Font = New Font(DataGridProdi.Font, FontStyle.Bold)
            DataGridProdi.DefaultCellStyle.Font = New Font("Arial", 9)
            DataGridProdi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            DataGridProdi.ColumnHeadersHeight = 35

            DataGridProdi.Columns(0).Width = 80
            DataGridProdi.Columns(0).HeaderText = "Kode Jurusan"
            DataGridProdi.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridProdi.Columns(1).Width = 300
            DataGridProdi.Columns(1).HeaderText = "Nama Jurusan"
            DataGridProdi.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    Sub TampilkanDataProdi()
        Call KoneksiDB()

        Dim sql As String = "SELECT Kd_prodi, Nm_prodi FROM tbl_prodi ORDER BY Kd_prodi ASC"
        DA = New MySqlDataAdapter(sql, DBKoneksi)
        DS = New DataSet()
        DS.Clear()
        DA.Fill(DS, "tbl_prodi")

        DataGridProdi.DataSource = DS.Tables("tbl_prodi")
        DataGridProdi.ReadOnly = True

        Call AktifkanDataGridProdi()
    End Sub

    Private Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        Call KoneksiDB()

        ' Validasi input kosong
        If TextKodeProdi.Text = "" Or TextNamaProdi.Text = "" Then
            MsgBox("Silakan lengkapi semua data.", vbExclamation, "Validasi")
            Exit Sub
        End If

        Try
            ' Cek apakah kode atau nama prodi sudah ada
            Dim sqlCheck As String = "SELECT COUNT(*) FROM tbl_prodi WHERE Kd_prodi=@Kode OR Nm_prodi=@Nama"
            Dim cmdCheck As New MySqlCommand(sqlCheck, DBKoneksi)
            cmdCheck.Parameters.AddWithValue("@Kode", TextKodeProdi.Text.Trim())
            cmdCheck.Parameters.AddWithValue("@Nama", TextNamaProdi.Text.Trim())

            Dim exists As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            If exists > 0 Then
                MsgBox("Kode atau Nama Prodi sudah ada, tidak boleh duplikat!", vbCritical, "Validasi")
                Exit Sub
            End If

            ' Jika belum ada, lakukan insert
            If BtnTambah.Text = "Tambah" Then
                SQLInsert = "INSERT INTO tbl_prodi (Kd_prodi, Nm_prodi) VALUES (@Kode, @Nama)"
                CMD = New MySqlCommand(SQLInsert, DBKoneksi)
                CMD.Parameters.AddWithValue("@Kode", TextKodeProdi.Text.Trim())
                CMD.Parameters.AddWithValue("@Nama", TextNamaProdi.Text.Trim())
                CMD.ExecuteNonQuery()
            End If

            MsgBox("Data berhasil disimpan", vbInformation, "Informasi")

            ' Refresh data di form utama
            Call TampilkanDataProdi()

            ' Clear input
            TextKodeProdi.Clear()
            TextNamaProdi.Clear()

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Call KoneksiDB()

        Dim sql As String = "SELECT Kd_prodi, Nm_prodi " &
                        "FROM tbl_prodi " &
                        "WHERE Nm_prodi LIKE '%" & TextCariProdi.Text & "%'"

        DA = New MySqlDataAdapter(sql, DBKoneksi)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbl_prodi")

        DataGridProdi.DataSource = DS.Tables("tbl_prodi")
        DataGridProdi.Enabled = True

        Call AktifkanDataGridProdi()
    End Sub

    Private Sub DataGridProdi_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridProdi.CellMouseDoubleClick
        Call KoneksiDB()

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridProdi.Rows(e.RowIndex)

            ' Isi textbox dengan data dari grid
            TextKodeProdi.Text = row.Cells(0).Value.ToString()
            TextNamaProdi.Text = row.Cells(1).Value.ToString()

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
            ' Reset form ke mode Tambah Prodi
            TextKodeProdi.Clear()
            TextNamaProdi.Clear()
            TextCariProdi.Clear()
            TextKodeProdi.Focus()

            BtnSimpan.Enabled = False
            BtnHapus.Enabled = False
            BtnTambah.Enabled = True

            BtnSimpan.BackColor = Color.Red
            BtnHapus.BackColor = Color.Red
            BtnTambah.BackColor = Color.Orange

            BtnKeluar.Text = "Keluar"

            Call TampilkanDataProdi()
        Else
            ' Kalau tombol masih "Keluar", tutup form
            Dim Pesan As DialogResult = MsgBox("Anda yakin mau keluar dari form data grid prodi?", vbQuestion + vbOKCancel, "Informasi")
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
                Dim SQLDelete As String = "DELETE FROM tbl_prodi WHERE Kd_prodi = @Kode"
                CMD = New MySqlCommand(SQLDelete, DBKoneksi)
                CMD.Parameters.AddWithValue("@Kode", TextKodeProdi.Text)

                CMD.ExecuteNonQuery()

                MsgBox("Data berhasil dihapus", vbInformation, "Informasi")

                ' Refresh DataGrid agar data terbaru tampil
                Call TampilkanDataProdi()

                ' Reset form ke mode Tambah Prodi
                TextKodeProdi.Clear()
                TextNamaProdi.Clear()
                TextKodeProdi.Focus()

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

        If TextKodeProdi.Text = "" Or TextNamaProdi.Text = "" Then
            MsgBox("Silakan lengkapi semua data.", vbExclamation, "Validasi")
            Exit Sub
        End If

        Try
            ' Validasi: cek apakah nama prodi sudah dipakai oleh kode lain
            Dim sqlCheck As String = "SELECT COUNT(*) FROM tbl_prodi WHERE Nm_prodi=@Nama AND Kd_prodi<>@Kode"
            Dim cmdCheck As New MySqlCommand(sqlCheck, DBKoneksi)
            cmdCheck.Parameters.AddWithValue("@Nama", TextNamaProdi.Text.Trim())
            cmdCheck.Parameters.AddWithValue("@Kode", TextKodeProdi.Text.Trim())

            Dim exists As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            If exists > 0 Then
                MsgBox("Nama Prodi sudah ada, tidak boleh duplikat!", vbCritical, "Validasi")
                Exit Sub
            End If

            ' Perintah UPDATE untuk edit data
            Dim SQLUpdate As String = "UPDATE tbl_prodi SET Nm_prodi = @Nama WHERE Kd_prodi = @Kode"
            CMD = New MySqlCommand(SQLUpdate, DBKoneksi)
            CMD.Parameters.AddWithValue("@Kode", TextKodeProdi.Text.Trim())
            CMD.Parameters.AddWithValue("@Nama", TextNamaProdi.Text.Trim())

            CMD.ExecuteNonQuery()

            MsgBox("Data berhasil diperbarui", vbInformation, "Informasi")

            ' Refresh DataGrid agar data terbaru tampil
            Call TampilkanDataProdi()

            ' Reset form ke mode Tambah Prodi
            TextKodeProdi.Clear()
            TextNamaProdi.Clear()
            TextKodeProdi.Focus()

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