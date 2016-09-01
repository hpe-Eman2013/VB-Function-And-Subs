Public Sub MakeControlsInvisible(controlContainer As Object,
	Optional controlToHide As Object = Nothing)
	'this hides the control passed in
	Dim allControls As List(Of Control) = GetAllControls(controlContainer)
	For Each con As Control In allControls
		If Not isNothing(controlToHide) Then
			If con = controlToHide Then 
				con.Visible = False
				Exit For
			End If
		Else
			con.Visible = False
		End IF
	Next
End Sub