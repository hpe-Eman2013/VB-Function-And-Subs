Private Function SortNumberList(numList As String, divider As String) As String
	Dim values = numList.Split(divider)
	Dim sorted = From t In values Order By t.Length, t Select t

	Return String.Join(Environment.NewLine, sorted.ToArray)
End Function