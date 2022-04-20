'Seth Rasmussen
'RCET 0265
'Spring 2022
'Math Contest
'https://github.com/SethRas/SethRasm_MathContest.git

Option Strict On
Option Explicit On

Public Class MathContest
    'Set up loader for the form
    'Disable the Answer and submit 
    Private Sub MathContest_Load(sender As Object, e As EventArgs) Handles Me.Load
        StudentAnswerTextBox.Enabled = True
        SubmitButton.Enabled = False
        SummaryButton.Enabled = True
    End Sub

    'Set Up the clear button to write all entries to empty
    'Enable or disable certain areas of the form to the start up state
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        StudentNameTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
        FirstNumberTextBox.Text = ""
        SecondNumberTextBox.Text = ""
        StudentAnswerTextBox.Text = ""
        FirstNumberTextBox.Enabled = True
        SecondNumberTextBox.Enabled = True
        StudentAnswerTextBox.Enabled = False
        SubmitButton.Enabled = False
        AdditionRadioButton.Enabled = True
        SubtractRadioButton.Enabled = True
        MultiplyRadioButton.Enabled = True
        DivideRadioButton.Enabled = True
    End Sub

    'This function confirms the integers for the code like the grade and age
    'value returns true or false
    Function NumberValidation(input As String) As Boolean
        Dim number As Integer
        Dim value As Boolean = False
        Try
            number = CInt(input)
            value = True
        Catch ex As Exception
        End Try
        Return value
    End Function

    'Look at the the Problem Type group box confirm if something has changed
    'If the Numbers are blank then the student answer box should be grayed out
    'If there are numbers present then the student answer box should become enabled
    Private Sub ProblemTypeGroupBox_TextChanged(sender As Object, e As EventArgs) Handles ProblemTypeGroupBox.TextChanged
        If FirstNumberTextBox.Text = "" And SecondNumberTextBox.Text = "" Then
            StudentAnswerTextBox.Enabled = True
        Else
            StudentAnswerTextBox.Enabled = False
        End If
    End Sub

    'Recall the Validation function for Numbers 1 and 2
    'Enable Student Answer
    'Turn off the ProblemType group box
    Private Sub FirstNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles FirstNumberTextBox.TextChanged, SecondNumberTextBox.TextChanged
        Dim number1 As Boolean = NumberValidation(FirstNumberTextBox.Text)
        Dim number2 As Boolean = NumberValidation(SecondNumberTextBox.Text)
        If number1 = True And number2 = True Then
            StudentAnswerTextBox.Enabled = True
        End If
        ProblemTypeGroupBox.Enabled = False
    End Sub

    'Turn on the submit button as soon as text Is entered into the StudentAnswerTextBox
    Private Sub StudentAnswerTextBox_TextChanged(sender As Object, e As EventArgs) Handles StudentAnswerTextBox.TextChanged
        SubmitButton.Enabled = True
    End Sub

    'Age between 7 and 11
    'Grade between 1 and 4
    'Throw error for values outside specified range and focus on offending entry
    'recall from Validation

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        SummaryButton.Enabled = True
        Dim grade As Integer
        Dim age As Integer
        Dim ageCheck As Boolean = NumberValidation(AgeTextBox.Text)
        Dim gradecheck As Boolean = NumberValidation(GradeTextBox.Text)
        Dim problem As Boolean = False
        If ageCheck = True Then
            age = CInt(AgeTextBox.Text)
            If age > 11 Then
                problem = True
                MsgBox("Student not eligible to compete")
                AgeTextBox.Text = ""
                AgeTextBox.Focus()
            ElseIf age < 7 Then
                problem = True
                MsgBox("Student not eligible to compete")
                AgeTextBox.Text = ""
                AgeTextBox.Focus()
            ElseIf ageCheck = False Then
                problem = True
                MsgBox("Age must be a whole number")
                AgeTextBox.Text = ""
                AgeTextBox.Focus()
            End If

        End If
        If gradecheck = True And problem = False Then
            If grade > 1 Then
                problem = True
                MsgBox("Student not eligible to compete")
                GradeTextBox.Text = ""
                GradeTextBox.Focus()
            ElseIf grade > 4 Then
                problem = True
                MsgBox("Student not eligible to compete")
                GradeTextBox.Text = ""
                GradeTextBox.Focus()
            End If

        ElseIf gradecheck = False And problem = False Then
            problem = True
            MsgBox("Grade must be a whole number")
            GradeTextBox.Text = ""
            GradeTextBox.Focus()
        End If

        'Call math sub
        If problem = False Then
            math()
        End If
    End Sub

    'When Submit is selected calculate student response

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        math()
    End Sub

    'Find radio button
    'radio button operation
    'Add success to trys
    'Total number of tries vs correct
    'Blank number boxes after summary button click
    'Summary button displays count

    Sub math()
        Static attempts As Integer
        Static correctResponses As Integer

        If SubmitButton.Focused = True Then
            attempts += 1
            Dim number1 As Integer = CInt(FirstNumberTextBox.Text)
            Dim number2 As Integer = CInt(SecondNumberTextBox.Text)
            If NumberValidation(StudentAnswerTextBox.Text) = True Then
                Dim studentAnswer As Integer = CInt(StudentAnswerTextBox.Text)
                If AdditionRadioButton.Checked = True Then
                    If number1 + number2 = studentAnswer Then
                        MsgBox("Correct")
                        correctResponses += 1
                    Else
                        MsgBox($"the correct answer is {number1 + number2}")
                    End If
                End If
                If SubtractRadioButton.Checked = True Then
                    If number1 - number2 = studentAnswer Then
                        MsgBox("Correct")
                        correctResponses += 1
                    Else
                        MsgBox($"the correct answer is {number1 - number2}")
                    End If
                End If
                If MultiplyRadioButton.Checked = True Then
                    If number1 * number2 = studentAnswer Then
                        MsgBox("Correct")
                        correctResponses += 1
                    Else
                        MsgBox($"the correct answer is {number1 * number2}")
                    End If
                End If
                If DivideRadioButton.Checked = True Then
                    If number1 / number2 = studentAnswer Then
                        MsgBox("Correct")
                        correctResponses += 1
                    Else
                        MsgBox($"the correct answer is {number1 / number2}")
                    End If
                End If
            End If
            FirstNumberTextBox.Text = ""
            SecondNumberTextBox.Text = ""
            StudentAnswerTextBox.Text = ""
            ProblemTypeGroupBox.Enabled = True
            SubmitButton.Enabled = False
        Else
            MsgBox($"{StudentNameTextBox.Text} got {correctResponses} questions correct out of {attempts}")
        End If
    End Sub

    'Close the form 
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

End Class
