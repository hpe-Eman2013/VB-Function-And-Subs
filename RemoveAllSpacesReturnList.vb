Public Shared Function RemoveAllSpaces(longString As String) As List(Of String)
        Try
            Dim lstValues As New List(Of String)
            Dim foundHyphen As Boolean = False
            Dim modified As Boolean = False
            For i As Integer = 1 To Len(longString)
                If Not String.IsNullOrWhiteSpace(Mid(longString, i, 1).ToString) Then
                    Dim counter = i
                    Dim temp As String = Nothing
                    While Not String.IsNullOrWhiteSpace(Mid(longString, counter, 1)) _
                        And counter <= Len(longString)
                        If Mid(longString, counter, 1).Equals("-") Then
                            lstValues.Item(lstValues.Count - 1) += "-"
                            foundHyphen = True
                            Exit While
                        Else
                            If foundHyphen Then
                                While Not String.IsNullOrWhiteSpace(Mid(longString, counter, 1))
                                    temp += Mid(longString, counter, 1)
                                    counter += 1
                                End While
                                If lstValues.Item(lstValues.Count - 1).Contains("-") Then
                                    lstValues.Item(lstValues.Count - 1) += temp
                                    foundHyphen = False
                                    modified = True
                                End If
                            Else
                                temp += Mid(longString, counter, 1)
                            End If
                        End If
                        counter += 1
                    End While
                    If Not foundHyphen Then
                        If modified = False Then
                            lstValues.Add(temp)
                            temp = String.Empty
                            i = (counter - 1)
                        Else
                            modified = False
                            i = counter
                        End If
                    End If
                End If
            Next
            Return lstValues
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return Nothing
    End Function