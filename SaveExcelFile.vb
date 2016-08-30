Private Declare Auto Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr,
              ByRef lpdwProcessId As Integer) As Integer
Public Shared Function SaveExcelFile(fullPathAndFile As String, excelData As DataTable) As Boolean
        Dim xproc As New Process
        Dim xlHWND As Integer = 0
        Dim procIdXL As Integer = 0
        Dim xlApp As New Excel.Application
        Try
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            xlHWND = xlApp.Hwnd

            xlApp.DisplayAlerts = False
            xlApp.ScreenUpdating = False
            GetWindowThreadProcessId(xlHWND, procIdXL)
            xproc = Process.GetProcessById(procIdXL)
            'create the file
            xlWorkBook = xlApp.Workbooks.Add()
            xlWorkBook.SaveAs(Filename:=fullPathAndFile)
            'get the new worksheet values and save
            xlWorkSheet = AddExcelValues(xlWorkBook, excelData)
            xlWorkBook.Close(SaveChanges:=True)
            xlApp.ScreenUpdating = True
            xlApp.DisplayAlerts = True
            xlApp.Quit()
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlApp)
            If Not xproc.HasExited Then
                xproc.Kill()
            End If
            Return True
        Catch ex As Exception
            If Not xproc.HasExited Then
                xproc.Kill()
            End If
            MsgBox(ex.Message + " :In SaveExcelFile!")
        End Try
        Return False
    End Function
	Private Shared Function AddExcelValues(ByRef xlWorkBook As Excel.Workbook,
                            excelValues As DataTable) As Excel.Worksheet
        Try
            Dim xlWorkSheet As Excel.Worksheet
            Dim startRow As Integer = 1
            xlWorkSheet = xlWorkBook.Worksheets(1)
            With xlWorkSheet
                For i As Integer = 0 To excelValues.Columns.Count - 1
                    .Cells(startRow, i + 1) = excelValues.Columns(i).ToString
                Next i
                startRow += 1
                For j As Integer = 0 To excelValues.Rows.Count - 1
                    For i As Integer = 0 To excelValues.Columns.Count - 1
                        .Cells(startRow, i + 1) = excelValues.Rows(j).Item(i).ToString
                    Next i
                    startRow += 1
                Next j
            End With
            Return xlWorkSheet
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function
	Private Shared Sub ReleaseComObject(ByVal p As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(p) > 0)
                p = Nothing
            End While
        Catch ex As System.ComponentModel.Win32Exception
            p = Nothing
        End Try
    End Sub