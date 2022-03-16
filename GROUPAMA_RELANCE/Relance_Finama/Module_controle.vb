Imports System.IO
Imports System.Threading

Module Module_controle

    Public text_in As String = ""
    Public fic_in As String = ""

    Public Function Etat_check_error() As Boolean
        If Etat_check_gest() = False Or Etat_check_dossier() = False Or Etat_check_fic_in() = False Then 'Or Etat_Check_unzip() = False Then
            Etat_check_error = True
        Else
            Etat_check_error = False
        End If
    End Function

    Public Function Etat_check_gest() As Boolean
        If Form_vue.Txt_gest.Text = "" Then : Etat_check_gest = False
            text_in = "Veuillez remplir le gestionnnaires"
            Aff_princ_text(text_in)
        Else : Etat_check_gest = True
        End If
    End Function

    Public Function Etat_check_dossier() As Boolean
        If Form_vue.Txt_doss.Text = "" Then : Etat_check_dossier = False
            text_in = "Veuillez remplir le numéro de dossier"
            Aff_princ_text(text_in)
        Else : Etat_check_dossier = True
        End If
    End Function

    Public Function Etat_check_fic_in() As Boolean
        If Form_vue.Txt_fic_in.Text = "" Then : Etat_check_fic_in = False 'Form_vue.Txt_fic_zip.Text = "" And
            text_in = "Veuillez selectionner un fichier en entrée"
            Aff_princ_text(text_in)
        Else : Etat_check_fic_in = True
        End If
    End Function

    Public Function Check_fic_in_exist(ByVal fic_in) As Boolean
        If File.Exists(fic_in) = False Then : Check_fic_in_exist = False
            text_in = "Fichier en entrée introuvable !" & vbCrLf & "Vérifier qu'il existe bien !"
            Aff_princ_text(text_in)
        Else : Check_fic_in_exist = True
        End If
    End Function

    Public Sub Message_erreur(ByVal info_error_in, ByVal from_where_in)

        Dim nom_function_from As String
        Dim text_error As String
        Dim date_date As String
        Dim rep_error As String

        rep_error = Application.StartupPath() & "\log\"
        date_date = Date.Now.ToString("yyyyMMddhhmmss")
        text_error = info_error_in.ToString
        nom_function_from = from_where_in.ToString

        If System.IO.Directory.Exists(rep_error) = False Then : Directory.CreateDirectory(rep_error) : End If

        Dim fic_error As String = rep_error & date_date & "_" & nom_function_from & ".log"

        MsgBox("Erreur de ' " & nom_function_from & " '" & vbCrLf & "chemin des logs " & vbCrLf & fic_error & vbCrLf & "le traitement vas continuer")

        If System.IO.File.Exists(fic_error) = True Then : Suppression_fichier(fic_error) : End If
        If System.IO.File.Exists(fic_error) = False Then : File.Create(fic_error).Close() : End If

        Dim objWriter As New System.IO.StreamWriter(fic_error)
        objWriter.Write(text_error.ToString)
        objWriter.Close()
        System.Diagnostics.Process.Start("notepad.exe", fic_error.ToString)

    End Sub

    Public Function Aff_princ_text(ByVal text_in As String)

        Form_vue.Txt_AffPrinc.Refresh()
        Form_vue.Txt_AffPrinc.Text = ""
        Form_vue.Txt_AffPrinc.Text = text_in & vbCrLf
        Form_vue.Txt_AffPrinc.Refresh()
        text_in = ""

        Return text_in

    End Function

    Public Sub Suppression_fichier(ByVal fic_in As String)

        If File.Exists(fic_in) = True Then
            Try
                Thread.Sleep(10)
                File.Delete(fic_in)
            Catch e As Exception
                Message_erreur(e.ToString, "Suppression_fichier")
            End Try
        End If
    End Sub

End Module