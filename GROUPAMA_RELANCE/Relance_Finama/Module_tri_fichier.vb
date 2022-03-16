Imports System.Text
Imports System.IO

Module Module_tri_fichier

    Public fic_fusion_echeance As String
    Public list_fic_echeance As New List(Of String)

    Public Function tri_sur_cp(ByVal fic_in)

        Dim fic_entree As String = fic_in
        Dim fic_sortie As String = rep_travail & Path.GetFileNameWithoutExtension(fic_entree) & date_fic_echeance & "_temp"
        Dim ligne As String
        Dim espace As String = "                                                                                                                                "

        Dim list_ligne As New List(Of String)
        Dim list_code_postaux As New List(Of String) 'liste qui récupre les cp et num_ref
        Dim list_cible_ecrite As New List(Of String) 'liste de cible déja sortie pour evité les doublons

        Dim fin_cible As Boolean = False
        Dim encode As Encoding

        Dim code_postal As String
        Dim num_ref As String = ""

        Dim Files As String() = System.IO.Directory.GetFiles(rep_travail)
        Dim str = New StreamReader(fic_entree, detectEncodingFromByteOrderMarks:=False)

        encode = str.CurrentEncoding

        'recupère un liste des cp et num_ref pour le tri
        Do Until str.EndOfStream

            ligne = str.ReadLine

            If Mid(ligne, 1, 2) = "I3" Or Mid(ligne, 2, 2) = "I3" Then : fin_cible = True : End If

            If Mid(ligne, 1, 2) = "A8" Or Mid(ligne, 2, 2) = "A8" Then
                num_ref = Trim(Mid(ligne, 62, 30))
            ElseIf Mid(ligne, 1, 2) = "B5" Then
                code_postal = Mid(ligne, 50, 5)
                list_code_postaux.Add(code_postal & ";" & num_ref)
            ElseIf fin_cible = True Then
                fin_cible = False
            End If
        Loop

        list_code_postaux.Sort()

        str.Close()

        code_postal = ""
        num_ref = ""

        'trie le fichier depuis la liste de code postaux et numero de reference
        Dim stw As New StreamWriter(fic_sortie, False, Encoding.Latin1)

        For index_total As Integer = 0 To list_code_postaux.Count - 1

            str = New StreamReader(fic_entree, encode)

            Dim ref_tri() As String = Split(list_code_postaux(index_total), ";")

            Do Until str.EndOfStream

                ligne = str.ReadLine

                If Mid(ligne, 1, 2) = "I3" Or Mid(ligne, 2, 2) = "I3" Then
                    fin_cible = True
                End If
                'si la ligne en lecture ne marque pas la fin de cible
                If fin_cible = False Then
                    If Mid(ligne, 1, 2) = "A8" Or Mid(ligne, 2, 2) = "A8" Then
                        num_ref = Trim(Mid(ligne, 62, 30))
                        list_ligne.Add(ligne)
                    ElseIf Mid(ligne, 1, 2) = "B5" Then
                        list_ligne.Add(ligne)
                        code_postal = Mid(ligne, 50, 5)
                    ElseIf Mid(ligne, 1, 2) <> "  " Then
                        list_ligne.Add(ligne)
                    End If
                End If
                'si la ligne en lecture marque la fin de cible
                If fin_cible = True Then
                    'list_ligne.Add(Left(ligne.Replace("N?", "N°").Replace(" ? ", " à ").Replace("?", "é") & espace, 128))
                    list_ligne.Add(Left(ligne & espace, 128))

                    'compare la liste triée et le cp et num_ref de la cible en cours de lecture
                    If (ref_tri(0) = code_postal And ref_tri(1) = num_ref And list_cible_ecrite.Contains(num_ref) = False) Then
                        Dim str_next As New StreamReader(fic_entree, encode)
                        Dim ligne_next As String
                        ligne_next = str.ReadLine()

                        'recupère la ligne I5 pas tous le temps présente
                        If Mid(ligne_next, 1, 2) = "I3" Or Mid(ligne_next, 2, 2) = "I3" Then
                            list_ligne.Add(ligne_next)
                            str_next.Close()
                        End If

                        'ecrit dans le fichier la liste contenant la cible
                        For i As Integer = 0 To list_ligne.Count - 1
                            stw.WriteLine(Left((Trim(list_ligne(i)).Replace("N�", "N°").Replace(" � ", " à ").Replace("�", "é")) & espace, 128))
                        Next

                        list_cible_ecrite.Add(num_ref)
                        num_ref = ""
                        code_postal = ""
                        list_ligne.Clear()
                        fin_cible = False
                    Else
                        fin_cible = False
                        list_ligne.Clear()
                    End If
                End If
            Loop
        Next

        stw.Close()
        str.Close()

        Return fic_sortie

    End Function


    Public Function formatage_dialogue(ByVal fic_in) 'regroupe les cibles avec des num_ref identiques pour éviter le changment de cible (page) prévut dans le fichier d'origine

        Dim fic_entree As String = fic_in
        Dim fic_sortie_diag As String = rep_travail & Path.GetFileNameWithoutExtension(fic_entree) & date_fic_echeance
        Dim espace As String = "                                                                                                                                "
        Dim ligne As String
        Dim list_ligne As New List(Of String)
        Dim tabstr() As String

        Dim balise_en_cours As String = ""
        Dim balise_prec As String = ""
        Dim num_ref_en_cours As String = ""
        Dim num_ref_prec As String = ""

        Dim Files As String() = System.IO.Directory.GetFiles(rep_travail)
        Dim str = New StreamReader(fic_entree)
        Dim stw As New StreamWriter(fic_sortie_diag, False, Encoding.Latin1)

        Do Until str.EndOfStream

            ligne = str.ReadLine

            If Mid(ligne, 1, 2) = "00" Or Mid(ligne, 2, 2) = "00" Then
                tabstr = Split(ligne, ";")
                num_ref_prec = num_ref_en_cours
                num_ref_en_cours = tabstr(14)
            End If
            If num_ref_prec <> num_ref_en_cours Then
                list_ligne.Add(ligne)
            ElseIf num_ref_prec = num_ref_en_cours Then
                balise_prec = balise_en_cours
                balise_en_cours = Mid(ligne, 1, 1).ToString
                If balise_en_cours = "E" Or balise_en_cours = "T" Or balise_en_cours = "I" Then
                    list_ligne.Add(ligne)
                End If
            End If
        Loop

        For i = 0 To list_ligne.Count - 1
            stw.WriteLine(Left((Trim(list_ligne(i)).Replace("N�", "N°").Replace(" � ", " à ").Replace("�", "é")) & espace, 128))
        Next

        str.Close()
        stw.Close()

        Return fic_sortie_diag

    End Function


End Module
