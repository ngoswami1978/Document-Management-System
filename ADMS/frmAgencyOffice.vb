'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmAgencyOffice.vb $
'$Workfile: frmAgencyOffice.vb $
'$Revision: 47 $
'$Archive: /AAMS/Interface/ADMS/frmAgencyOffice.vb $
'$Modtime: 13-06-12 5:27p $
Imports System.Xml
Imports AAMS.bizShared
Public Class frmAgencyOffice
    Dim objtable As New DataTable
    Private Sub frmAgencyOffice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            BindAllControlsExceptFileNo()
            AgencyView()
            AllowControlsReadOnly()
            GetOrderNumber()
            GetOrderDetails()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "frmAgencyOffice_Load", exc.GetBaseException)
        End Try
    End Sub
    Private Sub AllowControlsReadOnly()
        Try
            'txtAgencyGroup.Enabled = False
            'txtAgencyName.Enabled = False
            'txtAddress1.Enabled = False
            'txtAddress2.Enabled = False
            'drpCity.Enabled = False
            'txtPinCode.Enabled = False
            'txtCountry.Enabled = False
            'txtOfficeName.Enabled = False
            'txtEmail.Enabled = False
            'drpAgencyStatus.Enabled = False
            'txtPhone.Enabled = False
            'txtIATAID.Enabled = False
            'txtFax.Enabled = False
            'txtWebSite.Enabled = False
            'txtAoffice.Enabled = False
            'txtAresponsible.Enabled = False
            'drpAgencyType.Enabled = False
            'drpPriority.Enabled = False
            'dtpDateOnline.Enabled = False
            'dtpDateOffLine.Enabled = False
            'txtCCRoster.Enabled = False
            'txtReason.Enabled = False
            'txtPrimaryOnlineStatus.Enabled = False
            'dtpPrimaryInstallDate.Enabled = False
            'txtPrimaryOrderNumber.Enabled = False
            'txtBackupOnlineStatus.Enabled = False
            'dtpBackupInstallationDate.Enabled = False
            'TxtBackupOrderNumber.Enabled = False

            btnDateOnline.Enabled = False
            btnDateOffline.Enabled = False
            btnPrimaryInstallationDate.Enabled = False
            btnBackupInstallationDate.Enabled = False
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "AllowControlsReadOnly", exc.GetBaseException)
        End Try
    End Sub
    Private Function GetBoolScanFileNoStatus(ByVal strFileno As String) As Boolean
        Dim objbzAFileno As New AAMS.bizTravelAgency.bzAgency
        Dim objOutputXml As XmlDocument
        Dim objInputDoc As XmlDocument
        Dim strInput_XML As String = "<UP_GETFINENOSTATUS_INPUT><FILENO/></UP_GETFINENOSTATUS_INPUT >"
        Try
            objInputDoc = New XmlDocument
            objInputDoc.LoadXml(strInput_XML)
            objInputDoc.DocumentElement.SelectSingleNode("FILENO").InnerText = strFileno
            objOutputXml = New XmlDocument
            objOutputXml = objbzAFileno.ScannedFileStatus(objInputDoc)
            GetBoolScanFileNoStatus = False

            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                GetBoolScanFileNoStatus = objOutputXml.DocumentElement.SelectSingleNode("FILESTATUS").Attributes("ScannedFileStatus").Value
            Else
                If objOutputXml.DocumentElement.SelectSingleNode("FILESTATUS").Attributes("ScannedFileStatus").Value <> "TRUE" Then
                    If objOutputXml.DocumentElement.SelectSingleNode("Errors/Error").Attributes("Description").InnerText <> "No Record Found!" Then
                        Throw (New AAMSException(CStr(objOutputXml.DocumentElement.SelectSingleNode("Errors/Error").Attributes("Description").InnerText) & ""))
                    End If
                Else
                    GetBoolScanFileNoStatus = objOutputXml.DocumentElement.SelectSingleNode("FILESTATUS").Attributes("ScannedFileStatus").Value
                End If
                GetBoolScanFileNoStatus = objOutputXml.DocumentElement.SelectSingleNode("FILESTATUS").Attributes("ScannedFileStatus").Value
                End If

        Catch Exec As AAMSException
            'CATCHING AAMS EXCEPTIONS
            'bzShared.FillErrorStatus(objOutputXml, "101", Exec.Message)
            MsgBox(CStr(objOutputXml.DocumentElement.SelectSingleNode("Errors/Error").Attributes("Description").Value), MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "GetBoolScanFileNoStatus", Exec.GetBaseException)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "GetBoolScanFileNoStatus", exc.GetBaseException)

        Finally
            objInputDoc = Nothing
            objOutputXml = Nothing
            objbzAFileno = Nothing
        End Try

    End Function
    Private Sub BindAllControlsExceptFileNo()
        Try
            BindDropDown(drpCity, "CITY", True)
            BindDropDown(drpAgencyType, "ATYPE", True)
            BindDropDown(drpAgencyStatus, "ASTATUS", True)
            BindDropDown(drpPriority, "PRIORITY", True)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "BindControls", exc.GetBaseException)
        End Try
    End Sub
    Private Sub BindFileNoControl(ByVal drpDownList As ComboBox, ByVal strType As String, ByVal bolSelect As Boolean, Optional ByVal strFileno As String = "", Optional ByVal boolFileStatus As Boolean = False)
        Dim objbzAFileno As New AAMS.bizTravelAgency.bzAgency
        Dim objOutputXml As XmlDocument
        Dim objTempOutputXml As New XmlDocument
        Dim objXmlReader As XmlNodeReader
        Dim ds As New DataSet

        Try
            objOutputXml = New XmlDocument
            objOutputXml = objbzAFileno.GetFileNumber()

            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then

                objXmlReader = New XmlNodeReader(objOutputXml)
                ds.ReadXml(objXmlReader)

                '***Assign File No at First Position
                If boolFileStatus = True Or Trim(strFileno) = "" Then
                    Dim dr As DataRow = ds.Tables("FILENUMBER").NewRow
                    dr("FileNo") = strFileno
                    ds.Tables("FILENUMBER").Rows.InsertAt(dr, 0)
                End If
                '***
                If boolFileStatus = False Then
                    Dim dr As DataRow = ds.Tables("FILENUMBER").NewRow
                    dr("FileNo") = strFileno
                    ds.Tables("FILENUMBER").Rows.InsertAt(dr, 0)
                End If

                drpDownList.DataSource = ds.Tables("FILENUMBER")
                drpDownList.DisplayMember = "FileNo"
                drpDownList.ValueMember = "FileNo"
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "BindDropDownForFileNo", exc.GetBaseException)
        End Try
    End Sub
    Private Sub AgencyView()
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency
        Dim m_FileNoStatus As Boolean
        Try
            objInputXml.LoadXml("<MS_VIEWAGENCY_INPUT><LOCATION_CODE></LOCATION_CODE></MS_VIEWAGENCY_INPUT>")
            objInputXml.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerXml = gblLcode

            'Here Back end Method Call
            objOutputXml = objbzAgency.View(objInputXml)
            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                With objOutputXml.DocumentElement.SelectSingleNode("Agency")
                    txtAgencyGroup.Text = .Attributes("Chain_Name").Value()
                    txtAgencyName.Text = .Attributes("NAME").Value()
                    txtAddress1.Text = .Attributes("ADDRESS").Value()
                    txtAddress2.Text = .Attributes("ADDRESS1").Value()
                    drpCity.Text = .Attributes("CITY").Value()
                    txtCountry.Text = .Attributes("COUNTRY").Value()
                    txtEmail.Text = .Attributes("EMAIL").Value()
                    txtPhone.Text = .Attributes("PHONE").Value()
                    txtFax.Text = .Attributes("FAX").Value()
                    txtPinCode.Text = .Attributes("PINCODE").Value()
                    txtOfficeName.Text = .Attributes("CITY").Value()
                    drpAgencyStatus.SelectedValue = .Attributes("AGENCYSTATUSID").Value()
                    txtIATAID.Text = .Attributes("IATA_TID").Value()
                    txtWebSite.Text = .Attributes("WWW_ADDRESS").Value()
                    txtAoffice.Text = .Attributes("Aoffice").Value()
                    drpAgencyType.Text = .Attributes("AGENCYTYPEID").Value()
                    txtReason.Text = .Attributes("INCLUDE_IN_CCR_REASON").Value()
                    txtCCRoster.Text = .Attributes("INCLUDE_IN_CCR").Value()
                    txtAresponsible.Text = .Attributes("RESP_1A_NAME").Value()
                    drpPriority.Text = .Attributes("PRIORITYID").Value()

                    If .Attributes("FILENO").Value().Trim() <> "" Then
                        m_FileNoStatus = GetBoolScanFileNoStatus(.Attributes("FILENO").Value().Trim())

                        BindFileNoControl(drpFileNo, "FileNo", True, CType(.Attributes("FILENO").Value().Trim(), String), m_FileNoStatus)

                        drpFileNo.Text = CType(.Attributes("FILENO").Value().Trim(), String)

                        If m_FileNoStatus = True Then
                            drpFileNo.Enabled = False
                        Else
                            drpFileNo.Enabled = True
                        End If
                    Else
                        BindFileNoControl(drpFileNo, "FileNo", True, CType(.Attributes("FILENO").Value().Trim(), String), m_FileNoStatus)
                    End If

                    If .Attributes("FILENO").Value().Trim() <> "" Then
                        m_file_no = .Attributes("FILENO").Value().Trim()
                    End If

                    txtPrimaryOnlineStatus.Text = .Attributes("ONLINE_STATUS").Value()
                    txtBackupOnlineStatus.Text = .Attributes("ONLINE_STATUS_BACKUP").Value()
                    dtpPrimaryInstallDate.Text = ConvertDateBlank(.Attributes("INSTALL_DATE_PRIMARY").Value())
                    dtpBackupInstallationDate.Text = ConvertDateBlank(.Attributes("INSTALL_DATE_BACKUP").Value())
                    txtPrimaryOrderNumber.Text = .Attributes("ORDERNUMBER_PRIMARY").Value()
                    TxtBackupOrderNumber.Text = .Attributes("ORDERNUMBER_BACKUP").Value()
                    dtpDateOnline.Text = ConvertDateBlank(.Attributes("DATE_ONLINE").Value())
                    dtpDateOffLine.Text = ConvertDateBlank(.Attributes("DATE_OFFLINE").Value())
                End With
            Else
                MsgBox(objOutputXml.DocumentElement.SelectSingleNode("Errors/Error").Attributes("Description").Value)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "AgencyView()", exc.GetBaseException)
        Finally
            objInputXml = Nothing
            objOutputXml = Nothing
            objbzAgency = Nothing
        End Try
    End Sub
    Private Sub GetOrderNumber()
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzOrder As New AAMS.bizTravelAgency.bzOrder
        Try
            objInputXml.LoadXml("<MS_GETORDERS_INPUT><LCODE></LCODE></MS_GETORDERS_INPUT>")
            objInputXml.DocumentElement.SelectSingleNode("LCODE").InnerXml = gblLcode
            'Here Back end Method Call
            objOutputXml = objbzOrder.GetDetails(objInputXml)
            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                With objOutputXml.DocumentElement.SelectSingleNode("ORDERS")
                    strOrderId = .Attributes("ORDERID").Value()
                    strOrderNumber = .Attributes("ORDER_NUMBER").Value()
                End With
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "GetOrderNumber", exc.GetBaseException)
        Finally
            objInputXml = Nothing
            objOutputXml = Nothing
            objbzOrder = Nothing
        End Try
    End Sub
    Private Sub GetOrderDetails()
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzAgency As New AAMS.bizTravelAgency.bzOrder
        Dim objbzOrder As New AAMS.bizTravelAgency.bzOrder
        Dim objRow As DataRow
        Dim objAddNode As XmlNode
        Try
            If Len(strOrderId) >= 1 Then
                objInputXml.LoadXml("<MS_VIEWORDER_INPUT><ORDERID></ORDERID></MS_VIEWORDER_INPUT>")
                objInputXml.DocumentElement.SelectSingleNode("ORDERID").InnerXml = strOrderId

                'Here Back end Method Call
                objOutputXml = objbzAgency.View(objInputXml)
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objtable.Columns.Add("OrderNo", GetType(String))
                    objtable.Columns.Add("Type", GetType(String))
                    objtable.Columns.Add("Status", GetType(String))
                    objtable.Columns.Add("Approval Date", GetType(String))
                    objtable.Columns.Add("Applied Date", GetType(String))
                    objtable.Columns.Add("Agency PC", GetType(String))
                    objtable.Columns.Add("Amadeus PC", GetType(String))
                    objtable.Columns.Add("Amadeus Printer", GetType(String))
                    objtable.Columns.Add("Remarks", GetType(String))
                    objtable.Columns.Add("OfficeId1", GetType(String))
                    objtable.Columns.Add("OfficeId2", GetType(String))
                    objtable.Columns.Add("Pending With Emp", GetType(String))


                    objInputXml.LoadXml("<MS_GETORDERS_INPUT><LCODE></LCODE></MS_GETORDERS_INPUT>")
                    objInputXml.DocumentElement.SelectSingleNode("LCODE").InnerXml = gblLcode

                    'Here Back end Method Call
                    objOutputXml = objbzOrder.GetDetails(objInputXml)
                    If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then

                        For Each objAddNode In objOutputXml.DocumentElement.SelectNodes("ORDERS")

                            objRow = objtable.NewRow
                            With objOutputXml.DocumentElement.SelectSingleNode("ORDERS")
                                objRow("OrderNo") = objAddNode.Attributes("ORDER_NUMBER").Value()
                                objRow("Type") = objAddNode.Attributes("ORDER_TYPE_NAME").Value()
                                objRow("Status") = objAddNode.Attributes("ORDER_STATUS_NAME").Value()
                                objRow("Approval Date") = objAddNode.Attributes("APPROVAL_DATE").Value()
                                objRow("Applied Date") = objAddNode.Attributes("APPLIED_DATE").Value()
                                objRow("Agency PC") = objAddNode.Attributes("OPC").Value()
                                objRow("Amadeus PC") = objAddNode.Attributes("APC").Value()
                                objRow("Amadeus Printer") = objAddNode.Attributes("APR").Value()
                                objRow("Remarks") = objAddNode.Attributes("REMARKS").Value()
                                objRow("OfficeId1") = objAddNode.Attributes("OFFICEID1").Value()
                                objRow("OfficeId2") = objAddNode.Attributes("OFFICEID").Value()
                                objRow("Pending With Emp") = objAddNode.Attributes("PENDINGWITHNAME").Value()
                                objtable.Rows.Add(objRow)
                            End With
                        Next
                        tdbGridOrderReceived.DataSource = objtable
                        Call grid_setting()
                    End If
                End If
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "GetOrderDetails", exc.GetBaseException)
        Finally
            objInputXml = Nothing
            objOutputXml = Nothing
            objbzAgency = Nothing
            strOrderId = Nothing
        End Try
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim objbzAFileno As New AAMS.bizTravelAgency.bzAgency
        Dim objOutputXml As XmlDocument
        Dim objInputDoc As XmlDocument
        'Dim strInput_XML As String = "<UP_UPDATEFILENO_INPUT><FILENO/><LOCATION_CODE/></UP_UPDATEFILENO_INPUT>"
        Dim strInput_XML As String = "<UP_UPDATEFILENO_INPUT><FILENO/><LOCATION_CODE/><STATUS/></UP_UPDATEFILENO_INPUT>"

  Try
            objInputDoc = New XmlDocument
            objInputDoc.LoadXml(strInput_XML)
            If drpFileNo.Text = "" Then
                MsgBox("Select File Number", MsgBoxStyle.Information)
                Exit Sub
            End If

             'MsgBox(drpAgencyStatus.SelectedValue)

            objInputDoc.DocumentElement.SelectSingleNode("FILENO").InnerText = drpFileNo.Text & ""
            objInputDoc.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerText = gblLcode
            objInputDoc.DocumentElement.SelectSingleNode("STATUS").InnerText = drpAgencyStatus.SelectedValue
            objOutputXml = New XmlDocument
            objOutputXml = objbzAFileno.SaveAgencyFileno(objInputDoc)

            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                MsgBox("Record Updated Successfully.", MsgBoxStyle.Information)
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnUpdate_Click FileNo Method", exc.GetBaseException)
        Finally
            objInputDoc = Nothing
            objOutputXml = Nothing
            objbzAFileno = Nothing
        End Try
    End Sub
    Private Sub btnUpdateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateFile.Click
        Dim strOrderNumber As String = ""
        Dim strOrderType As String = ""
        Try
            If objtable.Rows.Count >= 1 Then
                strOrderNumber = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 0), String)
                strOrderType = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 1), String)

                If Len(m_file_no) = 0 Then
                    MsgBox("Please Assign A FileNo To This Agency", vbCritical, "AAMS Error")
                    Exit Sub
                End If
                If strOrderNumber = "" Then
                    MsgBox("Please Select OrderNumber", vbCritical, "AAMS Error")
                    Exit Sub
                End If
            Else
                MsgBox("Please Select Order to Update File", vbCritical, "AAMS Error")
                Exit Sub
            End If

            Dim objfrmInput As New frmUpdateFile
            objfrmInput.WindowState = FormWindowState.Normal

            '' Set All Values into FrmFillings Forms 
            objfrmInput.lstFinalList.SelectedIndex = -1
            objfrmInput.lstRawList.SelectedIndex = -1
            objfrmInput.txtRawOrderNo.Text = strOrderNumber
            ''**************************************

            objfrmInput.ShowDialog()

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnUpdateFile_Click", exc.GetBaseException)
        End Try

    End Sub

    Private Sub btnDateOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateOnline.Click
        Try
            Dim objDate As New frmDate
            objDate.ShowDialog()
            dtpDateOnline.Text = objDate.strDate ' objDate.CalcDate_DateChanged(txtDateOffline, e)
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnDateOnline_Click", exc.GetBaseException)
        End Try
    End Sub

    Private Sub btnDateOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateOffline.Click
        Try
            Dim objDate As New frmDate
            objDate.ShowDialog()
            dtpDateOffLine.Text = objDate.strDate ' objDate.CalcDate_DateChanged(txtDateOffline, e)
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnDateOffline_Click", exc.GetBaseException)
        End Try
    End Sub

    Private Sub btnPrimaryInstallationDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimaryInstallationDate.Click
        Try
            Dim objDate As New frmDate
            objDate.ShowDialog()
            dtpPrimaryInstallDate.Text = objDate.strDate ' objDate.CalcDate_DateChanged(txtDateOffline, e)
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnPrimaryInstallationDate_Click", exc.GetBaseException)
        End Try
    End Sub

    Private Sub btnBackupInstallationDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackupInstallationDate.Click
        Try
            Dim objDate As New frmDate
            objDate.ShowDialog()
            dtpBackupInstallationDate.Text = objDate.strDate ' objDate.CalcDate_DateChanged(txtDateOffline, e)
            objDate.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnBackupInstallationDate_Click", exc.GetBaseException)
        End Try
    End Sub

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        Dim strOrderNumber As String = ""
        Dim strOrderType As String = ""

        Try
            If objtable.Rows.Count >= 1 Then
                strOrderNumber = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 0), String)
                strOrderType = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 1), String)

                If Len(m_file_no) = 0 Then
                    MsgBox("Please Assign A FileNo To This Agency", vbCritical, "AAMS Error")
                    Exit Sub
                End If
                If strOrderNumber = "" Then
                    MsgBox("Please Select OrderNumber", vbCritical, "AAMS Error")
                    Exit Sub
                End If
            Else
                MsgBox("Please Select Order to Scan", vbCritical, "AAMS Error")
            End If


            Me.Cursor = Cursors.WaitCursor

            Dim objfrmInput As New frmFilling
            objfrmInput.MdiParent = frmMain
            objfrmInput.WindowState = FormWindowState.Maximized

            '' Set All Values into FrmFillings Forms 
            objfrmInput.txtFileNo.Text = m_file_no
            objfrmInput.txtOrderNumber.Text = strOrderNumber
            objfrmInput.txtOrderType.Text = strOrderType
            ''**************************************

            ChangeAtrib()
            ScanImageToFile() ' Temperory Hide 
            ChangeAtrib()

            objfrmInput.Show()
            Me.Cursor = Cursors.Default

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnScan_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub ChangeAtrib()
        Try
            If FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes And 1 Then
                FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes = FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes - 1
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "ChangeAtrib", exc.GetBaseException)
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
            imgFileScan.StartScan()

            imgFileScan.UseWaitCursor = True
            imgFileScan.StopScan()
            imgFileScan.CloseScanner()

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "ScanImageToFile", exc.GetBaseException)
        End Try
    End Sub

    Private Sub btnMiscScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strOrderNumber As String = ""
        Dim strOrderType As String = ""

        Try
            If objtable.Rows.Count >= 1 Then
                strOrderNumber = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 0), String)
                strOrderType = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 1), String)

                If Len(m_file_no) = 0 Then
                    MsgBox("Please Assign A FileNo To This Agency", vbCritical, "AAMS Error")
                    Exit Sub
                End If
            Else
                MsgBox("Please Select Order to Scan", vbCritical, "AAMS Error")
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim objfrmInput As New frmFilling
            objfrmInput.MdiParent = frmMain
            objfrmInput.WindowState = FormWindowState.Maximized

            '' Set All Values into FrmFillings Forms 
            objfrmInput.txtFileNo.Text = m_file_no
            objfrmInput.txtOrderType.Text = strOrderType
            ''**************************************

            ChangeAtrib()
            ScanImageToFile() ' Temperory Hide 
            ChangeAtrib()

            objfrmInput.Show()
            Me.Cursor = Cursors.Default
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnMiscScan_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnViewDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDoc.Click
        Dim strOrderNumber As String = ""
        Dim strOrderType As String = ""
        Dim strFileOrder As String = ""

        Try
            If objtable.Rows.Count >= 1 Then
                strOrderNumber = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 0), String)
                strOrderType = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 1), String)


                If Len(m_file_no) = 0 Then
                    MsgBox("Please Assign A FileNo To This Agency", vbCritical, "AAMS Error")
                    Exit Sub
                End If
                If strOrderNumber = "" Then
                    MsgBox("Please Select OrderNumber", vbCritical, "AAMS Error")
                    Exit Sub
                End If
            Else
                MsgBox("Please Select Order to View Document", vbCritical, "AAMS Error")
                Exit Sub
            End If

            Dim objfrmInput As New frmViewDocument
            'objfrmInput.MdiParent = frmMain
            objfrmInput.WindowState = FormWindowState.Maximized

            '' Set All Values into FrmFillings Forms 
            objfrmInput.txtAgencyName.Text = txtOrderAgencyname.Text
            objfrmInput.txtAddress.Text = txtOrderAddress.Text
            objfrmInput.txtOfficeId.Text = txtOrderOfficeid.Text

            objfrmInput.txtFileNo.Text = m_file_no
            objfrmInput.txtOrderNumber.Text = strOrderNumber
            objfrmInput.txtOrderType.Text = strOrderType

            ''**************************************
            objfrmInput.lblHiddenFileNo.Text = m_file_no
            objfrmInput.lblFlag.Text = "VD"
            objfrmInput.ShowDialog()

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnViewDoc_Click", exc.GetBaseException)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Close()

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnClose_Click", exc.GetBaseException)
        End Try

    End Sub

    Private Sub btnClose1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Close()
            'Dim strOrderType As String = ""
            'Dim strFileOrder As String = ""

            'Try
            '    If objtable.Rows.Count >= 1 Then
            '        strOrderNumber = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 0), String)
            '        strOrderType = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 1), String)

            '        If Len(m_file_no) = 0 Then
            '            MsgBox("Please Assign A FileNo To This Agency", vbCritical, "AAMS Error")
            '            Exit Sub
            '        End If
            '        If strOrderNumber = "" Then
            '            MsgBox("Please Select OrderNumber", vbCritical, "AAMS Error")
            '            Exit Sub
            '        End If
            '    Else
            '        MsgBox("Please Select Order to View Document", vbCritical, "AAMS Error")
            '        Exit Sub
            '    End If

            '    Dim objfrmInput As New frmViewDocument
            '    objfrmInput.MdiParent = frmMain
            '    objfrmInput.WindowState = FormWindowState.Maximized

            '    '' Set All Values into FrmFillings Forms 
            '    If Len(m_file_no) <= 0 Or m_file_no = 0 Then
            '        objfrmInput.txtFileNo.Text = m_file_no
            '        Exit Sub
            '    End If
            '    ''**************************************

            '    objfrmInput.lblHiddenFileNo.Text = m_file_no
            '    objfrmInput.lblFlag.Text = "MISC"
            '    objfrmInput.Show()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "btnClose1_Click", exc.GetBaseException)
        End Try
    End Sub

    Private Sub grid_setting()
        Try
            tdbGridOrderReceived.Splits(0).DisplayColumns(0).Width = 60     'orderno
            tdbGridOrderReceived.Splits(0).DisplayColumns(1).Width = 95    'type
            tdbGridOrderReceived.Splits(0).DisplayColumns(2).Width = 60     'status
            tdbGridOrderReceived.Splits(0).DisplayColumns(3).Width = 78     'approval Date
            tdbGridOrderReceived.Splits(0).DisplayColumns(4).Width = 72     'applied adte
            tdbGridOrderReceived.Splits(0).DisplayColumns(5).Width = 68     'Agency PC
            tdbGridOrderReceived.Splits(0).DisplayColumns(6).Width = 69     'Amadeus PC
            tdbGridOrderReceived.Splits(0).DisplayColumns(7).Width = 90   'Amadeus Printer
            tdbGridOrderReceived.Splits(0).DisplayColumns(8).Width = 150    'Remarks
            tdbGridOrderReceived.Splits(0).DisplayColumns(9).Width = 60    'OfficeID1
            tdbGridOrderReceived.Splits(0).DisplayColumns(10).Width = 60    'OfficeID2
            tdbGridOrderReceived.Splits(0).DisplayColumns(11).Width = 60    'Pending with EMp

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "frmAgencyOffice", exc.GetBaseException)
        End Try
    End Sub
 Private Sub drpAgencyStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles drpAgencyStatus.KeyDown
        Try
            If e.KeyCode = 46 Then 'Delete
                drpAgencyStatus.SelectedIndex = -1
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmAgencyOffice", "frmAgencyOffice", exc.GetBaseException)
        End Try
    End Sub

End Class