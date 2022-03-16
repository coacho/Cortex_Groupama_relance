Imports System.IO
Imports System.Net.Sockets
Imports System.Text

Module Module_dialogue

    Public rep_opt_fic As String
    Public rep_bat As String
    Public fic_pub As String = ""

    Public Function Creation_opt(ByVal fic_in)

        fic_in = Path.GetFileName(fic_in)
        fic_pub = "finama_relance_en_cours.pub"
        Dim ligne As String = ""
        rep_opt_fic = rep_serv01 & Path.GetFileNameWithoutExtension(fic_in) & ".opt"
        Dim stw = New StreamWriter(rep_opt_fic)
        Using (stw)
            stw.Write("-PACKAGEFILE=" & rep_serv01 & fic_pub & vbCrLf)
            stw.Write("-FILEMAP=driver," & rep_travail & fic_in & vbCrLf)
            stw.Write("-FILEMAP=rapp," & rep_serv01 & "Rapports\" & "Rapport_" & fic_in & ".txt" & vbCrLf)
            stw.Write("-FILEMAP=driverPDF," & rep_spool & fic_in & ".pdf" & vbCrLf)
            stw.Write("-FILEMAP=driverPDF_BAT," & rep_serv01 & "BAT\" & fic_in & "_bat.pdf" & vbCrLf)
            stw.Write("-RUNMODE=PRODUCTION" & vbCrLf)
            stw.Write("-MESSAGEFILE=" & rep_serv01 & "Messages\" & "Messages_" & fic_in & ".txt" & vbCrLf)
        End Using

        stw.Close()

        'Creation des bats
        Creation_bat(fic_in)

        Return rep_opt_fic

    End Function

    Public Sub Creation_bat(ByVal fic_in)

        fic_in = Path.GetFileNameWithoutExtension(fic_in)
        rep_bat = rep_serv01 & "Moteur_" & fic_in & ".BAT"
        Dim stw = New StreamWriter(rep_bat)

        Using (stw)
            stw.Write("ECHO Lancement de la composition Dialogue" & vbCrLf)
            stw.Write("c:" & vbCrLf)
            stw.Write("CD C:\DialogueEngine9-5\" & vbCrLf)
            stw.Write("ProdEngine.exe -CONTROLFILE=" & rep_serv01 & fic_in & ".opt" & vbCrLf)
            stw.Write("")
            stw.Write("rem pause" & vbCrLf)
        End Using
        stw.Close()

        'lancement dialogiue
        LancementDialogue(rep_bat)

    End Sub

    Private Sub Exec_Winsock(ByVal Serveur As String, ByVal Command As String)
        Dim tcpClient As New System.Net.Sockets.TcpClient()
        tcpClient.Connect(Serveur, 1001)
        Dim networkStream As NetworkStream = tcpClient.GetStream()
        If networkStream.CanWrite And networkStream.CanRead Then

            'Inscription sur le serveur winsock/dialogue
            Dim dlg_command As String
            dlg_command = "ID"
            Dim sendBytes = Encoding.ASCII.GetBytes(dlg_command.PadRight(20) + "DORMEUR|")
            networkStream.Write(sendBytes, 0, sendBytes.Length)
            For i = 0 To 1000000
                System.Windows.Forms.Application.DoEvents()
            Next

            'Maj des informations de la connexion sur le serveur
            dlg_command = "UPDATE"
            sendBytes = Encoding.ASCII.GetBytes(dlg_command.PadRight(20) + "DE|" & Command & "|DE|DE|DE|")
            networkStream.Write(sendBytes, 0, sendBytes.Length)

            'Lancement du moteur Dialogue
            dlg_command = "EXECUTE"
            sendBytes = Encoding.ASCII.GetBytes(dlg_command.PadRight(20) + Command)
            networkStream.Write(sendBytes, 0, sendBytes.Length)
            For i = 0 To 1000000
                System.Windows.Forms.Application.DoEvents()
            Next

            ' Lecture du flux réseau - attente du retour
            Dim bytes(tcpClient.ReceiveBufferSize) As Byte
            networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))

            ' Récupération du retour traitement
            Dim returndata As String = Encoding.ASCII.GetString(bytes)
            For i = 0 To 50000
                System.Windows.Forms.Application.DoEvents()
            Next
            tcpClient.Close()
        Else
            If Not networkStream.CanRead Then
                MsgBox("cannot not write data to this stream")
                tcpClient.Close()
            Else
                If Not networkStream.CanWrite Then
                    MsgBox("cannot read data from this stream")
                    tcpClient.Close()
                End If
            End If
        End If
    End Sub

    Public Sub LancementDialogue(ByVal fic_in)

        Exec_Winsock("ot-exs-01", fic_in)

    End Sub

End Module
