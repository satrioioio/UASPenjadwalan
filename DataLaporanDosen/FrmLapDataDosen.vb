Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmLapDataDosen

    Private isloading As Boolean = True

    Sub TampilkanNamaProdi()
        Call KoneksiDB()
        Dim DT As New DataTable
        Dim DA As New MySqlDataAdapter("SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Kd_Prodi", DBKoneksi)
        DA.Fill(DT)

        CmbNamaProdi.DataSource = DT
        CmbNamaProdi.DisplayMember = "Nm_Prodi"
        CmbNamaProdi.ValueMember = "Kd_Prodi"
    End Sub

    Private Sub BtnCetakLaporan_Click(sender As Object, e As EventArgs) Handles BtnCetakLaporan.Click
        Try
            Call KoneksiDB()

            ' Query hanya berdasarkan Nama Prodi
            Dim SQL As String = "SELECT COUNT(*) FROM v_dosen_prodi d WHERE d.Nm_Prodi = @NmProdi"

            Dim CMD As New MySqlCommand(SQL, DBKoneksi)
            CMD.Parameters.AddWithValue("@NmProdi", CmbNamaProdi.Text)

            Dim jumlahData As Integer = Convert.ToInt32(CMD.ExecuteScalar())
            If jumlahData = 0 Then
                MsgBox("Data tidak ditemukan, laporan tidak bisa dicetak.", vbInformation, "Informasi")
                ' Bersihkan report viewer agar tidak menampilkan data lama
                CrystalReportViewer1.ReportSource = Nothing
                CrystalReportViewer1.RefreshReport()
                Exit Sub
            End If

            Dim LapDataDosen As New ReportDocument
            LapDataDosen.Load("C:\UAS_DbPenjadwalan24022\DbPenjadwalan24022\DataLaporanDosen\CryLapDataDosen.rpt")
            CrystalReportViewer1.ReportSource = LapDataDosen

            ' Selection Formula hanya filter prodi
            CrystalReportViewer1.SelectionFormula = "({v_dosen_prodi1.Nm_Prodi})='" & CmbNamaProdi.Text & "'"

            CrystalReportViewer1.RefreshReport()
            LapDataDosen.Dispose()
        Catch ex As Exception
            MsgBox("Terjadi error saat mencetak laporan: " & ex.Message, vbCritical, "Error")
        End Try

    End Sub

    Private Sub FrmLapDataDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilkanNamaProdi()
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        If BtnKeluar.Text = "&KELUAR" Then
            Pesan = MsgBox("Anda Yakin Mau Exit dari From Laporan Mahasiswa?", vbQuestion + vbYesNo, "Informasi")
            If Pesan = vbYes Then
                Me.Close()
            End If
            Me.Enabled = True

            FrmDataDosen.Close()

            BtnKeluar.Text = "&KELUAR"
            BtnKeluar.BackColor = Color.LightGray
        End If
    End Sub
End Class