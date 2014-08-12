Option Explicit On 

Imports System
Imports System.IO
Imports System.Math
Imports Microsoft.Win32


Public Class Manga_Viewer
    Inherits System.Windows.Forms.Form

    Private reg_last_path As String
    Private reg_last_image As String
    Private reg_zoom_percentage As Integer
    Private reg_view_toolbar As Boolean
    Private reg_view_folderlist As Boolean
    Private reg_fit_to_screen As Boolean

    

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        reg_last_path = ""
        reg_last_image = ""
        reg_zoom_percentage = 100
        reg_view_toolbar = True
        reg_view_folderlist = True
        reg_fit_to_screen = False

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
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents current_path As System.Windows.Forms.Label
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents filetree As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents mangascan As System.Windows.Forms.PictureBox
    Friend WithEvents selectedtree As System.Windows.Forms.TreeView
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Manga_Viewer_Toolbar As System.Windows.Forms.ToolBar
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents current_image_label As System.Windows.Forms.Label
    Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBarButton8 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton9 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton10 As System.Windows.Forms.ToolBarButton
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBarButton11 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton12 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton13 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Percentage_label As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Manga_Viewer))
        Me.Manga_Viewer_Toolbar = New System.Windows.Forms.ToolBar
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton11 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton6 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton12 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton10 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton8 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton9 = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton13 = New System.Windows.Forms.ToolBarButton
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.mangascan = New System.Windows.Forms.PictureBox
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.filetree = New System.Windows.Forms.TreeView
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.selectedtree = New System.Windows.Forms.TreeView
        Me.current_path = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.MenuItem33 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Percentage_label = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.current_image_label = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Manga_Viewer_Toolbar
        '
        Me.Manga_Viewer_Toolbar.AllowDrop = True
        Me.Manga_Viewer_Toolbar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.Manga_Viewer_Toolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Manga_Viewer_Toolbar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.ToolBarButton1, Me.ToolBarButton11, Me.ToolBarButton4, Me.ToolBarButton6, Me.ToolBarButton7, Me.ToolBarButton12, Me.ToolBarButton2, Me.ToolBarButton5, Me.ToolBarButton3, Me.ToolBarButton10, Me.ToolBarButton8, Me.ToolBarButton9, Me.ToolBarButton13})
        Me.Manga_Viewer_Toolbar.ButtonSize = New System.Drawing.Size(32, 32)
        Me.Manga_Viewer_Toolbar.DropDownArrows = True
        Me.Manga_Viewer_Toolbar.ImageList = Me.ImageList1
        Me.Manga_Viewer_Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Manga_Viewer_Toolbar.Name = "Manga_Viewer_Toolbar"
        Me.Manga_Viewer_Toolbar.ShowToolTips = True
        Me.Manga_Viewer_Toolbar.Size = New System.Drawing.Size(728, 45)
        Me.Manga_Viewer_Toolbar.TabIndex = 1
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.ImageIndex = 0
        Me.ToolBarButton1.ToolTipText = "Open New Location"
        '
        'ToolBarButton11
        '
        Me.ToolBarButton11.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ToolBarButton4
        '
        Me.ToolBarButton4.ImageIndex = 8
        Me.ToolBarButton4.ToolTipText = "Open Parent Directory"
        '
        'ToolBarButton6
        '
        Me.ToolBarButton6.ImageIndex = 5
        Me.ToolBarButton6.ToolTipText = "Move Up a Directory"
        '
        'ToolBarButton7
        '
        Me.ToolBarButton7.ImageIndex = 9
        Me.ToolBarButton7.ToolTipText = "Move Down a Directory"
        '
        'ToolBarButton12
        '
        Me.ToolBarButton12.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.ImageIndex = 4
        Me.ToolBarButton2.ToolTipText = "Toggle Folder List View"
        '
        'ToolBarButton5
        '
        Me.ToolBarButton5.ImageIndex = 6
        Me.ToolBarButton5.ToolTipText = "Toggle Toolbar/Status Bar View"
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.ImageIndex = 2
        Me.ToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.ToolBarButton3.ToolTipText = "Toggle Image Resize"
        '
        'ToolBarButton10
        '
        Me.ToolBarButton10.ImageIndex = 12
        Me.ToolBarButton10.ToolTipText = "Display Actual Size Image"
        '
        'ToolBarButton8
        '
        Me.ToolBarButton8.ImageIndex = 10
        Me.ToolBarButton8.ToolTipText = "Zoom In"
        '
        'ToolBarButton9
        '
        Me.ToolBarButton9.ImageIndex = 11
        Me.ToolBarButton9.ToolTipText = "Zoom Out"
        '
        'ToolBarButton13
        '
        Me.ToolBarButton13.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Panel1
        '
        Me.Panel1.AllowDrop = True
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Splitter1)
        Me.Panel1.Controls.Add(Me.filetree)
        Me.Panel1.Controls.Add(Me.Splitter2)
        Me.Panel1.Controls.Add(Me.selectedtree)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 497)
        Me.Panel1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.AllowDrop = True
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.mangascan)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(316, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(412, 497)
        Me.Panel2.TabIndex = 24
        '
        'mangascan
        '
        Me.mangascan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.mangascan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mangascan.Location = New System.Drawing.Point(0, 0)
        Me.mangascan.Name = "mangascan"
        Me.mangascan.Size = New System.Drawing.Size(50, 50)
        Me.mangascan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.mangascan.TabIndex = 19
        Me.mangascan.TabStop = False
        Me.mangascan.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(312, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 497)
        Me.Splitter1.TabIndex = 23
        Me.Splitter1.TabStop = False
        '
        'filetree
        '
        Me.filetree.AllowDrop = True
        Me.filetree.BackColor = System.Drawing.Color.WhiteSmoke
        Me.filetree.Dock = System.Windows.Forms.DockStyle.Left
        Me.filetree.ImageIndex = 1
        Me.filetree.ImageList = Me.ImageList2
        Me.filetree.Indent = 23
        Me.filetree.ItemHeight = 20
        Me.filetree.Location = New System.Drawing.Point(156, 0)
        Me.filetree.Name = "filetree"
        Me.filetree.SelectedImageIndex = 2
        Me.filetree.Size = New System.Drawing.Size(156, 497)
        Me.filetree.Sorted = True
        Me.filetree.TabIndex = 20
        Me.filetree.TabStop = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(152, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(4, 497)
        Me.Splitter2.TabIndex = 21
        Me.Splitter2.TabStop = False
        '
        'selectedtree
        '
        Me.selectedtree.AllowDrop = True
        Me.selectedtree.BackColor = System.Drawing.Color.WhiteSmoke
        Me.selectedtree.Dock = System.Windows.Forms.DockStyle.Left
        Me.selectedtree.ImageIndex = -1
        Me.selectedtree.Location = New System.Drawing.Point(0, 0)
        Me.selectedtree.Name = "selectedtree"
        Me.selectedtree.SelectedImageIndex = -1
        Me.selectedtree.Size = New System.Drawing.Size(152, 497)
        Me.selectedtree.Sorted = True
        Me.selectedtree.TabIndex = 22
        Me.selectedtree.TabStop = False
        '
        'current_path
        '
        Me.current_path.AllowDrop = True
        Me.current_path.BackColor = System.Drawing.Color.Transparent
        Me.current_path.Dock = System.Windows.Forms.DockStyle.Top
        Me.current_path.Location = New System.Drawing.Point(0, 45)
        Me.current_path.Name = "current_path"
        Me.current_path.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.current_path.Size = New System.Drawing.Size(728, 22)
        Me.current_path.TabIndex = 3
        Me.current_path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem7, Me.MenuItem4, Me.MenuItem8, Me.MenuItem14})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem29, Me.MenuItem5, Me.MenuItem30, Me.MenuItem6, Me.MenuItem31, Me.MenuItem32, Me.MenuItem33, Me.MenuItem13})
        Me.MenuItem1.Text = "File"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.MenuItem2.Text = "Open Directory"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.MenuItem3.Text = "Open File"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 2
        Me.MenuItem29.Text = "-"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 3
        Me.MenuItem5.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.MenuItem5.Text = "Save File"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 4
        Me.MenuItem30.Text = "-"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 5
        Me.MenuItem6.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.MenuItem6.Text = "Print File"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 6
        Me.MenuItem31.Text = "-"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 7
        Me.MenuItem32.Text = "Close File"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 8
        Me.MenuItem33.Text = "-"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 9
        Me.MenuItem13.Shortcut = System.Windows.Forms.Shortcut.CtrlQ
        Me.MenuItem13.Text = "Exit"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 1
        Me.MenuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9})
        Me.MenuItem7.Text = "Edit"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 0
        Me.MenuItem9.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.MenuItem9.Text = "Copy Image"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem10, Me.MenuItem11, Me.MenuItem27, Me.MenuItem12, Me.MenuItem15, Me.MenuItem28, Me.MenuItem16, Me.MenuItem17})
        Me.MenuItem4.Text = "View"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 0
        Me.MenuItem10.Text = "Zoom In"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 1
        Me.MenuItem11.Text = "Zoom Out"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 2
        Me.MenuItem27.Text = "-"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 3
        Me.MenuItem12.Text = "Actual Pixels"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 4
        Me.MenuItem15.Text = "Fit to Screen"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 5
        Me.MenuItem28.Text = "-"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 6
        Me.MenuItem16.Text = "Toggle Folderlist"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 7
        Me.MenuItem17.Text = "Toggle Toolbars"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 3
        Me.MenuItem8.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem18, Me.MenuItem19, Me.MenuItem25, Me.MenuItem20, Me.MenuItem21, Me.MenuItem26, Me.MenuItem22})
        Me.MenuItem8.Text = "Navigation"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 0
        Me.MenuItem18.Text = "Next Image"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 1
        Me.MenuItem19.Text = "Previous Image"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 2
        Me.MenuItem25.Text = "-"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 3
        Me.MenuItem20.Text = "Next Folder"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 4
        Me.MenuItem21.Text = "Previous Folder"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 5
        Me.MenuItem26.Text = "-"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 6
        Me.MenuItem22.Text = "Parent Directory"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 4
        Me.MenuItem14.Text = "About"
        '
        'Panel3
        '
        Me.Panel3.AllowDrop = True
        Me.Panel3.Controls.Add(Me.Percentage_label)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.current_image_label)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 564)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(728, 28)
        Me.Panel3.TabIndex = 7
        '
        'Percentage_label
        '
        Me.Percentage_label.AllowDrop = True
        Me.Percentage_label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Percentage_label.Location = New System.Drawing.Point(621, 7)
        Me.Percentage_label.Name = "Percentage_label"
        Me.Percentage_label.Size = New System.Drawing.Size(47, 16)
        Me.Percentage_label.TabIndex = 8
        Me.Percentage_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.AllowDrop = True
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(679, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(16, 16)
        Me.Button2.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.AllowDrop = True
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(702, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(16, 16)
        Me.Button1.TabIndex = 5
        '
        'current_image_label
        '
        Me.current_image_label.AllowDrop = True
        Me.current_image_label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.current_image_label.BackColor = System.Drawing.Color.Transparent
        Me.current_image_label.Location = New System.Drawing.Point(5, 7)
        Me.current_image_label.Name = "current_image_label"
        Me.current_image_label.Size = New System.Drawing.Size(606, 16)
        Me.current_image_label.TabIndex = 7
        Me.current_image_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "jpg"
        Me.OpenFileDialog1.Filter = "All files|*.*|JPG images|*.jpg|BMP images|*.bmp|PNG images|*.png|GIF images|*.gif" & _
        ""
        Me.OpenFileDialog1.Title = "Manga Viewer 1.0"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "jpg"
        Me.SaveFileDialog1.FileName = "doc1"
        Me.SaveFileDialog1.Filter = "All files|*.*"
        Me.SaveFileDialog1.Title = "Manga Viewer 1.0"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select a root folder containing the images you wish to display."
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'Manga_Viewer
        '
        Me.AllowDrop = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(728, 592)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.current_path)
        Me.Controls.Add(Me.Manga_Viewer_Toolbar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.Name = "Manga_Viewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manga Viewer 1.0"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Error_Handler(ByVal message As String)
        Try
            If message.EndsWith("is denied.") Then
                'ignore access denied errors
            Else
                MsgBox("Apologies, bu Manga Viewer 1.0 has trapped the following error: " & vbCrLf & message, MsgBoxStyle.Exclamation, "Manga Viewer 1.0 Error Message")
            End If
        Catch ex As Exception
            MsgBox("Apologies, bu Manga Viewer 1.0 has trapped the following error: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Manga Viewer 1.0 Error Message")
        End Try
    End Sub


    Public Sub ProcessPath(ByVal inputpath As String, ByVal currentnode As TreeNode)
        Try
            Dim path As String
            path = inputpath

            If Directory.Exists(path) Then
                ' This path is a directory
                ProcessDirectory(path, currentnode, 0)

        End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub 'Main


    ' Process all files in the directory passed in, and recurse on any directories 
    ' that are found to process the files they contain

    Public Sub ProcessDirectory(ByVal targetDirectory As String, ByVal currentnode As TreeNode, ByVal initialised As Integer)
        Try
            Dim childnode As TreeNode
            If Not initialised = 0 Then
                Dim file As FileInfo = New FileInfo(targetDirectory)
                Dim newnode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(file.Name)
                newnode.Tag = targetDirectory
                currentnode.Nodes.Add(newnode)

                childnode = currentnode.LastNode()
            Else
                childnode = currentnode
            End If
            initialised = initialised + 1

            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            ' Recurse into subdirectories of this directory
            If initialised < 2 Then
                Dim subdirectory As String
                For Each subdirectory In subdirectoryEntries
                    ProcessDirectory(subdirectory, childnode, initialised)
                Next subdirectory
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try



    End Sub 'ProcessDirectory

    Public Sub ProcessFiles(ByVal targetDirectory As String, ByVal currentnode As TreeNode)
        Try

            Dim subfileEntries As String() = Directory.GetFiles(targetDirectory)
            ' Recurse into subdirectories of this directory
            'Dim itemtoadd As MyFileItem
            Dim subfile As String
            For Each subfile In subfileEntries
                Dim file As FileInfo = New FileInfo(subfile)
                If subfile.ToLower.EndsWith("jpg") Or subfile.ToLower.EndsWith("bmp") Or subfile.ToLower.EndsWith("gif") Or subfile.ToLower.EndsWith("png") Or subfile.ToLower.EndsWith("jpeg") Or subfile.ToLower.EndsWith("ico") Then
                    Dim nodetoinsert As TreeNode = New TreeNode
                    nodetoinsert.Text = file.Name
                    nodetoinsert.Tag = subfile
                    currentnode.Nodes.Add(nodetoinsert)
                    'itemtoadd.FilenameString = subfile
                    'SortedArraylistInsert(itemtoadd)
                End If
            Next subfile

        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub 'ProcessFiles

    Private Sub handle_expand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles selectedtree.AfterExpand
        Try
            If IsNothing(e) = False And IsNothing(e.Node) = False Then


            Dim currentnode As TreeNode
            currentnode = e.Node
            While Not currentnode Is e.Node.NextNode()
                selectedtree.SelectedNode = currentnode.NextVisibleNode
                currentnode = currentnode.NextVisibleNode()
            End While
                selectedtree.SelectedNode = e.Node
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Select_Folder(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles selectedtree.AfterSelect
        Try
            If IsNothing(selectedtree.SelectedNode) = False Then
                Dim currentnode As TreeNode
                currentnode = selectedtree.SelectedNode
                Dim file As DirectoryInfo = New DirectoryInfo(currentnode.Tag)
                currentnode.Tag = selectedtree.SelectedNode.Tag
                current_image_label.Text = ""
                'reg_last_path = file.FullName
                'reg_last_image = ""

                current_path.Text = file.FullName
                reg_last_path = selectedtree.SelectedNode.Tag
                'If reg_last_path.EndsWith(":") Then
                'reg_last_path = reg_last_path & "\"
                'End If
                filetree.Nodes.Clear()
                'filenamelist.Clear()

                ' If currentnode.Text.Length > 3 Then
                filetree.Nodes.Add(file.Name)
                filetree.TopNode.ImageIndex = 0
                filetree.TopNode.SelectedImageIndex = 0
                'Else
                'filetree.Nodes.Add(currentnode.Text)
                'filetree.TopNode.ImageIndex = 0
                'filetree.TopNode.SelectedImageIndex = 0
                'End If
                ProcessFiles(currentnode.Tag, filetree.TopNode)

                filetree.ExpandAll()
                If IsNothing(filetree.TopNode) = True Then


                    filetree.SelectedNode = filetree.TopNode
                End If
                If Not currentnode Is selectedtree.TopNode And currentnode.GetNodeCount(False) = 0 Then

                    ProcessPath(currentnode.FullPath, currentnode)
                End If
                If Not IsNothing(filetree.TopNode.FirstNode) Then
                    filetree.SelectedNode = filetree.TopNode.FirstNode
                Else
                    mangascan.Hide()
                    current_image_label.Text = ""
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Select_Image_To_Display(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles filetree.AfterSelect
        Try
            Change_Image()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Toggle_FileTree_View()
        Try
            If reg_view_folderlist = True Then
                selectedtree.Visible = False
                filetree.Visible = False
                Splitter1.Visible = False
                Splitter2.Visible = False
                mangascan.Focus()
                reg_view_folderlist = False
                Manga_Viewer_Toolbar.Buttons(1).ImageIndex = 3
            Else
                selectedtree.Visible = True
                filetree.Visible = True
                Splitter1.Visible = True
                Splitter2.Visible = True
                reg_view_folderlist = True
                Manga_Viewer_Toolbar.Buttons(1).ImageIndex = 4
            End If
            Change_Image()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Toggle_Top_Bottom_Panels()
        Try
            If reg_view_toolbar = False Then
                Manga_Viewer_Toolbar.Show()
                Panel3.Show()
                current_path.Show()
                reg_view_toolbar = True
            Else
                Manga_Viewer_Toolbar.Hide()
                Panel3.Hide()
                current_path.Hide()
                reg_view_toolbar = False
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Manga_Viewer_Toolbar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles Manga_Viewer_Toolbar.ButtonClick
        Try
            Select Case Manga_Viewer_Toolbar.Buttons.IndexOf(e.Button)
                Case 0
                    Open_Location(sender, e)
                Case 6
                    Toggle_FileTree_View()
                Case 8
                    If Manga_Viewer_Toolbar.Buttons(8).Pushed = True Then
                        Manga_Viewer_Toolbar.Buttons(8).ImageIndex = 1
                        reg_fit_to_screen = True
                    Else
                        Manga_Viewer_Toolbar.Buttons(8).ImageIndex = 2
                        reg_fit_to_screen = False
                    End If
                    reg_zoom_percentage = 100
                    Fit_Image_To_Window()
                Case 2
                    Open_Parent_Location()
                Case 7
                    Toggle_Top_Bottom_Panels()
                Case 3
                    Navigate_Up()
                Case 4
                    Navigate_Down()
                Case 10
                    Zoom_In()
                Case 11
                    Zoom_Out()
                Case 9
                    Zoom_None(100)
            End Select
            mangascan.Focus()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub manga_viewer_sizechange(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Try
            Change_Image()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub



    Private Sub file_node_find(ByVal filename As String)
        Try
            Dim noded As TreeNode = filetree.TopNode.FirstNode
            filetree.ExpandAll()
            If Not noded Is Nothing Then
                While Not noded Is noded.LastNode
                    If noded.Text = filename Then
                        '                load_image(filenamelist.Item(0))
                        filetree.SelectedNode = noded
                        Exit While
                    End If
                    noded = noded.NextNode

                End While
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Mouse_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Panel2.DragEnter, Panel3.DragEnter, Panel1.DragEnter, selectedtree.DragEnter, filetree.DragEnter, Manga_Viewer_Toolbar.DragEnter, MyBase.DragEnter
        Try
            If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
                e.Effect = DragDropEffects.All
            Else
                e.Effect = DragDropEffects.None
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Mouse_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Panel2.DragDrop, Panel3.DragDrop, Panel1.DragDrop, selectedtree.DragDrop, filetree.DragDrop, Manga_Viewer_Toolbar.DragDrop, MyBase.DragDrop
        Try

            Dim s As String() = e.Data.GetData(DataFormats.FileDrop, False)
            Dim i As Integer
            i = 0
            Dim fileinf As FileInfo = New FileInfo(s(i))
            If File.Exists(s(i)) Then
                Open_Location(fileinf.DirectoryName)
                file_node_find(fileinf.Name)
            Else
                If Directory.Exists(s(i)) Then
                    Open_Location(s(i))
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub




#Region " Program Load Procedures "

    'Private Sub Get_Registry_Values()
    '    Dim str As String
    '    Dim keyflag1 As Boolean = False
    '    Dim oReg As RegistryKey = Registry.LocalMachine
    '    Dim keys() As String = oReg.GetSubKeyNames()
    '    System.Array.Sort(keys)
    '    For Each str In keys
    '        If str.Equals("Software\Hellsing Software") = True Then
    '            keyflag1 = True
    '            Exit For
    '        End If
    '    Next str
    '    If keyflag1 = False Then
    '        oReg.CreateSubKey("Software\Hellsing Software")
    '    End If
    '    keyflag1 = False
    '    Dim oKey As RegistryKey = oReg.OpenSubKey("Software\Hellsing Software", True)

    '    str = "unset"
    '    str = oKey.GetValue("tree_view")
    '    If Not IsNothing(str) And Not (str = "") Then
    '        If str = "True" Then
    '            reg_view_folderlist = True
    '            Manga_Viewer_Toolbar.Buttons(6).ImageIndex = 4
    '        Else
    '            reg_view_folderlist = False
    '            Manga_Viewer_Toolbar.Buttons(6).ImageIndex = 3
    '        End If
    '        If reg_view_folderlist = False Then
    '            selectedtree.Visible = False
    '            filetree.Visible = False
    '            Splitter1.Visible = False
    '            Splitter2.Visible = False
    '            mangascan.Focus()
    '            reg_view_folderlist = False
    '        Else
    '            selectedtree.Visible = True
    '            filetree.Visible = True
    '            Splitter1.Visible = True
    '            Splitter2.Visible = True
    '            reg_view_folderlist = True
    '        End If
    '    End If
    '    str = oKey.GetValue("resize_view")
    '    If Not IsNothing(str) And Not (str = "") Then
    '        If str = "True" Then
    '            Manga_Viewer_Toolbar.Buttons(8).Pushed = True
    '            Manga_Viewer_Toolbar.Buttons(8).ImageIndex = 1

    '        Else
    '            Manga_Viewer_Toolbar.Buttons(8).Pushed = False
    '            Manga_Viewer_Toolbar.Buttons(8).ImageIndex = 2

    '        End If

    '    End If
    '    str = oKey.GetValue("last_path")
    '    If Not IsNothing(str) And Not (str = "") Then

    '        Open_Location(str)

    '        str = oKey.GetValue("last_image")
    '        If Not IsNothing(str) And Not (str = "") Then
    '            If File.Exists(str) Then
    '                load_image(str)
    '                'file_node_find(str)
    '            End If
    '        End If
    '    End If


    'End Sub

    Private Function Invert_Boolean(ByVal input As Boolean) As Boolean
        Try
            If input = True Then
                Invert_Boolean = False
            Else
                Invert_Boolean = True
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Function


    Private Sub Manga_Viewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Load_Registry_Values()
            reg_view_folderlist = Invert_Boolean(reg_view_folderlist)
            Toggle_FileTree_View()
            reg_view_toolbar = Invert_Boolean(reg_view_toolbar)
            Toggle_Top_Bottom_Panels()



            If reg_fit_to_screen = True Then
                Manga_Viewer_Toolbar.Buttons(8).Pushed = True
                Manga_Viewer_Toolbar.Buttons(8).ImageIndex = 1
            Else
                Manga_Viewer_Toolbar.Buttons(8).Pushed = False
                Manga_Viewer_Toolbar.Buttons(8).ImageIndex = 2
            End If

            If IsNothing(reg_last_image) = False And Not reg_last_image = "" Then
                Dim file As FileInfo = New FileInfo(reg_last_image)
                If file.Exists() = True Then
                    Open_Location(file.DirectoryName)
                    file_node_find(file.Name)
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

#End Region

#Region " Program Close Procedures "

    'Private Sub Set_Registry_Values()
    '    Dim oReg As RegistryKey = Registry.LocalMachine
    '    Dim oKey As RegistryKey = oReg.OpenSubKey("Software\Hellsing Software", True)

    '    If Not IsNothing(current_path.Text) Then
    '        oKey.SetValue("last_path", current_path.Text)
    '    End If
    '    If Not IsNothing(reg_view_folderlist) Then
    '        oKey.SetValue("tree_view", reg_view_folderlist)
    '    End If
    '    If Not IsNothing(current_image) Then
    '        oKey.SetValue("last_image", current_image)
    '    End If
    '    oKey.SetValue("resize_view", reg_fit_to_screen)
    'End Sub

    Private Sub Dispose_Loaded_Image()
        Try
            If Not (mangascan.Image Is Nothing) Then
                mangascan.Image.Dispose()
                mangascan.Image = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Manga_Viewer_Unload(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            Dispose_Loaded_Image()
            Save_Registry_Values()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

#End Region

#Region " File Procedures "

    'Function that handles the opening of a new folder root
    Private Sub Open_Location(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'displays the open folder dialog
        'Dim OpenFolderDialog1 = New OpenFolderDialog()
        Try
            Dim result As DialogResult
            result = FolderBrowserDialog1.ShowDialog()
            'OpenFolderDialog1.showdialog()


            'if a path was selected in the open folder dialog, fill the tree lists accordingly
            If result = DialogResult.OK Then
                If Directory.Exists(FolderBrowserDialog1.SelectedPath) Then

                    'clears all tree lists as well as associated data structure
                    selectedtree.Nodes.Clear()
                    filetree.Nodes.Clear()
                    'filenamelist.Clear()

                    'set the root of the local folder tree to the selected path
                    Dim newnode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(FolderBrowserDialog1.SelectedPath)
                    newnode.Tag = FolderBrowserDialog1.SelectedPath
                    selectedtree.Nodes.Add(newnode)

                    'populate the folder tree
                    Dim currentnode As TreeNode
                    currentnode = selectedtree.Nodes(0)
                    ProcessPath(FolderBrowserDialog1.SelectedPath, currentnode)
                    filetree.Nodes.Clear()
                    ' filenamelist.Clear()
                    Dim file As FileInfo = New FileInfo(currentnode.Text)
                    If currentnode.Text.Length > 3 Then
                        filetree.Nodes.Add(file.Name)
                        filetree.TopNode.ImageIndex = 0
                        filetree.TopNode.SelectedImageIndex = 0
                    Else
                        filetree.Nodes.Add(currentnode.Text)
                        filetree.TopNode.ImageIndex = 0
                        filetree.TopNode.SelectedImageIndex = 0
                    End If
                    ProcessFiles(currentnode.Text, filetree.TopNode)
                    filetree.ExpandAll()
                    If Not IsNothing(selectedtree.TopNode) Then
                        selectedtree.SelectedNode = selectedtree.TopNode
                    End If
                Else
                    mangascan.Hide()
                    current_image_label.Text = ""
                    current_path.Text = "Invalid Path Selected"
                    filetree.Nodes.Clear()
                    selectedtree.Nodes.Clear()
                    reg_last_path = ""
                    reg_last_image = ""
                End If
            End If
            'dispose of the open folder dialog
            FolderBrowserDialog1.Dispose()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Open_Location(ByVal path As String)
        Try
            'if a path was selected in the open folder dialog, fill the tree lists accordingly

            If Directory.Exists(path) Then

                'clears all tree lists as well as associated data structure
                selectedtree.Nodes.Clear()
                filetree.Nodes.Clear()
                ' filenamelist.Clear()

                'set the root of the local folder tree to the selected path
                Dim newnode As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode(path)
                newnode.Tag = path
                selectedtree.Nodes.Add(newnode)

                'populate the folder tree
                Dim currentnode As TreeNode
                If Not IsNothing(selectedtree.Nodes(0)) Then


                    currentnode = selectedtree.Nodes(0)
                    ProcessPath(path, currentnode)
                    filetree.Nodes.Clear()
                    ' filenamelist.Clear()
                    Dim file As FileInfo = New FileInfo(currentnode.Text)
                    If currentnode.Tag.Length > 3 Then
                        filetree.Nodes.Add(file.Name)
                        filetree.TopNode.ImageIndex = 0
                        filetree.TopNode.SelectedImageIndex = 0
                    Else
                        filetree.Nodes.Add(currentnode.Text)
                        filetree.TopNode.ImageIndex = 0
                        filetree.TopNode.SelectedImageIndex = 0
                    End If
                    ProcessFiles(currentnode.Tag, filetree.TopNode)
                    filetree.ExpandAll()

                    If Not IsNothing(selectedtree.TopNode) Then
                        selectedtree.SelectedNode = selectedtree.TopNode
                    End If
                End If
            Else
                mangascan.Hide()
                current_image_label.Text = ""
                current_path.Text = "Invalid Path Selected"
                filetree.Nodes.Clear()
                selectedtree.Nodes.Clear()
                reg_last_path = ""
                reg_last_image = ""
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    'Handles the selection of a new image to be displayed
    Private Sub Change_Image()
        Try
            'Checks that an image file has indeed been selected
            If IsNothing(filetree.TopNode) = False Then

                If Not filetree.SelectedNode Is Nothing Then
                    'If the top of the Filelist tree is selected, then load the first image of the list
                    If filetree.SelectedNode Is filetree.TopNode Then
                        If filetree.TopNode.GetNodeCount(False) > 0 Then
                            filetree.SelectedNode = filetree.TopNode.FirstNode
                        End If
                    End If
                    'If the file has an accepted extension, display that file
                    If filetree.SelectedNode.Text.ToLower.EndsWith("jpg") Or filetree.SelectedNode.Text.ToLower.EndsWith("bmp") Or filetree.SelectedNode.Text.ToLower.EndsWith("gif") Or filetree.SelectedNode.Text.ToLower.EndsWith("png") Or filetree.SelectedNode.Text.ToLower.EndsWith("jpeg") Or filetree.SelectedNode.Text.ToLower.EndsWith("ico") Then
                        'Dim itemtodisplay As MyFileItem = filenamelist.Item(filetree.SelectedNode.Index)
                        Load_Image(filetree.SelectedNode.Tag)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Load_Image(ByVal imagetoload As String)

        mangascan.Visible = False
        current_image_label.Text = ""
        mangascan.Top = 0
        mangascan.Left = 0
        mangascan.Width = 50
        mangascan.Height = 50
        Try
            If Not (mangascan.Image Is Nothing) Then
                mangascan.Image.Dispose()
                mangascan.Image = Nothing
            End If
            mangascan.Image = Image.FromFile(imagetoload)
            Dim file As FileInfo = New FileInfo(imagetoload)
            current_image_label.Text = file.Name & "    (" & (filetree.SelectedNode.Index + 1) & "/" & filetree.GetNodeCount(True) - 1 & ")"
            reg_last_image = file.Name
            If reg_fit_to_screen = False Then
                Zoom_None(reg_zoom_percentage)
            Else
                Zoom_Perfect()
            End If
            reg_last_image = imagetoload
            mangascan.Visible = True
        Catch errt As Exception
            mangascan.Hide()
            current_image_label.Text = ""
            current_path.Text = "Invalid Path Selected"
        End Try

    End Sub

#End Region

#Region " Edit Procedures "

#End Region

#Region " View Procedures "

    Private Sub Fit_Image_To_Window()
        Try
            If reg_fit_to_screen = True Then
                Zoom_Perfect()
            Else
                Zoom_None(reg_zoom_percentage)
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Zoom_In()
        Try
            Dim percentage As Integer
            If (Round((((mangascan.Width * 1.25) / mangascan.Image.Width) * 100), 0) <= 500) Then
                mangascan.Width = mangascan.Width * 1.25
                mangascan.Height = mangascan.Height * 1.25
                percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)
                Percentage_label.Text = "[ " & percentage & "% ]"
            Else
                mangascan.Width = mangascan.Image.Width * 5
                mangascan.Height = mangascan.Image.Height * 5
                percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)
                Percentage_label.Text = "[ " & percentage & "% ]"
            End If
            reg_zoom_percentage = percentage
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Zoom_None(ByVal percent As Integer)
        Try
            Dim percent2 As Decimal
            percent2 = percent / 100
            Dim percentage As Integer
            mangascan.Width = mangascan.Image.Width * percent2
            mangascan.Height = mangascan.Image.Height * percent2

            percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)

            Percentage_label.Text = "[ " & percentage & "% ]"
            reg_zoom_percentage = percentage
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Zoom_Perfect()
        Try
            Dim percentage As Integer
            If (mangascan.Image.Height > Panel2.Height) Or (mangascan.Image.Width > Panel2.Width) Then

                If mangascan.Image.Height > mangascan.Image.Width Then
                    mangascan.Height = Panel2.Height
                    mangascan.Width = mangascan.Image.Width / (mangascan.Image.Height / Panel2.Height)
                    percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)

                    If mangascan.Width > Panel2.Width Then
                        mangascan.Width = Panel2.Width
                        mangascan.Height = mangascan.Image.Height / (mangascan.Image.Width / Panel2.Width)
                        percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)
                    End If
                    mangascan.Width = 0.99 * mangascan.Width
                    mangascan.Height = 0.99 * mangascan.Height
                    Percentage_label.Text = "[ " & percentage & "% ]"

                    reg_zoom_percentage = percentage
                Else
                    mangascan.Width = Panel2.Width
                    mangascan.Height = mangascan.Image.Height / (mangascan.Image.Width / Panel2.Width)
                    percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)
                    If mangascan.Height > Panel2.Height Then
                        mangascan.Height = Panel2.Height
                        mangascan.Width = mangascan.Image.Width / (mangascan.Image.Height / Panel2.Height)
                        percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)
                    End If
                    mangascan.Width = 0.99 * mangascan.Width
                    mangascan.Height = 0.99 * mangascan.Height
                    ' current_image_label.Text = current_image_label.Text & "     [ " & percentage & "% ]"
                    Percentage_label.Text = "[ " & percentage & "% ]"

                    reg_zoom_percentage = percentage
                End If
            Else
                mangascan.Width = mangascan.Image.Width
                mangascan.Height = mangascan.Image.Height
                'current_image_label.Text = current_image_label.Text & "     [ 100% ]"
                Percentage_label.Text = "[ 100% ]"
                reg_zoom_percentage = 100

            End If
            mangascan.Top = 0
            mangascan.Left = 0
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Zoom_Out()
        Try
            Dim percentage As Integer
            If (Round((((mangascan.Width * 0.75) / mangascan.Image.Width) * 100), 0) >= 25) Then
                mangascan.Width = mangascan.Width * 0.75
                mangascan.Height = mangascan.Height * 0.75
                percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)
                'current_image_label.Text = current_image_label.Text.Remove((current_image_label.Text.LastIndexOf(")") + 1), (current_image_label.Text.Length - (current_image_label.Text.LastIndexOf(")") + 1))) & "     [ " & percentage & "% ]"
                Percentage_label.Text = "[ " & percentage & "% ]"
                reg_zoom_percentage = percentage

            Else
                mangascan.Width = mangascan.Image.Width * 0.25
                mangascan.Height = mangascan.Image.Height * 0.25
                percentage = Round(((mangascan.Width / mangascan.Image.Width) * 100), 0)
                'current_image_label.Text = current_image_label.Text.Remove((current_image_label.Text.LastIndexOf(")") + 1), (current_image_label.Text.Length - (current_image_label.Text.LastIndexOf(")") + 1))) & "     [ " & percentage & "% ]"
                Percentage_label.Text = "[ " & percentage & "% ]"
                reg_zoom_percentage = percentage

            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

