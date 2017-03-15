Public Class Form1

  WithEvents pi As TcpForwardPlugIn

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim x = "1|0.0.0.0|5000|www.cnn.com|80|25|0|300"
    OptionsUI1.LoadData(x)
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    pi = New TcpForwardPlugIn

    If Not OptionsUI1.ValidateData Then Exit Sub
    Dim x = OptionsUI1.SaveData

    pi.LoadConfig(x, Nothing, "", 10)
    pi.StartService()
  End Sub

  Private Sub pi_LogLine(ByVal text As String) Handles pi.LogLine
    Me.Invoke(LogLineDGDG, text)
  End Sub

  Private LogLineDGDG As New LogLineDG(AddressOf LogLine)
  Private Delegate Sub LogLineDG(ByVal s As String)

  Private Sub LogLine(ByVal s As String)
    ListBox1.Items.Add(s)
  End Sub


  Private Sub ViewUI1_MsgFromViewUI(ByVal msg() As Byte) Handles ViewUI1.MsgFromViewUI
    pi.MsgFromViewUI(1, msg)
  End Sub

  Private Sub pi_MsgToViewUI1(ByVal connID As Integer, ByVal msg() As Byte) Handles pi.MsgToViewUI
    Invoke(MsgToViewUIDGDG, msg)
  End Sub

  Private MsgToViewUIDGDG As New MsgToViewUIDG(AddressOf MsgToViewUI)
  Private Delegate Sub MsgToViewUIDG(ByVal msg As Byte())
  Private Sub MsgToViewUI(ByVal msg As Byte())
    ViewUI1.MsgFromService(msg)
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    pi.StopService()
  End Sub
End Class