'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmDate.vb $
'$Workfile: frmDate.vb $
'$Revision: 4 $
'$Archive: /AAMS/Interface/ADMS/frmDate.vb $
'$Modtime: 24/01/08 11:36a $

Imports System.Windows.Forms
Public Class frmDate
    Public strDate As String
    Public Sub CalcDate_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles CalcDate.DateChanged
        Try
            'set the date formate in dd/MM/yyyy
            strDate = ""
            strDate = Format(e.Start.Date, "dd/MM/yyyy")
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmDate", "CaleDateOffline_DateChanged", exc.GetBaseException)
        End Try
    End Sub
    Private Sub CalcDate_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles CalcDate.DateSelected
        Try
            strDate = Format(e.Start.Date, "dd/MM/yyyy")
            Me.Close()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmDate", "CaleDateOffline_DateChanged", exc.GetBaseException)
        End Try
    End Sub

    Private Sub frmDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try
            If e.Handled = Keys.Escape Then
                Me.Close()
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmDate", "frmDate_KeyPress", exc.GetBaseException)
        End Try

    End Sub

    Private Sub CalcDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CalcDate.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmDate", "CalcDate_KeyDown", exc.GetBaseException)
        End Try
    End Sub
End Class
