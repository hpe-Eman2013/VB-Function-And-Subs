Public Function GetConfigFileData(fullFileName As String) As DataTable
	Try
		Dim ds As New DataSet
		If Not File.Exists(fullFileName) Then _
			Throw New Exception("The file does not exist!")
		ds.ReadXml(fullFileName)
		Return ds.Tables(0)
	Catch ex As Exception
		Throw New Exception("Could not retrieve XML file!")
	End Try
	Return Nothing
End Function
