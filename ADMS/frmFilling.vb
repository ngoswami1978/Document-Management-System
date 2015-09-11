'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmAgencySearch.vb $
'$Workfile: frmFilling.vb $
'$Revision: 28 $
'$Archive: /AAMS/Interface/ADMS/frmFilling.vb $
'$Modtime: 6/02/14 3:19p $
Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
Imports AAMS.bizShared
Public Class frmFilling
    Dim x As Integer
    Dim pos As Integer
    Dim ZoomPercent As Long
    Dim varSequence As Integer
    Dim strFileLocatlPath As String
    Dim strBuilder As New System.Text.StringBuilder
    Dim objbzFileUpload As AAMS.bizTravelAgency.bzAgency
    Dim oDir As DirectoryInfo
    Dim sFilesInfo As FileInfo

    Private Sub frmFilling_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ''new added
         Try
             If lstPic.Items.Count <= 0 Then
                  Exit Sub
             Else
                 DeleteFiles()
            End If

         Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "frmFilling_Disposed", exc.GetBaseException)
         End Try
     ''end

    End Sub
    Private Sub frmFilling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim objSecurityXml As New XmlDocument

            objSecurityXml.LoadXml(SecurityXml)
            If (objSecurityXml.DocumentElement.SelectSingleNode("Administrator").InnerText = "0") Then
                If objSecurityXml.DocumentElement.SelectNodes("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='AGENCY_OFFICE']").Count <> 0 Then
                    strBuilder = SecurityCheck(objSecurityXml.DocumentElement.SelectSingleNode("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='File']").Attributes("Value").Value)
                    If strBuilder(3) = "0" Then
                        btnDelete.Enabled = False
                    End If
                End If
            Else
                strBuilder = SecurityCheck(31)
            End If
            lstPic.Items.Clear()
            SearchFiles(True)

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "frmFilling_Load", exc.GetBaseException)
        End Try
    End Sub
    Private Sub SearchFiles(Optional ByVal boolSetFirstPage As Boolean = False)
        Try
            x = 0
            'Dim oDir As DirectoryInfo
            Dim sFiles As FileInfo
            oDir = New DirectoryInfo(strFilePath)
            Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            lstPic.Items.Clear()

            For Each sFiles In oDir.GetFiles("*.tif")
                x += 1
                lstPic.Items.Add(sFiles)
            Next
            lblPageScanned.Text = x

            If x = 0 Then
                AxImgEdit1.Image = ""
                AxImgEdit1.DisplayBlankImage(1, 1)
                Me.Text = "0"
            End If

            ''Set First Page
            If boolSetFirstPage = True Then
                If x >= 1 Then
                    x = 0
                    strFileLocatlPath = strFilePath + "\" + Trim(lstPic.Items.Item(x).ToString)
                    AxImgEdit1.Image = strFileLocatlPath
                    If CInt(strZoomPercentage) <> 0 Then
                        AxImgEdit1.Zoom = CInt(strZoomPercentage)
                    End If
                    AxImgEdit1.Display()
                    Me.Text = lstPic.Items.Item(x).ToString
                ElseIf x = 0 Then
                    AxImgEdit1.Image = ""
                    AxImgEdit1.DisplayBlankImage(1, 1)
                    Me.Text = "0"
                End If
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "SearchFiles", exc.GetBaseException)
        End Try

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cmd As New SqlCommand
        Dim objSqlConnection As New SqlConnection(bzShared.GetConnectionString())  ''connection string from AAMS
        Try

            Dim varDocType As Integer
            Dim intCounter As Integer
            Dim cOrderType As Integer
            Dim mContentType As Integer
            Dim intRecordEffected As Integer = 0



            Dim ch As Integer

            ch = MsgBox("Are you sure to save Document against LCode : " & gblLcode, MsgBoxStyle.YesNo, "Amadeus Document Management System")

            If ch = 6 Then
                Me.Cursor = Cursors.WaitCursor
                cOrderType = 0
                varSequence = 0
                mContentType = 1
                btnSave.Enabled = False

                If AxImgEdit1.Image = Nothing Then Exit Sub

                If Trim(txtOrderNumber.Text) = "" Then
                    varDocType = 1
                Else
                    varDocType = 2
                End If
                For intCounter = 0 To lstPic.Items.Count - 1
                    strFileLocatlPath = strFilePath + "\" + lstPic.Items.Item(intCounter).ToString
                    varSequence = varSequence + 1
                    Call UploadFile(strFileLocatlPath, Val(txtFileNo.Text), varDocType, varSequence, Trim(txtOrderNumber.Text), Trim(txtOrderType.Text), mContentType, gblLcode)
                Next

                If lstPic.Items.Count >= 1 Then
                    '--- Increase FileNo
                    cmd.CommandText = "UP_ALLOCATE_NEW_TA_FILENO"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = objSqlConnection
                    objSqlConnection.Open()
                    cmd.ExecuteNonQuery()
                    '--- 
                    MsgBox("Record Updated Successfully.", MsgBoxStyle.Information)
                    DeleteFiles()
                End If
            Else
                Exit Sub
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnSave_Click", exc.GetBaseException)
        Finally
            ' DeleteFiles()
            Me.Cursor = Cursors.Arrow
            cmd.Dispose()
            objSqlConnection.Close()
        End Try
    End Sub
    Private Function UploadFile(ByVal gstrFileName As String, ByVal FileNo As Integer, ByVal DocType As Integer, ByVal Sequence As Integer, ByVal mvarOrderNumber As String, ByVal mvarOrderType As String, ByVal mContentType As Integer, ByVal mLcode As Integer) As Boolean

        Dim objOutputXml As XmlDocument
        Dim objInputDoc As XmlDocument
        Dim Encode As New System.Text.ASCIIEncoding
        Try
            objbzFileUpload = New AAMS.bizTravelAgency.bzAgency
            Dim fs As FileStream = New FileStream(gstrFileName, FileMode.Open, FileAccess.Read)
            Dim bReader As BinaryReader = New BinaryReader(fs)
            Dim PhotoByes(fs.Length) As Byte
            PhotoByes = bReader.ReadBytes(fs.Length)
            Dim objSqlCommand As New SqlCommand
            Dim objSqlConnection As New SqlConnection(bzShared.GetDOCConnectionString)

            With objSqlCommand
                '.CommandType = CommandType.StoredProcedure
                '.CommandText = "UP_SRO_TA_FILENO"
                '.Connection = objSqlConnection

                .Parameters.Add(New SqlParameter("@ACTION", SqlDbType.Char, 1))
                .Parameters("@ACTION").Value = "I"

                .Parameters.Add(New SqlParameter("@ID", SqlDbType.Char, 1))
                .Parameters("@ID").Value = "" 'strID

                .Parameters.Add(New SqlParameter("@LCode", SqlDbType.BigInt))
                .Parameters("@LCode").Value = mLcode

                .Parameters.Add(New SqlParameter("@FILENO", SqlDbType.Int))
                .Parameters("@FILENO").Value = FileNo

                .Parameters.Add(New SqlParameter("@ORDERNO", SqlDbType.Char, 40))
                .Parameters("@ORDERNO").Value = mvarOrderNumber

                .Parameters.Add(New SqlParameter("@DOCTYPE", SqlDbType.Int))
                .Parameters("@DOCTYPE").Value = DocType

                .Parameters.Add(New SqlParameter("@SEQUENCE", SqlDbType.Int))
                .Parameters("@SEQUENCE").Value = Sequence

                .Parameters.Add(New SqlParameter("@ORDERTYPE", SqlDbType.Char, 200))
                .Parameters("@ORDERTYPE").Value = mvarOrderType

                .Parameters.Add(New SqlParameter("@ContentType", SqlDbType.SmallInt))
                .Parameters("@ContentType").Value = mContentType


                .Parameters.Add(New SqlParameter("@DOCUMENT", SqlDbType.Image))
                .Parameters("@DOCUMENT").Value = PhotoByes 'strDOCUMENT

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
                .Parameters("@PDFDocFileName").Value = String.Empty

                .Parameters.Add(New SqlParameter("@RETURNID", SqlDbType.BigInt))
                .Parameters("@RETURNID").Direction = ParameterDirection.Output
                .Parameters("@RETURNID").Value = 0

            End With
            objbzFileUpload.UpLoadFile(objSqlCommand)
            fs.Flush()
            fs.Close()

            '################## 3DELETE CURRENT UPLOADED FILE FROM SYSTEM 
            oDir = New DirectoryInfo(strFilePath)
            Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            System.IO.File.Delete(gstrFileName)
            'Kill(gstrFileName)
            'System.IO.File.Delete(gstrFileName)
            '################# END


        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "UploadFile Method", exc.GetBaseException)
        Finally
            objInputDoc = Nothing
            objOutputXml = Nothing
            objbzFileUpload = Nothing
            'fs.close()
            gstrFileName = ""
        End Try
    End Function
    Private Sub DeleteFiles()
        'Dim oDir As DirectoryInfo
        'Dim sFilesInfo As FileInfo

        Try
            SearchFiles(False)

            oDir = New DirectoryInfo(strFilePath)
            Dim oDirs As DirectoryInfo() = oDir.GetDirectories()

            For Each sFilesInfo In oDir.GetFiles("*.tif")
                System.IO.File.Delete(strFilePath & "\" & sFilesInfo.Name)
            Next

            ' SearchFiles(False)

        Catch exc As Exception
            'MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "DeleteFiles", exc.GetBaseException)
        Finally
            oDir = Nothing
            sFilesInfo = Nothing
        End Try
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        Try
            If lstPic.Items.Count = 0 Then
                MsgBox("No  Document found", MsgBoxStyle.Information, "AAMS")
                Exit Sub
            End If
            x = x + 1

            If x = lstPic.Items.Count Then
                x = lstPic.Items.Count - 1
                'MsgBox("End")
                Exit Sub
            End If


            If x = -1 Then
                x = lstPic.Items.Count - 1
            End If

            strFileLocatlPath = strFilePath + "\" + Trim(lstPic.Items.Item(x).ToString)
            AxImgEdit1.Image = strFileLocatlPath
            If CInt(strZoomPercentage) <> 0 Then
                AxImgEdit1.Zoom = CInt(strZoomPercentage)
            End If
            AxImgEdit1.Display()
            Me.Text = lstPic.Items.Item(x).ToString

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnNext_Click", exc.GetBaseException)
        End Try


''Try

        ''   If lstPic.Items.Count = 0 Then
        ''        MsgBox("Number of Scanned Document not exists..", MsgBoxStyle.Information, "AAMS")
        ''        Exit Sub
        ''    End If


        ''    If pos >= lstPic.Items.Count Then
        ''        MsgBox("End")
        ''        Exit Sub
        ''    End If

        ''    pos = pos + 1


        ''    If pos = -1 Then
        ''        pos = lstPic.Items.Count - 1
        ''    End If

        ''    strFileLocatlPath = strFilePath + "\" + Trim(lstPic.Items.Item(pos - 1).ToString)
        ''    AxImgEdit1.Image = strFileLocatlPath

        ''    If CInt(strZoomPercentage) <> 0 Then
        ''        AxImgEdit1.Zoom = CInt(strZoomPercentage)
        ''    End If
        ''    AxImgEdit1.Display()
        ''    Me.Text = lstPic.Items.Item(pos - 1).ToString

        ''Catch exc As Exception
        ''    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
        ''    Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnNext_Click", exc.GetBaseException)
        ''End Try

    End Sub
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click

        Try
            If lstPic.Items.Count = 0 Then
                MsgBox("No of Scanned Document not exists..", MsgBoxStyle.Information, "AAMS")
                Exit Sub
            End If
            x = x - 1

            If x = lstPic.Items.Count Then
                x = 0
            End If
            If x = -1 Then
                x = 0
                ' MsgBox("Start")
                Exit Sub
            End If


            strFileLocatlPath = strFilePath + "\" + Trim(lstPic.Items.Item(x).ToString)
            AxImgEdit1.Image = strFileLocatlPath
            If CInt(strZoomPercentage) <> 0 Then
                AxImgEdit1.Zoom = CInt(strZoomPercentage)
            End If
            AxImgEdit1.Display()
            Me.Text = lstPic.Items.Item(x).ToString

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnNext_Click", exc.GetBaseException)
        End Try


        'Try
        '    If lstPic.Items.Count = 0 Then
        '        MsgBox("No of Scanned Document not exists..", MsgBoxStyle.Information, "AAMS")
        '        Exit Sub
        '    End If



        '     If pos <= 0 Then
        '         MsgBox("Start")
        '        Exit Sub
        '    End If

        '     pos = pos - 1
        '    strFileLocatlPath = strFilePath + "\" + Trim(lstPic.Items.Item(pos).ToString)
        '    AxImgEdit1.Image = strFileLocatlPath
        '    If CInt(strZoomPercentage) <> 0 Then
        '        AxImgEdit1.Zoom = CInt(strZoomPercentage)
        '    End If
        '    AxImgEdit1.Display()
        '    Me.Text = lstPic.Items.Item(pos).ToString

        'Catch exc As Exception
        '    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
        '    Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnNext_Click", exc.GetBaseException)
        'End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            If lstPic.Items.Count <= 0 Then
                Me.Close()
            Else
                DeleteFiles()
                Me.Close()
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnNext_Click", exc.GetBaseException)
        End Try


    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oDir As DirectoryInfo

        Try
            SearchFiles(False)

            oDir = New DirectoryInfo(strFilePath)
            Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            System.IO.File.Delete(strFileLocatlPath)

            SearchFiles(True)

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnDelete_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnZoomIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIN.Click
        Try
            ChangeZoom(AxImgEdit1, -2)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnZoomIN_Click", exc.GetBaseException)
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
            AxImgEdit1.Refresh()

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "ChangeZoom", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        Try
            ChangeZoom(AxImgEdit1, 2)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnZoomOut_Click", exc.GetBaseException)
        End Try

    End Sub
    Private Sub btnFitPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFitPage.Click
        Try
            AxImgEdit1.FitTo(0)

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmFilling", "btnFitPage_Click", exc.GetBaseException)
        End Try
    End Sub

    
  
End Class