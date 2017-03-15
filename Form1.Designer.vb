<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.Button1 = New System.Windows.Forms.Button
    Me.ListBox1 = New System.Windows.Forms.ListBox
    Me.Button2 = New System.Windows.Forms.Button
    Me.ViewUI1 = New ViewUI
    Me.OptionsUI1 = New OptionsUI
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(29, 12)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Start"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ListBox1
    '
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.Location = New System.Drawing.Point(12, 271)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(899, 199)
    Me.ListBox1.TabIndex = 3
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(132, 15)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(75, 23)
    Me.Button2.TabIndex = 4
    Me.Button2.Text = "Stop"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'ViewUI1
    '
    Me.ViewUI1.AutoScroll = True
    Me.ViewUI1.AutoScrollMargin = New System.Drawing.Size(5, 5)
    Me.ViewUI1.Location = New System.Drawing.Point(525, 44)
    Me.ViewUI1.Margin = New System.Windows.Forms.Padding(5)
    Me.ViewUI1.Name = "ViewUI1"
    Me.ViewUI1.Size = New System.Drawing.Size(303, 200)
    Me.ViewUI1.TabIndex = 2
    '
    'OptionsUI1
    '
    Me.OptionsUI1.Location = New System.Drawing.Point(29, 62)
    Me.OptionsUI1.Name = "OptionsUI1"
    Me.OptionsUI1.Size = New System.Drawing.Size(371, 203)
    Me.OptionsUI1.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(937, 482)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.ListBox1)
    Me.Controls.Add(Me.ViewUI1)
    Me.Controls.Add(Me.OptionsUI1)
    Me.Controls.Add(Me.Button1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents OptionsUI1 As OptionsUI
  Friend WithEvents ViewUI1 As ViewUI
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
