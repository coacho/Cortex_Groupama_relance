Imports System
Imports System.IO
Imports System.IO.Compression
Imports Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.Net.Mail
Imports System.Net.Sockets

Module Module_mise_en_prod

    Public fic_stat As String

    Public fic_feuil_prod_fdp As String
    Public fic_feuil_prod_spool As String

    Public rep_feuil_prod As String
    Public rep_stats As String

    Function Recup_stat(ByVal fic_in, ByVal stat_wnted)

        fic_in = Path.GetFileName(fic_in)

        Dim tabstr() As String

        fic_stat = rep_serv01 & "Rapports\" & "Rapport_" & fic_in & ".txt"

        Try
            Dim str = New StreamReader(fic_stat)
            Dim ligne As String = ""

            Using (str)
                tabstr = Split(str.ReadLine, ";")
                If tabstr(0) = "" Then 'nombre pages
                    tabstr(0) = "0"
                End If
                If tabstr(1) = "" Then ' nombre de plis
                    tabstr(1) = "0"
                End If
                If tabstr(2) = "" Then 'nombre de faces
                    tabstr(2) = "0"
                End If
            End Using

            If stat_wnted = 0 Then : Return CLng(tabstr(0)) : End If
            If stat_wnted = 1 Then : Return CLng(tabstr(1)) : End If
            If stat_wnted = 2 Then : Return CLng(tabstr(2)) : Else : Return 0 : End If

            str.Close()

        Catch e As Exception
            Console.Write("le fichier en entrée de la fonction Recup_stat stats est vide, verifie la sortie des spools")
            Console.Write("Tous les valeurs retourne 0 puisque le fichier en entré est vide")
            If stat_wnted = 0 Then : Return 0 : End If
            If stat_wnted = 1 Then : Return 0 : End If
            If stat_wnted = 2 Then : Return 0 : End If
        End Try

        If stat_wnted = 0 Then : Return CLng(tabstr(0)) : End If
        If stat_wnted = 1 Then : Return CLng(tabstr(1)) : End If
        If stat_wnted = 2 Then : Return CLng(tabstr(2)) : Else : Return 0 : End If


    End Function

    Public Sub Creation_feuil_job(ByVal fic_in)

        fic_in = Path.GetFileName(fic_in)

        Dim feuil_job As Application = New Application

        fic_feuil_prod_fdp = "\\serveur01\MAO\V9_dialogue\FINAMA\RELANCE\Ressources\Job_finama_relance_dot_net.xlsx"
        fic_feuil_prod_spool = rep_serv01 & "Job\" & "fprod_REL_" & fic_in & ".xlsx"


        If (File.Exists(fic_feuil_prod_spool) = False) Then
            File.Copy(fic_feuil_prod_fdp, fic_feuil_prod_spool)
        Else
            Try
                File.Delete(fic_feuil_prod_spool)
                File.Copy(fic_feuil_prod_fdp, fic_feuil_prod_spool)
            Catch e As Exception

            End Try
        End If

        'OUVERTURE DU FICHIER EXCEL
        'Modèle pré-Formaté
        feuil_job = CreateObject("Excel.Application")
        feuil_job.Visible = False
        feuil_job.Workbooks.Open(Filename:=fic_feuil_prod_spool, Editable:=True)

        'Mise à jour cellule DOSSIER H1
        feuil_job.Range("H1").Select()
        feuil_job.ActiveCell.FormulaR1C1 = "*" & Form_vue.num_doss & "*"
        'Mise à jour cellule APPLICATION C2
        feuil_job.Range("C2").Select()
        feuil_job.ActiveCell.FormulaR1C1 = nom_relance.ToString.ToUpper & " " & type_rel_date
        'Mise à jour cellule APPLICATION H2
        feuil_job.Range("H2").Select()
        feuil_job.ActiveCell.FormulaR1C1 = Date.Now.ToString("MM/yyyy")
        'Mise à jour cellule GESTIONNAIRE C4
        feuil_job.Range("C4").Select()
        feuil_job.ActiveCell.FormulaR1C1 = Form_vue.nom_gest
        'Mise à jour cellule CHEMIN B17
        feuil_job.Range("B17").Select()
        feuil_job.ActiveCell.FormulaR1C1 = rep_spool
        'Mise à jour cellule FICHIER A19
        feuil_job.Range("A19").Select()
        feuil_job.ActiveCell.FormulaR1C1 = fic_in & ".pdf"
        'Mise à jour cellule NbPAGES F19
        feuil_job.Range("F19").Select()
        feuil_job.ActiveCell.FormulaR1C1 = Recup_stat(fic_in, 0)
        'Mise à jour cellule NbFACES H19
        feuil_job.Range("H19").Select()
        feuil_job.ActiveCell.FormulaR1C1 = Recup_stat(fic_in, 2)
        'Mise à jour celluleNbPLIS J19
        feuil_job.Range("J19").Select()
        feuil_job.ActiveCell.FormulaR1C1 = Recup_stat(fic_in, 0)

        feuil_job.DisplayAlerts = False
        feuil_job.ActiveWorkbook.SaveAs(fic_feuil_prod_spool)
        feuil_job.ActiveWorkbook.PrintOutEx()
        feuil_job.Workbooks.Close()
        feuil_job.Application.Quit()

    End Sub

    Public Sub Envoi_mail(ByVal fic_in)

        'declaration des bats en piece jointes
        Dim smtp As New System.Net.Mail.SmtpClient()
        Dim mail As New System.Net.Mail.MailMessage()

        Dim fic_pdf_avis As String = rep_spool & "finama" & date_fic_echeance & ".pdf"
        Dim fic_pdf_avis_exclu As String = rep_spool & "finama" & date_fic_echeance & "_exclus.pdf"

        Dim mail_mathieu As String 'pour les tests
        Dim mail_ca As String
        Dim mail_mao As String
        Dim mail_exploit As String

        mail_mathieu = "mathieu.launay@cortex-sa.com" 'pour les tests

        mail_mao = "mao@cortex-sa.com"
        mail_ca = "ca@cortex-sa.com"
        mail_exploit = """Exploitation Cortex"" <fid@cortex-sa.com>"

        mail.From = New System.Net.Mail.MailAddress(mail_exploit)
        mail.CC.Add(mail_mathieu)
        mail.To.Add(mail_mathieu)
        mail.Subject = "Stats - RELANCE GROUPAMA - dossier : " & Form_vue.num_doss
        mail.Body = "Bonjour, " & vbCrLf & vbCrLf
        mail.Body = mail.Body & "Ci-dessous les comptages pour les avis finama du " & type_rel_date& & vbCrLf & "Fait le " & Date.Now.ToString("dd/MM/yyyy") & " par " & Form_vue.nom_gest & vbCrLf
        mail.Body = mail.Body & nom_relance & ":" & vbCrLf
        mail.Body = mail.Body & "Nbre de plis total Relance Groupama Immo  : " & Recup_stat(fic_in, 0) & vbCrLf & vbCrLf
        mail.Body = mail.Body & "Cordialement. "

        'Préparation du client SMTP 
        smtp.Host = "smtp-cortex"

        'Tentative d'envoi
        Try
            smtp.Send(mail)
            smtp.Timeout = 60
        Catch
            MsgBox("Problème ds l'envoi du mail")
        End Try

    End Sub


End Module
