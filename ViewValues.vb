Private Sub ViewValues(isVisible As Boolean, clearControls As Boolean,
	groupControl As GroupBox)
	If isVisible Then
		For Each con As Control In groupControl.Controls
			con.Visible = True
		Next
	Else
		For Each con As Control In groupControl.Controls
			con.Visible = False
		Next
	End If
	If clearControls Then
		For Each con As Control In groupControl.Controls
			con.Text = String.Empty
		Next
	End If
	groupControl.Visible = isVisible
End Sub