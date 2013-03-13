Imports System.IO.StreamReader
Imports System.IO.StreamWriter
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing.Printing
Public Class MainWindow
    Dim text As String
    Dim ofd As New OpenFileDialog
    Dim sfd As New SaveFileDialog
    Dim cd As New ColorDialog
    Dim fd As New FontDialog
    Dim sr As StreamReader
    Dim sw As StreamWriter
    Dim PD As New PrintDialog
    Dim str As String
    Dim computer As Integer
    Dim Search_Counter As Boolean = False
    Dim Replace_Counter As Boolean = False
    Dim Bol As Boolean = False
    Dim size2 As New System.Windows.Size
    Dim ppd As New PrintPreviewDialog
    Dim p_d As New PrintDialog
    Dim Pdoc As New PrintDocument

    Sub Enregistrer()
        sw = New StreamWriter(text)
        sw.Write(Me.RichTextBox1.Text)
        sw.Close()
        sr = New StreamReader(text)
        RichTextBox1.Text = sr.ReadToEnd
        sr.Close()
    End Sub

    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub RibbonWindow_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        RibbonRadioButton1.IsChecked = True
        sfd.Filter = "Documents Text (*.Txt)|*.txt|Batch File (*.bat)|*.bat"
        ofd.Filter = "Text file|*.txt|Batch file|*.bat|Hyper Text Markup Language file|*.html;*.htm;*.shtml;*.shtm;*.xhtml;*.hta|MS ini file|*.ini;*.inf;*.reg;*.url|PHP Hypertext Preprocesser file|*.php;*.php3;*.phtml|eXtensible Markup Language file|*.xml;*.xsml;*.xsl;*.xsd;*.kml;*.wsdl|All files|*.*"
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles MenuItem1.Click
        If RichTextBox1.Text <> String.Empty Then
            Dim Reponse As String = MsgBox("هل تريد حفظ التغيرات على المستند", MsgBoxStyle.YesNoCancel, "تأكيد")
        If Reponse = 6 Then
                If text = String.Empty Then
                    If sfd.ShowDialog = True Then
                        text = sfd.FileName
                        Enregistrer()
                        Me.RichTextBox1.Clear()
                    Else
                    End If
                End If
            ElseIf Reponse = 7 Then
                Me.RichTextBox1.Clear()
            End If
        End If
    End Sub

    Private Sub MenuItem2_Click1(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles MenuItem2.Click
        If ofd.ShowDialog = True Then
            text = ofd.FileName
            sr = New StreamReader(text)
            Me.RichTextBox1.Text = sr.ReadToEnd
            sr.Close()
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles MenuItem4.Click
        If sfd.ShowDialog = True Then
            Enregistrer()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Me.RichTextBox1.Undo()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Me.RichTextBox1.Redo()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button3.Click
        Dim X As MessageBoxResult = MsgBox("هل أنت متأكد", MsgBoxStyle.OkCancel, "مسح النص")
        If X = MsgBoxResult.Ok Then
            Me.RichTextBox1.Clear()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button4.Click
        Me.RichTextBox1.Paste()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button5.Click
        Me.RichTextBox1.Cut()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button6.Click
        Me.RichTextBox1.Copy()
    End Sub

    Sub Search()
        Dim found As Boolean = False
        str = ""
        str = InputBox("أدخل كلمة للبحث :  ")
        If str = "" Then
        Else
        For Compteur As Integer = 0 To RichTextBox1.Text.Length - str.Length
            If RichTextBox1.Text.Substring(Compteur, str.Length) = str Then
                RichTextBox1.SelectionStart = Compteur
                RichTextBox1.SelectionLength = str.Length
                found = True
                Search_Counter = True
                Exit For
            End If
        Next
        If (found = False) Then
            MsgBox("الكلمة غير موجودة", MsgBoxStyle.Exclamation, "خطأ")
            End If
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button8.Click
        Search()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button10.Click
        str = ""
        str = InputBox("أدخل كلمة للبحث :  ")
        Dim found As Boolean = False
        If str = "" Then
        Else
            Dim str2 As String = ""
            str2 = InputBox("أدخل الكلمة الجديدة : ")
            If str2 = "" Then
            Else
                For Compteur As Integer = 0 To RichTextBox1.Text.Length - str.Length
                    If RichTextBox1.Text.Substring(Compteur, str.Length) = str Then
                        RichTextBox1.SelectionStart = Compteur
                        RichTextBox1.SelectionLength = str.Length
                        RichTextBox1.SelectedText = str2
                        found = True
                        Replace_Counter = True
                        Exit For
                    End If
                Next
                If (found = False) Then
                    MsgBox("الكلمة غير موجودة", MsgBoxStyle.Exclamation, "خطأ")
                End If
            End If
        End If
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button19.Click
        Dim found_num As Integer = 0
        Dim computer As Integer = 0
            str = ""
            str = InputBox("أدخل كلمة للبحث :  ")
                Dim found As Boolean = False
                If str = "" Then
                Else
                    Dim str2 As String = ""
                    str2 = InputBox("أدخل الكلمة الجديدة : ")
                    If str2 = "" Then
                Else
                    For Compteur As Integer = Compteur To RichTextBox1.Text.Length - str.Length
                        For ReplaceFound As Integer = 0 To RichTextBox1.Text.Length - str.Length
                            If RichTextBox1.Text.Substring(Compteur, str.Length) = str Then
                                RichTextBox1.SelectionStart = Compteur
                                RichTextBox1.SelectionLength = str.Length
                                RichTextBox1.SelectedText = str2
                                found = True
                                Replace_Counter = True
                                Compteur = Compteur
                                found_num = found_num + 1
                                Exit For
                            End If
                        Next
                    Next
                    If (found = False) Then
                        MsgBox("الكلمة غير موجودة", MsgBoxStyle.Exclamation, "خطأ")
                Else
                    Dim found_str As String = found_num
                    Dim found_num1 As String = "تم اجراء " + found_str + " استبدال"
                    MsgBox(found_num1, MsgBoxStyle.Information, "تم")
                    End If
                    End If
                End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button11.Click
        Me.RichTextBox1.SelectedText = Date.Now.ToString
    End Sub

    Private Sub Button18_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button18.Click
        Try
            Dim line As String = ""
            line = InputBox("أدخل رقم السطر : ", "عودة الى السطر")
            If (line = "") Then
            Else
                RichTextBox1.ScrollToLine(line)
            End If
        Catch ex As Exception
            MsgBox("لقد أدخلت رقم غير صالح", MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

    Private Sub RibbonCheckBox1_Click1(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles RibbonCheckBox1.Click
        If RibbonCheckBox1.IsChecked = True Then
            RichTextBox1.TextWrapping = TextWrapping.Wrap
        Else
            RichTextBox1.TextWrapping = TextWrapping.NoWrap
        End If
    End Sub

    Private Sub Button20_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button20.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub RibbonCheckBox2_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles RibbonCheckBox2.Click
        If RibbonCheckBox2.IsChecked = True Then
            RichTextBox1.FontWeight = FontWeights.Bold
        Else
            RichTextBox1.FontWeight = FontWeights.Normal
        End If
    End Sub

    Private Sub RibbonCheckBox3_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles RibbonCheckBox3.Click
        If RibbonCheckBox2.IsChecked = True Then
            RichTextBox1.FontStyle = FontStyles.Italic
        Else
            RichTextBox1.FontStyle = FontStyles.Normal
        End If
    End Sub

    Private Sub RibbonCheckBox4_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles RibbonCheckBox4.Click
        If RibbonCheckBox2.IsChecked = True Then
            RichTextBox1.TextDecorations = TextDecorations.Underline
        Else
            RichTextBox1.TextDecorations = TextDecorations.Baseline
        End If
    End Sub

    Sub alliment()
        If (RibbonRadioButton1.IsChecked = True) Then
            Me.RichTextBox1.TextAlignment = TextAlignment.Left
        ElseIf (RibbonRadioButton2.IsChecked = True) Then
            Me.RichTextBox1.TextAlignment = TextAlignment.Center
        ElseIf (RibbonRadioButton3.IsChecked = True) Then
            Me.RichTextBox1.TextAlignment = TextAlignment.Right
        End If
    End Sub

    Private Sub RibbonRadioButton1_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles RibbonRadioButton1.Click
        RibbonRadioButton1.IsChecked = True
        alliment()
    End Sub

    Private Sub RibbonRadioButton2_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles RibbonRadioButton2.Click
        RibbonRadioButton2.IsChecked = True
        alliment()
    End Sub

    Private Sub RibbonRadioButton3_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles RibbonRadioButton3.Click
        RibbonRadioButton3.IsChecked = True
        alliment()
    End Sub

    Private Sub Button12_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button12.Click
        If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim new_font As System.Drawing.Font = fd.Font
            RichTextBox1.FontFamily = New FontFamily(new_font.Name)
            RichTextBox1.FontSize = new_font.Size
            If new_font.Bold = True Then
                RichTextBox1.FontWeight = FontWeights.Bold
                RibbonCheckBox2.IsChecked = True
            Else
                RichTextBox1.FontWeight = FontWeights.Regular
                RibbonCheckBox2.IsChecked = False
            End If
            If (new_font.Italic = True) Then
                RichTextBox1.FontStyle = FontStyles.Italic
                RibbonCheckBox3.IsChecked = True
            Else
                RichTextBox1.FontStyle = FontStyles.Normal
                RibbonCheckBox3.IsChecked = True
            End If
            If new_font.Underline = True Then
                RichTextBox1.TextDecorations = TextDecorations.Underline
                RibbonCheckBox4.IsChecked = True
            Else
                RichTextBox1.TextDecorations = TextDecorations.Baseline
                RibbonCheckBox4.IsChecked = True
            End If
            If new_font.Strikeout = True Then
                RichTextBox1.TextDecorations = TextDecorations.Strikethrough
            Else
                RichTextBox1.TextDecorations = TextDecorations.Baseline
            End If
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button16.Click
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim new_color As System.Drawing.Color = cd.Color
        End If
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles MenuItem5.Click
        ppd.ShowDialog()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles MenuItem6.Click
        PD.Document = Pdoc
        PD.PrinterSettings = Pdoc.PrinterSettings
        PD.AllowSomePages = True
        If PD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Pdoc.Print()
        End If
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles MenuItem7.Click
        MsgBox("برنامج المفكرة" & vbCrLf & "الاصدار الأول " & vbCrLf & "تم تصميمه بواسطة  : The Legend Mohammad", MsgBoxStyle.Information, "About")
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles MenuItem8.Click
        If RichTextBox1.Text <> String.Empty Then
            Dim Reponse As String = MsgBox("هل تريد حفظ التغيرات على المستند", MsgBoxStyle.YesNoCancel, "تأكيد")
            If Reponse = 6 Then
                If text = String.Empty Then
                    If sfd.ShowDialog = True Then
                        text = sfd.FileName
                        Enregistrer()
                        Me.Close()
                    Else
                        Enregistrer()
                        Me.Close()
                    End If
                End If
            ElseIf Reponse = 7 Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button9.Click
        If Search_Counter = True Then
            Dim f As Integer
            f = InStr(RichTextBox1.SelectionStart + 2, RichTextBox1.Text, str) - 1
            If f = -1 Then
                MsgBox("الكلمة غير موجودة", MsgBoxStyle.Exclamation, "نتائج البحث")
            Else
                RichTextBox1.SelectionStart = f
                RichTextBox1.SelectionLength = str.Length
            End If
        Else
            Search()
        End If
    End Sub
End Class