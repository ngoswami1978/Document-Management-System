<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusinessCaseSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBusinessCaseSearch))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnViewAll = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnViewDoc = New System.Windows.Forms.Button
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.btnDateOnline = New System.Windows.Forms.Button
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.txtValidTo = New System.Windows.Forms.TextBox
        Me.txtValidFrom = New System.Windows.Forms.TextBox
        Me.drpPLBType = New System.Windows.Forms.ComboBox
        Me.lblPLBType = New System.Windows.Forms.Label
        Me.drpPLBApplicable = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.drpPaymentType = New System.Windows.Forms.ComboBox
        Me.lblPaymentType = New System.Windows.Forms.Label
        Me.drpDealType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.drpSignUPAdjustable = New System.Windows.Forms.ComboBox
        Me.btnValidTo = New System.Windows.Forms.Button
        Me.btnValidFrom = New System.Windows.Forms.Button
        Me.txtChainCode = New System.Windows.Forms.TextBox
        Me.txtGroupName = New System.Windows.Forms.TextBox
        Me.imgFileScan = New AxScanLibCtl.AxImgScan
        Me.Label16 = New System.Windows.Forms.Label
        Me.drpSlabType = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBCID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.drpAgencyType = New System.Windows.Forms.ComboBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnScanDocument = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.drpCRS = New System.Windows.Forms.ComboBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.btnDateOffline = New System.Windows.Forms.Button
        Me.txtDateOnline = New System.Windows.Forms.MaskedTextBox
        Me.txtDateOffline = New System.Windows.Forms.MaskedTextBox
        Me.grdBusineecase = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Panel1.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        CType(Me.imgFileScan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBusineecase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnViewAll)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnViewDoc)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.btnDateOnline)
        Me.Panel1.Controls.Add(Me.grpSearch)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.drpAgencyType)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.btnScanDocument)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.drpCRS)
        Me.Panel1.Controls.Add(Me.txtFax)
        Me.Panel1.Controls.Add(Me.btnDateOffline)
        Me.Panel1.Controls.Add(Me.txtDateOnline)
        Me.Panel1.Controls.Add(Me.txtDateOffline)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(731, 182)
        Me.Panel1.TabIndex = 33
        '
        'btnViewAll
        '
        Me.btnViewAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewAll.Location = New System.Drawing.Point(653, 72)
        Me.btnViewAll.Name = "btnViewAll"
        Me.btnViewAll.Size = New System.Drawing.Size(76, 23)
        Me.btnViewAll.TabIndex = 17
        Me.btnViewAll.Text = "&View All"
        Me.btnViewAll.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(653, 95)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(76, 23)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnViewDoc
        '
        Me.btnViewDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewDoc.Location = New System.Drawing.Point(653, 49)
        Me.btnViewDoc.Name = "btnViewDoc"
        Me.btnViewDoc.Size = New System.Drawing.Size(76, 23)
        Me.btnViewDoc.TabIndex = 16
        Me.btnViewDoc.Text = "&View Doc"
        Me.btnViewDoc.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(683, 173)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(10, 20)
        Me.txtEmail.TabIndex = 13
        Me.txtEmail.Visible = False
        '
        'btnDateOnline
        '
        Me.btnDateOnline.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnDateOnline.Location = New System.Drawing.Point(683, 177)
        Me.btnDateOnline.Name = "btnDateOnline"
        Me.btnDateOnline.Size = New System.Drawing.Size(24, 16)
        Me.btnDateOnline.TabIndex = 50
        Me.btnDateOnline.UseVisualStyleBackColor = True
        Me.btnDateOnline.Visible = False
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtValidTo)
        Me.grpSearch.Controls.Add(Me.txtValidFrom)
        Me.grpSearch.Controls.Add(Me.drpPLBType)
        Me.grpSearch.Controls.Add(Me.lblPLBType)
        Me.grpSearch.Controls.Add(Me.drpPLBApplicable)
        Me.grpSearch.Controls.Add(Me.Label8)
        Me.grpSearch.Controls.Add(Me.drpPaymentType)
        Me.grpSearch.Controls.Add(Me.lblPaymentType)
        Me.grpSearch.Controls.Add(Me.drpDealType)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.drpSignUPAdjustable)
        Me.grpSearch.Controls.Add(Me.btnValidTo)
        Me.grpSearch.Controls.Add(Me.btnValidFrom)
        Me.grpSearch.Controls.Add(Me.txtChainCode)
        Me.grpSearch.Controls.Add(Me.txtGroupName)
        Me.grpSearch.Controls.Add(Me.imgFileScan)
        Me.grpSearch.Controls.Add(Me.Label16)
        Me.grpSearch.Controls.Add(Me.drpSlabType)
        Me.grpSearch.Controls.Add(Me.Label15)
        Me.grpSearch.Controls.Add(Me.Label7)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Controls.Add(Me.Label2)
        Me.grpSearch.Controls.Add(Me.txtBCID)
        Me.grpSearch.Controls.Add(Me.Label1)
        Me.grpSearch.Location = New System.Drawing.Point(3, 5)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(644, 164)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Search Criteria"
        '
        'txtValidTo
        '
        Me.txtValidTo.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtValidTo.Location = New System.Drawing.Point(422, 59)
        Me.txtValidTo.MaxLength = 10
        Me.txtValidTo.Name = "txtValidTo"
        Me.txtValidTo.Size = New System.Drawing.Size(197, 20)
        Me.txtValidTo.TabIndex = 6
        '
        'txtValidFrom
        '
        Me.txtValidFrom.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtValidFrom.Location = New System.Drawing.Point(107, 59)
        Me.txtValidFrom.MaxLength = 10
        Me.txtValidFrom.Name = "txtValidFrom"
        Me.txtValidFrom.Size = New System.Drawing.Size(195, 20)
        Me.txtValidFrom.TabIndex = 4
        '
        'drpPLBType
        '
        Me.drpPLBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpPLBType.FormattingEnabled = True
        Me.drpPLBType.Location = New System.Drawing.Point(422, 133)
        Me.drpPLBType.Name = "drpPLBType"
        Me.drpPLBType.Size = New System.Drawing.Size(197, 21)
        Me.drpPLBType.TabIndex = 13
        '
        'lblPLBType
        '
        Me.lblPLBType.AutoSize = True
        Me.lblPLBType.Location = New System.Drawing.Point(348, 136)
        Me.lblPLBType.Name = "lblPLBType"
        Me.lblPLBType.Size = New System.Drawing.Size(54, 13)
        Me.lblPLBType.TabIndex = 61
        Me.lblPLBType.Text = "PLB Type"
        '
        'drpPLBApplicable
        '
        Me.drpPLBApplicable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpPLBApplicable.FormattingEnabled = True
        Me.drpPLBApplicable.Location = New System.Drawing.Point(107, 133)
        Me.drpPLBApplicable.Name = "drpPLBApplicable"
        Me.drpPLBApplicable.Size = New System.Drawing.Size(195, 21)
        Me.drpPLBApplicable.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "PLB Applicable"
        '
        'drpPaymentType
        '
        Me.drpPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpPaymentType.FormattingEnabled = True
        Me.drpPaymentType.Location = New System.Drawing.Point(422, 109)
        Me.drpPaymentType.Name = "drpPaymentType"
        Me.drpPaymentType.Size = New System.Drawing.Size(197, 21)
        Me.drpPaymentType.TabIndex = 11
        '
        'lblPaymentType
        '
        Me.lblPaymentType.AutoSize = True
        Me.lblPaymentType.Location = New System.Drawing.Point(348, 113)
        Me.lblPaymentType.Name = "lblPaymentType"
        Me.lblPaymentType.Size = New System.Drawing.Size(72, 13)
        Me.lblPaymentType.TabIndex = 57
        Me.lblPaymentType.Text = "PaymentType"
        '
        'drpDealType
        '
        Me.drpDealType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpDealType.FormattingEnabled = True
        Me.drpDealType.Location = New System.Drawing.Point(107, 108)
        Me.drpDealType.Name = "drpDealType"
        Me.drpDealType.Size = New System.Drawing.Size(195, 21)
        Me.drpDealType.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Deal Type"
        '
        'drpSignUPAdjustable
        '
        Me.drpSignUPAdjustable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpSignUPAdjustable.FormattingEnabled = True
        Me.drpSignUPAdjustable.Location = New System.Drawing.Point(107, 83)
        Me.drpSignUPAdjustable.Name = "drpSignUPAdjustable"
        Me.drpSignUPAdjustable.Size = New System.Drawing.Size(195, 21)
        Me.drpSignUPAdjustable.TabIndex = 8
        '
        'btnValidTo
        '
        Me.btnValidTo.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnValidTo.Location = New System.Drawing.Point(619, 62)
        Me.btnValidTo.Name = "btnValidTo"
        Me.btnValidTo.Size = New System.Drawing.Size(24, 16)
        Me.btnValidTo.TabIndex = 7
        Me.btnValidTo.UseVisualStyleBackColor = True
        '
        'btnValidFrom
        '
        Me.btnValidFrom.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnValidFrom.Location = New System.Drawing.Point(304, 63)
        Me.btnValidFrom.Name = "btnValidFrom"
        Me.btnValidFrom.Size = New System.Drawing.Size(24, 16)
        Me.btnValidFrom.TabIndex = 5
        Me.btnValidFrom.UseVisualStyleBackColor = True
        '
        'txtChainCode
        '
        Me.txtChainCode.Location = New System.Drawing.Point(422, 13)
        Me.txtChainCode.MaxLength = 6
        Me.txtChainCode.Name = "txtChainCode"
        Me.txtChainCode.Size = New System.Drawing.Size(197, 20)
        Me.txtChainCode.TabIndex = 2
        '
        'txtGroupName
        '
        Me.txtGroupName.Location = New System.Drawing.Point(107, 36)
        Me.txtGroupName.MaxLength = 45
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.Size = New System.Drawing.Size(512, 20)
        Me.txtGroupName.TabIndex = 3
        '
        'imgFileScan
        '
        Me.imgFileScan.Enabled = True
        Me.imgFileScan.Location = New System.Drawing.Point(675, 166)
        Me.imgFileScan.Name = "imgFileScan"
        Me.imgFileScan.OcxState = CType(resources.GetObject("imgFileScan.OcxState"), System.Windows.Forms.AxHost.State)
        Me.imgFileScan.Size = New System.Drawing.Size(30, 32)
        Me.imgFileScan.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Group Name"
        '
        'drpSlabType
        '
        Me.drpSlabType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpSlabType.FormattingEnabled = True
        Me.drpSlabType.Location = New System.Drawing.Point(422, 84)
        Me.drpSlabType.Name = "drpSlabType"
        Me.drpSlabType.Size = New System.Drawing.Size(197, 21)
        Me.drpSlabType.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(350, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Slab Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Signup Adjustable"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(350, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Valid To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = " Valid From "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(350, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Chain Code"
        '
        'txtBCID
        '
        Me.txtBCID.BackColor = System.Drawing.SystemColors.Window
        Me.txtBCID.Location = New System.Drawing.Point(107, 13)
        Me.txtBCID.MaxLength = 40
        Me.txtBCID.Name = "txtBCID"
        Me.txtBCID.Size = New System.Drawing.Size(195, 20)
        Me.txtBCID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BC ID"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(653, 141)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 20
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'drpAgencyType
        '
        Me.drpAgencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpAgencyType.FormattingEnabled = True
        Me.drpAgencyType.Location = New System.Drawing.Point(684, 170)
        Me.drpAgencyType.Name = "drpAgencyType"
        Me.drpAgencyType.Size = New System.Drawing.Size(17, 21)
        Me.drpAgencyType.TabIndex = 10
        Me.drpAgencyType.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(653, 118)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(76, 23)
        Me.btnClear.TabIndex = 19
        Me.btnClear.Text = "Clea&r"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnScanDocument
        '
        Me.btnScanDocument.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScanDocument.Location = New System.Drawing.Point(653, 26)
        Me.btnScanDocument.Name = "btnScanDocument"
        Me.btnScanDocument.Size = New System.Drawing.Size(76, 23)
        Me.btnScanDocument.TabIndex = 15
        Me.btnScanDocument.Text = "&Scan Doc"
        Me.btnScanDocument.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(653, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(76, 23)
        Me.btnSearch.TabIndex = 14
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'drpCRS
        '
        Me.drpCRS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpCRS.FormattingEnabled = True
        Me.drpCRS.Location = New System.Drawing.Point(683, 173)
        Me.drpCRS.Name = "drpCRS"
        Me.drpCRS.Size = New System.Drawing.Size(11, 21)
        Me.drpCRS.TabIndex = 8
        Me.drpCRS.Visible = False
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(684, 174)
        Me.txtFax.MaxLength = 30
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(10, 20)
        Me.txtFax.TabIndex = 14
        Me.txtFax.Visible = False
        '
        'btnDateOffline
        '
        Me.btnDateOffline.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnDateOffline.Location = New System.Drawing.Point(683, 174)
        Me.btnDateOffline.Name = "btnDateOffline"
        Me.btnDateOffline.Size = New System.Drawing.Size(24, 16)
        Me.btnDateOffline.TabIndex = 51
        Me.btnDateOffline.UseVisualStyleBackColor = True
        Me.btnDateOffline.Visible = False
        '
        'txtDateOnline
        '
        Me.txtDateOnline.Location = New System.Drawing.Point(690, 176)
        Me.txtDateOnline.Mask = "00/00/0000"
        Me.txtDateOnline.Name = "txtDateOnline"
        Me.txtDateOnline.Size = New System.Drawing.Size(11, 20)
        Me.txtDateOnline.TabIndex = 55
        Me.txtDateOnline.ValidatingType = GetType(Date)
        Me.txtDateOnline.Visible = False
        '
        'txtDateOffline
        '
        Me.txtDateOffline.Location = New System.Drawing.Point(683, 171)
        Me.txtDateOffline.Mask = "00/00/0000"
        Me.txtDateOffline.Name = "txtDateOffline"
        Me.txtDateOffline.Size = New System.Drawing.Size(26, 20)
        Me.txtDateOffline.TabIndex = 54
        Me.txtDateOffline.ValidatingType = GetType(Date)
        Me.txtDateOffline.Visible = False
        '
        'grdBusineecase
        '
        Me.grdBusineecase.AllowColMove = False
        Me.grdBusineecase.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdBusineecase.AllowUpdate = False
        Me.grdBusineecase.AlternatingRows = True
        Me.grdBusineecase.CaptionHeight = 18
        Me.grdBusineecase.ColumnFooters = True
        Me.grdBusineecase.DefColWidth = 93
        Me.grdBusineecase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBusineecase.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdBusineecase.Images.Add(CType(resources.GetObject("grdBusineecase.Images"), System.Drawing.Image))
        Me.grdBusineecase.Location = New System.Drawing.Point(0, 182)
        Me.grdBusineecase.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.grdBusineecase.Name = "grdBusineecase"
        Me.grdBusineecase.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdBusineecase.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdBusineecase.PreviewInfo.ZoomFactor = 75
        Me.grdBusineecase.PrintInfo.PageSettings = CType(resources.GetObject("grdBusineecase.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdBusineecase.RecordSelectors = False
        Me.grdBusineecase.RecordSelectorWidth = 17
        Me.grdBusineecase.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.grdBusineecase.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.grdBusineecase.RowHeight = 15
        Me.grdBusineecase.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdBusineecase.Size = New System.Drawing.Size(731, 396)
        Me.grdBusineecase.TabIndex = 34
        Me.grdBusineecase.PropBag = resources.GetString("grdBusineecase.PropBag")
        '
        'frmBusinessCaseSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 578)
        Me.Controls.Add(Me.grdBusineecase)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBusinessCaseSearch"
        Me.Text = "Businesscase Search"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        CType(Me.imgFileScan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBusineecase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents btnDateOnline As System.Windows.Forms.Button
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
	Friend WithEvents imgFileScan As AxScanLibCtl.AxImgScan
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents drpSlabType As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBCID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents drpAgencyType As System.Windows.Forms.ComboBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnScanDocument As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents drpCRS As System.Windows.Forms.ComboBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents btnDateOffline As System.Windows.Forms.Button
    Friend WithEvents txtDateOnline As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateOffline As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grdBusineecase As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtChainCode As System.Windows.Forms.TextBox
    Friend WithEvents btnValidFrom As System.Windows.Forms.Button
    Friend WithEvents drpPLBApplicable As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents drpPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPaymentType As System.Windows.Forms.Label
    Friend WithEvents drpDealType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents drpSignUPAdjustable As System.Windows.Forms.ComboBox
    Friend WithEvents btnValidTo As System.Windows.Forms.Button
    Friend WithEvents drpPLBType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPLBType As System.Windows.Forms.Label
    Friend WithEvents txtValidTo As System.Windows.Forms.TextBox
    Friend WithEvents txtValidFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnViewDoc As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnViewAll As System.Windows.Forms.Button
End Class
