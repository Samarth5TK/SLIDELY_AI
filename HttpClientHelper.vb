Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text

Public Class HttpClientHelper
    Private ReadOnly baseUrl As String = "http://localhost:3000" ' Replace with your backend server URL

    Private ReadOnly httpClient As HttpClient

    Public Sub New()
        httpClient = New HttpClient()
    End Sub

    Public Async Function SubmitSubmissionAsync(name As String, email As String, phone As String, githubLink As String, stopwatchTime As String) As Task(Of Boolean)
        Try
            Dim submission As New Dictionary(Of String, String) From {
                {"name", name},
                {"email", email},
                {"phone", phone},
                {"github_link", githubLink},
                {"stopwatch_time", stopwatchTime}
            }

            Dim json As String = JsonConvert.SerializeObject(submission)
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await httpClient.PostAsync($"{baseUrl}/submit", content)
            Return response.IsSuccessStatusCode
        Catch ex As Exception
            MessageBox.Show($"Error submitting form: {ex.Message}")
            Return False
        End Try
    End Function

    Public Async Function ReadSubmissionAsync(index As Integer) As Task(Of Dictionary(Of String, String))
        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync($"{baseUrl}/read?index={index}")
            If response.IsSuccessStatusCode Then
                Dim json As String = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
            Else
                MessageBox.Show("Failed to retrieve submission.")
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show($"Error reading submission: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Public Async Function PingServerAsync() As Task(Of Boolean)
        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync($"{baseUrl}/ping")
            Return response.IsSuccessStatusCode
        Catch ex As Exception
            MessageBox.Show($"Error pinging server: {ex.Message}")
            Return False
        End Try
    End Function
End Class