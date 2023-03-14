Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports DotNetSQLMOQUnitTest.Module1
Imports Moq
Imports System.Data.Common
Imports DotNetSQLMOQUnitTest
Imports Castle.Core.Logging
Imports Moq.Protected
Imports System.Runtime.Remoting.Messaging

<TestClass()> Public Class UnitTest1
    'Dim _connection = New Mock(Of DataAccess)
    '_connection.

    <TestMethod()>
    Public Sub SqlHelperConstructorWithIDbConnectionTest()
        Try
            Dim dbConnMock = New Mock(Of IDbConnection)()
            dbConnMock.Setup(Sub(d) d.Open()).Verifiable()
            dbConnMock.Setup(Function(d) d.State).Returns(ConnectionState.Open)

            'Dim helperMock = New Mock(Of SqlHelper)("Data Source=DummyServer;")

            Dim helperMock = New Mock(Of SqlHelper)(dbConnMock)
            helperMock.[Protected]().Setup(Of IDbConnection)("BuildConnection", ItExpr.IsAny(Of String)()).Returns(dbConnMock.Object)

            'Dim helper = helperMock.Object
            'helper.Open()

            'Dim conn As IDbConnection = helperMock

            'Dim conn = New Mock(Of SqlHelper)(dbConnMock.Object)

            'Dim x As IDbConnection = helperMock

            'Module1.GetPersonWithSqlConnectionParam(Helper)
            Module1.GetPersonWithSqlConnectionParam(helperMock)

            'Assert.AreEqual(ConnectionState.Open, Helper.State)
            'Assert.AreEqual(ConnectionState.Open, conn.State)
            'helperMock.[Protected]().Verify("BuildConnection", Times.Once(), ItExpr.IsAny(Of String)())
            'dbConnMock.Verify(Function(c) c.Open(), Times.Once())
            dbConnMock.Verify(Function(c) c.State,
                              Times.Once())
        Catch ex As Exception

        Finally

        End Try
    End Sub

End Class