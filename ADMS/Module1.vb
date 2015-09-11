'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Ashishsrivastava $Logfile: /AAMS/Interface/ADMS/frmAgencySearch.vb $
'$Workfile: Module1.vb $
'$Revision: 38 $
'$Archive: /AAMS/Interface/ADMS/Module1.vb $
'$Modtime: 6/17/14 2:02p $

Imports System.IO
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Data.DataSet
Imports System.Globalization
Module Module1
    Public SecurityXml As String
    Public SecurityAdminXml As String
    Public gblLcode As Integer
    Public m_file_no As Integer
    Public strOrderId As String
    Public strOrderNumber As String
    Public strOrderType As String
    Public strFilePath As String = System.Configuration.ConfigurationSettings.AppSettings("ScanFolder")
    Public strZoomPercentage As String = System.Configuration.ConfigurationSettings.AppSettings("ZoomPercentage")
    Public strPdfFolderName As String
    Public gblstrOfficeid As String
    Public strEmpId As String
    Public gblBCID As String
    Public gblChainCode As String
	Public gblChainName As String
	Public blnJAMError As Boolean = False
	Public blnSideLetter As Boolean = False
    Public blnContractLetter As Boolean = False
    ''new datatable
    Public gblDScontractSideLetter As New DataSet
    Public gblDTContractLetter As New DataTable
    Public gblDTSideLetter As New DataTable
    Public gblDTMiscDocument As New DataTable


    Public Sub BindDropDown(ByVal drpDownList As ComboBox, ByVal strType As String, ByVal bolSelect As Boolean)
        Dim objOutputXml As XmlDocument
        Dim objXmlReader As XmlNodeReader
        Dim ds As New DataSet
        Select Case strType

            Case "AOFFICE"

                Dim objbzAOffice As New AAMS.bizMaster.bzAOffice
                objOutputXml = New XmlDocument
                objOutputXml = objbzAOffice.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("AOFFICE")
                    drpDownList.DisplayMember = "AOFFICE"
                    drpDownList.ValueMember = "AOFFICE"

                End If
            Case "AIRLINE"
                Dim objbzAOffice As New AAMS.bizMaster.bzAirline
                objOutputXml = New XmlDocument
                objOutputXml = objbzAOffice.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("AIRLINE")
                    drpDownList.DisplayMember = "NAME"
                    drpDownList.ValueMember = "Airline_Code"

                End If
            Case "AGROUP"
                Dim objbzAgencyGroup As New AAMS.bizMaster.bzAgencyGroup
                objOutputXml = New XmlDocument
                objOutputXml = objbzAgencyGroup.ListGroupType()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("GROUP_TYPE")
                    drpDownList.DisplayMember = "GroupTypeName"
                    drpDownList.ValueMember = "GroupTypeID"

                End If
            Case "CITY"
                Dim objbzCity As New AAMS.bizMaster.bzCity
                objOutputXml = New XmlDocument
                objOutputXml = objbzCity.List()

                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("CITY")
                    drpDownList.DisplayMember = "City_Name"
                    drpDownList.ValueMember = "CityID"

                End If
            Case "COUNTRY"
                Dim objbzCountry As New AAMS.bizMaster.bzCountry
                objOutputXml = New XmlDocument
                objOutputXml = objbzCountry.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("COUNTRY")
                    drpDownList.DisplayMember = "Country_Name"
                    drpDownList.ValueMember = "CountryID"

                End If
            Case "DESIGNATION"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("DESIGNATION")
                    drpDownList.DisplayMember = "Designation"
                    drpDownList.ValueMember = "DesignationID"

                End If
            Case "EMPLOYEE"
                Dim objbzEmployee As New AAMS.bizMaster.bzEmployee
                Dim objInputXml As New XmlDocument
                objOutputXml = objbzEmployee.List
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("EMPLOYEE")
                    drpDownList.DisplayMember = "Employee_Name"
                    drpDownList.ValueMember = "EmployeeID"

                End If


            Case "FileNo"
                Dim objbzAFileno As New AAMS.bizTravelAgency.bzAgency
                objOutputXml = New XmlDocument
                objOutputXml = objbzAFileno.GetFileNumber()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DisplayMember = "FileNo"
                    drpDownList.ValueMember = "FileNo"
                    drpDownList.DataSource = ds.Tables("FILENUMBER")
                End If


            Case "FileNoTCFilling"
                Dim bzOrder As New AAMS.bizTravelAgency.bzOrder
                objOutputXml = New XmlDocument
                objOutputXml = bzOrder.GetFileNumber()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then

                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    ' Dim dView As New DataView
                    ' dView = ds.Tables("FILENUMBER").DefaultView
                    'dView.Sort = "FileNo asc"
                    'dView.RowFilter = "0"
                    'dView.RowFilter = "FileNo<>0"
                    drpDownList.DisplayMember = "FileNo"
                    drpDownList.ValueMember = "FileNo"
                    drpDownList.DataSource = ds.Tables("FILENUMBER")
                End If


            Case "IPPOOL"
                Dim objbzIPPool As New AAMS.bizMaster.bzIPPool
                Dim objInputXml As New XmlDocument
                objOutputXml = New XmlDocument
                objInputXml.LoadXml("<MS_SEARCHIPPOOL_INPUT><PoolName></PoolName><Aoffice></Aoffice><Department_Name></Department_Name></MS_SEARCHIPPOOL_INPUT>")
                objOutputXml = objbzIPPool.Search(objInputXml)
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("IPPOOL")
                    drpDownList.DisplayMember = "PoolName"
                    drpDownList.ValueMember = "PoolID"

                End If
            Case "PRIORITY"
                Dim objbzAgencyGroup As New AAMS.bizMaster.bzAgencyGroup
                objOutputXml = New XmlDocument
                objOutputXml = objbzAgencyGroup.ListPriority()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("PRIORITY")
                    drpDownList.DisplayMember = "PriorityName"
                    drpDownList.ValueMember = "PriorityID"

                End If
            Case "REGION"
                Dim objbzRegion As New AAMS.bizMaster.bzRegion
                objOutputXml = New XmlDocument

                objOutputXml = objbzRegion.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("REGION_DET")
                    drpDownList.DisplayMember = "Region_Name"
                    drpDownList.ValueMember = "Region_Name"

                End If
            Case "REGIONHQ"
                Dim objbzAOffice As New AAMS.bizMaster.bzAOffice
                objOutputXml = New XmlDocument
                objOutputXml = objbzAOffice.ListHQ()

                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("Detail")
                    drpDownList.DisplayMember = "Name"
                    drpDownList.ValueMember = "ID"

                End If
            Case "STATE"
                Dim objbzCountryState As New AAMS.bizMaster.bzCountryState
                objOutputXml = New XmlDocument
                objOutputXml = objbzCountryState.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("STATE")
                    drpDownList.DisplayMember = "StateName"
                    drpDownList.ValueMember = "StateID"

                End If
            Case "SECURITYREGION"
                Dim objbzSecurityRegion As New AAMS.bizMaster.bzSecurityRegion
                objOutputXml = New XmlDocument
                objOutputXml = objbzSecurityRegion.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("SECURITYREGION")
                    drpDownList.DisplayMember = "Name"
                    drpDownList.ValueMember = "RegionID"

                End If
            Case "ManagerName"
                Dim objbzEmployee As New AAMS.bizMaster.bzEmployee
                objOutputXml = New XmlDocument
                objOutputXml = objbzEmployee.ListManager()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("EMPLOYEE")
                    drpDownList.DisplayMember = "Employee_Name"
                    drpDownList.ValueMember = "EmployeeID"

                End If
            Case "DepartmentName"
                Dim objbzDepartment As New AAMS.bizMaster.bzDepartment
                objOutputXml = New XmlDocument
                objOutputXml = objbzDepartment.List

                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("DEPARTMENT")
                    drpDownList.DisplayMember = "Department_Name"
                    drpDownList.ValueMember = "DepartmentID"

                End If
            Case "DESIGNATION"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("DESIGNATION")
                    drpDownList.DisplayMember = "Designation"
                    drpDownList.ValueMember = "DesignationID"

                End If
            Case "PRODUCTGROUP"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("PRODUCTGROUP")
                    drpDownList.DisplayMember = "ProductGroupName"
                    drpDownList.ValueMember = "ProductGroupId"

                End If
            Case "PROVIDERCRS"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("PROVIDERCRS")
                    drpDownList.DisplayMember = "CRSCodeText"
                    drpDownList.ValueMember = "Name"

                End If
            Case "OS"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("OS")
                    drpDownList.DisplayMember = "ProductGroupName"
                    drpDownList.ValueMember = "ProductGroupId"
                End If
            Case "CRS"
                Dim objbzCRS As New AAMS.bizMaster.bzCRS
                objOutputXml = New XmlDocument
                objOutputXml = objbzCRS.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("CRS")
                    drpDownList.DisplayMember = "Name"
                    drpDownList.ValueMember = "CRSCodeText"
                End If

            Case "ATYPE"
                Dim objbzAgencyType As New AAMS.bizTravelAgency.bzAgencyType
                objOutputXml = New XmlDocument
                objOutputXml = objbzAgencyType.List
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("AGENCYTYPE")
                    drpDownList.DisplayMember = "Agency_Type_Name"
                    drpDownList.ValueMember = "AgencyTypeId"
                End If

            Case "ASTATUS"
                Dim objbzAgencyStatus As New AAMS.bizTravelAgency.bzAgencyStatus
                objOutputXml = New XmlDocument
                objOutputXml = objbzAgencyStatus.List
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("AGENCYSTATUS")
                    drpDownList.DisplayMember = "Agency_Status_Name"
                    drpDownList.ValueMember = "AgencyStatusId"
                End If

            Case "ONLINESTATUS"

                'AAMS.bizTravelAgency.bzOnlineStatus()
                '.List()


                Dim objOnlineStatus As New AAMS.bizTravelAgency.bzOnlineStatus
                objOutputXml = New XmlDocument
                objOutputXml = objOnlineStatus.List
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("Status")
                    drpDownList.DisplayMember = "StatusCode"
                    drpDownList.ValueMember = "StatusCode"
                End If
        End Select
    End Sub

    Public Function SecurityCheck(ByVal intValue As Integer) As System.Text.StringBuilder
        Dim builSecurity As New System.Text.StringBuilder

        Dim ViewRight, AddRight, ModifyRight, DeleteRight, PrintRight As String
        ViewRight = 0 : AddRight = 0 : ModifyRight = 0 : DeleteRight = 0 : PrintRight = 0
        Select Case intValue
            Case 1
                ViewRight = "1"
            Case 2, 3
                ViewRight = "1"
                AddRight = "1"
            Case 4, 5
                ViewRight = "1"
                ModifyRight = "1"
            Case 6, 7
                ViewRight = "1"
                ModifyRight = "1"
                AddRight = "1"
            Case 8, 9
                ViewRight = "1"
                DeleteRight = "1"
            Case 10, 11
                ViewRight = "1"
                DeleteRight = "1"
                AddRight = "1"
            Case 12, 13
                ViewRight = "1"
                DeleteRight = "1"
                ModifyRight = "1"
            Case 14, 15
                ViewRight = "1"
                DeleteRight = "1"
                ModifyRight = "1"
                AddRight = "1"
            Case 16, 17
                ViewRight = "1"
                PrintRight = "1"
            Case 18, 19
                ViewRight = "1"
                PrintRight = "1"
                AddRight = "1"
            Case 20, 21
                ViewRight = "1"
                PrintRight = "1"
                ModifyRight = "1"
            Case 22, 23
                ViewRight = "1"
                PrintRight = "1"
                AddRight = "1"
                ModifyRight = "1"
            Case 24, 25
                ViewRight = "1"
                PrintRight = "1"
                DeleteRight = "1"
            Case 26, 27
                ViewRight = "1"
                PrintRight = "1"
                DeleteRight = "1"
                AddRight = "1"
            Case 28, 29
                ViewRight = "1"
                PrintRight = "1"
                DeleteRight = "1"
                ModifyRight = "1"
            Case 30, 31
                ViewRight = "1"
                PrintRight = "1"
                DeleteRight = "1"
                ModifyRight = "1"
                AddRight = "1"
        End Select

        If SecurityAdminXml.ToString().Split("|").GetValue(1).ToString() = "1" Then
            builSecurity.Append(1)
            builSecurity.Append(1)
            builSecurity.Append(1)
            builSecurity.Append(1)
            builSecurity.Append(1)
            Return builSecurity
        Else
            'Index 0 View
            builSecurity.Append(ViewRight)
            'Index 1 Add
            builSecurity.Append(AddRight)
            'Index 2 Modify
            builSecurity.Append(ModifyRight)
            'Index 3 Delete
            builSecurity.Append(DeleteRight)
            'Index 4 Print
            builSecurity.Append(PrintRight)
            Return builSecurity
        End If
    End Function
    Function GetDateInt(ByVal dt As String) As Integer
        ''**********************************************************************
        '   Sub
        ''**********************************************************************
        'DESC :To make the date in a proper format
        'Input : string
        'Output: Integer

        Dim arrDate As Array
        arrDate = Split(dt, "/", -1, 1)
        Dim dt1 As String
        dt1 = arrDate(2)

        If CType(arrDate(1), Integer) < 10 Then
            dt1 = dt1 + "0" + CStr(CInt(arrDate(1)))
        Else
            dt1 = dt1 + arrDate(1)
        End If
        If CType(arrDate(0), Integer) < 10 Then
            dt1 = dt1 + "0" + CStr(CInt(arrDate(0)))
        Else
            dt1 = dt1 + arrDate(0)
        End If
        Return dt1
    End Function

    Public Function ConvertDateBlank(ByVal intDate As String) As String
        If intDate.Trim = "" Then
            Return intDate
        End If
        Try
            Dim dtDateFrom As New Date(Left(CType(intDate, String), 4), Mid(CType(intDate, String), 5, 2), Right(CType(intDate, String), 2))
            Return dtDateFrom.ToString("dd/MM/yyyy")
        Catch ex As Exception
            Return CDate("1/1/1900")
        End Try
    End Function

    Public Function GetDateFormat(ByVal objDate As Object, ByVal dateInFormat As String, ByVal dateOutFormat As String, ByVal dateSepChar As String) As String
        Dim str As String = ""
        If objDate.Trim = "" Then
        Else
            Try
                If dateInFormat.Equals("yyyyMMdd") Then
                    str = DateTime.ParseExact(objDate, dateInFormat, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat).ToString(dateOutFormat)
                Else
                    Dim ln As Integer = objDate.ToString().Length
                    If ln = 8 And dateInFormat.Equals("dd/MM/yyyy") Then
                        dateInFormat = "dd/MM/yy"
                    End If
                    Dim dt As New DateTime()
                    '  Dim dtfi As New DateTimeFormatInfo
                    Dim dtfi As New DateTimeFormatInfo
                    dtfi.ShortDatePattern = dateInFormat
                    dtfi.DateSeparator = dateSepChar
                    dt = Convert.ToDateTime(objDate, dtfi)
                    str = dt.ToString(dateOutFormat)
                End If

            Catch ex As Exception
                str = "0"
            End Try
        End If
        Return str
    End Function


   

End Module
