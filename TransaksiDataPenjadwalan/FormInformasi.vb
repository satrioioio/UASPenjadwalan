Public Class FormInformasi
    Public Property PesanBentrok As String
    Private Sub FormInformasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtDetail.Text = PesanBentrok
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class