<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataMataKuliah
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
        Me.TextTeoriMatkul = New System.Windows.Forms.TextBox()
        Me.TextNamaMatkul = New System.Windows.Forms.TextBox()
        Me.TextKodeMatkul = New System.Windows.Forms.TextBox()
        Me.CmbNmJurusanMatkul = New System.Windows.Forms.ComboBox()
        Me.CmbSemesterMatkul = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LbHasilTeoriPraktek = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LbPraktekMatkul = New System.Windows.Forms.Label()
        Me.TextPraktekMatkul = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LbTeoriMatkul = New System.Windows.Forms.Label()
        Me.CmbSksMatkul = New System.Windows.Forms.ComboBox()
        Me.CmbNmSemesterMatkul = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnKeluar = New System.Windows.Forms.Button()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.LbKodeMatkul = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextTeoriMatkul
        '
        Me.TextTeoriMatkul.Location = New System.Drawing.Point(160, 326)
        Me.TextTeoriMatkul.Name = "TextTeoriMatkul"
        Me.TextTeoriMatkul.Size = New System.Drawing.Size(66, 26)
        Me.TextTeoriMatkul.TabIndex = 22
        '
        'TextNamaMatkul
        '
        Me.TextNamaMatkul.Location = New System.Drawing.Point(160, 159)
        Me.TextNamaMatkul.Multiline = True
        Me.TextNamaMatkul.Name = "TextNamaMatkul"
        Me.TextNamaMatkul.Size = New System.Drawing.Size(326, 82)
        Me.TextNamaMatkul.TabIndex = 20
        '
        'TextKodeMatkul
        '
        Me.TextKodeMatkul.Location = New System.Drawing.Point(160, 116)
        Me.TextKodeMatkul.Name = "TextKodeMatkul"
        Me.TextKodeMatkul.Size = New System.Drawing.Size(130, 26)
        Me.TextKodeMatkul.TabIndex = 17
        '
        'CmbNmJurusanMatkul
        '
        Me.CmbNmJurusanMatkul.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbNmJurusanMatkul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNmJurusanMatkul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbNmJurusanMatkul.FormattingEnabled = True
        Me.CmbNmJurusanMatkul.Location = New System.Drawing.Point(160, 33)
        Me.CmbNmJurusanMatkul.Name = "CmbNmJurusanMatkul"
        Me.CmbNmJurusanMatkul.Size = New System.Drawing.Size(221, 27)
        Me.CmbNmJurusanMatkul.TabIndex = 12
        '
        'CmbSemesterMatkul
        '
        Me.CmbSemesterMatkul.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbSemesterMatkul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSemesterMatkul.FormattingEnabled = True
        Me.CmbSemesterMatkul.Location = New System.Drawing.Point(160, 249)
        Me.CmbSemesterMatkul.Name = "CmbSemesterMatkul"
        Me.CmbSemesterMatkul.Size = New System.Drawing.Size(66, 27)
        Me.CmbSemesterMatkul.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Cursor = System.Windows.Forms.Cursors.No
        Me.Label11.Location = New System.Drawing.Point(11, 329)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 19)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Teori Matkul"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 289)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 19)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "SKS"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 168)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 19)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Nama Matkul"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 19)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Kode Matkul"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 252)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 19)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Semester"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(591, 411)
        Me.Panel2.TabIndex = 13
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox3.Controls.Add(Me.LbKodeMatkul)
        Me.GroupBox3.Controls.Add(Me.LbHasilTeoriPraktek)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.LbPraktekMatkul)
        Me.GroupBox3.Controls.Add(Me.TextPraktekMatkul)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.LbTeoriMatkul)
        Me.GroupBox3.Controls.Add(Me.CmbSksMatkul)
        Me.GroupBox3.Controls.Add(Me.CmbNmSemesterMatkul)
        Me.GroupBox3.Controls.Add(Me.TextTeoriMatkul)
        Me.GroupBox3.Controls.Add(Me.TextNamaMatkul)
        Me.GroupBox3.Controls.Add(Me.TextKodeMatkul)
        Me.GroupBox3.Controls.Add(Me.CmbNmJurusanMatkul)
        Me.GroupBox3.Controls.Add(Me.CmbSemesterMatkul)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(567, 378)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'LbHasilTeoriPraktek
        '
        Me.LbHasilTeoriPraktek.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbHasilTeoriPraktek.Location = New System.Drawing.Point(513, 323)
        Me.LbHasilTeoriPraktek.Name = "LbHasilTeoriPraktek"
        Me.LbHasilTeoriPraktek.Size = New System.Drawing.Size(43, 26)
        Me.LbHasilTeoriPraktek.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 19)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Nama Semester"
        '
        'LbPraktekMatkul
        '
        Me.LbPraktekMatkul.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbPraktekMatkul.Location = New System.Drawing.Point(464, 323)
        Me.LbPraktekMatkul.Name = "LbPraktekMatkul"
        Me.LbPraktekMatkul.Size = New System.Drawing.Size(43, 26)
        Me.LbPraktekMatkul.TabIndex = 26
        '
        'TextPraktekMatkul
        '
        Me.TextPraktekMatkul.Location = New System.Drawing.Point(411, 323)
        Me.TextPraktekMatkul.Name = "TextPraktekMatkul"
        Me.TextPraktekMatkul.Size = New System.Drawing.Size(47, 26)
        Me.TextPraktekMatkul.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.No
        Me.Label3.Location = New System.Drawing.Point(284, 329)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 19)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Praktek Matkul"
        '
        'LbTeoriMatkul
        '
        Me.LbTeoriMatkul.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbTeoriMatkul.Location = New System.Drawing.Point(232, 326)
        Me.LbTeoriMatkul.Name = "LbTeoriMatkul"
        Me.LbTeoriMatkul.Size = New System.Drawing.Size(43, 26)
        Me.LbTeoriMatkul.TabIndex = 15
        '
        'CmbSksMatkul
        '
        Me.CmbSksMatkul.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbSksMatkul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSksMatkul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSksMatkul.FormattingEnabled = True
        Me.CmbSksMatkul.Location = New System.Drawing.Point(160, 286)
        Me.CmbSksMatkul.Name = "CmbSksMatkul"
        Me.CmbSksMatkul.Size = New System.Drawing.Size(66, 27)
        Me.CmbSksMatkul.TabIndex = 24
        '
        'CmbNmSemesterMatkul
        '
        Me.CmbNmSemesterMatkul.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbNmSemesterMatkul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNmSemesterMatkul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbNmSemesterMatkul.FormattingEnabled = True
        Me.CmbNmSemesterMatkul.Location = New System.Drawing.Point(160, 74)
        Me.CmbNmSemesterMatkul.Name = "CmbNmSemesterMatkul"
        Me.CmbNmSemesterMatkul.Size = New System.Drawing.Size(221, 27)
        Me.CmbNmSemesterMatkul.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 19)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Nama Jurusan"
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
        Me.Label1.Font = New System.Drawing.Font("Georgia", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(510, 32)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":: DATA MASTER MATAKULIAH ::"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 476)
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
        'LbKodeMatkul
        '
        Me.LbKodeMatkul.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbKodeMatkul.Location = New System.Drawing.Point(296, 115)
        Me.LbKodeMatkul.Name = "LbKodeMatkul"
        Me.LbKodeMatkul.Size = New System.Drawing.Size(43, 26)
        Me.LbKodeMatkul.TabIndex = 30
        '
        'FrmDataMataKuliah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 603)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "FrmDataMataKuliah"
        Me.Text = "FrmDataMataKuliah"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextTeoriMatkul As TextBox
    Friend WithEvents TextNamaMatkul As TextBox
    Friend WithEvents TextKodeMatkul As TextBox
    Friend WithEvents CmbNmJurusanMatkul As ComboBox
    Friend WithEvents CmbSemesterMatkul As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents CmbNmSemesterMatkul As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents CmbSksMatkul As ComboBox
    Friend WithEvents LbTeoriMatkul As Label
    Friend WithEvents LbPraktekMatkul As Label
    Friend WithEvents TextPraktekMatkul As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LbHasilTeoriPraktek As Label
    Friend WithEvents LbKodeMatkul As Label
End Class
