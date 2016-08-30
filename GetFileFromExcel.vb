Public Shared Function GetFileFromExcel(fullFileName As String) As DataTable
        Try
            Dim incre = 0
            Dim excelData As New System.Data.DataTable
            Dim doOnce As Boolean = True
            Dim excel = New LinqToExcel.ExcelQueryFactory(fullFileName)
            Dim records = From r In excel.Worksheet
                          Select r

            For Each rec In records
                If doOnce Then
                    For Each item In rec.ColumnNames
                        excelData.Columns.Add(item.ToString)
                    Next
                    doOnce = False
                End If
                Dim rowval As DataRow = excelData.NewRow()
                For Each r In rec
                    rowval(incre) = r.Value.ToString
                    incre += 1
                Next
                excelData.Rows.Add(rowval)
                incre = 0
            Next
            Return excelData
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return Nothing
    End Function