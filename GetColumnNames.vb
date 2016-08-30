Public Shared Function GetColumnNames(tableName As String, connectionString As String) As DataTable
	Try
		Dim sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
			"WHERE(TABLE_NAME = N'" & tableName & "')"
		Dim _dsObj As New DataSet
		Using _conObj As New SqlConnection(connectionString)
			_conObj.Open()
			Dim cmd As New SqlCommand(sql, _conObj)
			Using _adapterObj As New SqlDataAdapter(cmd)
				Using cb As New SqlCommandBuilder(_adapterObj)
					_adapterObj.Fill(_dsObj)
					Return _dsObj.Tables(0)
				End Using
			End Using
		End Using
	Catch ex As Exception
		Throw New Exception(ex.Message)
		Return Nothing
	End Try
End Function