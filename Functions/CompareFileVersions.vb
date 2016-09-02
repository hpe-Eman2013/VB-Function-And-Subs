Private Function CompareFileVersions(localPathAndFile As String, existingPathAndFile As String) As Boolean
	Try
		Dim source As New DirectoryInfo(existingPathAndFile)
		Dim dest As New DirectoryInfo(localPathAndFile)
		Dim sourceFile = (From x In source.GetFiles()
						  Order By x.Name Descending
						  Where x.Name.Contains(".exe")).FirstOrDefault
		Dim destination = (From x In dest.GetFiles()
						  Order By x.Name Descending
						  Where x.Name.Contains(".exe")).FirstOrDefault

		If DateDiff(DateInterval.Minute, destination.LastWriteTime, sourceFile.LastWriteTime) > 0 Then
			'the local is older and must be changed
			Return True
		End If
	Catch ex As Exception
		Throw New Exception(ex.Message & "--In CompareVersions")
	End Try
	Return False
End Function
