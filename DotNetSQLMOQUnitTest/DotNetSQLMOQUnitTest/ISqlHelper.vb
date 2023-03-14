Imports System.Data
Public Interface ISqlHelper
    ReadOnly Property State As ConnectionState
    Sub Open()
End Interface
