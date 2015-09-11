'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmAgencySearch.vb $
'$Workfile: frmAgencySearch.vb $fileno

'$Revision: 85 $
'$Archive: /AAMS/Interface/ADMS/frmAgencySearch.vb $
'$Modtime: 12/03/14 4:53p $
Imports System.Text
Imports System.Xml
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports AAMS.bizTravelAgency
Imports AAMS.bizShared
'Imports Microsoft.Office.Interop.Excel


Public Class frmAgencySearch
    Dim strBuilder As New System.Text.StringBuilder
    Dim objSearchedDT As New DataTable ' DATATABLE FILLED WITH SEARCH RESULTS
    Dim flag As Boolean
    Dim miscFlag As Boolean
    Dim intExetension As Integer
    Dim objExportOutputXml As New XmlDocument
    '    Private Sub frmAgencySearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '      Try
    '            AgencyView()

    '        Catch exc As Exception
    '            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "frmAgencySearch_Activated", exc.GetBaseException)
    '        End Try

    'End Sub
    Private Sub frmAgencySearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            pnlDate.Visible = False

            Call grid_setting_for_Agency()
            Call grid_setting_for_ScanDateAgency()  ''new grid

            Call BindControls()
            Call ClearControl()
            Dim objSecurityXml As New XmlDocument
            objSecurityXml.LoadXml(SecurityXml)
            If (objSecurityXml.DocumentElement.SelectSingleNode("Administrator").InnerText = "0") Then
                If objSecurityXml.DocumentElement.SelectNodes("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='Agency']").Count <> 0 Then
                    strBuilder = SecurityCheck(objSecurityXml.DocumentElement.SelectSingleNode("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='Agency Prioity']").Attributes("Value").Value)
                    If strBuilder(0) = "0" Then
                        btnSearch.Enabled = False

                    End If
                    If strBuilder(2) = "0" Then
                        btnModify.Enabled = False
                    End If
                Else
                    ' btnSearch.Enabled = False
                    ' btnModify.Enabled = False
                    strBuilder = SecurityCheck(31)
                End If
            Else
                strBuilder = SecurityCheck(31)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "frmAgencySearch_Load", exc.GetBaseException)
        Finally

        End Try
    End Sub
    Private Sub BindControls()
        Try
            BindDropDown(drpCity, "CITY", True)
            BindDropDown(drpCountry, "COUNTRY", True)
            BindDropDown(drpAoffice, "AOFFICE", True)
            BindDropDown(drpCRS, "CRS", True)
            BindDropDown(drpAgencyType, "ATYPE", True)
            BindDropDown(drpAgencyStatus, "ASTATUS", False)
            BindDropDown(drpOnlineStatus, "ONLINESTATUS", True)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "BindControls", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpCity.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpCity.SelectedIndex = -1
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpCity_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpCountry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpCountry.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpCountry.SelectedIndex = -1
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpCountry_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpAoffice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpAoffice.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpAoffice.SelectedIndex = -1
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpAoffice_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpCRS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpCRS.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpCRS.SelectedIndex = -1
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpCRS_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnSearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            AgencyofficeSearch()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnSearch_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub AgencyofficeSearch()
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objXmlReader As XmlNodeReader
        Dim numDateOnline, numDateOffline As String
        Dim ds As New DataSet
        Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency

        Try


            'If (txtDateOnline.Text) <> "  /  /" Then
            '    numDateOnline = GetDateInt(txtDateOnline.Text)
            'Else
            '    numDateOnline = ""
            'End If
            'If (txtDateOffline.Text) <> "  /  /" Then
            '    numDateOffline = GetDateInt(txtDateOffline.Text)
            'Else
            '    numDateOffline = ""
            'End If

            If chkDate.Checked = False Then
            objInputXml.LoadXml("<MS_SEARCHAGENCY_INPUT><NAME></NAME><LOCATION_CODE></LOCATION_CODE><SearchType></SearchType><LOCATION_SHORT_NAME></LOCATION_SHORT_NAME><City_Name></City_Name><Country_Name></Country_Name><StatusCode></StatusCode><Aoffice></Aoffice><OFFICEID></OFFICEID><Crs></Crs><ADDRESS></ADDRESS><AgencyStatusId></AgencyStatusId><AgencyTypeId></AgencyTypeId><EMAIL></EMAIL><DATE_ONLINE></DATE_ONLINE><DATE_OFFLINE></DATE_OFFLINE><FAX></FAX><FILENO></FILENO><IATA_TID></IATA_TID><EmployeeID></EmployeeID><Limited_To_Aoffice></Limited_To_Aoffice><Limited_To_Region></Limited_To_Region><Limited_To_OwnAagency></Limited_To_OwnAagency><SecurityRegionID></SecurityRegionID><PAGE_NO>0</PAGE_NO><PAGE_SIZE>0</PAGE_SIZE><SORT_BY></SORT_BY><DESC></DESC><IPAddress></IPAddress><Online_Status_BackUp></Online_Status_BackUp><PRIORITYID></PRIORITYID><PHONE></PHONE><WWW_ADDRESS></WWW_ADDRESS><RESPONSIBILITY_1A></RESPONSIBILITY_1A><ORDERNO></ORDERNO></MS_SEARCHAGENCY_INPUT>")
            Else
             objInputXml.LoadXml("<MS_SEARCHAGENCY_INPUT><NAME></NAME><LOCATION_CODE></LOCATION_CODE><SearchType></SearchType><LOCATION_SHORT_NAME></LOCATION_SHORT_NAME><City_Name></City_Name><Country_Name></Country_Name><StatusCode></StatusCode><Aoffice></Aoffice><OFFICEID></OFFICEID><Crs></Crs><ADDRESS></ADDRESS><AgencyStatusId></AgencyStatusId><AgencyTypeId></AgencyTypeId><EMAIL></EMAIL><DATE_ONLINE></DATE_ONLINE><DATE_OFFLINE></DATE_OFFLINE><FAX></FAX><FILENO></FILENO><IATA_TID></IATA_TID><EmployeeID></EmployeeID><Limited_To_Aoffice></Limited_To_Aoffice><Limited_To_Region></Limited_To_Region><Limited_To_OwnAagency></Limited_To_OwnAagency><SecurityRegionID></SecurityRegionID><PAGE_NO>0</PAGE_NO><PAGE_SIZE>0</PAGE_SIZE><SORT_BY></SORT_BY><DESC></DESC><IPAddress></IPAddress><Online_Status_BackUp></Online_Status_BackUp><PRIORITYID></PRIORITYID><PHONE></PHONE><WWW_ADDRESS></WWW_ADDRESS><RESPONSIBILITY_1A></RESPONSIBILITY_1A><ORDERNO></ORDERNO><Is_Date_Checked></Is_Date_Checked><DOCUMENTDATEFROM></DOCUMENTDATEFROM><DOCUMENTDATETO></DOCUMENTDATETO></MS_SEARCHAGENCY_INPUT>")
            End If
            objInputXml.DocumentElement.SelectSingleNode("NAME").InnerText = Trim(txtAgencyName.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerText = "" 'Trim(txtAgencyName.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("SearchType").InnerText = "Contains" & ""
            objInputXml.DocumentElement.SelectSingleNode("LOCATION_SHORT_NAME").InnerText = Trim(txtShortName.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("City_Name").InnerText = Trim(drpCity.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("Country_Name").InnerText = Trim(drpCountry.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("StatusCode").InnerText = Trim(drpOnlineStatus.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("Aoffice").InnerText = Trim(drpAoffice.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("OFFICEID").InnerText = Trim(txtOfficeId.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("Crs").InnerText = Trim(drpCRS.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("ADDRESS").InnerText = Trim(txtAddress.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("AgencyStatusId").InnerText = Trim(drpAgencyStatus.SelectedValue) & ""
            objInputXml.DocumentElement.SelectSingleNode("AgencyTypeId").InnerText = Trim(drpAgencyType.SelectedValue) & ""
            objInputXml.DocumentElement.SelectSingleNode("EMAIL").InnerText = Trim(txtEmail.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("DATE_ONLINE").InnerText = numDateOnline & ""
            objInputXml.DocumentElement.SelectSingleNode("DATE_OFFLINE").InnerText = numDateOffline & ""
            objInputXml.DocumentElement.SelectSingleNode("FAX").InnerText = Trim(txtFax.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("FILENO").InnerText = Trim(txtFileNumber.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("IATA_TID").InnerText = Trim(txtIATAID.Text) & ""
            objInputXml.DocumentElement.SelectSingleNode("EmployeeID").InnerText = strEmpId
            objInputXml.DocumentElement.SelectSingleNode("Limited_To_Aoffice").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("Limited_To_Region").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("Limited_To_OwnAagency").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("SecurityRegionID").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("IPAddress").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("Online_Status_BackUp").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("PRIORITYID").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("PHONE").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("WWW_ADDRESS").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("RESPONSIBILITY_1A").InnerText = ""
            objInputXml.DocumentElement.SelectSingleNode("ORDERNO").InnerText = txtOrderNo.Text



            'Here Back end Method Call

            If chkDate.Checked = False Then
             grdAgency.Visible = True
             grdScanDateAgency.Visible = False
             btnScanMisc.Enabled = True

             objOutputXml = objbzAgency.Search(objInputXml)
             objExportOutputXml = objOutputXml
            Else

                Dim dtFrom As Date
                Dim dtTo As Date
                If Date.TryParseExact(txtFrom.Text.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None, dtFrom) = False Then
                  MsgBox("Invalid From Date", MsgBoxStyle.Critical, "ADMS")
                  txtFrom.Focus()
                  Exit Sub
                End If

                If Date.TryParseExact(txtTo.Text.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None, dtTo) = False Then
                  MsgBox("Invalid To Date", MsgBoxStyle.Critical, "ADMS")
                   txtTo.Focus()
                  Exit Sub
                End If

              '  MsgBox(DateDiff(DateInterval.Day, dtFrom, dtTo))
                If DateDiff(DateInterval.Day, dtFrom, dtTo) < 0 Then
                  MsgBox("ToDate should be >= FromDate", MsgBoxStyle.Critical, "ADMS")
                  Exit Sub
                End If
                    grdAgency.Visible = False
                    grdScanDateAgency.Visible = True
                    btnScanMisc.Enabled = False

                    objInputXml.DocumentElement.SelectSingleNode("Is_Date_Checked").InnerText = 1
                    objInputXml.DocumentElement.SelectSingleNode("DOCUMENTDATEFROM").InnerText = Getmydate(txtFrom.Text)
                    objInputXml.DocumentElement.SelectSingleNode("DOCUMENTDATETO").InnerText = Getmydate(txtTo.Text)

                    objOutputXml = objbzAgency.SearchScanDocumentDate(objInputXml)
                    objExportOutputXml = objOutputXml
             End If

            objSearchedDT.Clear()
            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                If chkDate.Checked = False Then
                    objSearchedDT = getDataTable(objOutputXml)
                    grdAgency.DataSource = objSearchedDT.DefaultView
                Else
                    objSearchedDT = getDataTableScan(objOutputXml)
                    grdScanDateAgency.DataSource = objSearchedDT.DefaultView
                End If
            Else
                objSearchedDT = getDataTable(objOutputXml)
                grdAgency.DataSource = objSearchedDT.DefaultView
            End If

            ''call function here
                If chkDate.Checked = False Then
                    Call grid_setting_for_Agency()
                Else
                    Call grid_setting_for_ScanDateAgency()
                End If




        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "AgencyofficeSearch", exc.GetBaseException)
        Finally
            objInputXml = Nothing
            objOutputXml = Nothing
        End Try
    End Sub
Public Function Getmydate(ByVal dt As System.String) As Integer
        Dim date_saperator As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator
        Dim date_format As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern()
        Dim ldate, ldate1, ldate2, ldate3 As String
        Dim intDate As Integer
        ldate = dt
        ldate1 = Mid(ldate, 1, 2)  ''day
        ldate2 = Mid(ldate, 4, 2)  ''month
        ldate3 = Mid(ldate, 7, 4)  ''year 
        intDate = ldate3 + ldate2 + ldate1
        Return intDate
    End Function
    Private Sub grid_setting_for_Agency()
        Try
            Me.grdAgency.Splits(0).DisplayColumns(0).Width = 45     'locde
            Me.grdAgency.Splits(0).DisplayColumns(1).Width = 65     'Office ID
            Me.grdAgency.Splits(0).DisplayColumns(2).Width = 185     'Agency Name
            Me.grdAgency.Splits(0).DisplayColumns(3).Width = 230     'address
            Me.grdAgency.Splits(0).DisplayColumns(4).Width = 230     'address1
            Me.grdAgency.Splits(0).DisplayColumns(5).Width = 70     'city
            Me.grdAgency.Splits(0).DisplayColumns(6).Width = 62     'country
            Me.grdAgency.Splits(0).DisplayColumns(7).Width = 100    'onlinestatus
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "grid_setting_for_Agency", exc.GetBaseException)
        End Try
    End Sub
    Private Sub grid_setting_for_ScanDateAgency()
        Try
            Me.grdScanDateAgency.Splits(0).DisplayColumns(0).Width = 45     'locde
            Me.grdScanDateAgency.Splits(0).DisplayColumns(1).Width = 65     'Office ID
            Me.grdScanDateAgency.Splits(0).DisplayColumns(2).Width = 185     'Agency Name
            Me.grdScanDateAgency.Splits(0).DisplayColumns(3).Width = 230     'address
            Me.grdScanDateAgency.Splits(0).DisplayColumns(4).Width = 230     'address1
            Me.grdScanDateAgency.Splits(0).DisplayColumns(5).Width = 70     'city
            Me.grdScanDateAgency.Splits(0).DisplayColumns(6).Width = 62     'country
            Me.grdScanDateAgency.Splits(0).DisplayColumns(7).Width = 100    'onlinestatus
            Me.grdScanDateAgency.Splits(0).DisplayColumns(8).Width = 80    'Order Number
            Me.grdScanDateAgency.Splits(0).DisplayColumns(9).Width = 115    'OrderType
            Me.grdScanDateAgency.Splits(0).DisplayColumns(10).Width = 60    'FileNo
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "grid_setting_for_ScanDateAgency", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtDateOffline_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDateOffline.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                txtDateOffline.Text = ""
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtDateOffline_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtDateOnline_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDateOnline.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                txtDateOnline.Text = ""
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtDateOnline_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    'Private Sub frmAgencySearch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    Try
    '        grpSearch.SetBounds(grpSearch.Location.X, grpSearch.Location.Y, grpSearch.Width, grpSearch.Height)
    '        grpResult.SetBounds(grpSearch.Location.X, grpSearch.Location.Y + grpSearch.Height, Me.Size.Width - (grpButtons.Width + 90), Me.Size.Height - (grpSearch.Height + 90))
    '        grpButtons.SetBounds(grpSearch.Location.X + grpResult.Width + 10, grpSearch.Location.Y, grpButtons.Width, grpSearch.Height + grpResult.Height)

    '        grdAgency.Width = (grpResult.Width - 10)
    '        grdAgency.Height = (grpResult.Height - 15)

    '    Catch exc As Exception
    '        MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "frmAgencySearch_Resize", exc.GetBaseException)
    '    End Try
    'End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnClose_Click", exc.GetBaseException)
        End Try

    End Sub
    '*********************************************************************************
    'Purpose    : This function converts the XML nodes in form of Data Table
    'Input      : XmlDocument object
    'Output     : DataTable
    '*********************************************************************************
    Private Function getDataTableScan(ByVal objXmlSearchdoc As XmlDocument) As DataTable
        Dim objDR As DataRow
        Dim objDT As New DataTable
        Dim objNode As XmlNode
        Dim objnodelist As XmlNodeList = objXmlSearchdoc.SelectNodes("TA_SEARCHAGENCY_OUTPUT/AGNECY")
        Try
            objDT.Columns.Add("LCODE")
            objDT.Columns.Add("OFFICEID")
            objDT.Columns.Add("NAME")
            objDT.Columns.Add("ADDRESS")
            objDT.Columns.Add("ADDRESS1")
            objDT.Columns.Add("CITY")
            objDT.Columns.Add("COUNTRY")
            objDT.Columns.Add("ONLINESTATUS")

            objDT.Columns.Add("OrderNo")
            objDT.Columns.Add("OrderType")
            objDT.Columns.Add("FileNo")

            objDT.AcceptChanges()
            For Each objNode In objnodelist
                objDR = objDT.NewRow
                objDR("LCODE") = objNode.Attributes("LOCATION_CODE").InnerText
                objDR("OFFICEID") = objNode.Attributes("OfficeID").InnerText
                objDR("NAME") = objNode.Attributes("NAME").InnerText
                objDR("ADDRESS") = objNode.Attributes("ADDRESS").InnerText
                objDR("ADDRESS1") = objNode.Attributes("ADDRESS1").InnerText
                objDR("CITY") = objNode.Attributes("CITY").InnerText
                objDR("COUNTRY") = objNode.Attributes("COUNTRY").InnerText
                objDR("ONLINESTATUS") = objNode.Attributes("ONLINE_STATUS").InnerText
                objDR("OrderNo") = objNode.Attributes("OrderNo").InnerText
                objDR("OrderType") = objNode.Attributes("OrderType").InnerText
                objDR("FileNo") = objNode.Attributes("FileNo").InnerText
                objDT.Rows.Add(objDR)
            Next
            objDT.AcceptChanges()
            objDT.DefaultView.Sort = "LCODE" ' Sort Records According to Location Code
            Return objDT
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "getDataTable", exc.GetBaseException)
        Finally
            objNode = Nothing
        End Try
    End Function
    Private Function getDataTable(ByVal objXmlSearchdoc As XmlDocument) As DataTable
        Dim objDR As DataRow
        Dim objDT As New DataTable
        Dim objNode As XmlNode
        Dim objnodelist As XmlNodeList = objXmlSearchdoc.SelectNodes("TA_SEARCHAGENCY_OUTPUT/AGNECY")
        Try
            objDT.Columns.Add("LCODE")
            objDT.Columns.Add("OFFICEID")
            objDT.Columns.Add("NAME")
            objDT.Columns.Add("ADDRESS")
            objDT.Columns.Add("ADDRESS1")
            objDT.Columns.Add("CITY")
            objDT.Columns.Add("COUNTRY")
            objDT.Columns.Add("ONLINESTATUS")
            objDT.AcceptChanges()
            For Each objNode In objnodelist
                objDR = objDT.NewRow
                objDR("LCODE") = objNode.Attributes("LOCATION_CODE").InnerText
                objDR("OFFICEID") = objNode.Attributes("OfficeID").InnerText
                objDR("NAME") = objNode.Attributes("NAME").InnerText
                objDR("ADDRESS") = objNode.Attributes("ADDRESS").InnerText
                objDR("ADDRESS1") = objNode.Attributes("ADDRESS1").InnerText
                objDR("CITY") = objNode.Attributes("CITY").InnerText
                objDR("COUNTRY") = objNode.Attributes("COUNTRY").InnerText
                objDR("ONLINESTATUS") = objNode.Attributes("ONLINE_STATUS").InnerText
                objDT.Rows.Add(objDR)
            Next
            objDT.AcceptChanges()
            objDT.DefaultView.Sort = "LCODE" ' Sort Records According to Location Code
            Return objDT
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "getDataTable", exc.GetBaseException)
        Finally
            objNode = Nothing
        End Try
    End Function
    Private Sub txtFileNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFileNumber.KeyPress
        Try
            'If Char.IsPunctuation(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsSurrogate(e.KeyChar) Or Char.IsNumber(e.KeyChar) = False Then
            '    e.Handled = True
            'End If


            'If e.KeyChar = Chr(13)  e.KeyChar = Chr(8) Then
            '    Call btnSearch_Click(txtFileNumber, e)
            '     Exit Sub
            'End If

            If e.KeyChar = Chr(8) Then
                Exit Sub
            End If

            If Char.IsPunctuation(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsSurrogate(e.KeyChar) Or Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If

            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtFileNumber, e)
                Exit Sub
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtFileNumber_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtAddress, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtAddress_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtAgencyName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgencyName.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtAgencyName, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtAgencyName_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtDateOffline_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDateOffline.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtDateOffline, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtDateOffline_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtDateOnline_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDateOnline.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtDateOnline, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtDateOnline_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtEmail, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtEmail_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
        Try
            If Char.IsNumber(e.KeyChar) = False Then
                e.Handled = True
            End If

            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtFax, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtFax_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtIATAID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIATAID.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtIATAID, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtIATAID_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtOfficeId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOfficeId.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtOfficeId, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtOfficeId_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtShortName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShortName.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtShortName, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtShortName_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpAgencyStatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpAgencyStatus.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpAgencyStatus, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpAgencyStatus_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpAgencyType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpAgencyType.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpAgencyType, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpAgencyType_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpAoffice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpAoffice.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpAoffice, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpAoffice_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpCity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpCity.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpCity, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpCity_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpCountry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpCountry.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpCountry, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpCountry_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpCRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpCRS.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpCRS, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpCRS_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpOnlineStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpOnlineStatus.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpOnlineStatus.SelectedIndex = -1
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpOnlineStatus_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpOnlineStatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles drpOnlineStatus.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(drpOnlineStatus, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpOnlineStatus_KeyPress", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            AgencyofficeSearch()
            Me.Cursor = Cursors.Arrow
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnSearch_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnModify_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If chkDate.Checked = False And grdAgency.Visible = True Then
             If objSearchedDT.Rows.Count >= 1 Then
                If CType(grdAgency.Item(grdAgency.Row, 0), String) = "" Then       'if use does not select any agency
                    MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    gblLcode = CType(grdAgency.Item(grdAgency.Row, 0), String)
                    Dim objfrmInput As New frmAgencyOffice
                    objfrmInput.WindowState = FormWindowState.Normal
                    objfrmInput.TabOrderReceived.SelectTab(0)
                    Me.Cursor = Cursors.WaitCursor
                    objfrmInput.TabPage1.Show()
                    objfrmInput.ShowDialog()
                End If
               End If
            Else

             If objSearchedDT.Rows.Count >= 1 Then
                If CType(grdScanDateAgency.Item(grdScanDateAgency.Row, 0), String) = "" Then       'if use does not select any agency
                    MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    gblLcode = CType(grdScanDateAgency.Item(grdScanDateAgency.Row, 0), String)
                    Dim objfrmInput As New frmAgencyOffice
                    objfrmInput.WindowState = FormWindowState.Normal
                    objfrmInput.TabOrderReceived.SelectTab(0)
                    Me.Cursor = Cursors.WaitCursor
                    objfrmInput.TabPage1.Show()
                    objfrmInput.ShowDialog()
                End If
              End If
            End If
            Me.Cursor = Cursors.Arrow
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnModify_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub grdAgency_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAgency.DoubleClick
        Try
            If objSearchedDT.Rows.Count >= 1 Then
                'gblLcode = ""
                gblLcode = Nothing
                gblLcode = CType(grdAgency.Item(grdAgency.Row, 0), String)
                Dim objfrmInput As New frmAgencyOffice
                objfrmInput.WindowState = FormWindowState.Normal
                objfrmInput.TabOrderReceived.SelectTab(0)
                objfrmInput.TabPage1.Text = "Agency Details"
                Me.Cursor = Cursors.WaitCursor
                objfrmInput.TabPage1.Show()
                objfrmInput.ShowDialog()
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "grdAgency_DoubleClick", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'grdAgency.ExportToExcel("c:\test.xls")
        Me.Close()
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            ClearControl()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnClear_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub ClearControl()
  Try
        Dim TempXMl As XmlDocument
        Dim TempXM2 As XmlDocument

        If chkDate.Checked = False Then
            TempXMl = New XmlDocument
            TempXMl.LoadXml("<TA_SEARCHAGENCY_OUTPUT><AGNECY LOCATION_CODE='' OfficeID='' NAME='' ADDRESS='' ADDRESS1='' CITY='' COUNTRY='' ONLINE_STATUS='' /><Errors Status=''><Error Code='' Description='' /></Errors></TA_SEARCHAGENCY_OUTPUT>")
        Else
            TempXM2 = New XmlDocument
            TempXM2.LoadXml("<TA_SEARCHAGENCY_OUTPUT><AGNECY LOCATION_CODE='' OfficeID='' NAME='' ADDRESS='' ADDRESS1='' CITY='' COUNTRY='' ONLINE_STATUS='' OrderNo='' OrderType='' FileNo='' /><Errors Status=''><Error Code='' Description='' /></Errors></TA_SEARCHAGENCY_OUTPUT>")
        End If

            txtAgencyName.Text = String.Empty
            txtShortName.Text = String.Empty
            drpCity.SelectedIndex = -1
            drpCountry.SelectedIndex = -1
            drpOnlineStatus.SelectedIndex = -1
            drpAoffice.SelectedIndex = -1
            txtOfficeId.Text = String.Empty
            drpCRS.SelectedIndex = -1
            txtAddress.Text = String.Empty
            drpAgencyStatus.SelectedIndex = -1
            drpAgencyType.SelectedIndex = -1
            txtEmail.Text = String.Empty
            txtDateOffline.Text = String.Empty
            txtDateOnline.Text = String.Empty
            txtFax.Text = String.Empty
            txtFileNumber.Text = String.Empty
            txtIATAID.Text = String.Empty
            txtTo.Text = ""
            txtFrom.Text = ""


            If chkDate.Checked = False Then
                objSearchedDT = getDataTable(TempXMl)
                grdAgency.DataSource = objSearchedDT
                chkDate.Checked = False
            Else
                objSearchedDT = getDataTable(TempXM2)
                grdScanDateAgency.DataSource = objSearchedDT
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "ClearControl", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpAgencyType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpAgencyType.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpAgencyType.SelectedIndex = -1
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpAgencyType_DropDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpAgencyStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpAgencyStatus.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpAgencyStatus.SelectedIndex = -1
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "drpAgencyStatus_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnDateOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateOnline.Click
        'Try
        '    CaleDateOnline.Visible = True
        '    CaleDateOnline.SetBounds(btnDateOnline.Location.X, btnDateOnline.Location.Y, CaleDateOnline.Width, CaleDateOnline.Height)

        'Catch exc As Exception
        '    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
        '    Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnDateOnline_Click", exc.GetBaseException)
        'End Try
        Try
            Dim objDate As New frmDate
            objDate.ShowDialog()
            txtDateOnline.Text = objDate.strDate ' objDate.CalcDate_DateChanged(txtDateOffline, e)
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnDateOnline_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnDateOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateOffline.Click
        Try

            Dim objDate As New frmDate
            objDate.ShowDialog()
            txtDateOffline.Text = objDate.strDate ' objDate.CalcDate_DateChanged(txtDateOffline, e)
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnDateOffline_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnViewMisc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewMisc.Click
        Dim strFileOrder As String = ""
        Dim strAgency As String = ""
        Dim strAddress As String = ""
        Dim strOfficeid As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            ''Get Location Code
            miscFlag = True

         If grdAgency.Visible = True And chkDate.Checked = False Then
            If objSearchedDT.Rows.Count >= 1 Then
                If CType(grdAgency.Item(grdAgency.Row, 0), String) = "" Then       'if use does not select any agency
                    MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    gblLcode = Nothing
                    gblLcode = CType(grdAgency.Item(grdAgency.Row, 0), String)
                    strOfficeid = CType(grdAgency.Item(grdAgency.Row, 1), String)   'Agency Office id
                    gblstrOfficeid = strOfficeid
                    strAgency = CType(grdAgency.Item(grdAgency.Row, 2), String)     'Agency Name
                    strAddress = CType(grdAgency.Item(grdAgency.Row, 3), String)    ' Agency Address
                End If

            Else
                MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If

         Else
                If objSearchedDT.Rows.Count >= 1 Then
                If CType(grdScanDateAgency.Item(grdScanDateAgency.Row, 0), String) = "" Then       'if use does not select any agency
                    MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    gblLcode = Nothing
                    gblLcode = CType(grdScanDateAgency.Item(grdAgency.Row, 0), String)
                    strOfficeid = CType(grdScanDateAgency.Item(grdAgency.Row, 1), String)   'Agency Office id
                    gblstrOfficeid = strOfficeid
                    strAgency = CType(grdScanDateAgency.Item(grdAgency.Row, 2), String)     'Agency Name
                    strAddress = CType(grdScanDateAgency.Item(grdAgency.Row, 3), String)    ' Agency Address
                End If

            Else
                MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If



        End If



            ' call Agency View to get FileNo 
            AgencyView()
            If Len(m_file_no) = 0 Then
                MsgBox("Please Assign A FileNo To This Agency", vbCritical, "AAMS Error")
                Exit Sub
            End If



            Dim objfrmInput As New frmViewDocument
            'objfrmInput.MdiParent = frmMain
            objfrmInput.WindowState = FormWindowState.Normal


            If m_file_no = 0 Then
                objfrmInput.txtFileNo.Text = ""
            Else
                objfrmInput.txtFileNo.Text = m_file_no

            End If

            objfrmInput.txtOfficeId.Text = strOfficeid
            objfrmInput.txtAddress.Text = strAddress
            objfrmInput.txtAgencyName.Text = strAgency

            If m_file_no = 0 Then
                objfrmInput.lblHiddenFileNo.Text = 0
            Else
                objfrmInput.lblHiddenFileNo.Text = m_file_no
            End If

            objfrmInput.lblFlag.Text = "MISC"
            objfrmInput.btnViewAll.Enabled = False




            '' Set All Values into FrmFillings Forms 
            'If Len(m_file_no) <= 0 Or m_file_no = 0 Then
            '   Exit Sub
            'Else

            ' End If
            ''**************************************

            objfrmInput.ShowDialog()

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnViewMisc_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub AgencyView()
        Dim ch As Integer
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency
        Try
            objInputXml.LoadXml("<MS_VIEWAGENCY_INPUT><LOCATION_CODE></LOCATION_CODE></MS_VIEWAGENCY_INPUT>")
            objInputXml.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerXml = gblLcode

            'Here Back end Method Call
            objOutputXml = objbzAgency.View(objInputXml)

            'If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
            '    With objOutputXml.DocumentElement.SelectSingleNode("Agency")
            '        If .Attributes("FILENO").Value().Trim() <> "" Then
            '            m_file_no = .Attributes("FILENO").Value().Trim()
            '            flag = True
            '        Else
            '            flag = False
            '            If miscFlag = True Then Exit Sub
            '                ch = MsgBox("File number does not exist , Do You want to create ? ", MsgBoxStyle.YesNo)
            '                     If ch = 6 Then
            '                         Dim obinputform As New frmAgencyOffice
            '                         obinputform.ShowDialog()
            '                     End If
            '            End If
            '    End With
            'End If


            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                With objOutputXml.DocumentElement.SelectSingleNode("Agency")
                    If .Attributes("FILENO").Value().Trim() <> "" Then
                        m_file_no = .Attributes("FILENO").Value().Trim()
                        flag = True
                    Else
                        m_file_no = 0
                        flag = True
                    End If

                End With
            End If




        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "AgencyView()", exc.GetBaseException)
        Finally
            objInputXml = Nothing
            objOutputXml = Nothing
            objbzAgency = Nothing
        End Try
    End Sub
    Private Sub btnScanMisc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanMisc.Click
        Dim strOrderNumber As String = ""
        Dim strOrderType As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            ''Get Location Code
            If objSearchedDT.Rows.Count >= 1 Then
                If CType(grdAgency.Item(grdAgency.Row, 0), String) = "" Then
                    MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    gblLcode = CType(grdAgency.Item(grdAgency.Row, 0), String)
                    AgencyView()
                End If
                'call Agency View to get FileNo 
            Else
                MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If

            'If Len(m_file_no) = 0 Then
            '    MsgBox("Please Assign A FileNo To " & CType(grdAgency.Item(grdAgency.Row, 2), String), vbCritical, "AAMS Error")
            '    Exit Sub
            'End If

            If flag = False Then
                Exit Sub
            End If

            Dim objfrmInput As New frmFilling
            ' objfrmInput.MdiParent = frmMain
            objfrmInput.WindowState = FormWindowState.Maximized

            '' Set All Values into FrmFillings Forms 

            If m_file_no = 0 Then
                objfrmInput.txtFileNo.Text = ""
            Else
                objfrmInput.txtFileNo.Text = m_file_no
            End If

            objfrmInput.txtOrderType.Text = strOrderType
            ''**************************************

            ''***************************ashish test without scanner*************************
            ChangeAtrib()
            DeleteFiles()
            ''***************************end test without scanner*****************************

            ScanImageToFile() ' Temperory Hide 
            ChangeAtrib()
            Me.Cursor = Cursors.WaitCursor
            objfrmInput.ShowDialog()
            

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnScanMisc_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
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
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "DeleteFiles", exc.GetBaseException)
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
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "ChangeAtrib", exc.GetBaseException)
        End Try
    End Sub
    Private Sub ScanImageToFile()
        Try
            imgFileScan.ScanTo = ScanLibCtl.ScanToConstants.UseFileTemplateOnly
            imgFileScan.FileType = ScanLibCtl.FileTypeConstants.TIFF
            imgFileScan.Image = strFilePath & "\" & "img"
            imgFileScan.MultiPage = True
            imgFileScan.PageCount = 1
            imgFileScan.ShowSetupBeforeScan = True

            ''***************************ashish test without scanner*************************
            imgFileScan.StartScan()
            imgFileScan.UseWaitCursor = True
            imgFileScan.StopScan()
            imgFileScan.CloseScanner()
            ''**************************end test without scanner****************************

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "ScanImageToFile", exc.GetBaseException)
        End Try
    End Sub
    Public Sub btnOrderDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrderDetail.Click
        Dim strAgency As String = ""
        Dim strAddress As String = ""
        Dim strOfficeid As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor

          If chkDate.Checked = False And grdAgency.Visible = True Then
                    If objSearchedDT.Rows.Count >= 1 Then
                        If CType(grdAgency.Item(grdAgency.Row, 0), String) = "" Then       'if use does not select any agency
                            MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                            Exit Sub
                        Else
                            gblLcode = CType(grdAgency.Item(grdAgency.Row, 0), String)
                            strOfficeid = CType(grdAgency.Item(grdAgency.Row, 1), String)   'Agency Office id
                            gblstrOfficeid = strOfficeid
                            strAgency = CType(grdAgency.Item(grdAgency.Row, 2), String)     'Agency Name
                            strAddress = CType(grdAgency.Item(grdAgency.Row, 3), String)    ' Agency Address
                            AgencyView()
                        End If
                    End If
           Else

                  If objSearchedDT.Rows.Count >= 1 Then
                     If CType(grdScanDateAgency.Item(grdAgency.Row, 0), String) = "" Then       'if use does not select any agency
                            MsgBox("Please Select Agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                            Exit Sub
                     Else
                            gblLcode = CType(grdScanDateAgency.Item(grdScanDateAgency.Row, 0), String)
                            strOfficeid = CType(grdScanDateAgency.Item(grdScanDateAgency.Row, 1), String)   'Agency Office id
                            gblstrOfficeid = strOfficeid
                            strAgency = CType(grdScanDateAgency.Item(grdScanDateAgency.Row, 2), String)     'Agency Name
                            strAddress = CType(grdScanDateAgency.Item(grdScanDateAgency.Row, 3), String)    ' Agency Address
                            AgencyView()
                     End If
                 End If
            End If


                If flag = False Then
                    Exit Sub
                End If

                Dim objfrmInput As New frmViewOrder
                objfrmInput.WindowState = FormWindowState.Normal
                objfrmInput.txtOrderAgencyname.Text = strAgency
                objfrmInput.txtOrderAddress.Text = strAddress
                objfrmInput.txtOrderOfficeid.Text = strOfficeid

                If m_file_no = 0 Then
                    objfrmInput.txtOrderFileno.Text = ""
                Else
                    objfrmInput.txtOrderFileno.Text = m_file_no
                End If

                objfrmInput.ShowDialog()
         '   End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnModify_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try

            'OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"
            OpenFileDialog1.Filter = "Select_Pdf_File|*.pdf|Select_jpg File|*.jpg|Select_jpeg|*.jpeg|Select_bmp|*.bmp|Image_Gif|*.gif"

            '****************** New added
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtPdf.Text = OpenFileDialog1.FileName
            Else
                txtPdf.Text = ""
                Exit Sub
            End If

            If IO.Path.GetExtension(OpenFileDialog1.FileName) = ".pdf" Then
                intExetension = 3
            End If

            If IO.Path.GetExtension(OpenFileDialog1.FileName) = ".jpg" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".JPG" Then
                intExetension = 4
            End If

            If IO.Path.GetExtension(OpenFileDialog1.FileName) = ".jpeg" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".JPEG" Then
                intExetension = 4
            End If

            If IO.Path.GetExtension(OpenFileDialog1.FileName) = ".bmp" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".BMP" Then
                intExetension = 4
            End If

            If IO.Path.GetExtension(OpenFileDialog1.FileName) = ".gif" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".GIF" Then
                intExetension = 4
            End If

            ''End new code

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnModify_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        'Input:
        '<TA_UPDATEAGENCYFILENODETAILS_INPUT>
        '<AGENCYFILE ID ='' LCode='' FILENO=''  ORDERNO ='' DOCTYPE ='' SEQUENCE='' ORDERTYPE='' DOCUMENT='' ContentType='' EmailFrom='' EmailTo =''   EmailSubject = '' EmailBody='' PDFDocFileName=''/>
        '</TA_UPDATEAGENCYFILENODETAILS_INPUT>

        'Output:
        '<TA_UPDATEAGENCYFILENODETAILS_OUTPUT>
        '<AGENCYFILE ID='' FILENO='' ORDERNO ='' DOCTYPE ='' SEQUENCE='' ORDERTYPE='' ContentType='' EmailFrom='' EmailTo=''  EmailSubject = '' EmailBody='' NewPDFDocFileName=''/>
        '   <Errors Status=''>
        '       <Error Code='' Description='' />
        '   </Errors>
        '</TA_UPDATEAGENCYFILENODETAILS_OUTPUT>
        Dim strFilePath() As String
        Dim strGetFileName As String
        Dim FinalPath As String
        Dim pdfFilelength As Integer
        Dim objOutputXml, objInputXml As New XmlDocument
        Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency
        Dim objSqlCommand As New SqlCommand
        Dim objSqlConnection As New SqlConnection(bzShared.GetDOCConnectionString)
        Dim objSqlConnection1 As New SqlConnection(bzShared.GetConnectionString)
        Dim cmd As New SqlCommand

        Dim ch As Integer

        Try
            If Trim(txtPdf.Text) = "" Then
                MsgBox("Please select file to upload.", MsgBoxStyle.Critical, "Amadeus Document Management System")
                Exit Sub
            End If


            'If (IO.Path.GetExtension(OpenFileDialog1.FileName) <> ".pdf" Or IO.Path.GetExtension(OpenFileDialog1.FileName) <> ".PDF") Or (IO.Path.GetExtension(OpenFileDialog1.FileName) <> ".jpg" Or IO.Path.GetExtension(OpenFileDialog1.FileName) <> ".JPG") Or (IO.Path.GetExtension(OpenFileDialog1.FileName) <> ".jpeg" Or IO.Path.GetExtension(OpenFileDialog1.FileName) <> ".JPEG") Or (IO.Path.GetExtension(OpenFileDialog1.FileName) <> ".bmp" Or IO.Path.GetExtension(OpenFileDialog1.FileName) <> ".BMP") Then
            '     MsgBox("Invalid Extenstion", MsgBoxStyle.Critical, "Amadeus Document Management System")
            '     Exit Sub
            '  End If

            If intExetension <= 0 Then
                MsgBox("Invalid Extenstion", MsgBoxStyle.Critical, "Amadeus Document Management System")
                Exit Sub
            End If



            If objSearchedDT.Rows.Count = 0 Then
                MsgBox("Unable to upload file .Please select agency ", MsgBoxStyle.Critical)
                txtPdf.Text = ""
                Exit Sub
            ElseIf CType(grdAgency.Item(grdAgency.Row, 0), String) = "" Then       'if use does not select any agency
                MsgBox("Please select agency", MsgBoxStyle.Information, "Amadeus Document Management System")
                txtPdf.Text = ""
                Exit Sub
            Else
                gblLcode = CType(grdAgency.Item(grdAgency.Row, 0), String)
                Call AgencyView()

                ''this comment on date 27-aug-2008
                ''check the flag when agnecy has no file number and want to load PDF
                'If flag = False Then
                '    txtPdf.Text = ""
                '    Exit Sub
                'End If

            End If

            ch = MsgBox("Are you sure to upload the file for agency : " & "'" & UCase(grdAgency.Item(grdAgency.Row, 2)) & "'" & " ", MsgBoxStyle.YesNo, "Amadeus Document Management System")
            Me.Cursor = Cursors.WaitCursor

            If ch = 6 Then
                strFilePath = Split(txtPdf.Text, "\")
                pdfFilelength = strFilePath.Length
                strGetFileName = strFilePath(pdfFilelength - 1)

                With objSqlCommand
                    .Parameters.Add(New SqlParameter("@ACTION", SqlDbType.Char, 1))
                    .Parameters("@ACTION").Value = "I"

                    .Parameters.Add(New SqlParameter("@ID", SqlDbType.Char, 1))
                    .Parameters("@ID").Value = ""

                    ''27-Aug-208 input xml for lcode
                    .Parameters.Add(New SqlParameter("@LCode", SqlDbType.BigInt))
                    .Parameters("@LCode").Value = gblLcode
                    '' end here


                    If m_file_no = 0 Then

                        .Parameters.Add(New SqlParameter("@FILENO", SqlDbType.Int))
                        .Parameters("@FILENO").Value = DBNull.Value

                    Else

                        .Parameters.Add(New SqlParameter("@FILENO", SqlDbType.Int))
                        .Parameters("@FILENO").Value = m_file_no

                    End If

                    .Parameters.Add(New SqlParameter("@ORDERNO", SqlDbType.Char, 40))
                    .Parameters("@ORDERNO").Value = String.Empty

                    .Parameters.Add(New SqlParameter("@DOCTYPE", SqlDbType.Int))
                    .Parameters("@DOCTYPE").Value = 1     ''MISC DOCUMENT

                    .Parameters.Add(New SqlParameter("@SEQUENCE", SqlDbType.Int))
                    .Parameters("@SEQUENCE").Value = 0

                    .Parameters.Add(New SqlParameter("@ORDERTYPE", SqlDbType.Char, 200))
                    .Parameters("@ORDERTYPE").Value = String.Empty

                    .Parameters.Add(New SqlParameter("@DOCUMENT", SqlDbType.Image))
                    .Parameters("@DOCUMENT").Value = DBNull.Value

                    .Parameters.Add(New SqlParameter("@ContentType", SqlDbType.Int))
                    .Parameters("@ContentType").Value = intExetension

                    .Parameters.Add(New SqlParameter("@EmailFrom", SqlDbType.VarChar, 100))
                    .Parameters("@EmailFrom").Value = String.Empty

                    .Parameters.Add(New SqlParameter("@EmailTo", SqlDbType.VarChar, 3000))
                    .Parameters("@EmailTo").Value = String.Empty

                    'EmailSubject
                    .Parameters.Add(New SqlParameter("@EmailSubject", SqlDbType.VarChar, 3000))
                    .Parameters("@EmailSubject").Value = String.Empty

                    .Parameters.Add(New SqlParameter("@EmailBody", SqlDbType.VarChar, 8000))
                    .Parameters("@EmailBody").Value = String.Empty

                    .Parameters.Add(New SqlParameter("@PDFDocFileName", SqlDbType.VarChar, 100))
                    .Parameters("@PDFDocFileName").Value = strGetFileName

                    .Parameters.Add(New SqlParameter("@RETURNID", SqlDbType.Int))
                    .Parameters("@RETURNID").Direction = ParameterDirection.Output
                    .Parameters("@RETURNID").Value = 0

                End With

                objOutputXml = objbzAgency.UpLoadFile(objSqlCommand)
                FinalPath = strPdfFolderName & "\" & objOutputXml.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("NewPDFDocFileName").Value.Trim()
                File.Copy(txtPdf.Text, FinalPath)
                Me.Cursor = Cursors.Default
                MsgBox("File uploaded successfully ", MsgBoxStyle.Information, "Amadeus Document Management System")

                '--- Increase FileNo
                cmd.CommandText = "UP_ALLOCATE_NEW_TA_FILENO"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = objSqlConnection1
                objSqlConnection1.Open()
                cmd.ExecuteNonQuery()
                '--- 

                txtPdf.Text = ""
                strGetFileName = ""
                FinalPath = ""

            Else
                txtPdf.Text = ""
                strGetFileName = ""
                FinalPath = ""
                Exit Sub
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnPdfUpload_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
            cmd.Dispose()
            objSqlConnection.Close()
            objSqlConnection1.Close()
        End Try
    End Sub
    Private Sub grdAgency_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAgency.GotFocus
        Try
            'grdAgency.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "grdAgency_GotFocus", exc.GetBaseException)
        End Try
    End Sub
    Private Sub grdAgency_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAgency.LostFocus
        Try
            'grdAgency.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
            'grdAgency.SelectedRows.Clear()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "grdAgency_LostFocus", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtOrderNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrderNo.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call btnSearch_Click(txtOrderNo.Text, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "txtOrderNo_KeyPress", exc.GetBaseException)
        End Try

    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
       Try

            Dim ch As Integer
            ch = MsgBox("Are you sure to Export data in Excel ? ", MsgBoxStyle.YesNo, "ADMS")
            If ch = 6 Then
                 AgencyofficeSearch()
                 Me.Cursor = Cursors.WaitCursor
                 DatatableToExcel(objSearchedDT)
                 Me.Cursor = Cursors.Arrow
            End If

       Catch exc As Exception
             MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnExport_Click", exc.GetBaseException)
       End Try


            '-------------------------- ALTERNATE WAY-----------------------------
            'Dim objExcel As New Microsoft.Office.Interop.Excel.Application
            'Dim objWorkBook As Microsoft.Office.Interop.Excel.Workbook
            'Dim objWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

            'Dim oXL As Microsoft.Office.Interop.Excel.Application
            'Dim oWB As Microsoft.Office.Interop.Excel.Workbook
            'Dim oSheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim oRange As Microsoft.Office.Interop.Excel.Range

            '' Start Excel and get Application object.
            'oXL = New Microsoft.Office.Interop.Excel.Application

            '' Set some properties
            'oXL.Visible = True
            'oXL.DisplayAlerts = False

            '' Get a new workbook.
            'oWB = oXL.Workbooks.Add

            '' Get the active sheet
            'oSheet = DirectCast(oWB.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
            'oSheet.Name = "Customers"

            '' Process the DataTable
            ''BE SURE TO CHANGE THIS LINE TO USE *YOUR* DATATABLE
            'Dim dt As Data.DataTable = objSearchedDT

            '' Create the data rows
            'Dim rowCount As Integer = 1
            'For Each dr As DataRow In dt.Rows
            '    rowCount += 1
            '    For i As Integer = 1 To dt.Columns.Count
            '        ' Add the header the first time through
            '        If rowCount = 2 Then
            '            oSheet.Cells(1, i) = dt.Columns(i - 1).ColumnName
            '        End If
            '        oSheet.Cells(rowCount, i) = dr.Item(i - 1).ToString
            '    Next
            'Next

            '' Resize the columns
            'oRange = oSheet.Range(oSheet.Cells(1, 1), _
            '          oSheet.Cells(rowCount, dt.Columns.Count))
            'oRange.EntireColumn.AutoFit()

            '' Save the sheet and close
            'oSheet = Nothing
            'oRange = Nothing
            'oWB.SaveAs("test.xls")
            'MsgBox("Completed")
            'oWB.Close()
            'oWB = Nothing
            'oXL.Quit()

            '' Clean up
            '' NOTE: When in release mode, this does the trick
            'GC.WaitForPendingFinalizers()
            'GC.Collect()
            'GC.WaitForPendingFinalizers()
            'GC.Collect()
            '--------------------------------------END---------------------------------------------
End Sub
    Private Sub DatatableToExcel(ByVal dtTemp As DataTable)
        'Dim objExcel As New Microsoft.Office.Interop.Excel.Application

        Dim objExcel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim objWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim objWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Try
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.Filter = "Excel File|*.xls"
            saveFileDialog1.Title = "Save an Excel File"
            If (saveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    If saveFileDialog1.FileName <> "" Then
                        objWorkBook = objExcel.Workbooks.Add()
                        objWorkSheet = objWorkBook.ActiveSheet()
                        Dim dt As System.Data.DataTable = dtTemp
                        Dim dc As System.Data.DataColumn
                        Dim dr As System.Data.DataRow
                        Dim colIndex As Integer = 0
                        Dim rowIndex As Integer = 0
                        Me.Cursor = Cursors.WaitCursor
                            For Each dc In dt.Columns
                                colIndex = colIndex + 1
                                objExcel.Cells(1, colIndex) = dc.ColumnName
                            Next

                            For Each dr In dt.Rows
                                rowIndex = rowIndex + 1
                                colIndex = 0
                                    For Each dc In dt.Columns
                                        colIndex = colIndex + 1
                                        objExcel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                                    Next
                            Next

                        objWorkSheet.Columns.AutoFit()
                        Dim strFileName As String

                        strFileName = saveFileDialog1.FileName
                        If System.IO.File.Exists(strFileName) Then
                            System.IO.File.Delete(strFileName)
                        End If
                        objWorkBook.SaveAs(strFileName)
                        MsgBox("File sucessfully Exported", MsgBoxStyle.Information)
                        objWorkBook.Close()
                        objExcel.Quit()
                        objExcel = Nothing
                        objWorkBook = Nothing
                        objWorkSheet = Nothing
                         '' Clean up
                         '' NOTE: When in release mode, this does the trick
                        GC.WaitForPendingFinalizers()
                        GC.Collect()
                        GC.WaitForPendingFinalizers()
                        GC.Collect()
                  End If
        End If

        Catch exc As Exception
          MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
          Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnExport_Click", exc.GetBaseException)
        Finally
           objExcel = Nothing
           objWorkBook = Nothing
           objWorkSheet = Nothing
          '' Clean up
          '' NOTE: When in release mode, this does the trick
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
       End Try


    End Sub
    Private Sub btnValidFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidFrom.Click
          Try
            Dim objDate As New frmDate
            objDate.StartPosition = FormStartPosition.Manual
            objDate.Location = New Point(110, 255)
            objDate.ShowDialog()
            txtFrom.Text = objDate.strDate
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnValidFrom_Click", exc.GetBaseException)
        End Try
End Sub
    Private Sub btnValidTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidTo.Click
         Try
            Dim objDate As New frmDate
            objDate.StartPosition = FormStartPosition.Manual
            objDate.Location = New Point(450, 255)
            objDate.ShowDialog()
            txtTo.Text = objDate.strDate
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "btnValidTo_Click", exc.GetBaseException)
        End Try
End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        If chkDate.Checked = True Then

            'Dim dt As Date = Format("dd/mmm/yyyy", Date.Now)
            'txtFrom.Text = dt.Day & "/" & dt.Month & "/" & dt.Year
            'txtTo.Text = dt.Day & "/" & dt.Month & "/" & dt.Year
            pnlDate.Visible = True

            Else
            pnlDate.Visible = False

            txtFrom.Text = ""
            txtTo.Text = ""
        End If
End Sub
    Private Sub grdScanDateAgency_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdScanDateAgency.DoubleClick
        Try
            If objSearchedDT.Rows.Count >= 1 Then
                gblLcode = Nothing
                gblLcode = CType(grdScanDateAgency.Item(grdScanDateAgency.Row, 0), String)
                Dim objfrmInput As New frmAgencyOffice
                objfrmInput.WindowState = FormWindowState.Normal
                objfrmInput.TabOrderReceived.SelectTab(0)
                objfrmInput.TabPage1.Text = "Agency Details"
                Me.Cursor = Cursors.WaitCursor
                objfrmInput.TabPage1.Show()
                objfrmInput.ShowDialog()
           End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencySearch", "grdScanDateAgency_DoubleClick", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


End Class