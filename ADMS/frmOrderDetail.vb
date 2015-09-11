Imports System.Text
Imports System.Xml
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports AAMS.bizTravelAgency
Imports AAMS.bizShared
Public Class frmOrderDetail

    Dim objInputXml As New XmlDocument
    Public glbOrderId As Integer
    Dim strLocalOrderId As Integer
    Dim ob As New frmViewOrder

    Private Sub frmOrderDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            strLocalOrderId = strOrderId

            objInputXml.LoadXml("<TA_UPDATEAGENCYORDERREMARKSDETAILS_INPUT><DETAILS ORDERID='' REMARKS=''/></TA_UPDATEAGENCYORDERREMARKSDETAILS_INPUT>")

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmOrderDetail", "frmOrderDetail_Load", exc.GetBaseException)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try

            Dim ob As New frmViewOrder
            ob.frmgblFormName = "frmOrderDetail"
            GetOrderDetails()

         
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmOrderDetail", "btnClose_Click", exc.GetBaseException)
        End Try
    End Sub

   Public Sub GetOrderDetails()
          Try

               Dim ob As New frmViewOrder
               ob.frmgblFormName = "frmOrderDetail"

               strOrderId = strLocalOrderId

               ob.getOrder()

             Me.Close()
          Catch exc As Exception
               MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
               Call AAMS.bizShared.bzShared.LogWrite("frmOrderDetail", "btnClose_Click", exc.GetBaseException)
          End Try

   End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim objxml As New XmlDocument
        Dim obj As New AAMS.bizTravelAgency.bzOrder
        Try

            objInputXml.DocumentElement("DETAILS").Attributes("ORDERID").InnerText = glbOrderId
            objInputXml.DocumentElement("DETAILS").Attributes("REMARKS").InnerText = CType(txtRemarks.Text, String)

            objxml = obj.UpdateOrderRemarks(objInputXml)

            If objxml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "FALSE" Then
                MsgBox("Update Successfully ", MsgBoxStyle.Information, "Amadeus Document Management System")
            Else
                MsgBox(objxml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText.ToString)
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmOrderDetail", "btnSave_Click", exc.GetBaseException)
        End Try

    End Sub

End Class