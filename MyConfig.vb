Friend Class MyConfig

  Friend ListenIP As JHSoftware.SimpleDNS.Plugin.IPAddress
  Friend ListenPort As UShort

  Friend ConnectHost As String
  Friend ConnectPort As UShort

  Friend MaxConns As Integer
  Friend EnableTimeOut As Boolean
  Friend TimeOut As Integer ' in seconds

  Public Function Save() As String
    Return "1|" & _
           ListenIP.ToString & "|" & _
           ListenPort.ToString & "|" & _
           PipeEncode(ConnectHost) & "|" & _
           ConnectPort.ToString & "|" & _
           MaxConns.ToString & "|" & _
           If(EnableTimeOut, "1", "0") & "|" & _
           TimeOut.ToString
  End Function

  Public Shared Function Load(ByVal s As String) As MyConfig
    If s Is Nothing Then s = "1|0.0.0.0|0||0|25|1|300"
    If Not s.StartsWith("1|") Then Throw New Exception("Unknown configuration data version")
    Dim va = PipeDecode(s)
    Dim rv As New MyConfig
    rv.ListenIP = JHSoftware.SimpleDNS.Plugin.IPAddress.Parse(va(1))
    rv.ListenPort = UShort.Parse(va(2))
    rv.ConnectHost = va(3)
    rv.ConnectPort = UShort.Parse(va(4))
    rv.MaxConns = Integer.Parse(va(5))
    rv.EnableTimeOut = (va(6) = "1")
    rv.TimeOut = Integer.Parse(va(7))
    Return rv
  End Function

End Class
