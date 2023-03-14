Imports System.Data.SqlClient
Public Class DataAccess
    'Public Interface ISqlRepositoryContext
    '    Property SqlConnection As IDbConnection
    'End Interface

    'Public Interface ISqlDbCommandFactory
    '    Sub GetDbCommand(commandText As String, sqlRepositoryContext As ISqlRepositoryContext)
    'End Interface

    Overridable Function getConnection(connectionString As String) As IDbConnection
        Return New SqlConnection(connectionString)
    End Function
End Class
