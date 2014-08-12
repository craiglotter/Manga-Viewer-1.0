Imports Microsoft.Win32
Public Class Configuration

    Private reg_last_path As String
    Private reg_last_image As String
    Private reg_zoom_percentage As Integer
    Private reg_view_toolbar As Boolean
    Private reg_view_folderlist As Boolean
    Private reg_fit_to_screen As Boolean

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

    Public Sub New()
        reg_last_path = ""
        reg_last_image = ""
        reg_zoom_percentage = 100
        reg_view_toolbar = True
        reg_view_folderlist = True
        reg_fit_to_screen = False
    End Sub

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
            If str.Equals("Software\Hellsing Software") = True Then
                keyflag1 = True
                Exit For
            End If
        Next str

        If keyflag1 = False Then
            oReg.CreateSubKey("Software\Hellsing Software")
        End If

        keyflag1 = False

        Dim oKey As RegistryKey = oReg.OpenSubKey("Software\Hellsing Software", True)

        str = oKey.GetValue("reg_last_path")
        If Not IsNothing(str) And Not (str = "") Then
            reg_last_path = str
        End If

        str = oKey.GetValue("reg_last_image")
        If Not IsNothing(str) And Not (str = "") Then
            reg_last_image = str
        End If

        str = oKey.GetValue("reg_zoom_percentage")
        If Not IsNothing(str) And Not (str = "") Then
            reg_zoom_percentage = CInt(str)
        End If

        str = oKey.GetValue("reg_view_toolbar")
        If Not IsNothing(str) And Not (str = "") Then
            reg_view_toolbar = CBool(str)
        End If

        str = oKey.GetValue("reg_view_folderlist")
        If Not IsNothing(str) And Not (str = "") Then
            reg_view_folderlist = CBool(str)
        End If

        str = oKey.GetValue("reg_fit_to_screen")
        If Not IsNothing(str) And Not (str = "") Then
            reg_fit_to_screen = CBool(str)
        End If

        oKey.Close()
        oReg.Close()

    End Sub

    Public Sub Save_Registry_Values()
        Dim oReg As RegistryKey = Registry.LocalMachine
        Dim oKey As RegistryKey = oReg.OpenSubKey("Software\Hellsing Software", True)

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
