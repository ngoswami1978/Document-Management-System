<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewOrder))
        Me.btnViewDoc = New System.Windows.Forms.Button
        Me.btnScan = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnUpdateFile = New System.Windows.Forms.Button
        Me.imgFileScan = New AxScanLibCtl.AxImgScan
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tdbGridOrderReceived = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.btnUpload = New System.Windows.Forms.Button
        Me.txtPdf = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtOrderFileno = New System.Windows.Forms.TextBox
        Me.txtOrderAddress = New System.Windows.Forms.TextBox
        Me.txtOrderOfficeid = New System.Windows.Forms.TextBox
        Me.txtOrderAgencyname = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.lblAgencyName = New System.Windows.Forms.Label
        Me.btnDetail = New System.Windows.Forms.Button
        CType(Me.imgFileScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.tdbGridOrderReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnViewDoc
        '
        Me.btnViewDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewDoc.Location = New System.Drawing.Point(721, 28)
        Me.btnViewDoc.Name = "btnViewDoc"
        Me.btnViewDoc.Size = New System.Drawing.Size(76, 23)
        Me.btnViewDoc.TabIndex = 69
        Me.btnViewDoc.Text = "View Doc"
        Me.btnViewDoc.UseVisualStyleBackColor = True
        '
        'btnScan
        '
        Me.btnScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScan.Location = New System.Drawing.Point(721, 5)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(76, 23)
        Me.btnScan.TabIndex = 70
        Me.btnScan.Text = "Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(721, 434)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 71
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdateFile
        '
        Me.btnUpdateFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateFile.Location = New System.Drawing.Point(721, 52)
        Me.btnUpdateFile.Name = "btnUpdateFile"
        Me.btnUpdateFile.Size = New System.Drawing.Size(76, 23)
        Me.btnUpdateFile.TabIndex = 72
        Me.btnUpdateFile.Text = "Update File"
        Me.btnUpdateFile.UseVisualStyleBackColor = True
        '
        'imgFileScan
        '
        Me.imgFileScan.Enabled = True
        Me.imgFileScan.Location = New System.Drawing.Point(650, 6)
        Me.imgFileScan.Name = "imgFileScan"
        Me.imgFileScan.OcxState = CType(resources.GetObject("imgFileScan.OcxState"), System.Windows.Forms.AxHost.State)
        Me.imgFileScan.Size = New System.Drawing.Size(32, 32)
        Me.imgFileScan.TabIndex = 73
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.tdbGridOrderReceived)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Location = New System.Drawing.Point(0, 109)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(810, 469)
        Me.Panel1.TabIndex = 74
        '
        'tdbGridOrderReceived
        '
        Me.tdbGridOrderReceived.AllowUpdate = False
        Me.tdbGridOrderReceived.AlternatingRows = True
        Me.tdbGridOrderReceived.CaptionHeight = 18
        Me.tdbGridOrderReceived.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbGridOrderReceived.Images.Add(CType(resources.GetObject("tdbGridOrderReceived.Images"), System.Drawing.Image))
        Me.tdbGridOrderReceived.Location = New System.Drawing.Point(12, 6)
        Me.tdbGridOrderReceived.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.tdbGridOrderReceived.Name = "tdbGridOrderReceived"
        Me.tdbGridOrderReceived.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbGridOrderReceived.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbGridOrderReceived.PreviewInfo.ZoomFactor = 75
        Me.tdbGridOrderReceived.PrintInfo.PageSettings = CType(resources.GetObject("tdbGridOrderReceived.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbGridOrderReceived.RecordSelectors = False
        Me.tdbGridOrderReceived.RecordSelectorWidth = 17
        Me.tdbGridOrderReceived.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbGridOrderReceived.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbGridOrderReceived.RowHeight = 15
        Me.tdbGridOrderReceived.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbGridOrderReceived.Size = New System.Drawing.Size(702, 451)
        Me.tdbGridOrderReceived.TabIndex = 61
        Me.tdbGridOrderReceived.Text = "C1TrueDBGrid2"
        Me.tdbGridOrderReceived.PropBag = resources.GetString("tdbGridOrderReceived.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Controls.Add(Me.imgFileScan)
        Me.GroupBox1.Controls.Add(Me.txtPdf)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GroupBox1.Location = New System.Drawing.Point(12, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(700, 41)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Upload File"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBrowse.Location = New System.Drawing.Point(560, 14)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(67, 23)
        Me.btnBrowse.TabIndex = 56
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnUpload.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUpload.Location = New System.Drawing.Point(628, 14)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(71, 23)
        Me.btnUpload.TabIndex = 58
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'txtPdf
        '
        Me.txtPdf.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPdf.Location = New System.Drawing.Point(8, 14)
        Me.txtPdf.Name = "txtPdf"
        Me.txtPdf.ReadOnly = True
        Me.txtPdf.Size = New System.Drawing.Size(546, 20)
        Me.txtPdf.TabIndex = 57
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtOrderFileno)
        Me.Panel2.Controls.Add(Me.txtOrderAddress)
        Me.Panel2.Controls.Add(Me.txtOrderOfficeid)
        Me.Panel2.Controls.Add(Me.txtOrderAgencyname)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.lblAgencyName)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(717, 109)
        Me.Panel2.TabIndex = 76
        '
        'txtOrderFileno
        '
        Me.txtOrderFileno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderFileno.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtOrderFileno.Location = New System.Drawing.Point(528, 27)
        Me.txtOrderFileno.Name = "txtOrderFileno"
        Me.txtOrderFileno.ReadOnly = True
        Me.txtOrderFileno.Size = New System.Drawing.Size(184, 20)
        Me.txtOrderFileno.TabIndex = 76
        '
        'txtOrderAddress
        '
        Me.txtOrderAddress.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtOrderAddress.Location = New System.Drawing.Point(93, 27)
        Me.txtOrderAddress.Multiline = True
        Me.txtOrderAddress.Name = "txtOrderAddress"
        Me.txtOrderAddress.ReadOnly = True
        Me.txtOrderAddress.Size = New System.Drawing.Size(375, 37)
        Me.txtOrderAddress.TabIndex = 75
        '
        'txtOrderOfficeid
        '
        Me.txtOrderOfficeid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderOfficeid.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtOrderOfficeid.Location = New System.Drawing.Point(528, 4)
        Me.txtOrderOfficeid.Name = "txtOrderOfficeid"
        Me.txtOrderOfficeid.ReadOnly = True
        Me.txtOrderOfficeid.Size = New System.Drawing.Size(184, 20)
        Me.txtOrderOfficeid.TabIndex = 74
        '
        'txtOrderAgencyname
        '
        Me.txtOrderAgencyname.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtOrderAgencyname.Location = New System.Drawing.Point(93, 4)
        Me.txtOrderAgencyname.Name = "txtOrderAgencyname"
        Me.txtOrderAgencyname.ReadOnly = True
        Me.txtOrderAgencyname.Size = New System.Drawing.Size(375, 20)
        Me.txtOrderAgencyname.TabIndex = 73
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(485, 29)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 13)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "FileNo"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(17, 28)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(45, 13)
        Me.Label30.TabIndex = 71
        Me.Label30.Text = "Address"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(482, 10)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 70
        Me.Label26.Text = "OfficeId"
        '
        'lblAgencyName
        '
        Me.lblAgencyName.AutoSize = True
        Me.lblAgencyName.Location = New System.Drawing.Point(17, 8)
        Me.lblAgencyName.Name = "lblAgencyName"
        Me.lblAgencyName.Size = New System.Drawing.Size(74, 13)
        Me.lblAgencyName.TabIndex = 69
        Me.lblAgencyName.Text = "Agency Name"
        '
        'btnDetail
        '
        Me.btnDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetail.Location = New System.Drawing.Point(721, 76)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(76, 23)
        Me.btnDetail.TabIndex = 77
        Me.btnDetail.Text = "Detail"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'frmViewOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 578)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnUpdateFile)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.btnViewDoc)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Order"
        CType(Me.imgFileScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tdbGridOrderReceived, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnViewDoc As System.Windows.Forms.Button
    Friend WithEvents btnScan As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUpdateFile As System.Windows.Forms.Button
    Friend WithEvents imgFileScan As AxScanLibCtl.AxImgScan
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtPdf As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtOrderFileno As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderOfficeid As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderAgencyname As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblAgencyName As System.Windows.Forms.Label
    Friend WithEvents tdbGridOrderReceived As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnDetail As System.Windows.Forms.Button
End Class
