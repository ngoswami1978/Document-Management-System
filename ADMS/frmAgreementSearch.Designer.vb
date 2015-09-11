<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgreementSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgreementSearch))
        Me.grdAgreement = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBCID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.drpSlabType = New System.Windows.Forms.ComboBox
        Me.txtChainCode = New System.Windows.Forms.TextBox
        Me.drpSignUPAdjustable = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.drpPaymentMode = New System.Windows.Forms.ComboBox
        Me.lblUpfrontType = New System.Windows.Forms.Label
        Me.drpUpfrontType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.drpPLBApplicable = New System.Windows.Forms.ComboBox
        Me.lblPLBType = New System.Windows.Forms.Label
        Me.drpPLBType = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.drpDocumentType = New System.Windows.Forms.ComboBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnExport = New System.Windows.Forms.Button
        Me.drpPeriod = New System.Windows.Forms.ComboBox
        Me.btnViewDoc = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btmClose = New System.Windows.Forms.Button
        Me.txtGROUPNAME = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.grdAgreement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdAgreement
        '
        Me.grdAgreement.AllowColMove = False
        Me.grdAgreement.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdAgreement.AllowUpdate = False
        Me.grdAgreement.AlternatingRows = True
        Me.grdAgreement.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdAgreement.CaptionHeight = 18
        Me.grdAgreement.ColumnFooters = True
        Me.grdAgreement.DefColWidth = 93
        Me.grdAgreement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAgreement.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdAgreement.Images.Add(CType(resources.GetObject("grdAgreement.Images"), System.Drawing.Image))
        Me.grdAgreement.Location = New System.Drawing.Point(0, 0)
        Me.grdAgreement.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.grdAgreement.Name = "grdAgreement"
        Me.grdAgreement.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAgreement.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAgreement.PreviewInfo.ZoomFactor = 75
        Me.grdAgreement.PrintInfo.PageSettings = CType(resources.GetObject("grdAgreement.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAgreement.RecordSelectors = False
        Me.grdAgreement.RecordSelectorWidth = 17
        Me.grdAgreement.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.grdAgreement.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.grdAgreement.RowHeight = 15
        Me.grdAgreement.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdAgreement.Size = New System.Drawing.Size(989, 548)
        Me.grdAgreement.TabIndex = 36
        Me.grdAgreement.PropBag = resources.GetString("grdAgreement.PropBag")
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.grdAgreement)
        Me.Panel2.Location = New System.Drawing.Point(8, 161)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(991, 550)
        Me.Panel2.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BC ID"
        '
        'txtBCID
        '
        Me.txtBCID.BackColor = System.Drawing.SystemColors.Window
        Me.txtBCID.Location = New System.Drawing.Point(97, 4)
        Me.txtBCID.MaxLength = 40
        Me.txtBCID.Name = "txtBCID"
        Me.txtBCID.Size = New System.Drawing.Size(195, 20)
        Me.txtBCID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(332, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Chain Code"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(-1, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Signup Adjustable"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(332, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Slab Type"
        '
        'drpSlabType
        '
        Me.drpSlabType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpSlabType.FormattingEnabled = True
        Me.drpSlabType.Location = New System.Drawing.Point(412, 48)
        Me.drpSlabType.Name = "drpSlabType"
        Me.drpSlabType.Size = New System.Drawing.Size(197, 21)
        Me.drpSlabType.TabIndex = 5
        '
        'txtChainCode
        '
        Me.txtChainCode.Location = New System.Drawing.Point(411, 4)
        Me.txtChainCode.MaxLength = 6
        Me.txtChainCode.Name = "txtChainCode"
        Me.txtChainCode.Size = New System.Drawing.Size(198, 20)
        Me.txtChainCode.TabIndex = 2
        '
        'drpSignUPAdjustable
        '
        Me.drpSignUPAdjustable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpSignUPAdjustable.FormattingEnabled = True
        Me.drpSignUPAdjustable.Location = New System.Drawing.Point(97, 48)
        Me.drpSignUPAdjustable.Name = "drpSignUPAdjustable"
        Me.drpSignUPAdjustable.Size = New System.Drawing.Size(195, 21)
        Me.drpSignUPAdjustable.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Payment Mode"
        '
        'drpPaymentMode
        '
        Me.drpPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpPaymentMode.FormattingEnabled = True
        Me.drpPaymentMode.Location = New System.Drawing.Point(97, 72)
        Me.drpPaymentMode.Name = "drpPaymentMode"
        Me.drpPaymentMode.Size = New System.Drawing.Size(195, 21)
        Me.drpPaymentMode.TabIndex = 6
        '
        'lblUpfrontType
        '
        Me.lblUpfrontType.AutoSize = True
        Me.lblUpfrontType.Location = New System.Drawing.Point(332, 79)
        Me.lblUpfrontType.Name = "lblUpfrontType"
        Me.lblUpfrontType.Size = New System.Drawing.Size(69, 13)
        Me.lblUpfrontType.TabIndex = 57
        Me.lblUpfrontType.Text = "Upfront Type"
        '
        'drpUpfrontType
        '
        Me.drpUpfrontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpUpfrontType.FormattingEnabled = True
        Me.drpUpfrontType.Location = New System.Drawing.Point(412, 72)
        Me.drpUpfrontType.Name = "drpUpfrontType"
        Me.drpUpfrontType.Size = New System.Drawing.Size(197, 21)
        Me.drpUpfrontType.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "PLB Applicable"
        '
        'drpPLBApplicable
        '
        Me.drpPLBApplicable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpPLBApplicable.FormattingEnabled = True
        Me.drpPLBApplicable.Location = New System.Drawing.Point(97, 96)
        Me.drpPLBApplicable.Name = "drpPLBApplicable"
        Me.drpPLBApplicable.Size = New System.Drawing.Size(195, 21)
        Me.drpPLBApplicable.TabIndex = 8
        '
        'lblPLBType
        '
        Me.lblPLBType.AutoSize = True
        Me.lblPLBType.Location = New System.Drawing.Point(333, 104)
        Me.lblPLBType.Name = "lblPLBType"
        Me.lblPLBType.Size = New System.Drawing.Size(54, 13)
        Me.lblPLBType.TabIndex = 61
        Me.lblPLBType.Text = "PLB Type"
        '
        'drpPLBType
        '
        Me.drpPLBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpPLBType.FormattingEnabled = True
        Me.drpPLBType.Location = New System.Drawing.Point(413, 96)
        Me.drpPLBType.Name = "drpPLBType"
        Me.drpPLBType.Size = New System.Drawing.Size(195, 21)
        Me.drpPLBType.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Document Type"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(910, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(76, 23)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'drpDocumentType
        '
        Me.drpDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpDocumentType.FormattingEnabled = True
        Me.drpDocumentType.Location = New System.Drawing.Point(97, 120)
        Me.drpDocumentType.Name = "drpDocumentType"
        Me.drpDocumentType.Size = New System.Drawing.Size(195, 21)
        Me.drpDocumentType.TabIndex = 10
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(910, 51)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(76, 23)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "Clea&r"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(333, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Period"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(910, 99)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(76, 23)
        Me.btnExport.TabIndex = 16
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        Me.btnExport.Visible = False
        '
        'drpPeriod
        '
        Me.drpPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpPeriod.FormattingEnabled = True
        Me.drpPeriod.Location = New System.Drawing.Point(413, 120)
        Me.drpPeriod.Name = "drpPeriod"
        Me.drpPeriod.Size = New System.Drawing.Size(195, 21)
        Me.drpPeriod.TabIndex = 11
        '
        'btnViewDoc
        '
        Me.btnViewDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewDoc.Location = New System.Drawing.Point(910, 27)
        Me.btnViewDoc.Name = "btnViewDoc"
        Me.btnViewDoc.Size = New System.Drawing.Size(76, 23)
        Me.btnViewDoc.TabIndex = 13
        Me.btnViewDoc.Text = "&View Doc"
        Me.btnViewDoc.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btmClose)
        Me.Panel1.Controls.Add(Me.txtGROUPNAME)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btnViewDoc)
        Me.Panel1.Controls.Add(Me.drpPeriod)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.drpPLBType)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.drpDocumentType)
        Me.Panel1.Controls.Add(Me.lblPLBType)
        Me.Panel1.Controls.Add(Me.txtBCID)
        Me.Panel1.Controls.Add(Me.drpUpfrontType)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblUpfrontType)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtChainCode)
        Me.Panel1.Controls.Add(Me.drpSignUPAdjustable)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.drpSlabType)
        Me.Panel1.Controls.Add(Me.drpPLBApplicable)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.drpPaymentMode)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(8, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 149)
        Me.Panel1.TabIndex = 35
        '
        'btmClose
        '
        Me.btmClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btmClose.Location = New System.Drawing.Point(910, 75)
        Me.btmClose.Name = "btmClose"
        Me.btmClose.Size = New System.Drawing.Size(76, 23)
        Me.btmClose.TabIndex = 15
        Me.btmClose.Text = "C&lose"
        Me.btmClose.UseVisualStyleBackColor = True
        '
        'txtGROUPNAME
        '
        Me.txtGROUPNAME.BackColor = System.Drawing.SystemColors.Window
        Me.txtGROUPNAME.Location = New System.Drawing.Point(97, 26)
        Me.txtGROUPNAME.MaxLength = 40
        Me.txtGROUPNAME.Name = "txtGROUPNAME"
        Me.txtGROUPNAME.Size = New System.Drawing.Size(512, 20)
        Me.txtGROUPNAME.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Chain Name"
        '
        'frmAgreementSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 723)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAgreementSearch"
        Me.Text = "Agreement Search"
        CType(Me.grdAgreement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdAgreement As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBCID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents drpSlabType As System.Windows.Forms.ComboBox
    Friend WithEvents txtChainCode As System.Windows.Forms.TextBox
    Friend WithEvents drpSignUPAdjustable As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents drpPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblUpfrontType As System.Windows.Forms.Label
    Friend WithEvents drpUpfrontType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents drpPLBApplicable As System.Windows.Forms.ComboBox
    Friend WithEvents lblPLBType As System.Windows.Forms.Label
    Friend WithEvents drpPLBType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents drpDocumentType As System.Windows.Forms.ComboBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents drpPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents btnViewDoc As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtGROUPNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btmClose As System.Windows.Forms.Button
End Class
