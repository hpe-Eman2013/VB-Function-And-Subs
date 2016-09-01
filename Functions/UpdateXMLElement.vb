Public Function UpdateXMLElement(oldValue As String, newValue As String,
				eleName As String, subRoot As String, fullFileName As String) As Boolean
	Try
		If Not File.Exists(fullFileName) Then _
			Throw New Exception("The file does not exist!")
		Dim xEle As XElement = XElement.Load(fullFileName)
		
		Dim existRec = (From fields In xEle.Descendants(subRoot)
				   Where fields.Element(eleName).Value.Equals(oldValue)
				   Select fields).FirstOrDefault

		If IsNothing(existRec) Then Return False
		existRec.Element(eleName).SetValue(newValue)
		xEle.Save(fullFileName)
		Return True
	Catch ex As Exception
		Throw New Exception(ex.Message)
	End Try
	Return False
End Function
