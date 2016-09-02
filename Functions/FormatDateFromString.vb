Public Function FormatDateFromString(dateString As String, _
                changeOrder As DateValueChange) As String
        Try
            Dim tempString = FormatStringForDate(dateString)
            Select Case changeOrder
                Case DateValueChange.FirstSetForSecond
                    Return FirstSetForSecond(tempString)
                Case DateValueChange.SecondSetForThird
                    Return SecondSetForThird(tempString)
                Case DateValueChange.FirstSetForThird
                    Return FirstSetForThird(tempString)
                Case DateValueChange.FormatForDate
                    Return FormatStringForDate(dateString)
            End Select
            Return tempString
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Enum DateValueChange
        FirstSetForSecond
        SecondSetForThird
        FirstSetForThird
        FormatForDate
    End Enum
    Private Function FirstSetForThird(tempString As String) As String
        Dim first As String = tempString.Substring(0, tempString.IndexOf("/"))
        Dim second = tempString.Substring(tempString.IndexOf("/") + 1, tempString.LastIndexOf("/") - 2)
        Dim third = tempString.Substring(tempString.LastIndexOf("/") + 1)
        tempString = third + "/" + second + "/" + first
        Return tempString
    End Function

    Private Function SecondSetForThird(tempString As String) As String
        Dim first As String = tempString.Substring(0, tempString.IndexOf("/"))
        Dim second = tempString.Substring(tempString.IndexOf("/") + 1, tempString.LastIndexOf("/") - 2)
        Dim third = tempString.Substring(tempString.LastIndexOf("/") + 1)
        tempString = first + "/" + third + "/" + second
        Return tempString
    End Function

    Private Function FirstSetForSecond(tempString As String) As String
        Dim first As String = tempString.Substring(0, tempString.IndexOf("/"))
        Dim second = tempString.Substring(tempString.IndexOf("/") + 1, tempString.LastIndexOf("/") - 2)
        Dim third = tempString.Substring(tempString.LastIndexOf("/") + 1)
        tempString = second + "/" + first + "/" + third
        Return tempString
    End Function
    
    Private Function FormatStringForDate(dateString As String) As String
        Dim weekdays() As String = {"Sunday", "Monday", "Tuesday",
                                    "Wednesday", "Thursday", "Friday", "Saturday"}
        Dim monthDate
        Dim shortMonth = Regex.Replace(dateString, "[0-9_///.-]", "")
        If Not String.IsNullOrWhiteSpace(shortMonth) Then
            monthDate = ConvertMonthNameToNumber(shortMonth)
        Else
            monthDate = ""
        End If
        Dim longString As String = Regex.Replace(dateString, "[a-zA-Z, ///.-]", "")
        longString = monthDate & longString
        Return ParseNumbersAsDate(longString)
    End Function
    Private Function ConvertMonthNameToNumber(monthName As String) As Integer
        Dim monthsInEnglish() As String = {"Empty", "January", "February", "March", "April", "May",
                "June", "July", "August", "September", "October", "November", "December"}
        Dim index As Integer = 0
        Try
            For Each monthval As String In monthsInEnglish
                If monthName.ToString.ToLower.Contains(monthval.ToString.ToLower.Substring(0, 3)) Then
                    Return index
                End If
                index += 1
            Next
        Catch ex As Exception

        End Try
        Return Integer.Parse(monthName)
    End Function

    Private Function ParseNumbersAsDate(longString As String) As String
        Dim first, second, third As Integer

        Select Case Len(longString)
            Case 8
                first = longString.Substring(0, 2)
                second = longString.Substring(2, 2)
                third = longString.Substring(4)
            Case 7
                first = longString.Substring(0, 1)
                second = longString.Substring(1, 2)
                third = longString.Substring(3)
            Case 6
                first = longString.Substring(0, 1)
                second = longString.Substring(1, 1)
                third = longString.Substring(2)
            Case Else
                Return longString
        End Select
        Dim formattedString = first & "/" & second & "/" & third
        Return formattedString
    End Function