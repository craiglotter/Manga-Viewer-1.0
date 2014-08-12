Imports System
Imports System.IO

Public Class OpenFolderDialog
    Inherits System.Windows.Forms.Form
    Public selectstate As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents selectedtree As System.Windows.Forms.TreeView
    Friend WithEvents selecteddrive As System.Windows.Forms.ComboBox
    Public WithEvents selectedpath As System.Windows.Forms.TextBox
    Friend WithEvents selectbutton1 As System.Windows.Forms.Button
    Friend WithEvents cancelbutton1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.selectedtree = New System.Windows.Forms.TreeView()
        Me.selecteddrive = New System.Windows.Forms.ComboBox()
        Me.selectedpath = New System.Windows.Forms.TextBox()
        Me.selectbutton1 = New System.Windows.Forms.Button()
        Me.cancelbutton1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'selectedtree
        '
        Me.selectedtree.ImageIndex = -1
        Me.selectedtree.Location = New System.Drawing.Point(32, 48)
        Me.selectedtree.Name = "selectedtree"
        Me.selectedtree.SelectedImageIndex = -1
        Me.selectedtree.Size = New System.Drawing.Size(392, 368)
        Me.selectedtree.Sorted = True
        Me.selectedtree.TabIndex = 0
        '
        'selecteddrive
        '
        Me.selecteddrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.selecteddrive.Location = New System.Drawing.Point(32, 16)
        Me.selecteddrive.MaxDropDownItems = 15
        Me.selecteddrive.Name = "selecteddrive"
        Me.selecteddrive.Size = New System.Drawing.Size(136, 21)
        Me.selecteddrive.Sorted = True
        Me.selecteddrive.TabIndex = 1
        '
        'selectedpath
        '
        Me.selectedpath.Location = New System.Drawing.Point(32, 432)
        Me.selectedpath.Name = "selectedpath"
        Me.selectedpath.Size = New System.Drawing.Size(392, 20)
        Me.selectedpath.TabIndex = 2
        Me.selectedpath.Text = ""
        '
        'selectbutton1
        '
        Me.selectbutton1.Location = New System.Drawing.Point(160, 464)
        Me.selectbutton1.Name = "selectbutton1"
        Me.selectbutton1.TabIndex = 3
        Me.selectbutton1.Text = "Select"
        '
        'cancelbutton1
        '
        Me.cancelbutton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelbutton1.Location = New System.Drawing.Point(248, 464)
        Me.cancelbutton1.Name = "cancelbutton1"
        Me.cancelbutton1.TabIndex = 4
        Me.cancelbutton1.Text = "Cancel"
        '
        'OpenFolderDialog
        '
        Me.AcceptButton = Me.selectbutton1
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 493)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cancelbutton1, Me.selectbutton1, Me.selectedpath, Me.selecteddrive, Me.selectedtree})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OpenFolderDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select a Folder to Scan From"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub OpenFolderDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fso As New Scripting.FileSystemObject(), drv As Scripting.Drive
        Dim drivelisting As IEnumerator = fso.Drives.GetEnumerator()
        selecteddrive.Items.Clear()
        Dim firstharddrive As Integer = -1
        Dim counter As Integer = 0

        selectstate = False

        While (drivelisting.MoveNext())
            drv = drivelisting.Current()

            ' selecteddrive.Items.Add(drv.Path & "   [" & drv.DriveType.ToString & "]")
            selecteddrive.Items.Add(drv.Path)
            If firstharddrive = -1 Then
                If drv.DriveType = Scripting.DriveTypeConst.Fixed Then firstharddrive = counter
            End If
            counter = counter + 1
        End While


        drivelisting.Reset()

        selectedtree.Nodes.Add("c:\")

        Dim currentnode As TreeNode
        currentnode = selectedtree.Nodes(0)
        ProcessPath(currentnode.FullPath, currentnode)

        If firstharddrive = -1 Then
            selecteddrive.SelectedIndex = 0
        Else
            selecteddrive.SelectedIndex = firstharddrive
        End If
    End Sub

    Public Sub ProcessPath(ByVal inputpath As String, ByVal currentnode As TreeNode)
        Dim path As String
        path = inputpath

        If Directory.Exists(path) Then
            ' This path is a directory
            ProcessDirectory(path, currentnode, 0)

        End If

    End Sub 'Main


    ' Process all files in the directory passed in, and recurse on any directories 
    ' that are found to process the files they contain

    Public Sub ProcessDirectory(ByVal targetDirectory As String, ByVal currentnode As TreeNode, ByVal initialised As Integer)

        Dim childnode As TreeNode
        If Not initialised = 0 Then

            currentnode.Nodes.Add(New System.Windows.Forms.TreeNode(targetDirectory.Remove(0, (targetDirectory.LastIndexOf("\") + 1))))
            childnode = currentnode.LastNode()

        Else
            childnode = currentnode
        End If
        initialised = initialised + 1


        Try

            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            ' Recurse into subdirectories of this directory
            If initialised < 3 Then
                Dim subdirectory As String
                For Each subdirectory In subdirectoryEntries
                    'ProcessDirectory(subdirectory, childnode, initialised)
                    ProcessDirectory(subdirectory, childnode, 4)
                Next subdirectory
            End If
        Catch e As Exception
        End Try
    End Sub 'ProcessDirectory

    Private Sub selectedtree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles selectedtree.AfterSelect

        Dim currentnode As TreeNode
        currentnode = selectedtree.SelectedNode


        If Not currentnode Is selectedtree.TopNode And currentnode.GetNodeCount(False) = 0 Then

            ProcessPath(currentnode.FullPath, currentnode)
        End If
        selectedpath.Text = currentnode.FullPath.Replace("\\", "\")


    End Sub

    Private Sub handle_expand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles selectedtree.AfterExpand
        Dim currentnode As TreeNode
        currentnode = e.Node
        While Not currentnode Is e.Node.NextNode()
            selectedtree.SelectedNode = currentnode.NextVisibleNode
            currentnode = currentnode.NextVisibleNode()
        End While
        selectedtree.SelectedNode = e.Node
    End Sub

    Private Sub selecteddrive_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selecteddrive.SelectedIndexChanged

        selectedtree.Nodes.Clear()

        selectedtree.Nodes.Add(LCase(selecteddrive.SelectedItem() & "\"))
        'selectedtree.Nodes.Add(LCase(selecteddrive.SelectedItem()))

        Dim currentnode As TreeNode
        currentnode = selectedtree.Nodes(0)

        ProcessPath(currentnode.Text, currentnode)
        selectedpath.Text = currentnode.Text
    End Sub

    Private Sub selectbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectbutton1.Click
        selectstate = True
        Me.Hide()
    End Sub

    Private Sub cancelbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelbutton1.Click
        selectstate = False
        Me.Hide()
    End Sub
End Class
