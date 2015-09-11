'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Neeraj $Logfile: /AAMS/Interface/ADMS/frmUpdateFile.vb $
'$Workfile: frmUpdateFile.vb $
'$Revision: 57 $
'$Archive: /AAMS/Interface/ADMS/frmUpdateFile.vb $
'$Modtime: 3/01/09 12:59p $
Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Public Class frmUpdateFile
    Dim m_objdsSelect As New DataSet
    Dim m_objdsFinal As New DataSet
    Dim ds As New DataSet
    Dim strRawOrderNo As String
    Dim boolFindOrderType As Boolean
    Dim StrCheck As Boolean

    Private Sub frmUpdateFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            lstFinalList.SelectedIndex = -1
            lstRawList.SelectedIndex = -1
            BindAllControls()

            If Len(m_file_no) > 0 Then
                drpRawFileNo.Items.Add(m_file_no)
                drpRawFileNo.SelectedItem = m_file_no
            Else
                Exit Sub
            End If
            If Len(strRawOrderNo) > 0 Then
                txtRawOrderNo.Text = strRawOrderNo
            Else
                Exit Sub
            End If


            If Len(strOrderType) > 0 Then
                Exit Sub
            Else
                If lstRawList.Items.Count = 0 Then
                    btnMoveRight.Enabled = False
                    btnMoveLeft.Enabled = False
                Else
                    btnMoveRight.Enabled = True
                    btnMoveLeft.Enabled = True
                End If
                Exit Sub
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "frmUpdateFile_Load", exc.GetBaseException)
        End Try
    End Sub
    Private Sub BindAllControls()
        Try
            BindDropDown(drpFileNo, "FileNoTCFilling", True)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFiles", "BindControls", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnMoveRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveRight.Click
        Dim objDR As DataRow
        Try
            If lstRawList.Items.Count = 0 Then Exit Sub
            objDR = m_objdsFinal.Tables("DETAILS").NewRow
            objDR("Id") = lstRawList.SelectedValue
            objDR("FILEORDER") = m_objdsSelect.Tables("DETAILS").Rows(lstRawList.SelectedIndex)("FILEORDER") & ""
            objDR("FILENO") = drpFileNo.Text & ""       'm_objdsSelect.Tables("DETAILS").Rows(lstRawList.SelectedIndex)("FILENO") & ""
            objDR("ORDER_NO") = drpOrderNo.Text & ""    'm_objdsSelect.Tables("DETAILS").Rows(lstRawList.SelectedIndex)("ORDER_NO") & ""
            objDR("DOCTYPE") = m_objdsSelect.Tables("DETAILS").Rows(lstRawList.SelectedIndex)("DOCTYPE") & ""
            objDR("ORDER_TYPE") = drpOrderType.Text & "" 'm_objdsSelect.Tables("DETAILS").Rows(lstRawList.SelectedIndex)("ORDER_TYPE") & ""

           If m_objdsFinal.Tables("DETAILS").Rows.Count = 0 Then
                objDR("FILEORDER") = 1           'CType(m_objdsFinal.Tables("DETAILS").Compute(CStr("Max(fileorder)"), ""), Integer) + 1
            Else
            objDR("FILEORDER") = CType(m_objdsFinal.Tables("DETAILS").Compute(CStr("Max(fileorder)"), ""), Integer) + 1
           End If

            objDR("TEMPFILENO") = m_objdsSelect.Tables("DETAILS").Rows(lstRawList.SelectedIndex)("FILENO") & ""
            objDR("TEMPORDER_NO") = m_objdsSelect.Tables("DETAILS").Rows(lstRawList.SelectedIndex)("ORDER_NO") & ""
            objDR("TEMPORDER_TYPE") = m_objdsSelect.Tables("DETAILS").Rows(lstRawList.SelectedIndex)("ORDER_TYPE") & ""


            objDR("ContentType") = 1
            m_objdsFinal.Tables("DETAILS").Rows.InsertAt(objDR, m_objdsFinal.Tables("DETAILS").Rows.Count)
            m_objdsSelect.Tables("DETAILS").Rows.RemoveAt(lstRawList.SelectedIndex)
            m_objdsSelect.Tables("DETAILS").AcceptChanges()
            m_objdsFinal.Tables("DETAILS").AcceptChanges()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFiles", "btnMoveRight_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnMoveLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveLeft.Click
        Dim objDR As DataRow
        Try

            If lstFinalList.Items.Count = 0 Then Exit Sub

            objDR = m_objdsSelect.Tables("DETAILS").NewRow
            objDR("Id") = lstFinalList.SelectedValue
            objDR("FILEORDER") = m_objdsFinal.Tables("DETAILS").Rows(lstFinalList.SelectedIndex)("FILEORDER") & ""
            objDR("DOCTYPE") = m_objdsFinal.Tables("DETAILS").Rows(lstFinalList.SelectedIndex)("DOCTYPE") & ""

            If Trim(m_objdsFinal.Tables("DETAILS").Rows(lstFinalList.SelectedIndex)("TEMPFILENO") & "") <> "" Then
                objDR("FILENO") = m_objdsFinal.Tables("DETAILS").Rows(lstFinalList.SelectedIndex)("TEMPFILENO") & ""
            End If
            If Trim(m_objdsFinal.Tables("DETAILS").Rows(lstFinalList.SelectedIndex)("TEMPORDER_NO") & "") <> "" Then
                objDR("ORDER_NO") = m_objdsFinal.Tables("DETAILS").Rows(lstFinalList.SelectedIndex)("TEMPORDER_NO") & ""
            End If
            If Trim(m_objdsFinal.Tables("DETAILS").Rows(lstFinalList.SelectedIndex)("TEMPORDER_TYPE") & "") <> "" Then
                objDR("ORDER_TYPE") = m_objdsFinal.Tables("DETAILS").Rows(lstFinalList.SelectedIndex)("TEMPORDER_TYPE") & ""
            End If

            m_objdsSelect.Tables("DETAILS").Rows.InsertAt(objDR, m_objdsSelect.Tables("DETAILS").Rows.Count)
            m_objdsFinal.Tables("DETAILS").Rows.RemoveAt(lstFinalList.SelectedIndex)
            m_objdsSelect.Tables("DETAILS").AcceptChanges()
            m_objdsFinal.Tables("DETAILS").AcceptChanges()

 Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFiles", "btnMoveLeft_Click", exc.GetBaseException)
        End Try
    End Sub
     Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Dim bztaOrderDoc As New AAMS.bizTravelAgency.bzOrder
            Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency
            Dim xInput, xOutput As New XmlDocument
            Dim strPageNo As String
            Dim frmviewDoc As New frmViewDocument
            Dim objfrmViewOrder As New frmViewOrder
            Dim m_objdsSelect As New DataSet
            Dim m_objdsFinal As New DataSet
            Dim dSet As New DataSet
            Dim strContentType As String
            Dim strNewFileName As String
            Dim strFinalPath As String
            Dim objInputXml, objOutputXml As New XmlDocument
            Dim objSearchAgency As New frmAgencySearch
            Me.Cursor = Cursors.WaitCursor

            xInput.LoadXml("<TA_GETSCANNEDDOCUMENT_INPUT><LCode></LCode><FileNo></FileNo><Order_No></Order_No></TA_GETSCANNEDDOCUMENT_INPUT>")
            If lstRawList.SelectedIndex = -1 And lstFinalList.SelectedIndex = -1 Then
                MsgBox("Select Any Page Number")
                Exit Sub
            End If


            xInput.DocumentElement.SelectSingleNode("LCode").InnerText = gblLcode

            If lstRawList.SelectedIndex >= 0 Then
                xInput.DocumentElement.SelectSingleNode("FileNo").InnerText = drpRawFileNo.Text.Trim()
                strPageNo = lstRawList.Text.Trim()
            ElseIf lstFinalList.SelectedIndex >= 0 Then
                xInput.DocumentElement.SelectSingleNode("FileNo").InnerText = drpFileNo.Text.Trim() 'drpfi.Text.Trim()
                strPageNo = lstFinalList.Text.Trim()

            Else
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            xOutput = bztaOrderDoc.GetScannedDocument(xInput)
            frmviewDoc.btnPrev.Enabled = False
            frmviewDoc.btnNext.Enabled = False
            frmviewDoc.btnViewAll.Enabled = False

            If xOutput.DocumentElement.SelectSingleNode("Document").Attributes("ID").Value().Trim() = "" Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Amadeus Document Management System")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If xOutput.DocumentElement.SelectSingleNode("Document").Attributes("FileNo").Value().Trim() = "" Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Amadeus Document Management System")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If xOutput.DocumentElement.SelectSingleNode("Document").Attributes("Order_No").Value().Trim() = "" Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Amadeus Document Management System")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If xOutput.DocumentElement.SelectSingleNode("Document").Attributes("Order_Type").Value().Trim() = "" Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Amadeus Document Management System")
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            frmviewDoc.txtFileNo.Text = xOutput.DocumentElement.SelectSingleNode("Document[@FileOrder='" & strPageNo & "']").Attributes("FileNo").Value
            frmviewDoc.txtOrderNumber.Text = xOutput.DocumentElement.SelectSingleNode("Document[@FileOrder='" & strPageNo & "']").Attributes("Order_No").Value
            frmviewDoc.txtOrderType.Text = xOutput.DocumentElement.SelectSingleNode("Document[@FileOrder='" & strPageNo & "']").Attributes("Order_Type").Value
            frmviewDoc.txtSequenceNo.Text = strPageNo
            frmviewDoc.txtOfficeId.Text = gblstrOfficeid

            Dim strID As String = xOutput.DocumentElement.SelectSingleNode("Document[@FileOrder='" & strPageNo & "']").Attributes("ID").Value
            If strID = "" Then Exit Sub
            strContentType = xOutput.DocumentElement.SelectSingleNode("Document[@ID='" & strID & "']").Attributes("ContentType").Value
            strNewFileName = xOutput.DocumentElement.SelectSingleNode("Document[@ID='" & strID & "']").Attributes("PDFDocFileName").Value


            'FOR IMAGE RETRIEVING FROM DOCUMENT
            xInput.LoadXml("<TA_GETSCANNEDIMAGE_INPUT><ID></ID></TA_GETSCANNEDIMAGE_INPUT>")
            xInput.DocumentElement.SelectSingleNode("ID").InnerText = strID

            dSet = bztaOrderDoc.GetScannedImage(xInput)
            If strContentType = "1" Then

                If dSet.Tables(0).Rows.Count > 0 Then
                    Dim ImageBytes() As Byte = dSet.Tables(0).Rows(0)(1)
                    Dim mStream As New MemoryStream(ImageBytes)
                    Dim imgTest As Image = Image.FromStream(mStream)
                    Dim imgPath As String = strFilePath & "\" & strID & ".tif"
                    imgTest.Save(imgPath)

                    frmviewDoc.HideEmail()
                    frmviewDoc.AxPdf.Visible = False
                    frmviewDoc.PictureBox1.Visible = False
                    frmviewDoc.AxImgEdit1.Image = imgPath
                    frmviewDoc.AxImgEdit1.Visible = True
                    frmviewDoc.EnableButtonTrue()
                    frmviewDoc.btnPrint.Enabled = True

                    objInputXml.LoadXml("<MS_VIEWAGENCY_INPUT><LOCATION_CODE></LOCATION_CODE></MS_VIEWAGENCY_INPUT>")
                    objInputXml.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerXml = gblLcode
                    objOutputXml = objbzAgency.View(objInputXml)
                    frmviewDoc.txtAgencyName.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("NAME").Value().Trim()
                    frmviewDoc.txtAddress.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("ADDRESS").Value().Trim()
                    frmviewDoc.AxImgEdit1.Display()
                    frmviewDoc.Show()
                Else
                    frmviewDoc.AxImgEdit1.Image = Nothing
                    frmviewDoc.AxImgEdit1.Display()
                End If

            ElseIf strContentType = "2" Then
                frmviewDoc.AxImgEdit1.Visible = False
                frmviewDoc.AxPdf.Visible = False
                frmviewDoc.PictureBox1.Visible = False
                frmviewDoc.EnableButtonFalse()
                frmviewDoc.VisibleEmail()
                frmviewDoc.btnPrint.Enabled = True

                frmviewDoc.txtFileNo.Text = xOutput.DocumentElement.SelectSingleNode("Document[@ID='" & strID & "']").Attributes("FileNo").Value
                frmviewDoc.txtMailTo.Text = xOutput.DocumentElement.SelectSingleNode("Document[@ID='" & strID & "']").Attributes("EmailTo").Value
                frmviewDoc.txtMailFrom.Text = xOutput.DocumentElement.SelectSingleNode("Document[@ID='" & strID & "']").Attributes("EmailFrom").Value
                frmviewDoc.WebBrowser1.DocumentText = xOutput.DocumentElement.SelectSingleNode("Document[@ID='" & strID & "']").Attributes("EmailBody").Value
                frmviewDoc.txtMailSub.Text = xOutput.DocumentElement.SelectSingleNode("Document[@ID='" & strID & "']").Attributes("EmailSubject").Value

                frmviewDoc.btnZoomIN.Enabled = False
                frmviewDoc.btnZoomOut.Enabled = False
                frmviewDoc.btnFitPage.Enabled = False
                frmviewDoc.btnNext.Enabled = False
                frmviewDoc.btnPrint.Enabled = False
                frmviewDoc.btnViewAll.Enabled = False

                objInputXml.LoadXml("<MS_VIEWAGENCY_INPUT><LOCATION_CODE></LOCATION_CODE></MS_VIEWAGENCY_INPUT>")
                objInputXml.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerXml = gblLcode
                objOutputXml = objbzAgency.View(objInputXml)
                frmviewDoc.txtAgencyName.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("NAME").Value().Trim()
                frmviewDoc.txtAddress.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("ADDRESS").Value().Trim()
                frmviewDoc.EnableButtonFalse()
                frmviewDoc.btnPrint.Enabled = True
                frmviewDoc.ShowDialog()


            ElseIf strContentType = "3" Then
                strNewFileName = strNewFileName & ".pdf"
                strFinalPath = strPdfFolderName & "\" & strNewFileName
                frmviewDoc.HideEmail()
                frmviewDoc.AxImgEdit1.Visible = False
                frmviewDoc.PictureBox1.Visible = False
                frmviewDoc.EnableButtonFalse()
                frmviewDoc.AxPdf.LoadFile(strFinalPath)
                frmviewDoc.AxPdf.Show()
                frmviewDoc.AxPdf.Visible = True
                frmviewDoc.btnZoomIN.Enabled = False
                frmviewDoc.btnZoomOut.Enabled = False
                frmviewDoc.btnFitPage.Enabled = False
                frmviewDoc.btnNext.Enabled = False
                frmviewDoc.btnPrint.Enabled = False
                frmviewDoc.btnViewAll.Enabled = False

                objInputXml.LoadXml("<MS_VIEWAGENCY_INPUT><LOCATION_CODE></LOCATION_CODE></MS_VIEWAGENCY_INPUT>")
                objInputXml.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerXml = gblLcode
                objOutputXml = objbzAgency.View(objInputXml)
                frmviewDoc.txtAgencyName.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("NAME").Value().Trim()
                frmviewDoc.txtAddress.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("ADDRESS").Value().Trim()
                frmviewDoc.EnableButtonFalse()
                frmviewDoc.btnPrint.Enabled = False
                frmviewDoc.ShowDialog()

            ElseIf strContentType = "4" Then
                strNewFileName = strNewFileName & ".jpg"
                strFinalPath = strPdfFolderName & "\" & strNewFileName

                frmviewDoc.HideEmail()
                frmviewDoc.AxImgEdit1.Visible = False
                frmviewDoc.AxPdf.Visible = False
                frmviewDoc.EnableButtonFalse()

                frmviewDoc.PictureBox1.ImageLocation = strFinalPath

                objInputXml.LoadXml("<MS_VIEWAGENCY_INPUT><LOCATION_CODE></LOCATION_CODE></MS_VIEWAGENCY_INPUT>")
                objInputXml.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerXml = gblLcode
                objOutputXml = objbzAgency.View(objInputXml)
                frmviewDoc.txtAgencyName.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("NAME").Value().Trim()
                frmviewDoc.txtAddress.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("ADDRESS").Value().Trim()

                frmviewDoc.PictureBox1.Visible = True
                frmviewDoc.btnPrint.Enabled = True
                frmviewDoc.ShowDialog()
            End If

            Me.Cursor = Cursors.Arrow

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFiles", "btnPreview_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub agencyDetails()
        ' Dim ob As New frmViewOrder
        Try
            Dim frmviewDoc As New frmViewDocument
            Dim objInputXml, objOutputXml As New XmlDocument
            Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency
            objInputXml.LoadXml("<MS_VIEWAGENCY_INPUT><LOCATION_CODE></LOCATION_CODE></MS_VIEWAGENCY_INPUT>")
            objInputXml.DocumentElement.SelectSingleNode("LOCATION_CODE").InnerXml = gblLcode
            objOutputXml = objbzAgency.View(objInputXml)
            frmViewDocument.txtAgencyName.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("NAME").Value().Trim()
            frmViewDocument.txtAddress.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("ADDRESS").Value().Trim()
            'frmviewDoc.txtOfficeId.Text = objOutputXml.DocumentElement.SelectSingleNode("Agency").Attributes("FILENO").Value().Trim()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFiles", "agencyDetails", exc.GetBaseException)
        End Try

    End Sub
    Private Sub drpRawFileNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpRawFileNo.SelectedIndexChanged
        '***********************************************************************
        'Purpose:This function gives details Scanned Document
        'Input  :
        '<TA_GETAGENCYFILENODETAILS_INPUT>
        '   <FILENO/>    
        '</TA_GETAGENCYFILENODETAILS_INPUT>

        'Output :
        '<TA_GETAGENCYFILENODETAILS_OUTPUT>
        '     <DETAILS ID="" DOCTYPE="" FILENO="" FILEORDER="" ORDER_NO="" ORDER_TYPE=""></DETAILS>
        '</TA_GETAGENCYFILENODETAILS_OUTPUT>
        '************************************************************************
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency
        Dim objXMLNodeReader As XmlNodeReader
        Dim objXmlNode As XmlNode
        Dim i As Integer = 1

        Try
            objInputXml.LoadXml("<TA_GETAGENCYFILENODETAILS_INPUT><FILENO></FILENO></TA_GETAGENCYFILENODETAILS_INPUT>")
            objInputXml.DocumentElement.SelectSingleNode("FILENO").InnerXml = drpRawFileNo.Text
            objOutputXml = objbzAgency.GetFileNoDetailsForDoc(objInputXml)
            strRawOrderNo = txtRawOrderNo.Text

            ''Filter the Xml by Xpath
            If objOutputXml.DocumentElement.SelectNodes("DETAILS[@ORDER_NO='" & strRawOrderNo & "']").Count = 0 Then
                'MsgBox("Record Not Found..")
                Exit Sub
            End If

            For Each objXmlNode In objOutputXml.DocumentElement.SelectNodes("DETAILS")
                If Not objXmlNode.Attributes("ORDER_NO").InnerText = strRawOrderNo Then
                    objOutputXml.DocumentElement.RemoveChild(objXmlNode)
                Else
                    boolFindOrderType = SearchOrderType(Me.drpRawOrderType, objXmlNode.Attributes("ORDER_TYPE").InnerText)
                    If boolFindOrderType = False Then
                        drpRawOrderType.Items.Add(objXmlNode.Attributes("ORDER_TYPE").InnerText)
                    End If
                End If
            Next

            If drpRawOrderType.Items.Count > 0 Then
                drpRawOrderType.SelectedIndex = 0
            End If

            m_objdsSelect.Clear()
            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                objXMLNodeReader = New XmlNodeReader(objOutputXml)
                m_objdsSelect.ReadXml(objXMLNodeReader)
                lstRawList.DataSource = m_objdsSelect.Tables("DETAILS").DefaultView
                lstRawList.DisplayMember = "FILEORDER"
                lstRawList.ValueMember = "Id"
            Else
                MsgBox(objOutputXml.DocumentElement.SelectSingleNode("Errors/Error").Attributes("Description").Value)
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "drpRawFileNo_SelectedIndexChanged", exc.GetBaseException)
        Finally
            objInputXml = Nothing
            objOutputXml = Nothing
            objbzAgency = Nothing
        End Try
    End Sub
    Private Function SearchOrderType(ByVal drpControl As ComboBox, ByVal strOrderType As String) As Boolean
        Dim X As Integer
        Try
            If drpControl.Items.Count >= 1 Then
                For X = 0 To drpControl.Items.Count - 1
                    If drpControl.Items.Item(X) = strOrderType Then
                        Return True
                        Exit Function
                    End If
                Next
            End If

            Return False
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "drpRawFileNo_SelectedIndexChanged", exc.GetBaseException)
        End Try

    End Function
    Private Sub drpFileNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpFileNo.SelectedIndexChanged
        '***********************************************************************
        'Purpose:This function gives details Scanned Document
        'Input  :
        '<TA_GETAGENCYFILENODETAILS_INPUT>
        '   <FILENO/>    
        '</TA_GETAGENCYFILENODETAILS_INPUT>

        'Output :
        '<TA_GETAGENCYFILENODETAILS_OUTPUT>
        '     <DETAILS ID="" DOCTYPE="" FILENO="" FILEORDER="" ORDER_NO="" ORDER_TYPE=""></DETAILS>
        '</TA_GETAGENCYFILENODETAILS_OUTPUT>
        '************************************************************************

        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency
        Dim objXMLNodeReader As XmlNodeReader
        Dim objXMLReader As XmlNodeReader
        Dim dview As New DataView
        Dim dSet As New DataSet
        Dim objXmlNode As XmlNode
        Dim strFinalOrderNo As String
        Dim i As Integer = 1

        drpOrderType.Items.Clear()
        Try
            objInputXml.LoadXml("<TA_GETAGENCYFILENODETAILS_INPUT><FILENO></FILENO></TA_GETAGENCYFILENODETAILS_INPUT>")
            If (drpFileNo.SelectedIndex >= 0) Then
                objInputXml.DocumentElement.SelectSingleNode("FILENO").InnerXml = drpFileNo.SelectedValue
                objOutputXml = objbzAgency.GetFileNoDetailsForDoc(objInputXml)

                'code to fill combo
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXMLReader = New XmlNodeReader(objOutputXml)
                    dSet.ReadXml(objXMLReader)
                    dview = dSet.Tables("DETAILS").DefaultView
                    dview.RowFilter = "ORDER_NO<>''"
                    Dim distinct() As String = {"ORDER_NO"}
                    Dim dTable As New DataTable
                    dTable = dview.ToTable(True, distinct)
                    dview = dTable.DefaultView
                    drpOrderNo.DataSource = Nothing
                    drpOrderNo.ValueMember = Nothing
                    drpOrderNo.DisplayMember = Nothing
                    drpOrderNo.DisplayMember = "ORDER_NO"
                    drpOrderNo.ValueMember = "Id"
                    drpOrderNo.DataSource = dview
                End If
                ''end code to fill combo
                strFinalOrderNo = drpOrderNo.Text
                For Each objXmlNode In objOutputXml.DocumentElement.SelectNodes("DETAILS")
                    If Not objXmlNode.Attributes("ORDER_NO").InnerText = strFinalOrderNo Then
                        objOutputXml.DocumentElement.RemoveChild(objXmlNode)
                    End If
                Next

                m_objdsFinal = Nothing
                m_objdsFinal = New DataSet
                m_objdsFinal.Clear()

                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXMLNodeReader = New XmlNodeReader(objOutputXml)
                    m_objdsFinal.ReadXml(objXMLNodeReader)

                    m_objdsFinal.Tables("DETAILS").Columns.Add("TEMPFILENO")
                    m_objdsFinal.Tables("DETAILS").Columns.Add("TEMPORDER_NO")
                    m_objdsFinal.Tables("DETAILS").Columns.Add("TEMPORDER_TYPE")

                    lstFinalList.DataSource = m_objdsFinal.Tables("DETAILS")
                    lstFinalList.DisplayMember = "FILEORDER"
                    lstFinalList.ValueMember = "Id"

                Else
                    'MsgBox(objOutputXml.DocumentElement.SelectSingleNode("Errors/Error").Attributes("Description").Value)
                    MsgBox("There is no Document Scaned in this FileNo.. " & vbCrLf & "Press Ok to Continue Update File.!", MsgBoxStyle.Information, "Amadeus Document Management System")
                    lstFinalList.DataSource = Nothing
                    lstFinalList.Items.Clear()
                    StrCheck = True
                    drpOrderNo.DataSource = Nothing
                    drpOrderNo.Items.Clear()

                    drpOrderType.DataSource = Nothing
                    drpOrderType.Items.Clear()


                End If
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "drpFileNo_SelectedIndexChanged", exc.GetBaseException)
        Finally
            objInputXml = Nothing
            objOutputXml = Nothing
            objbzAgency = Nothing
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzAgency As New AAMS.bizTravelAgency.bzAgency
        Dim i As Integer
        i = 0

        ' Input XML
        '<TA_UPDATEAGENCYFILENODETAILS_INPUT>
        '   <AGENCYFILE ID='' FILENO=''  ORDERNO ='' DOCTYPE ='' SEQUENCE='' ORDERTYPE='' CONTENTTYPE=''/>
        '</TA_UPDATEAGENCYFILENODETAILS_INPUT>

        'Output XML  
        '<TA_UPDATEAGENCYFILENODETAILS_OUTPUT>
        '<AGENCYFILE ID='' FILENO=''  ORDERNO ='' DOCTYPE ='' SEQUENCE='' ORDERTYPE='' />
        '   <Errors Status=''>
        '       <Error Code='' Description='' />
        '   </Errors>
        '</TA_UPDATEAGENCYFILENODETAILS_OUTPUT>
        'For Each i In lstRawList.Items.Count
        Try
            Dim objbzAFileno As New AAMS.bizTravelAgency.bzAgency
            Dim objInputDoc As XmlDocument
            Dim strInput_XML As String = "<TA_UPDATEAGENCYFILENODETAILS_INPUT><AGENCYFILE ID='' FILENO=''  ORDERNO ='' DOCTYPE ='' SEQUENCE='' ORDERTYPE='' CONTENTTYPE=''/></TA_UPDATEAGENCYFILENODETAILS_INPUT>"
            objInputDoc = New XmlDocument
            objInputDoc.LoadXml(strInput_XML)

            If lstFinalList.Items.Count <= 0 Then
                MsgBox("No Items in Final List", MsgBoxStyle.Information, "Amadeus Document Management System")
                Exit Sub
            End If

            Try

                For i = 0 To m_objdsFinal.Tables("DETAILS").Rows.Count - 1
                    objInputDoc.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("ID").Value = m_objdsFinal.Tables("DETAILS").Rows(i).Item("Id")
                    objInputDoc.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("FILENO").Value = drpFileNo.Text
                    objInputDoc.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("ORDERNO").Value = m_objdsFinal.Tables("DETAILS").Rows(i).Item("ORDER_NO")
                    objInputDoc.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("DOCTYPE").Value = m_objdsFinal.Tables("DETAILS").Rows(i).Item("DOCTYPE")
                    objInputDoc.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("SEQUENCE").Value = m_objdsFinal.Tables("DETAILS").Rows(i).Item("FILEORDER")
                    objInputDoc.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("ORDERTYPE").Value = m_objdsFinal.Tables("DETAILS").Rows(i).Item("ORDER_TYPE")
                    'objInputDoc.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("CONTENTTYPE").Value = m_objdsFinal.Tables("DETAILS").Rows(i).Item("CONTENTTYPE")

                    objOutputXml = New XmlDocument
                    objOutputXml = objbzAgency.UpdateFile(objInputDoc)
                Next
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    MsgBox("Record Updated Successfully.", MsgBoxStyle.Information)
                End If

            Catch exc As Exception
                MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
                Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "btnUpdate_Click FileNo Method", exc.GetBaseException)
            Finally
                objInputDoc = Nothing
                objOutputXml = Nothing
                objbzAFileno = Nothing
            End Try
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "btnSave_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub lstRawList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRawList.Click
        Try
            lstFinalList.SelectedIndex = -1
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "lstRawList_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub lstFinalList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFinalList.Click
        Try
            lstRawList.SelectedIndex = -1
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "lstFinalList_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpOrderNo.SelectedIndexChanged
        '***********************************************************************
        'Purpose:This function gives details Scanned Document
        'Input  :
        '<TA_GETAGENCYFILENODETAILS_INPUT>
        '   <FILENO/>    
        '</TA_GETAGENCYFILENODETAILS_INPUT>

        'Output :
        '<TA_GETAGENCYFILENODETAILS_OUTPUT>
        '     <DETAILS ID="" DOCTYPE="" FILENO="" FILEORDER="" ORDER_NO="" ORDER_TYPE=""></DETAILS>
        '</TA_GETAGENCYFILENODETAILS_OUTPUT>
        '************************************************************************
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzorder As New AAMS.bizTravelAgency.bzAgency
        Dim objXMLNodeReader As XmlNodeReader
        Dim dview As New DataView
        Dim dSet As New DataSet
        Dim objXmlNode As XmlNode
        Dim strFinalOrderNo As String
        Dim i As Integer = 1


        drpOrderType.Items.Clear()

        If drpOrderNo.Items.Count > 0 Then
            Try
                objInputXml.LoadXml("<TA_GETAGENCYFILENODETAILS_INPUT><FILENO></FILENO></TA_GETAGENCYFILENODETAILS_INPUT>")
                If (drpFileNo.SelectedIndex >= 0) Then
                    objInputXml.DocumentElement.SelectSingleNode("FILENO").InnerXml = drpFileNo.SelectedValue
                    objOutputXml = objbzorder.GetFileNoDetailsForDoc(objInputXml)

                    'code to fill combo
                    strFinalOrderNo = drpOrderNo.Text

                    For Each objXmlNode In objOutputXml.DocumentElement.SelectNodes("DETAILS")
                        If Not objXmlNode.Attributes("ORDER_NO").InnerText = strFinalOrderNo Then
                            objOutputXml.DocumentElement.RemoveChild(objXmlNode)
                        Else
                            boolFindOrderType = SearchOrderType(Me.drpOrderType, objXmlNode.Attributes("ORDER_TYPE").InnerText)
                            If boolFindOrderType = False Then
                                drpOrderType.Items.Add(objXmlNode.Attributes("ORDER_TYPE").InnerText)
                            End If
                        End If
                    Next

                    If drpOrderType.Items.Count > 0 Then
                        drpOrderType.SelectedIndex = 0
                    End If

                    m_objdsFinal.Clear()

                    If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                        objXMLNodeReader = New XmlNodeReader(objOutputXml)
                        m_objdsFinal.ReadXml(objXMLNodeReader)
                        lstFinalList.DataSource = m_objdsFinal.Tables("DETAILS")
                        lstFinalList.DisplayMember = "FILEORDER"
                        lstFinalList.ValueMember = "Id"
                    Else
                        If StrCheck = True Then
                        Else
                            MsgBox(objOutputXml.DocumentElement.SelectSingleNode("Errors/Error").Attributes("Description").Value, MsgBoxStyle.Critical, "    Amadeus Document Management System")
                        End If

                    End If
                End If
            Catch exc As Exception
                MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
                Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "drpOrderNo_SelectedIndexChanged", exc.GetBaseException)
            Finally
                objInputXml = Nothing
                objOutputXml = Nothing
                objbzorder = Nothing
            End Try
        End If
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmUpdateFile", "drpOrderNo_SelectedIndexChanged", exc.GetBaseException)
        End Try
    End Sub


End Class