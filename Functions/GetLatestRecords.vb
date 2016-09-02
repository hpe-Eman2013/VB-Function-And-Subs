Private Function GetLatestRecords(dt As DataTable, savedDate As String, 
	dateColumn As String, elapsedTime As Integer) As DataTable
	Dim query = (From r In dt.AsEnumerable
				 Where DateTime.Parse(r.Item(dateColumn).ToString) >= DateTime.Parse(savedDate) And _
				 DateTime.Parse(r.Item(dateColumn).ToString) <= DateTime.Parse(savedDate).AddDays(elapsedTime)
				 Order By r.Item(dateColumn) Descending
				 Select r).CopyToDataTable

	If IsNothing(query) Then Return Nothing
	Return query
End Function