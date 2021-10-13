Public Class OptionsUI

  Private AllIp4 As String = "All local IPv4 addresses"
  Private AllIp6 As String = "All local IPv6 addresses"

  Public Overrides Sub LoadData(ByVal config As String)
    ddListenIP.Items.Add(AllIp4)
    ddListenIP.Items.Add(AllIp6)
    ddListenIP.Items.Add("127.0.0.1")
    ddListenIP.Items.Add("::1")
    For Each ipsn In GetServerIPs()
      ddListenIP.Items.Add(ipsn.IPAddr.ToString)
    Next
    ddListenIP.SelectedIndex = 0

    Dim cfg = MyConfig.Load(config)
    If cfg.ListenIP = SdnsIP.Parse("0.0.0.0") Then
      ddListenIP.SelectedIndex = 0
    ElseIf cfg.ListenIP = sdnsip.Parse("::") Then
      ddListenIP.SelectedIndex = 1
    Else
      For i = 2 To ddListenIP.Items.Count - 1
        If SdnsIP.Parse(ddListenIP.Items(i).ToString) = cfg.ListenIP Then ddListenIP.SelectedIndex = i : Exit For
      Next
    End If
    numListenPort.Value = cfg.ListenPort
    txtConnHost.Text = cfg.ConnectHost
    numConnPort.Value = cfg.ConnectPort
    numMaxConn.Value = cfg.MaxConns
    chkTimeOut.Checked = cfg.EnableTimeOut
    ttlTimeOut.Value = cfg.TimeOut
  End Sub

  Public Overrides Function ValidateData() As Boolean
    If numListenPort.Value = 0 Then
      MessageBox.Show("Invalid Listen on TCP port number", "TCP Port Forwarder", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    If txtConnHost.Text.Trim.Length = 0 Then
      MessageBox.Show("Connect to host name is required", "TCP Port Forwarder", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    If numConnPort.Value = 0 Then
      MessageBox.Show("Invalid Connect to TCP port number", "TCP Port Forwarder", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    Return True
  End Function

  Public Overrides Function SaveData() As String
    Dim cfg As New MyConfig
    If ddListenIP.SelectedItem.ToString = AllIp4 Then
      cfg.ListenIP = SdnsIP.Parse("0.0.0.0")
    ElseIf ddListenIP.SelectedItem.ToString = AllIp6 Then
      cfg.ListenIP = SdnsIP.Parse("::")
    Else
      cfg.ListenIP = SdnsIP.Parse(ddListenIP.SelectedItem.ToString)
    End If
    cfg.ListenPort = CUShort(numListenPort.Value)
    cfg.ConnectHost = txtConnHost.Text.Trim.ToLowerInvariant
    cfg.ConnectPort = CUShort(numConnPort.Value)
    cfg.MaxConns = CInt(numMaxConn.Value)
    cfg.EnableTimeOut = chkTimeOut.Checked
    cfg.TimeOut = ttlTimeOut.Value
    Return cfg.Save
  End Function

  Private Sub chkTimeOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTimeOut.CheckedChanged
    ttlTimeOut.Enabled = chkTimeOut.Checked
  End Sub
End Class
