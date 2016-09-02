Public Shared Function GetSearchData(column1 As String, column1Value As String, 
				column2 As String, searchCriteria As String, tableName As String,
				connectionString As String) As DataTable
	Try
		Dim _dsObj As New DataSet
		Using _conObj As New SqlConnection(connectionString)
			_conObj.Open()
			Dim sql = "Select * From " & tableName
			Dim cmd As New SqlCommand(sql, _conObj)
			Using _adapterObj As New SqlDataAdapter(cmd)
				Using cb As New SqlCommandBuilder(_adapterObj)
					_adapterObj.Fill(_dsObj)
				End Using
			End Using
		End Using
		Dim filtered = From r In _dsObj.Tables(0)
					   Where r.Item(column1).ToString.Equals(column1Value)
					   Where r.Item(column2).ToString.Contains(searchCriteria)
					   Select r

		Return filtered.CopyToDataTable
	Catch ex As Exception
		Throw New Exception(ex.Message)
		Return Nothing
	End Try
End Function
