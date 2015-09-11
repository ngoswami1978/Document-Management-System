'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmViewDoc.vb $
'$Workfile: frmViewDoc.vb $
'$Revision: 70 $
'$Archive: /AAMS/Interface/ADMS/frmViewDoc.vb $
'$Modtime: 6/23/14 2:29p $
Imports System.IO
Imports System.Xml
Imports System.Text

Imports System.Drawing.Printing
Imports System.Drawing.Graphics

Public Class frmViewDocument
    Dim strBuilder As New System.Text.StringBuilder
    Dim dSetGlobal As New DataSet
    Dim bManager As BindingManagerBase
    Dim ZoomPercent As Long
    Dim press As Integer
    Dim StrGlobalImageId As String
    Dim StrGlobalPdfId As String
    Dim strGlobalContentType As String
    Dim blnDeletePress As Boolean
    Dim bmPosition As Integer
    Dim objPrintPreview As New PrintPreviewDialog
    Dim objPrintDoc As New PrintDocument
    Dim StrAgencyDetail As String
    Enum Result
        Success = 1
        Failure = 2
    End Enum

    Private Sub frmViewDocument_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            DeleteFiles()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "frmViewDocument_Disposed", exc.GetBaseException)
        End Try
    End Sub
    Private Sub frmViewDocument_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            DeleteFiles()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "frmViewDocument_FormClosing", exc.GetBaseException)
        End Try
    End Sub
    Private Sub frmUP_Agency_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            lblFlag.Visible = False
            lblHiddenFileNo.Visible = False
            lblImageID.Visible = False
            lblPageScanned.Text = ""
            'AxPdf.Size = New Size(684, 443)
            'AxImgEdit1.Size = New Size(684, 443)


            If lblFlag.Text = "VD" Then
                BindViewDocument(lblHiddenFileNo.Text.Trim(), False, "")

                lblOrderType.Visible = True
                txtOrderType.Visible = True
                lblOrderNumber.Visible = True
                txtOrderNumber.Visible = True

            End If

            If lblFlag.Text = "MISC" Then
                Call btnViewAll_Click(sender, e)

                lblOrderType.Visible = False
                txtOrderType.Visible = False
                lblOrderNumber.Visible = False
                txtOrderNumber.Visible = False

            End If

            Dim objSecurityXml As New XmlDocument
            objSecurityXml.LoadXml(SecurityXml)
            If (objSecurityXml.DocumentElement.SelectSingleNode("Administrator").InnerText = "0") Then
                If objSecurityXml.DocumentElement.SelectNodes("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='AGENCY_OFFICE']").Count <> 0 Then
                    strBuilder = SecurityCheck(objSecurityXml.DocumentElement.SelectSingleNode("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='File']").Attributes("Value").Value)
                    If strBuilder(0) = "0" Then
                        btnViewAll.Enabled = False
                    End If
                End If
            Else
                strBuilder = SecurityCheck(31)
            End If


        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "frmUP_Agency_Load", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            bManager = Nothing
            dSetGlobal = Nothing
            txtOrderNumber.Text = ""
            dSetGlobal = New DataSet

            txtOrderNumber.DataBindings.Clear()
            txtSequenceNo.DataBindings.Clear()
            txtOrderType.DataBindings.Clear()
            lblImageID.DataBindings.Clear()
            txtFileNo.DataBindings.Clear()

            'txtMailBody.DataBindings.Clear()
            WebBrowser1.DataBindings.Clear()
            txtMailFrom.DataBindings.Clear()
            txtMailSub.DataBindings.Clear()
            txtMailTo.DataBindings.Clear()
            txtFileName.DataBindings.Clear()

            If lblFlag.Text = "MISC" Then
                BindViewDocument(lblHiddenFileNo.Text.Trim(), True, "")
            Else
                BindViewDocument(lblHiddenFileNo.Text.Trim(), False, "")
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnViewAll_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub BindViewDocument(ByVal strFileNo As String, Optional ByVal strViewMISC As Boolean = False, Optional ByVal strordeNo As String = "")
        Dim bztaOrderDoc As New AAMS.bizTravelAgency.bzOrder
        Dim xInput, xOutput As New XmlDocument
        Dim m_objdsSelect As New DataSet
        Dim xReader As XmlNodeReader
        Dim strNewFileName As String
        Dim strFinalPath As String
        Try
            Me.Cursor = Cursors.WaitCursor

            If strViewMISC = False Then
                xInput.LoadXml("<TA_GETSCANNEDDOCUMENT_INPUT><LCode></LCode><FileNo></FileNo><Order_No></Order_No></TA_GETSCANNEDDOCUMENT_INPUT>")
                xInput.DocumentElement.SelectSingleNode("LCode").InnerText = gblLcode
                xInput.DocumentElement.SelectSingleNode("FileNo").InnerText = strFileNo

                If txtOrderNumber.Text.Trim() <> "" Then
                    xInput.DocumentElement.SelectSingleNode("Order_No").InnerText = txtOrderNumber.Text.Trim()
                Else
                    xInput.DocumentElement.SelectSingleNode("Order_No").InnerText = strordeNo
                End If

                xOutput = bztaOrderDoc.GetScannedDocument(xInput)
                If xOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    xReader = New XmlNodeReader(xOutput)
                    dSetGlobal.ReadXml(xReader)


                    'bManager = Me.BindingContext(dSetGlobal, "Document")
                    bManager = Me.BindingContext(dSetGlobal.Tables("Document"))

                    If dSetGlobal.Tables("Document").Rows.Count > 0 Then

                        txtFileNo.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.FileNo"))
                        txtOrderNumber.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.Order_No"))
                        txtSequenceNo.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.FileOrder"))
                        txtOrderType.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.Order_Type"))
                        lblImageID.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.ID"))

                        'txtMailBody.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailBody"))
                        WebBrowser1.DataBindings.Add(New Binding("DocumentText", dSetGlobal, "Document.EmailBody"))
                        txtMailFrom.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailFrom"))
                        txtMailSub.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailSubject"))
                        txtMailTo.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailTo"))
                        txtFileName.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.PDFDocFileName"))



                        ''Write new code to tackle delete problem
                        If blnDeletePress = True Then
                            If bmPosition = 0 Then
                                bManager.Position = 0
                            Else
                                bManager.Position = bmPosition - 1
                            End If

                        Else
                            bManager.Position = 0
                            blnDeletePress = False
                        End If

                        ''end here


                        Dim strid As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
                        StrGlobalImageId = strid
                        Dim strContentType As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ContentType").ToString()
                        strGlobalContentType = strContentType

                        If strContentType = "1" Then
                            GetImage(strid)
                            PictureBox1.Visible = False
                            AxImgEdit1.Visible = True
                            AxPdf.Visible = False
                            EnableButtonTrue()
                            HideEmail()
                            btnPrint.Enabled = True
                            btnDelete.Enabled = True
                        ElseIf strContentType = "2" Then
                            AxImgEdit1.Visible = False
                            AxPdf.Visible = False
                            PictureBox1.Visible = False
                            EnableButtonFalse()
                            btnPrint.Enabled = True
                            btnDelete.Enabled = False
                            VisibleEmail()
                        ElseIf strContentType = "3" Then
                            strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".pdf"
                            strFinalPath = strPdfFolderName & "\" & strNewFileName
                            StrGlobalPdfId = strFinalPath
                            AxPdf.LoadFile(strFinalPath)
                            AxPdf.Show()
                            AxPdf.Visible = True
                            btnDelete.Enabled = True
                            AxImgEdit1.Visible = False
                            HideEmail()
                            EnableButtonFalse()
                            btnPrint.Enabled = False
                            PictureBox1.Visible = False
                        ElseIf strContentType = "4" Then
                            strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".jpg"
                            strFinalPath = strPdfFolderName & "\" & strNewFileName
                            HideEmail()
                            AxImgEdit1.Visible = False
                            AxPdf.Visible = False
                            EnableButtonFalse()
                            PictureBox1.ImageLocation = strFinalPath
                            ''visible block
                            PictureBox1.Visible = True
                            btnPrint.Enabled = True
                            btnDelete.Enabled = True
                            ''end of visible block
                            PictureBox1.Show()
                        End If
                    End If
                Else
                    'txtAgencyName.Text = ""
                    'txtAddress.Text = ""
                    'txtOfficeId.Text = ""
                    'txtFileNo.Text = ""
                    txtOrderNumber.Text = ""
                    txtSequenceNo.Text = ""
                    txtOrderType.Text = ""
                    lblImageID.Text = ""
                    AxImgEdit1.Visible = False
                    PictureBox1.Visible = False
                    AxPdf.Visible = False
                    HideEmail()

                End If
            Else
                Call GetMISCImage(strFileNo)
            End If

        Catch exc As Exception
            MsgBox(exc.Message)
            'MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "BindViewDocument", exc.GetBaseException)

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub HideEmail()
        lblContent.Visible = False
        lblMailFrom.Visible = False
        lblMailTo.Visible = False
        lblSubject.Visible = False
        'txtMailBody.Visible = False
        WebBrowser1.Visible = False
        txtMailFrom.Visible = False
        txtMailSub.Visible = False
        txtMailTo.Visible = False
    End Sub
    Public Sub VisibleEmail()
        lblContent.Visible = True
        lblMailFrom.Visible = True
        lblMailTo.Visible = True
        lblSubject.Visible = True
       ' txtMailBody.Visible = True
         WebBrowser1.Visible = True

        txtMailFrom.Visible = True
        txtMailSub.Visible = True
        txtMailTo.Visible = True
    End Sub
    Public Sub EnableButtonTrue()
        '  btnViewAll.Enabled = True
        btnZoomIN.Enabled = True
        btnZoomOut.Enabled = True
        btnFitPage.Enabled = True
    End Sub
    Public Sub EnableButtonFalse()
        ' btnViewAll.Enabled = False
        btnZoomIN.Enabled = False
        btnZoomOut.Enabled = False
        btnFitPage.Enabled = False
    End Sub
    ''----------Mothod was commented due to compactibility issue  kadac component in windows 7---------
    'Private Sub GetImage(ByVal strImgID As String)
    '    Dim xInput, xOutput As New XmlDocument
    '    Dim dSet As New DataSet
    '    Dim bztaOrderImage As New AAMS.bizTravelAgency.bzOrder
    '    Dim mStream As MemoryStream
    '    Dim imgStream As Image
    '    Try
    '        AxImgEdit1.Visible = True
    '        EnableButtonTrue()
    '        HideEmail()
    '        AxPdf.Visible = False
    '        xInput.LoadXml("<TA_GETSCANNEDIMAGE_INPUT><ID></ID></TA_GETSCANNEDIMAGE_INPUT>")
    '        xInput.DocumentElement.SelectSingleNode("ID").InnerText = strImgID
    '        dSet = bztaOrderImage.GetScannedImage(xInput)
    '        If dSet.Tables(0).Rows.Count > 0 Then
    '            Dim ImageBytes() As Byte = dSet.Tables(0).Rows(0)(1)
    '            mStream = New MemoryStream(ImageBytes)
    '            imgStream = Image.FromStream(mStream)

    '            Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
    '            imgStream.Save(imgPath)
    '            If CInt(strZoomPercentage) <> 0 Then
    '                AxImgEdit1.Zoom = CInt(strZoomPercentage)
    '            End If
    '            AxImgEdit1.Image = imgPath
    '            AxImgEdit1.Display()
    '            lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
    '        End If

    '    Catch exc As Exception
    '        MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "GetImage", exc.GetBaseException)
    '    Finally
    '        mStream = Nothing
    '        imgStream = Nothing
    '    End Try
    'End Sub
    '' End here
    Private Sub GetImage(ByVal strImgID As String)
        Dim xInput, xOutput As New XmlDocument
        Dim dSet As New DataSet
        Dim bztaOrderImage As New AAMS.bizTravelAgency.bzOrder
        Dim mStream As MemoryStream
        Dim imgStream As Image
        Try
            AxImgEdit1.Visible = True
            EnableButtonTrue()
            HideEmail()
            AxPdf.Visible = False
            xInput.LoadXml("<TA_GETSCANNEDIMAGE_INPUT><ID></ID></TA_GETSCANNEDIMAGE_INPUT>")
            xInput.DocumentElement.SelectSingleNode("ID").InnerText = strImgID
            dSet = bztaOrderImage.GetScannedImage(xInput)
            If dSet.Tables(0).Rows.Count > 0 Then
                Dim ImageBytes() As Byte = dSet.Tables(0).Rows(0)(1)

                'Convert byte[] to Base64 String
                Dim base64String As String = Convert.ToBase64String(ImageBytes)
                ImageBytes = Convert.FromBase64String(base64String)
                mStream = New MemoryStream(ImageBytes, 0, ImageBytes.Length)
                mStream.Write(ImageBytes, 0, ImageBytes.Length)
                imgStream = Image.FromStream(mStream)

                Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
                imgStream.Save(imgPath)

                ConvertBytesToImageFile(ImageBytes, imgPath)

                If CInt(strZoomPercentage) <> 0 Then
                    AxImgEdit1.Zoom = CInt(strZoomPercentage)
                End If
                AxImgEdit1.Image = imgPath
                AxImgEdit1.Display()
                lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "GetImage", exc.GetBaseException)
        Finally
            mStream = Nothing
            imgStream = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' Converts array of Bytes to Image File
    ''' </summary>
    ''' <param name="ImageData">The array of bytes which contains image binary data</param>
    ''' <param name="FilePath">The destination file path.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertBytesToImageFile(ByVal ImageData As Byte(), ByVal FilePath As String) As Result
        If IsNothing(ImageData) = True Then
            Return Result.Failure
            'Throw New ArgumentNullException("Image Binary Data Cannot be Null or Empty", "ImageData")
        End If
        Try
            Dim fs As IO.FileStream = New IO.FileStream(FilePath, IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
            Dim bw As IO.BinaryWriter = New IO.BinaryWriter(fs)
            bw.Write(ImageData)
            bw.Flush()
            bw.Close()

            fs.Close()
            fs.Dispose()
            bw = Nothing
            fs.Dispose()
            Return Result.Success
        Catch ex As Exception
            Return Result.Failure
        End Try
    End Function

    'Private Sub GetMISCImage(ByVal strFileNo As Integer)
    '    'Input  :
    '    '<TA_GETMISCSCANNEDDOCUMENT_INPUT>
    '    '<FileNo></FileNo>
    '    '</TA_GETMISCSCANNEDDOCUMENT_INPUT>

    '    'Output :
    '    '<TA_GETMISCSCANNEDDOCUMENT_OUTPUT>
    '    '<Document ID='' Document ='' FileNo='' Order_No='' Status='' FileOrder='' DocType='' Order_Type='' />
    '    '<Errors Status=''><Error Code='' Description='' />
    '    '</Errors>
    '    '</TA_GETMISCSCANNEDDOCUMENT_OUTPUT>            

    '    Dim xInput, xOutput As New XmlDocument
    '    'Dim dSet As New DataSet
    '    Dim bztaOrderImage As New AAMS.bizTravelAgency.bzOrder
    '    Dim strNewFileName As String
    '    Dim strFinalPath As String
    '    Dim mStream As MemoryStream
    '    Dim imgStream As Image
    '    Dim strDSContentType As String

    '    Try
    '        xInput.LoadXml("<TA_GETMISCSCANNEDDOCUMENT_INPUT><LCode></LCode><FileNo></FileNo></TA_GETMISCSCANNEDDOCUMENT_INPUT>")

    '        xInput.DocumentElement.SelectSingleNode("LCode").InnerText = gblLcode

    '        If strFileNo = 0 Then
    '            xInput.DocumentElement.SelectSingleNode("FileNo").InnerText = 0
    '        Else
    '            xInput.DocumentElement.SelectSingleNode("FileNo").InnerText = strFileNo

    '        End If

    '        dSetGlobal = bztaOrderImage.GetMiscScannedDocument(xInput)

    '        dSetGlobal.Tables(0).TableName = "Document"

    '        If (Not dSetGlobal.Tables("Document") Is Nothing) Then
    '            If dSetGlobal.Tables("Document").Rows.Count > 0 Then
    '                bManager = Me.BindingContext(dSetGlobal.Tables("Document"))
    '                lblImageID.DataBindings.Add(New Binding("Text", dSetGlobal.Tables("Document"), "ID"))
    '                txtFileNo.DataBindings.Add(New Binding("Text", dSetGlobal.Tables("Document"), "FileNo"))
    '                txtSequenceNo.DataBindings.Add(New Binding("Text", dSetGlobal.Tables("Document"), "FileOrder"))
    '                lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
    '               ' txtMailBody.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailBody"))
    '                WebBrowser1.DataBindings.Add(New Binding("DocumentText", dSetGlobal, "Document.EmailBody"))

    '                txtMailFrom.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailFrom"))
    '                txtMailSub.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailSubject"))
    '                txtMailTo.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailTo"))
    '                Dim strContentType As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ContentType").ToString()
    '                strGlobalContentType = strContentType

    '                bManager.Position = 0
    '                If strContentType = "1" Then            ''CASE FOR SCAN DOCUMENT
    '                    Dim strImgID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
    '                    StrGlobalImageId = strImgID
    '                    Dim ImageBytes() As Byte = dSetGlobal.Tables("Document").Rows(bManager.Position)("Document")
    '                    mStream = New MemoryStream(ImageBytes)
    '                    imgStream = Image.FromStream(mStream)
    '                    Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
    '                    imgStream.Save(imgPath)

    '                    ''disable block
    '                    HideEmail()
    '                    AxPdf.Visible = False
    '                    PictureBox1.Visible = False
    '                    ''end of disable block   

    '                    AxImgEdit1.Image = imgPath

    '                    ''visible block
    '                    AxImgEdit1.Visible = True
    '                    EnableButtonTrue()
    '                    btnPrint.Enabled = True
    '                    btnDelete.Enabled = True
    '                    ''end of visible block

    '                    AxImgEdit1.Display()
    '                    Call DisplayMISCImage()
    '                ElseIf strContentType = "2" Then              ''case for E-mail document

    '                    ''disable block
    '                       AxImgEdit1.Visible = False
    '                       AxPdf.Visible = False
    '                       PictureBox1.Visible = False
    '                       EnableButtonFalse()
    '                       btnDelete.Enabled = False
    '                    ''end of disable block   


    '                    ''visible block
    '                    VisibleEmail()
    '                    btnPrint.Enabled = True
    '                    ''end of visible block

    '                ElseIf strContentType = "3" Then              ''case for pdf

    '                    Dim strPDFID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()

    '                    ''disable block
    '                    HideEmail()
    '                    AxImgEdit1.Visible = False
    '                    PictureBox1.Visible = False
    '                    EnableButtonFalse()
    '                    btnPrint.Enabled = False
    '                    ''end of disable block   

    '                    StrGlobalImageId = strPDFID
    '                    strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".pdf"
    '                    strFinalPath = strPdfFolderName & "\" & strNewFileName
    '                    StrGlobalPdfId = strFinalPath
    '                    AxPdf.LoadFile(strFinalPath)
    '                    AxPdf.Show()

    '                    ''visible block
    '                    AxPdf.Visible = True
    '                    btnDelete.Enabled = True
    '                    ''end of visible block

    '                ElseIf strContentType = "4" Then              ''case for image
    '                    'Dim strPDFID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
    '                    'Dim strImgID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()

    '                    'StrGlobalImageId = strPDFID

    '                    'strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".JPG"
    '                    'strFinalPath = strPdfFolderName & "\" & strNewFileName
    '                    'StrGlobalPdfId = strFinalPath


    '                    'AxPdf.Visible = False

    '                    'Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
    '                    'AxImgEdit1.Image = imgPath


    '                    'AxImgEdit1.Visible = True

    '                    'AxImgEdit1.Display()
    '                    'AxImgEdit1.Visible = True
    '                    'HideEmail()
    '                    'AxPdf.Visible = False
    '                    'AxImgEdit1.Visible = False
    '                    'HideEmail()


    '                    'Call DisplayMISCImage()
    '                    'EnableButtonTrue()
    '                    'btnPrint.Enabled = True
    '                    Dim strPDFID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
    '                    StrGlobalImageId = strPDFID
    '                    strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".jpg"
    '                    strFinalPath = strPdfFolderName & "\" & strNewFileName

    '                    ''disable block
    '                    HideEmail()
    '                    AxImgEdit1.Visible = False
    '                    AxPdf.Visible = False
    '                    EnableButtonFalse()
    '                    ''end of disable block   

    '                    PictureBox1.ImageLocation = strFinalPath
    '                    PictureBox1.Show()

    '                    ''visible block
    '                    PictureBox1.Visible = True
    '                    btnPrint.Enabled = True
    '                    btnDelete.Visible = True
    '                    ''end of visible block


    '                End If
    '            Else
    '                AxPdf.Hide()
    '            End If
    '        Else

    '            MsgBox("No Misc . Scanned Document exists...")
    '            Exit Sub
    '        End If

    '    Catch exc As Exception
    '        MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "GetMISCImage", exc.GetBaseException)
    '    End Try
    'End Sub
    'Private Sub DisplayMISCImage()
    '    Dim mStream As MemoryStream
    '    Dim imgStream As Image
    '    Dim strDSContentType As String
    '    Dim strNewFileName As String
    '    Dim strFinalPath As String


    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
    '        lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
    '        strDSContentType = dSetGlobal.Tables("Document").Rows(bManager.Position)("CONTENTTYPE").ToString()
    '        Dim strImgID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()


    '        If strDSContentType = "1" Then
    '            Dim ImageBytes() As Byte = dSetGlobal.Tables("Document").Rows(bManager.Position)("Document")

    '            ''disable block
    '            HideEmail()
    '            AxPdf.Visible = False
    '            PictureBox1.Visible = False
    '            ''end of disable block   


    '            mStream = New MemoryStream(ImageBytes)
    '            imgStream = Image.FromStream(mStream)
    '            Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
    '            imgStream.Save(imgPath)
    '            AxImgEdit1.Image = imgPath
    '            If CInt(strZoomPercentage) <> 0 Then
    '                AxImgEdit1.Zoom = CInt(strZoomPercentage)
    '            End If

    '            ''visible block
    '            AxImgEdit1.Visible = True
    '            EnableButtonTrue()
    '            btnPrint.Enabled = True
    '            ''end of visible block
    '            AxImgEdit1.Display()

    '        ElseIf strDSContentType = "2" Then

    '            ''disable block
    '            AxImgEdit1.Visible = False
    '            AxPdf.Visible = False
    '            PictureBox1.Visible = False
    '            EnableButtonFalse()
    '            btnDelete.Enabled = False
    '            ''end of disable block   

    '            ''visible block
    '            VisibleEmail()
    '            btnPrint.Enabled = True
    '            ''end of visible block

    '        ElseIf strDSContentType = "3" Then
    '            strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".pdf"
    '            ''disable block
    '            HideEmail()
    '            AxImgEdit1.Visible = False
    '            PictureBox1.Visible = False
    '            EnableButtonFalse()
    '            btnPrint.Enabled = False
    '            ''end of disable block   

    '            strFinalPath = strPdfFolderName & "\" & strNewFileName
    '            StrGlobalPdfId = strFinalPath
    '            AxPdf.LoadFile(strFinalPath)
    '            AxPdf.Show()

    '            ''visible block
    '            AxPdf.Visible = True
    '            ''end of visible block

    '        ElseIf strDSContentType = "4" Then
    '            strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".jpg"
    '            strFinalPath = strPdfFolderName & "\" & strNewFileName
    '            ''disable block
    '            HideEmail()
    '            AxImgEdit1.Visible = False
    '            AxPdf.Visible = False
    '            EnableButtonFalse()
    '            ''end of disable block   

    '            PictureBox1.ImageLocation = strFinalPath

    '            ''visible block
    '            PictureBox1.Visible = True
    '            btnPrint.Enabled = True
    '            ''end of visible block
    '            PictureBox1.Show()
    '        End If
    '    Catch exc As Exception
    '        MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "DisplayMISCImage", exc.GetBaseException)
    '    Finally
    '        Me.Cursor = Cursors.Default
    '        mStream = Nothing
    '        imgStream = Nothing
    '    End Try
    'End Sub
    Private Sub GetMISCImage(ByVal strFileNo As Integer)
        'Input :
        '<TA_GETMISCSCANNEDDOCUMENT_INPUT>
        '<FileNo></FileNo>
        '</TA_GETMISCSCANNEDDOCUMENT_INPUT>

        'Output :
        '<TA_GETMISCSCANNEDDOCUMENT_OUTPUT>
        '<Document ID='' Document ='' FileNo='' Order_No='' Status='' FileOrder='' DocType='' Order_Type='' />
        '<Errors Status=''><Error Code='' Description='' />
        '</Errors>
        '</TA_GETMISCSCANNEDDOCUMENT_OUTPUT>

        Dim xInput, xOutput As New XmlDocument
        'Dim dSet As New DataSet
        Dim bztaOrderImage As New AAMS.bizTravelAgency.bzOrder
        Dim strNewFileName As String
        Dim strFinalPath As String
        Dim mStream As MemoryStream
        Dim imgStream As Image
        Dim strDSContentType As String

        Try
            xInput.LoadXml("<TA_GETMISCSCANNEDDOCUMENT_INPUT><LCode></LCode><FileNo></FileNo></TA_GETMISCSCANNEDDOCUMENT_INPUT>")

            xInput.DocumentElement.SelectSingleNode("LCode").InnerText = gblLcode

            If strFileNo = 0 Then
                xInput.DocumentElement.SelectSingleNode("FileNo").InnerText = 0
            Else
                xInput.DocumentElement.SelectSingleNode("FileNo").InnerText = strFileNo

            End If

            dSetGlobal = bztaOrderImage.GetMiscScannedDocument(xInput)

            dSetGlobal.Tables(0).TableName = "Document"

            If (Not dSetGlobal.Tables("Document") Is Nothing) Then
                If dSetGlobal.Tables("Document").Rows.Count > 0 Then
                    bManager = Me.BindingContext(dSetGlobal.Tables("Document"))
                    lblImageID.DataBindings.Add(New Binding("Text", dSetGlobal.Tables("Document"), "ID"))
                    txtFileNo.DataBindings.Add(New Binding("Text", dSetGlobal.Tables("Document"), "FileNo"))
                    txtSequenceNo.DataBindings.Add(New Binding("Text", dSetGlobal.Tables("Document"), "FileOrder"))
                    lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
                    ' txtMailBody.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailBody"))
                    WebBrowser1.DataBindings.Add(New Binding("DocumentText", dSetGlobal, "Document.EmailBody"))

                    txtMailFrom.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailFrom"))
                    txtMailSub.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailSubject"))
                    txtMailTo.DataBindings.Add(New Binding("Text", dSetGlobal, "Document.EmailTo"))
                    Dim strContentType As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ContentType").ToString()
                    strGlobalContentType = strContentType

                    bManager.Position = 0
                    If strContentType = "1" Then ''CASE FOR SCAN DOCUMENT
                        Dim strImgID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
                        StrGlobalImageId = strImgID
                        Dim ImageBytes() As Byte = dSetGlobal.Tables("Document").Rows(bManager.Position)("Document")


                        'Convert byte[] to Base64 String
                        Dim base64String As String = Convert.ToBase64String(ImageBytes)
                        ImageBytes = Convert.FromBase64String(base64String)
                        mStream = New MemoryStream(ImageBytes, 0, ImageBytes.Length)
                        mStream.Write(ImageBytes, 0, ImageBytes.Length)
                        imgStream = Image.FromStream(mStream)
                        Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
                        imgStream.Save(imgPath)
                        ConvertBytesToImageFile(ImageBytes, imgPath)

                        'mStream = New MemoryStream(ImageBytes)
                        'imgStream = Image.FromStream(mStream)
                        'Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
                        'imgStream.Save(imgPath)

                        ''disable block
                        HideEmail()
                        AxPdf.Visible = False
                        PictureBox1.Visible = False
                        ''end of disable block

                        AxImgEdit1.Image = imgPath

                        ''visible block
                        AxImgEdit1.Visible = True
                        EnableButtonTrue()
                        btnPrint.Enabled = True
                        btnDelete.Enabled = True
                        ''end of visible block

                        AxImgEdit1.Display()
                        Call DisplayMISCImage()
                    ElseIf strContentType = "2" Then ''case for E-mail document

                        ''disable block
                        AxImgEdit1.Visible = False
                        AxPdf.Visible = False
                        PictureBox1.Visible = False
                        EnableButtonFalse()
                        btnDelete.Enabled = False
                        ''end of disable block


                        ''visible block
                        VisibleEmail()
                        btnPrint.Enabled = True
                        ''end of visible block

                    ElseIf strContentType = "3" Then ''case for pdf

                        Dim strPDFID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()

                        ''disable block
                        HideEmail()
                        AxImgEdit1.Visible = False
                        PictureBox1.Visible = False
                        EnableButtonFalse()
                        btnPrint.Enabled = False
                        ''end of disable block

                        StrGlobalImageId = strPDFID
                        strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".pdf"
                        strFinalPath = strPdfFolderName & "\" & strNewFileName
                        StrGlobalPdfId = strFinalPath
                        AxPdf.LoadFile(strFinalPath)
                        AxPdf.Show()

                        ''visible block
                        AxPdf.Visible = True
                        btnDelete.Enabled = True
                        ''end of visible block

                    ElseIf strContentType = "4" Then ''case for image
                        'Dim strPDFID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
                        'Dim strImgID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()

                        'StrGlobalImageId = strPDFID

                        'strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".JPG"
                        'strFinalPath = strPdfFolderName & "\" & strNewFileName
                        'StrGlobalPdfId = strFinalPath


                        'AxPdf.Visible = False

                        'Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
                        'AxImgEdit1.Image = imgPath


                        'AxImgEdit1.Visible = True

                        'AxImgEdit1.Display()
                        'AxImgEdit1.Visible = True
                        'HideEmail()
                        'AxPdf.Visible = False
                        'AxImgEdit1.Visible = False
                        'HideEmail()


                        'Call DisplayMISCImage()
                        'EnableButtonTrue()
                        'btnPrint.Enabled = True
                        Dim strPDFID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
                        StrGlobalImageId = strPDFID
                        strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".jpg"
                        strFinalPath = strPdfFolderName & "\" & strNewFileName

                        ''disable block
                        HideEmail()
                        AxImgEdit1.Visible = False
                        AxPdf.Visible = False
                        EnableButtonFalse()
                        ''end of disable block

                        PictureBox1.ImageLocation = strFinalPath
                        PictureBox1.Show()

                        ''visible block
                        PictureBox1.Visible = True
                        btnPrint.Enabled = True
                        btnDelete.Visible = True
                        ''end of visible block


                    End If
                Else
                    AxPdf.Hide()
                End If
            Else

                MsgBox("No Misc . Scanned Document exists...")
                Exit Sub
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "GetMISCImage", exc.GetBaseException)
        End Try
    End Sub

    Private Sub DisplayMISCImage()
        Dim mStream As MemoryStream
        Dim imgStream As Image
        Dim strDSContentType As String
        Dim strNewFileName As String
        Dim strFinalPath As String


        Try
            Me.Cursor = Cursors.WaitCursor

            lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
            lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
            strDSContentType = dSetGlobal.Tables("Document").Rows(bManager.Position)("CONTENTTYPE").ToString()
            Dim strImgID As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()


            If strDSContentType = "1" Then
                Dim ImageBytes() As Byte = dSetGlobal.Tables("Document").Rows(bManager.Position)("Document")

                ''disable block
                HideEmail()
                AxPdf.Visible = False
                PictureBox1.Visible = False
                ''end of disable block

                'mStream = New MemoryStream(ImageBytes)
                'imgStream = Image.FromStream(mStream)
                'Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
                'imgStream.Save(imgPath)

                'Convert byte[] to Base64 String
                Dim base64String As String = Convert.ToBase64String(ImageBytes)
                ImageBytes = Convert.FromBase64String(base64String)
                mStream = New MemoryStream(ImageBytes, 0, ImageBytes.Length)
                mStream.Write(ImageBytes, 0, ImageBytes.Length)
                imgStream = Image.FromStream(mStream)

                Dim imgPath As String = strFilePath & "\" & strImgID & ".tif"
                imgStream.Save(imgPath)

                ConvertBytesToImageFile(ImageBytes, imgPath)



                AxImgEdit1.Image = imgPath
                If CInt(strZoomPercentage) <> 0 Then
                    AxImgEdit1.Zoom = CInt(strZoomPercentage)
                End If

                ''visible block
                AxImgEdit1.Visible = True
                EnableButtonTrue()
                btnPrint.Enabled = True
                ''end of visible block
                AxImgEdit1.Display()

            ElseIf strDSContentType = "2" Then

                ''disable block
                AxImgEdit1.Visible = False
                AxPdf.Visible = False
                PictureBox1.Visible = False
                EnableButtonFalse()
                btnDelete.Enabled = False
                ''end of disable block

                ''visible block
                VisibleEmail()
                btnPrint.Enabled = True
                ''end of visible block

            ElseIf strDSContentType = "3" Then
                strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".pdf"
                ''disable block
                HideEmail()
                AxImgEdit1.Visible = False
                PictureBox1.Visible = False
                EnableButtonFalse()
                btnPrint.Enabled = False
                ''end of disable block

                strFinalPath = strPdfFolderName & "\" & strNewFileName
                StrGlobalPdfId = strFinalPath
                AxPdf.LoadFile(strFinalPath)
                AxPdf.Show()

                ''visible block
                AxPdf.Visible = True
                ''end of visible block

            ElseIf strDSContentType = "4" Then
                strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".jpg"
                strFinalPath = strPdfFolderName & "\" & strNewFileName
                ''disable block
                HideEmail()
                AxImgEdit1.Visible = False
                AxPdf.Visible = False
                EnableButtonFalse()
                ''end of disable block

                PictureBox1.ImageLocation = strFinalPath

                ''visible block
                PictureBox1.Visible = True
                btnPrint.Enabled = True
                ''end of visible block
                PictureBox1.Show()
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "DisplayMISCImage", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
            mStream = Nothing
            imgStream = Nothing
        End Try
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Try
            Dim strDSContentType As String
            Dim strNewFileName As String
            Dim strFinalPath As String

            Me.Cursor = Cursors.WaitCursor
            If bManager Is Nothing Then
                Exit Sub
            End If
            DeleteFiles()

            bManager.Position -= 1
            Dim strid As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
            StrGlobalImageId = strid

            If lblFlag.Text = "MISC" Then
                DisplayMISCImage()
                Exit Sub
            End If


            lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
            strDSContentType = dSetGlobal.Tables("Document").Rows(bManager.Position)("CONTENTTYPE").ToString()
            txtSequenceNo.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
            txtOrderNumber.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("Order_No").ToString()
            txtOrderType.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("Order_Type").ToString()


            If strDSContentType = "1" Then                  'case scan

                ''disable block
                HideEmail()
                AxPdf.Visible = False
                PictureBox1.Visible = False
                ''end of disable block   

                GetImage(strid)

                ''visible block
                AxImgEdit1.Visible = True
                EnableButtonTrue()
                btnPrint.Enabled = True
                btnDelete.Enabled = True
                'end of visible block


            ElseIf strDSContentType = "2" Then              'case E-mail
                ''disable block
                AxImgEdit1.Visible = False
                AxPdf.Visible = False
                PictureBox1.Visible = False
                EnableButtonFalse()
                btnDelete.Enabled = False
                ''end of disable block   

                ''visible block
                VisibleEmail()
                btnPrint.Enabled = True
                txtMailFrom.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailFrom").ToString()
                txtMailSub.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailSubject").ToString()
                txtMailTo.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailTo").ToString()
                WebBrowser1.DocumentText = dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailBody")
                ''end of visible block

            ElseIf strDSContentType = "3" Then              'case PDF
                strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".pdf"
                strFinalPath = strPdfFolderName & "\" & strNewFileName
                ''disable block
                HideEmail()
                AxImgEdit1.Visible = False
                PictureBox1.Visible = False
                EnableButtonFalse()
                btnPrint.Enabled = False
                ''end of disable block   

                StrGlobalPdfId = strFinalPath
                AxPdf.LoadFile(strFinalPath)
                AxPdf.Show()

                ''visible block
                AxPdf.Visible = True
                btnDelete.Enabled = True
                ''end of visible block

            ElseIf strDSContentType = "4" Then              'CASE IMAGES
                strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".jpg"
                strFinalPath = strPdfFolderName & "\" & strNewFileName
                ''disable block
                HideEmail()
                AxImgEdit1.Visible = False
                AxPdf.Visible = False
                EnableButtonFalse()
                ''end of disable block   
                PictureBox1.ImageLocation = strFinalPath

                ''visible block
                PictureBox1.Visible = True
                btnPrint.Enabled = True
                btnDelete.Enabled = True
                ''end of visible block
                PictureBox1.Show()
            Else
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnPrev_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            Dim strDSContentType As String
            Dim strNewFileName As String
            Dim strFinalPath As String
            Me.Cursor = Cursors.WaitCursor
            If bManager Is Nothing Then
                Exit Sub
            End If
            DeleteFiles()
            bManager.Position += 1

            Dim strid As String = dSetGlobal.Tables("Document").Rows(bManager.Position)("ID").ToString()
            StrGlobalImageId = strid

            If lblFlag.Text = "MISC" Then
                DisplayMISCImage()
                Exit Sub
            End If

            
            lblPageScanned.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
            strDSContentType = dSetGlobal.Tables("Document").Rows(bManager.Position)("CONTENTTYPE").ToString()
            txtSequenceNo.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("FileOrder").ToString()
            txtOrderNumber.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("Order_No").ToString()
            txtOrderType.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("Order_Type").ToString()


            If strDSContentType = "1" Then                     'Image
                AxImgEdit1.Visible = True


             ''disable block
                     HideEmail()
                     AxPdf.Visible = False
                     PictureBox1.Visible = False
              ''end of disable block   
                GetImage(strid)

              ''visible block
                    AxImgEdit1.Visible = True
                    EnableButtonTrue()
                    btnPrint.Enabled = True
                    btnDelete.Enabled = True
              'end of visible block

            ElseIf strDSContentType = "2" Then                 ' Email

            ''disable block
                     AxImgEdit1.Visible = False
                     AxPdf.Visible = False
                     PictureBox1.Visible = False
                     EnableButtonFalse()
                     btnDelete.Enabled = False
            ''end of disable block   

            ''visible block
                    VisibleEmail()

                    txtMailFrom.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailFrom").ToString()
                    txtMailSub.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailSubject").ToString()
                    txtMailTo.Text = dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailTo").ToString()

                    WebBrowser1.DocumentText = dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailBody").ToString()

                     btnPrint.Enabled = True
            ''end of visible block

            ElseIf strDSContentType = "3" Then                 'Pdf

                strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".pdf"
                strFinalPath = strPdfFolderName & "\" & strNewFileName

             ''disable block
                     HideEmail()
                     AxImgEdit1.Visible = False
                     PictureBox1.Visible = False
                     EnableButtonFalse()
                     btnPrint.Enabled = False
              ''end of disable block   

                StrGlobalPdfId = strFinalPath
                AxPdf.LoadFile(strFinalPath)
                AxPdf.Show()

             ''visible block
                   AxPdf.Visible = True
                     btnDelete.Enabled = True
             ''end of visible block


             ElseIf strDSContentType = "4" Then                 'Images
                'strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".jpg"
                'strFinalPath = strPdfFolderName & "\" & strNewFileName

                'AxImgEdit1.Visible = True
                'AxImgEdit1.Image = strFinalPath
                'AxImgEdit1.Display()
                'HideEmail()
                'AxPdf.Visible = False
                'EnableButtonTrue()
                'btnPrint.Enabled = True

                strNewFileName = dSetGlobal.Tables("Document").Rows(bManager.Position)("PDFDocFileName").ToString() & ".jpg"
                strFinalPath = strPdfFolderName & "\" & strNewFileName

                ''disable block
                        HideEmail()
                        AxImgEdit1.Visible = False
                        AxPdf.Visible = False
                        EnableButtonFalse()
                ''end of disable block   

               PictureBox1.ImageLocation = strFinalPath

             ''visible block
                       PictureBox1.Visible = True
                       btnPrint.Enabled = True
                       btnDelete.Enabled = True
            ''end of visible block
                    PictureBox1.Show()
            Else
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnNext_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnZoomIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIN.Click
        Try

          If AxImgEdit1.Image.Length <= 0 Then Exit Sub
             ChangeZoom(AxImgEdit1, -2)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnZoomIN_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub ChangeZoom(ByVal ImgControl As AxImgeditLibCtl.AxImgEdit, ByVal Offset As Long)
        Try
            ZoomPercent = AxImgEdit1.Zoom
            ZoomPercent = ZoomPercent + Offset
            If ZoomPercent < 2 Then
                Beep()
                ZoomPercent = 2
            End If
            If ZoomPercent > 500 Then
                Beep()
                ZoomPercent = 500
            End If
            AxImgEdit1.Zoom = ZoomPercent
            ' MsgBox(ZoomPercent)
            AxImgEdit1.Refresh()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "ChangeZoom", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        Try
          If AxImgEdit1.Image.Length <= 0 Then Exit Sub
           ChangeZoom(AxImgEdit1, 2)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnZoomOut_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnFitPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFitPage.Click
        Try
            AxImgEdit1.FitTo(0)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnFitPage_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If AxImgEdit1.Visible = True Then            ''For print scan document
                AxImgEdit1.PrintImage()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If WebBrowser1.Visible = True Then           ''For print web browser content document
                StrAgencyDetail = " <table border=2 align=center><tr><td><b>Agency Name :- " & txtAgencyName.Text & vbCrLf & " <br> " & _
                  " Order No    :- " & txtOrderNumber.Text & " <br> " & _
                  " Order Type  :- " & txtOrderType.Text & "<br>" & _
                  " File No     :- " & txtFileNo.Text & " <br> " & _
                  " Email From  :- " & dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailFrom").ToString() & " <br> " & _
                  " Email To    :- " & dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailTo").ToString() & " <br> " & _
                  " Subject     :- " & dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailSubject").ToString() & "</td></tr></table></b> <br> " & _
                  "<br>" & dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailBody").ToString()
                  WebBrowser2.DocumentText = StrAgencyDetail
                  WebBrowser2.Print()
                  Me.Cursor = Cursors.Arrow
                  Exit Sub
            End If

            If AxPdf.Visible = True Then                 ''For print pdf content document
               AxPdf.printAll()
               Me.Cursor = Cursors.Arrow
               Exit Sub
            End If

            If PictureBox1.Visible = True Then            ''For print images
                PrintDocument1.Print()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If


        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnPrint_Click", exc.GetBaseException)
        Finally
               objPrintPreview = Nothing
               objPrintPreview = Nothing
               Me.Cursor = Cursors.Arrow

        End Try
    End Sub
    Private Sub DeleteFiles(Optional ByVal strDeleteFilePath As String = "", Optional ByVal strPdfPath As String = "")

        Dim oDir As DirectoryInfo
        Dim sFilesInfo As FileInfo

        Try
            If Trim(strDeleteFilePath) = "" Then
                oDir = New DirectoryInfo(strFilePath)
                Dim oDirs As DirectoryInfo() = oDir.GetDirectories()

                For Each sFilesInfo In oDir.GetFiles("*.tif")
                    System.IO.File.Delete(strFilePath & "\" & sFilesInfo.ToString)
                Next

            Else
                If strGlobalContentType = "1" Then
                    oDir = New DirectoryInfo(strFilePath)
                    Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
                    System.IO.File.Delete(strDeleteFilePath)
                ElseIf strGlobalContentType = "3" Then
                    oDir = New DirectoryInfo(strPdfFolderName)
                    Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
                    System.IO.File.Delete(strDeleteFilePath)

                ElseIf strGlobalContentType = "4" Then
                    oDir = New DirectoryInfo(strPdfFolderName)
                    Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
                    System.IO.File.Delete(strDeleteFilePath)

                End If
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "DeleteFiles", exc.GetBaseException)
        Finally
            oDir = Nothing
            sFilesInfo = Nothing
        End Try

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnClose_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
       '******************************************************************************
        'Input Xml :
        '<TA_DELETEAGENCYFILENODETAILS_INPUT>
        '   <AGENCYFILE ID='' FILENO=''  ORDERNO ='' />
        '</TA_DELETEAGENCYFILENODETAILS_INPUT>

        'Output Xml :  
        '<TA_DELETEAGENCYFILENODETAILS_OUTPUT>
        '   <AGENCYFILE ID='' FILENO=''  ORDERNO ='' />
        '<Errors Status=''>
        '   <Error Code='' Description='' />
        '</Errors>
        '</TA_DELETEAGENCYFILENODETAILS_OUTPUT>
        '******************************************************************************

        Dim xInput, xOutput As New XmlDocument
        Dim bztaAgencyFile As New AAMS.bizTravelAgency.bzAgency
        Dim strDeleteImageId As String = ""
        Dim strOrderNumber As String
        Dim ch As Integer
        Try
            blnDeletePress = True
            bmPosition = bManager.Position
           ' MsgBox(bmPosition)

            xInput.LoadXml("<TA_DELETEAGENCYFILENODETAILS_INPUT><AGENCYFILE ID='' FILENO=''  ORDERNO ='' /></TA_DELETEAGENCYFILENODETAILS_INPUT>")
            ch = MsgBox("Are you sure want to delete ? ", MsgBoxStyle.YesNo, "Amadeus Document Management System")
            Me.Cursor = Cursors.WaitCursor
            If ch = 7 Then
                Exit Sub
            Else
                xInput.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("ID").InnerText = StrGlobalImageId
                xInput.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("FILENO").InnerText = txtFileNo.Text & ""
                xInput.DocumentElement.SelectSingleNode("AGENCYFILE").Attributes("ORDERNO").InnerText = txtOrderNumber.Text & ""
                strOrderNumber = txtOrderNumber.Text & ""
                xOutput = bztaAgencyFile.DeleteFile(xInput)
            End If

            If xOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                If strGlobalContentType = "1" Then
                    strDeleteImageId = strFilePath & "\" & StrGlobalImageId & ".tif"
                ElseIf strGlobalContentType = "3" Then
                    strDeleteImageId = strFilePath & "\" & StrGlobalImageId
                ElseIf strGlobalContentType = "4" Then
                    strDeleteImageId = strFilePath & "\" & StrGlobalImageId
                End If

                DeleteFiles(strDeleteImageId) '***************** Delete File Method
                MsgBox("Record deleted Successfully.", MsgBoxStyle.Information, "Amadeus Document Management System")

                Me.Cursor = Cursors.WaitCursor

                bManager = Nothing
                dSetGlobal = Nothing
                dSetGlobal = New DataSet

                ' Clear All Controls
                txtOrderNumber.Text = ""
                txtSequenceNo.Text = ""
                txtOrderType.Text = ""
                lblImageID.Text = ""
                txtFileNo.Text = ""

                WebBrowser1.DocumentText = ""
                txtMailFrom.Text = ""
                txtMailSub.Text = ""
                txtMailTo.Text = ""
                txtFileName.Text = ""
                '***********************

                txtOrderNumber.DataBindings.Clear()
                txtSequenceNo.DataBindings.Clear()
                txtOrderType.DataBindings.Clear()
                lblImageID.DataBindings.Clear()
                txtFileNo.DataBindings.Clear()
                WebBrowser1.DataBindings.Clear()
                txtMailFrom.DataBindings.Clear()
                txtMailSub.DataBindings.Clear()
                txtMailTo.DataBindings.Clear()
                txtFileName.DataBindings.Clear()

                If lblFlag.Text = "MISC" Then
                    BindViewDocument(lblHiddenFileNo.Text.Trim(), True, "")
                Else
                    BindViewDocument(lblHiddenFileNo.Text.Trim(), False, strOrderNumber)
                End If

                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnDelete_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim MyGraphicsPage As Graphics = e.Graphics
        MyGraphicsPage.PageUnit = GraphicsUnit.Inch
        MyGraphicsPage.DrawImage(PictureBox1.Image, 1, 1, PictureBox1.Width, PictureBox1.Height)

    End Sub
End Class

