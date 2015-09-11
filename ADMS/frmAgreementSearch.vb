Imports System.Data
Imports System.Xml
Imports System.IO
Imports AAMS.bizShared
Imports AAMS.bizIncetive
Imports System.Data.SqlClient
Public Class frmAgreementSearch
    Dim oDir As DirectoryInfo
    Dim strBuilder As New System.Text.StringBuilder
    Dim objInputXml As New XmlDocument
    Dim objOutPutxml As New XmlDocument
    Dim objSearchedBC As New DataTable ' DATATABLE FILLED WITH SEARCH RESULTS
    Dim formLoaded As Boolean
    Private Sub frmAgreementSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fill_SignUPAdjustable()  'done
        fill_SlabType()  'DONE
        fill_PLBApplicable() 'done
        fill_PLBType()  'done
        fill_PaymentMode()
        fill_UpfrontType()
        fill_DocumentType()
        fill_Period()
        GetDataForPeriod()
        grid_setting()
        formLoaded = True
    End Sub
    Private Sub fill_PaymentMode()
        Try
            Dim objTablePaymentMode As New DataTable
            objTablePaymentMode.Columns.Add("ID")
            objTablePaymentMode.Columns.Add("Value")
            objTablePaymentMode.Rows.Add("--All--", "")
            objTablePaymentMode.Rows.Add("Upfront", "1")
            objTablePaymentMode.Rows.Add("Post", "2")
            drpPaymentMode.DataSource = objTablePaymentMode
            drpPaymentMode.DisplayMember = "ID"
            drpPaymentMode.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "fill_PLBApplicable", exc.GetBaseException)
        End Try

    End Sub
    Private Sub fill_UpfrontType()
        Try
            Dim objTableUpfrontType As New DataTable
            objTableUpfrontType.Columns.Add("ID")
            objTableUpfrontType.Columns.Add("Value")
            objTableUpfrontType.Rows.Add("--All--", "")
            objTableUpfrontType.Rows.Add("One Time", "1")
            objTableUpfrontType.Rows.Add("Replinishable", "2")
            objTableUpfrontType.Rows.Add("Fixed", "3")
            drpUpfrontType.DataSource = objTableUpfrontType
            drpUpfrontType.DisplayMember = "ID"
            drpUpfrontType.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "fill_PLBApplicable", exc.GetBaseException)
        End Try

    End Sub
    Private Sub fill_DocumentType()
        Try
            Dim objTableDocumentType As New DataTable
            objTableDocumentType.Columns.Add("ID")
            objTableDocumentType.Columns.Add("Value")
            objTableDocumentType.Rows.Add("--All--", "")
            objTableDocumentType.Rows.Add("Contract Letter", "1")
            objTableDocumentType.Rows.Add("Side Letter", "2")
            drpDocumentType.DataSource = objTableDocumentType
            drpDocumentType.DisplayMember = "ID"
            drpDocumentType.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "fill_PLBApplicable", exc.GetBaseException)
        End Try

    End Sub
    Private Sub fill_Period()
        Try
            Dim objTablePeriod As New DataTable
            objTablePeriod.Columns.Add("ID")
            objTablePeriod.Columns.Add("Value")
            objTablePeriod.Rows.Add("--All--", "")
            drpPeriod.DataSource = objTablePeriod
            drpPeriod.DisplayMember = "ID"
            drpPeriod.ValueMember = "Value"
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "fill_PLBApplicable", exc.GetBaseException)
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
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "fill_PLBApplicable", exc.GetBaseException)
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
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "fill_PLBApplicable", exc.GetBaseException)
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
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "fill_SlabType", exc.GetBaseException)
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
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "fill_SignUPAdjustable", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtBCID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBCID.KeyUp
        Try
            If e.KeyValue = 13 Or e.KeyValue = Keys.Tab Then
                Call btnSearch_Click(txtBCID, e)
            End If
            GetDataForPeriod()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "txtBCID_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtChainCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChainCode.KeyUp
        Try
            If e.KeyValue = 13 Or e.KeyValue = Keys.Tab Then
                Call btnSearch_Click(txtChainCode, e)
            End If
            GetDataForPeriod()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "txtChainCode_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtGROUPNAME_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGROUPNAME.KeyUp
        Try
            If e.KeyValue = 13 Or e.KeyValue = Keys.Tab Then
                Call btnSearch_Click(txtChainCode, e)
            End If
            FillDateAfterGroupNameKeyPress()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "txtChainCode_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub FillDateAfterGroupNameKeyPress()
        Dim objTablePaymentMode As New DataTable
        objTablePaymentMode.Columns.Add("Text")
        objTablePaymentMode.Columns.Add("Value")
        objTablePaymentMode.Rows.Add("--All--", "")
        For Each objNode As DataRow In objSearchedBC.Rows
            Dim val As String() = objNode("PERIOD").ToString().Split("  to   ")
            Dim d1 As String = New DateTime(CType(val(2), Integer), System.Enum.Parse(GetType(Months), val(1), True), CType(val(0), Integer)).ToString("yyyyMMdd")
            Dim d2 As String = New DateTime(CType(val(9), Integer), System.Enum.Parse(GetType(Months), val(8), True), CType(val(7), Integer)).ToString("yyyyMMdd")
            Dim exists As Boolean = False
            For Each Item As DataRow In objTablePaymentMode.Rows
                If (objNode("PERIOD") = Item("Text")) Then
                    exists = True
                    Exit For
                End If
            Next
            If (Not exists) Then
                objTablePaymentMode.Rows.Add(objNode("PERIOD"), d1 + "&" + d2)
            End If
        Next
        drpPeriod.DataSource = objTablePaymentMode
        drpPeriod.DisplayMember = "Text"
        drpPeriod.ValueMember = "Value"
    End Sub
    Private Sub HandleKeyPressEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpSignUPAdjustable.KeyPress, drpSlabType.KeyPress, drpPaymentMode.KeyPress, drpPLBApplicable.KeyPress, drpPLBType.KeyPress, drpUpfrontType.KeyPress, drpDocumentType.KeyPress
        Dim selectedDropdown = CType(sender, ComboBox)
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(selectedDropdown, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "drpSignUPAdjustable_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub HandleKeyDownEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpSignUPAdjustable.KeyDown, drpSlabType.KeyDown, drpPaymentMode.KeyDown, drpUpfrontType.KeyDown, drpPLBApplicable.KeyDown, drpPLBType.KeyDown, drpDocumentType.KeyDown, drpPeriod.KeyDown
        Dim selectedDropdown = CType(sender, ComboBox)
        Try
            If e.KeyCode = 46 Then 'Delete
                selectedDropdown.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "HandleKeyDownEvent", exc.GetBaseException)
        End Try

    End Sub
    Private Sub HandleDropDownPostbacks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpPLBApplicable.SelectedIndexChanged, drpPaymentMode.SelectedIndexChanged, drpUpfrontType.SelectedIndexChanged, drpSlabType.SelectedIndexChanged, drpSignUPAdjustable.SelectedIndexChanged, drpPLBType.SelectedIndexChanged, drpDocumentType.SelectedIndexChanged, drpPeriod.SelectedIndexChanged
        Dim drp As ComboBox = CType(sender, ComboBox)
        Try
            If (drp.Equals(drpPLBApplicable)) Then
                If drpPLBApplicable.SelectedValue IsNot Nothing Then
                    If drpPLBApplicable.SelectedValue.ToString = "True" Then
                        drpPLBType.Visible = True
                        drpPLBType.Visible = True
                        lblPLBType.Visible = True
                    Else
                        lblPLBType.Visible = False
                        drpPLBType.Visible = False
                        drpPLBType.Visible = False
                        drpPLBType.Text = "--All--"
                    End If
                End If
            ElseIf (drp.Equals(drpPaymentMode)) Then
                If drpPaymentMode.SelectedValue IsNot Nothing Then
                    If drpPaymentMode.SelectedValue.ToString = "1" Then
                        drpUpfrontType.Visible = True
                        drpUpfrontType.Visible = True
                        lblUpfrontType.Visible = True
                    Else
                        lblUpfrontType.Visible = False
                        drpUpfrontType.Visible = False
                        drpUpfrontType.Visible = False
                        drpUpfrontType.Text = "--All--"
                    End If
                End If
            End If
            If (formLoaded) Then
                Call btnSearch_Click(drp, e)
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "HandleDropDownPostbacks", exc.GetBaseException)
        End Try
        If (drp IsNot drpPeriod) Then
            GetDataForPeriod()
        End If

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            LoadData()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "btnSearch_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub LoadData()
        Dim objbzBusinessCase As New AAMS.bizIncetive.bzBusinessCase
        Try
            objInputXml.LoadXml("<INC_SEARCH_BUSINESSCASE_INPUT><BC_ID /> <CHAIN_CODE /><CHAIN_NAME/> <BC_EFFECTIVE_FROM /> <BC_VALID_TILL /> <PAGE_NO>1</PAGE_NO> <PAGE_SIZE>25</PAGE_SIZE> <SORT_BY>CHAIN_CODE</SORT_BY> <DESC>FALSE</DESC> <EmployeeID/> <INC_TYPE_ID /> <PAYMENTTYPEID /> <UPFRONTTYPEID /> <PLBTYPEID /> <ADJUSTABLE /> <PLBSLAB /> <DOCTYPE /> <STYPE>1</STYPE> <FINAL_APPROVE>3</FINAL_APPROVE> </INC_SEARCH_BUSINESSCASE_INPUT>")
            objInputXml.DocumentElement.SelectSingleNode("BC_ID").InnerText = txtBCID.Text
            objInputXml.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = txtChainCode.Text
            objInputXml.DocumentElement.SelectSingleNode("EmployeeID").InnerText = strEmpId
            objInputXml.DocumentElement.SelectSingleNode("CHAIN_NAME").InnerText = txtGROUPNAME.Text

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

            If drpPaymentMode.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("INC_TYPE_ID").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("INC_TYPE_ID").InnerText = drpPaymentMode.SelectedValue
            End If

            If drpUpfrontType.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("UPFRONTTYPEID").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("UPFRONTTYPEID").InnerText = drpUpfrontType.SelectedValue
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
            If drpDocumentType.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = drpDocumentType.SelectedValue
            End If
            If drpPeriod.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("BC_EFFECTIVE_FROM").InnerText = ""
                objInputXml.DocumentElement.SelectSingleNode("BC_VALID_TILL").InnerText = ""
            Else
                Dim selectedValue As String() = drpPeriod.SelectedValue.ToString().Split("&")
                objInputXml.DocumentElement.SelectSingleNode("BC_EFFECTIVE_FROM").InnerText = selectedValue(0)
                objInputXml.DocumentElement.SelectSingleNode("BC_VALID_TILL").InnerText = selectedValue(1)
            End If

            objOutPutxml = objbzBusinessCase.SearchforADMS(objInputXml)


            objSearchedBC = New DataTable
            grdAgreement.Columns(4).FooterText = ""
            If objOutPutxml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                CreateDataTable()

                objSearchedBC = getDataTable(objOutPutxml)
                grdAgreement.DataSource = objSearchedBC
                grdAgreement.Splits(0).DisplayColumns(4).FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                grdAgreement.Columns(4).FooterText = " Total:" & objSearchedBC.Rows.Count

                grdAgreement.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                grdAgreement.Splits(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                grdAgreement.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                grdAgreement.Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                grdAgreement.SetDataBinding(objSearchedBC, "", True)
                grid_setting()
            Else
                grdAgreement.DataSource = Nothing
                Exit Sub
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "LoadData", exc.GetBaseException)
        End Try

    End Sub
    Private Sub CreateDataTable()
        Try
            Dim BCID As DataColumn = New DataColumn("BC_ID")
            Dim ChainCode As DataColumn = New DataColumn("CHAIN_CODE")
            BCID.DataType = System.Type.GetType("System.Int32")
            ChainCode.DataType = System.Type.GetType("System.Int32")

            objSearchedBC.Columns.Add(ChainCode)
            objSearchedBC.Columns.Add(BCID)
            objSearchedBC.Columns.Add("GROUP_NAME")
            objSearchedBC.Columns.Add("DOCTYPE")
            objSearchedBC.Columns.Add("PERIOD")
            objSearchedBC.AcceptChanges()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "CreateDataTable", exc.GetBaseException)
        End Try
    End Sub
    Private Function getDataTable(ByVal objXmlSearchdoc As XmlDocument) As DataTable
        Dim objDR As DataRow
        Dim objNode As XmlNode
        Dim objnodelist As XmlNodeList = objXmlSearchdoc.SelectNodes("INC_SEARCH_BUSINESSCASE_OUTPUT/BUSINESSCASE")
        Try
            For Each objNode In objnodelist
                objDR = objSearchedBC.NewRow
                objDR("CHAIN_CODE") = CInt(objNode.Attributes("CHAIN_CODE").InnerText)
                objDR("BC_ID") = CInt(objNode.Attributes("BC_ID").InnerText)
                objDR("GROUP_NAME") = objNode.Attributes("GROUP_NAME").InnerText
                objDR("PERIOD") = objNode.Attributes("BC_EFFECTIVE_FROM").InnerText + "  to   " + objNode.Attributes("BC_VALID_TILL").InnerText
                objDR("DOCTYPE") = objNode.Attributes("DOCTYPE").InnerText
                objSearchedBC.Rows.Add(objDR)
            Next
            objSearchedBC.AcceptChanges()
            Return objSearchedBC
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "getDataTable", exc.GetBaseException)
        Finally
            objNode = Nothing
        End Try
    End Function

    Private Sub grid_setting()
        Try
            Me.grdAgreement.Splits(0).DisplayColumns(0).Width = 100   'CHAIN_CODE
            Me.grdAgreement.Splits(0).DisplayColumns(1).Width = 100   'BC_ID
            Me.grdAgreement.Splits(0).DisplayColumns(2).Width = 550  'GROUP_NAME
            Me.grdAgreement.Splits(0).DisplayColumns(3).Width = 200  'Doc Type
            Me.grdAgreement.Splits(0).DisplayColumns(4).Width = 250  'Period

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "grid_setting", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            ClearControl()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "btnClear_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub ClearControl()
        Try
            txtBCID.Text = String.Empty
            txtChainCode.Text = String.Empty
            drpSignUPAdjustable.SelectedIndex = 0
            drpSlabType.SelectedIndex = 0
            drpDocumentType.SelectedIndex = 0
            drpPeriod.SelectedIndex = 0
            drpPaymentMode.SelectedIndex = 0
            drpPLBApplicable.SelectedIndex = 0
            drpPLBType.SelectedIndex = 0
            objSearchedBC.Rows.Clear()
            grdAgreement.Columns(4).FooterText = ""
            grdAgreement.SetDataBinding(objSearchedBC, "", True)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "ClearControl", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnViewDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDoc.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If objSearchedBC.Rows.Count >= 1 Then
                If CType(grdAgreement.Item(grdAgreement.Row, 0), String) = "" Then       'if use does not select any agency
                    MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    DeleteFiles()
                    Dim objfrmInput As New frmBCViewDoc(CType(grdAgreement.Item(grdAgreement.Row, "BC_ID"), String), 100, False)
                    objfrmInput.WindowState = FormWindowState.Normal
                    objfrmInput.Height = 980
                    If CInt(strZoomPercentage) <> 0 Then
                        'objfrmInput.AxImgEdit1.Zoom = CInt(strZoomPercentage)
                    End If
                    objfrmInput.ShowDialog()
                End If

            Else
                MsgBox("Please Select BCID", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "btnViewMisc_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub DeleteFiles()
        Dim oDir As DirectoryInfo
        Dim sFilesInfo As FileInfo
        Try
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
            Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "DeleteFiles", exc.GetBaseException)
        Finally
            oDir = Nothing
            sFilesInfo = Nothing
        End Try
    End Sub
    Private Sub grdAgreement_FormatText(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FormatTextEventArgs) Handles grdAgreement.FormatText
        'Dim result As String
        'Dim x As Integer
        'x = 0

        'Try
        '    If e.ColIndex = 8 Or e.ColIndex = 9 Then
        '        result = e.Value.ToString()
        '        result = result.Substring(6, 2) + "-" + MonthName(result.Substring(4, 2)).Substring(0, 3).ToUpper.ToString() + "-" + result.Substring(0, 4)
        '        'result = GetDateFormat(result, "dd/MM/yyyy", "dd-MMM-yyyy", "/")
        '        e.Value = result
        '        x = x + 1
        '    End If

        'Catch exc As Exception
        '    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
        '    Call AAMS.bizShared.bzShared.LogWrite("frmBusinessCaseSearch", "grdBusineecase_FormatText", exc.GetBaseException)
        'End Try
    End Sub
    Private Sub GetDataForPeriod()
        Dim objbzBusinessCase As New AAMS.bizIncetive.bzBusinessCase
        objInputXml.LoadXml("<INC_SEARCH_BUSINESSCASE_INPUT><BC_ID /> <CHAIN_CODE /> <EmployeeID/> <INC_TYPE_ID /> <PAYMENTTYPEID /> <UPFRONTTYPEID /> <PLBTYPEID /> <ADJUSTABLE /> <PLBSLAB /> <DOCTYPE /> </INC_SEARCH_BUSINESSCASE_INPUT>")
        objInputXml.DocumentElement.SelectSingleNode("BC_ID").InnerText = txtBCID.Text
        objInputXml.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = txtChainCode.Text
        objInputXml.DocumentElement.SelectSingleNode("EmployeeID").InnerText = strEmpId

        Try
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

            If drpPaymentMode.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("INC_TYPE_ID").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("INC_TYPE_ID").InnerText = drpPaymentMode.SelectedValue
            End If

            If drpUpfrontType.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("UPFRONTTYPEID").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("UPFRONTTYPEID").InnerText = drpUpfrontType.SelectedValue
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
            If drpDocumentType.SelectedValue = "" Then
                objInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = ""
            Else
                objInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = drpDocumentType.SelectedValue
            End If

            objOutPutxml = objbzBusinessCase.List_ContractPeriod(objInputXml)
            Dim objTablePaymentMode As New DataTable
            objTablePaymentMode.Columns.Add("Text")
            objTablePaymentMode.Columns.Add("Value")
            objTablePaymentMode.Rows.Add("--All--", "")
            If objOutPutxml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                Dim objNode As XmlNode
                Dim objnodelist As XmlNodeList = objOutPutxml.SelectNodes("UP_LST_CONTRACT_PERIOD_OUTPUT/CONTRACTPERIOD")
                Try
                    For Each objNode In objnodelist
                        objTablePaymentMode.Rows.Add(objNode.Attributes("BC_EFFECTIVE_FROM_TEXT").InnerText + " to " + objNode.Attributes("BC_VALID_TILL_TEXT").InnerText, objNode.Attributes("BC_EFFECTIVE_FROM_VALUE").InnerText + "&" + objNode.Attributes("BC_VALID_TILL_VALUE").InnerText)
                    Next
                    drpPeriod.DataSource = objTablePaymentMode
                    drpPeriod.DisplayMember = "Text"
                    drpPeriod.ValueMember = "Value"
                Catch exc As Exception
                    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
                    Call AAMS.bizShared.bzShared.LogWrite("frmAgreementSearch", "getDataTable", exc.GetBaseException)
                Finally
                    objNode = Nothing
                End Try
            Else
                drpPeriod.DataSource = objTablePaymentMode
                drpPeriod.DisplayMember = "Text"
                drpPeriod.ValueMember = "Value"
                Exit Sub
            End If
        Catch ex As Exception
        End Try

    End Sub
    Enum Months
        JAN = 1
        FEB = 2
        MAR = 3
        APR = 4
        MAY = 5
        JUN = 6
        JUL = 7
        AUG = 8
        SEP = 9
        OCT = 10
        NOV = 11
        DEC = 12
    End Enum
    Private Sub btmClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmClose.Click
        Me.Close()
    End Sub
End Class