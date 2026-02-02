<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMataKuliah
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtCari = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CbAngkaSemester = New System.Windows.Forms.ComboBox()
        Me.CbKatSemester = New System.Windows.Forms.ComboBox()
        Me.BtnCari = New System.Windows.Forms.Button()
        Me.BtnKeluar = New System.Windows.Forms.Button()
        Me.BtnTambahData = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbNamaProdi = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridMatkul = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxEntries = New System.Windows.Forms.ComboBox()
        Me.LbHasilBagiHalaman = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridMatkul, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.TxtCari)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CbAngkaSemester)
        Me.Panel1.Controls.Add(Me.CbKatSemester)
        Me.Panel1.Controls.Add(Me.BtnCari)
        Me.Panel1.Controls.Add(Me.BtnKeluar)
        Me.Panel1.Controls.Add(Me.BtnTambahData)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CmbNamaProdi)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1103, 130)
        Me.Panel1.TabIndex = 28
        '
        'TxtCari
        '
        Me.TxtCari.Location = New System.Drawing.Point(418, 73)
        Me.TxtCari.Name = "TxtCari"
        Me.TxtCari.Size = New System.Drawing.Size(201, 26)
        Me.TxtCari.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(366, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 23)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Cari"
        '
        'CbAngkaSemester
        '
        Me.CbAngkaSemester.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CbAngkaSemester.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CbAngkaSemester.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbAngkaSemester.FormattingEnabled = True
        Me.CbAngkaSemester.Location = New System.Drawing.Point(257, 70)
        Me.CbAngkaSemester.Name = "CbAngkaSemester"
        Me.CbAngkaSemester.Size = New System.Drawing.Size(85, 31)
        Me.CbAngkaSemester.TabIndex = 8
        '
        'CbKatSemester
        '
        Me.CbKatSemester.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CbKatSemester.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CbKatSemester.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbKatSemester.FormattingEnabled = True
        Me.CbKatSemester.Location = New System.Drawing.Point(117, 70)
        Me.CbKatSemester.Name = "CbKatSemester"
        Me.CbKatSemester.Size = New System.Drawing.Size(134, 31)
        Me.CbKatSemester.TabIndex = 7
        '
        'BtnCari
        '
        Me.BtnCari.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnCari.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCari.Location = New System.Drawing.Point(625, 69)
        Me.BtnCari.Name = "BtnCari"
        Me.BtnCari.Size = New System.Drawing.Size(77, 34)
        Me.BtnCari.TabIndex = 6
        Me.BtnCari.Text = "CARI"
        Me.BtnCari.UseVisualStyleBackColor = True
        '
        'BtnKeluar
        '
        Me.BtnKeluar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnKeluar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKeluar.Location = New System.Drawing.Point(957, 43)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.Size = New System.Drawing.Size(123, 45)
        Me.BtnKeluar.TabIndex = 5
        Me.BtnKeluar.Text = "&KELUAR"
        Me.BtnKeluar.UseVisualStyleBackColor = True
        '
        'BtnTambahData
        '
        Me.BtnTambahData.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnTambahData.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTambahData.Location = New System.Drawing.Point(757, 43)
        Me.BtnTambahData.Name = "BtnTambahData"
        Me.BtnTambahData.Size = New System.Drawing.Size(181, 45)
        Me.BtnTambahData.TabIndex = 4
        Me.BtnTambahData.Text = "TAMBAH DATA"
        Me.BtnTambahData.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Semester"
        '
        'CmbNamaProdi
        '
        Me.CmbNamaProdi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbNamaProdi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbNamaProdi.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbNamaProdi.FormattingEnabled = True
        Me.CmbNamaProdi.Location = New System.Drawing.Point(153, 20)
        Me.CmbNamaProdi.Name = "CmbNamaProdi"
        Me.CmbNamaProdi.Size = New System.Drawing.Size(549, 31)
        Me.CmbNamaProdi.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nama Jurusan"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel2.Controls.Add(Me.DataGridMatkul)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 180)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1103, 463)
        Me.Panel2.TabIndex = 30
        '
        'DataGridMatkul
        '
        Me.DataGridMatkul.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridMatkul.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridMatkul.Location = New System.Drawing.Point(0, 0)
        Me.DataGridMatkul.Name = "DataGridMatkul"
        Me.DataGridMatkul.RowHeadersWidth = 62
        Me.DataGridMatkul.RowTemplate.Height = 28
        Me.DataGridMatkul.Size = New System.Drawing.Size(1103, 463)
        Me.DataGridMatkul.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(286, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 20)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Tampil Data:"
        '
        'ComboBoxEntries
        '
        Me.ComboBoxEntries.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ComboBoxEntries.FormattingEnabled = True
        Me.ComboBoxEntries.Location = New System.Drawing.Point(392, 183)
        Me.ComboBoxEntries.Name = "ComboBoxEntries"
        Me.ComboBoxEntries.Size = New System.Drawing.Size(55, 28)
        Me.ComboBoxEntries.TabIndex = 32
        Me.ComboBoxEntries.Text = "10"
        '
        'LbHasilBagiHalaman
        '
        Me.LbHasilBagiHalaman.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LbHasilBagiHalaman.Location = New System.Drawing.Point(127, 600)
        Me.LbHasilBagiHalaman.Name = "LbHasilBagiHalaman"
        Me.LbHasilBagiHalaman.Size = New System.Drawing.Size(92, 20)
        Me.LbHasilBagiHalaman.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1103, 50)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = ":: DATA MATA KULIAH ::"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMataKuliah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1103, 643)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBoxEntries)
        Me.Controls.Add(Me.LbHasilBagiHalaman)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmMataKuliah"
        Me.Text = "FrmMataKuliah"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridMatkul, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnCari As Button
    Friend WithEvents BtnKeluar As Button
    Friend WithEvents BtnTambahData As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbNamaProdi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGridMatkul As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBoxEntries As ComboBox
    Friend WithEvents LbHasilBagiHalaman As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CbAngkaSemester As ComboBox
    Friend WithEvents CbKatSemester As ComboBox
    Friend WithEvents TxtCari As TextBox
    Friend WithEvents Label4 As Label
End Class
