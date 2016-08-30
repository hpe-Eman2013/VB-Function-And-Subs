Public Shared Function GetAllRecords(sqlQuery As String, conString As String) As DataTable
	Dim _dsObj As New DataSet
	Using _conObj As New SqlConnection(conString)
		_conObj.Open()
		Dim cmd As New SqlCommand(sqlQuery, _conObj)
		Using _adapterObj As New SqlDataAdapter(cmd)
			Using cb As New SqlCommandBuilder(_adapterObj)
				Try
					_adapterObj.Fill(_dsObj)
					Return _dsObj.Tables(0)
				Catch ex As Exception
					Throw New Exception(ex.Message)
					Return Nothing
				End Try
			End Using
		End Using
	End Using
End Function