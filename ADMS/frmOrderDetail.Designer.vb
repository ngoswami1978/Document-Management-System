<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAppliedDate = New System.Windows.Forms.TextBox
        Me.txtOrderApprovalDate = New System.Windows.Forms.TextBox
        Me.txtAgencyPC = New System.Windows.Forms.TextBox
        Me.txtAmadeusPC = New System.Windows.Forms.TextBox
        Me.txtAmadeusPrinter = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtOrderStatus = New System.Windows.Forms.TextBox
        Me.txtOrderType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOrderNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Approval Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(538, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Applied Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Agency PC"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(296, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Amadeus PC"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(538, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Amadeus Printer"
        '
        'txtAppliedDate
        '
        Me.txtAppliedDate.BackColor = System.Drawing.SystemColors.Control
        Me.txtAppliedDate.Location = New System.Drawing.Point(628, 39)
        Me.txtAppliedDate.Name = "txtAppliedDate"
        Me.txtAppliedDate.ReadOnly = True
        Me.txtAppliedDate.Size = New System.Drawing.Size(139, 20)
        Me.txtAppliedDate.TabIndex = 9
        '
        'txtOrderApprovalDate
        '
        Me.txtOrderApprovalDate.BackColor = System.Drawing.SystemColors.Control
        Me.txtOrderApprovalDate.Location = New System.Drawing.Point(87, 36)
        Me.txtOrderApprovalDate.Name = "txtOrderApprovalDate"
        Me.txtOrderApprovalDate.ReadOnly = True
        Me.txtOrderApprovalDate.Size = New System.Drawing.Size(139, 20)
        Me.txtOrderApprovalDate.TabIndex = 13
        '
        'txtAgencyPC
        '
        Me.txtAgencyPC.BackColor = System.Drawing.SystemColors.Control
        Me.txtAgencyPC.Location = New System.Drawing.Point(87, 62)
        Me.txtAgencyPC.Name = "txtAgencyPC"
        Me.txtAgencyPC.ReadOnly = True
        Me.txtAgencyPC.Size = New System.Drawing.Size(139, 20)
        Me.txtAgencyPC.TabIndex = 14
        '
        'txtAmadeusPC
        '
        Me.txtAmadeusPC.BackColor = System.Drawing.SystemColors.Control
        Me.txtAmadeusPC.Location = New System.Drawing.Point(370, 62)
        Me.txtAmadeusPC.Name = "txtAmadeusPC"
        Me.txtAmadeusPC.ReadOnly = True
        Me.txtAmadeusPC.Size = New System.Drawing.Size(139, 20)
        Me.txtAmadeusPC.TabIndex = 15
        '
        'txtAmadeusPrinter
        '
        Me.txtAmadeusPrinter.BackColor = System.Drawing.SystemColors.Control
        Me.txtAmadeusPrinter.Location = New System.Drawing.Point(628, 65)
        Me.txtAmadeusPrinter.Name = "txtAmadeusPrinter"
        Me.txtAmadeusPrinter.ReadOnly = True
        Me.txtAmadeusPrinter.Size = New System.Drawing.Size(139, 20)
        Me.txtAmadeusPrinter.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(632, 446)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(714, 446)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 19
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.txtAmadeusPrinter)
        Me.GroupBox1.Controls.Add(Me.txtAppliedDate)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtAmadeusPC)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtAgencyPC)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtOrderApprovalDate)
        Me.GroupBox1.Controls.Add(Me.txtOrderStatus)
        Me.GroupBox1.Controls.Add(Me.txtOrderType)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtOrderNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(773, 427)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.SystemColors.Window
        Me.txtRemarks.Location = New System.Drawing.Point(85, 91)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(682, 321)
        Me.txtRemarks.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(538, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Status"
        '
        'txtOrderStatus
        '
        Me.txtOrderStatus.BackColor = System.Drawing.SystemColors.Control
        Me.txtOrderStatus.Location = New System.Drawing.Point(628, 13)
        Me.txtOrderStatus.Name = "txtOrderStatus"
        Me.txtOrderStatus.ReadOnly = True
        Me.txtOrderStatus.Size = New System.Drawing.Size(139, 20)
        Me.txtOrderStatus.TabIndex = 18
        '
        'txtOrderType
        '
        Me.txtOrderType.BackColor = System.Drawing.SystemColors.Control
        Me.txtOrderType.Location = New System.Drawing.Point(370, 13)
        Me.txtOrderType.Name = "txtOrderType"
        Me.txtOrderType.ReadOnly = True
        Me.txtOrderType.Size = New System.Drawing.Size(139, 20)
        Me.txtOrderType.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "OrderNo"
        '
        'txtOrderNo
        '
        Me.txtOrderNo.BackColor = System.Drawing.SystemColors.Control
        Me.txtOrderNo.Location = New System.Drawing.Point(87, 10)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.Size = New System.Drawing.Size(139, 20)
        Me.txtOrderNo.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(296, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Type"
        '
        'frmOrderDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 478)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrderDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OrderDetail Add Remarks"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAppliedDate As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderApprovalDate As System.Windows.Forms.TextBox
    Friend WithEvents txtAgencyPC As System.Windows.Forms.TextBox
    Friend WithEvents txtAmadeusPC As System.Windows.Forms.TextBox
    Friend WithEvents txtAmadeusPrinter As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOrderStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
End Class
