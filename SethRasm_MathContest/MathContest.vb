
Option Strict On
Option Explicit On

Public Class MathContest
    'Set up loader for the form
    'Disable the Answer and submit 
    Private Sub MathContest_Load(sender As Object, e As EventArgs) Handles Me.Load
        StudentAnswerTextBox.Enabled = False
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
    End Sub

    'Close the form 
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ProblemTypeGroupBox_TextChanged(sender As Object, e As EventArgs) Handles ProblemTypeGroupBox.TextChanged
        If FirstNumberTextBox.Text = "" And SecondNumberTextBox.Text = "" Then
            StudentAnswerTextBox.Enabled = False
        Else
            StudentAnswerTextBox.Enabled = True
        End If
    End Sub
    Function NumberValidation(input As String) As Boolean
        Dim number As Integer
        Dim converstion As Boolean = False
        Try
            number = CInt(input)
        Catch ex As Exception
        End Try
        Return converstion
    End Function

    Private Sub FirstNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles FirstNumberTextBox.TextChanged, SecondNumberTextBox.TextChanged
        Dim number1 As Boolean = NumberValidation(FirstNumberTextBox.Text)
        Dim number2 As Boolean = NumberValidation(SecondNumberTextBox.Text)
        If FirstNumberTextBox.Text = "" Then
        ElseIf SecondNumberTextBox.Text = "" Then
        ElseIf number1 = True And number2 = True Then
            StudentAnswerTextBox.Enabled = True
        End If
        ProblemTypeGroupBox.Enabled = False
    End Sub
    'Turn on the submit button as soon as text is entered into the StudentAnswerTextBox
    Private Sub StudentAnswerTextBox_TextChanged(sender As Object, e As EventArgs) Handles StudentAnswerTextBox.TextChanged
        SubmitButton.Enabled = True
    End Sub

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
        If problem = False Then
            mathcheck()
        End If
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        mathcheck()
    End Sub
    Sub mathcheck()
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
End Class
