<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgencySearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgencySearch))
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.chkDate = New System.Windows.Forms.CheckBox
        Me.pnlDate = New System.Windows.Forms.Panel
        Me.btnValidFrom = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.btnValidTo = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtOrderNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.imgFileScan = New AxScanLibCtl.AxImgScan
        Me.Label16 = New System.Windows.Forms.Label
        Me.drpAgencyStatus = New System.Windows.Forms.ComboBox
        Me.txtFileNumber = New System.Windows.Forms.TextBox
        Me.txtIATAID = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.drpOnlineStatus = New System.Windows.Forms.ComboBox
        Me.drpAoffice = New System.Windows.Forms.ComboBox
        Me.drpCountry = New System.Windows.Forms.ComboBox
        Me.drpCity = New System.Windows.Forms.ComboBox
        Me.txtOfficeId = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtShortName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAgencyName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDateOnline = New System.Windows.Forms.MaskedTextBox
        Me.txtDateOffline = New System.Windows.Forms.MaskedTextBox
        Me.btnDateOffline = New System.Windows.Forms.Button
        Me.btnDateOnline = New System.Windows.Forms.Button
        Me.drpAgencyType = New System.Windows.Forms.ComboBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.drpCRS = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.grpResult = New System.Windows.Forms.GroupBox
        Me.grdScanDateAgency = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdAgency = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnModify = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnExport = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.btnUpload = New System.Windows.Forms.Button
        Me.txtPdf = New System.Windows.Forms.TextBox
        Me.btnOrderDetail = New System.Windows.Forms.Button
        Me.btnScanMisc = New System.Windows.Forms.Button
        Me.btnViewMisc = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.grpSearch.SuspendLayout()
        Me.pnlDate.SuspendLayout()
        CType(Me.imgFileScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpResult.SuspendLayout()
        CType(Me.grdScanDateAgency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAgency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.chkDate)
        Me.grpSearch.Controls.Add(Me.pnlDate)
        Me.grpSearch.Controls.Add(Me.txtOrderNo)
        Me.grpSearch.Controls.Add(Me.Label8)
        Me.grpSearch.Controls.Add(Me.txtAddress)
        Me.grpSearch.Controls.Add(Me.imgFileScan)
        Me.grpSearch.Controls.Add(Me.Label16)
        Me.grpSearch.Controls.Add(Me.drpAgencyStatus)
        Me.grpSearch.Controls.Add(Me.txtFileNumber)
        Me.grpSearch.Controls.Add(Me.txtIATAID)
        Me.grpSearch.Controls.Add(Me.Label17)
        Me.grpSearch.Controls.Add(Me.Label9)
        Me.grpSearch.Controls.Add(Me.Label15)
        Me.grpSearch.Controls.Add(Me.drpOnlineStatus)
        Me.grpSearch.Controls.Add(Me.drpAoffice)
        Me.grpSearch.Controls.Add(Me.drpCountry)
        Me.grpSearch.Controls.Add(Me.drpCity)
        Me.grpSearch.Controls.Add(Me.txtOfficeId)
        Me.grpSearch.Controls.Add(Me.Label7)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Controls.Add(Me.Label4)
        Me.grpSearch.Controls.Add(Me.txtShortName)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.Label2)
        Me.grpSearch.Controls.Add(Me.txtAgencyName)
        Me.grpSearch.Controls.Add(Me.Label1)
        Me.grpSearch.Location = New System.Drawing.Point(3, 6)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(644, 206)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Search Criteria"
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.ForeColor = System.Drawing.SystemColors.Highlight
        Me.chkDate.Location = New System.Drawing.Point(10, 154)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(181, 17)
        Me.chkDate.TabIndex = 49
        Me.chkDate.Text = "Search Scan Document By Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'pnlDate
        '
        Me.pnlDate.Controls.Add(Me.btnValidFrom)
        Me.pnlDate.Controls.Add(Me.Label10)
        Me.pnlDate.Controls.Add(Me.txtFrom)
        Me.pnlDate.Controls.Add(Me.txtTo)
        Me.pnlDate.Controls.Add(Me.btnValidTo)
        Me.pnlDate.Controls.Add(Me.Label11)
        Me.pnlDate.Location = New System.Drawing.Point(3, 171)
        Me.pnlDate.Name = "pnlDate"
        Me.pnlDate.Size = New System.Drawing.Size(635, 27)
        Me.pnlDate.TabIndex = 49
        '
        'btnValidFrom
        '
        Me.btnValidFrom.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnValidFrom.Location = New System.Drawing.Point(289, 7)
        Me.btnValidFrom.Name = "btnValidFrom"
        Me.btnValidFrom.Size = New System.Drawing.Size(25, 16)
        Me.btnValidFrom.TabIndex = 44
        Me.btnValidFrom.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(358, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Date To"
        '
        'txtFrom
        '
        Me.txtFrom.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtFrom.Location = New System.Drawing.Point(88, 4)
        Me.txtFrom.MaxLength = 10
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(201, 20)
        Me.txtFrom.TabIndex = 43
        '
        'txtTo
        '
        Me.txtTo.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtTo.Location = New System.Drawing.Point(433, 3)
        Me.txtTo.MaxLength = 10
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(173, 20)
        Me.txtTo.TabIndex = 45
        '
        'btnValidTo
        '
        Me.btnValidTo.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnValidTo.Location = New System.Drawing.Point(606, 6)
        Me.btnValidTo.Name = "btnValidTo"
        Me.btnValidTo.Size = New System.Drawing.Size(25, 16)
        Me.btnValidTo.TabIndex = 46
        Me.btnValidTo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Date From "
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(436, 132)
        Me.txtOrderNo.MaxLength = 11
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(195, 20)
        Me.txtOrderNo.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(354, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Order Number"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(91, 109)
        Me.txtAddress.MaxLength = 45
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(541, 20)
        Me.txtAddress.TabIndex = 9
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
        Me.Label16.Location = New System.Drawing.Point(9, 113)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Address"
        '
        'drpAgencyStatus
        '
        Me.drpAgencyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpAgencyStatus.FormattingEnabled = True
        Me.drpAgencyStatus.Location = New System.Drawing.Point(436, 84)
        Me.drpAgencyStatus.Name = "drpAgencyStatus"
        Me.drpAgencyStatus.Size = New System.Drawing.Size(195, 21)
        Me.drpAgencyStatus.TabIndex = 8
        '
        'txtFileNumber
        '
        Me.txtFileNumber.Location = New System.Drawing.Point(252, 133)
        Me.txtFileNumber.MaxLength = 6
        Me.txtFileNumber.Name = "txtFileNumber"
        Me.txtFileNumber.Size = New System.Drawing.Size(63, 20)
        Me.txtFileNumber.TabIndex = 11
        '
        'txtIATAID
        '
        Me.txtIATAID.Location = New System.Drawing.Point(91, 133)
        Me.txtIATAID.MaxLength = 20
        Me.txtIATAID.Name = "txtIATAID"
        Me.txtIATAID.Size = New System.Drawing.Size(113, 20)
        Me.txtIATAID.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 137)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "IATA ID"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(210, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "File No"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(354, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Agency Status"
        '
        'drpOnlineStatus
        '
        Me.drpOnlineStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpOnlineStatus.FormattingEnabled = True
        Me.drpOnlineStatus.Location = New System.Drawing.Point(91, 59)
        Me.drpOnlineStatus.Name = "drpOnlineStatus"
        Me.drpOnlineStatus.Size = New System.Drawing.Size(224, 21)
        Me.drpOnlineStatus.TabIndex = 5
        '
        'drpAoffice
        '
        Me.drpAoffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpAoffice.FormattingEnabled = True
        Me.drpAoffice.Location = New System.Drawing.Point(436, 60)
        Me.drpAoffice.Name = "drpAoffice"
        Me.drpAoffice.Size = New System.Drawing.Size(196, 21)
        Me.drpAoffice.TabIndex = 6
        '
        'drpCountry
        '
        Me.drpCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpCountry.FormattingEnabled = True
        Me.drpCountry.Location = New System.Drawing.Point(436, 35)
        Me.drpCountry.Name = "drpCountry"
        Me.drpCountry.Size = New System.Drawing.Size(196, 21)
        Me.drpCountry.TabIndex = 4
        '
        'drpCity
        '
        Me.drpCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpCity.FormattingEnabled = True
        Me.drpCity.Location = New System.Drawing.Point(436, 10)
        Me.drpCity.Name = "drpCity"
        Me.drpCity.Size = New System.Drawing.Size(196, 21)
        Me.drpCity.TabIndex = 2
        '
        'txtOfficeId
        '
        Me.txtOfficeId.Location = New System.Drawing.Point(91, 85)
        Me.txtOfficeId.MaxLength = 10
        Me.txtOfficeId.Name = "txtOfficeId"
        Me.txtOfficeId.Size = New System.Drawing.Size(224, 20)
        Me.txtOfficeId.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Office ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(354, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Aoffice"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Online Status "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(354, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Country"
        '
        'txtShortName
        '
        Me.txtShortName.Location = New System.Drawing.Point(91, 36)
        Me.txtShortName.MaxLength = 20
        Me.txtShortName.Name = "txtShortName"
        Me.txtShortName.Size = New System.Drawing.Size(224, 20)
        Me.txtShortName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Short Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(354, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "City"
        '
        'txtAgencyName
        '
        Me.txtAgencyName.BackColor = System.Drawing.SystemColors.Window
        Me.txtAgencyName.Location = New System.Drawing.Point(91, 12)
        Me.txtAgencyName.MaxLength = 40
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.Size = New System.Drawing.Size(224, 20)
        Me.txtAgencyName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agency Name"
        '
        'txtDateOnline
        '
        Me.txtDateOnline.Location = New System.Drawing.Point(880, 195)
        Me.txtDateOnline.Mask = "00/00/0000"
        Me.txtDateOnline.Name = "txtDateOnline"
        Me.txtDateOnline.Size = New System.Drawing.Size(11, 20)
        Me.txtDateOnline.TabIndex = 55
        Me.txtDateOnline.ValidatingType = GetType(Date)
        Me.txtDateOnline.Visible = False
        '
        'txtDateOffline
        '
        Me.txtDateOffline.Location = New System.Drawing.Point(873, 190)
        Me.txtDateOffline.Mask = "00/00/0000"
        Me.txtDateOffline.Name = "txtDateOffline"
        Me.txtDateOffline.Size = New System.Drawing.Size(26, 20)
        Me.txtDateOffline.TabIndex = 54
        Me.txtDateOffline.ValidatingType = GetType(Date)
        Me.txtDateOffline.Visible = False
        '
        'btnDateOffline
        '
        Me.btnDateOffline.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnDateOffline.Location = New System.Drawing.Point(873, 193)
        Me.btnDateOffline.Name = "btnDateOffline"
        Me.btnDateOffline.Size = New System.Drawing.Size(24, 16)
        Me.btnDateOffline.TabIndex = 51
        Me.btnDateOffline.UseVisualStyleBackColor = True
        Me.btnDateOffline.Visible = False
        '
        'btnDateOnline
        '
        Me.btnDateOnline.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnDateOnline.Location = New System.Drawing.Point(867, 199)
        Me.btnDateOnline.Name = "btnDateOnline"
        Me.btnDateOnline.Size = New System.Drawing.Size(24, 16)
        Me.btnDateOnline.TabIndex = 50
        Me.btnDateOnline.UseVisualStyleBackColor = True
        Me.btnDateOnline.Visible = False
        '
        'drpAgencyType
        '
        Me.drpAgencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpAgencyType.FormattingEnabled = True
        Me.drpAgencyType.Location = New System.Drawing.Point(874, 189)
        Me.drpAgencyType.Name = "drpAgencyType"
        Me.drpAgencyType.Size = New System.Drawing.Size(17, 21)
        Me.drpAgencyType.TabIndex = 10
        Me.drpAgencyType.Visible = False
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(873, 192)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(10, 20)
        Me.txtEmail.TabIndex = 13
        Me.txtEmail.Visible = False
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(874, 193)
        Me.txtFax.MaxLength = 30
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(10, 20)
        Me.txtFax.TabIndex = 14
        Me.txtFax.Visible = False
        '
        'drpCRS
        '
        Me.drpCRS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpCRS.FormattingEnabled = True
        Me.drpCRS.Location = New System.Drawing.Point(873, 192)
        Me.drpCRS.Name = "drpCRS"
        Me.drpCRS.Size = New System.Drawing.Size(11, 21)
        Me.drpCRS.TabIndex = 8
        Me.drpCRS.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Location = New System.Drawing.Point(29, 545)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 27
        '
        'grpResult
        '
        Me.grpResult.Controls.Add(Me.grdScanDateAgency)
        Me.grpResult.Controls.Add(Me.grdAgency)
        Me.grpResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpResult.Location = New System.Drawing.Point(0, 0)
        Me.grpResult.Name = "grpResult"
        Me.grpResult.Size = New System.Drawing.Size(910, 494)
        Me.grpResult.TabIndex = 28
        Me.grpResult.TabStop = False
        '
        'grdScanDateAgency
        '
        Me.grdScanDateAgency.AllowColMove = False
        Me.grdScanDateAgency.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdScanDateAgency.AllowUpdate = False
        Me.grdScanDateAgency.AlternatingRows = True
        Me.grdScanDateAgency.CaptionHeight = 18
        Me.grdScanDateAgency.DefColWidth = 93
        Me.grdScanDateAgency.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdScanDateAgency.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdScanDateAgency.Images.Add(CType(resources.GetObject("grdScanDateAgency.Images"), System.Drawing.Image))
        Me.grdScanDateAgency.Location = New System.Drawing.Point(3, 16)
        Me.grdScanDateAgency.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.grdScanDateAgency.Name = "grdScanDateAgency"
        Me.grdScanDateAgency.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdScanDateAgency.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdScanDateAgency.PreviewInfo.ZoomFactor = 75
        Me.grdScanDateAgency.PrintInfo.PageSettings = CType(resources.GetObject("grdScanDateAgency.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdScanDateAgency.RecordSelectors = False
        Me.grdScanDateAgency.RecordSelectorWidth = 17
        Me.grdScanDateAgency.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.grdScanDateAgency.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.grdScanDateAgency.RowHeight = 15
        Me.grdScanDateAgency.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdScanDateAgency.Size = New System.Drawing.Size(904, 475)
        Me.grdScanDateAgency.TabIndex = 19
        Me.grdScanDateAgency.PropBag = resources.GetString("grdScanDateAgency.PropBag")
        '
        'grdAgency
        '
        Me.grdAgency.AllowColMove = False
        Me.grdAgency.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdAgency.AllowUpdate = False
        Me.grdAgency.AlternatingRows = True
        Me.grdAgency.CaptionHeight = 18
        Me.grdAgency.DefColWidth = 93
        Me.grdAgency.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAgency.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdAgency.Images.Add(CType(resources.GetObject("grdAgency.Images"), System.Drawing.Image))
        Me.grdAgency.Location = New System.Drawing.Point(3, 16)
        Me.grdAgency.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.grdAgency.Name = "grdAgency"
        Me.grdAgency.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAgency.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAgency.PreviewInfo.ZoomFactor = 75
        Me.grdAgency.PrintInfo.PageSettings = CType(resources.GetObject("grdAgency.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAgency.RecordSelectors = False
        Me.grdAgency.RecordSelectorWidth = 17
        Me.grdAgency.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.grdAgency.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.grdAgency.RowHeight = 15
        Me.grdAgency.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdAgency.Size = New System.Drawing.Size(904, 475)
        Me.grdAgency.TabIndex = 18
        Me.grdAgency.PropBag = resources.GetString("grdAgency.PropBag")
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(831, 164)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 20
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(830, 141)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(76, 23)
        Me.btnClear.TabIndex = 19
        Me.btnClear.Text = "Clea&r"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModify.Location = New System.Drawing.Point(831, 26)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(76, 23)
        Me.btnModify.TabIndex = 14
        Me.btnModify.Text = "&Detail"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(831, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(76, 23)
        Me.btnSearch.TabIndex = 13
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnOrderDetail)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.btnDateOnline)
        Me.Panel1.Controls.Add(Me.btnScanMisc)
        Me.Panel1.Controls.Add(Me.btnViewMisc)
        Me.Panel1.Controls.Add(Me.grpSearch)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.drpAgencyType)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.btnModify)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.drpCRS)
        Me.Panel1.Controls.Add(Me.txtFax)
        Me.Panel1.Controls.Add(Me.btnDateOffline)
        Me.Panel1.Controls.Add(Me.txtDateOnline)
        Me.Panel1.Controls.Add(Me.txtDateOffline)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(910, 256)
        Me.Panel1.TabIndex = 32
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(830, 118)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(76, 23)
        Me.btnExport.TabIndex = 18
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Controls.Add(Me.txtPdf)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GroupBox1.Location = New System.Drawing.Point(3, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 40)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Upload File"
        '
        'btnBrowse
        '
        Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBrowse.Location = New System.Drawing.Point(496, 13)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(67, 23)
        Me.btnBrowse.TabIndex = 19
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUpload.Location = New System.Drawing.Point(566, 13)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(71, 23)
        Me.btnUpload.TabIndex = 20
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'txtPdf
        '
        Me.txtPdf.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPdf.Location = New System.Drawing.Point(6, 14)
        Me.txtPdf.Name = "txtPdf"
        Me.txtPdf.ReadOnly = True
        Me.txtPdf.Size = New System.Drawing.Size(487, 20)
        Me.txtPdf.TabIndex = 18
        '
        'btnOrderDetail
        '
        Me.btnOrderDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrderDetail.Location = New System.Drawing.Point(831, 95)
        Me.btnOrderDetail.Name = "btnOrderDetail"
        Me.btnOrderDetail.Size = New System.Drawing.Size(76, 23)
        Me.btnOrderDetail.TabIndex = 17
        Me.btnOrderDetail.Text = "&Order Detail"
        Me.btnOrderDetail.UseVisualStyleBackColor = True
        '
        'btnScanMisc
        '
        Me.btnScanMisc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScanMisc.Location = New System.Drawing.Point(831, 72)
        Me.btnScanMisc.Name = "btnScanMisc"
        Me.btnScanMisc.Size = New System.Drawing.Size(76, 23)
        Me.btnScanMisc.TabIndex = 16
        Me.btnScanMisc.Text = "Sc&an Misc."
        Me.btnScanMisc.UseVisualStyleBackColor = True
        '
        'btnViewMisc
        '
        Me.btnViewMisc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewMisc.Location = New System.Drawing.Point(831, 49)
        Me.btnViewMisc.Name = "btnViewMisc"
        Me.btnViewMisc.Size = New System.Drawing.Size(76, 23)
        Me.btnViewMisc.TabIndex = 15
        Me.btnViewMisc.Text = "&View Misc. "
        Me.btnViewMisc.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grpResult)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 256)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(910, 494)
        Me.Panel2.TabIndex = 33
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmAgencySearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 750)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(739, 612)
        Me.Name = "frmAgencySearch"
        Me.Text = "Agency Search"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.pnlDate.ResumeLayout(False)
        Me.pnlDate.PerformLayout()
        CType(Me.imgFileScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpResult.ResumeLayout(False)
        CType(Me.grdScanDateAgency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAgency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtShortName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAgencyName As System.Windows.Forms.TextBox
    Friend WithEvents drpOnlineStatus As System.Windows.Forms.ComboBox
    Friend WithEvents drpCRS As System.Windows.Forms.ComboBox
    Friend WithEvents drpAoffice As System.Windows.Forms.ComboBox
    Friend WithEvents drpCountry As System.Windows.Forms.ComboBox
    Friend WithEvents drpCity As System.Windows.Forms.ComboBox
    Friend WithEvents txtOfficeId As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents grpResult As System.Windows.Forms.GroupBox
    Friend WithEvents grdAgency As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents drpAgencyStatus As System.Windows.Forms.ComboBox
    Friend WithEvents drpAgencyType As System.Windows.Forms.ComboBox
    Friend WithEvents txtFileNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtIATAID As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnDateOffline As System.Windows.Forms.Button
    Friend WithEvents btnDateOnline As System.Windows.Forms.Button
    Friend WithEvents txtDateOffline As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateOnline As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnScanMisc As System.Windows.Forms.Button
    Friend WithEvents btnViewMisc As System.Windows.Forms.Button
    Friend WithEvents btnOrderDetail As System.Windows.Forms.Button
    Friend WithEvents imgFileScan As AxScanLibCtl.AxImgScan
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPdf As System.Windows.Forms.TextBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnValidTo As System.Windows.Forms.Button
    Friend WithEvents btnValidFrom As System.Windows.Forms.Button
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlDate As System.Windows.Forms.Panel
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents grdScanDateAgency As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
