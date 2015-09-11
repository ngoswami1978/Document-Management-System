'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmViewDoc.vb $
'$Workfile: frmViewOrder.vb $
'$Revision: 33 $
'$Archive: /AAMS/Interface/ADMS/frmViewOrder.vb $
'$Modtime: 12/26/12 12:38p $
Imports System.Text
Imports System.Xml
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports AAMS.bizTravelAgency
Imports AAMS.bizShared
Public Class frmViewOrder
    Dim objtable As New DataTable
    Dim objtable1 As New DataTable
    Dim intExetension As Integer
    Dim objOutputOrderDetailsXml As XmlDocument
    Public frmgblFormName As String = "frmViewOrder"
    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        Dim strOrderNumber As String = ""
        Dim strOrderType As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
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
                MsgBox("Please Select OrderNumber for Scan", vbCritical, "AAMS Error")
                Exit Sub
            End If

          'Me.Close()

          

            
            Dim objfrmInput As New frmFilling
            '############# Commented due to make this form as a Child of Prevous One
            'objfrmInput.MdiParent = frmMain
            'objfrmInput.WindowState = FormWindowState.Normal
            'End ############# Commented due to make this form as a Child of Prevous One


            '' Set All Values into FrmFillings Forms 
            If m_file_no = 0 Then
               objfrmInput.txtFileNo.Text = ""
            Else
               objfrmInput.txtFileNo.Text = m_file_no
            End If



            objfrmInput.txtOrderNumber.Text = strOrderNumber
            objfrmInput.txtOrderType.Text = strOrderType
            ''**************************************

            ChangeAtrib()
            ScanImageToFile() ' Temperory Hide 
            ChangeAtrib()
            'objfrmInput.Show()
            objfrmInput.ShowDialog()


        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "btnScan_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub btnUpdateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateFile.Click
        Dim strOrderNumber As String = ""
        Dim strOrderType As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
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
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "btnUpdateFile_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub btnViewDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDoc.Click
        Dim strOrderNumber As String = ""
        Dim strOrderType As String = ""
        Dim strFileOrder As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
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
            objfrmInput.WindowState = FormWindowState.Normal

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
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "btnViewDoc_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try

    End Sub
    Private Sub ChangeAtrib()
        Try
            If FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes And 1 Then
                FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes = FileIO.FileSystem.GetDirectoryInfo(strFilePath).Attributes - 1
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "ChangeAtrib", exc.GetBaseException)
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
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "ScanImageToFile", exc.GetBaseException)
        End Try
    End Sub

   ''Private Sub frmViewOrder_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
   ''Try

   ''   If frmgblFormName = "frmOrderDetail" Then
   ''        GetOrderDetails()
   ''   End If

   '' Catch exc As Exception
   ''     MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
   ''     Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "Form1_Load", exc.GetBaseException)
   '' End Try
   ''End Sub

   Public Sub getOrder()
      Try
         If frmgblFormName = "frmOrderDetail" Then
              GetOrderNumber()
              GetOrderDetails()
         End If

       Catch exc As Exception
           MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
           Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "getOrder", exc.GetBaseException)
       End Try
   End Sub

    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GetOrderNumber()
            GetOrderDetails()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "Form1_Load", exc.GetBaseException)
        End Try
    End Sub
    Private Sub GetOrderNumber()
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objbzOrder As New AAMS.bizTravelAgency.bzOrder
        Try
         '   objInputXml.LoadXml("<MS_GETORDERS_INPUT><LCODE></LCODE></PAGE_NO></PAGE_SIZE></SORT_BY></DESC></MS_GETORDERS_INPUT>")
            objInputXml.LoadXml("<MS_GETORDERS_INPUT><LCODE></LCODE><PAGE_NO></PAGE_NO><PAGE_SIZE></PAGE_SIZE><SORT_BY></SORT_BY><DESC></DESC></MS_GETORDERS_INPUT>")
            objInputXml.DocumentElement.SelectSingleNode("LCODE").InnerXml = gblLcode

            'Here Back end Method Call
            objOutputXml = objbzOrder.GetDetails(objInputXml)
            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                objOutputOrderDetailsXml = objOutputXml
                With objOutputXml.DocumentElement.SelectSingleNode("ORDERS")
                    strOrderId = .Attributes("ORDERID").Value()
                    strOrderNumber = .Attributes("ORDER_NUMBER").Value()
                End With
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "GetOrderNumber", exc.GetBaseException)
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
        Dim objRow1 As DataRow

         Dim objAddNode As XmlNode

        objtable = Nothing
        objtable = New DataTable

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
                    objtable.Columns.Add("ORDERID", GetType(Integer))

                    objInputXml.LoadXml("<MS_GETORDERS_INPUT><LCODE></LCODE><PAGE_NO></PAGE_NO><PAGE_SIZE></PAGE_SIZE><SORT_BY></SORT_BY><DESC></DESC></MS_GETORDERS_INPUT>")
                    objInputXml.DocumentElement.SelectSingleNode("LCODE").InnerXml = gblLcode

                    'Here Back end Method Call
                    objOutputXml = objbzOrder.GetDetails(objInputXml)

                    If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then

                        For Each objAddNode In objOutputXml.DocumentElement.SelectNodes("ORDERS")
                            objRow = objtable.NewRow
                            With objOutputXml.DocumentElement.SelectSingleNode("ORDERS")
                                objRow("ORDERID") = CInt(objAddNode.Attributes("ORDERID").Value())
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
                        Dim dv As New DataView

                        dv = objtable.DefaultView
                        dv.Sort = "ORDERID  desc"
                        If frmgblFormName = "frmOrderDetail" Then

                            tdbGridOrderReceived.DataSource = dv 'objtable.DefaultView
                        Else
                            tdbGridOrderReceived.DataSource = dv 'objtable.DefaultView
                        End If

                    End If
                    Call grid_setting()
                End If
            End If
            
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "GetOrderDetails", exc.GetBaseException)
        Finally
            objInputXml = Nothing
            objOutputXml = Nothing
            objbzAgency = Nothing
            strOrderId = Nothing
        End Try
    End Sub
    Private Sub grid_setting()
        Try

            tdbGridOrderReceived.Splits(0).DisplayColumns(0).Width = 70     'orderno
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
            tdbGridOrderReceived.Splits(0).DisplayColumns(11).Width = 100    'Pending with EMp
            tdbGridOrderReceived.Splits(0).DisplayColumns(12).Width = 0 ' 'orderID
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "grid_setting", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "btnClose_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
        '    OpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"

             OpenFileDialog1.Filter = "Select_Pdf_File|*.pdf|Select_jpg File|*.jpg|Select_jpeg|*.jpeg|Select_bmp|*.bmp|Image_Gif|*.gif"

            '****************** New added
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtPdf.Text = OpenFileDialog1.FileName
            Else
                txtPdf.Text = ""
                Exit Sub
            End If


            'If (IO.Path.GetExtension(OpenFileDialog1.FileName) = ".pdf" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".PDF") Or (IO.Path.GetExtension(OpenFileDialog1.FileName) = ".jpg" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".JPG") Or (IO.Path.GetExtension(OpenFileDialog1.FileName) = ".jpeg" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".JPEG") Or (IO.Path.GetExtension(OpenFileDialog1.FileName) = ".bmp" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".BMP") Then
            '   MsgBox("Invalid Extenstion", MsgBoxStyle.Critical, "Amadeus Document Management System")
            '   Exit Sub
            'End If



           If IO.Path.GetExtension(OpenFileDialog1.FileName) = ".pdf" Or IO.Path.GetExtension(OpenFileDialog1.FileName) = ".PDF" Then
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
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "btnBrowse_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
         'Input:
        '<TA_UPDATEAGENCYFILENODETAILS_INPUT>
        '<AGENCYFILE ID ='' FILENO=''  ORDERNO ='' DOCTYPE ='' SEQUENCE='' ORDERTYPE='' DOCUMENT='' ContentType='' EmailFrom='' EmailTo =''   EmailSubject = '' EmailBody='' PDFDocFileName=''/>
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
        Dim ch As Integer

        Dim cmd As New SqlCommand
        Dim objSqlCommand As New SqlCommand
        Dim objSqlConnection As New SqlConnection(bzShared.GetDOCConnectionString)
        Dim objSqlConnection1 As New SqlConnection(bzShared.GetConnectionString)


        Try
            If Trim(txtPdf.Text) = "" Then
                MsgBox("Please Select File To Upload.", MsgBoxStyle.Critical, "Amadeus Document Management System")
                Exit Sub
            End If

            If intExetension <= 0 Then
                MsgBox("Invalid Extenstion", MsgBoxStyle.Critical, "Amadeus Document Management System")
               Exit Sub
            End If


            If objtable.Rows.Count = 0 Then
                MsgBox("Failed to upload file. Because their is no Order Number ", MsgBoxStyle.Critical)
                txtPdf.Text = ""
                Exit Sub
            Else

            End If

            ch = MsgBox("Are you sure to upload the File for agency : " & "'" & (UCase(txtOrderAgencyname.Text)) & "'" & " ", MsgBoxStyle.YesNo, "Amadeus Document Management System")
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
                    .Parameters("@ORDERNO").Value = tdbGridOrderReceived.Columns.Item(0).Value

                    .Parameters.Add(New SqlParameter("@DOCTYPE", SqlDbType.Int))
                    .Parameters("@DOCTYPE").Value = 2

                    .Parameters.Add(New SqlParameter("@SEQUENCE", SqlDbType.Int))
                    .Parameters("@SEQUENCE").Value = 0

                    .Parameters.Add(New SqlParameter("@ORDERTYPE", SqlDbType.Char, 200))
                    .Parameters("@ORDERTYPE").Value = tdbGridOrderReceived.Columns.Item(1).Value

                    .Parameters.Add(New SqlParameter("@DOCUMENT", SqlDbType.Image))
                    .Parameters("@DOCUMENT").Value = DBNull.Value

                    .Parameters.Add(New SqlParameter("@ContentType", SqlDbType.Int))
                    .Parameters("@ContentType").Value = intExetension '3

                    .Parameters.Add(New SqlParameter("@EmailFrom", SqlDbType.VarChar, 100))
                    .Parameters("@EmailFrom").Value = String.Empty

                    .Parameters.Add(New SqlParameter("@EmailTo", SqlDbType.VarChar, 3000))
                    .Parameters("@EmailTo").Value = String.Empty

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
                MsgBox("File Successfully Uploaded", MsgBoxStyle.Information, "Amadeus Document Management System")

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
            Call AAMS.bizShared.bzShared.LogWrite("frmViewOrder", "btnUpload_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
            cmd.Dispose()
            objSqlConnection.Close()
            objSqlConnection1.Close()
        End Try
    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Dim strStatus As String
        Dim intOrderID As Integer
        Dim strApprovalDate As String
        Dim strapplieddate As String
        Dim strAgencyPC As String
        Dim strAmadeusPC As String
        Dim strAmadeusPrinter As String
        Dim strRemarks As String


        Try
            Me.Cursor = Cursors.WaitCursor
            If objtable.Rows.Count >= 1 Then



                strOrderNumber = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 0), String)

                intOrderID = Val(objOutputOrderDetailsXml.DocumentElement.SelectSingleNode("ORDERS[@ORDER_NUMBER='" & strOrderNumber & "']").Attributes("ORDERID").InnerText)

                strOrderType = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 1), String)
                strStatus = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 2), String)
                strApprovalDate = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 3), String)
                strapplieddate = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 4), String)
                strAgencyPC = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 5), String)
                strAmadeusPC = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 6), String)
                strAmadeusPrinter = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 7), String)
                strRemarks = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 8), String)

               
                If CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 0), String) = "" Then       'if use does not select any agency
                    MsgBox("Please Select Agency Order", MsgBoxStyle.Information, "Amadeus Document Management System")
                    Exit Sub
                Else
                    'gblLcode = CType(tdbGridOrderReceived.Item(tdbGridOrderReceived.Row, 0), String)
                    Dim objfrmInput As New frmOrderDetail
                    objfrmInput.WindowState = FormWindowState.Normal
                    objfrmInput.txtOrderNo.Text = strOrderNumber
                    objfrmInput.txtOrderType.Text = strOrderType
                    objfrmInput.txtOrderStatus.Text = strStatus
                    objfrmInput.txtAgencyPC.Text = strAgencyPC
                    objfrmInput.txtAmadeusPC.Text = strAmadeusPC
                    objfrmInput.txtAmadeusPrinter.Text = strAmadeusPrinter
                    objfrmInput.txtRemarks.Text = strRemarks
                    objfrmInput.txtAppliedDate.Text = strapplieddate
                    objfrmInput.txtOrderApprovalDate.Text = strApprovalDate
                    objfrmInput.glbOrderId = intOrderID

                    Me.Cursor = Cursors.WaitCursor
                    objfrmInput.ShowDialog()
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


    
End Class