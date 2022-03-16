Public Class Form_vue

    Public fic_relance As String

    Public num_doss As String
    Public nom_gest As String

    Public check_rel_1 As Boolean
    Public check_rel_2 As Boolean

    Private Sub Btn_parcourir_Click(sender As Object, e As EventArgs) Handles Btn_parcourir.Click

        OpenFileDialog1.InitialDirectory = "\\serveur01\MAO\fichier doc\"
        OpenFileDialog1.ShowDialog()
        fic_relance = OpenFileDialog1.FileName
        Txt_fic_in.Text = fic_relance

    End Sub
    Private Function Txt_gest_TextRecup()
        Return Txt_gest.Text
    End Function
    Private Function Txt_doss_TextRecup()
        Return Txt_doss.Text
    End Function

    Private Sub Btn_annuler_Click(sender As Object, e As EventArgs) Handles Btn_annuler.Click
        Application.Restart()
    End Sub
    Private Sub GrpBox_option_Enter(sender As Object, e As EventArgs) Handles GrpBox_option.Enter
        If Rdio_Btn_rel1.Checked = False Then : Rdio_Btn_rel2.Checked = True : End If
        If Rdio_Btn_rel2.Checked = False Then : Rdio_Btn_rel1.Checked = True : End If
    End Sub
    Private Sub GrpBox_option2_Enter(sender As Object, e As EventArgs) Handles GrpBox_option2.Enter
        If Rdio_Btn_rel15.Checked = False Then : Rdio_Btn_rel30.Checked = True : End If
        If Rdio_Btn_rel30.Checked = False Then : Rdio_Btn_rel15.Checked = True : End If
    End Sub
    Private Sub Btn_lancer_Click(sender As Object, e As EventArgs) Handles Btn_lancer.Click

        If Etat_check_error() = True Then : Exit Sub : End If

        'Initiatiation des répertoires
        Aff_princ_text("Initialisation des répertoires")
        nom_gest = Txt_gest_TextRecup()
        num_doss = Txt_doss_TextRecup()
        init_rep(num_doss)
        fic_relance = MiseEnPlace_fic_donnees(fic_relance)

        'Tri du fichier 
        Aff_princ_text("Tri du fichier " & nom_relance)
        fic_relance = tri_sur_cp(fic_relance)
        fic_relance = formatage_dialogue(fic_relance) 'regroupe les cibles avec des num_ref identiques pour éviter le changment de cible (page) prévut dans le fichier d'origine

        'Creation OPT + BAT + Lancement dialogue
        Aff_princ_text("Lancement de dialogue " & vbCrLf & fic_relance)
        Creation_opt(fic_relance)

        'Creation de la feuille de prod
        Aff_princ_text("Création feuille de prod")
        Creation_feuil_job(fic_relance)

        'Envoi du mail auX CA
        Aff_princ_text("Envoi des stats et BAT aux CA")
        Envoi_mail(fic_relance)

        Aff_princ_text("Traitement terminé")

    End Sub
End Class