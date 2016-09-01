Public Sub DeleteNode(xmlFile As String, subNode As String, eleNameToDelete As String,
				eleValueToDelete As String)
	Try
		If Not File.Exists(xmlFile) Then _
			Throw New Exception("The file does not exist!")
		Dim xEle As XElement = XElement.Load(xmlFile)
		Dim deleteQuery = From r In xEle.Descendants(subNode)
						  Where r.Element(eleNameToDelete).Value.Equals(eleValueToDelete)
						  Select r


		deleteQuery.Remove()
		xEle.Save(xmlFile)
	Catch ex As Exception
		MsgBox(ex.Message, MsgBoxStyle.Exclamation)
	End Try
End Sub
