Public Class FrmMenuUtama
    Public CurrentLevel As String = ""
    Public CurrentUser As String = ""

    Private Sub AboutBoxTentangAplikasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutBoxTentangAplikasiToolStripMenuItem.Click
        TentangAplikasi.MdiParent = Me
        TentangAplikasi.Show()
    End Sub

    Private Sub FrmMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AktifkanMenu(False)
    End Sub

    Private Sub AktifkanMenu(isLogin As Boolean)
        DATAMASTERToolStripMenuItem.Enabled = isLogin
        DATATRANSAKSIToolStripMenuItem.Enabled = isLogin
        DATALAPORANToolStripMenuItem.Enabled = isLogin
        LogOutSystemToolStripMenuItem.Enabled = isLogin
        LogInSystemToolStripMenuItem.Enabled = Not isLogin
        ExitToolStripMenuItem.Enabled = Not isLogin
    End Sub

    Public Sub LoginBerhasil(level As String, namaUser As String)
        CurrentLevel = level
        CurrentUser = namaUser
        AktifkanMenu(True)

        ' Jika level Dosen, batasi akses
        If level = "Dosen" Then
            DATAMASTERToolStripMenuItem.Enabled = False
            DATATRANSAKSIToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub LogInSystemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogInSystemToolStripMenuItem.Click
        Dim frmlogin As New FrmLogin()
        frmlogin.MdiParent = Nothing
        frmlogin.ShowDialog(Me)
    End Sub

    Private Sub LogOutSystemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutSystemToolStripMenuItem.Click
        Dim result As DialogResult = MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            AktifkanMenu(False)
            CurrentLevel = ""
            CurrentUser = ""
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DataProdiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataProdiToolStripMenuItem.Click
        Dim frmprodi As New FrmProdi()
        frmprodi.MdiParent = Nothing
        frmprodi.ShowDialog(Me)
    End Sub

    Private Sub DataHariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataHariToolStripMenuItem.Click
        Dim frmhari As New FrmHari()
        frmhari.MdiParent = Nothing
        frmhari.ShowDialog(Me)
    End Sub

    Private Sub DataRuangKelasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataRuangKelasToolStripMenuItem.Click
        Dim frmruangan As New FrmRuangan()
        frmruangan.MdiParent = Nothing
        frmruangan.ShowDialog(Me)
    End Sub

    Private Sub DataDosenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DataDosenToolStripMenuItem1.Click
        Dim frmdosen As New FrmDosen()
        frmdosen.MdiParent = Nothing
        frmdosen.ShowDialog(Me)
    End Sub

    Private Sub DataMataKuliahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataMataKuliahToolStripMenuItem.Click
        Dim frmmatkul As New FrmDataMataKuliah()
        frmmatkul.MdiParent = Nothing
        frmmatkul.ShowDialog(Me)
    End Sub

    Private Sub DataDosenPengampuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataDosenPengampuToolStripMenuItem.Click
        Dim frmpengampu As New FrmDosenPengampu()
        frmpengampu.MdiParent = Nothing
        frmpengampu.ShowDialog(Me)
    End Sub

    Private Sub DataPenjadwalanMatakuliahDosenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DataPenjadwalanMatakuliahDosenToolStripMenuItem1.Click
        Dim Jadwal As New FormPenjadwalanMatkul()
        Jadwal.MdiParent = Nothing
        Jadwal.ShowDialog(Me)
    End Sub

    Private Sub LaporanDataDosenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanDataDosenToolStripMenuItem.Click
        Dim frmLapDosen As New FrmLapDataDosen()
        frmLapDosen.ShowDialog(Me)
    End Sub

    Private Sub LaporanDataDosenPengampuMatakuliahBerdasarkanTahunAkademikToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanDataDosenPengampuMatakuliahBerdasarkanTahunAkademikToolStripMenuItem.Click
        Dim FrmLapMatkul As New FrmLapDataMataKuliah
        FrmLapMatkul.ShowDialog(Me)
    End Sub

    Private Sub LaporanDataDosenPengampuMatakuliahBerdasarkanTahunAkademikToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LaporanDataDosenPengampuMatakuliahBerdasarkanTahunAkademikToolStripMenuItem1.Click
        Dim frmLapPengampu As New FrmLapDosenPengampuMataKuliah()
        frmLapPengampu.ShowDialog(Me)
    End Sub

    Private Sub LaporanPenjadwalanMatakuliahBerdasarkanTahunAkademikToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LaporanPenjadwalanMatakuliahBerdasarkanTahunAkademikToolStripMenuItem1.Click
        Dim frmLapJadwal As New FrmLapdataPenjadwalanMatkul()
        frmLapJadwal.ShowDialog(Me)
    End Sub


End Class