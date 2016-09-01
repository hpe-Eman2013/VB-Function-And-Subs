Public Shared Function GetNextID(connectString As String, numRecsNeeded As Integer,
						pKeyIndex As String, tableName As String) As List(Of Integer)
        Try
			Dim sql As String = String.Format("Select * From {0}", tablename)
			Dim dt = DatabaseFiles.GetAllRecords(sql, connectString)
            If IsNothing(dt) Or dt.Rows.Count < 1 Then
                Return Enumerable.Range(1, numRecsNeeded).ToList()
            End If
            'records exists, so get all the available IDs matching the number needed

            Dim existingNumbers As List(Of Integer) = _
                dt.AsEnumerable.Select(Function(x) CType(x.Item(pKeyIndex), Integer)).ToList
            Dim min As List(Of Integer) = Enumerable.Range(existingNumbers.Item(0),
                existingNumbers.Item(existingNumbers.Count - 1)).ToList
            'compare the total number of records with those IDs that are missing 
            Dim missingNumbers = min.Except(existingNumbers).ToList
            'use the missing IDs and put them into a list
            If missingNumbers.Count < numRecsNeeded Then
                sql = String.Format("Select Max({0}) From {1}", pKeyIndex, tableName)
                Dim maxId = GetAllRecords(sql)
                Dim nextRecNum = CInt(maxId.Rows(0).Item(0).ToString) + 1
                While missingNumbers.Count < numRecsNeeded
                    missingNumbers.Add(nextRecNum)
                    nextRecNum += 1
                End While
            Else
                missingNumbers.RemoveRange(numRecsNeeded, missingNumbers.Count - numRecsNeeded)
            End If
            Return missingNumbers
		Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
	Public Shared Function GetAllRecords(sqlQuery As String, conString as String) As DataTable
        Try
            Dim _dsObj As New DataSet
            Using _conObj As New SqlConnection(ConnectString)
                _conObj.Open()
                Dim cmd As New SqlCommand(sqlQuery, _conObj)
                Using _adapterObj As New SqlDataAdapter(cmd)
                    Using cb As New SqlCommandBuilder(_adapterObj)
                        Try
                            _adapterObj.Fill(_dsObj)
                            Return _dsObj.Tables(0)
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                            Return Nothing
                        End Try
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
