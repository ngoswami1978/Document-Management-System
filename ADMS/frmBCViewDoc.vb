Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Data.DataSet
Imports System.Drawing.Printing
Imports System.Drawing.Graphics
Public Class frmBCViewDoc
    Dim strBuilder As New System.Text.StringBuilder
    Dim dSetGlobal As New DataSet
    Dim bManager As BindingManagerBase
    Dim ZoomPercent As Long
    Dim press As Integer
    Dim StrGlobalImageId As String
    Dim blnDeletePress As Boolean
    Dim bmPosition As Integer
    Dim objPrintPreview As New PrintPreviewDialog
    Dim objPrintDoc As New PrintDocument
    Dim strBCaseID As String
    Dim strChainCode As String = String.Empty
    Dim arrBCID As New ArrayList
    Dim currentIndex As Integer = 0
    Dim flgDone As Boolean
    Public Sub New(ByVal _strBCID As String, ByVal x As Integer, Optional ByVal isVisible As Boolean = True)
        MyBase.New()
        strBCaseID = _strBCID
        InitializeComponent()
        lblAoffice.Visible = isVisible
        txtAoffice.Visible = isVisible
    End Sub
    Public Sub New(ByVal _strChainCode As String, ByVal strCodeType As String, Optional ByVal isVisible As Boolean = True)
        MyBase.New()
        If strCodeType = "ChainCode" Then
            strChainCode = _strChainCode
        End If
        InitializeComponent()
        lblAoffice.Visible = isVisible
        txtAoffice.Visible = isVisible
    End Sub
    Private Sub btnViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor
            bManager = Nothing
            dSetGlobal = Nothing
            txtAgencyName.Text = ""
            txtChaincode.Text = ""
            txtAoffice.Text = ""
            txtValidfrom.Text = ""
            txtValidTo.Text = ""
            txtPaymentMode.Text = ""
            txtslabtype.Text = ""
            txtCurrentpage.Text = ""
            txtTotalPage.Text = ""
            dSetGlobal = New DataSet
            lblImageID.DataBindings.Clear()
            'Call view
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "btnViewAll_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub BindViewDocument()
        Dim bzobjBusinesscase As New AAMS.bizIncetive.bzBusinessCase
        Dim xInput, xOutput As New XmlDocument
        Dim m_objdsSelect As New DataSet
        Dim xReader As XmlNodeReader
        Try
            Me.Cursor = Cursors.WaitCursor
            xInput.LoadXml("<INC_SEARCH_SCANNEDCONTRACT_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><EMPLOYEEID></EMPLOYEEID><DOCTYPE></DOCTYPE></INC_SEARCH_SCANNEDCONTRACT_INPUT>")
            xInput.DocumentElement.SelectSingleNode("BC_ID").InnerText = strBCaseID
            'xInput.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = txtChaincode.Text
            xInput.DocumentElement.SelectSingleNode("EMPLOYEEID").InnerText = strEmpId
            xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = "" ' ------- default doctype is 1 means 'Contract'
            xOutput = bzobjBusinesscase.GetContractDetails(xInput)
            If xOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                xReader = New XmlNodeReader(xOutput)
                dSetGlobal.Clear()
                dSetGlobal.ReadXml(xReader)
                ''*******************************************ashish added for view all types (1,2,3) documents---------------------
                gblDScontractSideLetter.Clear()
                xReader = New XmlNodeReader(xOutput)
                gblDScontractSideLetter.ReadXml(xReader)
                ''*******************************populate datatable for contract************************************************    
                Dim objNodeContract As XmlNode
                Dim objnodelistContract As XmlNodeList = xOutput.SelectNodes("INC_SEARCH_BUSINESSCASE_OUTPUT/SCANNEDCONTRACT[@DOCTYPE='Contract']")
                Dim rowContractletter() As DataRow
                rowContractletter = gblDScontractSideLetter.Tables("SCANNEDCONTRACT").Select("DOCTYPE='Contract'")
                If rowContractletter IsNot Nothing Then
                    gblDTContractLetter.Columns.Clear()
                    gblDTContractLetter.Rows.Clear()
                    gblDTContractLetter.TableName = ""
                    gblDTContractLetter.TableName = "ContractLetter"
                    gblDTContractLetter.Columns.Add("SRNO", GetType(Integer))
                    gblDTContractLetter.Columns.Add("CONTRACTTYPE", GetType(String))
                    'For Each objNodeContract In objnodelistContract
                    '    drpSRNO.Items.Add(objNodeContract.Attributes("SRNO").InnerText)
                    'Next
                    ''populate datatable
                    For Each row As DataRow In gblDScontractSideLetter.Tables("SCANNEDCONTRACT").Select("DOCTYPE='Contract'")
                        gblDTContractLetter.Rows.Add(row("SRNO").ToString(), row("DOCTYPE"))
                    Next
                End If
                '**************************************end populate ********************************************************    


                ''*******************************populate datatable for side letter******************************************
                Dim objNodeSide As XmlNode
                Dim objnodelistSide As XmlNodeList = xOutput.SelectNodes("INC_SEARCH_BUSINESSCASE_OUTPUT/SCANNEDCONTRACT[@DOCTYPE='Side letter']")

                ''bind contarct letter by default
                Dim rowSideletter() As DataRow
                rowSideletter = gblDScontractSideLetter.Tables("SCANNEDCONTRACT").Select("DOCTYPE='Side letter'")
                If rowSideletter IsNot Nothing Then
                    gblDTSideLetter.Columns.Clear()
                    gblDTSideLetter.Rows.Clear()
                    gblDTSideLetter.TableName = ""
                    gblDTSideLetter.TableName = "SideLetter"
                    gblDTSideLetter.Columns.Add("SRNO", GetType(Integer))
                    gblDTSideLetter.Columns.Add("CONTRACTTYPE", GetType(String))
                    'If rowContractletter Is Nothing Then
                    '    For Each objNodeSide In objnodelistSide
                    '        drpSRNO.Items.Add(objNodeSide.Attributes("SRNO").InnerText)
                    '    Next
                    'End If
                    ''populate datatable
                    For Each row As DataRow In gblDScontractSideLetter.Tables("SCANNEDCONTRACT").Select("DOCTYPE='Side letter'")
                        gblDTSideLetter.Rows.Add(row("SRNO").ToString(), row("DOCTYPE"))
                    Next
                End If
                '**************************************end populate ********************************************************    

                ''*******************************populate datatable for MISC Document****************************************
                Dim objNodeMisc As XmlNode
                Dim objnodelistMisc As XmlNodeList = xOutput.SelectNodes("INC_SEARCH_BUSINESSCASE_OUTPUT/SCANNEDCONTRACT[@DOCTYPE='Misc Document']")

                ''bind contarct letter by default
                Dim rowMiscDocument() As DataRow
                rowMiscDocument = gblDScontractSideLetter.Tables("SCANNEDCONTRACT").Select("DOCTYPE='Misc Document'")
                If rowMiscDocument IsNot Nothing Then

                    gblDTMiscDocument.Columns.Clear()
                    gblDTMiscDocument.Rows.Clear()
                    gblDTMiscDocument.TableName = ""

                    gblDTMiscDocument.TableName = "MISCDocument"
                    gblDTMiscDocument.Columns.Add("SRNO", GetType(Integer))
                    gblDTMiscDocument.Columns.Add("CONTRACTTYPE", GetType(String))

                    'If rowMiscDocument Is Nothing Then
                    '    For Each objNodeSide In objnodelistMisc
                    '        drpSRNO.Items.Add(objNodeSide.Attributes("SRNO").InnerText)
                    '    Next
                    'End If
                    ''populate datatable
                    For Each row As DataRow In gblDScontractSideLetter.Tables("SCANNEDCONTRACT").Select("DOCTYPE='Misc Document'")
                        gblDTMiscDocument.Rows.Add(row("SRNO").ToString(), row("DOCTYPE"))
                    Next
                End If
                '**************************************end populate ********************************************************    



                ''***************************************end here , work for view all type document***********************************(

                bManager = Me.BindingContext(dSetGlobal.Tables("SCANNEDCONTRACT"))
                If dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count > 0 Then
                    lblImageID.DataBindings.Clear()
                    lblImageID.DataBindings.Add(New Binding("Text", dSetGlobal, "SCANNEDCONTRACT.ID"))
                    AxAcroPDF1.Hide()

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
                    txtAgencyName.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("GROUP_NAME").ToString()
                    txtChaincode.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("CHAIN_CODE").ToString()
                    txtAoffice.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("AOFFICE").ToString()
                    txtBCID.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_ID").ToString()
                    txtValidfrom.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_EFFECTIVE_FROM").ToString()
                    txtValidTo.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_VALID_TILL").ToString()
                    txtPaymentMode.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("INC_TYPE_NAME").ToString()
                    txtslabtype.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("PAYMENTTYPENAME").ToString()

                    If dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count > 0 And dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("ID").ToString() <> "" Then
                        txtTotalPage.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count.ToString
                        txtCurrentpage.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("SRNO").ToString()
                        txtDocType.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString()
                        drpLetterType.SelectedValue = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString()

                        If drpLetterType.SelectedValue Is Nothing Then
                            drpLetterType.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString()
                        End If
                        Dim strid As String = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("ID").ToString()
                        StrGlobalImageId = strid
                        'GetImage(strid)
                        EnableButtonTrue()
                        btnPrev.Enabled = True
                        btnNext.Enabled = True
                    Else
                        txtDocType.Text = ""
                        btnPrev.Enabled = False
                        btnNext.Enabled = False
                        EnableButtonFalse()
                    End If

                    If currentIndex = 0 Then
                        btnPrev.Enabled = False
                    Else
                        btnPrev.Enabled = True
                    End If

                    If currentIndex >= arrBCID.Count - 1 Then
                        btnNext.Enabled = False
                    Else
                        btnNext.Enabled = True
                    End If

                End If
            Else
                txtCurrentpage.Text = ""
                txtTotalPage.Text = ""
                txtAgencyName.Text = ""
                txtChaincode.Text = ""
                txtAoffice.Text = ""
                txtValidfrom.Text = ""
                txtValidTo.Text = ""
                txtPaymentMode.Text = ""
                txtslabtype.Text = ""
                txtDocType.Text = ""
                txtChaincode.Text = ""
                txtBCID.Text = ""
                lblImageID.Text = ""
                'AxImgEdit1.Visible = False
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "BindViewDocument", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ViewAllDocumentChainCode()
        Dim bzobjBusinesscase As New AAMS.bizIncetive.bzBusinessCase
        Dim xInput, xOutput As New XmlDocument
        Try
            Me.Cursor = Cursors.WaitCursor
            xInput.LoadXml("<INC_SEARCH_BUSINESSCASE_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><CHAIN_NAME></CHAIN_NAME><BC_EFFECTIVE_FROM></BC_EFFECTIVE_FROM><BC_VALID_TILL></BC_VALID_TILL><PAGE_NO></PAGE_NO><PAGE_SIZE></PAGE_SIZE><SORT_BY/><DESC/><EmployeeID></EmployeeID><INC_TYPE_ID></INC_TYPE_ID><PAYMENTTYPEID></PAYMENTTYPEID><UPFRONTTYPEID></UPFRONTTYPEID><PLBTYPEID></PLBTYPEID><ADJUSTABLE></ADJUSTABLE><PLBSLAB></PLBSLAB><FINAL_APPROVE>True</FINAL_APPROVE></INC_SEARCH_BUSINESSCASE_INPUT>")
            xInput.DocumentElement.SelectSingleNode("EmployeeID").InnerText = strEmpId
            xInput.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = strChainCode

            xOutput = bzobjBusinesscase.SearchAll_ADMS(xInput)

            'xOutput.Load("C:\TEST.XML")

            If xOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                Dim objNodeList As XmlNodeList
                objNodeList = xOutput.DocumentElement.SelectNodes("BUSINESSCASE")
                Dim i As Integer = 0
                For Each objLoopNode As XmlNode In objNodeList
                    If objLoopNode.Attributes("DOCTYPE").Value.Trim() <> "" Then
                        arrBCID.Add(objLoopNode.Attributes("BC_ID").Value & "," & objLoopNode.Attributes("DOCTYPE").Value & "," & objLoopNode.Attributes("SRNO").Value)
                    End If
                Next
                currentIndex = 0
                strBCaseID = arrBCID(currentIndex)  'Take BCID at index=0
                'strBCaseID = arrBCID(currentIndex).ToString.Split(",")(0) 'Take BCID at index=0 

                BindViewAllDocument()
            End If

            btnDelete.Enabled = False
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "BindViewDocument", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub GetImage(ByVal strImgID As String)
        Dim xInput, xOutput As New XmlDocument
        Dim dSet As New DataSet
        Dim bzobjBusinesscase As New AAMS.bizIncetive.bzBusinessCase
        Dim mStream As MemoryStream
        Dim imgStream As Image
        Dim StreamWtite As Stream
        Try
            'AxImgEdit1.Visible = True
            EnableButtonTrue()
            xInput.LoadXml("<TA_GETSCANNEDIMAGE_INPUT><ID></ID></TA_GETSCANNEDIMAGE_INPUT>")
            xInput.DocumentElement.SelectSingleNode("ID").InnerText = strImgID
            dSet = bzobjBusinesscase.GetScannedImage(xInput)
            If dSet.Tables(0).Rows.Count > 0 Then
                Dim ImageBytes() As Byte = dSet.Tables(0).Rows(0)(2)

                Dim strFileName As String = strFilePath + "\BCDOC" & txtBCID.Text.Trim & ".pdf"
                StreamWtite = New IO.FileStream(strFileName, FileMode.Create)
                StreamWtite.Write(ImageBytes, 0, ImageBytes.Length)
                StreamWtite.Close()
                StreamWtite.Dispose()
                If File.Exists(strFileName) Then
                    'MsgBox("Loading..")
                    If AxAcroPDF1 Is Nothing Then
                        MsgBox("Pdf is null.." & AxAcroPDF1.GetType().ToString())
                    End If
                    AxAcroPDF1.LoadFile(strFileName)
                    AxAcroPDF1.Show()
                Else
                    MsgBox("File does not exist!")
                End If
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "GetImage", exc.GetBaseException)
        Finally
            StreamWtite.Close()
            StreamWtite.Dispose()
            mStream = Nothing
            imgStream = Nothing
            dSet = Nothing
        End Try
    End Sub

    Public Sub EnableButtonTrue()
        btnZoomIN.Enabled = True
        btnZoomOut.Enabled = True
        btnFitPage.Enabled = True
    End Sub
    Public Sub EnableButtonFalse()
        btnZoomIN.Enabled = False
        btnZoomOut.Enabled = False
        btnFitPage.Enabled = False
    End Sub

    '''''''''comment by ashish
    '#Region "Comment by Ashish"
    '    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '        '    Try
    '        '        Me.Cursor = Cursors.WaitCursor

    '        '        'If AxImgEdit1.Visible = True Then            ''For print scan document
    '        '        '    AxImgEdit1.PrintImage()
    '        '        '    Me.Cursor = Cursors.Arrow
    '        '        '    Exit Sub
    '        '        'End If

    '        '        'If WebBrowser1.Visible = True Then           ''For print web browser content document
    '        '        '    StrAgencyDetail = " <table border=2 align=center><tr><td><b>Agency Name :- " & txtAgencyName.Text & vbCrLf & " <br> " & _
    '        '        '      " Order No    :- " & txtOrderNumber.Text & " <br> " & _
    '        '        '      " Order Type  :- " & txtOrderType.Text & "<br>" & _
    '        '        '      " File No     :- " & txtFileNo.Text & " <br> " & _
    '        '        '      " Email From  :- " & dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailFrom").ToString() & " <br> " & _
    '        '        '      " Email To    :- " & dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailTo").ToString() & " <br> " & _
    '        '        '      " Subject     :- " & dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailSubject").ToString() & "</td></tr></table></b> <br> " & _
    '        '        '      "<br>" & dSetGlobal.Tables("Document").Rows(bManager.Position)("EmailBody").ToString()
    '        '        '    WebBrowser2.DocumentText = StrAgencyDetail
    '        '        '    WebBrowser2.Print()
    '        '        '    Me.Cursor = Cursors.Arrow
    '        '        '    Exit Sub
    '        '        'End If

    '        '        'If AxPdf.Visible = True Then                 ''For print pdf content document
    '        '        '    AxPdf.printAll()
    '        '        '    Me.Cursor = Cursors.Arrow
    '        '        '    Exit Sub
    '        '        'End If

    '        '        'If PictureBox1.Visible = True Then            ''For print images
    '        '        '    PrintDocument1.Print()
    '        '        '    Me.Cursor = Cursors.Arrow
    '        '        '    Exit Sub
    '        '        'End If


    '        '    Catch exc As Exception
    '        '        MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        '        Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "btnPrint_Click", exc.GetBaseException)
    '        '    Finally
    '        '        objPrintPreview = Nothing
    '        '        objPrintPreview = Nothing
    '        '        Me.Cursor = Cursors.Arrow

    '        '    End Try
    '    End Sub
    '    Private Sub btnZoomIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIN.Click
    '        'Try
    '        '    If AxImgEdit1.Image.Length <= 0 Then Exit Sub
    '        '    ChangeZoom(AxImgEdit1, 2)
    '        'Catch exc As Exception
    '        '    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        '    Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "btnZoomOut_Click", exc.GetBaseException)
    '        'End Try
    '    End Sub
    '    Private Sub ChangeZoom(ByVal ImgControl As AxImgeditLibCtl.AxImgEdit, ByVal Offset As Long)
    '        'Try
    '        '    ZoomPercent = AxImgEdit1.Zoom
    '        '    ZoomPercent = ZoomPercent + Offset
    '        '    If ZoomPercent < 2 Then
    '        '        Beep()
    '        '        ZoomPercent = 2
    '        '    End If
    '        '    If ZoomPercent > 500 Then
    '        '        Beep()
    '        '        ZoomPercent = 500
    '        '    End If
    '        '    AxImgEdit1.Zoom = ZoomPercent
    '        '    ' MsgBox(ZoomPercent)
    '        '    AxImgEdit1.Refresh()
    '        'Catch exc As Exception
    '        '    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        '    Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "ChangeZoom", exc.GetBaseException)
    '        'End Try
    '    End Sub
    '    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
    '        'Try

    '        '    If AxImgEdit1.Image.Length <= 0 Then Exit Sub
    '        '    ChangeZoom(AxImgEdit1, -2)
    '        'Catch exc As Exception
    '        '    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        '    Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "btnZoomIN_Click", exc.GetBaseException)
    '        'End Try
    '    End Sub
    '    Private Sub btnFitPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFitPage.Click
    '        'Try
    '        '    AxImgEdit1.FitTo(0)
    '        'Catch exc As Exception
    '        '    MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        '    Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "btnFitPage_Click", exc.GetBaseException)
    '        'End Try
    '    End Sub
    '#End Region
    ''''''''' Commented By Ashish  
    Private Sub DeleteFiles(Optional ByVal strDeleteFilePath As String = "")

        Dim oDir As DirectoryInfo
        Dim sFilesInfo As FileInfo

        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If Trim(strDeleteFilePath) = "" Then
                oDir = New DirectoryInfo(strFilePath)
                Dim oDirs As DirectoryInfo() = oDir.GetDirectories()
                For Each sFilesInfo In oDir.GetFiles("*.tif")
                    System.IO.File.Delete(strFilePath & "\" & sFilesInfo.ToString)
                Next

                For Each sFilesInfo In oDir.GetFiles("*.pdf")
                    System.IO.File.Delete(strFilePath & "\" & sFilesInfo.ToString)
                Next
            End If
        Catch exc As Exception
            'MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "DeleteFiles", exc.GetBaseException)
        Finally
            oDir = Nothing
            sFilesInfo = Nothing
        End Try

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Try
                DeleteFiles()
                Me.Close()
            Catch exc As Exception
                MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
                Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "btnClose_Click", exc.GetBaseException)
            End Try
            Me.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "btnClose_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub frmBCViewDoc_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            DeleteFiles()
          
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCScanDocument", "frmBCViewDoc_FormClosed", exc.GetBaseException)
        End Try
    End Sub
    Private Sub frmBCViewDoc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSecurityXml As New XmlDocument
        objSecurityXml.LoadXml(SecurityXml)
        If (objSecurityXml.DocumentElement.SelectSingleNode("Administrator").InnerText = "0") Then
            If objSecurityXml.DocumentElement.SelectNodes("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='Upload Contract or Side letter']").Count <> 0 Then
                strBuilder = SecurityCheck(objSecurityXml.DocumentElement.SelectSingleNode("SECURITY_OPTIONS/SECURITY_OPTION[@SecurityOptionSubName='Upload Contract or Side letter']").Attributes("Value").Value)
                If strBuilder(1) = "0" Then
                    btnPrint.Enabled = False
                End If
            End If
        Else
            strBuilder = SecurityCheck(31)
        End If

        If strChainCode <> String.Empty Then
            ViewAllDocumentChainCode()
        Else
            BindViewDocument()
		End If
        fill_LetterType()
       
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            If currentIndex < arrBCID.Count - 1 Then
                DeleteFiles()
                currentIndex += 1
				strBCaseID = arrBCID(currentIndex)
                BindViewAllDocument()
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnNext_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Try
            If currentIndex > 0 Then
                DeleteFiles()
                currentIndex -= 1
                strBCaseID = arrBCID(currentIndex)
                BindViewAllDocument()
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmViewDoc", "btnPrev_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim objbzBusinessCase As New AAMS.bizIncetive.bzBusinessCase()
        Dim xInputXml, xOutputXml As New XmlDocument
        Dim msgFlag As Integer

        Try
            Me.Cursor = Cursors.WaitCursor


            xInputXml.LoadXml("<INC_DELETE_SCANNED_DOCTYPE_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><DOCTYPE></DOCTYPE><DELETEALL></DELETEALL><SERIALNO></SERIALNO></INC_DELETE_SCANNED_DOCTYPE_INPUT>")

            xInputXml.DocumentElement.SelectSingleNode("BC_ID").InnerText = txtBCID.Text
			xInputXml.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = txtChaincode.Text
            xInputXml.DocumentElement.SelectSingleNode("SERIALNO").InnerText = drpSRNO.Text

            If drpLetterType.Text = "Contract" Then
                xInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 1
                xInputXml.DocumentElement.SelectSingleNode("SERIALNO").InnerText = drpSRNO.Text

            ElseIf drpLetterType.Text = "Side letter" Then
                xInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 2
                xInputXml.DocumentElement.SelectSingleNode("SERIALNO").InnerText = drpSRNO.Text

            ElseIf drpLetterType.Text = "Misc Document" Then
                xInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 3
                xInputXml.DocumentElement.SelectSingleNode("SERIALNO").InnerText = drpSRNO.Text

            End If


            MsgBox("It is recommended that first you take PrintOut , then go for deleted.", MsgBoxStyle.Information, "Amadeus Document Management System")
            ' msgFlag = MsgBox("Are you sure want to delete ?" & vbCrLf & drpLetterType.Text & " of Serial No : " & drpSRNO.Text, MsgBoxStyle.YesNo, "Amadeus Document Management System")
            msgFlag = MsgBox("Delete this document?", MsgBoxStyle.YesNo, "Amadeus Document Management System")
            If msgFlag = 6 Then

                xOutputXml = objbzBusinessCase.DeleteDocType(xInputXml)

                If xOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    Dim objfrmBusinessCaseSearch As New frmBusinessCaseSearch()
                    objfrmBusinessCaseSearch.CreateDataTable()
                    objfrmBusinessCaseSearch.LoadData()
                    msgFlag = MsgBox("Deleted successfully!", MsgBoxStyle.OkOnly, "Amadeus Document Management System")
                    Me.Close()
                End If
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "btnDelete_Click", ex.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
	End Sub
	Private Sub fill_LetterType()
		Try
            If strChainCode = String.Empty Then
                Dim objLetterType As New DataTable
                drpLetterType.Items.Add("--Select One--")
                drpLetterType.Items.Add("Contract")
                drpLetterType.Items.Add("Side letter")
                drpLetterType.Items.Add("Misc Document")
                drpLetterType.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "fill_LetterType", exc.GetBaseException)
        End Try

	End Sub
    '------------------------------As per new requiment new button is created--------------------------------------
	Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

		Dim bzobjBusinesscase As New AAMS.bizIncetive.bzBusinessCase
		Dim xInput, xOutput As New XmlDocument
		Dim m_objdsSelect As New DataSet
		Dim xReader As XmlNodeReader
		Try
			Me.Cursor = Cursors.WaitCursor

            If (drpLetterType.Text = "--Select One--") Then
                MsgBox("Please Select atleast on document type..", MsgBoxStyle.Critical, "Amadeus Document Management System")
                Exit Sub
            End If

            xInput.LoadXml("<INC_SEARCH_SCANNEDCONTRACT_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><EMPLOYEEID></EMPLOYEEID><DOCTYPE></DOCTYPE><SERIALNO></SERIALNO></INC_SEARCH_SCANNEDCONTRACT_INPUT>")
			xInput.DocumentElement.SelectSingleNode("BC_ID").InnerText = strBCaseID
			xInput.DocumentElement.SelectSingleNode("EMPLOYEEID").InnerText = strEmpId

            If drpLetterType.Text = "Contract" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 1
                xInput.DocumentElement.SelectSingleNode("SERIALNO").InnerText = drpSRNO.Text

            ElseIf drpLetterType.Text = "Side letter" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 2
                xInput.DocumentElement.SelectSingleNode("SERIALNO").InnerText = drpSRNO.Text

            ElseIf drpLetterType.Text = "Misc Document" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 3
                xInput.DocumentElement.SelectSingleNode("SERIALNO").InnerText = drpSRNO.Text

            End If

			xOutput = bzobjBusinesscase.GetContractDetails(xInput)

			If xOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
				xReader = New XmlNodeReader(xOutput)
				dSetGlobal.Clear()
				dSetGlobal.ReadXml(xReader)

				'bManager = Me.BindingContext(dSetGlobal, "Document")
				bManager = Me.BindingContext(dSetGlobal.Tables("SCANNEDCONTRACT"))

				If dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count > 0 Then

					lblImageID.DataBindings.Clear()
					lblImageID.DataBindings.Add(New Binding("Text", dSetGlobal, "SCANNEDCONTRACT.ID"))
					AxAcroPDF1.Hide()

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

					txtAgencyName.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("GROUP_NAME").ToString()
					txtChaincode.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("CHAIN_CODE").ToString()
					txtAoffice.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("AOFFICE").ToString()
					txtBCID.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_ID").ToString()
					txtValidfrom.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_EFFECTIVE_FROM").ToString()
					txtValidTo.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_VALID_TILL").ToString()
					txtPaymentMode.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("INC_TYPE_NAME").ToString()
					txtslabtype.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("PAYMENTTYPENAME").ToString()

					If dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count > 0 And dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("ID").ToString() <> "" Then
						txtTotalPage.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count.ToString
						txtCurrentpage.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("SRNO").ToString()
						txtDocType.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString()
						drpLetterType.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString()

						Dim strid As String = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("ID").ToString()
						StrGlobalImageId = strid
						GetImage(strid)
                        EnableButtonTrue()
						btnPrev.Enabled = True
						btnNext.Enabled = True
					Else
						txtDocType.Text = ""

						btnPrev.Enabled = False
						btnNext.Enabled = False
						EnableButtonFalse()
					End If

					If currentIndex = 0 Then
						btnPrev.Enabled = False
					Else
						btnPrev.Enabled = True
					End If

					If currentIndex >= arrBCID.Count - 1 Then
						btnNext.Enabled = False
					Else
						btnNext.Enabled = True
					End If

				End If
			Else
				txtCurrentpage.Text = ""
				txtTotalPage.Text = ""
				txtAgencyName.Text = ""
				txtChaincode.Text = ""
				txtAoffice.Text = ""
				txtValidfrom.Text = ""
				txtValidTo.Text = ""
				txtPaymentMode.Text = ""
				txtslabtype.Text = ""
				txtDocType.Text = ""
				txtChaincode.Text = ""
				txtBCID.Text = ""
				lblImageID.Text = ""
            End If

		Catch exc As Exception
			MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
			Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "btnView_Click", exc.GetBaseException)
		Finally
			Me.Cursor = Cursors.Default
		End Try

	End Sub
	'----------------------------------------end here----------------------------------------------------------------------
    Private Sub populateContractletter()
        Try
            drpSRNO.Items.Clear()
            If gblDTContractLetter.Rows.Count > 0 Then
                Dim dr As DataRow
                For Each dr In gblDTContractLetter.Rows()
                    drpSRNO.Items.Add(dr("SRNO"))
                Next
                drpSRNO.SelectedIndex = 0
                btnView.Enabled = True
                btnDelete.Enabled = True
                btnDeleteAll.Enabled = True
            Else

                btnView.Enabled = False
                btnDelete.Enabled = False
                btnDeleteAll.Enabled = False
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "populateContractletter", exc.GetBaseException)
        End Try
    End Sub
    Private Sub populateSideletter()
        Try
            drpSRNO.Items.Clear()
            If gblDTSideLetter.Rows.Count > 0 Then
                Dim dr As DataRow

                For Each dr In gblDTSideLetter.Rows()
                    drpSRNO.Items.Add(dr("SRNO"))
                Next
                drpSRNO.SelectedIndex = 0
                btnView.Enabled = True
                btnDelete.Enabled = True
                btnDeleteAll.Enabled = True
            Else
                btnView.Enabled = False
                btnDelete.Enabled = False
                btnDeleteAll.Enabled = False
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "populateSideletter", exc.GetBaseException)
        End Try
    End Sub
    Private Sub populateMiscDocument()
        Try
            drpSRNO.Items.Clear()
            If gblDTMiscDocument.Rows.Count <> 0 Then
                Dim dr As DataRow
                For Each dr In gblDTMiscDocument.Rows()
                    drpSRNO.Items.Add(dr("SRNO"))
                Next
                drpSRNO.SelectedIndex = 0
                btnView.Enabled = True
                btnDelete.Enabled = True
                btnDeleteAll.Enabled = True
            Else

                btnView.Enabled = False
                btnDelete.Enabled = False
                btnDeleteAll.Enabled = False
                AxAcroPDF1.Hide()
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "populateMiscDocument", exc.GetBaseException)
        End Try
    End Sub
    Private Sub drpLetterType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpLetterType.SelectedValueChanged
        Try
            If drpLetterType.SelectedIndex = 0 Then
                drpSRNO.Items.Clear()
                btnDelete.Enabled = False
                btnDeleteAll.Enabled = False
                btnView.Enabled = False
            ElseIf drpLetterType.SelectedIndex = 1 Then
                populateContractletter()
            ElseIf drpLetterType.SelectedIndex = 2 Then
                populateSideletter()
            ElseIf drpLetterType.SelectedIndex = 3 Then
                populateMiscDocument()
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "populateMiscDocument", exc.GetBaseException)
        End Try
    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objbzBusinessCase As New AAMS.bizIncetive.bzBusinessCase()
        Dim xInputXml, xOutputXml As New XmlDocument
        Dim msgFlag As Integer

        Try
            Me.Cursor = Cursors.WaitCursor

            xInputXml.LoadXml("<INC_DELETE_SCANNED_DOCTYPE_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><DOCTYPE></DOCTYPE><DELETEALL></DELETEALL><SERIALNO></SERIALNO></INC_DELETE_SCANNED_DOCTYPE_INPUT>")

            xInputXml.DocumentElement.SelectSingleNode("BC_ID").InnerText = txtBCID.Text
            xInputXml.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = txtChaincode.Text
            xInputXml.DocumentElement.SelectSingleNode("SERIALNO").InnerText = ""

            If drpLetterType.Text = "Contract" Then
                xInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 1
                xInputXml.DocumentElement.SelectSingleNode("SERIALNO").InnerText = ""

            ElseIf drpLetterType.Text = "Side letter" Then
                xInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 2
                xInputXml.DocumentElement.SelectSingleNode("SERIALNO").InnerText = ""

            ElseIf drpLetterType.Text = "Misc Document" Then
                xInputXml.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 3
                xInputXml.DocumentElement.SelectSingleNode("SERIALNO").InnerText = ""

            End If

            MsgBox("It is recommended that first you take PrintOut , then go for deleted.", MsgBoxStyle.Information, "Amadeus Document Management System")
            'msgFlag = MsgBox("Are you sure want to delete ?" & vbCrLf & drpLetterType.Text & " of Serial No : " & drpSRNO.Text, MsgBoxStyle.YesNo, "Amadeus Document Management System")
            msgFlag = MsgBox("Delete all document sets for business case?", MsgBoxStyle.YesNo, "Amadeus Document Management System")
            If msgFlag = 6 Then

                xOutputXml = objbzBusinessCase.DeleteDocType(xInputXml)

                If xOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    Dim objfrmBusinessCaseSearch As New frmBusinessCaseSearch()
                    objfrmBusinessCaseSearch.CreateDataTable()
                    objfrmBusinessCaseSearch.LoadData()
                    msgFlag = MsgBox("Deleted successfully!", MsgBoxStyle.OkOnly, "Amadeus Document Management System")
                    Me.Close()
                End If
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "btnDelete_Click", ex.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try

    End Sub

    Private Sub BindViewAllDocument()
        Dim bzobjBusinesscase As New AAMS.bizIncetive.bzBusinessCase
        Dim xInput, xOutput As New XmlDocument
        Dim m_objdsSelect As New DataSet
        Dim xReader As XmlNodeReader
        Try
            Me.Cursor = Cursors.WaitCursor
            xInput.LoadXml("<INC_SEARCH_SCANNEDCONTRACT_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><EMPLOYEEID></EMPLOYEEID><DOCTYPE></DOCTYPE><SERIALNO></SERIALNO></INC_SEARCH_SCANNEDCONTRACT_INPUT>")

            Dim strArr() As String
            strArr = strBCaseID.Split(",")

            xInput.DocumentElement.SelectSingleNode("BC_ID").InnerText = strArr(0).ToString()
            'xInput.DocumentElement.SelectSingleNode("CHAIN_CODE").InnerText = txtChaincode.Text
            xInput.DocumentElement.SelectSingleNode("EMPLOYEEID").InnerText = strEmpId

            If strArr(1).ToString() = "Contract" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 1
            ElseIf strArr(1).ToString() = "Side letter" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 2
            ElseIf strArr(1).ToString() = "Misc Document" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 3
            End If

            xInput.DocumentElement.SelectSingleNode("SERIALNO").InnerText = strArr(2).ToString()


            xOutput = bzobjBusinesscase.GetContractDetails(xInput)

            If xOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                xReader = New XmlNodeReader(xOutput)
                dSetGlobal.Clear()
                dSetGlobal.ReadXml(xReader)

                bManager = Me.BindingContext(dSetGlobal.Tables("SCANNEDCONTRACT"))
                If dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count > 0 Then
                    lblImageID.DataBindings.Clear()
                    lblImageID.DataBindings.Add(New Binding("Text", dSetGlobal, "SCANNEDCONTRACT.ID"))
                    AxAcroPDF1.Hide()

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
                    txtAgencyName.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("GROUP_NAME").ToString()
                    txtChaincode.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("CHAIN_CODE").ToString()
                    txtAoffice.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("AOFFICE").ToString()
                    txtBCID.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_ID").ToString()
                    txtValidfrom.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_EFFECTIVE_FROM").ToString()
                    txtValidTo.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_VALID_TILL").ToString()
                    txtPaymentMode.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("INC_TYPE_NAME").ToString()
                    txtslabtype.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("PAYMENTTYPENAME").ToString()

                    If dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count > 0 And dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("ID").ToString() <> "" Then
                        txtTotalPage.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count.ToString
                        txtCurrentpage.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("SRNO").ToString()
                        txtDocType.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString()

                        drpLetterType.Items.Clear()
                        drpLetterType.Items.Add(dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString())
                        drpLetterType.SelectedIndex = 0

                        drpSRNO.Items.Clear()
                        drpSRNO.Items.Add(dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("SRNO").ToString())
                        drpSRNO.SelectedIndex = 0


                        Dim strid As String = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("ID").ToString()
                        StrGlobalImageId = strid
                        GetImage(strid)
                        EnableButtonTrue()
                        btnPrev.Enabled = True
                        btnNext.Enabled = True
                    Else
                        txtDocType.Text = ""
                        btnPrev.Enabled = False
                        btnNext.Enabled = False
                        EnableButtonFalse()
                    End If

                    If currentIndex = 0 Then
                        btnPrev.Enabled = False
                    Else
                        btnPrev.Enabled = True
                    End If

                    If currentIndex >= arrBCID.Count - 1 Then
                        btnNext.Enabled = False
                    Else
                        btnNext.Enabled = True
                    End If

                End If
            Else
                txtCurrentpage.Text = ""
                txtTotalPage.Text = ""
                txtAgencyName.Text = ""
                txtChaincode.Text = ""
                txtAoffice.Text = ""
                txtValidfrom.Text = ""
                txtValidTo.Text = ""
                txtPaymentMode.Text = ""
                txtslabtype.Text = ""
                txtDocType.Text = ""
                txtChaincode.Text = ""
                txtBCID.Text = ""
                lblImageID.Text = ""

            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("BindViewDocument", "BindViewDocument", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub drpSRNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpSRNO.SelectedIndexChanged
        Try
            Dim selectedSerialNo = CType(drpSRNO.SelectedItem, String)
            Call View_Document_bySerialNo(selectedSerialNo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("drpSRNO_SelectedIndexChanged", "drpSRNO_SelectedIndexChanged", ex.GetBaseException)
        End Try
    End Sub

    Private Sub View_Document_bySerialNo(ByVal selectedSerialNo As Integer)
        Dim bzobjBusinesscase As New AAMS.bizIncetive.bzBusinessCase
        Dim xInput, xOutput As New XmlDocument
        Dim m_objdsSelect As New DataSet
        Dim xReader As XmlNodeReader
        Try
            Me.Cursor = Cursors.WaitCursor

            If (drpLetterType.Text = "--Select One--") Then
                MsgBox("Please Select atleast on document type..", MsgBoxStyle.Critical, "Amadeus Document Management System")
                Exit Sub
            End If

            xInput.LoadXml("<INC_SEARCH_SCANNEDCONTRACT_INPUT><BC_ID></BC_ID><CHAIN_CODE></CHAIN_CODE><EMPLOYEEID></EMPLOYEEID><DOCTYPE></DOCTYPE><SERIALNO></SERIALNO></INC_SEARCH_SCANNEDCONTRACT_INPUT>")
            xInput.DocumentElement.SelectSingleNode("BC_ID").InnerText = strBCaseID.Split(",")(0)
            xInput.DocumentElement.SelectSingleNode("EMPLOYEEID").InnerText = strEmpId

            If drpLetterType.Text = "Contract" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 1
                xInput.DocumentElement.SelectSingleNode("SERIALNO").InnerText = selectedSerialNo

            ElseIf drpLetterType.Text = "Side letter" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 2
                xInput.DocumentElement.SelectSingleNode("SERIALNO").InnerText = selectedSerialNo

            ElseIf drpLetterType.Text = "Misc Document" Then
                xInput.DocumentElement.SelectSingleNode("DOCTYPE").InnerText = 3
                xInput.DocumentElement.SelectSingleNode("SERIALNO").InnerText = selectedSerialNo

            End If

            xOutput = bzobjBusinesscase.GetContractDetails(xInput)

            If xOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                xReader = New XmlNodeReader(xOutput)
                dSetGlobal.Clear()
                dSetGlobal.ReadXml(xReader)

                'bManager = Me.BindingContext(dSetGlobal, "Document")
                bManager = Me.BindingContext(dSetGlobal.Tables("SCANNEDCONTRACT"))

                If dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count > 0 Then

                    lblImageID.DataBindings.Clear()
                    lblImageID.DataBindings.Add(New Binding("Text", dSetGlobal, "SCANNEDCONTRACT.ID"))
                    AxAcroPDF1.Hide()

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

                    txtAgencyName.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("GROUP_NAME").ToString()
                    txtChaincode.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("CHAIN_CODE").ToString()
                    txtAoffice.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("AOFFICE").ToString()
                    txtBCID.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_ID").ToString()
                    txtValidfrom.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_EFFECTIVE_FROM").ToString()
                    txtValidTo.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("BC_VALID_TILL").ToString()
                    txtPaymentMode.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("INC_TYPE_NAME").ToString()
                    txtslabtype.Text = dSetGlobal.Tables("BC_DETAILS").Rows(bManager.Position)("PAYMENTTYPENAME").ToString()

                    If dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count > 0 And dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("ID").ToString() <> "" Then
                        txtTotalPage.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows.Count.ToString
                        txtCurrentpage.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("SRNO").ToString()
                        txtDocType.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString()
                        drpLetterType.Text = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("DOCTYPE").ToString()

                        Dim strid As String = dSetGlobal.Tables("SCANNEDCONTRACT").Rows(bManager.Position)("ID").ToString()
                        StrGlobalImageId = strid
                        GetImage(strid)
                        EnableButtonTrue()
                        btnPrev.Enabled = True
                        btnNext.Enabled = True
                    Else
                        txtDocType.Text = ""

                        btnPrev.Enabled = False
                        btnNext.Enabled = False
                        EnableButtonFalse()
                    End If

                    If currentIndex = 0 Then
                        btnPrev.Enabled = False
                    Else
                        btnPrev.Enabled = True
                    End If

                    If currentIndex >= arrBCID.Count - 1 Then
                        btnNext.Enabled = False
                    Else
                        btnNext.Enabled = True
                    End If

                End If
            Else
                txtCurrentpage.Text = ""
                txtTotalPage.Text = ""
                txtAgencyName.Text = ""
                txtChaincode.Text = ""
                txtAoffice.Text = ""
                txtValidfrom.Text = ""
                txtValidTo.Text = ""
                txtPaymentMode.Text = ""
                txtslabtype.Text = ""
                txtDocType.Text = ""
                txtChaincode.Text = ""
                txtBCID.Text = ""
                lblImageID.Text = ""
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmBCViewDoc", "View_Document_bySerialNo", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class