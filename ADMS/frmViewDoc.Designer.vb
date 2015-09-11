<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewDocument))
        Me.btnViewAll = New System.Windows.Forms.Button
        Me.lblAgencyName = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.lblPageScanned = New System.Windows.Forms.Label
        Me.lblSequence = New System.Windows.Forms.Label
        Me.lblHiddenFileNo = New System.Windows.Forms.Label
        Me.lblFlag = New System.Windows.Forms.Label
        Me.lblImageID = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnFitPage = New System.Windows.Forms.Button
        Me.btnZoomIN = New System.Windows.Forms.Button
        Me.btnZoomOut = New System.Windows.Forms.Button
        Me.AxImgEdit1 = New AxImgeditLibCtl.AxImgEdit
        Me.lblFileNo = New System.Windows.Forms.Label
        Me.txtFileNo = New System.Windows.Forms.TextBox
        Me.lblAddress = New System.Windows.Forms.Label
        Me.txtSequenceNo = New System.Windows.Forms.TextBox
        Me.lblOfficeid = New System.Windows.Forms.Label
        Me.txtAgencyName = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtOrderType = New System.Windows.Forms.TextBox
        Me.lblOrderType = New System.Windows.Forms.Label
        Me.lblOrderNumber = New System.Windows.Forms.Label
        Me.txtOfficeId = New System.Windows.Forms.TextBox
        Me.txtOrderNumber = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF
        Me.AxImgScan2 = New AxScanLibCtl.AxImgScan
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.pnlWebControl = New System.Windows.Forms.Panel
        Me.AxPdf = New AxAcroPDFLib.AxAcroPDF
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.txtMailSub = New System.Windows.Forms.TextBox
        Me.txtMailTo = New System.Windows.Forms.TextBox
        Me.txtMailFrom = New System.Windows.Forms.TextBox
        Me.lblSubject = New System.Windows.Forms.Label
        Me.lblMailFrom = New System.Windows.Forms.Label
        Me.lblMailTo = New System.Windows.Forms.Label
        Me.lblContent = New System.Windows.Forms.Label
        Me.pnlNextPrev = New System.Windows.Forms.Panel
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PnlAllControls = New System.Windows.Forms.Panel
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.Panel1.SuspendLayout()
        CType(Me.AxImgEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxImgScan2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlWebControl.SuspendLayout()
        CType(Me.AxPdf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNextPrev.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnViewAll
        '
        Me.btnViewAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewAll.Location = New System.Drawing.Point(2, 3)
        Me.btnViewAll.Name = "btnViewAll"
        Me.btnViewAll.Size = New System.Drawing.Size(76, 23)
        Me.btnViewAll.TabIndex = 37
        Me.btnViewAll.Text = "View  All"
        Me.btnViewAll.UseVisualStyleBackColor = True
        '
        'lblAgencyName
        '
        Me.lblAgencyName.AutoSize = True
        Me.lblAgencyName.Location = New System.Drawing.Point(10, 13)
        Me.lblAgencyName.Name = "lblAgencyName"
        Me.lblAgencyName.Size = New System.Drawing.Size(74, 13)
        Me.lblAgencyName.TabIndex = 43
        Me.lblAgencyName.Text = "Agency Name"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(6, 103)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(46, 20)
        Me.txtFileName.TabIndex = 49
        Me.txtFileName.Visible = False
        '
        'lblPageScanned
        '
        Me.lblPageScanned.AutoSize = True
        Me.lblPageScanned.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPageScanned.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageScanned.ForeColor = System.Drawing.Color.Red
        Me.lblPageScanned.Location = New System.Drawing.Point(2, 98)
        Me.lblPageScanned.Name = "lblPageScanned"
        Me.lblPageScanned.Size = New System.Drawing.Size(46, 18)
        Me.lblPageScanned.TabIndex = 43
        Me.lblPageScanned.Text = "Page"
        Me.lblPageScanned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPageScanned.Visible = False
        '
        'lblSequence
        '
        Me.lblSequence.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSequence.AutoSize = True
        Me.lblSequence.Location = New System.Drawing.Point(375, 36)
        Me.lblSequence.Name = "lblSequence"
        Me.lblSequence.Size = New System.Drawing.Size(56, 13)
        Me.lblSequence.TabIndex = 37
        Me.lblSequence.Text = "Sequence"
        '
        'lblHiddenFileNo
        '
        Me.lblHiddenFileNo.AutoSize = True
        Me.lblHiddenFileNo.Location = New System.Drawing.Point(899, 289)
        Me.lblHiddenFileNo.Name = "lblHiddenFileNo"
        Me.lblHiddenFileNo.Size = New System.Drawing.Size(0, 13)
        Me.lblHiddenFileNo.TabIndex = 46
        Me.lblHiddenFileNo.Visible = False
        '
        'lblFlag
        '
        Me.lblFlag.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.lblFlag.AutoSize = True
        Me.lblFlag.Location = New System.Drawing.Point(902, 319)
        Me.lblFlag.Name = "lblFlag"
        Me.lblFlag.Size = New System.Drawing.Size(0, 13)
        Me.lblFlag.TabIndex = 47
        Me.lblFlag.Visible = False
        '
        'lblImageID
        '
        Me.lblImageID.AutoSize = True
        Me.lblImageID.Location = New System.Drawing.Point(899, 319)
        Me.lblImageID.Name = "lblImageID"
        Me.lblImageID.Size = New System.Drawing.Size(0, 13)
        Me.lblImageID.TabIndex = 1
        Me.lblImageID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.WebBrowser2)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.btnFitPage)
        Me.Panel1.Controls.Add(Me.btnZoomIN)
        Me.Panel1.Controls.Add(Me.btnZoomOut)
        Me.Panel1.Controls.Add(Me.btnViewAll)
        Me.Panel1.Controls.Add(Me.lblPageScanned)
        Me.Panel1.Controls.Add(Me.txtFileName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(720, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(84, 586)
        Me.Panel1.TabIndex = 52
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Location = New System.Drawing.Point(0, 166)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(79, 78)
        Me.WebBrowser2.TabIndex = 58
        Me.WebBrowser2.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(2, 118)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(76, 23)
        Me.btnDelete.TabIndex = 57
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(2, 141)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 56
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(2, 26)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(76, 23)
        Me.btnPrint.TabIndex = 55
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnFitPage
        '
        Me.btnFitPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFitPage.Location = New System.Drawing.Point(2, 95)
        Me.btnFitPage.Name = "btnFitPage"
        Me.btnFitPage.Size = New System.Drawing.Size(76, 23)
        Me.btnFitPage.TabIndex = 54
        Me.btnFitPage.Text = "Fit Page"
        Me.btnFitPage.UseVisualStyleBackColor = True
        '
        'btnZoomIN
        '
        Me.btnZoomIN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomIN.Location = New System.Drawing.Point(2, 72)
        Me.btnZoomIN.Name = "btnZoomIN"
        Me.btnZoomIN.Size = New System.Drawing.Size(76, 23)
        Me.btnZoomIN.TabIndex = 52
        Me.btnZoomIN.Text = "Zoom Out"
        Me.btnZoomIN.UseVisualStyleBackColor = True
        '
        'btnZoomOut
        '
        Me.btnZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomOut.Location = New System.Drawing.Point(2, 49)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(76, 23)
        Me.btnZoomOut.TabIndex = 53
        Me.btnZoomOut.Text = "Zoom In"
        Me.btnZoomOut.UseVisualStyleBackColor = True
        '
        'AxImgEdit1
        '
        Me.AxImgEdit1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxImgEdit1.Location = New System.Drawing.Point(0, 0)
        Me.AxImgEdit1.Name = "AxImgEdit1"
        Me.AxImgEdit1.OcxState = CType(resources.GetObject("AxImgEdit1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxImgEdit1.Size = New System.Drawing.Size(706, 436)
        Me.AxImgEdit1.TabIndex = 58
        '
        'lblFileNo
        '
        Me.lblFileNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFileNo.AutoSize = True
        Me.lblFileNo.Location = New System.Drawing.Point(375, 16)
        Me.lblFileNo.Name = "lblFileNo"
        Me.lblFileNo.Size = New System.Drawing.Size(60, 13)
        Me.lblFileNo.TabIndex = 33
        Me.lblFileNo.Text = "FileNumber"
        '
        'txtFileNo
        '
        Me.txtFileNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileNo.BackColor = System.Drawing.SystemColors.Control
        Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileNo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtFileNo.Location = New System.Drawing.Point(436, 13)
        Me.txtFileNo.Name = "txtFileNo"
        Me.txtFileNo.ReadOnly = True
        Me.txtFileNo.Size = New System.Drawing.Size(227, 20)
        Me.txtFileNo.TabIndex = 34
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(10, 35)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(45, 13)
        Me.lblAddress.TabIndex = 44
        Me.lblAddress.Text = "Address"
        '
        'txtSequenceNo
        '
        Me.txtSequenceNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSequenceNo.BackColor = System.Drawing.SystemColors.Control
        Me.txtSequenceNo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtSequenceNo.Location = New System.Drawing.Point(436, 34)
        Me.txtSequenceNo.MaxLength = 3
        Me.txtSequenceNo.Name = "txtSequenceNo"
        Me.txtSequenceNo.ReadOnly = True
        Me.txtSequenceNo.Size = New System.Drawing.Size(96, 20)
        Me.txtSequenceNo.TabIndex = 38
        '
        'lblOfficeid
        '
        Me.lblOfficeid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOfficeid.AutoSize = True
        Me.lblOfficeid.Location = New System.Drawing.Point(534, 36)
        Me.lblOfficeid.Name = "lblOfficeid"
        Me.lblOfficeid.Size = New System.Drawing.Size(49, 13)
        Me.lblOfficeid.TabIndex = 45
        Me.lblOfficeid.Text = "Office ID"
        '
        'txtAgencyName
        '
        Me.txtAgencyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAgencyName.BackColor = System.Drawing.SystemColors.Control
        Me.txtAgencyName.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtAgencyName.Location = New System.Drawing.Point(88, 11)
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.ReadOnly = True
        Me.txtAgencyName.Size = New System.Drawing.Size(270, 20)
        Me.txtAgencyName.TabIndex = 46
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress.BackColor = System.Drawing.SystemColors.Control
        Me.txtAddress.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtAddress.Location = New System.Drawing.Point(88, 35)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtAddress.Size = New System.Drawing.Size(270, 66)
        Me.txtAddress.TabIndex = 47
        '
        'txtOrderType
        '
        Me.txtOrderType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderType.BackColor = System.Drawing.SystemColors.Control
        Me.txtOrderType.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtOrderType.Location = New System.Drawing.Point(436, 79)
        Me.txtOrderType.Name = "txtOrderType"
        Me.txtOrderType.ReadOnly = True
        Me.txtOrderType.Size = New System.Drawing.Size(227, 20)
        Me.txtOrderType.TabIndex = 40
        '
        'lblOrderType
        '
        Me.lblOrderType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrderType.AutoSize = True
        Me.lblOrderType.Location = New System.Drawing.Point(375, 79)
        Me.lblOrderType.Name = "lblOrderType"
        Me.lblOrderType.Size = New System.Drawing.Size(57, 13)
        Me.lblOrderType.TabIndex = 39
        Me.lblOrderType.Text = "OrderType"
        '
        'lblOrderNumber
        '
        Me.lblOrderNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrderNumber.AutoSize = True
        Me.lblOrderNumber.Location = New System.Drawing.Point(375, 58)
        Me.lblOrderNumber.Name = "lblOrderNumber"
        Me.lblOrderNumber.Size = New System.Drawing.Size(50, 13)
        Me.lblOrderNumber.TabIndex = 35
        Me.lblOrderNumber.Text = "Order No"
        '
        'txtOfficeId
        '
        Me.txtOfficeId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOfficeId.BackColor = System.Drawing.SystemColors.Control
        Me.txtOfficeId.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtOfficeId.Location = New System.Drawing.Point(581, 35)
        Me.txtOfficeId.Name = "txtOfficeId"
        Me.txtOfficeId.ReadOnly = True
        Me.txtOfficeId.Size = New System.Drawing.Size(82, 20)
        Me.txtOfficeId.TabIndex = 48
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderNumber.BackColor = System.Drawing.SystemColors.Control
        Me.txtOrderNumber.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtOrderNumber.Location = New System.Drawing.Point(436, 56)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.ReadOnly = True
        Me.txtOrderNumber.Size = New System.Drawing.Size(227, 20)
        Me.txtOrderNumber.TabIndex = 36
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AxAcroPDF1)
        Me.GroupBox1.Controls.Add(Me.lblAgencyName)
        Me.GroupBox1.Controls.Add(Me.txtSequenceNo)
        Me.GroupBox1.Controls.Add(Me.lblSequence)
        Me.GroupBox1.Controls.Add(Me.lblOrderNumber)
        Me.GroupBox1.Controls.Add(Me.txtOfficeId)
        Me.GroupBox1.Controls.Add(Me.txtFileNo)
        Me.GroupBox1.Controls.Add(Me.lblFileNo)
        Me.GroupBox1.Controls.Add(Me.lblOrderType)
        Me.GroupBox1.Controls.Add(Me.txtAgencyName)
        Me.GroupBox1.Controls.Add(Me.txtOrderNumber)
        Me.GroupBox1.Controls.Add(Me.txtOrderType)
        Me.GroupBox1.Controls.Add(Me.lblOfficeid)
        Me.GroupBox1.Controls.Add(Me.txtAddress)
        Me.GroupBox1.Controls.Add(Me.lblAddress)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(683, 109)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(4, 124)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(706, 436)
        Me.AxAcroPDF1.TabIndex = 49
        '
        'AxImgScan2
        '
        Me.AxImgScan2.Enabled = True
        Me.AxImgScan2.Location = New System.Drawing.Point(0, 124)
        Me.AxImgScan2.Name = "AxImgScan2"
        Me.AxImgScan2.OcxState = CType(resources.GetObject("AxImgScan2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxImgScan2.Size = New System.Drawing.Size(721, 351)
        Me.AxImgScan2.TabIndex = 37
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.CaptionHeight = 17
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = Nothing
        Me.C1TrueDBGrid1.RecordSelectorWidth = 17
        Me.C1TrueDBGrid1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TrueDBGrid1.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TrueDBGrid1.RowHeight = 15
        Me.C1TrueDBGrid1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.TabIndex = 0
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(720, 586)
        Me.Panel2.TabIndex = 54
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pnlWebControl)
        Me.Panel4.Controls.Add(Me.pnlNextPrev)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 123)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(720, 463)
        Me.Panel4.TabIndex = 55
        '
        'pnlWebControl
        '
        Me.pnlWebControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlWebControl.Controls.Add(Me.AxImgEdit1)
        Me.pnlWebControl.Controls.Add(Me.AxPdf)
        Me.pnlWebControl.Controls.Add(Me.PictureBox1)
        Me.pnlWebControl.Controls.Add(Me.WebBrowser1)
        Me.pnlWebControl.Controls.Add(Me.txtMailSub)
        Me.pnlWebControl.Controls.Add(Me.txtMailTo)
        Me.pnlWebControl.Controls.Add(Me.txtMailFrom)
        Me.pnlWebControl.Controls.Add(Me.lblSubject)
        Me.pnlWebControl.Controls.Add(Me.lblMailFrom)
        Me.pnlWebControl.Controls.Add(Me.lblMailTo)
        Me.pnlWebControl.Controls.Add(Me.lblContent)
        Me.pnlWebControl.Location = New System.Drawing.Point(7, 0)
        Me.pnlWebControl.Name = "pnlWebControl"
        Me.pnlWebControl.Size = New System.Drawing.Size(706, 436)
        Me.pnlWebControl.TabIndex = 61
        '
        'AxPdf
        '
        Me.AxPdf.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxPdf.Enabled = True
        Me.AxPdf.Location = New System.Drawing.Point(-1, 0)
        Me.AxPdf.Name = "AxPdf"
        Me.AxPdf.OcxState = CType(resources.GetObject("AxPdf.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxPdf.Size = New System.Drawing.Size(704, 436)
        Me.AxPdf.TabIndex = 13
        Me.AxPdf.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(706, 436)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.WaitOnLoad = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(85, 91)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(595, 331)
        Me.WebBrowser1.TabIndex = 17
        '
        'txtMailSub
        '
        Me.txtMailSub.BackColor = System.Drawing.SystemColors.Window
        Me.txtMailSub.Location = New System.Drawing.Point(85, 64)
        Me.txtMailSub.Name = "txtMailSub"
        Me.txtMailSub.ReadOnly = True
        Me.txtMailSub.Size = New System.Drawing.Size(596, 20)
        Me.txtMailSub.TabIndex = 15
        '
        'txtMailTo
        '
        Me.txtMailTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMailTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtMailTo.Location = New System.Drawing.Point(85, 37)
        Me.txtMailTo.Name = "txtMailTo"
        Me.txtMailTo.ReadOnly = True
        Me.txtMailTo.Size = New System.Drawing.Size(596, 20)
        Me.txtMailTo.TabIndex = 10
        '
        'txtMailFrom
        '
        Me.txtMailFrom.BackColor = System.Drawing.SystemColors.Window
        Me.txtMailFrom.Location = New System.Drawing.Point(84, 11)
        Me.txtMailFrom.Name = "txtMailFrom"
        Me.txtMailFrom.ReadOnly = True
        Me.txtMailFrom.Size = New System.Drawing.Size(596, 20)
        Me.txtMailFrom.TabIndex = 14
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblSubject.Location = New System.Drawing.Point(24, 68)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(43, 13)
        Me.lblSubject.TabIndex = 13
        Me.lblSubject.Text = "Subject"
        '
        'lblMailFrom
        '
        Me.lblMailFrom.AutoSize = True
        Me.lblMailFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblMailFrom.Location = New System.Drawing.Point(23, 17)
        Me.lblMailFrom.Name = "lblMailFrom"
        Me.lblMailFrom.Size = New System.Drawing.Size(52, 13)
        Me.lblMailFrom.TabIndex = 12
        Me.lblMailFrom.Text = "Mail From"
        '
        'lblMailTo
        '
        Me.lblMailTo.AutoSize = True
        Me.lblMailTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblMailTo.Location = New System.Drawing.Point(25, 43)
        Me.lblMailTo.Name = "lblMailTo"
        Me.lblMailTo.Size = New System.Drawing.Size(42, 13)
        Me.lblMailTo.TabIndex = 11
        Me.lblMailTo.Text = "Mail To"
        '
        'lblContent
        '
        Me.lblContent.AutoSize = True
        Me.lblContent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblContent.Location = New System.Drawing.Point(24, 94)
        Me.lblContent.Name = "lblContent"
        Me.lblContent.Size = New System.Drawing.Size(44, 13)
        Me.lblContent.TabIndex = 16
        Me.lblContent.Text = "Content"
        '
        'pnlNextPrev
        '
        Me.pnlNextPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlNextPrev.Controls.Add(Me.btnPrev)
        Me.pnlNextPrev.Controls.Add(Me.btnNext)
        Me.pnlNextPrev.Location = New System.Drawing.Point(0, 428)
        Me.pnlNextPrev.Name = "pnlNextPrev"
        Me.pnlNextPrev.Size = New System.Drawing.Size(720, 35)
        Me.pnlNextPrev.TabIndex = 60
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrev.Location = New System.Drawing.Point(3, 9)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(76, 23)
        Me.btnPrev.TabIndex = 59
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(85, 9)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 23)
        Me.btnNext.TabIndex = 58
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.PnlAllControls)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(720, 123)
        Me.Panel3.TabIndex = 54
        '
        'PnlAllControls
        '
        Me.PnlAllControls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlAllControls.AutoScroll = True
        Me.PnlAllControls.Location = New System.Drawing.Point(6, 113)
        Me.PnlAllControls.Name = "PnlAllControls"
        Me.PnlAllControls.Size = New System.Drawing.Size(710, 446)
        Me.PnlAllControls.TabIndex = 57
        '
        'PrintDocument1
        '
        '
        'frmViewDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 586)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblImageID)
        Me.Controls.Add(Me.lblFlag)
        Me.Controls.Add(Me.lblHiddenFileNo)
        Me.Controls.Add(Me.AxImgScan2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmViewDocument"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Document"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.AxImgEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxImgScan2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.pnlWebControl.ResumeLayout(False)
        Me.pnlWebControl.PerformLayout()
        CType(Me.AxPdf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNextPrev.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents AxImgScan2 As AxScanLibCtl.AxImgScan
    Friend WithEvents lblHiddenFileNo As System.Windows.Forms.Label
    Friend WithEvents lblFlag As System.Windows.Forms.Label
    Friend WithEvents lblImageID As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnFitPage As System.Windows.Forms.Button
    Friend WithEvents btnZoomIN As System.Windows.Forms.Button
    Friend WithEvents btnZoomOut As System.Windows.Forms.Button
    Friend WithEvents btnViewAll As System.Windows.Forms.Button
    Friend WithEvents lblAgencyName As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblPageScanned As System.Windows.Forms.Label
    Friend WithEvents lblSequence As System.Windows.Forms.Label
    Friend WithEvents lblFileNo As System.Windows.Forms.Label
    Friend WithEvents txtFileNo As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtSequenceNo As System.Windows.Forms.TextBox
    Friend WithEvents lblOfficeid As System.Windows.Forms.Label
    Friend WithEvents txtAgencyName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderType As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderType As System.Windows.Forms.Label
    Friend WithEvents lblOrderNumber As System.Windows.Forms.Label
    Friend WithEvents txtOfficeId As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	'Friend WithEvents AxPdf As AxPdfLib.AxPdf
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
	Friend WithEvents AxPdf As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents AxImgEdit1 As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents PnlAllControls As System.Windows.Forms.Panel
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents pnlNextPrev As System.Windows.Forms.Panel
    Friend WithEvents pnlWebControl As System.Windows.Forms.Panel
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents lblMailFrom As System.Windows.Forms.Label
    Friend WithEvents lblMailTo As System.Windows.Forms.Label
    Friend WithEvents txtMailTo As System.Windows.Forms.TextBox
    Friend WithEvents lblContent As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents txtMailSub As System.Windows.Forms.TextBox
    Friend WithEvents txtMailFrom As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
	Friend WithEvents WebBrowser2 As System.Windows.Forms.WebBrowser
	Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
End Class
