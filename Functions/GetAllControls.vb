Public Function GetAllControls(container As Control) As List(Of Control)
	Dim controlList As New List(Of Control)

	For Each c As Control In container.Controls
		If c.Controls.Count > 0 Then
			controlList.Add(c)
			For Each con In c.Controls
				controlList.Add(con)
			Next
		Else
			controlList.Add(c)
		End If
	Next
	Return controlList
End Function