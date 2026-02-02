<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataDosen
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
        Me.BtnKeluar = New System.Windows.Forms.Button()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextEmailDsn = New System.Windows.Forms.TextBox()
        Me.TextNoTelpDsn = New System.Windows.Forms.TextBox()
        Me.TextNamaDsn = New System.Windows.Forms.TextBox()
        Me.LbkdProdiDsn = New System.Windows.Forms.Label()
        Me.TextNidnDsn = New System.Windows.Forms.TextBox()
        Me.LbNikDsn = New System.Windows.Forms.Label()
        Me.CmbProdiDsn = New System.Windows.Forms.ComboBox()
        Me.CmbJkDsn = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
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
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(218, 31)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(161, 63)
        Me.BtnHapus.TabIndex = 1
        Me.BtnHapus.Text = "&HAPUS"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 476)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(591, 127)
        Me.Panel3.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Georgia", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(151, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 32)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":: BIODATA DOSEN ::"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(591, 65)
        Me.Panel1.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(591, 411)
        Me.Panel2.TabIndex = 10
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox3.Controls.Add(Me.TextEmailDsn)
        Me.GroupBox3.Controls.Add(Me.TextNoTelpDsn)
        Me.GroupBox3.Controls.Add(Me.TextNamaDsn)
        Me.GroupBox3.Controls.Add(Me.LbkdProdiDsn)
        Me.GroupBox3.Controls.Add(Me.TextNidnDsn)
        Me.GroupBox3.Controls.Add(Me.LbNikDsn)
        Me.GroupBox3.Controls.Add(Me.CmbProdiDsn)
        Me.GroupBox3.Controls.Add(Me.CmbJkDsn)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(567, 378)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'TextEmailDsn
        '
        Me.TextEmailDsn.Location = New System.Drawing.Point(185, 317)
        Me.TextEmailDsn.Name = "TextEmailDsn"
        Me.TextEmailDsn.Size = New System.Drawing.Size(227, 26)
        Me.TextEmailDsn.TabIndex = 22
        '
        'TextNoTelpDsn
        '
        Me.TextNoTelpDsn.Location = New System.Drawing.Point(185, 275)
        Me.TextNoTelpDsn.Name = "TextNoTelpDsn"
        Me.TextNoTelpDsn.Size = New System.Drawing.Size(227, 26)
        Me.TextNoTelpDsn.TabIndex = 21
        '
        'TextNamaDsn
        '
        Me.TextNamaDsn.Location = New System.Drawing.Point(185, 165)
        Me.TextNamaDsn.Name = "TextNamaDsn"
        Me.TextNamaDsn.Size = New System.Drawing.Size(227, 26)
        Me.TextNamaDsn.TabIndex = 20
        '
        'LbkdProdiDsn
        '
        Me.LbkdProdiDsn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbkdProdiDsn.Location = New System.Drawing.Point(185, 71)
        Me.LbkdProdiDsn.Name = "LbkdProdiDsn"
        Me.LbkdProdiDsn.Size = New System.Drawing.Size(93, 26)
        Me.LbkdProdiDsn.TabIndex = 19
        '
        'TextNidnDsn
        '
        Me.TextNidnDsn.Location = New System.Drawing.Point(185, 116)
        Me.TextNidnDsn.Name = "TextNidnDsn"
        Me.TextNidnDsn.Size = New System.Drawing.Size(130, 26)
        Me.TextNidnDsn.TabIndex = 17
        '
        'LbNikDsn
        '
        Me.LbNikDsn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbNikDsn.Location = New System.Drawing.Point(185, 32)
        Me.LbNikDsn.Name = "LbNikDsn"
        Me.LbNikDsn.Size = New System.Drawing.Size(93, 26)
        Me.LbNikDsn.TabIndex = 14
        '
        'CmbProdiDsn
        '
        Me.CmbProdiDsn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProdiDsn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbProdiDsn.FormattingEnabled = True
        Me.CmbProdiDsn.Location = New System.Drawing.Point(282, 70)
        Me.CmbProdiDsn.Name = "CmbProdiDsn"
        Me.CmbProdiDsn.Size = New System.Drawing.Size(221, 27)
        Me.CmbProdiDsn.TabIndex = 12
        '
        'CmbJkDsn
        '
        Me.CmbJkDsn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbJkDsn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbJkDsn.FormattingEnabled = True
        Me.CmbJkDsn.Location = New System.Drawing.Point(185, 218)
        Me.CmbJkDsn.Name = "CmbJkDsn"
        Me.CmbJkDsn.Size = New System.Drawing.Size(130, 27)
        Me.CmbJkDsn.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Cursor = System.Windows.Forms.Cursors.No
        Me.Label11.Location = New System.Drawing.Point(21, 320)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 19)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Email"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 278)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 19)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "No. Telpon"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(21, 168)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 19)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Nama Dosen"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 19)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "NIDN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 222)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 19)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Jenis Kelamin"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(21, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 19)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Prodi"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 19)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "NIK"
        '
        'FrmDataDosen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 603)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "FrmDataDosen"
        Me.Text = "FrmMahasiswa"
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnKeluar As Button
    Friend WithEvents BtnSimpan As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnHapus As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents LbkdProdiDsn As Label
    Friend WithEvents TextNidnDsn As TextBox
    Friend WithEvents LbNikDsn As Label
    Friend WithEvents CmbProdiDsn As ComboBox
    Friend WithEvents CmbJkDsn As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TextEmailDsn As TextBox
    Friend WithEvents TextNoTelpDsn As TextBox
    Friend WithEvents TextNamaDsn As TextBox
End Class
