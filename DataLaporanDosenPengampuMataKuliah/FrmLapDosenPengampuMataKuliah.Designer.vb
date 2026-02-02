<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLapDosenPengampuMataKuliah
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LbTahunAkademik = New System.Windows.Forms.Label()
        Me.LbNmDsn = New System.Windows.Forms.Label()
        Me.LbNidnDsn = New System.Windows.Forms.Label()
        Me.TextKdDsn = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnCetakDsnPengampu = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbTahunAkademik = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbNmSemester = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbNamaProdi = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnBatal = New System.Windows.Forms.Button()
        Me.BtnCetakTahunAkademik = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer3 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.BtnCetakDsnPengampu)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.BtnBatal)
        Me.Panel1.Controls.Add(Me.BtnCetakTahunAkademik)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1124, 230)
        Me.Panel1.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LbTahunAkademik)
        Me.GroupBox2.Controls.Add(Me.LbNmDsn)
        Me.GroupBox2.Controls.Add(Me.LbNidnDsn)
        Me.GroupBox2.Controls.Add(Me.TextKdDsn)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(599, 106)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'LbTahunAkademik
        '
        Me.LbTahunAkademik.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbTahunAkademik.Location = New System.Drawing.Point(434, 56)
        Me.LbTahunAkademik.Name = "LbTahunAkademik"
        Me.LbTahunAkademik.Size = New System.Drawing.Size(159, 31)
        Me.LbTahunAkademik.TabIndex = 25
        '
        'LbNmDsn
        '
        Me.LbNmDsn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbNmDsn.Location = New System.Drawing.Point(434, 16)
        Me.LbNmDsn.Name = "LbNmDsn"
        Me.LbNmDsn.Size = New System.Drawing.Size(159, 31)
        Me.LbNmDsn.TabIndex = 24
        '
        'LbNidnDsn
        '
        Me.LbNidnDsn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LbNidnDsn.Location = New System.Drawing.Point(143, 57)
        Me.LbNidnDsn.Name = "LbNidnDsn"
        Me.LbNidnDsn.Size = New System.Drawing.Size(157, 31)
        Me.LbNidnDsn.TabIndex = 23
        '
        'TextKdDsn
        '
        Me.TextKdDsn.Location = New System.Drawing.Point(143, 16)
        Me.TextKdDsn.Multiline = True
        Me.TextKdDsn.Name = "TextKdDsn"
        Me.TextKdDsn.Size = New System.Drawing.Size(157, 31)
        Me.TextKdDsn.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(306, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 18)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Tahun Akademik"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(306, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 18)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Nama Dosen"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 18)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "NIDN Dosen"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 18)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Kode Dosen"
        '
        'BtnCetakDsnPengampu
        '
        Me.BtnCetakDsnPengampu.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnCetakDsnPengampu.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCetakDsnPengampu.Location = New System.Drawing.Point(643, 136)
        Me.BtnCetakDsnPengampu.Name = "BtnCetakDsnPengampu"
        Me.BtnCetakDsnPengampu.Size = New System.Drawing.Size(154, 65)
        Me.BtnCetakDsnPengampu.TabIndex = 16
        Me.BtnCetakDsnPengampu.Text = "&CETAK DOSEN PENGAMPU"
        Me.BtnCetakDsnPengampu.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbTahunAkademik)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CmbNmSemester)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CmbNamaProdi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1100, 105)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Data"
        '
        'CmbTahunAkademik
        '
        Me.CmbTahunAkademik.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbTahunAkademik.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbTahunAkademik.FormattingEnabled = True
        Me.CmbTahunAkademik.Location = New System.Drawing.Point(434, 62)
        Me.CmbTahunAkademik.Name = "CmbTahunAkademik"
        Me.CmbTahunAkademik.Size = New System.Drawing.Size(197, 31)
        Me.CmbTahunAkademik.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(306, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 18)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Tahun Akademik"
        '
        'CmbNmSemester
        '
        Me.CmbNmSemester.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbNmSemester.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbNmSemester.FormattingEnabled = True
        Me.CmbNmSemester.Location = New System.Drawing.Point(143, 62)
        Me.CmbNmSemester.Name = "CmbNmSemester"
        Me.CmbNmSemester.Size = New System.Drawing.Size(157, 31)
        Me.CmbNmSemester.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 18)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Nama Semester"
        '
        'CmbNamaProdi
        '
        Me.CmbNamaProdi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbNamaProdi.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbNamaProdi.FormattingEnabled = True
        Me.CmbNamaProdi.Location = New System.Drawing.Point(143, 25)
        Me.CmbNamaProdi.Name = "CmbNamaProdi"
        Me.CmbNamaProdi.Size = New System.Drawing.Size(488, 31)
        Me.CmbNamaProdi.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 18)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Nama Prodi"
        '
        'BtnBatal
        '
        Me.BtnBatal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnBatal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBatal.Location = New System.Drawing.Point(985, 136)
        Me.BtnBatal.Name = "BtnBatal"
        Me.BtnBatal.Size = New System.Drawing.Size(121, 65)
        Me.BtnBatal.TabIndex = 10
        Me.BtnBatal.Text = "&BATAL"
        Me.BtnBatal.UseVisualStyleBackColor = True
        '
        'BtnCetakTahunAkademik
        '
        Me.BtnCetakTahunAkademik.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnCetakTahunAkademik.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCetakTahunAkademik.Location = New System.Drawing.Point(803, 136)
        Me.BtnCetakTahunAkademik.Name = "BtnCetakTahunAkademik"
        Me.BtnCetakTahunAkademik.Size = New System.Drawing.Size(176, 65)
        Me.BtnCetakTahunAkademik.TabIndex = 9
        Me.BtnCetakTahunAkademik.Text = "&CETAK DATA TAHUN AKADEMIK"
        Me.BtnCetakTahunAkademik.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1124, 53)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = ":: CETAK DOSEN PENGAMPU ::"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CrystalReportViewer3
        '
        Me.CrystalReportViewer3.ActiveViewIndex = -1
        Me.CrystalReportViewer3.AutoSize = True
        Me.CrystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer3.Location = New System.Drawing.Point(0, 283)
        Me.CrystalReportViewer3.Name = "CrystalReportViewer3"
        Me.CrystalReportViewer3.ShowGroupTreeButton = False
        Me.CrystalReportViewer3.ShowLogo = False
        Me.CrystalReportViewer3.ShowParameterPanelButton = False
        Me.CrystalReportViewer3.Size = New System.Drawing.Size(1124, 424)
        Me.CrystalReportViewer3.TabIndex = 13
        Me.CrystalReportViewer3.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmLapDosenPengampuMataKuliah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 707)
        Me.Controls.Add(Me.CrystalReportViewer3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmLapDosenPengampuMataKuliah"
        Me.Text = "ForLapDosenPengampuMataKuliah"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnCetakTahunAkademik As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CrystalReportViewer3 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CmbTahunAkademik As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CmbNmSemester As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbNamaProdi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnCetakDsnPengampu As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextKdDsn As TextBox
    Friend WithEvents LbNidnDsn As Label
    Friend WithEvents LbTahunAkademik As Label
    Friend WithEvents LbNmDsn As Label
    Friend WithEvents BtnBatal As Button
End Class
