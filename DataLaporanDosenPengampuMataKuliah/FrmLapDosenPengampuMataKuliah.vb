Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmLapDosenPengampuMataKuliah
    Sub TampilkanNamaProdi()
        Call KoneksiDB()
        Dim DT As New DataTable
        Dim DA As New MySqlDataAdapter("SELECT Nm_Prodi FROM tbl_prodi ORDER BY Kd_Prodi", DBKoneksi)
        DA.Fill(DT)
        CmbNamaProdi.DataSource = DT
        CmbNamaProdi.DisplayMember = "Nm_Prodi"
    End Sub

    Sub TampilkanTahun()
        Call KoneksiDB()
        Dim DT As New DataTable
        Dim DA As New MySqlDataAdapter("SELECT DISTINCT Tahun_Akademik FROM tbl_dosenpengampu_matkul ORDER BY Tahun_Akademik DESC", DBKoneksi)
        DA.Fill(DT)
        CmbTahunAkademik.DataSource = DT
        CmbTahunAkademik.DisplayMember = "Tahun_Akademik"
        CmbTahunAkademik.SelectedIndex = -1
    End Sub

    Private Sub FrmLapDosenPengampu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilkanNamaProdi()
        Call TampilkanTahun()

        CmbNmSemester.Items.Clear()
        CmbNmSemester.Items.Add("GANJIL")
        CmbNmSemester.Items.Add("GENAP")
    End Sub

    Private Sub BtnCetakDsnPengampu_Click(sender As Object, e As EventArgs) Handles BtnCetakDsnPengampu.Click
        ' 1. Validasi Input Lengkap
        If TextKdDsn.Text = "" Or LbNmDsn.Text = "-" Then
            MsgBox("Pilih Dosen terlebih dahulu!", vbExclamation, "Peringatan")
            TextKdDsn.Focus()
            Exit Sub
        End If
        If CmbTahunAkademik.Text = "" Then
            MsgBox("Pilih Tahun Akademik!", vbExclamation, "Peringatan")
            CmbTahunAkademik.Focus()
            Exit Sub
        End If
        If CmbNmSemester.Text = "" Then
            MsgBox("Pilih Semester (Ganjil/Genap)!", vbExclamation, "Peringatan")
            CmbNmSemester.Focus()
            Exit Sub
        End If

        Try
            Call KoneksiDB()

            ' 2. CEK DATA DULU (Validasi Data Kosong) - Agar tidak blank putih
            Dim SQLCek As String = "SELECT * FROM v_laporan_dosen_pengampu WHERE Kd_Dosen = @Kd AND Tahun_Akademik = @Thn"
            Dim DACek As New MySqlDataAdapter(SQLCek, DBKoneksi)
            DACek.SelectCommand.Parameters.AddWithValue("@Kd", TextKdDsn.Text)
            DACek.SelectCommand.Parameters.AddWithValue("@Thn", CmbTahunAkademik.Text)

            Dim DT As New DataTable
            DACek.Fill(DT)

            ' Filter manual Ganjil/Genap di DataTable (Logic Modulus)
            Dim FilteredRows() As DataRow
            If CmbNmSemester.Text = "GANJIL" Then
                FilteredRows = DT.Select("Semester_Matkul % 2 <> 0")
            Else
                FilteredRows = DT.Select("Semester_Matkul % 2 = 0")
            End If

            If FilteredRows.Length = 0 Then
                MsgBox("Data Jadwal Dosen tidak ditemukan pada Tahun/Semester tersebut.", vbInformation)
                CrystalReportViewer3.ReportSource = Nothing
                Exit Sub
            End If

            ' 3. JIKA ADA, LOAD REPORT
            Dim LapDosen As New ReportDocument
            Dim rptPath As String = "C:\UAS_DbPenjadwalan24022\DbPenjadwalan24022\DataLaporanDosenPengampuMataKuliah\CryLapDataDosenPengampu.rpt
