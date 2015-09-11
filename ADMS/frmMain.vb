'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmAgencySearch.vb $
'$Workfile: frmMain.vb $
'$Revision: 19 $
'$Archive: /AAMS/Interface/ADMS/frmMain.vb $
'$Modtime: 5/17/12 11:24a $
Public Class frmMain
    Private Sub AgencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgencyToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objfrmInput As New frmAgencySearch
            objfrmInput.MdiParent = Me
            objfrmInput.WindowState = FormWindowState.Maximized
            objfrmInput.Show()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmMain", "AgencyToolStripMenuItem_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            End
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmMain", "frmMain_FormClosed", exc.GetBaseException)
        End Try
    End Sub
    Private Sub AgencyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objfrm As New frmViewDocument
            objfrm.MdiParent = Me
            objfrm.WindowState = FormWindowState.Normal
            objfrm.Show()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmMain", "AgencyToolStripMenuItem1_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    

    Private Sub ExitToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem2.Click
        Try
            End
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmMain", "ExitToolStripMenuItem_Click", exc.GetBaseException)
        End Try
    End Sub

    Private Sub SearchBusinesscaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBusinesscaseToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objfrmInput As New frmBusinessCaseSearch
            objfrmInput.MdiParent = Me
            objfrmInput.WindowState = FormWindowState.Maximized
            objfrmInput.Show()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmMain", "SearchBusinesscaseToolStripMenuItem_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' IncentiveToolStripMenuItem.Visible = False
    End Sub

    Private Sub SearchAgreementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchAgreementToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objfrmInput As New frmAgreementSearch
            objfrmInput.MdiParent = Me
            objfrmInput.WindowState = FormWindowState.Maximized
            objfrmInput.Show()
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmMain", "SearchAgreementToolStripMenuItem_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class
