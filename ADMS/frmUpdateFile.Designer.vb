<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateFile))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.drpRawFileNo = New System.Windows.Forms.ComboBox
        Me.drpRawOrderType = New System.Windows.Forms.ComboBox
        Me.txtRawOrderNo = New System.Windows.Forms.ComboBox
        Me.lstRawList = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lstFinalList = New System.Windows.Forms.ListBox
        Me.drpOrderType = New System.Windows.Forms.ComboBox
        Me.drpOrderNo = New System.Windows.Forms.ComboBox
        Me.drpFileNo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnMoveRight = New System.Windows.Forms.Button
        Me.btnMoveLeft = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.drpRawFileNo)
        Me.Panel1.Controls.Add(Me.drpRawOrderType)
        Me.Panel1.Controls.Add(Me.txtRawOrderNo)
        Me.Panel1.Controls.Add(Me.lstRawList)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(261, 277)
        Me.Panel1.TabIndex = 0
        '
        'drpRawFileNo
        '
        Me.drpRawFileNo.BackColor = System.Drawing.SystemColors.Window
        Me.drpRawFileNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpRawFileNo.FormattingEnabled = True
        Me.drpRawFileNo.Location = New System.Drawing.Point(75, 6)
        Me.drpRawFileNo.Name = "drpRawFileNo"
        Me.drpRawFileNo.Size = New System.Drawing.Size(66, 21)
        Me.drpRawFileNo.TabIndex = 27
        '
        'drpRawOrderType
        '
        Me.drpRawOrderType.BackColor = System.Drawing.SystemColors.Window
        Me.drpRawOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpRawOrderType.FormattingEnabled = True
        Me.drpRawOrderType.Location = New System.Drawing.Point(75, 59)
        Me.drpRawOrderType.Name = "drpRawOrderType"
        Me.drpRawOrderType.Size = New System.Drawing.Size(177, 21)
        Me.drpRawOrderType.TabIndex = 26
        '
        'txtRawOrderNo
        '
        Me.txtRawOrderNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtRawOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.txtRawOrderNo.FormattingEnabled = True
        Me.txtRawOrderNo.Location = New System.Drawing.Point(75, 33)
        Me.txtRawOrderNo.Name = "txtRawOrderNo"
        Me.txtRawOrderNo.Size = New System.Drawing.Size(177, 21)
        Me.txtRawOrderNo.TabIndex = 25
        '
        'lstRawList
        '
        Me.lstRawList.FormattingEnabled = True
        Me.lstRawList.Location = New System.Drawing.Point(75, 85)
        Me.lstRawList.Name = "lstRawList"
        Me.lstRawList.Size = New System.Drawing.Size(177, 186)
        Me.lstRawList.Sorted = True
        Me.lstRawList.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Pages"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Order Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Order No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "File No"
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel2.Controls.Add(Me.lstFinalList)
        Me.Panel2.Controls.Add(Me.drpOrderType)
        Me.Panel2.Controls.Add(Me.drpOrderNo)
        Me.Panel2.Controls.Add(Me.drpFileNo)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(325, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 277)
        Me.Panel2.TabIndex = 1
        '
        'lstFinalList
        '
        Me.lstFinalList.FormattingEnabled = True
        Me.lstFinalList.Location = New System.Drawing.Point(76, 85)
        Me.lstFinalList.Name = "lstFinalList"
        Me.lstFinalList.Size = New System.Drawing.Size(177, 186)
        Me.lstFinalList.Sorted = True
        Me.lstFinalList.TabIndex = 9
        '
        'drpOrderType
        '
        Me.drpOrderType.BackColor = System.Drawing.SystemColors.Window
        Me.drpOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpOrderType.FormattingEnabled = True
        Me.drpOrderType.Location = New System.Drawing.Point(76, 59)
        Me.drpOrderType.Name = "drpOrderType"
        Me.drpOrderType.Size = New System.Drawing.Size(177, 21)
        Me.drpOrderType.TabIndex = 28
        '
        'drpOrderNo
        '
        Me.drpOrderNo.BackColor = System.Drawing.SystemColors.Window
        Me.drpOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpOrderNo.FormattingEnabled = True
        Me.drpOrderNo.Location = New System.Drawing.Point(76, 35)
        Me.drpOrderNo.Name = "drpOrderNo"
        Me.drpOrderNo.Size = New System.Drawing.Size(177, 21)
        Me.drpOrderNo.TabIndex = 27
        '
        'drpFileNo
        '
        Me.drpFileNo.BackColor = System.Drawing.SystemColors.Window
        Me.drpFileNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpFileNo.FormattingEnabled = True
        Me.drpFileNo.Location = New System.Drawing.Point(76, 9)
        Me.drpFileNo.Name = "drpFileNo"
        Me.drpFileNo.Size = New System.Drawing.Size(66, 21)
        Me.drpFileNo.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Pages"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Order Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Order No"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "File No"
        '
        'btnMoveRight
        '
        Me.btnMoveRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveRight.Location = New System.Drawing.Point(275, 106)
        Me.btnMoveRight.Name = "btnMoveRight"
        Me.btnMoveRight.Size = New System.Drawing.Size(44, 25)
        Me.btnMoveRight.TabIndex = 2
        Me.btnMoveRight.Text = ">"
        Me.btnMoveRight.UseVisualStyleBackColor = True
        '
        'btnMoveLeft
        '
        Me.btnMoveLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLeft.Location = New System.Drawing.Point(275, 137)
        Me.btnMoveLeft.Name = "btnMoveLeft"
        Me.btnMoveLeft.Size = New System.Drawing.Size(44, 25)
        Me.btnMoveLeft.TabIndex = 3
        Me.btnMoveLeft.Text = "<"
        Me.btnMoveLeft.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPreview.Location = New System.Drawing.Point(591, 3)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(76, 23)
        Me.btnPreview.TabIndex = 28
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(591, 26)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 23)
        Me.btnSave.TabIndex = 29
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(591, 49)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 30
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmUpdateFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 284)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnMoveLeft)
        Me.Controls.Add(Me.btnMoveRight)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmUpdateFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update File"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstRawList As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lstFinalList As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnMoveRight As System.Windows.Forms.Button
    Friend WithEvents btnMoveLeft As System.Windows.Forms.Button
    Friend WithEvents drpRawOrderType As System.Windows.Forms.ComboBox
    Friend WithEvents drpFileNo As System.Windows.Forms.ComboBox
    Friend WithEvents drpOrderType As System.Windows.Forms.ComboBox
    Friend WithEvents drpOrderNo As System.Windows.Forms.ComboBox
    Friend WithEvents drpRawFileNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtRawOrderNo As System.Windows.Forms.ComboBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
