Class MainWindow 
    Dim Timer As System.Timers.Timer
    Dim watcherthread As System.Threading.Thread
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim thr As New System.Threading.Thread(AddressOf watchersub)
        thr.Start()
        Button1.Visibility = Windows.Visibility.Collapsed
    End Sub

    Sub watchersub()
        Dim r As New Random
        Randomize()
        Dim Icount As Integer = r.Next(5000)
        Icount += 500
        System.Threading.Thread.Sleep(Icount)
        grid.Background.Dispatcher.Invokestart(changecolour)
        Timer.Start()
    End Sub
    'Sub changecolour()
    Function changecolour()
        Dim a As New System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red)
        grid.Background = a
        Return (Nothing)
    End Function

    Private Sub grid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles grid.KeyDown, Button1.KeyDown
        If e.Key = Key.Space Then
            Timer.Stop()
            Timer.Interval = Timer.Interval
        End If
    End Sub
End Class
