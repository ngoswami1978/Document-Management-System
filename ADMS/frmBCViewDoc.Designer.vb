<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBCViewDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBCViewDoc))
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnFitPage = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnZoomOut = New System.Windows.Forms.Button
        Me.btnZoomIN = New System.Windows.Forms.Button
        Me.pnlPDF = New System.Windows.Forms.Panel
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF
        Me.pnlNextPrev = New System.Windows.Forms.Panel
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnDeleteAll = New System.Windows.Forms.Button
        Me.drpSRNO = New System.Windows.Forms.ComboBox
        Me.btnView = New System.Windows.Forms.Button
        Me.drpLetterType = New System.Windows.Forms.ComboBox
        Me.txtValidfrom = New System.Windows.Forms.TextBox
        Me.lblOrderNumber = New System.Windows.Forms.Label
        Me.txtAoffice = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblAgencyName = New System.Windows.Forms.Label
        Me.lblAoffice = New System.Windows.Forms.Label
        Me.txtBCID = New System.Windows.Forms.TextBox
        Me.txtChaincode = New System.Windows.Forms.TextBox
        Me.lblOrderType = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtValidTo = New System.Windows.Forms.TextBox
        Me.txtTotalPage = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtslabtype = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPaymentMode = New System.Windows.Forms.TextBox
        Me.lblChaincode = New System.Windows.Forms.Label
        Me.txtCurrentpage = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAgencyName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDocType = New System.Windows.Forms.TextBox
        Me.lblImageID = New System.Windows.Forms.Label
        Me.lblHiddenFileNo = New System.Windows.Forms.Label
        Me.lblFlag = New System.Windows.Forms.Label
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.pnlPDF.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNextPrev.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(866, 26)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(73, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnFitPage
        '
        Me.btnFitPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFitPage.Location = New System.Drawing.Point(841, 1)
        Me.btnFitPage.Name = "btnFitPage"
        Me.btnFitPage.Size = New System.Drawing.Size(76, 23)
        Me.btnFitPage.TabIndex = 16
        Me.btnFitPage.Text = "Fit Page"
        Me.btnFitPage.UseVisualStyleBackColor = True
        Me.btnFitPage.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(849, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(76, 23)
        Me.btnPrint.TabIndex = 17
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        Me.btnPrint.Visible = False
        '
        'btnZoomOut
        '
        Me.btnZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomOut.Location = New System.Drawing.Point(846, 1)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(76, 23)
        Me.btnZoomOut.TabIndex = 14
        Me.btnZoomOut.Text = "Zoom In"
        Me.btnZoomOut.UseVisualStyleBackColor = True
        Me.btnZoomOut.Visible = False
        '
        'btnZoomIN
        '
        Me.btnZoomIN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomIN.Location = New System.Drawing.Point(849, 1)
        Me.btnZoomIN.Name = "btnZoomIN"
        Me.btnZoomIN.Size = New System.Drawing.Size(76, 23)
        Me.btnZoomIN.TabIndex = 15
        Me.btnZoomIN.Text = "Zoom Out"
        Me.btnZoomIN.UseVisualStyleBackColor = True
        Me.btnZoomIN.Visible = False
        '
        'pnlPDF
        '
        Me.pnlPDF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPDF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPDF.Controls.Add(Me.AxAcroPDF1)
        Me.pnlPDF.Location = New System.Drawing.Point(4, 103)
        Me.pnlPDF.Name = "pnlPDF"
        Me.pnlPDF.Size = New System.Drawing.Size(883, 606)
        Me.pnlPDF.TabIndex = 61
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(0, 0)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(881, 604)
        Me.AxAcroPDF1.TabIndex = 0
        '
        'pnlNextPrev
        '
        Me.pnlNextPrev.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlNextPrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNextPrev.Controls.Add(Me.btnNext)
        Me.pnlNextPrev.Controls.Add(Me.btnPrev)
        Me.pnlNextPrev.Controls.Add(Me.btnZoomOut)
        Me.pnlNextPrev.Controls.Add(Me.btnZoomIN)
        Me.pnlNextPrev.Controls.Add(Me.btnPrint)
        Me.pnlNextPrev.Controls.Add(Me.btnFitPage)
        Me.pnlNextPrev.Location = New System.Drawing.Point(4, 717)
        Me.pnlNextPrev.Name = "pnlNextPrev"
        Me.pnlNextPrev.Size = New System.Drawing.Size(930, 30)
        Me.pnlNextPrev.TabIndex = 60
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(78, 2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(73, 23)
        Me.btnNext.TabIndex = 13
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrev.Location = New System.Drawing.Point(3, 2)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(73, 23)
        Me.btnPrev.TabIndex = 12
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(866, 50)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(74, 23)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.pnlNextPrev)
        Me.Panel2.Controls.Add(Me.pnlPDF)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(946, 757)
        Me.Panel2.TabIndex = 61
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnDeleteAll)
        Me.Panel1.Controls.Add(Me.drpSRNO)
        Me.Panel1.Controls.Add(Me.btnView)
        Me.Panel1.Controls.Add(Me.drpLetterType)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.txtValidfrom)
        Me.Panel1.Controls.Add(Me.lblOrderNumber)
        Me.Panel1.Controls.Add(Me.txtAoffice)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.lblAgencyName)
        Me.Panel1.Controls.Add(Me.lblAoffice)
        Me.Panel1.Controls.Add(Me.txtBCID)
        Me.Panel1.Controls.Add(Me.txtChaincode)
        Me.Panel1.Controls.Add(Me.lblOrderType)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtValidTo)
        Me.Panel1.Controls.Add(Me.txtTotalPage)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtslabtype)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtPaymentMode)
        Me.Panel1.Controls.Add(Me.lblChaincode)
        Me.Panel1.Controls.Add(Me.txtCurrentpage)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtAgencyName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtDocType)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(946, 101)
        Me.Panel1.TabIndex = 67
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteAll.Location = New System.Drawing.Point(866, 73)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(74, 23)
        Me.btnDeleteAll.TabIndex = 61
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        '
        'drpSRNO
        '
        Me.drpSRNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpSRNO.FormattingEnabled = True
        Me.drpSRNO.Location = New System.Drawing.Point(674, 55)
        Me.drpSRNO.Name = "drpSRNO"
        Me.drpSRNO.Size = New System.Drawing.Size(77, 21)
        Me.drpSRNO.TabIndex = 10
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.Location = New System.Drawing.Point(866, 2)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(73, 23)
        Me.btnView.TabIndex = 11
        Me.btnView.Text = "Refresh"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'drpLetterType
        '
        Me.drpLetterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpLetterType.FormattingEnabled = True
        Me.drpLetterType.Location = New System.Drawing.Point(674, 30)
        Me.drpLetterType.Name = "drpLetterType"
        Me.drpLetterType.Size = New System.Drawing.Size(127, 21)
        Me.drpLetterType.TabIndex = 7
        '
        'txtValidfrom
        '
        Me.txtValidfrom.BackColor = System.Drawing.SystemColors.Control
        Me.txtValidfrom.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtValidfrom.Location = New System.Drawing.Point(314, 33)
        Me.txtValidfrom.Name = "txtValidfrom"
        Me.txtValidfrom.ReadOnly = True
        Me.txtValidfrom.Size = New System.Drawing.Size(112, 20)
        Me.txtValidfrom.TabIndex = 5
        '
        'lblOrderNumber
        '
        Me.lblOrderNumber.AutoSize = True
        Me.lblOrderNumber.Location = New System.Drawing.Point(430, 37)
        Me.lblOrderNumber.Name = "lblOrderNumber"
        Me.lblOrderNumber.Size = New System.Drawing.Size(42, 13)
        Me.lblOrderNumber.TabIndex = 35
        Me.lblOrderNumber.Text = "Valid to"
        '
        'txtAoffice
        '
        Me.txtAoffice.BackColor = System.Drawing.SystemColors.Control
        Me.txtAoffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAoffice.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtAoffice.Location = New System.Drawing.Point(674, 7)
        Me.txtAoffice.Name = "txtAoffice"
        Me.txtAoffice.ReadOnly = True
        Me.txtAoffice.Size = New System.Drawing.Size(127, 20)
        Me.txtAoffice.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(238, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Payment mode"
        '
        'lblAgencyName
        '
        Me.lblAgencyName.AutoSize = True
        Me.lblAgencyName.Location = New System.Drawing.Point(238, 13)
        Me.lblAgencyName.Name = "lblAgencyName"
        Me.lblAgencyName.Size = New System.Drawing.Size(64, 13)
        Me.lblAgencyName.TabIndex = 43
        Me.lblAgencyName.Text = "GroupName"
        '
        'lblAoffice
        '
        Me.lblAoffice.AutoSize = True
        Me.lblAoffice.Location = New System.Drawing.Point(623, 14)
        Me.lblAoffice.Name = "lblAoffice"
        Me.lblAoffice.Size = New System.Drawing.Size(40, 13)
        Me.lblAoffice.TabIndex = 33
        Me.lblAoffice.Text = "Aoffice"
        '
        'txtBCID
        '
        Me.txtBCID.BackColor = System.Drawing.SystemColors.Control
        Me.txtBCID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBCID.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtBCID.Location = New System.Drawing.Point(75, 33)
        Me.txtBCID.Name = "txtBCID"
        Me.txtBCID.ReadOnly = True
        Me.txtBCID.Size = New System.Drawing.Size(113, 20)
        Me.txtBCID.TabIndex = 4
        '
        'txtChaincode
        '
        Me.txtChaincode.BackColor = System.Drawing.SystemColors.Control
        Me.txtChaincode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChaincode.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtChaincode.Location = New System.Drawing.Point(75, 9)
        Me.txtChaincode.Name = "txtChaincode"
        Me.txtChaincode.ReadOnly = True
        Me.txtChaincode.Size = New System.Drawing.Size(113, 20)
        Me.txtChaincode.TabIndex = 1
        '
        'lblOrderType
        '
        Me.lblOrderType.AutoSize = True
        Me.lblOrderType.Location = New System.Drawing.Point(11, 58)
        Me.lblOrderType.Name = "lblOrderType"
        Me.lblOrderType.Size = New System.Drawing.Size(51, 13)
        Me.lblOrderType.TabIndex = 39
        Me.lblOrderType.Text = "Slab type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "BC ID"
        '
        'txtValidTo
        '
        Me.txtValidTo.BackColor = System.Drawing.SystemColors.Control
        Me.txtValidTo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtValidTo.Location = New System.Drawing.Point(472, 33)
        Me.txtValidTo.Name = "txtValidTo"
        Me.txtValidTo.ReadOnly = True
        Me.txtValidTo.Size = New System.Drawing.Size(112, 20)
        Me.txtValidTo.TabIndex = 6
        '
        'txtTotalPage
        '
        Me.txtTotalPage.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPage.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtTotalPage.Location = New System.Drawing.Point(757, 54)
        Me.txtTotalPage.Name = "txtTotalPage"
        Me.txtTotalPage.ReadOnly = True
        Me.txtTotalPage.Size = New System.Drawing.Size(41, 20)
        Me.txtTotalPage.TabIndex = 11
        Me.txtTotalPage.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(240, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Valid from"
        '
        'txtslabtype
        '
        Me.txtslabtype.BackColor = System.Drawing.SystemColors.Control
        Me.txtslabtype.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtslabtype.Location = New System.Drawing.Point(75, 58)
        Me.txtslabtype.Name = "txtslabtype"
        Me.txtslabtype.ReadOnly = True
        Me.txtslabtype.Size = New System.Drawing.Size(113, 20)
        Me.txtslabtype.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(810, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "of"
        Me.Label5.Visible = False
        '
        'txtPaymentMode
        '
        Me.txtPaymentMode.BackColor = System.Drawing.SystemColors.Control
        Me.txtPaymentMode.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtPaymentMode.Location = New System.Drawing.Point(315, 57)
        Me.txtPaymentMode.Name = "txtPaymentMode"
        Me.txtPaymentMode.ReadOnly = True
        Me.txtPaymentMode.Size = New System.Drawing.Size(269, 20)
        Me.txtPaymentMode.TabIndex = 9
        '
        'lblChaincode
        '
        Me.lblChaincode.AutoSize = True
        Me.lblChaincode.Location = New System.Drawing.Point(11, 12)
        Me.lblChaincode.Name = "lblChaincode"
        Me.lblChaincode.Size = New System.Drawing.Size(62, 13)
        Me.lblChaincode.TabIndex = 44
        Me.lblChaincode.Text = "Chain Code"
        '
        'txtCurrentpage
        '
        Me.txtCurrentpage.BackColor = System.Drawing.SystemColors.Control
        Me.txtCurrentpage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentpage.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtCurrentpage.Location = New System.Drawing.Point(757, 54)
        Me.txtCurrentpage.Name = "txtCurrentpage"
        Me.txtCurrentpage.ReadOnly = True
        Me.txtCurrentpage.Size = New System.Drawing.Size(41, 20)
        Me.txtCurrentpage.TabIndex = 10
        Me.txtCurrentpage.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(621, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Doc type"
        '
        'txtAgencyName
        '
        Me.txtAgencyName.BackColor = System.Drawing.SystemColors.Control
        Me.txtAgencyName.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtAgencyName.Location = New System.Drawing.Point(313, 9)
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.ReadOnly = True
        Me.txtAgencyName.Size = New System.Drawing.Size(271, 20)
        Me.txtAgencyName.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(622, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Serial No"
        '
        'txtDocType
        '
        Me.txtDocType.BackColor = System.Drawing.SystemColors.Control
        Me.txtDocType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocType.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtDocType.Location = New System.Drawing.Point(762, 56)
        Me.txtDocType.Name = "txtDocType"
        Me.txtDocType.ReadOnly = True
        Me.txtDocType.Size = New System.Drawing.Size(24, 20)
        Me.txtDocType.TabIndex = 7
        Me.txtDocType.Visible = False
        '
        'lblImageID
        '
        Me.lblImageID.AutoSize = True
        Me.lblImageID.Location = New System.Drawing.Point(850, 319)
        Me.lblImageID.Name = "lblImageID"
        Me.lblImageID.Size = New System.Drawing.Size(0, 13)
        Me.lblImageID.TabIndex = 56
        Me.lblImageID.Visible = False
        '
        'lblHiddenFileNo
        '
        Me.lblHiddenFileNo.AutoSize = True
        Me.lblHiddenFileNo.Location = New System.Drawing.Point(850, 289)
        Me.lblHiddenFileNo.Name = "lblHiddenFileNo"
        Me.lblHiddenFileNo.Size = New System.Drawing.Size(0, 13)
        Me.lblHiddenFileNo.TabIndex = 58
        Me.lblHiddenFileNo.Visible = False
        '
        'lblFlag
        '
        Me.lblFlag.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.lblFlag.AutoSize = True
        Me.lblFlag.Location = New System.Drawing.Point(853, 319)
        Me.lblFlag.Name = "lblFlag"
        Me.lblFlag.Size = New System.Drawing.Size(0, 13)
        Me.lblFlag.TabIndex = 59
        Me.lblFlag.Visible = False
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.CaptionHeight = 17
        Me.C1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(-49, 0)
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
        Me.C1TrueDBGrid1.TabIndex = 55
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'frmBCViewDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 757)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.C1TrueDBGrid1)
        Me.Controls.Add(Me.lblImageID)
        Me.Controls.Add(Me.lblHiddenFileNo)
        Me.Controls.Add(Me.lblFlag)
        Me.Name = "frmBCViewDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BusinessCase ViewDocument"
        Me.pnlPDF.ResumeLayout(False)
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNextPrev.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents pnlNextPrev As System.Windows.Forms.Panel
	Friend WithEvents btnPrev As System.Windows.Forms.Button
	Friend WithEvents btnNext As System.Windows.Forms.Button
	Friend WithEvents Panel2 As System.Windows.Forms.Panel
	Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
	Friend WithEvents lblImageID As System.Windows.Forms.Label
	Friend WithEvents lblHiddenFileNo As System.Windows.Forms.Label
	Friend WithEvents lblFlag As System.Windows.Forms.Label
	Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
	Friend WithEvents pnlPDF As System.Windows.Forms.Panel
	Friend WithEvents btnClose As System.Windows.Forms.Button
	Friend WithEvents btnFitPage As System.Windows.Forms.Button
	Friend WithEvents btnPrint As System.Windows.Forms.Button
	Friend WithEvents btnZoomOut As System.Windows.Forms.Button
	Friend WithEvents btnZoomIN As System.Windows.Forms.Button
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents txtValidfrom As System.Windows.Forms.TextBox
	Friend WithEvents lblOrderNumber As System.Windows.Forms.Label
	Friend WithEvents txtAoffice As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents lblAgencyName As System.Windows.Forms.Label
	Friend WithEvents lblAoffice As System.Windows.Forms.Label
	Friend WithEvents txtBCID As System.Windows.Forms.TextBox
	Friend WithEvents txtChaincode As System.Windows.Forms.TextBox
	Friend WithEvents lblOrderType As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents txtValidTo As System.Windows.Forms.TextBox
	Friend WithEvents txtTotalPage As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtslabtype As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents txtPaymentMode As System.Windows.Forms.TextBox
	Friend WithEvents lblChaincode As System.Windows.Forms.Label
	Friend WithEvents txtCurrentpage As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents txtAgencyName As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents txtDocType As System.Windows.Forms.TextBox
	'Friend WithEvents AxPdf As AxAcroPDFLib.AxAcroPDF
	Friend WithEvents btnDelete As System.Windows.Forms.Button
	Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
	Friend WithEvents drpLetterType As System.Windows.Forms.ComboBox
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents drpSRNO As System.Windows.Forms.ComboBox
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
End Class
