Public Shared Function AddDataToCsvFile(filename As String, csvData As DataTable) As Boolean
        Try
            Dim sep As String = Nothing
            Dim counter As Integer = 0

            Using writer = New StreamWriter(filename)
                Dim builder As New System.Text.StringBuilder
                For Each col As DataColumn In csvData.Columns
                    counter = GetCounter(counter)
                    If counter < 3 Then
                        sep = String.Format("{0, -10}", col.ColumnName)
                    Else
                        sep = String.Format("{0, -30}", col.ColumnName)
                    End If
                    builder.Append(sep)
                Next
                writer.WriteLine(builder.ToString)
                For Each row As DataRow In csvData.Rows
                    counter = 0
                    builder = New System.Text.StringBuilder
                    For Each col As DataColumn In csvData.Columns
                        counter = GetCounter(counter)
                        If counter < 3 Then
                            sep = String.Format("{0, -10}", row(col.ColumnName))
                        Else
                            sep = String.Format("{0, -30}", row(col.ColumnName))
                        End If
                        builder.Append(sep)
                    Next
                    writer.WriteLine(builder.ToString)
                Next
            End Using
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function
	Private Shared Function GetCounter(ByRef counterValue As Integer) As Integer
        If counterValue > 4 Then Return 0
        counterValue = counterValue + 1
        Return counterValue
    End Function