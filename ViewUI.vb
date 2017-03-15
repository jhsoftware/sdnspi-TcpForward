Public Class ViewUI

  Public Overrides Sub MsgFromService(ByVal msg() As Byte)
    If msg(0) = 1 Then
      REM message type = stats counters
      lblCurConn.Text = BufGetInt32(msg, 1).ToString("###,###,###,###,###,##0")
      lblTotConn.Text = BufGetInt32(msg, 5).ToString("###,###,###,###,###,##0")
      lblBytesIn.Text = FormatByteCount(BufGetInt64(msg, 9))
      lblBytesOut.Text = FormatByteCount(BufGetInt64(msg, 17))
    End If
  End Sub

  Private Function FormatByteCount(ByVal ct As Long) As String
    Dim rv = ct.ToString("###,###,###,###,###,##0")
    If ct >= 1024L ^ 4 Then
      rv &= " (" & (ct / 1024L ^ 4).ToString("###,###,##0.0") & " TB)"
    ElseIf ct >= 1024L ^ 3 Then
      rv &= " (" & (ct / 1024L ^ 3).ToString("##0.0") & " GB)"
    ElseIf ct >= 1024L ^ 2 Then
      rv &= " (" & (ct / 1024L ^ 2).ToString("##0.0") & " MB)"
    ElseIf ct >= 1024L Then
      rv &= " (" & (ct / 1024L).ToString("##0.0") & " kB)"
    End If
    Return rv
  End Function

  Friend Function BufGetInt32(ByVal buf As Byte(), ByVal index As Integer) As Int32
    Return ((buf(index) And &H7F) << 24) Or _
           (CInt(buf(index + 1)) << 16) Or _
           (CInt(buf(index + 2)) << 8) Or _
           buf(index + 3)
  End Function

  Friend Function BufGetInt64(ByVal buf As Byte(), ByVal index As Integer) As Int64
    Return ((buf(index) And &H7FL) << 56) Or _
           (CLng(buf(index + 1)) << 48) Or _
           (CLng(buf(index + 2)) << 40) Or _
           (CLng(buf(index + 3)) << 32) Or _
           (CLng(buf(index + 4)) << 24) Or _
           (CLng(buf(index + 5)) << 16) Or _
           (CLng(buf(index + 6)) << 8) Or _
           CLng(buf(index + 7))
  End Function

End Class
