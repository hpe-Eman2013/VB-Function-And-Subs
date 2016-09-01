Private Function StartApplication(localFileName As String) As String
	Dim source As New DirectoryInfo(localFileName)
	Dim sourceFile = (From x In source.GetFiles()
						  Order By x.Name Descending
						  Where x.Name.Contains(".exe")).FirstOrDefault

	Dim proc As New System.Diagnostics.Process
	proc.StartInfo.FileName = localFileName & sourceFile.Name
	proc.StartInfo.UseShellExecute = False
	proc.Start()
	Return localFileName & sourceFile.Name
End Function
