Public Function UppercaseSentence(ByVal val As String) As String
	If String.IsNullOrEmpty(val) Then
		Return val
	End If
	Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(val)
End Function
