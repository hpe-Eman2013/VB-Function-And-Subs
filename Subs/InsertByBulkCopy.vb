Public Sub InsertByBulkCopy(ByVal passedInTable As DataTable, connectString As String)
	Using con As New SqlConnection(connectString)
		con.Open()
		Try
			Using bc As New SqlBulkCopy(con)
				bc.DestinationTableName = passedInTable.TableName
				For Each col As DataColumn In passedInTable.Columns
					bc.ColumnMappings.Add(col.ColumnName, col.ColumnName)
				Next
				bc.WriteToServer(passedInTable)
			End Using
		Catch ex As Exception
			Throw New Exception(ex.Message)
		End Try
	End Using
End Sub