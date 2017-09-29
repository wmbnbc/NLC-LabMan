<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formSentry
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
        Me.buttonAcademic = New System.Windows.Forms.Button()
        Me.buttonPersonal = New System.Windows.Forms.Button()
        Me.labelWelcome = New System.Windows.Forms.Label()
        Me.labelTypeOfWork = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'buttonAcademic
        '
        Me.buttonAcademic.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.buttonAcademic.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonAcademic.Location = New System.Drawing.Point(34, 275)
        Me.buttonAcademic.Name = "buttonAcademic"
        Me.buttonAcademic.Size = New System.Drawing.Size(255, 85)
        Me.buttonAcademic.TabIndex = 0
        Me.buttonAcademic.Text = "Academic"
        Me.buttonAcademic.UseVisualStyleBackColor = True
        '
        'buttonPersonal
        '
        Me.buttonPersonal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.buttonPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonPersonal.Location = New System.Drawing.Point(338, 275)
        Me.buttonPersonal.Name = "buttonPersonal"
        Me.buttonPersonal.Size = New System.Drawing.Size(255, 85)
        Me.buttonPersonal.TabIndex = 1
        Me.buttonPersonal.Text = "Personal"
        Me.buttonPersonal.UseVisualStyleBackColor = True
        '
        'labelWelcome
        '
        Me.labelWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.labelWelcome.AutoSize = True
        Me.labelWelcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelWelcome.Location = New System.Drawing.Point(15, 80)
        Me.labelWelcome.Name = "labelWelcome"
        Me.labelWelcome.Size = New System.Drawing.Size(606, 37)
        Me.labelWelcome.TabIndex = 2
        Me.labelWelcome.Text = "Welcome to the NTID Learning Center!"
        '
        'labelTypeOfWork
        '
        Me.labelTypeOfWork.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.labelTypeOfWork.AutoSize = True
        Me.labelTypeOfWork.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTypeOfWork.Location = New System.Drawing.Point(87, 191)
        Me.labelTypeOfWork.Name = "labelTypeOfWork"
        Me.labelTypeOfWork.Size = New System.Drawing.Size(452, 31)
        Me.labelTypeOfWork.TabIndex = 3
        Me.labelTypeOfWork.Text = "What type of work will you be doing?"
        '
        'formSentry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.labelTypeOfWork)
        Me.Controls.Add(Me.labelWelcome)
        Me.Controls.Add(Me.buttonPersonal)
        Me.Controls.Add(Me.buttonAcademic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formSentry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "NLC Sentry"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents buttonAcademic As Button
    Friend WithEvents buttonPersonal As Button
    Friend WithEvents labelWelcome As Label
    Friend WithEvents labelTypeOfWork As Label
End Class