"

            If Not IO.File.Exists(rptPath) Then
                MsgBox("File Report tidak ditemukan di jalur: " & rptPath, vbCritical)
                Exit Sub
            End If

            LapDosen.Load(rptPath)

            ' 4. Push Data (Gunakan DT awal agar struktur aman)
            DT.TableName = "v_laporan_dosen_pengampu1" ' Pastikan nama ini sama persis dgn di Database Expert CR
            LapDosen.DataSourceConnections.Clear()
            LapDosen.Database.Tables(0).SetDataSource(DT)

            ' 5. Formula Filter Tampilan
            Dim Formula As String = "{v_laporan_dosen_pengampu1.Kd_Dosen} = '" & TextKdDsn.Text & "' AND {v_laporan_dosen_pengampu1.Tahun_Akademik} = '" & CmbTahunAkademik.Text & "'"

            If CmbNmSemester.Text = "GANJIL" Then
                Formula &= " AND Remainder({v_laporan_dosen_pengampu1.Semester_Matkul}, 2) <> 0"
            Else
                Formula &= " AND Remainder({v_laporan_dosen_pengampu1.Semester_Matkul}, 2) = 0"
            End If

            CrystalReportViewer3.SelectionFormula = Formula
            CrystalReportViewer3.ReportSource = LapDosen
            CrystalReportViewer3.RefreshReport()

        Catch ex As Exception
            MsgBox("Error Cetak Perorangan: " & ex.Message, vbCritical)
        End Try
    End Sub

    ' ==================================================================================
    ' TOMBOL 2: CETAK REKAP (Per Tahun/Prodi)
    ' ==================================================================================
    Private Sub BtnCetakTahunAkademik_Click(sender As Object, e As EventArgs) Handles BtnCetakTahunAkademik.Click
        LbNmDsn.Text = "-"
        LbNidnDsn.Text = "-"
        LbTahunAkademik.Text = "-"
        TextKdDsn.Clear()

        If CmbNamaProdi.Text = "" Or CmbTahunAkademik.Text = "" Or CmbNmSemester.Text = "" Then
            MsgBox("Mohon lengkapi filter: Prodi, Tahun Akademik, dan Semester!", vbExclamation)
            Exit Sub
        End If

        Try
            Call KoneksiDB()

            ' 2. Ambil Data (HANYA Filter Prodi & Tahun)
            ' KITA HAPUS Filter Kode Dosen disini agar mengambil semua orang
            Dim SQL As String = "SELECT * FROM v_laporan_dosen_pengampu WHERE Nm_Prodi = @Prodi AND Tahun_Akademik = @Thn"

            Dim DA As New MySqlDataAdapter(SQL, DBKoneksi)
            DA.SelectCommand.Parameters.AddWithValue("@Prodi", CmbNamaProdi.Text)
            DA.SelectCommand.Parameters.AddWithValue("@Thn", CmbTahunAkademik.Text)

            Dim DT As New DataTable
            DA.Fill(DT)

            ' Filter Semester (Logic Ganjil/Genap)
            Dim FilteredRows() As DataRow
            If CmbNmSemester.Text = "GANJIL" Then
                FilteredRows = DT.Select("Semester_Matkul % 2 <> 0")
            Else
                FilteredRows = DT.Select("Semester_Matkul % 2 = 0")
            End If

            ' Cek Data Kosong
            If FilteredRows.Length = 0 Then
                MsgBox("Tidak ada data jadwal untuk Prodi & Tahun tersebut.", vbInformation)
                CrystalReportViewer3.ReportSource = Nothing
                Exit Sub
            End If

            ' 3. Load Report
            Dim LapTahun As New ReportDocument
            ' Pastikan path benar
            LapTahun.Load("C:\UAS_DbPenjadwalan24022\DbPenjadwalan24022\DataLaporanDosenPengampuMataKuliah\CryLapDataDosenPengampu.rpt")

            DT.TableName = "v_laporan_dosen_pengampu1"
            LapTahun.DataSourceConnections.Clear()
            LapTahun.Database.Tables(0).SetDataSource(DT)

            ' 4. Formula Filter Tampilan (FIX: JANGAN MASUKKAN KODE DOSEN)
            Dim Formula As String = "{v_laporan_dosen_pengampu1.Nm_Prodi} = '" & CmbNamaProdi.Text & "' AND " &
                                    "{v_laporan_dosen_pengampu1.Tahun_Akademik} = '" & CmbTahunAkademik.Text & "'"

            ' HAPUS BAGIAN "If TextKdDsn.Text <> "" Then..." YANG DULU ADA DISINI
            ' AGAR DIA MENGABAIKAN INPUTAN TEXTBOX KODE DOSEN

            If CmbNmSemester.Text = "GANJIL" Then
                Formula &= " AND Remainder({v_laporan_dosen_pengampu1.Semester_Matkul}, 2) <> 0"
            Else
                Formula &= " AND Remainder({v_laporan_dosen_pengampu1.Semester_Matkul}, 2) = 0"
            End If

            CrystalReportViewer3.SelectionFormula = Formula
            CrystalReportViewer3.ReportSource = LapTahun
            CrystalReportViewer3.RefreshReport()

        Catch ex As Exception
            MsgBox("Error Cetak Rekap: " & ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
        Me.Close()
    End Sub

    Private Sub TextKdDsn_KeyDown(sender As Object, e As KeyEventArgs) Handles TextKdDsn.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim kodeMurni As String = TextKdDsn.Text.Trim()
            TextKdDsn.Text = kodeMurni ' Rapikan spasi

            If kodeMurni = "" Then Exit Sub
            Try
                Call KoneksiDB()
                ' Menggunakan Parameter @KdDosen agar aman dari error tanda kutip
                Dim SQL As String = "SELECT d.Nm_Dosen, d.Nidn_Dosen, p.Nm_Prodi, " &
                                    "(SELECT Tahun_Akademik FROM tbl_dosenpengampu_matkul " &
                                    " WHERE Kd_Dosen = d.Kd_Dosen ORDER BY Tahun_Akademik DESC LIMIT 1) as ThnTerakhir " &
                                    "FROM tbl_dosen d " &
                                    "INNER JOIN tbl_prodi p ON d.Kd_Prodi = p.Kd_Prodi " &
                                    "WHERE d.Kd_Dosen = @KdDosen"

                CMD = New MySqlCommand(SQL, DBKoneksi)
                CMD.Parameters.AddWithValue("@KdDosen", kodeMurni)

                DR = CMD.ExecuteReader

                If DR.Read Then
                    LbNmDsn.Text = DR("Nm_Dosen").ToString()
                    LbNidnDsn.Text = DR("Nidn_Dosen").ToString()

                    ' Otomatis Set Prodi sesuai Dosen (Validasi Konsistensi)
                    CmbNamaProdi.Text = DR("Nm_Prodi").ToString()

                    ' Set Tahun Terakhir jika ada
                    If Not IsDBNull(DR("ThnTerakhir")) Then
                        LbTahunAkademik.Text = DR("ThnTerakhir").ToString()
                        CmbTahunAkademik.Text = DR("ThnTerakhir").ToString()
                    Else
                        LbTahunAkademik.Text = "-"
                    End If
                Else
                    MsgBox("Kode Dosen '" & kodeMurni & "' tidak ditemukan.", vbExclamation)
                    LbNmDsn.Text = "-"
                    LbNidnDsn.Text = "-"
                    LbTahunAkademik.Text = "-"

                    ' Fokuskan kembali agar user mudah mengedit
                    TextKdDsn.Focus()
                    TextKdDsn.SelectAll()
                End If
                DR.Close()
            Catch ex As Exception
                MsgBox("Error Cari: " & ex.Message, vbCritical)
            End Try

            e.SuppressKeyPress = True
        End If
    End Sub

End Class