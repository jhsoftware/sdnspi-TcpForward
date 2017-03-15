<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewUI
    Inherits JHSoftware.SimpleDNS.Plugin.ViewUI

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
    Me.Label2 = New System.Windows.Forms.Label
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.lblCurConn = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.lblTotConn = New System.Windows.Forms.Label
    Me.lblBytesIn = New System.Windows.Forms.Label
    Me.lblBytesOut = New System.Windows.Forms.Label
    Me.TableLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(5, 5)
    Me.Label1.Margin = New System.Windows.Forms.Padding(5)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(128, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Current connections:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(5, 31)
    Me.Label2.Margin = New System.Windows.Forms.Padding(5)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(117, 16)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Total connections:"
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.AutoSize = True
    Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.lblCurConn, 1, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.lblTotConn, 1, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.lblBytesIn, 1, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.lblBytesOut, 1, 3)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 5)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 4
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(237, 104)
    Me.TableLayoutPanel1.TabIndex = 2
    '
    'lblCurConn
    '
    Me.lblCurConn.AutoSize = True
    Me.lblCurConn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCurConn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.lblCurConn.Location = New System.Drawing.Point(217, 5)
    Me.lblCurConn.Margin = New System.Windows.Forms.Padding(5)
    Me.lblCurConn.Name = "lblCurConn"
    Me.lblCurConn.Size = New System.Drawing.Size(15, 16)
    Me.lblCurConn.TabIndex = 2
    Me.lblCurConn.Text = "0"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(5, 57)
    Me.Label4.Margin = New System.Windows.Forms.Padding(5)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(202, 16)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "Bytes transferred - clients to host:"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(5, 83)
    Me.Label5.Margin = New System.Windows.Forms.Padding(5)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(202, 16)
    Me.Label5.TabIndex = 4
    Me.Label5.Text = "Bytes transferred - host to clients:"
    '
    'lblTotConn
    '
    Me.lblTotConn.AutoSize = True
    Me.lblTotConn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblTotConn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.lblTotConn.Location = New System.Drawing.Point(217, 31)
    Me.lblTotConn.Margin = New System.Windows.Forms.Padding(5)
    Me.lblTotConn.Name = "lblTotConn"
    Me.lblTotConn.Size = New System.Drawing.Size(15, 16)
    Me.lblTotConn.TabIndex = 5
    Me.lblTotConn.Text = "0"
    '
    'lblBytesIn
    '
    Me.lblBytesIn.AutoSize = True
    Me.lblBytesIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblBytesIn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.lblBytesIn.Location = New System.Drawing.Point(217, 57)
    Me.lblBytesIn.Margin = New System.Windows.Forms.Padding(5)
    Me.lblBytesIn.Name = "lblBytesIn"
    Me.lblBytesIn.Size = New System.Drawing.Size(15, 16)
    Me.lblBytesIn.TabIndex = 6
    Me.lblBytesIn.Text = "0"
    '
    'lblBytesOut
    '
    Me.lblBytesOut.AutoSize = True
    Me.lblBytesOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblBytesOut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.lblBytesOut.Location = New System.Drawing.Point(217, 83)
    Me.lblBytesOut.Margin = New System.Windows.Forms.Padding(5)
    Me.lblBytesOut.Name = "lblBytesOut"
    Me.lblBytesOut.Size = New System.Drawing.Size(15, 16)
    Me.lblBytesOut.TabIndex = 7
    Me.lblBytesOut.Text = "0"
    '
    'ViewUI
    '
    Me.AutoScroll = True
    Me.AutoScrollMargin = New System.Drawing.Size(5, 5)
    Me.BackColor = System.Drawing.Color.White
    Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Margin = New System.Windows.Forms.Padding(5)
    Me.Name = "ViewUI"
    Me.Size = New System.Drawing.Size(377, 257)
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.TableLayoutPanel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents lblCurConn As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblTotConn As System.Windows.Forms.Label
  Friend WithEvents lblBytesIn As System.Windows.Forms.Label
  Friend WithEvents lblBytesOut As System.Windows.Forms.Label

End Class
