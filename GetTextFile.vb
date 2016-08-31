Imports System.IO
Public Shared Function GetTextFile(fullPathName As String, hasHeaders As Boolean) As DataTable
	Try
		Dim lines = File.ReadAllLines(fullPathName)
		Dim txtData As New System.Data.DataTable
		Dim arr = RemoveAllSpacesReturnList(lines(0))
		Dim startValue = If(hasHeaders, 1, 0)
		If hasHeaders Then
			For i As Integer = 0 To arr.Count - 1
				txtData.Columns.Add(arr.Item(i).ToString.ToUpper)
			Next
		End If
		For i As Integer = startValue To lines.Count - 1
			Dim row As DataRow = txtData.NewRow()
			arr = RemoveAllSpacesReturnList(lines(i))
			For j As Integer = 0 To arr.Count - 1
				row(j) = arr.Item(j).ToString
			Next
			txtData.Rows.Add(row)
		Next
		Return txtData
	Catch ex As Exception
		Throw New Exception(ex.Message)
	End Try
	Return Nothing
End Function