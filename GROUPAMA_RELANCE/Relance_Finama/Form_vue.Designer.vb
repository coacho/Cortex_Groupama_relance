<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_vue
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Txt_gest = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_doss = New System.Windows.Forms.TextBox()
        Me.GrpBox_formulaire = New System.Windows.Forms.GroupBox()
        Me.Rdio_Btn_rel30 = New System.Windows.Forms.RadioButton()
        Me.Rdio_Btn_rel15 = New System.Windows.Forms.RadioButton()
        Me.GrpBox_fichier = New System.Windows.Forms.GroupBox()
        Me.Btn_parcourir = New System.Windows.Forms.Button()
        Me.Txt_fic_in = New System.Windows.Forms.TextBox()
        Me.Txt_AffPrinc = New System.Windows.Forms.TextBox()
        Me.Btn_lancer = New System.Windows.Forms.Button()
        Me.Btn_annuler = New System.Windows.Forms.Button()
        Me.GrpBox_option = New System.Windows.Forms.GroupBox()
        Me.Rdio_Btn_rel2 = New System.Windows.Forms.RadioButton()
        Me.Rdio_Btn_rel1 = New System.Windows.Forms.RadioButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GrpBox_option2 = New System.Windows.Forms.GroupBox()
        Me.GrpBox_formulaire.SuspendLayout()
        Me.GrpBox_fichier.SuspendLayout()
        Me.GrpBox_option.SuspendLayout()
        Me.GrpBox_option2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_gest
        '
        Me.Txt_gest.Location = New System.Drawing.Point(15, 52)
        Me.Txt_gest.Name = "Txt_gest"
        Me.Txt_gest.Size = New System.Drawing.Size(201, 23)
        Me.Txt_gest.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nom Gestionaire"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Numéro dossier"
        '
        'Txt_doss
        '
        Me.Txt_doss.Location = New System.Drawing.Point(15, 113)
        Me.Txt_doss.Name = "Txt_doss"
        Me.Txt_doss.Size = New System.Drawing.Size(202, 23)
        Me.Txt_doss.TabIndex = 3
        '
        'GrpBox_formulaire
        '
        Me.GrpBox_formulaire.Controls.Add(Me.Txt_doss)
        Me.GrpBox_formulaire.Controls.Add(Me.Label2)
        Me.GrpBox_formulaire.Controls.Add(Me.Label1)
        Me.GrpBox_formulaire.Controls.Add(Me.Txt_gest)
        Me.GrpBox_formulaire.Location = New System.Drawing.Point(21, 12)
        Me.GrpBox_formulaire.Name = "GrpBox_formulaire"
        Me.GrpBox_formulaire.Size = New System.Drawing.Size(232, 162)
        Me.GrpBox_formulaire.TabIndex = 4
        Me.GrpBox_formulaire.TabStop = False
        '
        'Rdio_Btn_rel30
        '
        Me.Rdio_Btn_rel30.AutoSize = True
        Me.Rdio_Btn_rel30.Location = New System.Drawing.Point(16, 47)
        Me.Rdio_Btn_rel30.Name = "Rdio_Btn_rel30"
        Me.Rdio_Btn_rel30.Size = New System.Drawing.Size(98, 19)
        Me.Rdio_Btn_rel30.TabIndex = 5
        Me.Rdio_Btn_rel30.TabStop = True
        Me.Rdio_Btn_rel30.Text = "Relance du 30"
        Me.Rdio_Btn_rel30.UseVisualStyleBackColor = True
        '
        'Rdio_Btn_rel15
        '
        Me.Rdio_Btn_rel15.AutoSize = True
        Me.Rdio_Btn_rel15.Checked = True
        Me.Rdio_Btn_rel15.Location = New System.Drawing.Point(16, 22)
        Me.Rdio_Btn_rel15.Name = "Rdio_Btn_rel15"
        Me.Rdio_Btn_rel15.Size = New System.Drawing.Size(98, 19)
        Me.Rdio_Btn_rel15.TabIndex = 4
        Me.Rdio_Btn_rel15.TabStop = True
        Me.Rdio_Btn_rel15.Text = "Relance du 15"
        Me.Rdio_Btn_rel15.UseVisualStyleBackColor = True
        '
        'GrpBox_fichier
        '
        Me.GrpBox_fichier.Controls.Add(Me.Btn_parcourir)
        Me.GrpBox_fichier.Controls.Add(Me.Txt_fic_in)
        Me.GrpBox_fichier.Location = New System.Drawing.Point(21, 180)
        Me.GrpBox_fichier.Name = "GrpBox_fichier"
        Me.GrpBox_fichier.Size = New System.Drawing.Size(364, 78)
        Me.GrpBox_fichier.TabIndex = 5
        Me.GrpBox_fichier.TabStop = False
        Me.GrpBox_fichier.Text = "Fichier Relance"
        '
        'Btn_parcourir
        '
        Me.Btn_parcourir.Location = New System.Drawing.Point(279, 31)
        Me.Btn_parcourir.Name = "Btn_parcourir"
        Me.Btn_parcourir.Size = New System.Drawing.Size(75, 23)
        Me.Btn_parcourir.TabIndex = 1
        Me.Btn_parcourir.Text = "Parcourir"
        Me.Btn_parcourir.UseVisualStyleBackColor = True
        '
        'Txt_fic_in
        '
        Me.Txt_fic_in.Location = New System.Drawing.Point(16, 32)
        Me.Txt_fic_in.Name = "Txt_fic_in"
        Me.Txt_fic_in.Size = New System.Drawing.Size(257, 23)
        Me.Txt_fic_in.TabIndex = 0
        '
        'Txt_AffPrinc
        '
        Me.Txt_AffPrinc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Txt_AffPrinc.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Txt_AffPrinc.Location = New System.Drawing.Point(37, 275)
        Me.Txt_AffPrinc.Margin = New System.Windows.Forms.Padding(6)
        Me.Txt_AffPrinc.Multiline = True
        Me.Txt_AffPrinc.Name = "Txt_AffPrinc"
        Me.Txt_AffPrinc.ReadOnly = True
        Me.Txt_AffPrinc.ShortcutsEnabled = False
        Me.Txt_AffPrinc.Size = New System.Drawing.Size(254, 97)
        Me.Txt_AffPrinc.TabIndex = 6
        Me.Txt_AffPrinc.TabStop = False
        Me.Txt_AffPrinc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_lancer
        '
        Me.Btn_lancer.Location = New System.Drawing.Point(300, 285)
        Me.Btn_lancer.Name = "Btn_lancer"
        Me.Btn_lancer.Size = New System.Drawing.Size(75, 52)
        Me.Btn_lancer.TabIndex = 7
        Me.Btn_lancer.Text = "Lancer"
        Me.Btn_lancer.UseVisualStyleBackColor = True
        '
        'Btn_annuler
        '
        Me.Btn_annuler.Location = New System.Drawing.Point(300, 343)
        Me.Btn_annuler.Name = "Btn_annuler"
        Me.Btn_annuler.Size = New System.Drawing.Size(75, 23)
        Me.Btn_annuler.TabIndex = 8
        Me.Btn_annuler.Text = "Annuler"
        Me.Btn_annuler.UseVisualStyleBackColor = True
        '
        'GrpBox_option
        '
        Me.GrpBox_option.Controls.Add(Me.Rdio_Btn_rel2)
        Me.GrpBox_option.Controls.Add(Me.Rdio_Btn_rel1)
        Me.GrpBox_option.Location = New System.Drawing.Point(259, 12)
        Me.GrpBox_option.Name = "GrpBox_option"
        Me.GrpBox_option.Size = New System.Drawing.Size(126, 75)
        Me.GrpBox_option.TabIndex = 9
        Me.GrpBox_option.TabStop = False
        Me.GrpBox_option.Text = "Option"
        '
        'Rdio_Btn_rel2
        '
        Me.Rdio_Btn_rel2.AutoSize = True
        Me.Rdio_Btn_rel2.Location = New System.Drawing.Point(16, 50)
        Me.Rdio_Btn_rel2.Name = "Rdio_Btn_rel2"
        Me.Rdio_Btn_rel2.Size = New System.Drawing.Size(75, 19)
        Me.Rdio_Btn_rel2.TabIndex = 1
        Me.Rdio_Btn_rel2.Text = "Relance 2"
        Me.Rdio_Btn_rel2.UseVisualStyleBackColor = True
        '
        'Rdio_Btn_rel1
        '
        Me.Rdio_Btn_rel1.AutoSize = True
        Me.Rdio_Btn_rel1.Checked = True
        Me.Rdio_Btn_rel1.Location = New System.Drawing.Point(16, 22)
        Me.Rdio_Btn_rel1.Name = "Rdio_Btn_rel1"
        Me.Rdio_Btn_rel1.Size = New System.Drawing.Size(75, 19)
        Me.Rdio_Btn_rel1.TabIndex = 0
        Me.Rdio_Btn_rel1.TabStop = True
        Me.Rdio_Btn_rel1.Text = "Relance 1"
        Me.Rdio_Btn_rel1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GrpBox_option2
        '
        Me.GrpBox_option2.Controls.Add(Me.Rdio_Btn_rel30)
        Me.GrpBox_option2.Controls.Add(Me.Rdio_Btn_rel15)
        Me.GrpBox_option2.Location = New System.Drawing.Point(259, 87)
        Me.GrpBox_option2.Name = "GrpBox_option2"
        Me.GrpBox_option2.Size = New System.Drawing.Size(126, 87)
        Me.GrpBox_option2.TabIndex = 10
        Me.GrpBox_option2.TabStop = False
        '
        'Form_vue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 401)
        Me.Controls.Add(Me.GrpBox_option2)
        Me.Controls.Add(Me.GrpBox_option)
        Me.Controls.Add(Me.Btn_annuler)
        Me.Controls.Add(Me.Btn_lancer)
        Me.Controls.Add(Me.Txt_AffPrinc)
        Me.Controls.Add(Me.GrpBox_fichier)
        Me.Controls.Add(Me.GrpBox_formulaire)
        Me.Name = "Form_vue"
        Me.Text = "Relance GROUPAMA IMMO"
        Me.GrpBox_formulaire.ResumeLayout(False)
        Me.GrpBox_formulaire.PerformLayout()
        Me.GrpBox_fichier.ResumeLayout(False)
        Me.GrpBox_fichier.PerformLayout()
        Me.GrpBox_option.ResumeLayout(False)
        Me.GrpBox_option.PerformLayout()
        Me.GrpBox_option2.ResumeLayout(False)
        Me.GrpBox_option2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txt_gest As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_doss As TextBox
    Friend WithEvents GrpBox_formulaire As GroupBox
    Friend WithEvents GrpBox_fichier As GroupBox
    Friend WithEvents Btn_parcourir As Button
    Friend WithEvents Txt_fic_in As TextBox
    Friend WithEvents Txt_AffPrinc As TextBox
    Friend WithEvents Btn_lancer As Button
    Friend WithEvents Btn_annuler As Button
    Friend WithEvents GrpBox_option As GroupBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Rdio_Btn_rel2 As RadioButton
    Friend WithEvents Rdio_Btn_rel1 As RadioButton
    Friend WithEvents Rdio_Btn_rel30 As RadioButton
    Friend WithEvents Rdio_Btn_rel15 As RadioButton
    Friend WithEvents GrpBox_option2 As GroupBox
End Class
