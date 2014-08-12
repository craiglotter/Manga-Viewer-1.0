Module Application_Entry_Point
    Sub Main()
        'Dim Configuration1 As Configuration = New Configuration()
        'Configuration1.Load_Registry_Values()
        Dim Manga_Viewer1 As Manga_Viewer = New Manga_Viewer()

        'Manga_Viewer1.Set_Values(Configuration1.Last_Path, _
          '  Configuration1.Last_Image, Configuration1.Zoom_Percentage, _
         '   Configuration1.View_Toolbar, Configuration1.View_Folderlist, _
        '    Configuration1.Fit_To_Screen)
        Manga_Viewer1.ShowDialog()

        'Configuration1.Set_Values(Manga_Viewer1.Last_Path, _
        '   Manga_Viewer1.Last_Image, Manga_Viewer1.Zoom_Percentage, _
        '  Manga_Viewer1.View_Toolbar, Manga_Viewer1.View_Folderlist, _
        ' Manga_Viewer1.Fit_To_Screen)

        'Configuration1.Save_Registry_Values()
    End Sub
End Module
