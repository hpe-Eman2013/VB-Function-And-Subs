Private Sub CopyExistingFilesToLocal(destinePath As String, existingFolder As String)
	Dim sourceDir As New System.IO.DirectoryInfo(existingFolder)
	If Not Directory.Exists(destinePath) Then
		Directory.CreateDirectory(destinePath)
		For Each fileSource In sourceDir.GetFiles
			fileSource.CopyTo(Path.Combine(destinePath, fileSource.Name), True)
		Next
	End If
End Sub
