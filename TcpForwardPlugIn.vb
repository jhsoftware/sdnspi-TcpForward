﻿Public Class TcpForwardPlugIn
  Implements JHSoftware.SimpleDNS.Plugin.INoDNS
  Implements JHSoftware.SimpleDNS.Plugin.IViewUI
  Implements JHSoftware.SimpleDNS.Plugin.IOptionsUI

  Dim cfg As MyConfig
  Dim LSock As System.Net.Sockets.Socket
  Dim Conns As List(Of Connection)
  Dim TotConnCt As Integer
  Friend TotBytesIn, TotBytesOut As Long
  Private ShuttingDown As Boolean

  Dim Tmr As System.Threading.Timer

  Public Event MsgToViewUI As Plugin.IViewUI.MsgToViewUIEventHandler Implements Plugin.IViewUI.MsgToViewUI

  Public Property Host As Plugin.IHost Implements Plugin.IPlugInBase.Host

  Public Function GetPlugInTypeInfo() As Plugin.TypeInfo Implements Plugin.IPlugInBase.GetTypeInfo
    Dim rv As Plugin.TypeInfo
    rv.Name = "TCP Port Forwarder"
    rv.Description = "Forwards TCP traffic"
    rv.InfoURL = "https://simpledns.plus/plugin-tcpforward"
    Return rv
  End Function

  Public Function InstanceConflict(ByVal config1 As String, ByVal config2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Dim cfg1 = MyConfig.Load(config1)
    Dim cfg2 = MyConfig.Load(config2)
    If cfg1.ListenIP = cfg2.ListenIP AndAlso cfg1.ListenPort = cfg2.ListenPort Then
      errorMsg = "Another plug-in instance is listening on same IP address and port"
      Return True
    End If
    Return False
  End Function

  Public Sub LoadConfig(config As String, instanceID As System.Guid, dataPath As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadConfig
    cfg = MyConfig.Load(config)
  End Sub

  Public Function StartService() As Threading.Tasks.Task Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StartService
    ShuttingDown = False
    Conns = New List(Of Connection)
    LSock = New System.Net.Sockets.Socket(cfg.ListenIP.ToIPAddress.AddressFamily, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
    LSock.Bind(New System.Net.IPEndPoint(cfg.ListenIP.ToIPAddress, cfg.ListenPort))
    LSock.Listen(5)
    LSock.BeginAccept(AddressOf LSockCB, LSock)

    Tmr = New System.Threading.Timer(AddressOf TimerTick, Me, 0, 1000)
    Return Threading.Tasks.Task.CompletedTask
  End Function

  Private Sub TimerTick(ByVal state As Object)
    If ShuttingDown Then Exit Sub

    If cfg.EnableTimeOut Then
      SyncLock Conns
        For i = Conns.Count - 1 To 0 Step -1
          If Conns(i).IdleTime.TotalSeconds > cfg.TimeOut Then
            Host.LogLine(Conns(i).ClientIP.ToString & " - Idle connection time out.")
            Conns(i).ShutDown()
          End If
        Next
      End SyncLock
    End If

    SendStats()
  End Sub

  Private Sub SendStats()
    Dim ba(24) As Byte
    ba(0) = 1 ' message type = stats counters 
    BufSetInt(ba, 1, Conns.Count)
    BufSetInt(ba, 5, TotConnCt)
    BufSetInt(ba, 9, TotBytesIn)
    BufSetInt(ba, 17, TotBytesOut)
    RaiseEvent MsgToViewUI(-1, ba)
  End Sub

  Private Sub LSockCB(ByVal ia As IAsyncResult)
    If ShuttingDown Then Exit Sub

    Dim conn As New Connection
    Try
      conn.Sock1 = LSock.EndAccept(ia)
    Catch
      GoTo markWaitForNext
    End Try
    conn.ClientIP = DirectCast(conn.Sock1.RemoteEndPoint, System.Net.IPEndPoint).Address

    If Conns.Count >= cfg.MaxConns Then
      Try
        conn.Sock1.Close()
      Catch
      End Try
      Host.LogLine(conn.ClientIP.ToString & " - New connection rejected - Max. connections already open")
      GoTo markWaitForNext
    End If

    Host.LogLine(conn.ClientIP.ToString & " - New connection accepted")

    Dim IPs As System.Net.IPAddress()
    Dim IP As System.Net.IPAddress = Nothing
    If System.Net.IPAddress.TryParse(cfg.ConnectHost, IP) Then
      ReDim IPs(0)
      IPs(0) = IP
    Else
      Try
        IPs = System.Net.Dns.GetHostAddresses(cfg.ConnectHost)
        If IPs.Length > 0 Then GoTo markResolved
      Catch
      End Try
      Try
        conn.Sock1.Close()
      Catch
      End Try
      Host.LogLine(conn.ClientIP.ToString & " - New connection rejected - could not resolve server host name.")
      GoTo markWaitForNext
    End If
markResolved:

    Try
      conn.Sock2 = New System.Net.Sockets.Socket(IPs(0).AddressFamily, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
      conn.Sock2.Connect(IPs, cfg.ConnectPort)
    Catch ex As Exception
      Try
        conn.Sock1.Close()
      Catch
      End Try
      Host.LogLine(conn.ClientIP.ToString & " - New connection rejected - error connecting to host: " & ex.Message)
      GoTo markWaitForNext
    End Try

    SyncLock Conns
      If Conns.Count >= cfg.MaxConns Then
        Try
          conn.Sock1.Close()
        Catch
        End Try
        Try
          conn.Sock2.Close()
        Catch
        End Try
        Host.LogLine(conn.ClientIP.ToString & " - New connection rejected - Max. connections already open")
        GoTo markWaitForNext
      End If

      Conns.Add(conn)
      TotConnCt += 1
      AddHandler conn.SocketError, AddressOf Conn_SockError
      AddHandler conn.Closed, AddressOf Conn_Closed
      AddHandler conn.DataTransfered, AddressOf Conn_DataTransfered
      conn.Go()
    End SyncLock

markWaitForNext:
    Try
      LSock.BeginAccept(AddressOf LSockCB, LSock)
    Catch ex As Exception
      If ShuttingDown Then Exit Sub
      Host.AsyncError(New Exception("Error on listening socket: " & ex.Message, ex))
    End Try
  End Sub

  Sub Conn_SockError(ByVal sender As Connection, ByVal ex As Exception)
    If TypeOf ex Is System.Net.Sockets.SocketException Then
      Host.LogLine(sender.ClientIP.ToString & " - Socket error " & DirectCast(ex, System.Net.Sockets.SocketException).SocketErrorCode & ": " & ex.Message)
    Else
      Host.LogLine(sender.ClientIP.ToString & " - Error: " & ex.Message)
    End If
  End Sub

  Sub Conn_Closed(ByVal sender As Connection)
    SyncLock Conns
      Conns.Remove(sender)
    End SyncLock
    Host.LogLine(sender.ClientIP.ToString & " - Connection closed. " & sender.BytesIn & " bytes received. " & sender.BytesOut & " bytes sent. Connected for " & DateTime.UtcNow.Subtract(sender.StartTime).ToString)
  End Sub

  Sub Conn_DataTransfered(ByVal sender As Connection, ByVal Inbound As Boolean, ByVal count As Integer)
    If Inbound Then
      Threading.Interlocked.Add(TotBytesIn, count)
    Else
      Threading.Interlocked.Add(TotBytesOut, count)
    End If
  End Sub

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StopService
    ShuttingDown = True
    Tmr.Dispose()
    Try
      LSock.Close()
    Catch
    End Try
    SyncLock Conns
      For i = Conns.Count - 1 To 0 Step -1
        Conns(i).ShutDown()
      Next
    End SyncLock
    SendStats()
  End Sub

  Public Function GetOptionsUI(ByVal instanceID As System.Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IOptionsUI.GetOptionsUI
    Return New OptionsUI
  End Function

  Public Function GetViewUI() As JHSoftware.SimpleDNS.Plugin.ViewUI Implements JHSoftware.SimpleDNS.Plugin.IViewUI.GetViewUI
    Return New ViewUI
  End Function

  Public Sub MsgFromViewUI(ByVal connID As Integer, ByVal msg() As Byte) Implements JHSoftware.SimpleDNS.Plugin.IViewUI.MsgFromViewUI
    REM nothing
  End Sub

  Friend Sub BufSetInt(ByVal buf As Byte(), ByVal index As Integer, ByVal value As Int32)
    buf(index) = CByte((value >> 24) And &H7F)
    buf(index + 1) = CByte((value >> 16) And &HFF)
    buf(index + 2) = CByte((value >> 8) And &HFF)
    buf(index + 3) = CByte(value And &HFF)
  End Sub

  Friend Sub BufSetInt(ByVal buf As Byte(), ByVal index As Integer, ByVal value As Int64)
    buf(index) = CByte((value >> 56) And &H7FL)
    buf(index + 1) = CByte((value >> 48) And &HFFL)
    buf(index + 2) = CByte((value >> 40) And &HFFL)
    buf(index + 3) = CByte((value >> 32) And &HFFL)
    buf(index + 4) = CByte((value >> 24) And &HFFL)
    buf(index + 5) = CByte((value >> 16) And &HFFL)
    buf(index + 6) = CByte((value >> 8) And &HFFL)
    buf(index + 7) = CByte(value And &HFFL)
  End Sub

End Class
