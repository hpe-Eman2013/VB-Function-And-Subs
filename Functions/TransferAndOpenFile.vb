Public Function TransferAndOpenFile(fileLocation As String, 
		existingFolder As String, Optional newFolderName As String) As String
	Try
		Dim appFileName As String = Nothing
		If Mid(fileLocation, Len(fileLocation), 1).Equals("\") Then
			'the user does not have the application
			fileLocation += String.Format("\{0}\", newFolderName)
			CopyExistingFilesToLocal(fileLocation, existingFolder)
			appFileName = fileLocation
		Else
			'the user has the application
			Dim localFolder = Path.GetDirectoryName(fileLocation) & "\"
			appFileName = localFolder
			If CompareFileVersions(localFolder, existingFolder) Then
				'the local file is older so get the current folder
				GetCurrentAppLocation(localFolder, existingFolder)
			End If
		End If
		Return StartApplication(appFileName)
	Catch ex As Exception
		Throw New Exception(ex.Message & "--In TransferAndOpenFile")
	End Try
End Function
