Public Shared Function ImportFromXLS(filename As String) As DataTable
        Dim sSheetName As String = Nothing
        Dim sConnection As String
        Dim dtTablesList As DataTable
        Dim oleExcelCommand As OleDbCommand
        Dim oleExcelReader As OleDbDataReader
        Dim oleExcelConnection As OleDbConnection

        Try
            sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename +
                ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""

            oleExcelConnection = New OleDbConnection(sConnection)
            oleExcelConnection.Open()
            dtTablesList = oleExcelConnection.GetSchema("Tables")
            If dtTablesList.Rows.Count > 0 Then
                sSheetName = dtTablesList.Rows(0)("TABLE_NAME").ToString
            End If
            dtTablesList.Clear()
            dtTablesList.Dispose()
            Dim excelTable As New DataTable
            If sSheetName <> "" Then
                oleExcelCommand = oleExcelConnection.CreateCommand()
                oleExcelCommand.CommandText = "Select * From [" & sSheetName & "]"
                oleExcelCommand.CommandType = CommandType.Text
                oleExcelReader = oleExcelCommand.ExecuteReader
                Dim nOutputRow = 0
                Dim doOnce As Boolean = True
				Dim counter As Integer = 1
                While oleExcelReader.HasRows
                    oleExcelReader.Read()
                    If doOnce Then
                        For i As Integer = 0 To oleExcelReader.FieldCount - 1
                            excelTable.Columns.Add(oleExcelReader.Item(i).ToString)
                        Next
                        doOnce = False
                    Else
                        Try
                            Dim row As DataRow = excelTable.NewRow
                            For i As Integer = 0 to oleExcelReader.FieldCount - 1
								row(i) = oleExcelReader.Item(i).ToString
							Next
                            excelTable.Rows.Add(row)
                        Catch ex As Exception
                            oleExcelReader.Close()
                            oleExcelReader = Nothing
                            oleExcelConnection.Close()
                            Exit While
                        End Try
                    End If
                End While
            End If
            If oleExcelConnection.State = ConnectionState.Open Then oleExcelConnection.Close()
            Return excelTable
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return Nothing
    End Function
