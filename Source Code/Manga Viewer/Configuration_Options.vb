Public Class Configuration_Options
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Options_General As System.Windows.Forms.TabPage
    Friend WithEvents Options_General_Layout As System.Windows.Forms.CheckBox
    Friend WithEvents Options_General_Zoom As System.Windows.Forms.CheckBox
    Friend WithEvents Options_General_Last_Image As System.Windows.Forms.CheckBox
    Friend WithEvents Options_General_Error_Messages As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Options_General = New System.Windows.Forms.TabPage()
        Me.Options_General_Error_Messages = New System.Windows.Forms.CheckBox()
        Me.Options_General_Last_Image = New System.Windows.Forms.CheckBox()
        Me.Options_General_Zoom = New System.Windows.Forms.CheckBox()
        Me.Options_General_Layout = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.Options_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Options_General})
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(352, 328)
        Me.TabControl1.TabIndex = 0
        '
        'Options_General
        '
        Me.Options_General.Controls.AddRange(New System.Windows.Forms.Control() {Me.Options_General_Error_Messages, Me.Options_General_Last_Image, Me.Options_General_Zoom, Me.Options_General_Layout})
        Me.Options_General.Location = New System.Drawing.Point(4, 22)
        Me.Options_General.Name = "Options_General"
        Me.Options_General.Size = New System.Drawing.Size(344, 302)
        Me.Options_General.TabIndex = 0
        Me.Options_General.Text = "General"
        '
        'Options_General_Error_Messages
        '
        Me.Options_General_Error_Messages.Location = New System.Drawing.Point(32, 120)
        Me.Options_General_Error_Messages.Name = "Options_General_Error_Messages"
        Me.Options_General_Error_Messages.Size = New System.Drawing.Size(200, 24)
        Me.Options_General_Error_Messages.TabIndex = 3
        Me.Options_General_Error_Messages.Text = "Display Error Messages"
        '
        'Options_General_Last_Image
        '
        Me.Options_General_Last_Image.Location = New System.Drawing.Point(32, 88)
        Me.Options_General_Last_Image.Name = "Options_General_Last_Image"
        Me.Options_General_Last_Image.Size = New System.Drawing.Size(200, 24)
        Me.Options_General_Last_Image.TabIndex = 2
        Me.Options_General_Last_Image.Text = "Remember Last Image Displayed"
        '
        'Options_General_Zoom
        '
        Me.Options_General_Zoom.Location = New System.Drawing.Point(32, 56)
        Me.Options_General_Zoom.Name = "Options_General_Zoom"
        Me.Options_General_Zoom.Size = New System.Drawing.Size(208, 24)
        Me.Options_General_Zoom.TabIndex = 1
        Me.Options_General_Zoom.Text = "Remember Last Used Zoom Factor"
        '
        'Options_General_Layout
        '
        Me.Options_General_Layout.Location = New System.Drawing.Point(32, 24)
        Me.Options_General_Layout.Name = "Options_General_Layout"
        Me.Options_General_Layout.Size = New System.Drawing.Size(168, 24)
        Me.Options_General_Layout.TabIndex = 0
        Me.Options_General_Layout.Text = "Remember Window Layout"
        '
        'Configuration_Options
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 325)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "Configuration_Options"
        Me.Text = "Configuration"
        Me.TabControl1.ResumeLayout(False)
        Me.Options_General.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


End Class
