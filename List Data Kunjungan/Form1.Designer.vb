Imports System.IO

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form
    Private listMhs As New List(Of String)
    Private nomor As Integer = 1

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Button1 = New Button()
        ToolTip1 = New ToolTip(components)
        nameTxt = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        universityTxt = New TextBox()
        Label3 = New Label()
        tlpTxt = New TextBox()
        List = New ListBox()
        Label4 = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(322, 127)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "Simpan"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' nameTxt
        ' 
        nameTxt.Location = New Point(115, 47)
        nameTxt.Name = "nameTxt"
        nameTxt.Size = New Size(174, 23)
        nameTxt.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.0F)
        Label1.Location = New Point(33, 48)
        Label1.Name = "Label1"
        Label1.Size = New Size(45, 19)
        Label1.TabIndex = 2
        Label1.Text = "Nama"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.0F)
        Label2.Location = New Point(33, 88)
        Label2.Name = "Label2"
        Label2.Size = New Size(76, 19)
        Label2.TabIndex = 4
        Label2.Text = "Universitas"
        ' 
        ' universityTxt
        ' 
        universityTxt.Location = New Point(115, 88)
        universityTxt.Name = "universityTxt"
        universityTxt.Size = New Size(174, 23)
        universityTxt.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.0F)
        Label3.Location = New Point(33, 127)
        Label3.Name = "Label3"
        Label3.Size = New Size(52, 19)
        Label3.TabIndex = 6
        Label3.Text = "No. Tlp"
        ' 
        ' tlpTxt
        ' 
        tlpTxt.Location = New Point(115, 126)
        tlpTxt.Name = "tlpTxt"
        tlpTxt.Size = New Size(174, 23)
        tlpTxt.TabIndex = 5
        ' 
        ' List
        ' 
        List.FormattingEnabled = True
        List.ItemHeight = 15
        List.Location = New Point(33, 186)
        List.Name = "List"
        List.Size = New Size(364, 124)
        List.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 15.0F)
        Label4.Location = New Point(56, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(330, 28)
        Label4.TabIndex = 8
        Label4.Text = "List Daftar Pengunjung Perpustakaan"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(537, 330)
        Controls.Add(Label4)
        Controls.Add(List)
        Controls.Add(Label3)
        Controls.Add(tlpTxt)
        Controls.Add(Label2)
        Controls.Add(universityTxt)
        Controls.Add(Label1)
        Controls.Add(nameTxt)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents nameTxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents universityTxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tlpTxt As TextBox
    Friend WithEvents List As ListBox
    Friend WithEvents Label4 As Label

    Private Sub readText()
        If File.Exists("List.txt") Then
            listMhs.Clear()
            List.Items.Clear()
            Using reader As New StreamReader("List.txt")
                Dim line As String
                Do
                    line = reader.ReadLine()
                    If line IsNot Nothing Then
                        nomor += 1
                        listMhs.Add(line)
                        List.Items.Add(line)
                    End If
                Loop Until line Is Nothing
            End Using
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        listMhs.Add($"{nomor}. {nameTxt.Text} - {universityTxt.Text} - {tlpTxt.Text}")
        nameTxt.Clear()
        universityTxt.Clear()
        tlpTxt.Clear()
        List.Items.Clear()
        Using writer As New StreamWriter("List.txt")
            For Each daftar As String In listMhs
                nomor += 1
                writer.WriteLine(daftar)
                List.Items.Add(daftar)
            Next
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        readText()
    End Sub
End Class
