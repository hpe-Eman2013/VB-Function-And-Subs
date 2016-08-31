Public Function GetXMLRootName(pathToFile As String) As String
	Try
		If Not File.Exists(pathToFile) Then _
			Throw New ArgumentException("The path must contain a valid filename and path!")
		Dim NameOfFile = Path.GetFileName(pathToFile)
		Dim FullPath = Path.GetDirectoryName(pathToFile) & "\"
		Dim xDoc As XDocument = XDocument.Load(FullPath & NameOfFile)
		Return xDoc.Root.Name.LocalName
	Catch ae As ArgumentException
		MsgBox(ae.Message, MsgBoxStyle.Critical)
	End Try
End Sub