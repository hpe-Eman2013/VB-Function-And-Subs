Public Shared Function SaveDbData(insertQuery As String,
                conString As String) As Boolean
	Try
		Using con As New SqlConnection(conString)
			Using cmd As New SqlCommand(insertQuery, con)
				cmd.Connection.Open()
				cmd.ExecuteNonQuery()
				cmd.Connection.Close()
			End Using
		End Using
		Return True
	Catch ex As Exception
		Throw New Exception(ex.Message & "--Error in SaveDbData!")
	End Try
End Function
