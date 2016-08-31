Public Function GetSpecificXMLValue(searchNode As String, searchNodeValue As String,
                            eleName As String, subRoot As String,
							fullFileName As String) As Object
	Try
		If Not File.Exists(fullFileName) Then _
			Throw New Exception("The file does not exist!")
		Dim xEle As XElement = XElement.Load(fullFileName)
		Dim retItem = (From fields In xEle.Descendants(subRoot)
							Where fields.Element(searchNode).Value.Equals(searchNodeValue) And
							fields.Element(eleName).Value IsNot Nothing
							Select fields.Element(eleName).Value).FirstOrDefault

		Return retItem.ToString
	Catch ex As Exception
		Throw New Exception(ex.Message)
	End Try
End Function