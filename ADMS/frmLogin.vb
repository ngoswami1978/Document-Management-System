'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmLogin.vb $
'$Workfile: frmLogin.vb $
'$Revision: 16 $
'$Archive: /AAMS/Interface/ADMS/frmLogin.vb $
'$Modtime: 6/19/14 4:54p $
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Data.SqlClient
Imports AAMS.bizShared
Public Class frmLogin
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lblStatus.Text = String.Empty
            'txtUsername.Text = "admin"
            'txtPassword.Text = "amadeus"
            txtUsername.Focus()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "frmLogin_Load", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Dim mAns As Int16 = MsgBox("                do you want to exit ? ", MsgBoxStyle.OkCancel, "Amadeus Management Document System")
            If (mAns) = 1 Then
                Me.Close()
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "btnCancel_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objEmployee As New AAMS.bizMaster.bzEmployee
        Dim cmd As New SqlCommand
        Dim objSqlConnection As New SqlConnection(bzShared.GetConnectionString())  ''connection string from AAMS
        Dim mhostname As String = Dns.GetHostName()
        Dim strPermisionUserFromConfig As String
        Dim strArrUsers() As String
        Dim strGetUserNameFromConfig As String
        Dim count As Integer
        Dim blnAllowConfigUser As Boolean
        blnAllowConfigUser = False
        strPdfFolderName = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            lblStatus.Text = "Authenticating the user....."
            Dim mIpaddress As String = CType(Dns.GetHostByName(mhostname).AddressList.GetValue(0), IPAddress).ToString
            If Trim(txtUsername.Text) = "" Then
                MsgBox("Username is mandatory", MsgBoxStyle.Information)
                txtUsername.Focus()
                Exit Sub
            End If
            If Trim(txtPassword.Text) = "" Then
                MsgBox("Password is mandatory", MsgBoxStyle.Information)
                txtPassword.Focus()
                Exit Sub
            End If
            '############## THIS FOR ORDERING MODULE ####################################
            '##############  GET USE NAME FROM CONFIG FILE ####################################
            cmd.CommandText = "UP_GET_TA_GETUSERNAMEFORSCANMODULE"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = objSqlConnection
            objSqlConnection.Open()
            strGetUserNameFromConfig = cmd.ExecuteScalar()
            strPermisionUserFromConfig = strGetUserNameFromConfig
            strArrUsers = strPermisionUserFromConfig.Split(",")
            For count = 0 To strArrUsers.Length - 1
                'MsgBox(strArr(count))
                If UCase(txtUsername.Text) = UCase(strArrUsers(count)) Then
                    blnAllowConfigUser = True
                    objSqlConnection.Close()
                    Exit For
                End If
            Next
            If blnAllowConfigUser = False Then
                'MsgBox("Invalid User", MsgBoxStyle.Information, "ADMS")
                lblStatus.Text = "Access Permission Denied"
                objSqlConnection.Close()
                txtUsername.Focus()
                Exit Sub
            End If
            '######################################################################################    
            objInputXml.LoadXml("<MS_LOGIN_INPUT><Login></Login><Password></Password><IPAddress></IPAddress></MS_LOGIN_INPUT>")
            With objInputXml
                .DocumentElement.SelectSingleNode("Login").InnerText = Trim$(txtUsername.Text)
                .DocumentElement.SelectSingleNode("Password").InnerText = Trim$(txtPassword.Text)
                .DocumentElement.SelectSingleNode("IPAddress").InnerText = mIpaddress
            End With
            'Back end Method Call
            objOutputXml = objEmployee.Login(objInputXml)
            strEmpId = objOutputXml.DocumentElement.SelectSingleNode("EmployeeID").InnerText
            If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                SecurityXml = objOutputXml.OuterXml
                SecurityAdminXml = objOutputXml.DocumentElement.SelectSingleNode("EmployeeID").InnerText & "|" & objOutputXml.DocumentElement.SelectSingleNode("Administrator").InnerText & "|" & objOutputXml.DocumentElement.SelectSingleNode("FirstForm").InnerText
                '################   check for Img folder exists in C Drive #############################
                Dim objDir As DirectoryInfo
                objDir = New DirectoryInfo("C:\Img")
                If objDir.Exists Then
                    ' MsgBox("Folder already exist")
                Else
                    objDir.Create()
                End If
                '##############  Get Destination path for PDF File ####################################
                cmd.CommandText = "UP_GET_TA_PDFFOLDERPATH"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = objSqlConnection
                objSqlConnection.Open()
                strPdfFolderName = cmd.ExecuteScalar()
                'MsgBox(strPdfFolderName)
                '######################################################################################    
                Me.Hide()
                Me.Cursor = Cursors.WaitCursor
                frmMain.Show()
            Else
                lblStatus.Text = objOutputXml.DocumentElement.SelectSingleNode("Errors/Error").Attributes("Description").Value.Trim.ToString
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "btnOk_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub txtUsername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        Try
            If (e.KeyCode) = 13 Then
                Call btnOk_Click(sender, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "txtUsername_KeyDown", exc.GetBaseException)
        End Try
    End Sub
    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        Try
            If (e.KeyCode) = 13 Then
                Call btnOk_Click(sender, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "txtUsername_KeyDown", exc.GetBaseException)
        End Try
    End Sub
End Class