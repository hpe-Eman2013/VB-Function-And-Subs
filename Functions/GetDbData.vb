Public Shared Function GetDbData(sqlQuery As String, conString As String,
                              dbType As String, tableName As String) As DataTable

	Try
		Select Case dbType
			Case Is = "SQLServer"
				Using con As New SqlConnection(conString)
					Dim cmd As New SqlCommand(sqlQuery, con)
					'use a dataAdapter to be the link between the table and dataset
					Dim da As New SqlDataAdapter(cmd)
					'use a dataset to hold the data
					Dim ds As New DataSet("SqlServerData")
					'now fill the dataset using the dataAdapter
					da.Fill(ds, tableName)
					'put the data into a datatable
					Return ds.Tables(tableName)
				End Using
			Case Is = "MSAccess"
				Using con As New OleDb.OleDbConnection(conString)
					Dim cmd As New OleDbCommand(sqlQuery, con)
					con.Open()
					'use a dataAdapter to be the link between the table and dataset
					Dim da As New OleDbDataAdapter(cmd)
					'use a dataset to hold the data
					Dim ds As New DataSet("MSAccessData")
					'now fill the dataset using the dataAdapter
					da.Fill(ds, tableName)
					con.Close()
					'put the data into a datatable
					Return ds.Tables(tableName)
				End Using
		End Select
	Catch ex As Exception
		Throw New Exception("Error retrieving data!")
	End Try
	Return Nothing
End Function
