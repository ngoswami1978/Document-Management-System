Imports System.Data
Imports System.Xml
Imports System.IO
Imports AAMS.bizShared
Imports AAMS.bizIncetive
Imports System.Data.SqlClient
Public Class frmBusinessCaseSearch
    Dim oDir As DirectoryInfo
    Dim strBuilder As New System.Text.StringBuilder
    Dim objInputXml As New XmlDocument
    Dim objOutPutxml As New XmlDocument
	Dim objSearchedBC As New DataTable ' DATATABLE FILLED WITH SEARCH RESULTS
	Private Sub txtBCID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBCID.KeyPress
		Try
			If e.KeyChar = Chr(13) Then
				Call btnSearch_Click(txtBCID, e)
			End If
		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "txtBCID_KeyPress", exc.GetBaseException)
		End Try
	End Sub
    Private Sub txtGroupName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGroupName.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtGroupName, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "txtGroupName_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtChainCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChainCode.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtChainCode, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "txtChainCode_KeyPress", exc.GetBaseException)
        End Try
    End Sub
	Private Sub drpSignUPAdjustable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpSignUPAdjustable.KeyPress
		Try
			If e.KeyChar = Chr(13) Then
				Call btnSearch_Click(drpSignUPAdjustable, e)
			End If
		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpSignUPAdjustable_KeyPress", exc.GetBaseException)
		End Try
	End Sub
    'drpSlabType
    Private Sub drpSlabType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpSlabType.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpSlabType, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpSlabType_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    'drpDealType
    Private Sub drpDealType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpDealType.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpDealType, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpDealType_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    'drpPaymentType
    Private Sub drpPaymentType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpPaymentType.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpPaymentType, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpPaymentType_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    'drpPLBApplicable
    Private Sub drpPLBApplicable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpPLBApplicable.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpPLBApplicable, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpPLBApplicable_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    'drpPLBApplicable
    Private Sub drpPLBType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpPLBType.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpPLBType, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpPLBType_KeyPress", exc.GetBaseException)
        End Try
    End Sub
	Public Sub frmBusinessCaseSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()

            CreateDataTable()
            Call grid_setting()
            fill_SignUPAdjustable()
            fill_SlabType()
            fill_DealType()
            fill_PaymentType()
            fill_PLBApplicable()
            fill_PLBType()
            lblPaymentType.Visible = False
            drpPaymentType.Visible = False
            lblPLBType.Visible = False
            drpPLBType.Visible = False
            Call grid_setting()
            Dim objSecurityXml As New XmlDocument
            objSecurityXml.LoadXml(SecurityXml)
            objSecurityXml.LoadXml(SecurityXml)
            If (objSecurityXml.DocumentElement.SelectSingleNode("Administrator").InnerText = "0") Then
                If objSecurityXml.DocumentElement.SelectNodes("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='Business Case']").Count <> 0 Then
                    strBuilder = SecurityCheck(objSecurityXml.DocumentElement.SelectSingleNode("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='Business Case']").Attributes("Value").Value)
                    If strBuilder(0) = "0" Then
                        btnSearch.Enabled = False
                    End If
                Else
                    strBuilder = SecurityCheck(31)
                End If
            Else
                strBuilder = SecurityCheck(31)
            End If
            If (objSecurityXml.DocumentElement.SelectSingleNode("Administrator").InnerText = "0") Then
                If objSecurityXml.DocumentElement.SelectNodes("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='Upload Contract or Side letter']").Count <> 0 Then
                    strBuilder = SecurityCheck(objSecurityXml.DocumentElement.SelectSingleNode("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='Upload Contract or Side letter']").Attributes("Value").Value)
                    If strBuilder(0) = "0" Then
                        btnViewDoc.Enabled = False
                    End If
                    If strBuilder(1) = "0" Then
                        btnScanDocument.Enabled = False
                    End If
                Else
                    strBuilder = SecurityCheck(31)
                End If
            Else
                strBuilder = SecurityCheck(31)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "frmBusinessCaseSearch_Load", exc.GetBaseException)
        End Try
    End Sub
    Private Sub fill_PLBType()
        Try
            Dim objTablePLBType As New DataTable
            objTablePLBType.Columns.Add("ID")
            objTablePLBType.Columns.Add("Value")
            objTablePLBType.Rows.Add("--All--", "")
            objTablePLBType.Rows.Add("Fixed", "1")
            objTablePLBType.Rows.Add("Slab", "2")
            drpPLBType.DataSource = objTablePLBType
            drpPLBType.DisplayMember = "ID"
            drpPLBType.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "fill_PLBApplicable", exc.GetBaseException)
        End Try
    End Sub
    Private Sub fill_PLBApplicable()
        Try
            Dim objTablePLBApplicable As New DataTable
            objTablePLBApplicable.Columns.Add("ID")
            objTablePLBApplicable.Columns.Add("Value")
            objTablePLBApplicable.Rows.Add("--All--", "")
            objTablePLBApplicable.Rows.Add("Yes", "True")
            objTablePLBApplicable.Rows.Add("No", "False")
            drpPLBApplicable.DataSource = objTablePLBApplicable
            drpPLBApplicable.DisplayMember = "ID"
            drpPLBApplicable.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
        End Try
    End Sub
    Private Sub fill_PaymentType()
        Try
            Dim objTablePaymentType As New DataTable
            objTablePaymentType.Columns.Add("ID")
            objTablePaymentType.Columns.Add("Value")
            objTablePaymentType.Rows.Add("--All--", "")
            objTablePaymentType.Rows.Add("One Time", "1")
            objTablePaymentType.Rows.Add("Replinishable", "2")
            objTablePaymentType.Rows.Add("Fixed", "3")
            drpPaymentType.DataSource = objTablePaymentType
            drpPaymentType.DisplayMember = "ID"
            drpPaymentType.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "fill_PaymentType", exc.GetBaseException)
        End Try
    End Sub
    Private Sub fill_DealType()
        Try
            Dim objTableDealType As New DataTable
            objTableDealType.Columns.Add("ID")
            objTableDealType.Columns.Add("Value")
            objTableDealType.Rows.Add("--All--", "")
            objTableDealType.Rows.Add("UpFront", "1")
            objTableDealType.Rows.Add("Post", "2")
            drpDealType.DataSource = objTableDealType
            drpDealType.DisplayMember = "ID"
            drpDealType.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "fill_DealType", exc.GetBaseException)
        End Try
    End Sub
    Private Sub fill_SlabType()
        Try
            Dim objTableSlabType As New DataTable
            objTableSlabType.Columns.Add("ID")
            objTableSlabType.Columns.Add("Value")
            objTableSlabType.Rows.Add("--All--", "")
            objTableSlabType.Rows.Add("Rate", "1")
            objTableSlabType.Rows.Add("Fixed", "2")
            objTableSlabType.Rows.Add("Fixed With Rate", "3")
            drpSlabType.DataSource = objTableSlabType
            drpSlabType.DisplayMember = "ID"
            drpSlabType.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "fill_SlabType", exc.GetBaseException)
        End Try
    End Sub
    Private Sub fill_SignUPAdjustable()
        Try
            Dim objTableUPAdjustable As New DataTable
            objTableUPAdjustable.Columns.Add("ID")
            objTableUPAdjustable.Columns.Add("Value")
            objTableUPAdjustable.Rows.Add("--All--", "")
            objTableUPAdjustable.Rows.Add("Yes", "True")
            objTableUPAdjustable.Rows.Add("No", "False")
            drpSignUPAdjustable.DataSource = objTableUPAdjustable
            drpSignUPAdjustable.DisplayMember = "ID"
            drpSignUPAdjustable.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "fill_SignUPAdjustable", exc.GetBaseException)
        End Try
    End Sub
    Private Sub grid_setting()
        Try
            Me.grdBusineecase.Splits(0).DisplayColumns(0).Width = 45   'BC_ID
            Me.grdBusineecase.Splits(0).DisplayColumns(1).Width = 75   'CHAIN_CODE
			Me.grdBusineecase.Splits(0).DisplayColumns(2).Width = 360  'GROUP_NAME
			Me.grdBusineecase.Splits(0).DisplayColumns(3).Width = 90  'Payment Mode
			Me.grdBusineecase.Splits(0).DisplayColumns(4).Width = 95  'Payment Cycle
			Me.grdBusineecase.Splits(0).DisplayColumns(5).Width = 80  'Slab Type
			Me.grdBusineecase.Splits(0).DisplayColumns(6).Width = 100  'SignUp Adjustment
			Me.grdBusineecase.Splits(0).DisplayColumns(7).Width = 80  'PLB Type Name
			Me.grdBusineecase.Splits(0).DisplayColumns(8).Width = 80  'Valid From
			Me.grdBusineecase.Splits(0).DisplayColumns(9).Width = 80  'Valid To
			Me.grdBusineecase.Splits(0).DisplayColumns(10).Width = 80  'Doc Type
			Me.grdBusineecase.Splits(0).DisplayColumns(11).Width = 80	'Aoffice
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "grid_setting", exc.GetBaseException)
        End Try
	End Sub
    Private Sub drpSignUPAdjustable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpSignUPAdjustable.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpSignUPAdjustable.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpSignUPAdjustable_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpSlabType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpSlabType.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpSlabType.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpSlabType_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpDealType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpDealType.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpDealType.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpDealType_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpPaymentType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpPaymentType.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpPaymentType.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpPaymentType_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpPLBApplicable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpPLBApplicable.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpPLBApplicable.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpPLBApplicable_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpPLBType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpPLBType.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpPLBType.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpPLBType_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpDealType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpDealType.SelectedIndexChanged
        Try
            If drpDealType.SelectedValue IsNot Nothing Then
                If drpDealType.SelectedValue.ToString = "1" Then
                    lblPaymentType.Visible = True
                    drpPaymentType.Visible = True
                Else
                    lblPaymentType.Visible = False
                    drpPaymentType.Visible = False
                    drpPaymentType.Text = "--All--"
                End If
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpDealType_SelectedIndexChanged", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpPLBApplicable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpPLBApplicable.SelectedIndexChanged
        Try
            If drpPLBApplicable.SelectedValue IsNot Nothing Then
                If drpPLBApplicable.SelectedValue.ToString = "True" Then
                    lblPLBType.Visible = True
                    drpPLBType.Visible = True
                Else
                    lblPLBType.Visible = False
                    drpPLBType.Visible = False
                    drpPLBType.Text = "--All--"

                End If
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "drpPLBApplicable_SelectedIndexChanged", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnValidFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidFrom.Click
        Try
            Dim objDate As New frmDate
            objDate.StartPosition = FormStartPosition.Manual
            objDate.Location = New Point(110, 138)
            objDate.ShowDialog()
            txtValidFrom.Text = objDate.strDate
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnValidFrom_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnValidTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidTo.Click
        Try
            Dim objDate As New frmDate
            objDate.StartPosition = FormStartPosition.Manual
            objDate.Location = New Point(425, 138)
            objDate.ShowDialog()
            txtValidTo.Text = objDate.strDate
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnValidTo_Click", exc.GetBaseException)
        End Try
    End Sub
	Public Function Getmydate(ByVal dt As System.DateTime) As String
        Dim date_saperator As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator
		Dim date_format As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern()
        Dim ldate, ldate1, ldate2, ldate3 As String
		ldate = dt
		ldate1 = Mid(ldate, 1, 2)  ''day
		ldate2 = Mid(ldate, 4, 2)  ''month
		ldate3 = Mid(ldate, 7, 4)  ''year 
        Select Case date_format
            Case "dd-MMM-yy"
                ldate = ldate1 & date_saperator & ldate2 & date_saperator & ldate3
            Case "dd/MMM/yy"
                ldate = ldate1 & date_saperator & ldate2 & date_saperator & ldate3
                '-----------------------------
            Case "MM/dd/yy"
                ldate = ldate2 & date_saperator & ldate1 & date_saperator & ldate3
            Case "MM/dd/yyyy"
                ldate = ldate2 & date_saperator & ldate1 & date_saperator & ldate3
            Case "M/d/yyyy"

                ldate = ldate2 & date_saperator & ldate1 & date_saperator & ldate3
        End Select
        Return ldate
	End Function
	Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
		Try
            'vdtdate = DateTime.Parse(txtValidFrom.Text.ToString, Globalization.CultureInfo.CreateSpecificCulture("en-CA"))
			'ToDate = CType("txtValidTo", Date)
			Dim dtFrom As Date
			Dim dtTo As Date
            If txtValidFrom.Text <> "" Then
                Try

                dtFrom = DateTime.Parse(txtValidFrom.Text.ToString, Globalization.CultureInfo.CreateSpecificCulture("en-CA"))
                    If IsDate(dtFrom) = False Then
                        MsgBox("Invalid date", MsgBoxStyle.Critical, "Amadeus Document Management System")
                        Exit Sub
                    Else
                        dtFrom = DateTime.Parse(txtValidFrom.Text.ToString, Globalization.CultureInfo.CreateSpecificCulture("en-CA"))
                    End If

                Catch ex As Exception
                    MsgBox("Invalid Date ", MsgBoxStyle.Critical, "Amadeus Document Management System")
                    Exit Sub
                End Try

            End If


            If txtValidTo.Text <> "" Then
                Try
                    dtTo = DateTime.Parse(txtValidTo.Text.ToString, Globalization.CultureInfo.CreateSpecificCulture("en-CA"))
                    If IsDate(dtTo) = False Then
                        MsgBox("Invalid date", MsgBoxStyle.Critical, "Amadeus Document Management System")
                        Exit Sub
                    Else
                        dtTo = DateTime.Parse(txtValidTo.Text.ToString, Globalization.CultureInfo.CreateSpecificCulture("en-CA"))
                    End If
                Catch ex As Exception
                    MsgBox("Invalid Date ", MsgBoxStyle.Critical, "Amadeus Document Management System")
                    Exit Sub
                End Try
            End If


            If (txtValidFrom.Text <> "" And txtValidTo.Text <> "") Then
                If DateDiff("d", dtFrom, dtTo) < 0 Then                 ' which means ("date1 > date2")
                    MsgBox("ValidTo should be greather than or equal to ValidFrom ." & vbCrLf & " ValidTo >= ValidFrom ", MsgBoxStyle.Critical, "Amadeus Document Management System")
                    Exit Sub
                End If
            End If
            If (txtValidFrom.Text <> "" And txtValidTo.Text = "") Or (txtValidFrom.Text = "" And txtValidTo.Text <> "") Then
                MsgBox("Please enter both dates ", MsgBoxStyle.Critical, "Amadeus Document Management System")
                Exit Sub
            End If
            LoadData()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnSearch_Click", exc.GetBaseException)
		Finally
			Me.Cursor = Cursors.Arrow
		End Try
	End Sub
    Friend Sub LoadData()
        Dim objbzBusinessCase As New AAMS.bizIncetive.bzBusinessCase
        Try
            objInputXml.LoadXml("<INC_SEARCH_BUSINESSCASE_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><CHAIN_NAME></CHAIN_NAME><BC_EFFECTIVE_FROM></BC_EFFECTIVE_FROM><BC_VALID_TILL></BC_VALID_TILL><PAGE_NO></PAGE_NO><PAGE_SIZE></PAGE_SIZE><SORT_BY/><DESC/><EmployeeID></EmployeeID><INC_TYPE_ID></INC_TYPE_ID><PAYMENTTYPEID></PAYMENTTYPEID><UPFRONTTYPEID></UPFRONTTYPEID><PLBTYPEID></PLBTYPEID><ADJUSTABLE></ADJUSTABLE><PLBSLAB></PLBSLAB><FINAL_APPROVE>True</FINAL_APPROVE><MODULE></MODULE></INC_SEARCH_BUSINESSCASE_INPUT>")
            objInputXml.DocumentElement.SelectSingleNode("BC_ID").InnerText = txtBCID.Text
            objInputXml.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = txtChainCode.Text
            objInputXml.DocumentElement.SelectSingleNode("CHAIN_NAME").InnerText = txtGroupName.Text
            objInputXml.DocumentElement.SelectSingleNode("BC_EFFECTIVE_FROM").InnerText = GetDateFormat(txtValidFrom.Text, "dd/MM/yyyy", "yyyyMMdd", "/")
            objInputXml.DocumentElement.SelectSingleNode("BC_VALID_TILL").InnerText = GetDateFormat(txtValidTo.Text, "dd/MM/yyyy", "yyyyMMdd", "/")
            objInputXml.DocumentElement.SelectSingleNode("EmployeeID").InnerText = strEmpId
            If drpSignUPAdjustable.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("ADJUSTABLE").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("ADJUSTABLE").InnerText = drpSignUPAdjustable.SelectedValue
            End If

            If drpSlabType.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("PAYMENTTYPEID").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("PAYMENTTYPEID").InnerText = drpSlabType.SelectedValue
            End If

            If drpDealType.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("INC_TYPE_ID").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("INC_TYPE_ID").InnerText = drpDealType.SelectedValue
            End If

            If drpPaymentType.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("UPFRONTTYPEID").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("UPFRONTTYPEID").InnerText = drpPaymentType.SelectedValue
            End If

            If drpPLBApplicable.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("PLBSLAB").InnerText = ""
                drpPLBType.SelectedValue = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("PLBSLAB").InnerText = drpPLBApplicable.SelectedValue
            End If

            If drpPLBType.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("PLBTYPEID").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("PLBTYPEID").InnerText = drpPLBType.SelectedValue
            End If

            objInputXml.DocumentElement.SelectSingleNode("MODULE").InnerText = "ADMS"  ''new added 

            objOutPutxml = objbzBusinessCase.SearchforADMS(objInputXml)

            objSearchedBC.Rows.Clear()
            grdBusineecase.Columns(10).FooterText = ""
            If objOutPutxml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                objSearchedBC = getDataTable(objOutPutxml)
                grdBusineecase.Splits(0).DisplayColumns(10).FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                grdBusineecase.Columns(10).FooterText = "Total:" & objSearchedBC.Rows.Count
                grdBusineecase.SetDataBinding(objSearchedBC, "", True)
                EnableDisableButtons()
            Else
                grdBusineecase.DataSource = Nothing
                Exit Sub
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "LoadData", exc.GetBaseException)
        End Try
    End Sub
	Friend Sub CreateDataTable()
		Try
			Dim BCID As DataColumn = New DataColumn("BCID")
			Dim ChainCode As DataColumn = New DataColumn("ChainCode")
			BCID.DataType = System.Type.GetType("System.Int32")
			objSearchedBC.Columns.Add(BCID)
            ChainCode.DataType = System.Type.GetType("System.Int32")
			objSearchedBC.Columns.Add(ChainCode)
            objSearchedBC.Columns.Add("GroupName")
			objSearchedBC.Columns.Add("PaymentMode")
			objSearchedBC.Columns.Add("PaymentType")
			objSearchedBC.Columns.Add("PaymentCycle")
			objSearchedBC.Columns.Add("SlabType")
			objSearchedBC.Columns.Add("PLBTypeName")
			objSearchedBC.Columns.Add("SignupAdjustment")

            Dim ValidFrom As DataColumn = New DataColumn("ValidFrom")
            ValidFrom.DataType = System.Type.GetType("System.DateTime")
			objSearchedBC.Columns.Add("ValidFrom")

            Dim ValidTill As DataColumn = New DataColumn("ValidTill")
			ValidTill.DataType = System.Type.GetType("System.DateTime")
			objSearchedBC.Columns.Add("ValidTill")

            objSearchedBC.Columns.Add("DocType")
            objSearchedBC.Columns.Add("Aoffice")

            '''''''''''working''''''''''''''''''''''''''''''
            Dim BC_EFFECTIVE_FROM_I As DataColumn = New DataColumn("BC_EFFECTIVE_FROM_I")
            BC_EFFECTIVE_FROM_I.DataType = System.Type.GetType("System.DateTime")
            objSearchedBC.Columns.Add(BC_EFFECTIVE_FROM_I)

            Dim BC_VALID_TILL_I As DataColumn = New DataColumn("BC_VALID_TILL_I")
            BC_VALID_TILL_I.DataType = System.Type.GetType("System.DateTime")
			objSearchedBC.Columns.Add(BC_VALID_TILL_I)
            objSearchedBC.Columns.Add("DOCTYPE1")
            objSearchedBC.AcceptChanges()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "CreateDataTable", exc.GetBaseException)
		End Try
	End Sub
	Private Function getDataTable(ByVal objXmlSearchdoc As XmlDocument) As DataTable
		Dim objDR As DataRow
		Dim objNode As XmlNode
        Dim objnodelist As XmlNodeList = objXmlSearchdoc.SelectNodes("INC_SEARCH_BUSINESSCASE_OUTPUT/BUSINESSCASE")
        Dim dt
		Try
			For Each objNode In objnodelist
				objDR = objSearchedBC.NewRow
				objDR("BCID") = CInt(objNode.Attributes("BC_ID").InnerText)
				objDR("ChainCode") = CInt(objNode.Attributes("CHAIN_CODE").InnerText)
				objDR("GroupName") = objNode.Attributes("GROUP_NAME").InnerText
				objDR("PaymentMode") = objNode.Attributes("INC_TYPE_NAME").InnerText
				objDR("PaymentType") = objNode.Attributes("UPFRONTTYPENAME").InnerText
				objDR("PaymentCycle") = objNode.Attributes("PAYMENT_CYCLE_NAME").InnerText
				objDR("SlabType") = objNode.Attributes("PAYMENTTYPENAME").InnerText
				objDR("PLBTypeName") = objNode.Attributes("PLBTYPENAME").InnerText
				objDR("SignupAdjustment") = objNode.Attributes("ADJUSTABLE").InnerText
                objDR("ValidFrom") = objNode.Attributes("BC_EFFECTIVE_FROM").InnerText
                objDR("ValidTill") = objNode.Attributes("BC_VALID_TILL").InnerText

				objDR("DocType") = objNode.Attributes("DOCTYPE").InnerText
				objDR("Aoffice") = objNode.Attributes("AOFFICE").InnerText

                objDR("BC_EFFECTIVE_FROM_I") = DateTime.ParseExact(objNode.Attributes("BC_EFFECTIVE_FROM_I").InnerText, "yyyyMMdd", Nothing)
                objDR("BC_VALID_TILL_I") = DateTime.ParseExact(objNode.Attributes("BC_VALID_TILL_I").InnerText, "yyyyMMdd", Nothing) 'objNode.Attributes("BC_VALID_TILL_I").InnerText

                objDR("DOCTYPE1") = objNode.Attributes("DOCTYPE1").InnerText
                objSearchedBC.Rows.Add(objDR)
			Next
			objSearchedBC.AcceptChanges()
			Return objSearchedBC
		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "getDataTable", exc.GetBaseException)
		Finally
			objNode = Nothing
		End Try
	End Function
	Private Sub btnScanDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanDocument.Click
		Dim strOrderNumber As String = ""
		Dim strOrderType As String = ""
        'Dim strValidfrom As String = ""
        'Dim strValidto As String = ""
		Dim intImageCount As Integer
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()

            Me.Cursor = Cursors.WaitCursor
            If objSearchedBC.Rows.Count >= 1 Then
                If CType(grdBusineecase.Item(grdBusineecase.Row, 0), String) = "" Then
                    MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    Dim objfrmInput As New frmBCScanDocument
                    objfrmInput.WindowState = FormWindowState.Maximized
                    objfrmInput.txtBCID.Text = grdBusineecase.Item(grdBusineecase.Row, 5).ToString   'BC ID
                    objfrmInput.txtChainCode.Text = grdBusineecase.Item(grdBusineecase.Row, 0).ToString  'CHAIN CODE
                    objfrmInput.txtGroupName.Text = grdBusineecase.Item(grdBusineecase.Row, 1).ToString  'CHAIN NAME
                    objfrmInput.txtPaymentMode.Text = grdBusineecase.Item(grdBusineecase.Row, 2).ToString  'PAYMENT MODE
                    objfrmInput.txtslabtype.Text = grdBusineecase.Item(grdBusineecase.Row, 3).ToString  'SLAB TYPE

                    ' strValidfrom = Format(CDate(grdBusineecase.Item(grdBusineecase.Row, 8).ToString), "dd-MMM-yyyy")  ''VALID FROM
                    objfrmInput.txtValidfrom.Text = Format(CDate(grdBusineecase.Item(grdBusineecase.Row, 8).ToString), "dd-MMM-yyyy")                'strValidfrom.Substring(6, 2) + "-" + MonthName(strValidfrom.Substring(4, 2)).Substring(0, 3).ToUpper.ToString() + "-" + strValidfrom.Substring(0, 4)
                    'strValidto = grdBusineecase.Item(grdBusineecase.Row, 9).ToString  ''VALID TO
                    objfrmInput.txtValidTo.Text = Format(CDate(grdBusineecase.Item(grdBusineecase.Row, 9).ToString), "dd-MMM-yyyy") 'strValidto.Substring(6, 2) + "-" + MonthName(strValidto.Substring(4, 2)).Substring(0, 3).ToUpper.ToString() + "-" + strValidto.Substring(0, 4)

                    objfrmInput.txtAoffice.Text = grdBusineecase.Item(grdBusineecase.Row, 11).ToString 'AOFFICE
                    If CType(grdBusineecase.Item(grdBusineecase.Row, 10), String) = "Contractletter" Then
                        blnContractLetter = True
                    Else
                        blnContractLetter = False
                    End If
                    If CType(grdBusineecase.Item(grdBusineecase.Row, 12), String) = "Sideletter" Then
                        blnSideLetter = True
                    Else
                        blnSideLetter = False
                    End If
                    ''----------------------------------ashish temp hide
                    ' ChangeAtrib()
                    '------------------------------------end Temperory Hide 
                    If blnJAMError = True Then
                        '///////////////////////// do not delete the scanned paper due to paper jammed ////////////////////////////////////////////
                        blnJAMError = True
                        intImageCount = SearchFiles()
                        ScanImageToFile() ' Temperory Hide 
                        ChangeAtrib()
                        If CheckFileExistance() = True Then objfrmInput.ShowDialog()
                        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Else

                        ''----------------------------------ashish temp hide
                        DeleteFiles() ' Temperory Hide 
                        '------------------------------------end Temperory Hide 
                        blnJAMError = False
                        'Check image count before scanning , if any images (*.tiff) existes into configured Image Folder than do not start Scanning
                        ''----------------------------------ashish temp hide
                        intImageCount = SearchFiles()
                        If intImageCount > 0 Then
                            MsgBox("Please delete images from  " & strFilePath)
                            Exit Sub
                        End If
                        'end Check image count before scanning , if any images (*.tiff) existes into configured Image Folder than do not start Scanning
                        '------------------------------------end Temperory Hide 


                        ''-----------------------------ashish temp hide
                        ScanImageToFile()
                        ''------------------------------end  Temperory Hide 

                        ''-----------------------------ashish temp hide
                        ChangeAtrib()
                        ''------------------------------end  Temperory Hide 
                        If CheckFileExistance() = True Then objfrmInput.ShowDialog()
                    End If
                End If
            Else
                MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If
            ''**************************************           
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnScanDocument_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
	End Sub
	Private Function SearchFiles() As Integer
		Try
			Dim x As Integer = 0
			Dim sFiles As FileInfo
            oDir = New DirectoryInfo(strFilePath)
			Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            For Each sFiles In oDir.GetFiles("*.tif")
                x += 1
            Next
            Return x
		Catch exc As Exception
		Finally
			oDir = Nothing
		End Try
	End Function
	Private Sub DeleteFiles()
		Dim oDir As DirectoryInfo
		Dim sFilesInfo As FileInfo
        Try

            GC.Collect()
            GC.WaitForPendingFinalizers()

            oDir = New DirectoryInfo(strFilePath)
            Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            For Each sFilesInfo In oDir.GetFiles("*.tif")

                System.IO.File.Delete(strFilePath & "\" & sFilesInfo.ToString)
            Next
            For Each sFilesInfo In oDir.GetFiles("*.pdf")
                System.IO.File.Delete(strFilePath & "\" & sFilesInfo.ToString)
            Next
        Catch exc As Exception
            'MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "DeleteFiles", exc.GetBaseException)
        Finally
            oDir = Nothing
            sFilesInfo = Nothing
        End Try
	End Sub
	Private Sub ChangeAtrib()
		Try
			If FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes And 1 Then
				FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes = FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes - 1
			End If

		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "ChangeAtrib", exc.GetBaseException)
		End Try
	End Sub
	Private Sub ScanImageToFile()
		Try
            imgFileScan.ResetScanner()
            imgFileScan.ScanTo = ScanLibCtl.ScanToConstants.UseFileTemplateOnly
            imgFileScan.FileType = ScanLibCtl.FileTypeConstants.TIFF
			imgFileScan.Image = strFilePath & "\" & "img"
            imgFileScan.MultiPage = True
			imgFileScan.PageCount = 1
			imgFileScan.ShowSetupBeforeScan = True
            imgFileScan.OpenScanner()
			imgFileScan.StartScan()
            imgFileScan.UseWaitCursor = True
			If imgFileScan.StatusCode.ToString() = "-2146827175" Then
                blnJAMError = True
            ElseIf imgFileScan.StatusCode.ToString() = "0" Then
                blnJAMError = False
            End If
            imgFileScan.StopScan()
			imgFileScan.CloseScanner()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "ScanImageToFile", exc.GetBaseException)
		Finally
			'MsgBox(blnJAMError)
			imgFileScan.ResetScanner()
			imgFileScan.MultiPage = True
            If imgFileScan.Image.Length > 0 Then
                imgFileScan.Image = String.Empty
            End If
		End Try
	End Sub
	Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub
	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		Try
			ClearControl()
			EnableDisableButtons()
		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnClear_Click", exc.GetBaseException)
		End Try
	End Sub
	Private Sub ClearControl()
		Try
			txtBCID.Text = String.Empty
			txtChainCode.Text = String.Empty
			txtGroupName.Text = String.Empty
			txtValidFrom.Text = String.Empty
			txtValidTo.Text = String.Empty
			drpSignUPAdjustable.SelectedIndex = 0
			drpSlabType.SelectedIndex = 0
			drpDealType.SelectedIndex = 0
			drpPaymentType.SelectedIndex = 0
			drpPLBApplicable.SelectedIndex = 0
			drpPLBType.SelectedIndex = 0
			objSearchedBC.Rows.Clear()
			grdBusineecase.Columns(10).FooterText = ""
			grdBusineecase.SetDataBinding(objSearchedBC, "", True)
		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "ClearControl", exc.GetBaseException)
		End Try
	End Sub
	Private Sub btnViewDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDoc.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If objSearchedBC.Rows.Count >= 1 Then
                If CType(grdBusineecase.Item(grdBusineecase.Row, 0), String) = "" Then       'if use does not select any agency
                    MsgBox("Please Select Business case", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    DeleteFiles()
                    Dim objfrmInput As New frmBCViewDoc(CType(grdBusineecase.Item(grdBusineecase.Row, "BCID"), String), 100)
                    objfrmInput.WindowState = FormWindowState.Normal
                    objfrmInput.Height = 980
                    objfrmInput.ShowDialog()
                End If
            Else
                MsgBox("Please Select Chain Code", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnViewMisc_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
        'Try
        '	Me.Cursor = Cursors.WaitCursor
        '	If objSearchedBC.Rows.Count >= 1 Then
        '		If CType(grdBusineecase.Item(grdBusineecase.Row, 0), String) = "" Then		 'if use does not select any agency
        '			MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
        '			Exit Sub
        '		Else
        '			DeleteFiles()
        '			Dim objfrmInput As New frmBCViewDoc(CType(grdBusineecase.Item(grdBusineecase.Row, "BCID"), String))
        '			objfrmInput.WindowState = FormWindowState.Normal
        '			objfrmInput.Height = 980
        '			If CInt(strZoomPercentage) <> 0 Then
        '				'objfrmInput.AxImgEdit1.Zoom = CInt(strZoomPercentage)
        '			End If
        '			objfrmInput.ShowDialog()
        '		End If

        '	Else
        '		MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
        '		Exit Sub
        '	End If

        'Catch exc As Exception
        '	MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
        '	Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnViewMisc_Click", exc.GetBaseException)
        'Finally
        '	Me.Cursor = Cursors.Arrow
        'End Try
	End Sub
	Private Sub btnViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewAll.Click
		Try
			Me.Cursor = Cursors.WaitCursor
			If objSearchedBC.Rows.Count >= 1 Then
				If CType(grdBusineecase.Item(grdBusineecase.Row, 0), String) = "" Then		 'if use does not select any agency
					MsgBox("Please Select Chain Code", MsgBoxStyle.Information, "Amadeus Document Management System")
					Exit Sub
				Else
					DeleteFiles()
					Dim objfrmInput As New frmBCViewDoc(CType(grdBusineecase.Item(grdBusineecase.Row, "ChainCode"), String), "ChainCode")
					objfrmInput.WindowState = FormWindowState.Normal
					objfrmInput.Height = 980
					If CInt(strZoomPercentage) <> 0 Then
						'objfrmInput.AxImgEdit1.Zoom = CInt(strZoomPercentage)
					End If
					objfrmInput.ShowDialog()
				End If
            Else
                MsgBox("Please Select Chain Code", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
			End If

		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnViewMisc_Click", exc.GetBaseException)
		Finally
			Me.Cursor = Cursors.Arrow
		End Try
	End Sub
	' ashish comment on 24-apr-14
    'Private Sub grdBusineecase_FormatText(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FormatTextEventArgs) Handles grdBusineecase.FormatText
	'    Dim result As String
	'    Dim x As Integer
	'    x = 0

	'    Try
	'        If e.ColIndex = 8 Or e.ColIndex = 9 Then
	'            result = e.Value.ToString()
	'            result = result.Substring(6, 2) + "-" + MonthName(result.Substring(4, 2)).Substring(0, 3).ToUpper.ToString() + "-" + result.Substring(0, 4)
	'            'result = GetDateFormat(result, "dd/MM/yyyy", "dd-MMM-yyyy", "/")
	'            e.Value = result
	'            x = x + 1
	'        End If

	'    Catch exc As Exception
	'        MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
	'        Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "grdBusineecase_FormatText", exc.GetBaseException)
	'    End Try
	'End Sub
	Private Sub txtValidFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValidFrom.KeyPress
		Try
			If Asc(e.KeyChar) = 47 Then Exit Sub ''delete
			If Asc(e.KeyChar) = 8 Then Exit Sub ''for backspace
            If Char.IsPunctuation(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsSurrogate(e.KeyChar) Or Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtBCID, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "txtBCID_KeyPress", exc.GetBaseException)
		End Try
	End Sub
	Private Sub txtValidTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValidTo.KeyPress
		Try
			If Asc(e.KeyChar) = 47 Then Exit Sub ''delete
			If Asc(e.KeyChar) = 8 Then Exit Sub ''for backspace
            If Char.IsPunctuation(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsSurrogate(e.KeyChar) Or Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtBCID, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "txtBCID_KeyPress", exc.GetBaseException)
		End Try
	End Sub
	Private Function CheckFileExistance() As Boolean
		Dim oDir As DirectoryInfo
		Dim sFilesInfo As FileInfo
		Dim i As Integer
		Dim blnFound As Boolean = False
		Try
			oDir = New DirectoryInfo(strFilePath)
			Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            For Each sFilesInfo In oDir.GetFiles("*.tif")
                i += 1
                If i > 0 Then
                    blnFound = True
                    Exit For
                End If
            Next
		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "DeleteFiles", exc.GetBaseException)
		Finally
			oDir = Nothing
			sFilesInfo = Nothing
			CheckFileExistance = blnFound
		End Try
	End Function
	Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
		Dim objbzBusinessCase As New AAMS.bizIncetive.bzBusinessCase()
		Dim xInputXml, xOutputXml As New XmlDocument
		Dim msgFlag As Integer
        Try
            Me.Cursor = Cursors.WaitCursor
            If objSearchedBC.Rows.Count >= 1 Then
                If CType(grdBusineecase.Item(grdBusineecase.Row, 0), String) = "" Then       'if use does not select any agency
                    MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    xInputXml.LoadXml("<INC_DELETE_SCANNED_DOCTYPE_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><DELETEALL></DELETEALL></INC_DELETE_SCANNED_DOCTYPE_INPUT>")
                    xInputXml.DocumentElement.SelectSingleNode("BC_ID").InnerText = CType(grdBusineecase.Item(grdBusineecase.Row, "BCID"), String)
                    xInputXml.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = CType(grdBusineecase.Item(grdBusineecase.Row, "ChainCode"), String)
                    xInputXml.DocumentElement.SelectSingleNode("DELETEALL").InnerText = "TRUE"
                    MsgBox("It is recommended that first you take PrintOut , then go for deleted.", MsgBoxStyle.Information, "Amadeus Document Management System")
                    'msgFlag = MsgBox("Are you sure want to delete selected doctype?", MsgBoxStyle.YesNo, "Amadeus Document Management System")
                    msgFlag = MsgBox("Delete all document sets for business case?", MsgBoxStyle.YesNo, "Amadeus Document Management System")
                    If msgFlag = 6 Then
                        xOutputXml = objbzBusinessCase.DeleteDocType(xInputXml)
                        If xOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                            msgFlag = MsgBox("Deleted successfully!", MsgBoxStyle.OkOnly, "Amadeus Document Management System")
                            LoadData()
                        End If
                    Else
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "btnDelete_Click", ex.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
	End Sub
	Private Sub EnableDisableButtons()
        If CType(grdBusineecase.Item(grdBusineecase.Row, "DocType"), String).Trim() = "" And CType(grdBusineecase.Item(grdBusineecase.Row, "DocType1"), String).Trim() = "" Then
            btnScanDocument.Enabled = True
            btnDelete.Enabled = False
            btnViewDoc.Enabled = False
            btnViewAll.Enabled = False
        ElseIf CType(grdBusineecase.Item(grdBusineecase.Row, "DocType"), String).Trim() <> "" And CType(grdBusineecase.Item(grdBusineecase.Row, "DocType1"), String).Trim() <> "" Then
            'btnScanDocument.Enabled = False
            btnScanDocument.Enabled = True
            btnDelete.Enabled = True
            btnViewDoc.Enabled = True
            btnViewAll.Enabled = True
        ElseIf CType(grdBusineecase.Item(grdBusineecase.Row, "DocType"), String).Trim() <> "" And CType(grdBusineecase.Item(grdBusineecase.Row, "DocType1"), String).Trim() = "" Then
            btnScanDocument.Enabled = True
            btnDelete.Enabled = True
            btnViewDoc.Enabled = True
            btnViewAll.Enabled = True
        ElseIf CType(grdBusineecase.Item(grdBusineecase.Row, "DocType"), String).Trim() = "" And CType(grdBusineecase.Item(grdBusineecase.Row, "DocType1"), String).Trim() <> "" Then
            btnScanDocument.Enabled = True
            btnDelete.Enabled = True
            btnViewDoc.Enabled = True
            btnViewAll.Enabled = True
        Else
            btnDelete.Enabled = False
            btnViewDoc.Enabled = False
            btnViewAll.Enabled = False
        End If

		''--------------------------------------------OLD CODE-------------------------------------------
		'If CType(grdBusineecase.Item(grdBusineecase.Row, "DocType"), String).Trim() = "" Or (CType(grdBusineecase.Item(grdBusineecase.Row, "DocType"), String).Trim() = "Contractletter" And CType(grdBusineecase.Item(grdBusineecase.Row, "DocType1"), String).Trim() = "SideLetter") Then
		'	If CType(grdBusineecase.Item(grdBusineecase.Row, "BCID"), String).Trim() = "" Then
		'		btnScanDocument.Enabled = False
		'	Else
		'		btnScanDocument.Enabled = True
		'	End If
		'	btnDelete.Enabled = False
		'	btnViewDoc.Enabled = False
		'	btnViewAll.Enabled = False

		'Else
		'	btnScanDocument.Enabled = False
		'	btnDelete.Enabled = True
		'	btnViewDoc.Enabled = True
		'	btnViewAll.Enabled = True
		'End If
		'-----------------------------------------------END HERE------------------------------------------

	End Sub
	Private Sub grdBusineecase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBusineecase.Click
        If objSearchedBC.Rows.Count >= 1 Then
            If CType(grdBusineecase.Item(grdBusineecase.Row, 0), String) = "" Then
                MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If

            If (CType(grdBusineecase.Item(grdBusineecase.Row, "DOCTYPE"), String).Trim() = "Contractletter") Then
                blnContractLetter = True
            Else
                blnContractLetter = False
            End If

            If (CType(grdBusineecase.Item(grdBusineecase.Row, "DOCTYPE1"), String).Trim() = "Sideletter") Then
                blnSideLetter = True
            Else
                blnSideLetter = False
            End If
            Call EnableDisableButtons()
            'MsgBox(CType(grdBusineecase.Item(grdBusineecase.Row, "DOCTYPE1"), String).Trim())
        End If
    End Sub
	Private Sub grdBusineecase_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdBusineecase.RowColChange
        If objSearchedBC.Rows.Count >= 1 Then
            If CType(grdBusineecase.Item(grdBusineecase.Row, 0), String) = "" Then
                MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If
            'MsgBox(CType(grdBusineecase.Item(grdBusineecase.Row, "BCID"), String).Trim())
            'MsgBox(CType(grdBusineecase.Item(grdBusineecase.Row, "DOCTYPE"), String).Trim())
            If (CType(grdBusineecase.Item(grdBusineecase.Row, "DOCTYPE"), String).Trim() = "Contractletter") Then
                blnContractLetter = True
            Else
                blnContractLetter = False
            End If

            If (CType(grdBusineecase.Item(grdBusineecase.Row, "DOCTYPE1"), String).Trim() = "Sideletter") Then
                blnSideLetter = True
            Else
                blnSideLetter = False
            End If
            Call EnableDisableButtons()
            'MsgBox(CType(grdBusineecase.Item(grdBusineecase.Row, "DOCTYPE1"), String).Trim())
        End If
    End Sub

    'Enum SortDir
    '    None
    '    Asc
    '    Desc
    'End Enum
    ''SortDir

    'Private _sortup, _sortdn As Bitmap
    'Private Sub C1TrueDBGrid1_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles grdBusineecase.HeadClick
    '    ' get the display column that was clicked
    '    Dim dc As C1.Win.C1TrueDBGrid.C1DisplayColumn = Me.grdBusineecase.Splits(0).DisplayColumns(e.ColIndex)

    '    ' new sort order
    '    Dim newsort As SortDir = SortDir.None
    '    Select Case CType(dc.DataColumn.Tag, SortDir)
    '        Case SortDir.None, SortDir.Desc
    '            newsort = SortDir.Asc
    '        Case Else
    '            newsort = SortDir.Desc
    '    End Select

    '    ' clear all sort states and our sort indicators
    '    Dim col As C1.Win.C1TrueDBGrid.C1DisplayColumn
    '    For Each col In Me.grdBusineecase.Splits(0).DisplayColumns
    '        col.DataColumn.Tag = SortDir.None
    '        col.HeadingStyle.ForegroundImage = Nothing
    '    Next col

    '    ' build our new sort condition
    '    Dim sortCondition As String = dc.DataColumn.DataField + " "
    '    sortCondition += IIf(newsort = SortDir.Desc, "DESC", "")

    '    ' sort it
    '    objSearchedBC.DefaultView.Sort = sortCondition

    '    ' save the sort state
    '    dc.DataColumn.Tag = newsort

    '    ' update the sorting indicator
    '    If newsort = SortDir.Asc Then
    '        dc.HeadingStyle.ForegroundImage = Me._sortup
    '    Else
    '        dc.HeadingStyle.ForegroundImage = Me._sortdn
    '    End If ' indicators go to the right of text
    '    dc.HeadingStyle.ForeGroundPicturePosition = C1.Win.C1TrueDBGrid.ForeGroundPicturePositionEnum.RightOfText
    'End Sub

End Class