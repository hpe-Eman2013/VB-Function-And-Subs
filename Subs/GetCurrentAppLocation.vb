Private Sub GetCurrentAppLocation(destinePath As String, existingFolder As String)
	DeleteLocalFolder(destinePath)
	CopyExistingFilesToLocal(destinePath, existingFolder As String)
End Sub
