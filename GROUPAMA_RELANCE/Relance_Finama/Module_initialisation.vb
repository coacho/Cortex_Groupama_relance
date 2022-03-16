Imports System.IO
Module Module_initialisation

    Public rep_serv01 As String
    Public rep_travail As String
    Public rep_spool As String
    Public date_fic_echeance As String
    Public type_rel_date As String

    Public nom_relance As String

    Public list_fic_temp As New List(Of String)

    Public UnZipFile As Object

    Public cpt_fic_in As Integer = 1

    Sub init_rep(ByVal dossier_num)

        date_fic_echeance = ".m" & Date.Now.ToString("MM")

        rep_travail = "\\Data-ctx\FICHIERS\FICHIERS_TRAVAIL\Finama\relance\"
        rep_serv01 = "\\serveur01\mao\V9_dialogue\FINAMA\RELANCE\"
        rep_spool = "\\Data-ctx\FICHIERS\FICHIERS_OUT\PRODUCTION\FINAMA\RELANCE\"

        'creation repertoire out des spools
        If Directory.Exists(rep_spool) = False Then
            Directory.CreateDirectory(rep_spool)
        End If

        'creation rep sur serv01
        If (Directory.Exists(rep_serv01) = False) Then
            Directory.CreateDirectory(rep_serv01)
        End If

        'creation repertoire de travail
        If Directory.Exists(rep_travail) = False Then
            Directory.CreateDirectory(rep_travail)
        End If

        If Form_vue.Rdio_Btn_rel1.Checked = True Then
            nom_relance = "relance1"
        Else : nom_relance = "relance2"
        End If

        If Form_vue.Rdio_Btn_rel15.Checked = True Then
            type_rel_date = "15"
        ElseIf Form_vue.Rdio_Btn_rel30.Checked = True Then
            type_rel_date = "30"
        End If

    End Sub

    Function MiseEnPlace_fic_donnees(ByVal fic_in)

        Dim fic_out As String
        Dim fic_en_cours As String

        fic_en_cours = fic_in
        fic_out = rep_travail & "finama_" & nom_relance & "_" & type_rel_date & ".temp"
        FileCopy(fic_in, fic_out)
        Return fic_out

    End Function

End Module
