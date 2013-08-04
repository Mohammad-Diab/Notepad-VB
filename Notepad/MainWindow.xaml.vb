Imports System.Windows.Forms
Imports System.IO
Imports System.Text

Class MainWindow
    Dim BWriter As BinaryWriter
    Dim BReader As BinaryReader
    Dim OFD As New OpenFileDialog
    Dim SFD As New SaveFileDialog
    Dim SW As StreamWriter
    Dim SR As StreamReader
    Dim Path As String
    Dim x As Boolean = False

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        SFD.Filter = "Documents Text (*.txt)|*.txt|Batch File (*.bat)|*.bat"
        OFD.Filter = "Text file|*.txt|Batch file|*.bat|Hyper Text Markup Language file|*.html;*.htm;*.shtml;*.shtm;*.xhtml;*.hta|MS ini file|*.ini;*.inf;*.reg;*.url|PHP Hypertext Preprocesser file|*.php;*.php3;*.phtml|eXtensible Markup Language file|*.xml;*.xsml;*.xsl;*.xsd;*.kml;*.wsdl|All files|*.*"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        If OFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                Path = OFD.FileName
                SR = New StreamReader(Path)
                TextBox1.Text = SR.ReadToEnd
                SR.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            End Try
        End If
        TextBox1.VerticalScrollBarVisibility = ScrollBarVisibility.Visible
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim Encode As Encoding
        Select Case ComboBox1.SelectedIndex
            Case 0
                Encode = Encoding.ASCII
            Case 1
                Encode = Encoding.BigEndianUnicode
            Case 2
                Encode = Encoding.Unicode
            Case 3
                Encode = Encoding.UTF32
            Case 4
                Encode = Encoding.UTF7
            Case 5
                Encode = Encoding.UTF8
            Case Else
                Encode = Encoding.ASCII
        End Select
        If SFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Path = SFD.FileName
            SW = New StreamWriter(Path, False, Encode)
            SW.Write(TextBox1.Text)
            SW.Close()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button3.Click
        If (Not TextBox1.Text = "") Then
            If (MessageBox.Show("Are you shore?", "Notpad", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(Windows.Forms.DialogResult.Yes)) Then
                TextBox1.Text = ""
            End If
        End If
    End Sub

    Private Sub TextBox1_Drop(sender As Object, e As Windows.DragEventArgs) Handles TextBox1.Drop, TextBox1.DragEnter, TextBox1.DragLeave
        Dim Encode As Encoding
        Select Case ComboBox1.SelectedIndex
            Case 0
                Encode = Encoding.ASCII
            Case 1
                Encode = Encoding.BigEndianUnicode
            Case 2
                Encode = Encoding.Unicode
            Case 3
                Encode = Encoding.UTF32
            Case 4
                Encode = Encoding.UTF7
            Case 5
                Encode = Encoding.UTF8
            Case Else
                Encode = Encoding.ASCII
        End Select
        Path = SFD.FileName
        SW = New StreamWriter(Path, False, Encode)
        SW.Write(TextBox1.Text)
        SW.Close()
    End Sub

    Private Sub Grid_Drop_1(sender As Object, e As Windows.DragEventArgs)
        Path = SFD.FileName
        SW = New StreamWriter(Path)
        SW.Write(TextBox1.Text)
        SW.Close()
    End Sub

    Private Sub ComboBox1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ComboBox1.SelectionChanged
        If (Not Path = "") Then
            Dim Encode As Encoding
            Select Case ComboBox1.SelectedIndex
                Case 0
                    Encode = Encoding.ASCII
                Case 1
                    Encode = Encoding.BigEndianUnicode
                Case 2
                    Encode = Encoding.Unicode
                Case 3
                    Encode = Encoding.UTF32
                Case 4
                    Encode = Encoding.UTF7
                Case 5
                    Encode = Encoding.UTF8
                Case Else
                    Encode = Encoding.ASCII
            End Select
            If (x) Then
                Path = OFD.FileName
                SW = New StreamWriter(Path, False, Encode)
                SW.Write(TextBox1.Text)
                SW.Close()
            End If
            x = True
        End If
    End Sub

    Private Sub New_Click_Click(sender As Object, e As RoutedEventArgs) Handles New_Click.Click
        Dim window As MainWindow = New MainWindow()
        window.Show()
    End Sub

    Private Sub Font_Click_Click(sender As Object, e As RoutedEventArgs) Handles Font_Click.Click

    End Sub
End Class
