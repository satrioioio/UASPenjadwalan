Module MDbKoneksi
    'Membuat Variabel Koneksi
    Public DBKoneksi As MySqlConnection 'Menyediakan Koneksi Sumber Database
    Public DA As MySqlDataAdapter 'objek yang menjembatani DataSet dengan Database
    Public DS As DataSet
    Public CMD As MySqlCommand
    Public DR As MySqlDataReader 'digunakan untuk membaca hasil Query
    Public Hitung As Integer = 1
    Public Kode_Jurusan As String
    Public Kode_JurusanMhs As String
    Public Kode_Semester As String
    Public KodeJurusan As String
    Public KodeTahunAkademik As String
    Public Nomor As Integer
    Public Batas As Integer
    Public Pesan As Integer
    Public PesanMkl As Integer
    Public PesanSmtr As Integer


    'membuat Data Variabel SQL dan Lokasi Database
    Public LokasiDatabase As String
    Public SQLInsert As String
    Public SQLUpdate As String
    Public QUERY As String
    Public SQLHapus As String

    'Membuat Prosedure Public untuk Koneksi Database
    Public Sub KoneksiDB()
        Try
            'Lokasi database
            LokasiDatabase = "server=localhost;Uid=root;Pwd=iowisnu1;Database=dbpenjadwalan24022"
            DBKoneksi = New MySqlConnection(LokasiDatabase)
            If DBKoneksi.State = ConnectionState.Closed Then
                DBKoneksi.Open()
            End If
        Catch ex As Exception
            MsgBox("Koneksi Gagal", vbExclamation, "Koneksi Gagal")
        End Try
    End Sub

    Function Diskonek()
        DBKoneksi.Close()
        Return DBKoneksi
    End Function

    Public Function Rep(ByVal kata As String) As String
        Rep = Replace(kata, "'", "''")
    End Function
End Module
