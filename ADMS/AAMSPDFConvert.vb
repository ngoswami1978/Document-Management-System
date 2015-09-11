Imports System.IO
Imports System.Data
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Xml
Public Class AAMSPDFConverter
    'System.Configuration.ConfigurationSettings.AppSettings("ScanFolder")

    Public Sub CreatePDFFromImage(ByVal Id As String, ByVal StrFolderName As String, ByVal FileList As ArrayList, ByVal StrReportPhysicalPath As String)
        Dim objRepDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ' Dim tmpReportName As String
        Dim ds As New DataSet
        Dim strPDFFileName As String = ""
        Dim DiskOpts As CrystalDecisions.Shared.DiskFileDestinationOptions = New CrystalDecisions.Shared.DiskFileDestinationOptions

        Try
            ds = New DataSet
            Dim dt As New DataTable
            dt.TableName = "PDFDOC"
            dt.Columns.Add("BCID")
            dt.Columns.Add("IMG_NAME", System.Type.GetType("System.Byte[]"))
            ds.Tables.Add(dt)

            If Id.Trim = "" Then
                Throw New Exception("Please provide Id.")
            End If

            If Not Directory.Exists(StrFolderName) Then
                Throw New Exception(StrFolderName + " does not exist.")
            End If

            strPDFFileName = StrFolderName & "\BCDOC" + Id.ToString & ".pdf"

            If FileList.Count = 0 Then
                Throw New Exception("Please provide at least one image file.")
            End If
            If StrReportPhysicalPath.Trim = "" Then
                Throw New Exception("Please provide Report Name.")
            End If
            If Not File.Exists(StrReportPhysicalPath) Then
                Throw New Exception("Report Path does not exist.")
            End If

            For FileNo As Integer = 0 To FileList.Count - 1

                Dim FilePath As String = FileList(FileNo).ToString ' 'StrFolderName + "\" + Filename
                If File.Exists(FilePath) Then
                    Dim dr As DataRow
                    dr = ds.Tables("PDFDOC").NewRow
                    dr("BCID") = Id
                    ds.Tables("PDFDOC").Rows.Add(dr)
                    ds = CreateData(FilePath, ds, FileNo)
                Else
                    Throw New Exception("image file [ " + FileList(FileNo).ToString + " ] does not exist.")
                End If
            Next
            If ds.Tables("PDFDOC") IsNot Nothing Then
                If ds.Tables("PDFDOC").Rows.Count > 0 Then
                    Dim ReportName As String
                    Dim MyRandomNumber As New Random
                    ReportName = StrReportPhysicalPath ' "D:\AAMS\Interface\ADMS\CrystalReport1.rpt"
                    objRepDocument.Load(ReportName)
                    objRepDocument.SetDataSource(ds)

                    objRepDocument.ReportOptions.EnableSaveDataWithReport = False
                    objRepDocument.SetDataSource(ds)
                    objRepDocument.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat '.WordForWindows
                    objRepDocument.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile '.NoDestination

                    If File.Exists(strPDFFileName) Then
                        Try
                            File.Delete(strPDFFileName)
                        Catch ex As Exception
                        End Try
                    End If
                    objRepDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strPDFFileName)
                Else
                    Throw New Exception("Error On creation of PDF File.")
                End If
            Else
                Throw New Exception("Error On creation of PDF File.")
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            DiskOpts = Nothing
            FileList = Nothing
            objRepDocument = Nothing
        End Try
    End Sub

    Private Function CreateData(ByVal strFolder As String, ByVal ds As DataSet, ByVal RowNum As Integer) As DataSet
        Dim img As Image
        Dim imgStream As MemoryStream = New MemoryStream()
        Dim byteArray As Byte()
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            img = Image.FromFile(strFolder)
            img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Png)
            byteArray = imgStream.ToArray()
            ds.Tables("PDFDOC").Rows(RowNum)("IMG_NAME") = byteArray ' br.ReadBytes(CInt(br.BaseStream.Length))
            Return (ds)
        Catch ex As Exception
            Throw ex
        Finally
            img = Nothing
            'img.Dispose()

            imgStream.Close()
            imgStream.Flush()
            imgStream.Dispose()

        End Try
    End Function

End Class
