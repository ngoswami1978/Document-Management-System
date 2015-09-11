<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBCScanDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBCScanDocument))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.lstPic = New System.Windows.Forms.ListBox
        Me.btnFitPage = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnZoomIN = New System.Windows.Forms.Button
        Me.btnZoomOut = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblPageScanned = New System.Windows.Forms.Label
        Me.btnNext = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.drpLetterType = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPaymentMode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtValidfrom = New System.Windows.Forms.TextBox
        Me.lblAgencyName = New System.Windows.Forms.Label
        Me.lblOrderNumber = New System.Windows.Forms.Label
        Me.lblOrderType = New System.Windows.Forms.Label
        Me.txtGroupName = New System.Windows.Forms.TextBox
        Me.txtValidTo = New System.Windows.Forms.TextBox
        Me.txtslabtype = New System.Windows.Forms.TextBox
        Me.txtBCID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtChainCode = New System.Windows.Forms.TextBox
        Me.txtAoffice = New System.Windows.Forms.TextBox
        Me.lblAoffice = New System.Windows.Forms.Label
        Me.lblChaincode = New System.Windows.Forms.Label
        Me.btnPrev = New System.Windows.Forms.Button
        Me.AxImgEdit1 = New AxImgeditLibCtl.AxImgEdit
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.AxImgScan2 = New AxScanLibCtl.AxImgScan
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AxImgEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxImgScan2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.lstPic)
        Me.Panel1.Controls.Add(Me.btnFitPage)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnZoomIN)
        Me.Panel1.Controls.Add(Me.btnZoomOut)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblPageScanned)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(739, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(88, 617)
        Me.Panel1.TabIndex = 61
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(8, 141)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(76, 23)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(8, 45)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 23)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lstPic
        '
        Me.lstPic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstPic.FormattingEnabled = True
        Me.lstPic.Location = New System.Drawing.Point(6, 201)
        Me.lstPic.Name = "lstPic"
        Me.lstPic.Size = New System.Drawing.Size(82, 173)
        Me.lstPic.TabIndex = 48
        Me.lstPic.Visible = False
        '
        'btnFitPage
        '
        Me.btnFitPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFitPage.Location = New System.Drawing.Point(8, 117)
        Me.btnFitPage.Name = "btnFitPage"
        Me.btnFitPage.Size = New System.Drawing.Size(76, 23)
        Me.btnFitPage.TabIndex = 15
        Me.btnFitPage.Text = "Fit Page"
        Me.btnFitPage.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(8, 165)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Visible = False
        '
        'btnZoomIN
        '
        Me.btnZoomIN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomIN.Location = New System.Drawing.Point(8, 93)
        Me.btnZoomIN.Name = "btnZoomIN"
        Me.btnZoomIN.Size = New System.Drawing.Size(76, 23)
        Me.btnZoomIN.TabIndex = 14
        Me.btnZoomIN.Text = "Zoom Out"
        Me.btnZoomIN.UseVisualStyleBackColor = True
        '
        'btnZoomOut
        '
        Me.btnZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomOut.Location = New System.Drawing.Point(8, 69)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(76, 23)
        Me.btnZoomOut.TabIndex = 13
        Me.btnZoomOut.Text = "Zoom In"
        Me.btnZoomOut.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Page Scanned"
        '
        'lblPageScanned
        '
        Me.lblPageScanned.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPageScanned.AutoSize = True
        Me.lblPageScanned.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPageScanned.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageScanned.ForeColor = System.Drawing.Color.Red
        Me.lblPageScanned.Location = New System.Drawing.Point(19, 5)
        Me.lblPageScanned.Name = "lblPageScanned"
        Me.lblPageScanned.Size = New System.Drawing.Size(53, 18)
        Me.lblPageScanned.TabIndex = 50
        Me.lblPageScanned.Text = "PAGE"
        Me.lblPageScanned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(92, 589)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 23)
        Me.btnNext.TabIndex = 11
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.drpLetterType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPaymentMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtValidfrom)
        Me.GroupBox1.Controls.Add(Me.lblAgencyName)
        Me.GroupBox1.Controls.Add(Me.lblOrderNumber)
        Me.GroupBox1.Controls.Add(Me.lblOrderType)
        Me.GroupBox1.Controls.Add(Me.txtGroupName)
        Me.GroupBox1.Controls.Add(Me.txtValidTo)
        Me.GroupBox1.Controls.Add(Me.txtslabtype)
        Me.GroupBox1.Controls.Add(Me.txtBCID)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtChainCode)
        Me.GroupBox1.Controls.Add(Me.txtAoffice)
        Me.GroupBox1.Controls.Add(Me.lblAoffice)
        Me.GroupBox1.Controls.Add(Me.lblChaincode)
        Me.GroupBox1.Location = New System.Drawing.Point(15, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(718, 85)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        '
        'drpLetterType
        '
        Me.drpLetterType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.drpLetterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpLetterType.FormattingEnabled = True
        Me.drpLetterType.Location = New System.Drawing.Point(616, 12)
        Me.drpLetterType.Name = "drpLetterType"
        Me.drpLetterType.Size = New System.Drawing.Size(96, 21)
        Me.drpLetterType.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(557, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Letter Type"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Payment mode"
        '
        'txtPaymentMode
        '
        Me.txtPaymentMode.BackColor = System.Drawing.SystemColors.Window
        Me.txtPaymentMode.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtPaymentMode.Location = New System.Drawing.Point(256, 60)
        Me.txtPaymentMode.Name = "txtPaymentMode"
        Me.txtPaymentMode.ReadOnly = True
        Me.txtPaymentMode.Size = New System.Drawing.Size(117, 20)
        Me.txtPaymentMode.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(187, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Valid from"
        '
        'txtValidfrom
        '
        Me.txtValidfrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValidfrom.BackColor = System.Drawing.SystemColors.Window
        Me.txtValidfrom.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtValidfrom.Location = New System.Drawing.Point(256, 35)
        Me.txtValidfrom.Name = "txtValidfrom"
        Me.txtValidfrom.ReadOnly = True
        Me.txtValidfrom.Size = New System.Drawing.Size(117, 20)
        Me.txtValidfrom.TabIndex = 5
        '
        'lblAgencyName
        '
        Me.lblAgencyName.AutoSize = True
        Me.lblAgencyName.Location = New System.Drawing.Point(184, 13)
        Me.lblAgencyName.Name = "lblAgencyName"
        Me.lblAgencyName.Size = New System.Drawing.Size(65, 13)
        Me.lblAgencyName.TabIndex = 72
        Me.lblAgencyName.Text = "Group name"
        '
        'lblOrderNumber
        '
        Me.lblOrderNumber.AutoSize = True
        Me.lblOrderNumber.Location = New System.Drawing.Point(393, 36)
        Me.lblOrderNumber.Name = "lblOrderNumber"
        Me.lblOrderNumber.Size = New System.Drawing.Size(42, 13)
        Me.lblOrderNumber.TabIndex = 68
        Me.lblOrderNumber.Text = "Valid to"
        '
        'lblOrderType
        '
        Me.lblOrderType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrderType.AutoSize = True
        Me.lblOrderType.Location = New System.Drawing.Point(6, 61)
        Me.lblOrderType.Name = "lblOrderType"
        Me.lblOrderType.Size = New System.Drawing.Size(51, 13)
        Me.lblOrderType.TabIndex = 70
        Me.lblOrderType.Text = "Slab type"
        '
        'txtGroupName
        '
        Me.txtGroupName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.txtGroupName.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtGroupName.Location = New System.Drawing.Point(256, 10)
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.ReadOnly = True
        Me.txtGroupName.Size = New System.Drawing.Size(301, 20)
        Me.txtGroupName.TabIndex = 2
        '
        'txtValidTo
        '
        Me.txtValidTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValidTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtValidTo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtValidTo.Location = New System.Drawing.Point(440, 34)
        Me.txtValidTo.Name = "txtValidTo"
        Me.txtValidTo.ReadOnly = True
        Me.txtValidTo.Size = New System.Drawing.Size(116, 20)
        Me.txtValidTo.TabIndex = 6
        '
        'txtslabtype
        '
        Me.txtslabtype.BackColor = System.Drawing.SystemColors.Window
        Me.txtslabtype.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtslabtype.Location = New System.Drawing.Point(61, 59)
        Me.txtslabtype.Name = "txtslabtype"
        Me.txtslabtype.ReadOnly = True
        Me.txtslabtype.Size = New System.Drawing.Size(110, 20)
        Me.txtslabtype.TabIndex = 7
        '
        'txtBCID
        '
        Me.txtBCID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBCID.BackColor = System.Drawing.SystemColors.Window
        Me.txtBCID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBCID.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtBCID.Location = New System.Drawing.Point(61, 33)
        Me.txtBCID.Name = "txtBCID"
        Me.txtBCID.ReadOnly = True
        Me.txtBCID.Size = New System.Drawing.Size(110, 20)
        Me.txtBCID.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "BC ID"
        '
        'txtChainCode
        '
        Me.txtChainCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtChainCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtChainCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChainCode.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtChainCode.Location = New System.Drawing.Point(61, 9)
        Me.txtChainCode.Name = "txtChainCode"
        Me.txtChainCode.ReadOnly = True
        Me.txtChainCode.Size = New System.Drawing.Size(110, 20)
        Me.txtChainCode.TabIndex = 1
        '
        'txtAoffice
        '
        Me.txtAoffice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAoffice.BackColor = System.Drawing.SystemColors.Window
        Me.txtAoffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAoffice.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtAoffice.Location = New System.Drawing.Point(439, 58)
        Me.txtAoffice.Name = "txtAoffice"
        Me.txtAoffice.ReadOnly = True
        Me.txtAoffice.Size = New System.Drawing.Size(118, 20)
        Me.txtAoffice.TabIndex = 9
        '
        'lblAoffice
        '
        Me.lblAoffice.AutoSize = True
        Me.lblAoffice.Location = New System.Drawing.Point(393, 61)
        Me.lblAoffice.Name = "lblAoffice"
        Me.lblAoffice.Size = New System.Drawing.Size(40, 13)
        Me.lblAoffice.TabIndex = 60
        Me.lblAoffice.Text = "Aoffice"
        '
        'lblChaincode
        '
        Me.lblChaincode.AutoSize = True
        Me.lblChaincode.Location = New System.Drawing.Point(4, 13)
        Me.lblChaincode.Name = "lblChaincode"
        Me.lblChaincode.Size = New System.Drawing.Size(58, 13)
        Me.lblChaincode.TabIndex = 62
        Me.lblChaincode.Text = "Chaincode"
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrev.Location = New System.Drawing.Point(16, 589)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(76, 23)
        Me.btnPrev.TabIndex = 10
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'AxImgEdit1
        '
        Me.AxImgEdit1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxImgEdit1.Location = New System.Drawing.Point(3, 10)
        Me.AxImgEdit1.Name = "AxImgEdit1"
        Me.AxImgEdit1.OcxState = CType(resources.GetObject("AxImgEdit1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxImgEdit1.Size = New System.Drawing.Size(715, 494)
        Me.AxImgEdit1.TabIndex = 18
        Me.AxImgEdit1.UseWaitCursor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.AxImgEdit1)
        Me.GroupBox2.Controls.Add(Me.AxImgScan2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(721, 507)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        '
        'AxImgScan2
        '
        Me.AxImgScan2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxImgScan2.Enabled = True
        Me.AxImgScan2.Location = New System.Drawing.Point(680, 155)
        Me.AxImgScan2.Name = "AxImgScan2"
        Me.AxImgScan2.OcxState = CType(resources.GetObject("AxImgScan2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxImgScan2.Size = New System.Drawing.Size(32, 32)
        Me.AxImgScan2.TabIndex = 43
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.CaptionHeight = 17
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(-2, -1)
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
        Me.C1TrueDBGrid1.TabIndex = 56
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'frmBCScanDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 617)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.C1TrueDBGrid1)
        Me.Name = "frmBCScanDocument"
        Me.Text = "Business Case ScanDocument"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AxImgEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.AxImgScan2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lstPic As System.Windows.Forms.ListBox
    Friend WithEvents btnFitPage As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnZoomIN As System.Windows.Forms.Button
    Friend WithEvents btnZoomOut As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblPageScanned As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents AxImgEdit1 As AxImgeditLibCtl.AxImgEdit
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AxImgScan2 As AxScanLibCtl.AxImgScan
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtBCID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChainCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAoffice As System.Windows.Forms.TextBox
    Friend WithEvents lblAoffice As System.Windows.Forms.Label
    Friend WithEvents lblChaincode As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentMode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtValidfrom As System.Windows.Forms.TextBox
    Friend WithEvents lblAgencyName As System.Windows.Forms.Label
    Friend WithEvents lblOrderNumber As System.Windows.Forms.Label
    Friend WithEvents lblOrderType As System.Windows.Forms.Label
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txtValidTo As System.Windows.Forms.TextBox
    Friend WithEvents txtslabtype As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents drpLetterType As System.Windows.Forms.ComboBox
End Class
