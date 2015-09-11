<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgencyOffice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgencyOffice))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabOrderReceived = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnBackupInstallationDate = New System.Windows.Forms.Button
        Me.dtpBackupInstallationDate = New System.Windows.Forms.TextBox
        Me.btnPrimaryInstallationDate = New System.Windows.Forms.Button
        Me.dtpPrimaryInstallDate = New System.Windows.Forms.TextBox
        Me.txtBackupOnlineStatus = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtBackupOrderNumber = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtPrimaryOrderNumber = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtPrimaryOnlineStatus = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnDateOffline = New System.Windows.Forms.Button
        Me.dtpDateOffLine = New System.Windows.Forms.TextBox
        Me.btnDateOnline = New System.Windows.Forms.Button
        Me.dtpDateOnline = New System.Windows.Forms.TextBox
        Me.drpFileNo = New System.Windows.Forms.ComboBox
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.drpAgencyType = New System.Windows.Forms.ComboBox
        Me.drpPriority = New System.Windows.Forms.ComboBox
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtCCRoster = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtAresponsible = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAoffice = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtWebSite = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtIATAID = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.drpAgencyStatus = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtOfficeName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPinCode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.drpCity = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAgencyName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAgencyGroup = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtOrderFileno = New System.Windows.Forms.TextBox
        Me.txtOrderAddress = New System.Windows.Forms.TextBox
        Me.txtOrderOfficeid = New System.Windows.Forms.TextBox
        Me.txtOrderAgencyname = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.lblAgencyName = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnScan = New System.Windows.Forms.Button
        Me.btnUpdateFile = New System.Windows.Forms.Button
        Me.btnViewDoc = New System.Windows.Forms.Button
        Me.tdbGridOrderReceived = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.imgFileScan = New AxScanLibCtl.AxImgScan
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox1.SuspendLayout()
        Me.TabOrderReceived.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.tdbGridOrderReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFileScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabOrderReceived)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, -37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(677, 637)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TabOrderReceived
        '
        Me.TabOrderReceived.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabOrderReceived.Controls.Add(Me.TabPage1)
        Me.TabOrderReceived.Controls.Add(Me.TabPage2)
        Me.TabOrderReceived.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabOrderReceived.Location = New System.Drawing.Point(3, 16)
        Me.TabOrderReceived.Name = "TabOrderReceived"
        Me.TabOrderReceived.Padding = New System.Drawing.Point(0, 0)
        Me.TabOrderReceived.SelectedIndex = 0
        Me.TabOrderReceived.Size = New System.Drawing.Size(671, 618)
        Me.TabOrderReceived.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.txtWebSite)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtFax)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtIATAID)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.txtPhone)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.drpAgencyStatus)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtEmail)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtOfficeName)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtCountry)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtPinCode)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.drpCity)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtAddress2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtAddress1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtAgencyName)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtAgencyGroup)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(663, 589)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBackupInstallationDate)
        Me.GroupBox2.Controls.Add(Me.dtpBackupInstallationDate)
        Me.GroupBox2.Controls.Add(Me.btnPrimaryInstallationDate)
        Me.GroupBox2.Controls.Add(Me.dtpPrimaryInstallDate)
        Me.GroupBox2.Controls.Add(Me.txtBackupOnlineStatus)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.TxtBackupOrderNumber)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.txtPrimaryOrderNumber)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtPrimaryOnlineStatus)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 472)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(653, 83)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Connectivity"
        '
        'btnBackupInstallationDate
        '
        Me.btnBackupInstallationDate.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnBackupInstallationDate.Location = New System.Drawing.Point(431, 65)
        Me.btnBackupInstallationDate.Name = "btnBackupInstallationDate"
        Me.btnBackupInstallationDate.Size = New System.Drawing.Size(24, 16)
        Me.btnBackupInstallationDate.TabIndex = 55
        Me.btnBackupInstallationDate.UseVisualStyleBackColor = True
        '
        'dtpBackupInstallationDate
        '
        Me.dtpBackupInstallationDate.BackColor = System.Drawing.SystemColors.Control
        Me.dtpBackupInstallationDate.Location = New System.Drawing.Point(284, 60)
        Me.dtpBackupInstallationDate.Name = "dtpBackupInstallationDate"
        Me.dtpBackupInstallationDate.ReadOnly = True
        Me.dtpBackupInstallationDate.Size = New System.Drawing.Size(145, 20)
        Me.dtpBackupInstallationDate.TabIndex = 54
        '
        'btnPrimaryInstallationDate
        '
        Me.btnPrimaryInstallationDate.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnPrimaryInstallationDate.Location = New System.Drawing.Point(431, 39)
        Me.btnPrimaryInstallationDate.Name = "btnPrimaryInstallationDate"
        Me.btnPrimaryInstallationDate.Size = New System.Drawing.Size(24, 16)
        Me.btnPrimaryInstallationDate.TabIndex = 53
        Me.btnPrimaryInstallationDate.UseVisualStyleBackColor = True
        '
        'dtpPrimaryInstallDate
        '
        Me.dtpPrimaryInstallDate.BackColor = System.Drawing.SystemColors.Control
        Me.dtpPrimaryInstallDate.Location = New System.Drawing.Point(284, 34)
        Me.dtpPrimaryInstallDate.Name = "dtpPrimaryInstallDate"
        Me.dtpPrimaryInstallDate.ReadOnly = True
        Me.dtpPrimaryInstallDate.Size = New System.Drawing.Size(145, 20)
        Me.dtpPrimaryInstallDate.TabIndex = 52
        '
        'txtBackupOnlineStatus
        '
        Me.txtBackupOnlineStatus.BackColor = System.Drawing.SystemColors.Control
        Me.txtBackupOnlineStatus.Location = New System.Drawing.Point(99, 59)
        Me.txtBackupOnlineStatus.Name = "txtBackupOnlineStatus"
        Me.txtBackupOnlineStatus.ReadOnly = True
        Me.txtBackupOnlineStatus.Size = New System.Drawing.Size(156, 20)
        Me.txtBackupOnlineStatus.TabIndex = 47
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(8, 36)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(41, 13)
        Me.Label31.TabIndex = 46
        Me.Label31.Text = "Primary"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(527, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 13)
        Me.Label25.TabIndex = 40
        Me.Label25.Text = "Order Number"
        '
        'TxtBackupOrderNumber
        '
        Me.TxtBackupOrderNumber.BackColor = System.Drawing.SystemColors.Control
        Me.TxtBackupOrderNumber.Location = New System.Drawing.Point(492, 58)
        Me.TxtBackupOrderNumber.MaxLength = 12
        Me.TxtBackupOrderNumber.Name = "TxtBackupOrderNumber"
        Me.TxtBackupOrderNumber.ReadOnly = True
        Me.TxtBackupOrderNumber.Size = New System.Drawing.Size(156, 20)
        Me.TxtBackupOrderNumber.TabIndex = 33
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(308, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(83, 13)
        Me.Label27.TabIndex = 36
        Me.Label27.Text = "Installation Date"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(8, 57)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 13)
        Me.Label28.TabIndex = 34
        Me.Label28.Text = "BackUp"
        '
        'txtPrimaryOrderNumber
        '
        Me.txtPrimaryOrderNumber.BackColor = System.Drawing.SystemColors.Control
        Me.txtPrimaryOrderNumber.Location = New System.Drawing.Point(492, 32)
        Me.txtPrimaryOrderNumber.MaxLength = 12
        Me.txtPrimaryOrderNumber.Name = "txtPrimaryOrderNumber"
        Me.txtPrimaryOrderNumber.ReadOnly = True
        Me.txtPrimaryOrderNumber.Size = New System.Drawing.Size(156, 20)
        Me.txtPrimaryOrderNumber.TabIndex = 30
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(134, 15)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(70, 13)
        Me.Label29.TabIndex = 32
        Me.Label29.Text = "Online Status"
        '
        'txtPrimaryOnlineStatus
        '
        Me.txtPrimaryOnlineStatus.BackColor = System.Drawing.SystemColors.Control
        Me.txtPrimaryOnlineStatus.Location = New System.Drawing.Point(99, 33)
        Me.txtPrimaryOnlineStatus.Name = "txtPrimaryOnlineStatus"
        Me.txtPrimaryOnlineStatus.ReadOnly = True
        Me.txtPrimaryOnlineStatus.Size = New System.Drawing.Size(156, 20)
        Me.txtPrimaryOnlineStatus.TabIndex = 28
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnDateOffline)
        Me.GroupBox3.Controls.Add(Me.dtpDateOffLine)
        Me.GroupBox3.Controls.Add(Me.btnDateOnline)
        Me.GroupBox3.Controls.Add(Me.dtpDateOnline)
        Me.GroupBox3.Controls.Add(Me.drpFileNo)
        Me.GroupBox3.Controls.Add(Me.btnUpdate)
        Me.GroupBox3.Controls.Add(Me.drpAgencyType)
        Me.GroupBox3.Controls.Add(Me.drpPriority)
        Me.GroupBox3.Controls.Add(Me.txtReason)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtCCRoster)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtAresponsible)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.txtAoffice)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 322)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(656, 148)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Amadeus Specific"
        '
        'btnDateOffline
        '
        Me.btnDateOffline.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnDateOffline.Location = New System.Drawing.Point(630, 75)
        Me.btnDateOffline.Name = "btnDateOffline"
        Me.btnDateOffline.Size = New System.Drawing.Size(24, 16)
        Me.btnDateOffline.TabIndex = 51
        Me.btnDateOffline.UseVisualStyleBackColor = True
        '
        'dtpDateOffLine
        '
        Me.dtpDateOffLine.BackColor = System.Drawing.SystemColors.Control
        Me.dtpDateOffLine.Location = New System.Drawing.Point(436, 70)
        Me.dtpDateOffLine.Name = "dtpDateOffLine"
        Me.dtpDateOffLine.ReadOnly = True
        Me.dtpDateOffLine.Size = New System.Drawing.Size(192, 20)
        Me.dtpDateOffLine.TabIndex = 50
        '
        'btnDateOnline
        '
        Me.btnDateOnline.Image = Global.ADMS.My.Resources.Resources.calender
        Me.btnDateOnline.Location = New System.Drawing.Point(299, 75)
        Me.btnDateOnline.Name = "btnDateOnline"
        Me.btnDateOnline.Size = New System.Drawing.Size(24, 16)
        Me.btnDateOnline.TabIndex = 49
        Me.btnDateOnline.UseVisualStyleBackColor = True
        '
        'dtpDateOnline
        '
        Me.dtpDateOnline.BackColor = System.Drawing.SystemColors.Control
        Me.dtpDateOnline.Location = New System.Drawing.Point(105, 71)
        Me.dtpDateOnline.Name = "dtpDateOnline"
        Me.dtpDateOnline.ReadOnly = True
        Me.dtpDateOnline.Size = New System.Drawing.Size(192, 20)
        Me.dtpDateOnline.TabIndex = 45
        '
        'drpFileNo
        '
        Me.drpFileNo.BackColor = System.Drawing.SystemColors.Window
        Me.drpFileNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpFileNo.FormattingEnabled = True
        Me.drpFileNo.Location = New System.Drawing.Point(436, 95)
        Me.drpFileNo.Name = "drpFileNo"
        Me.drpFileNo.Size = New System.Drawing.Size(142, 21)
        Me.drpFileNo.TabIndex = 44
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(579, 93)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(72, 23)
        Me.btnUpdate.TabIndex = 47
        Me.btnUpdate.Text = "Save"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'drpAgencyType
        '
        Me.drpAgencyType.BackColor = System.Drawing.SystemColors.Control
        Me.drpAgencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpAgencyType.Enabled = False
        Me.drpAgencyType.FormattingEnabled = True
        Me.drpAgencyType.Location = New System.Drawing.Point(105, 44)
        Me.drpAgencyType.Name = "drpAgencyType"
        Me.drpAgencyType.Size = New System.Drawing.Size(218, 21)
        Me.drpAgencyType.TabIndex = 43
        '
        'drpPriority
        '
        Me.drpPriority.BackColor = System.Drawing.SystemColors.Control
        Me.drpPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpPriority.Enabled = False
        Me.drpPriority.FormattingEnabled = True
        Me.drpPriority.Location = New System.Drawing.Point(436, 44)
        Me.drpPriority.Name = "drpPriority"
        Me.drpPriority.Size = New System.Drawing.Size(218, 21)
        Me.drpPriority.TabIndex = 18
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.SystemColors.Control
        Me.txtReason.Location = New System.Drawing.Point(105, 122)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.ReadOnly = True
        Me.txtReason.Size = New System.Drawing.Size(549, 20)
        Me.txtReason.TabIndex = 27
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 125)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(44, 13)
        Me.Label23.TabIndex = 42
        Me.Label23.Text = "Reason"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(356, 99)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 13)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "File Number"
        '
        'txtCCRoster
        '
        Me.txtCCRoster.BackColor = System.Drawing.SystemColors.Control
        Me.txtCCRoster.Location = New System.Drawing.Point(105, 96)
        Me.txtCCRoster.Name = "txtCCRoster"
        Me.txtCCRoster.ReadOnly = True
        Me.txtCCRoster.Size = New System.Drawing.Size(218, 20)
        Me.txtCCRoster.TabIndex = 25
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 99)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 13)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "Include in CC roster"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(356, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "Date Offline"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 73)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 34
        Me.Label19.Text = "Date Online"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(356, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "Priority"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Type"
        '
        'txtAresponsible
        '
        Me.txtAresponsible.BackColor = System.Drawing.SystemColors.Control
        Me.txtAresponsible.Location = New System.Drawing.Point(436, 19)
        Me.txtAresponsible.Name = "txtAresponsible"
        Me.txtAresponsible.ReadOnly = True
        Me.txtAresponsible.Size = New System.Drawing.Size(218, 20)
        Me.txtAresponsible.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(356, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "A Responsibility"
        '
        'txtAoffice
        '
        Me.txtAoffice.BackColor = System.Drawing.SystemColors.Control
        Me.txtAoffice.Location = New System.Drawing.Point(105, 18)
        Me.txtAoffice.MaxLength = 10
        Me.txtAoffice.Name = "txtAoffice"
        Me.txtAoffice.ReadOnly = True
        Me.txtAoffice.Size = New System.Drawing.Size(218, 20)
        Me.txtAoffice.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "1Aoffice "
        '
        'txtWebSite
        '
        Me.txtWebSite.BackColor = System.Drawing.SystemColors.Control
        Me.txtWebSite.Location = New System.Drawing.Point(436, 290)
        Me.txtWebSite.MaxLength = 100
        Me.txtWebSite.Name = "txtWebSite"
        Me.txtWebSite.ReadOnly = True
        Me.txtWebSite.Size = New System.Drawing.Size(218, 20)
        Me.txtWebSite.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(353, 293)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Web Site"
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.SystemColors.Control
        Me.txtFax.Location = New System.Drawing.Point(105, 293)
        Me.txtFax.MaxLength = 30
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.Size = New System.Drawing.Size(218, 20)
        Me.txtFax.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 293)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Fax"
        '
        'txtIATAID
        '
        Me.txtIATAID.BackColor = System.Drawing.SystemColors.Control
        Me.txtIATAID.Location = New System.Drawing.Point(436, 265)
        Me.txtIATAID.MaxLength = 20
        Me.txtIATAID.Name = "txtIATAID"
        Me.txtIATAID.ReadOnly = True
        Me.txtIATAID.Size = New System.Drawing.Size(218, 20)
        Me.txtIATAID.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(353, 267)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "IATA ID"
        '
        'txtPhone
        '
        Me.txtPhone.BackColor = System.Drawing.SystemColors.Control
        Me.txtPhone.Location = New System.Drawing.Point(105, 267)
        Me.txtPhone.MaxLength = 30
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.ReadOnly = True
        Me.txtPhone.Size = New System.Drawing.Size(218, 20)
        Me.txtPhone.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 267)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Phone"
        '
        'drpAgencyStatus
        '
        Me.drpAgencyStatus.BackColor = System.Drawing.SystemColors.Window
        Me.drpAgencyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpAgencyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpAgencyStatus.FormattingEnabled = True
        Me.drpAgencyStatus.Location = New System.Drawing.Point(436, 239)
        Me.drpAgencyStatus.Name = "drpAgencyStatus"
        Me.drpAgencyStatus.Size = New System.Drawing.Size(218, 21)
        Me.drpAgencyStatus.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(353, 240)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Status"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Control
        Me.txtEmail.Location = New System.Drawing.Point(105, 241)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(218, 20)
        Me.txtEmail.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 241)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Email"
        '
        'txtOfficeName
        '
        Me.txtOfficeName.BackColor = System.Drawing.SystemColors.Control
        Me.txtOfficeName.Location = New System.Drawing.Point(436, 214)
        Me.txtOfficeName.MaxLength = 20
        Me.txtOfficeName.Name = "txtOfficeName"
        Me.txtOfficeName.ReadOnly = True
        Me.txtOfficeName.Size = New System.Drawing.Size(218, 20)
        Me.txtOfficeName.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(353, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Office Name"
        '
        'txtCountry
        '
        Me.txtCountry.BackColor = System.Drawing.SystemColors.Control
        Me.txtCountry.Location = New System.Drawing.Point(105, 215)
        Me.txtCountry.MaxLength = 25
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.ReadOnly = True
        Me.txtCountry.Size = New System.Drawing.Size(218, 20)
        Me.txtCountry.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 215)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Country"
        '
        'txtPinCode
        '
        Me.txtPinCode.BackColor = System.Drawing.SystemColors.Control
        Me.txtPinCode.Location = New System.Drawing.Point(436, 189)
        Me.txtPinCode.MaxLength = 8
        Me.txtPinCode.Name = "txtPinCode"
        Me.txtPinCode.ReadOnly = True
        Me.txtPinCode.Size = New System.Drawing.Size(218, 20)
        Me.txtPinCode.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(353, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "PinCode"
        '
        'drpCity
        '
        Me.drpCity.BackColor = System.Drawing.SystemColors.Control
        Me.drpCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpCity.Enabled = False
        Me.drpCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpCity.FormattingEnabled = True
        Me.drpCity.Location = New System.Drawing.Point(105, 188)
        Me.drpCity.Name = "drpCity"
        Me.drpCity.Size = New System.Drawing.Size(218, 21)
        Me.drpCity.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "City"
        '
        'txtAddress2
        '
        Me.txtAddress2.BackColor = System.Drawing.SystemColors.Control
        Me.txtAddress2.Location = New System.Drawing.Point(105, 126)
        Me.txtAddress2.MaxLength = 45
        Me.txtAddress2.Multiline = True
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.ReadOnly = True
        Me.txtAddress2.Size = New System.Drawing.Size(549, 56)
        Me.txtAddress2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Address2 "
        '
        'txtAddress1
        '
        Me.txtAddress1.BackColor = System.Drawing.SystemColors.Control
        Me.txtAddress1.Location = New System.Drawing.Point(105, 71)
        Me.txtAddress1.MaxLength = 45
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.Size = New System.Drawing.Size(549, 49)
        Me.txtAddress1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Address1 *"
        '
        'txtAgencyName
        '
        Me.txtAgencyName.BackColor = System.Drawing.SystemColors.Control
        Me.txtAgencyName.Location = New System.Drawing.Point(105, 45)
        Me.txtAgencyName.MaxLength = 50
        Me.txtAgencyName.Name = "txtAgencyName"
        Me.txtAgencyName.ReadOnly = True
        Me.txtAgencyName.Size = New System.Drawing.Size(549, 20)
        Me.txtAgencyName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name *"
        '
        'txtAgencyGroup
        '
        Me.txtAgencyGroup.BackColor = System.Drawing.SystemColors.Control
        Me.txtAgencyGroup.Location = New System.Drawing.Point(105, 19)
        Me.txtAgencyGroup.MaxLength = 40
        Me.txtAgencyGroup.Name = "txtAgencyGroup"
        Me.txtAgencyGroup.ReadOnly = True
        Me.txtAgencyGroup.Size = New System.Drawing.Size(549, 20)
        Me.txtAgencyGroup.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Agency Group"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtOrderFileno)
        Me.TabPage2.Controls.Add(Me.txtOrderAddress)
        Me.TabPage2.Controls.Add(Me.txtOrderOfficeid)
        Me.TabPage2.Controls.Add(Me.txtOrderAgencyname)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.lblAgencyName)
        Me.TabPage2.Controls.Add(Me.btnClose)
        Me.TabPage2.Controls.Add(Me.btnScan)
        Me.TabPage2.Controls.Add(Me.btnUpdateFile)
        Me.TabPage2.Controls.Add(Me.btnViewDoc)
        Me.TabPage2.Controls.Add(Me.tdbGridOrderReceived)
        Me.TabPage2.Controls.Add(Me.imgFileScan)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(663, 589)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtOrderFileno
        '
        Me.txtOrderFileno.Location = New System.Drawing.Point(511, 34)
        Me.txtOrderFileno.Name = "txtOrderFileno"
        Me.txtOrderFileno.ReadOnly = True
        Me.txtOrderFileno.Size = New System.Drawing.Size(159, 20)
        Me.txtOrderFileno.TabIndex = 59
        '
        'txtOrderAddress
        '
        Me.txtOrderAddress.Location = New System.Drawing.Point(86, 34)
        Me.txtOrderAddress.Name = "txtOrderAddress"
        Me.txtOrderAddress.ReadOnly = True
        Me.txtOrderAddress.Size = New System.Drawing.Size(369, 20)
        Me.txtOrderAddress.TabIndex = 58
        '
        'txtOrderOfficeid
        '
        Me.txtOrderOfficeid.Location = New System.Drawing.Point(511, 8)
        Me.txtOrderOfficeid.Name = "txtOrderOfficeid"
        Me.txtOrderOfficeid.ReadOnly = True
        Me.txtOrderOfficeid.Size = New System.Drawing.Size(159, 20)
        Me.txtOrderOfficeid.TabIndex = 57
        '
        'txtOrderAgencyname
        '
        Me.txtOrderAgencyname.Location = New System.Drawing.Point(86, 8)
        Me.txtOrderAgencyname.Name = "txtOrderAgencyname"
        Me.txtOrderAgencyname.ReadOnly = True
        Me.txtOrderAgencyname.Size = New System.Drawing.Size(369, 20)
        Me.txtOrderAgencyname.TabIndex = 56
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(468, 37)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 13)
        Me.Label24.TabIndex = 55
        Me.Label24.Text = "FileNo"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 35)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(45, 13)
        Me.Label30.TabIndex = 54
        Me.Label30.Text = "Address"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(461, 7)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 53
        Me.Label26.Text = "OfficeId"
        '
        'lblAgencyName
        '
        Me.lblAgencyName.AutoSize = True
        Me.lblAgencyName.Location = New System.Drawing.Point(6, 12)
        Me.lblAgencyName.Name = "lblAgencyName"
        Me.lblAgencyName.Size = New System.Drawing.Size(74, 13)
        Me.lblAgencyName.TabIndex = 51
        Me.lblAgencyName.Text = "Agency Name"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(823, 30)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 50
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnScan
        '
        Me.btnScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScan.Location = New System.Drawing.Point(741, 29)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(76, 23)
        Me.btnScan.TabIndex = 47
        Me.btnScan.Text = "Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'btnUpdateFile
        '
        Me.btnUpdateFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateFile.Location = New System.Drawing.Point(823, 7)
        Me.btnUpdateFile.Name = "btnUpdateFile"
        Me.btnUpdateFile.Size = New System.Drawing.Size(76, 23)
        Me.btnUpdateFile.TabIndex = 48
        Me.btnUpdateFile.Text = "Update File"
        Me.btnUpdateFile.UseVisualStyleBackColor = True
        '
        'btnViewDoc
        '
        Me.btnViewDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewDoc.Location = New System.Drawing.Point(741, 6)
        Me.btnViewDoc.Name = "btnViewDoc"
        Me.btnViewDoc.Size = New System.Drawing.Size(76, 23)
        Me.btnViewDoc.TabIndex = 46
        Me.btnViewDoc.Text = "View Doc"
        Me.btnViewDoc.UseVisualStyleBackColor = True
        '
        'tdbGridOrderReceived
        '
        Me.tdbGridOrderReceived.AllowUpdate = False
        Me.tdbGridOrderReceived.AlternatingRows = True
        Me.tdbGridOrderReceived.CaptionHeight = 18
        Me.tdbGridOrderReceived.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tdbGridOrderReceived.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbGridOrderReceived.Images.Add(CType(resources.GetObject("tdbGridOrderReceived.Images"), System.Drawing.Image))
        Me.tdbGridOrderReceived.Location = New System.Drawing.Point(3, 60)
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
        Me.tdbGridOrderReceived.Size = New System.Drawing.Size(657, 526)
        Me.tdbGridOrderReceived.TabIndex = 0
        Me.tdbGridOrderReceived.Text = "C1TrueDBGrid2"
        Me.tdbGridOrderReceived.PropBag = resources.GetString("tdbGridOrderReceived.PropBag")
        '
        'imgFileScan
        '
        Me.imgFileScan.Enabled = True
        Me.imgFileScan.Location = New System.Drawing.Point(843, 142)
        Me.imgFileScan.Name = "imgFileScan"
        Me.imgFileScan.OcxState = CType(resources.GetObject("imgFileScan.OcxState"), System.Windows.Forms.AxHost.State)
        Me.imgFileScan.Size = New System.Drawing.Size(32, 32)
        Me.imgFileScan.TabIndex = 49
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(677, 600)
        Me.Panel1.TabIndex = 1
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
        Me.C1TrueDBGrid1.PrintInfo.PageSettings = CType(resources.GetObject("C1TrueDBGrid1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.C1TrueDBGrid1.RecordSelectorWidth = 17
        Me.C1TrueDBGrid1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1TrueDBGrid1.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.C1TrueDBGrid1.RowHeight = 15
        Me.C1TrueDBGrid1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.TabIndex = 0
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'frmAgencyOffice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 600)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAgencyOffice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agency Update FileNumber"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabOrderReceived.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.tdbGridOrderReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFileScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabOrderReceived As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBackupInstallationDate As System.Windows.Forms.Button
    Friend WithEvents dtpBackupInstallationDate As System.Windows.Forms.TextBox
    Friend WithEvents btnPrimaryInstallationDate As System.Windows.Forms.Button
    Friend WithEvents dtpPrimaryInstallDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBackupOnlineStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtBackupOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtPrimaryOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtPrimaryOnlineStatus As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDateOffline As System.Windows.Forms.Button
    Friend WithEvents dtpDateOffLine As System.Windows.Forms.TextBox
    Friend WithEvents btnDateOnline As System.Windows.Forms.Button
    Friend WithEvents dtpDateOnline As System.Windows.Forms.TextBox
    Friend WithEvents drpFileNo As System.Windows.Forms.ComboBox
    Friend WithEvents drpAgencyType As System.Windows.Forms.ComboBox
    Friend WithEvents drpPriority As System.Windows.Forms.ComboBox
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCCRoster As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAresponsible As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAoffice As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtWebSite As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtIATAID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents drpAgencyStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOfficeName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPinCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents drpCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAgencyName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAgencyGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents imgFileScan As AxScanLibCtl.AxImgScan
    Friend WithEvents tdbGridOrderReceived As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnScan As System.Windows.Forms.Button
    Friend WithEvents btnUpdateFile As System.Windows.Forms.Button
    Friend WithEvents btnViewDoc As System.Windows.Forms.Button
    Friend WithEvents txtOrderFileno As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderOfficeid As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderAgencyname As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblAgencyName As System.Windows.Forms.Label
End Class
