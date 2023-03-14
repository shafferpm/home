Imports System.Data.SqlClient
Public Module Module1

    Sub Main()
        GetPerson()
    End Sub

    Public Sub GetPerson()
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim reader As SqlDataReader
        Dim results As String = String.Empty
        Dim initialCatalog As String = "AdventureWorks2019"
        Dim dataSource As String = "localhost"
        Dim integratedSecurity As String = "SSPI"
        Dim dataAccess As New DataAccess

        Try
            Dim connectionString As String = $"Initial Catalog={initialCatalog};" &
            $"Data Source={dataSource};" &
            $"Integrated Security={integratedSecurity};"

            'conn = New SqlConnection(connectionString)

            conn = dataAccess.getConnection(connectionString)

            cmd = conn.CreateCommand
            cmd.CommandText = "select firstname, lastname from [AdventureWorks2019].[Person].[Person]"

            conn.Open()

            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Do While reader.Read
                results = results & reader.GetString(0).Trim() & vbTab &
                reader.GetString(1).Trim() & vbLf
            Loop

            Console.WriteLine($"Name: {results}")
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            reader.Close()
            conn.Close()
        End Try
    End Sub

    Public Sub GetPersonWithSqlConnectionParam(ByVal conn As Object)
        'Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim reader As SqlDataReader
        Dim results As String = String.Empty
        Dim initialCatalog As String = "AdventureWorks2019"
        Dim dataSource As String = "localhost"
        Dim integratedSecurity As String = "SSPI"
        Dim dataAccess As New DataAccess

        Try
            Dim connectionString As String = $"Initial Catalog={initialCatalog};" &
            $"Data Source={dataSource};" &
            $"Integrated Security={integratedSecurity};"

            'conn = New SqlConnection(connectionString)

            conn = dataAccess.getConnection(connectionString)

            cmd = conn.CreateCommand
            cmd.CommandText = "select firstname, lastname from [AdventureWorks2019].[Person].[Person]"

            conn.Open()

            reader = cmd.ExecuteReader

            Do While reader.Read
                results = results & reader.GetString(0).Trim() & vbTab &
                reader.GetString(1).Trim() & vbLf
            Loop

            Console.WriteLine($"Name: {results}")
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            reader.Close()
            conn.Close()
        End Try
    End Sub
End Module
