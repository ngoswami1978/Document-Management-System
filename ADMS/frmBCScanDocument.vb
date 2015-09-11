Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
Imports AAMS.bizShared
Public Class frmBCScanDocument
    Dim x As Integer
    Dim pos As Integer
    Dim ZoomPercent As Long
    Dim varSequence As Integer
    Dim strFileLocatlPath As String
    Dim strBuilder As New System.Text.StringBuilder
    Dim objbzFileUpload As AAMS.bizTravelAgency.bzAgency
    Dim oDir As DirectoryInfo
    Dim sFilesInfo As FileInfo
    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        Try
            ChangeZoom(AxImgEdit1, -2)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnZoomOut_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnZoomIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIN.Click
        Try
            ChangeZoom(AxImgEdit1, 2)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnZoomIN_Click", exc.GetBaseException)
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
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "ChangeZoom", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnFitPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFitPage.Click
        Try
            AxImgEdit1.FitTo(0)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnFitPage_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oDir As DirectoryInfo
        Try
            If MsgBox("Are you sure to delete?", MsgBoxStyle.OkCancel, "ADMS") = MsgBoxResult.Cancel Then Exit Sub
            SearchFiles(False)
            oDir = New DirectoryInfo(strFilePath)
            Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            System.IO.File.Delete(strFileLocatlPath)
            SearchFiles(True)
            If AxImgEdit1.Image = Nothing Then Me.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnDelete_Click", exc.GetBaseException)
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
            'AxImgEdit1.ClearDisplay()
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
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "SearchFiles", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            frmBusinessCaseSearch.imgFileScan.ResetScanner()
            If lstPic.Items.Count <= 0 Then
                Me.Close()
            Else
                DeleteFiles()
                Me.Close()
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnClose_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub DeleteFiles()
        Dim oDir As DirectoryInfo
        Dim sFilesInfo As FileInfo
        Try

            GC.Collect()
            GC.WaitForPendingFinalizers()

            SearchFiles(False)
            ' AxImgEdit1 = Nothing
            oDir = New DirectoryInfo(strFilePath)
            Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            ' sFilesInfo = Nothing
            lstPic.Items.Clear()

            For Each sFilesInfo In oDir.GetFiles("*.tif")
                'System.IO.File.SetAttributes(strFilePath & "\" & sFilesInfo.Name, FileAttributes.Normal)
                System.IO.File.Delete(strFilePath & "\" & sFilesInfo.Name)
            Next
            For Each sFilesInfo In oDir.GetFiles("*.pdf")
                System.IO.File.Delete(strFilePath & "\" & sFilesInfo.Name)
            Next
            ' SearchFiles(False)
        Catch exc As Exception
            'MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "DeleteFiles", exc.GetBaseException)
        Finally
            oDir = Nothing
            sFilesInfo = Nothing
        End Try
    End Sub
    Private Function UploadFile(ByVal gstrFileName As String) As Boolean
        Dim objOutputXml As XmlDocument
        Dim objInputDoc As XmlDocument
        Dim Encode As New System.Text.ASCIIEncoding
        Dim intReturnid As Integer
        Dim fs As FileStream = New FileStream(gstrFileName, FileMode.Open, FileAccess.Read)
        Dim bReader As BinaryReader = New BinaryReader(fs)
        Dim PhotoByes(fs.Length) As Byte

        Try
            'Dim objbzFileUpload As New AAMS.bizIncetive.bzBusinessCase
            GC.Collect()
            GC.WaitForPendingFinalizers()

            PhotoByes = bReader.ReadBytes(fs.Length)
            Dim objSqlCommand As New SqlCommand
            Dim objSqlConnection As New SqlConnection(bzShared.GetDOCConnectionString)
            With objSqlCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "UP_SRO_INC_UPLOAD_CONTRACT_SIDELETTER"
                .Connection = objSqlConnection

                .Parameters.Add(New SqlParameter("@ACTION", SqlDbType.Char, 1))
                .Parameters("@ACTION").Value = "I"

                .Parameters.Add(New SqlParameter("@CHAIN_CODE", SqlDbType.BigInt))
                .Parameters("@CHAIN_CODE").Value = CInt(txtChainCode.Text)

                .Parameters.Add(New SqlParameter("@BC_ID", SqlDbType.Int))
                .Parameters("@BC_ID").Value = CInt(txtBCID.Text)

                .Parameters.Add(New SqlParameter("@DOCTYPE", SqlDbType.Int))
                .Parameters("@DOCTYPE").Value = drpLetterType.SelectedIndex

                .Parameters.Add(New SqlParameter("@DOCUMENT", SqlDbType.Image))
                .Parameters("@DOCUMENT").Value = PhotoByes

                .Parameters.Add(New SqlParameter("@EMPLOYEEID", SqlDbType.Int))
                .Parameters("@EMPLOYEEID").Value = CInt(strEmpId)

                .Parameters.Add(New SqlParameter("@RETURNID", SqlDbType.BigInt))
                .Parameters("@RETURNID").Direction = ParameterDirection.Output
                .Parameters("@RETURNID").Value = 0
                .Connection.Open()

            End With
            objSqlCommand.ExecuteNonQuery()
            intReturnid = objSqlCommand.Parameters("@RETURNID").Value
            fs.Flush()
            fs.Close()
            fs.Dispose()
            bReader.Close()


            '################## DELETE CURRENT UPLOADED FILE FROM SYSTEM 
            oDir = New DirectoryInfo(strFilePath)
            Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
            System.IO.File.Delete(gstrFileName)
            'Kill(gstrFileName)
            'System.IO.File.Delete(gstrFileName)
            '################# END
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "UploadFile", exc.GetBaseException)
        Finally
            objInputDoc = Nothing
            objOutputXml = Nothing
            objbzFileUpload = Nothing
            fs.Flush()
            fs.Close()
            fs.Dispose()
            bReader.Close()

            gstrFileName = ""
        End Try
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cmd As New SqlCommand
        Dim objSqlConnection As New SqlConnection(bzShared.GetConnectionString())  ''connection string from AAMS
        Try
            Dim intCounter As Integer
            Dim cOrderType As Integer
            Dim mContentType As Integer
            Dim intRecordEffected As Integer = 0
            Dim bln As Boolean = False
            Dim ch As Integer

            GC.Collect()
            GC.WaitForPendingFinalizers()

            If AxImgEdit1.Image = Nothing Then
                MsgBox("No Document found", MsgBoxStyle.Information, "AAMS")
                Exit Sub
            End If
            If drpLetterType.SelectedIndex = 0 Then
                MsgBox("Please Select Letter Type", MsgBoxStyle.Critical, "Amadeus Document Management System")
                drpLetterType.Focus()
                Exit Sub
            End If
            ch = MsgBox("Are you sure to save Document against BCID : " & txtBCID.Text, MsgBoxStyle.YesNo, "Amadeus Document Management System")
            If ch = 6 Then
                ''check for type******************************** no more requirement ***********************************
                'If (drpLetterType.SelectedIndex = 1 And blnContractLetter = True) Then
                '	MsgBox("You have already contact letter  against BCID : " & txtBCID.Text, MsgBoxStyle.Critical, "Amadeus Document Management System")
                '	Exit Sub
                'End If

                'If (drpLetterType.SelectedIndex = 2 And blnSideLetter = True) Then
                '	MsgBox("You have already side letter  against BCID : " & txtBCID.Text, MsgBoxStyle.Critical, "Amadeus Document Management System")
                '	Exit Sub
                'End If
                ''end type check


                Me.Cursor = Cursors.WaitCursor
                cOrderType = 0
                varSequence = 0
                mContentType = 1
                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnNext.Enabled = False
                btnPrev.Enabled = False
                btnZoomIN.Enabled = False
                btnZoomOut.Enabled = False
                btnFitPage.Enabled = False
                If AxImgEdit1.Image = Nothing Then Exit Sub
                Dim ObjFileList As New ArrayList
                For intCounter = 0 To lstPic.Items.Count - 1
                    strFileLocatlPath = strFilePath + "\" + lstPic.Items.Item(intCounter).ToString
                    varSequence = varSequence + 1
                    ObjFileList.Add(strFileLocatlPath)
                Next
                Dim objAAMSPDFConvert As New AAMSPDFConverter
                Dim strPDFFileName As String = strFilePath & "\BCDOC" + txtBCID.Text.ToString & ".pdf"
                Dim strRportPath As String = Application.StartupPath + "\BCDocument.rpt"

                objAAMSPDFConvert.CreatePDFFromImage(txtBCID.Text.Trim, strFilePath, ObjFileList, strRportPath)

                If File.Exists(strPDFFileName) Then
                    If UploadPDFFile(strPDFFileName) = True Then
                        bln = True
                        '@ Start ofDelete All Files 
                        oDir = New DirectoryInfo(strFilePath)
                        Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
                        For Each sFilesInfo In oDir.GetFiles()
                            Try
                                lstPic.Items.Clear()
                                AxImgEdit1.ClearDisplay()
                                AxImgEdit1.Image = String.Empty
                                'AxImgEdit1.Image = Nothing
                                System.IO.File.Delete(strFilePath & "\" & sFilesInfo.Name)
                            Catch ex As Exception
                            End Try
                        Next
                        '@ End of  Delete All Files 
                    Else
                        bln = False
                    End If
                    'call method to save images
                End If
            End If
            If bln = True Then
                MsgBox("Record Updated Successfully.", MsgBoxStyle.Information)
                DeleteFiles()
                blnJAMError = False
                ' AxImgEdit1.Image = Nothing
                btnDelete.Enabled = False
                btnNext.Enabled = False
                btnPrev.Enabled = False
                btnZoomIN.Enabled = False
                btnZoomOut.Enabled = False
                btnFitPage.Enabled = False
            Else
                btnSave.Enabled = True
                btnDelete.Enabled = True
                btnNext.Enabled = True
                btnPrev.Enabled = True
                btnZoomIN.Enabled = True
                btnZoomOut.Enabled = True
                btnFitPage.Enabled = True
                Exit Sub
                ' MsgBox("Record already exist.", MsgBoxStyle.Information)
            End If
        Catch exc As Exception
            ' MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnSave_Click", exc.GetBaseException)
            btnSave.Enabled = True
        Finally
            ' DeleteFiles()
            Me.Cursor = Cursors.Arrow
            cmd.Dispose()
            lstPic.Dispose()
            objSqlConnection.Close()
        End Try
    End Sub
    Private Sub frmBCScanDocument_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim ch As Integer

        GC.Collect()
        GC.WaitForPendingFinalizers()

        If blnJAMError = True Then
            ch = MsgBox("Would you like to restore scanned paper of BCID : " & txtBCID.Text & " , due to paper jammed", MsgBoxStyle.YesNo, "Amadeus Document Management System")
            If ch = 6 Then
                '////////////////// Code to save the scanned paper as it is and also get the maxmimum value of scanned paper///////////////////////////////
                blnJAMError = True
                '//////////////////////////////////////////////////////////////////////////////////////////
            Else
                DeleteFiles()
                blnJAMError = False
            End If
        Else
            DeleteFiles()
            blnJAMError = False
            'Dim ob As New frmBusinessCaseSearch
        End If
        'ob.frmBusinessCaseSearch_Load(sender, e)
        Me.Close()
    End Sub

    Private Sub frmBCScanDocument_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub frmBCScanDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If AxImgEdit1.Image = Nothing Then
            ' MsgBox("hi")
            AxImgEdit1.Image = ""
            AxImgEdit1.DisplayBlankImage(1, 1)
        End If
        fill_LetterType()
    End Sub
    Private Sub fill_LetterType()
        Try
            Dim objLetterType As New DataTable
            objLetterType.Columns.Add("ID")
            objLetterType.Columns.Add("Value")
            objLetterType.Rows.Add("--Select--", "")
            objLetterType.Rows.Add("Contract", "1")
            objLetterType.Rows.Add("Side Letter", "2")
            objLetterType.Rows.Add("Misc Document", "3")
            drpLetterType.DataSource = objLetterType
            drpLetterType.DisplayMember = "ID"
            drpLetterType.ValueMember = "Value"
            ' objTablePLBType = Nothing
            lstPic.Items.Clear()
            SearchFiles(True)
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "fill_LetterType", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            If lstPic.Items.Count = 0 Then
                MsgBox("No Document found..", MsgBoxStyle.Information, "Amadeus Document Management System")
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
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnNext_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Try
            If lstPic.Items.Count = 0 Then
                MsgBox("No Document found..", MsgBoxStyle.Information, "Amadeus Document Management System")
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
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnPrev_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Function UploadPDFFile(ByVal gstrFileName As String) As Boolean
        Dim blnSucceed As Boolean = False
        Dim objOutputXml As XmlDocument
        Dim objInputDoc As XmlDocument
        Dim Encode As New System.Text.ASCIIEncoding
        Dim intReturnid As Integer
        Dim Streamread As Stream = New IO.FileStream(gstrFileName, FileMode.Open)
        Dim PhotoByes As Byte()
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()

            PhotoByes = New Byte(Streamread.Length - 2) {}
            Streamread.Read(PhotoByes, 0, PhotoByes.Length)
            Streamread.Flush()
            Streamread.Close()
            Dim objSqlCommand As New SqlCommand
            Dim objSqlConnection As New SqlConnection(bzShared.GetDOCConnectionString)
            With objSqlCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "UP_SRO_INC_UPLOAD_CONTRACT_SIDELETTER"
                .Connection = objSqlConnection
                .Parameters.Add(New SqlParameter("@ACTION", SqlDbType.Char, 1))
                .Parameters("@ACTION").Value = "I"
                .Parameters.Add(New SqlParameter("@CHAIN_CODE", SqlDbType.BigInt))
                .Parameters("@CHAIN_CODE").Value = CInt(txtChainCode.Text)
                .Parameters.Add(New SqlParameter("@BC_ID", SqlDbType.Int))
                .Parameters("@BC_ID").Value = CInt(txtBCID.Text)
                .Parameters.Add(New SqlParameter("@DOCTYPE", SqlDbType.Int))
                .Parameters("@DOCTYPE").Value = drpLetterType.SelectedValue
                .Parameters.Add(New SqlParameter("@DOCUMENT", SqlDbType.Image))
                .Parameters("@DOCUMENT").Value = PhotoByes
                .Parameters.Add(New SqlParameter("@EMPLOYEEID", SqlDbType.Int))
                .Parameters("@EMPLOYEEID").Value = CInt(strEmpId)
                .Parameters.Add(New SqlParameter("@RETURNID", SqlDbType.BigInt))
                .Parameters("@RETURNID").Direction = ParameterDirection.Output
                .Parameters("@RETURNID").Value = 0
                .Connection.Open()
            End With
            objSqlCommand.ExecuteNonQuery()
            intReturnid = objSqlCommand.Parameters("@RETURNID").Value
            Streamread.Close()
            Streamread.Dispose()

            '################## 3DELETE CURRENT UPLOADED FILE FROM SYSTEM 
            If intReturnid > 0 Then
                blnSucceed = True
                'oDir = New DirectoryInfo(strFilePath)
                'Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
                'System.IO.File.Delete(gstrFileName)
                'ChangeAtrib()
                'DeleteFiles()
                'ChangeAtrib()
            Else
                blnSucceed = False
            End If
            'Kill(gstrFileName)
            'System.IO.File.Delete(gstrFileName)
            '################# END
            Return blnSucceed
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "UploadFile", exc.GetBaseException)
            Return blnSucceed
        Finally
            objInputDoc = Nothing
            objOutputXml = Nothing
            PhotoByes = Nothing
            gstrFileName = ""
            Streamread.Close()
            Streamread.Dispose()

        End Try
    End Function
End Class