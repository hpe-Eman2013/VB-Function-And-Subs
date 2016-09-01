Private Sub DeleteLocalFolder(destinePath As String)
	If Directory.Exists(destinePath) Then
		For Each fileToDelete In Directory.GetFiles(destinePath)
			File.Delete(fileToDelete)
		Next
		Directory.Delete(destinePath)
	End If
End Sub
