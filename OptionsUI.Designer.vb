<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsUI
    Inherits JHSoftware.SimpleDNS.Plugin.OptionsUI

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label
    Me.numListenPort = New System.Windows.Forms.NumericUpDown
    Me.Label2 = New System.Windows.Forms.Label
    Me.ddListenIP = New System.Windows.Forms.ComboBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.numConnPort = New System.Windows.Forms.NumericUpDown
    Me.txtConnHost = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.numMaxConn = New System.Windows.Forms.NumericUpDown
    Me.chkTimeOut = New System.Windows.Forms.CheckBox
    Me.ttlTimeOut = New ctlTTL
    CType(Me.numListenPort, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numConnPort, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numMaxConn, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(-3, 34)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(98, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Listen on TCP port:"
    '
    'numListenPort
    '
    Me.numListenPort.Location = New System.Drawing.Point(109, 32)
    Me.numListenPort.Margin = New System.Windows.Forms.Padding(3, 3, 3, 13)
    Me.numListenPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
    Me.numListenPort.Name = "numListenPort"
    Me.numListenPort.Size = New System.Drawing.Size(62, 20)
    Me.numListenPort.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(-3, 3)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(106, 13)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "Listen on IP address:"
    '
    'ddListenIP
    '
    Me.ddListenIP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ddListenIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ddListenIP.FormattingEnabled = True
    Me.ddListenIP.Location = New System.Drawing.Point(109, 0)
    Me.ddListenIP.Margin = New System.Windows.Forms.Padding(3, 3, 3, 8)
    Me.ddListenIP.Name = "ddListenIP"
    Me.ddListenIP.Size = New System.Drawing.Size(245, 21)
    Me.ddListenIP.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(-3, 71)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(85, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Connect to host:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(-3, 101)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(107, 13)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "Connect to TCP port:"
    '
    'numConnPort
    '
    Me.numConnPort.Location = New System.Drawing.Point(109, 99)
    Me.numConnPort.Margin = New System.Windows.Forms.Padding(3, 3, 3, 13)
    Me.numConnPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
    Me.numConnPort.Name = "numConnPort"
    Me.numConnPort.Size = New System.Drawing.Size(62, 20)
    Me.numConnPort.TabIndex = 7
    '
    'txtConnHost
    '
    Me.txtConnHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtConnHost.Location = New System.Drawing.Point(109, 68)
    Me.txtConnHost.Margin = New System.Windows.Forms.Padding(3, 3, 3, 8)
    Me.txtConnHost.Name = "txtConnHost"
    Me.txtConnHost.Size = New System.Drawing.Size(245, 20)
    Me.txtConnHost.TabIndex = 5
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(-3, 137)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(94, 13)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Max. connections:"
    '
    'numMaxConn
    '
    Me.numMaxConn.Location = New System.Drawing.Point(109, 135)
    Me.numMaxConn.Margin = New System.Windows.Forms.Padding(3, 3, 3, 13)
    Me.numMaxConn.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
    Me.numMaxConn.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.numMaxConn.Name = "numMaxConn"
    Me.numMaxConn.Size = New System.Drawing.Size(62, 20)
    Me.numMaxConn.TabIndex = 9
    Me.numMaxConn.Value = New Decimal(New Integer() {25, 0, 0, 0})
    '
    'chkTimeOut
    '
    Me.chkTimeOut.AutoSize = True
    Me.chkTimeOut.Location = New System.Drawing.Point(0, 172)
    Me.chkTimeOut.Name = "chkTimeOut"
    Me.chkTimeOut.Size = New System.Drawing.Size(86, 17)
    Me.chkTimeOut.TabIndex = 10
    Me.chkTimeOut.Text = "Idle time-out:"
    Me.chkTimeOut.UseVisualStyleBackColor = True
    '
    'ttlTimeOut
    '
    Me.ttlTimeOut.AutoSize = True
    Me.ttlTimeOut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.ttlTimeOut.BackColor = System.Drawing.Color.Transparent
    Me.ttlTimeOut.Enabled = False
    Me.ttlTimeOut.Location = New System.Drawing.Point(109, 171)
    Me.ttlTimeOut.Name = "ttlTimeOut"
    Me.ttlTimeOut.ReadOnly = False
    Me.ttlTimeOut.Size = New System.Drawing.Size(156, 21)
    Me.ttlTimeOut.TabIndex = 11
    Me.ttlTimeOut.Value = 300
    '
    'OptionsUI
    '
    Me.Controls.Add(Me.chkTimeOut)
    Me.Controls.Add(Me.ttlTimeOut)
    Me.Controls.Add(Me.numMaxConn)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.txtConnHost)
    Me.Controls.Add(Me.numConnPort)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.ddListenIP)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.numListenPort)
    Me.Controls.Add(Me.Label1)
    Me.Name = "OptionsUI"
    Me.Size = New System.Drawing.Size(354, 200)
    CType(Me.numListenPort, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numConnPort, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numMaxConn, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents numListenPort As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ddListenIP As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents numConnPort As System.Windows.Forms.NumericUpDown
  Friend WithEvents txtConnHost As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents numMaxConn As System.Windows.Forms.NumericUpDown
  Friend WithEvents ttlTimeOut As ctlTTL
  Friend WithEvents chkTimeOut As System.Windows.Forms.CheckBox

End Class
