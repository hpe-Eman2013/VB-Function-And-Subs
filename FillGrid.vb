Public Sub FillGrid(dgControl As DataGridView)
	Try
		If Not IsNothing(dgControl.DataSource) Then
			With dgControl
				.Columns(0).Visible = False
				.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
				.RowHeadersDefaultCellStyle.Font = New Font("Times New Roman", 13)
				.RowsDefaultCellStyle.Font = New Font("Times New Roman", 13)
				.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 13)
			End With
		End If
	Catch ex As Exception
		MsgBox(ex.Message, MsgBoxStyle.Critical)
	End Try
End Sub