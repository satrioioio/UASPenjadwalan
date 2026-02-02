<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataDosenPengampu
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
        Me.TextNoIdentitas = New System.Windows.Forms.TextBox()
        Me.LbKodePengampu = New System.Windows.Forms.Label()
        Me.CmbProdi = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextTahunAkademik = New System.Windows.Forms.TextBox()
        Me.CmbKelas = New System.Windows.Forms.ComboBox()
        Me.CmbSemester = New System.Windows.Forms.ComboBox()
        Me.LbSemester = New System.Windows.Forms.Label()
        Me.LbSksPraktek = New System.Windows.Forms.Label()
        Me.LbSksTeori = New System.Windows.Forms.Label()
        Me.LbSks = New System.Windows.Forms.Label()
        Me.LbNamaMatkul = New System.Windows.Forms.Label()
        Me.BtnCariKodeMatkul = New System.Windows.Forms.Button()
        Me.TextKodeMatkul = New System.Windows.Forms.TextBox()
        Me.LbNamaDosen = New System.Windows.Forms.Label()
        Me.LbNidn = New System.Windows.Forms.Label()
        Me.BtnCariNoidentitas = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnKeluar = New System.Windows.Forms.Button()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextNoIdentitas
        '
        Me.TextNoIdentitas.Location = New System.Drawing.Point(181, 92)
        Me.TextNoIdentitas.Name = "TextNoIdentitas"
        Me.TextNoIdentitas.Size = New System.Drawing.Size(92, 26)
        Me.TextNoIdentitas.TabIndex = 17
        '
        'LbKodePengampu
        '
        Me.LbKodePengampu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbKodePengampu.Location = New System.Drawing.Point(181, 20)
        Me.LbKodePengampu.Name = "LbKodePengampu"
        Me.LbKodePengampu.Size = New System.Drawing.Size(93, 26)
        Me.LbKodePengampu.TabIndex = 14
        '
        'CmbProdi
        '
        Me.CmbProdi.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.CmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbProdi.FormattingEnabled = True
        Me.CmbProdi.Location = New System.Drawing.Point(181, 55)
        Me.CmbProdi.Name = "CmbProdi"
        Me.CmbProdi.Size = New System.Drawing.Size(221, 27)
        Me.CmbProdi.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Cursor = System.Windows.Forms.Cursors.No
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 329)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 18)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "SKS Praktek"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(21, 295)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 18)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "SKS Teori"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(21, 129)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 18)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "NIDN"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(21, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 18)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Nomor Identitas"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(21, 195)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 18)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Kode MataKuliah"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 18)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Prodi"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(21, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(123, 18)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "kode Pengampu"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(591, 505)
        Me.Panel2.TabIndex = 13
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox3.Controls.Add(Me.TextTahunAkademik)
        Me.GroupBox3.Controls.Add(Me.CmbKelas)
        Me.GroupBox3.Controls.Add(Me.CmbSemester)
        Me.GroupBox3.Controls.Add(Me.LbSemester)
        Me.GroupBox3.Controls.Add(Me.LbSksPraktek)
        Me.GroupBox3.Controls.Add(Me.LbSksTeori)
        Me.GroupBox3.Controls.Add(Me.LbSks)
        Me.GroupBox3.Controls.Add(Me.LbNamaMatkul)
        Me.GroupBox3.Controls.Add(Me.BtnCariKodeMatkul)
        Me.GroupBox3.Controls.Add(Me.TextKodeMatkul)
        Me.GroupBox3.Controls.Add(Me.LbNamaDosen)
        Me.GroupBox3.Controls.Add(Me.LbNidn)
        Me.GroupBox3.Controls.Add(Me.BtnCariNoidentitas)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.TextNoIdentitas)
        Me.GroupBox3.Controls.Add(Me.LbKodePengampu)
        Me.GroupBox3.Controls.Add(Me.CmbProdi)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(585, 493)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'TextTahunAkademik
        '
        Me.TextTahunAkademik.Location = New System.Drawing.Point(181, 459)
        Me.TextTahunAkademik.Name = "TextTahunAkademik"
        Me.TextTahunAkademik.Size = New System.Drawing.Size(92, 26)
        Me.TextTahunAkademik.TabIndex = 42
        '
        'CmbKelas
        '
        Me.CmbKelas.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.CmbKelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbKelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbKelas.FormattingEnabled = True
        Me.CmbKelas.Location = New System.Drawing.Point(181, 424)
        Me.CmbKelas.Name = "CmbKelas"
        Me.CmbKelas.Size = New System.Drawing.Size(156, 27)
        Me.CmbKelas.TabIndex = 41
        '
        'CmbSemester
        '
        Me.CmbSemester.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.CmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSemester.FormattingEnabled = True
        Me.CmbSemester.Location = New System.Drawing.Point(181, 389)
        Me.CmbSemester.Name = "CmbSemester"
        Me.CmbSemester.Size = New System.Drawing.Size(156, 27)
        Me.CmbSemester.TabIndex = 40
        '
        'LbSemester
        '
        Me.LbSemester.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbSemester.Location = New System.Drawing.Point(181, 357)
        Me.LbSemester.Name = "LbSemester"
        Me.LbSemester.Size = New System.Drawing.Size(45, 26)
        Me.LbSemester.TabIndex = 39
        '
        'LbSksPraktek
        '
        Me.LbSksPraktek.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbSksPraktek.Location = New System.Drawing.Point(181, 325)
        Me.LbSksPraktek.Name = "LbSksPraktek"
        Me.LbSksPraktek.Size = New System.Drawing.Size(45, 26)
        Me.LbSksPraktek.TabIndex = 38
        '
        'LbSksTeori
        '
        Me.LbSksTeori.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbSksTeori.Location = New System.Drawing.Point(181, 291)
        Me.LbSksTeori.Name = "LbSksTeori"
        Me.LbSksTeori.Size = New System.Drawing.Size(45, 26)
        Me.LbSksTeori.TabIndex = 37
        '
        'LbSks
        '
        Me.LbSks.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbSks.Location = New System.Drawing.Point(181, 257)
        Me.LbSks.Name = "LbSks"
        Me.LbSks.Size = New System.Drawing.Size(45, 26)
        Me.LbSks.TabIndex = 36
        '
        'LbNamaMatkul
        '
        Me.LbNamaMatkul.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbNamaMatkul.Location = New System.Drawing.Point(181, 225)
        Me.LbNamaMatkul.Name = "LbNamaMatkul"
        Me.LbNamaMatkul.Size = New System.Drawing.Size(222, 26)
        Me.LbNamaMatkul.TabIndex = 35
        '
        'BtnCariKodeMatkul
        '
        Me.BtnCariKodeMatkul.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtnCariKodeMatkul.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnCariKodeMatkul.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCariKodeMatkul.Location = New System.Drawing.Point(279, 191)
        Me.BtnCariKodeMatkul.Name = "BtnCariKodeMatkul"
        Me.BtnCariKodeMatkul.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnCariKodeMatkul.Size = New System.Drawing.Size(58, 29)
        Me.BtnCariKodeMatkul.TabIndex = 34
        Me.BtnCariKodeMatkul.Text = "Cari"
        Me.BtnCariKodeMatkul.UseVisualStyleBackColor = False
        '
        'TextKodeMatkul
        '
        Me.TextKodeMatkul.Location = New System.Drawing.Point(181, 191)
        Me.TextKodeMatkul.Name = "TextKodeMatkul"
        Me.TextKodeMatkul.Size = New System.Drawing.Size(92, 26)
        Me.TextKodeMatkul.TabIndex = 33
        '
        'LbNamaDosen
        '
        Me.LbNamaDosen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbNamaDosen.Location = New System.Drawing.Point(181, 158)
        Me.LbNamaDosen.Name = "LbNamaDosen"
        Me.LbNamaDosen.Size = New System.Drawing.Size(222, 26)
        Me.LbNamaDosen.TabIndex = 32
        '
        'LbNidn
        '
        Me.LbNidn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbNidn.Location = New System.Drawing.Point(181, 125)
        Me.LbNidn.Name = "LbNidn"
        Me.LbNidn.Size = New System.Drawing.Size(93, 26)
        Me.LbNidn.TabIndex = 31
        '
        'BtnCariNoidentitas
        '
        Me.BtnCariNoidentitas.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BtnCariNoidentitas.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnCariNoidentitas.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCariNoidentitas.Location = New System.Drawing.Point(280, 91)
        Me.BtnCariNoidentitas.Name = "BtnCariNoidentitas"
        Me.BtnCariNoidentitas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnCariNoidentitas.Size = New System.Drawing.Size(58, 29)
        Me.BtnCariNoidentitas.TabIndex = 30
        Me.BtnCariNoidentitas.Text = "Cari"
        Me.BtnCariNoidentitas.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.No
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 463)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 18)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Tahun Akademik"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 428)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 18)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Kelas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 361)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 18)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "SMTR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 18)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "SKS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 393)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 18)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Semester"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 229)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 18)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Nama MataKuliah"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 162)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 18)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Nama Dosen"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(591, 65)
        Me.Panel1.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(440, 29)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":: BIODATA DOSEN PENGAMPU ::"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 570)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(591, 127)
        Me.Panel3.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.BtnKeluar)
        Me.GroupBox2.Controls.Add(Me.BtnHapus)
        Me.GroupBox2.Controls.Add(Me.BtnSimpan)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(591, 127)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'BtnKeluar
        '
        Me.BtnKeluar.Location = New System.Drawing.Point(405, 31)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.Size = New System.Drawing.Size(149, 63)
        Me.BtnKeluar.TabIndex = 2
        Me.BtnKeluar.Text = "&KELUAR"
        Me.BtnKeluar.UseVisualStyleBackColor = True
        '
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(218, 31)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(161, 63)
        Me.BtnHapus.TabIndex = 1
        Me.BtnHapus.Text = "&HAPUS"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnSimpan.Location = New System.Drawing.Point(37, 31)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnSimpan.Size = New System.Drawing.Size(155, 63)
        Me.BtnSimpan.TabIndex = 0
        Me.BtnSimpan.Text = "&SIMPAN"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'FrmDataDosenPengampu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 697)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "FrmDataDosenPengampu"
        Me.Text = "FrmDataDosenPengampu"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextNoIdentitas As TextBox
    Friend WithEvents LbKodePengampu As Label
    Friend WithEvents CmbProdi As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnCariNoidentitas As Button
    Friend WithEvents LbNidn As Label
    Friend WithEvents LbNamaDosen As Label
    Friend WithEvents BtnCariKodeMatkul As Button
    Friend WithEvents TextKodeMatkul As TextBox
    Friend WithEvents LbNamaMatkul As Label
    Friend WithEvents LbSks As Label
    Friend WithEvents LbSksTeori As Label
    Friend WithEvents LbSemester As Label
    Friend WithEvents LbSksPraktek As Label
    Friend WithEvents CmbKelas As ComboBox
    Friend WithEvents CmbSemester As ComboBox
    Friend WithEvents TextTahunAkademik As TextBox
End Class
