Imports System.Data.SqlClient

Public Class SqlHelper
    Implements ISqlHelper

    Public Sub New(connection As IDbConnection)
        Me.Connection = connection
    End Sub

    Public Sub New(connectionString As String)
        Me.Connection = BuildConnection(connectionString)
    End Sub

    Private Property Connection As IDbConnection

    Public ReadOnly Property State As ConnectionState Implements ISqlHelper.State
        Get
            Return Me.Connection.State
        End Get
    End Property

    Public Sub Open() Implements ISqlHelper.Open
        Me.Connection.Open()
    End Sub

    Protected Overridable Function BuildConnection(ByVal connectionString As String) As IDbConnection
        Return New SqlConnection(connectionString)
    End Function
End Class
