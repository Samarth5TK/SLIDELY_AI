Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text
Imports System.Threading.Tasks

Public Class CreateSubmissionForm
    Private stopwatch As Stopwatch = New Stopwatch()
    Private httpClient As HttpClient = New HttpClient()

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize stopwatch display
        UpdateStopwatchDisplay()
    End Sub

    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            btnStopwatch.Text = "Resume"
        Else
            stopwatch.Start()
            btnStopwatch.Text = "Pause"
            ' Start updating the stopwatch display asynchronously
            Task.Run(Sub() UpdateStopwatchDisplay())
        End If
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim name As String = txtName.Text
        Dim email As String = txtEmail.Text
        Dim phone As String = txtPhone.Text
        Dim githubLink As String = txtGitHubLink.Text
        Dim stopwatchTime As String = stopwatch.Elapsed.ToString()

        Dim submission As New Dictionary(Of String, String) From {
            {"name", name},
            {"email", email},
            {"phone", phone},
            {"github_link", githubLink},
            {"stopwatch_time", stopwatchTime}
        }

        Try
            Dim json As String = JsonConvert.SerializeObject(submission)
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await httpClient.PostAsync("http://localhost:3000/submit", content)

            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission successful!")
            Else
                MessageBox.Show("Submission failed: " & response.ReasonPhrase)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error submitting form: {ex.Message}")
        End Try
    End Sub

    Private Sub UpdateStopwatchDisplay()
        Do While stopwatch.IsRunning
            ' Update the stopwatch display safely on the UI thread
            lblStopwatch.Invoke(Sub()
                                    lblStopwatch.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
                                End Sub)
            Threading.Thread.Sleep(1000) ' Update every second
        Loop
    End Sub
End Class