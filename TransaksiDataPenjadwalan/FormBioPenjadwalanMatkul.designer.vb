<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBioPenjadwalanMatkul
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnKeluar = New System.Windows.Forms.Button()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbSmester = New System.Windows.Forms.Label()
        Me.lbSksPraktek = New System.Windows.Forms.Label()
        Me.lbSksTeori = New System.Windows.Forms.Label()
        Me.LbSks = New System.Windows.Forms.Label()
        Me.lbNamaMatkul = New System.Windows.Forms.Label()
        Me.lbKodeMatkul = New System.Windows.Forms.Label()
        Me.lbNamaDosen = New System.Windows.Forms.Label()
        Me.lbNidn = New System.Windows.Forms.Label()
        Me.lbNikDosen = New System.Windows.Forms.Label()
        Me.BtnCari = New System.Windows.Forms.Button()
        Me.TxtJamAwal = New System.Windows.Forms.TextBox()
        Me.TxtJamAkhir = New System.Windows.Forms.TextBox()
        Me.TxtKdPengampu = New System.Windows.Forms.TextBox()
        Me.CbNamaHari = New System.Windows.Forms.ComboBox()
        Me.CbRuangKelas = New System.Windows.Forms.ComboBox()
        Me.CbTahunAkademik = New System.Windows.Forms.ComboBox()
        Me.CbNamaSemester = New System.Windows.Forms.ComboBox()
        Me.CbNamaProdi = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(667, 70)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data Penjadwalan Matakuliah"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.BtnKeluar)
        Me.Panel1.Controls.Add(Me.BtnHapus)
        Me.Panel1.Controls.Add(Me.BtnSimpan)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 707)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(667, 96)
        Me.Panel1.TabIndex = 1
        '
        'BtnKeluar
        '
        Me.BtnKeluar.AutoSize = True
        Me.BtnKeluar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtnKeluar.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKeluar.Location = New System.Drawing.Point(445, 23)
        Me.BtnKeluar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.Size = New System.Drawing.Size(179, 60)
        Me.BtnKeluar.TabIndex = 4
        Me.BtnKeluar.Text = "Keluar"
        Me.BtnKeluar.UseVisualStyleBackColor = False
        '
        'BtnHapus
        '
        Me.BtnHapus.AutoSize = True
        Me.BtnHapus.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHapus.Location = New System.Drawing.Point(240, 23)
        Me.BtnHapus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(179, 60)
        Me.BtnHapus.TabIndex = 3
        Me.BtnHapus.Text = "Hapus"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'BtnSimpan
        '
        Me.BtnSimpan.AutoSize = True
        Me.BtnSimpan.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtnSimpan.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSimpan.Location = New System.Drawing.Point(33, 23)
        Me.BtnSimpan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(179, 60)
        Me.BtnSimpan.TabIndex = 2
        Me.BtnSimpan.Text = "Simpan"
        Me.BtnSimpan.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.Controls.Add(Me.lbSmester)
        Me.Panel2.Controls.Add(Me.lbSksPraktek)
        Me.Panel2.Controls.Add(Me.lbSksTeori)
        Me.Panel2.Controls.Add(Me.LbSks)
        Me.Panel2.Controls.Add(Me.lbNamaMatkul)
        Me.Panel2.Controls.Add(Me.lbKodeMatkul)
        Me.Panel2.Controls.Add(Me.lbNamaDosen)
        Me.Panel2.Controls.Add(Me.lbNidn)
        Me.Panel2.Controls.Add(Me.lbNikDosen)
        Me.Panel2.Controls.Add(Me.BtnCari)
        Me.Panel2.Controls.Add(Me.TxtJamAwal)
        Me.Panel2.Controls.Add(Me.TxtJamAkhir)
        Me.Panel2.Controls.Add(Me.TxtKdPengampu)
        Me.Panel2.Controls.Add(Me.CbNamaHari)
        Me.Panel2.Controls.Add(Me.CbRuangKelas)
        Me.Panel2.Controls.Add(Me.CbTahunAkademik)
        Me.Panel2.Controls.Add(Me.CbNamaSemester)
        Me.Panel2.Controls.Add(Me.CbNamaProdi)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 70)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(667, 637)
        Me.Panel2.TabIndex = 2
        '
        'lbSmester
        '
        Me.lbSmester.BackColor = System.Drawing.Color.White
        Me.lbSmester.Location = New System.Drawing.Point(195, 861)
        Me.lbSmester.Name = "lbSmester"
        Me.lbSmester.Size = New System.Drawing.Size(86, 29)
        Me.lbSmester.TabIndex = 34
        '
        'lbSksPraktek
        '
        Me.lbSksPraktek.BackColor = System.Drawing.Color.White
        Me.lbSksPraktek.Location = New System.Drawing.Point(195, 593)
        Me.lbSksPraktek.Name = "lbSksPraktek"
        Me.lbSksPraktek.Size = New System.Drawing.Size(86, 29)
        Me.lbSksPraktek.TabIndex = 33
        '
        'lbSksTeori
        '
        Me.lbSksTeori.BackColor = System.Drawing.Color.White
        Me.lbSksTeori.Location = New System.Drawing.Point(195, 550)
        Me.lbSksTeori.Name = "lbSksTeori"
        Me.lbSksTeori.Size = New System.Drawing.Size(86, 29)
        Me.lbSksTeori.TabIndex = 32
        '
        'LbSks
        '
        Me.LbSks.BackColor = System.Drawing.Color.White
        Me.LbSks.Location = New System.Drawing.Point(195, 510)
        Me.LbSks.Name = "LbSks"
        Me.LbSks.Size = New System.Drawing.Size(86, 29)
        Me.LbSks.TabIndex = 31
        '
        'lbNamaMatkul
        '
        Me.lbNamaMatkul.BackColor = System.Drawing.Color.White
        Me.lbNamaMatkul.Location = New System.Drawing.Point(195, 469)
        Me.lbNamaMatkul.Name = "lbNamaMatkul"
        Me.lbNamaMatkul.Size = New System.Drawing.Size(262, 29)
        Me.lbNamaMatkul.TabIndex = 30
        '
        'lbKodeMatkul
        '
        Me.lbKodeMatkul.BackColor = System.Drawing.Color.White
        Me.lbKodeMatkul.Location = New System.Drawing.Point(195, 429)
        Me.lbKodeMatkul.Name = "lbKodeMatkul"
        Me.lbKodeMatkul.Size = New System.Drawing.Size(112, 29)
        Me.lbKodeMatkul.TabIndex = 29
        '
        'lbNamaDosen
        '
        Me.lbNamaDosen.BackColor = System.Drawing.Color.White
        Me.lbNamaDosen.Location = New System.Drawing.Point(195, 388)
        Me.lbNamaDosen.Name = "lbNamaDosen"
        Me.lbNamaDosen.Size = New System.Drawing.Size(262, 29)
        Me.lbNamaDosen.TabIndex = 28
        '
        'lbNidn
        '
        Me.lbNidn.BackColor = System.Drawing.Color.White
        Me.lbNidn.Location = New System.Drawing.Point(195, 343)
        Me.lbNidn.Name = "lbNidn"
        Me.lbNidn.Size = New System.Drawing.Size(112, 29)
        Me.lbNidn.TabIndex = 27
        '
        'lbNikDosen
        '
        Me.lbNikDosen.BackColor = System.Drawing.Color.White
        Me.lbNikDosen.Location = New System.Drawing.Point(195, 297)
        Me.lbNikDosen.Name = "lbNikDosen"
        Me.lbNikDosen.Size = New System.Drawing.Size(112, 29)
        Me.lbNikDosen.TabIndex = 26
        '
        'BtnCari
        '
        Me.BtnCari.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnCari.ForeColor = System.Drawing.Color.White
        Me.BtnCari.Location = New System.Drawing.Point(335, 115)
        Me.BtnCari.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCari.Name = "BtnCari"
        Me.BtnCari.Size = New System.Drawing.Size(84, 36)
        Me.BtnCari.TabIndex = 25
        Me.BtnCari.Text = "Cari"
        Me.BtnCari.UseVisualStyleBackColor = False
        '
        'TxtJamAwal
        '
        Me.TxtJamAwal.Location = New System.Drawing.Point(195, 228)
        Me.TxtJamAwal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtJamAwal.Name = "TxtJamAwal"
        Me.TxtJamAwal.Size = New System.Drawing.Size(85, 26)
        Me.TxtJamAwal.TabIndex = 24
        '
        'TxtJamAkhir
        '
        Me.TxtJamAkhir.Location = New System.Drawing.Point(195, 262)
        Me.TxtJamAkhir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtJamAkhir.Name = "TxtJamAkhir"
        Me.TxtJamAkhir.Size = New System.Drawing.Size(85, 26)
        Me.TxtJamAkhir.TabIndex = 23
        '
        'TxtKdPengampu
        '
        Me.TxtKdPengampu.Location = New System.Drawing.Point(195, 120)
        Me.TxtKdPengampu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtKdPengampu.Name = "TxtKdPengampu"
        Me.TxtKdPengampu.Size = New System.Drawing.Size(132, 26)
        Me.TxtKdPengampu.TabIndex = 22
        '
        'CbNamaHari
        '
        Me.CbNamaHari.FormattingEnabled = True
        Me.CbNamaHari.Location = New System.Drawing.Point(195, 190)
        Me.CbNamaHari.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbNamaHari.Name = "CbNamaHari"
        Me.CbNamaHari.Size = New System.Drawing.Size(112, 28)
        Me.CbNamaHari.TabIndex = 21
        '
        'CbRuangKelas
        '
        Me.CbRuangKelas.FormattingEnabled = True
        Me.CbRuangKelas.Location = New System.Drawing.Point(195, 154)
        Me.CbRuangKelas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbRuangKelas.Name = "CbRuangKelas"
        Me.CbRuangKelas.Size = New System.Drawing.Size(292, 28)
        Me.CbRuangKelas.TabIndex = 20
        '
        'CbTahunAkademik
        '
        Me.CbTahunAkademik.FormattingEnabled = True
        Me.CbTahunAkademik.Location = New System.Drawing.Point(195, 84)
        Me.CbTahunAkademik.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbTahunAkademik.Name = "CbTahunAkademik"
        Me.CbTahunAkademik.Size = New System.Drawing.Size(160, 28)
        Me.CbTahunAkademik.TabIndex = 19
        '
        'CbNamaSemester
        '
        Me.CbNamaSemester.FormattingEnabled = True
        Me.CbNamaSemester.Location = New System.Drawing.Point(195, 48)
        Me.CbNamaSemester.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbNamaSemester.Name = "CbNamaSemester"
        Me.CbNamaSemester.Size = New System.Drawing.Size(160, 28)
        Me.CbNamaSemester.TabIndex = 18
        '
        'CbNamaProdi
        '
        Me.CbNamaProdi.FormattingEnabled = True
        Me.CbNamaProdi.Location = New System.Drawing.Point(195, 12)
        Me.CbNamaProdi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbNamaProdi.Name = "CbNamaProdi"
        Me.CbNamaProdi.Size = New System.Drawing.Size(450, 28)
        Me.CbNamaProdi.TabIndex = 17
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(14, 866)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 23)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Semester"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(22, 596)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 22)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "SKS Praktek"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(22, 553)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 22)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "SKS Teori"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(22, 513)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 22)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "SKS"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 472)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(123, 22)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Nama Matakuliah"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(22, 432)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 22)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Kode Matkul"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 391)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 22)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Nama Dosen"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 346)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 22)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "NIDN"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(22, 300)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 22)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "NIK Dosen"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 22)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Jam Akhir"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 22)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Jam Awal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 22)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Nama Hari"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 22)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Ruang Kelas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 22)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Kode Pengampu"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 22)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tahun Akademik"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 22)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nama Semester"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Jurusan"
        '
        'FormBioPenjadwalanMatkul
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 803)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FormBioPenjadwalanMatkul"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormBioPenjadwalanMatkul"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbSmester As Label
    Friend WithEvents lbSksPraktek As Label
    Friend WithEvents lbSksTeori As Label
    Friend WithEvents LbSks As Label
    Friend WithEvents lbNamaMatkul As Label
    Friend WithEvents lbKodeMatkul As Label
    Friend WithEvents lbNamaDosen As Label
    Friend WithEvents lbNidn As Label
    Friend WithEvents lbNikDosen As Label
    Friend WithEvents BtnCari As Button
    Friend WithEvents TxtJamAwal As TextBox
    Friend WithEvents TxtJamAkhir As TextBox
    Friend WithEvents TxtKdPengampu As TextBox
    Friend WithEvents CbNamaHari As ComboBox
    Friend WithEvents CbRuangKelas As ComboBox
    Friend WithEvents CbTahunAkademik As ComboBox
    Friend WithEvents CbNamaSemester As ComboBox
    Friend WithEvents CbNamaProdi As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
