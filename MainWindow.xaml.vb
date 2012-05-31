Class MainWindow 
    Dim Timer As New System.Diagnostics.Stopwatch
    Dim watcherthread As System.Threading.Thread
    Dim sresults As String = ""
    Dim Iarrscores(0) As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim thr As New System.Threading.Thread(AddressOf watchersub)
        thr.Start()
        Button1.Visibility = Windows.Visibility.Collapsed
    End Sub

    Sub watchersub()
        Timer.Reset()
        Dim r As New Random
        Randomize()
        Dim Icount As Integer = r.Next(5000)
        Icount += 500
        System.Threading.Thread.Sleep(Icount)

        Dispatcher.BeginInvoke(New Action(AddressOf changecolour), System.Windows.Threading.DispatcherPriority.Render)
        Timer.Start()
    End Sub
    'Sub changecolour()
    Function changecolour()
        Dim a As New System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red)
        grid.Background = a
        Return (Nothing)
    End Function

    Private Sub grid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles grid.KeyDown, Button1.KeyDown, MyBase.KeyDown
        If e.Key = Key.Space Then
            Timer.Stop()
            Dim newinteger As Integer = Timer.ElapsedMilliseconds
            newinteger = newinteger
            Button1.Visibility = Windows.Visibility.Visible
            sresults += newinteger.ToString + ", "
            grid.Background = New System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue)
            Button1.Content = "again? " + vbNewLine + sresults
        End If
    End Sub
End Class
