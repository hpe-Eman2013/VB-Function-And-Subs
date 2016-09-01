Public Sub DisableCertainControls(values As List(Of Control), container As Control)
	Dim allControls = valid.GetAllControls(container)
	For Each item As Control In values
		For Each con As Control In allControls
			If item.Name.Equals(con.Name) Then
				con.Enabled = False
				Exit For
			End If
		Next
	Next
End Sub