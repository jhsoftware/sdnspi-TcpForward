Imports System.Net.Sockets

Public Class Connection

  Friend ClientIP As System.Net.IPAddress
  Friend Sock1, Sock2 As Socket
  Private WithEvents Flow1, Flow2 As Flow

  Friend Event SocketError(ByVal sender As Connection, ByVal ex As System.Exception)
  Friend Event Closed(ByVal sender As Connection)
  Friend Event DataTransfered(ByVal sender As Connection, ByVal Inbound As Boolean, ByVal count As Integer)

  Private ShuttingDown As Boolean = False

  Friend StartTime As DateTime = DateTime.UtcNow

  Friend BytesIn, BytesOut As Long

  Sub Go()
    SyncLock Me
      Flow1 = New Flow
      Flow1.Go(Sock1, Sock2)
      Flow2 = New Flow
      Flow2.Go(Sock2, Sock1)
    End SyncLock
  End Sub

  Function IdleTime() As TimeSpan
    Return DateTime.UtcNow.Subtract(If(Flow1.IdleSince > Flow2.IdleSince, Flow1.IdleSince, Flow2.IdleSince))
  End Function

  Friend Sub ShutDown()
    SyncLock Me
      If ShuttingDown Then Exit Sub
      ShuttingDown = True
      Try
        Sock1.Close()
      Catch
      End Try
      Try
        Sock2.Close()
      Catch
      End Try
      RaiseEvent Closed(Me)
    End SyncLock
  End Sub

  Private Sub Flow1_DataTransfered(ByVal count As Integer) Handles Flow1.DataTransfered
    Threading.Interlocked.Add(BytesIn, count)
    RaiseEvent DataTransfered(Me, True, count)
  End Sub
  Private Sub Flow2_DataTransfered(ByVal count As Integer) Handles Flow2.DataTransfered
    Threading.Interlocked.Add(BytesOut, count)
    RaiseEvent DataTransfered(Me, False, count)
  End Sub

  Private Sub Flow1_SocketClosed() Handles Flow1.SocketClosed, Flow2.SocketClosed
    ShutDown()
  End Sub

  Private Sub Flow1_SocketError(ByVal ex As Exception) Handles Flow1.SocketError, Flow2.SocketError
    SyncLock Me
      If ShuttingDown Then Exit Sub
      If Not TypeOf ex Is SocketException OrElse DirectCast(ex, SocketException).SocketErrorCode <> 10054 Then
        RaiseEvent SocketError(Me, ex)
      End If
      ShutDown()
    End SyncLock
  End Sub


  Class Flow
    Friend IdleSince As DateTime = DateTime.UtcNow
    Private sockIn, sockOut As Socket
    Dim Buf(8191) As Byte

    Event DataTransfered(ByVal count As Integer)
    Event SocketError(ByVal ex As Exception)
    Event SocketClosed()

    Sub Go(ByVal sock1 As Socket, ByVal sock2 As Socket)
      sockIn = sock1
      sockOut = sock2
      Try
        sockIn.BeginReceive(Buf, 0, Buf.Length, SocketFlags.None, AddressOf RecvCB, sockIn)
      Catch ex As Exception
        RaiseEvent SocketError(ex)
      End Try
    End Sub

    Sub RecvCB(ByVal ia As IAsyncResult)
      Dim ln As Integer

      Try
        ln = sockIn.EndReceive(ia)
      Catch ex As Exception
        RaiseEvent SocketError(ex)
        Exit Sub
      End Try

      If ln = 0 Then RaiseEvent SocketClosed() : Exit Sub

      IdleSince = DateTime.UtcNow

      Try
        sockOut.BeginSend(Buf, 0, ln, SocketFlags.None, AddressOf SendCB, sockOut)
      Catch ex As Exception
        RaiseEvent SocketError(ex)
        Exit Sub
      End Try

      RaiseEvent DataTransfered(ln)

      IdleSince = DateTime.UtcNow
    End Sub

    Sub SendCB(ByVal ia As IAsyncResult)
      Try
        sockOut.EndSend(ia)
      Catch ex As Exception
        RaiseEvent SocketError(ex)
        Exit Sub
      End Try

      Try
        sockIn.BeginReceive(Buf, 0, Buf.Length, SocketFlags.None, AddressOf RecvCB, sockIn)
      Catch ex As Exception
        RaiseEvent SocketError(ex)
        Exit Sub
      End Try
    End Sub

  End Class

End Class

