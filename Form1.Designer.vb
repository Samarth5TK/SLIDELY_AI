﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnViewSubmissions = New System.Windows.Forms.Button()
        Me.btnCreateSubmission = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnViewSubmissions
        '
        Me.btnViewSubmissions.BackColor = System.Drawing.Color.Yellow
        Me.btnViewSubmissions.Location = New System.Drawing.Point(122, 82)
        Me.btnViewSubmissions.Name = "btnViewSubmissions"
        Me.btnViewSubmissions.Size = New System.Drawing.Size(582, 77)
        Me.btnViewSubmissions.TabIndex = 0
        Me.btnViewSubmissions.Text = "VIEW SUBMISSIONS (CTRL + V)"
        Me.btnViewSubmissions.UseVisualStyleBackColor = False
        '
        'btnCreateSubmission
        '
        Me.btnCreateSubmission.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList
        Me.btnCreateSubmission.BackColor = System.Drawing.Color.LightBlue
        Me.btnCreateSubmission.Location = New System.Drawing.Point(122, 207)
        Me.btnCreateSubmission.Name = "btnCreateSubmission"
        Me.btnCreateSubmission.Size = New System.Drawing.Size(582, 77)
        Me.btnCreateSubmission.TabIndex = 1
        Me.btnCreateSubmission.Text = "CREATE NEW SUBMISSION (CTRL + N)"
        Me.btnCreateSubmission.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnCreateSubmission)
        Me.Controls.Add(Me.btnViewSubmissions)
        Me.Name = "Form1"
        Me.Text = "Samarth T K"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnViewSubmissions As Button
    Friend WithEvents btnCreateSubmission As Button
End Class
