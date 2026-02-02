Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmLapDataMataKuliah
    Sub TampilkanNamaProdi()
        Call KoneksiDB()
        Dim DT As New DataTable
        Dim DA As New MySqlDataAdapter("SELECT Kd_Prodi, Nm_Prodi FROM tbl_prodi ORDER BY Kd_Prodi", DBKoneksi)
        DA.Fill(DT)

        CmbNamaProdi.DataSource = DT
        CmbNamaProdi.DisplayMember = "Nm_Prodi"
        CmbNamaProdi.ValueMember = "Kd_Prodi"
    End Sub

    Sub TampilkanSemester()
        CmbSemester.Items.Clear()
        CmbSemester.Items.Add("GANJIL")
        CmbSemester.Items.Add("GENAP")
        CmbSemester.SelectedIndex = 0 ' Default ke GANJIL
    End Sub

    Private Sub BtnCetakLaporan_Click(sender As Object, e As EventArgs) Handles BtnCetakLaporan.Click
        Try
            Call KoneksiDB()
            Dim jenisSemester As Integer = If(CmbSemester.Text = "GANJIL", 1, 0)

            Dim SQL As String = "SELECT COUNT(*) FROM v_matakuliah_perprodi " &
                    "WHERE Nm_Prodi = @NmProdi AND Semester_Matkul % 2 = @Jenis"

            Dim CMD As New MySqlCommand(SQL, DBKoneksi)
            CMD.Parameters.AddWithValue("@NmProdi", CmbNamaProdi.Text)
            CMD.Parameters.AddWithValue("@Jenis", jenisSemester)

            Dim jumlahData As Integer = Convert.ToInt32(CMD.ExecuteScalar())
            If jumlahData = 0 Then
                MsgBox("Data tidak ditemukan, laporan tidak bisa dicetak.", vbInformation, "Informasi")

                ' Bersihkan report viewer agar tidak menampilkan data lama
                CrystalReportViewer2.ReportSource = Nothing
                CrystalReportViewer2.RefreshReport()
                Exit Sub
            End If

            ' Load report
            Dim LapMatakuliah As New ReportDocument
            LapMatakuliah.Load("C:\UAS_DbPenjadwalan24022\DbPenjadwalan24022\DataLaporanMatkul\CryLapDataMatkul.rpt")

            CrystalReportViewer2.SelectionFormula = "({v_matakuliah_perprodi1.Nm_Prodi})='" & CmbNamaProdi.Text & "' AND " &
                                        "({v_matakuliah_perprodi1.Semester_Matkul} Mod 2)=" & jenisSemester

            CrystalReportViewer2.ReportSource = LapMatakuliah
            CrystalReportViewer2.RefreshReport()
        Catch ex As Exception
            MsgBox("Terjadi error saat mencetak laporan: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub FrmLapDataMataKuliah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilkanNamaProdi()
        Call TampilkanSemester()
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