#End Region

#Region " Navigation Procedures "

    'Opens parent folder of the current top node in the Folderlist tree
    Private Sub Open_Parent_Location()
        Try
            If IsNothing(reg_last_path) = False And Not reg_last_path = "" Then
                Dim directoryinf As DirectoryInfo = New DirectoryInfo(reg_last_path)
                If IsNothing(directoryinf.Parent) = False Then
                    Dim path As String = directoryinf.Parent.FullName
                    'If path.Length = 2 Then path = path & "\"
                    Open_Location(path)
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    'Selects the folder above the current folder in the Folderlist tree
    Private Sub Navigate_Up()
        Try
            If selectedtree.GetNodeCount(True) > 0 Then


                Dim red As TreeNode = selectedtree.SelectedNode
                red.Expand()
                If Not IsNothing(red.PrevVisibleNode()) Then
                    selectedtree.SelectedNode = red.PrevVisibleNode()
                End If

            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    'Selects the folder below the current folder in the Folderlist tree
    Private Sub Navigate_Down()
        Try
            If selectedtree.GetNodeCount(True) > 0 Then
                Dim red As TreeNode = selectedtree.SelectedNode
                red.Expand()
                If Not IsNothing(red.NextVisibleNode()) Then
                    selectedtree.SelectedNode = red.NextVisibleNode()
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    'Selects the image below the current image in the Filelist tree
    Private Sub Move_Next()
        Try
            If filetree.GetNodeCount(True) > 0 Then
                If Not (filetree.SelectedNode Is filetree.SelectedNode.Parent.LastNode) Then
                    filetree.SelectedNode = filetree.SelectedNode.NextNode
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
        mangascan.Focus()
    End Sub

    'Selects the image above the current image in the Filelist tree
    Private Sub Move_Previous()
        Try
            If filetree.GetNodeCount(True) > 0 Then
                If Not (filetree.SelectedNode Is filetree.SelectedNode.Parent.FirstNode) Then
                    filetree.SelectedNode = filetree.SelectedNode.PrevNode
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
        mangascan.Focus()
    End Sub

    'Handles key presses when the image control is in focus.
    Private Sub Navigation_Key_Handler(ByVal sender As System.Object, ByVal keyselected As System.Windows.Forms.KeyEventArgs) Handles mangascan.KeyDown
        Try
            'Handles user moving to next image (Ctrl+PgDw)
            If Control.ModifierKeys = Keys.Control And keyselected.KeyCode = Keys.PageDown Then
                Move_Next()
                keyselected.Handled = True
                mangascan.Focus()
                Exit Sub
            End If
            'Handles user moving to previous image (Ctrl+PgUp)
            If Control.ModifierKeys = Keys.Control And keyselected.KeyCode = Keys.PageUp Then
                Move_Previous()
                keyselected.Handled = True
                mangascan.Focus()
                Exit Sub
            End If
            keyselected.Handled = True
            mangascan.Focus()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    'Handles mouse clicks when the image control is in focus.
    Private Sub Navigation_Mouse_Handler(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mangascan.MouseDown
        Try
            'If double left-click when image control is in focus, select next image
            If e.Clicks = 2 And e.Button = MouseButtons.Left Then
                Move_Next()
            End If

            'If double right-click when image control is in focus, select previous image
            If e.Clicks = 2 And e.Button = MouseButtons.Right Then
                Move_Previous()
            End If
            mangascan.Focus()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    'Handles clicking on the Next Arrow Button
    Private Sub Next_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Move_Next()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    'Handles clicking on the Previous Arrow Button
    Private Sub Previous_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Move_Previous()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

#End Region

#Region " Options Procedures "

#End Region

#Region " About Procedures "

    Private Sub Show_About_Screen()
        Try
            Dim about1 As New About_Splash_Screen
            about1.ShowDialog()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

#End Region

#Region " Menu Item Handlers "

#Region " File Menu Item Handlers "
    Private Sub Menu_Open_Directory(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Try
            Open_Location(sender, e)
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Open_File(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Try
            OpenFileDialog1.ShowDialog()
            Dim selectedfile = OpenFileDialog1.FileName
            If file.Exists(selectedfile) Then
                Dim file As FileInfo = New FileInfo(selectedfile)
                Open_Location(file.DirectoryName)
                file_node_find(file.Name)
            Else
                If Directory.Exists(selectedfile) Then
                    Open_Location(selectedfile)
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Save_File(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Try
            If Not reg_last_image = "" And IsNothing(mangascan.Image) = False Then
                Dim fileinf As FileInfo = New FileInfo(reg_last_image)
                SaveFileDialog1.FileName = (fileinf.Name)
                Dim result As DialogResult = SaveFileDialog1.ShowDialog()
                If result = DialogResult.OK Then
                    File.Copy(reg_last_image, SaveFileDialog1.FileName, True)
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub OnPrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.DrawImage(mangascan.Image, 0, 0)
    End Sub



    Private Sub Menu_Print_File(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Try
            If Not (mangascan.Image Is Nothing) Then



                Dim pd As New System.Drawing.Printing.PrintDocument
                AddHandler pd.PrintPage, AddressOf OnPrintPage

                pd.Print()
            End If
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Close_File(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem32.Click
        Try
            mangascan.Visible = False
            current_image_label.Text = ""

            If Not (mangascan.Image Is Nothing) Then
                mangascan.Image.Dispose()
                mangascan.Image = Nothing
            End If
            mangascan.Visible = True
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem13.Click
        Try
            Me.Close()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub
#End Region

#Region " Edit Menu Item Handlers "

    Private Sub Menu_Copy_Image(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        Try
            If Not IsNothing(mangascan.Image) Then
                Clipboard.SetDataObject(mangascan.Image)
            End If
        Catch ex As Exception
            'If reg_error_messages = True Then
            Error_Handler(ex.Message)
            'End If
        End Try
    End Sub

#End Region

#Region " View Menu Item Handlers "

    Private Sub Menu_Zoom_In(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        Try
            Zoom_In()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Zoom_Out(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        Try
            Zoom_Out()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Actual_Pixels(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        Try
            Zoom_None(100)
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Fit_To_Screen(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        Try
            Zoom_Perfect()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Toggle_Folderlist(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        Try
            Toggle_FileTree_View()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Toggle_Toolbars(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        Try
            Toggle_Top_Bottom_Panels()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

#End Region

#Region " Navigation Menu Item Handlers "

    Private Sub Menu_Next_Image(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Click
        Try
            Move_Next()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Previous_Image(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem19.Click
        Try
            Move_Previous()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Next_Folder(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem20.Click
        Try
            Navigate_Down()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Previous_Folder(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem21.Click
        Try
            Navigate_Up()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

    Private Sub Menu_Parent_Directory(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem22.Click
        Try
            Open_Parent_Location()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

#End Region

#Region " Options Menu Item Handlers "
    Private Sub Menu_Configuration(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim configuration_options1 As Configuration_Options = New Configuration_Options
            configuration_options1.ShowDialog()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub
#End Region

#Region " About Menu Item Handlers "

    Private Sub Menu_About(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        Try
            Show_About_Screen()
        Catch ex As Exception
            Error_Handler(ex.Message)
        End Try
    End Sub

#End Region

#End Region

    Property Last_Path() As String
        Get
            Last_Path = reg_last_path
        End Get
        Set(ByVal Value As String)
            reg_last_path = Value
        End Set
    End Property

    Property Last_Image() As String
        Get
            Last_Image = reg_last_image
        End Get
        Set(ByVal Value As String)
            reg_last_image = Value
        End Set
    End Property

    Property Zoom_Percentage() As Integer
        Get
            Zoom_Percentage = reg_zoom_percentage
        End Get
        Set(ByVal Value As Integer)
            reg_zoom_percentage = Value
        End Set
    End Property

    Property View_Toolbar() As Boolean
        Get
            View_Toolbar = reg_view_toolbar
        End Get
        Set(ByVal Value As Boolean)
            reg_view_toolbar = Value
        End Set
    End Property

    Property View_Folderlist() As Boolean
        Get
            View_Folderlist = reg_view_folderlist
        End Get
        Set(ByVal Value As Boolean)
            reg_view_folderlist = Value
        End Set
    End Property

    Property Fit_To_Screen() As Boolean
        Get
            Fit_To_Screen = reg_fit_to_screen
        End Get
        Set(ByVal Value As Boolean)
            reg_fit_to_screen = Value
        End Set
    End Property



    Public Sub Set_Values(ByVal last_path As String, ByVal last_image As String, ByVal zoom_percentage As Integer, ByVal view_toolbar As Boolean, ByVal view_folderlist As Boolean, ByVal fit_to_screen As Boolean)
        reg_last_path = last_path
        reg_last_image = last_image
        reg_zoom_percentage = zoom_percentage
        reg_view_toolbar = view_toolbar
        reg_view_folderlist = view_folderlist
        reg_fit_to_screen = fit_to_screen
    End Sub

    Public Sub Load_Registry_Values()
        Dim str As String
        Dim keyflag1 As Boolean = False
        Dim oReg As RegistryKey = Registry.LocalMachine
        Dim keys() As String = oReg.GetSubKeyNames()
        System.Array.Sort(keys)

        For Each str In keys
            If str.Equals("Software\Manga Viewer 1.0") = True Then
                keyflag1 = True
                Exit For
            End If
        Next str

        If keyflag1 = False Then
            oReg.CreateSubKey("Software\Manga Viewer 1.0")
        End If

        keyflag1 = False

        Dim oKey As RegistryKey = oReg.OpenSubKey("Software\Manga Viewer 1.0", True)

        str = oKey.GetValue("reg_last_path")
        If Not IsNothing(str) And Not (str = "") Then
            reg_last_path = str
            ' If reg_last_path.EndsWith(":") Then
            'reg_last_path = reg_last_path & "\"
            'End If
        Else
            reg_last_path = "%WINDIR%"
        End If

        str = oKey.GetValue("reg_last_image")
        If Not IsNothing(str) And Not (str = "") Then
            reg_last_image = str
        Else
            reg_last_image = ""
        End If

        str = oKey.GetValue("reg_zoom_percentage")
        If Not IsNothing(str) And Not (str = "") Then
            reg_zoom_percentage = CInt(str)
        Else
            reg_zoom_percentage = 100
        End If

        str = oKey.GetValue("reg_view_toolbar")
        If Not IsNothing(str) And Not (str = "") Then
            reg_view_toolbar = CBool(str)
        Else
            reg_view_toolbar = True
        End If

        str = oKey.GetValue("reg_view_folderlist")
        If Not IsNothing(str) And Not (str = "") Then
            reg_view_folderlist = CBool(str)
        Else
            reg_view_folderlist = True
        End If

        str = oKey.GetValue("reg_fit_to_screen")
        If Not IsNothing(str) And Not (str = "") Then
            reg_fit_to_screen = CBool(str)
        Else
            reg_fit_to_screen = False
        End If

        oKey.Close()
        oReg.Close()

    End Sub

    Public Sub Save_Registry_Values()
        Dim oReg As RegistryKey = Registry.LocalMachine
        Dim oKey As RegistryKey = oReg.OpenSubKey("Software\Manga Viewer 1.0", True)
        'If reg_last_path.EndsWith(":") Then
        'reg_last_path = reg_last_path & "\"
        'End If
        oKey.SetValue("reg_last_path", reg_last_path)
        oKey.SetValue("reg_last_image", reg_last_image)
        oKey.SetValue("reg_zoom_percentage", reg_zoom_percentage.ToString)
        oKey.SetValue("reg_view_toolbar", reg_view_toolbar.ToString)
        oKey.SetValue("reg_view_folderlist", reg_view_folderlist.ToString)
        oKey.SetValue("reg_fit_to_screen", reg_fit_to_screen.ToString)

        oKey.Close()
        oReg.Close()

    End Sub


End Class
