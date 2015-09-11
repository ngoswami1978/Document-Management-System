<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AgencyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IncentiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchBusinesscaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchAgreementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowToolStripMenuItem, Me.ScanToolStripMenuItem, Me.IncentiveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.MdiWindowListItem = Me.WindowToolStripMenuItem
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(658, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem2})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.WindowToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem2.Text = "E&xit"
        '
        'ScanToolStripMenuItem
        '
        Me.ScanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgencyToolStripMenuItem})
        Me.ScanToolStripMenuItem.Name = "ScanToolStripMenuItem"
        Me.ScanToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.ScanToolStripMenuItem.Text = "&Order"
        '
        'AgencyToolStripMenuItem
        '
        Me.AgencyToolStripMenuItem.Name = "AgencyToolStripMenuItem"
        Me.AgencyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AgencyToolStripMenuItem.Text = "&Search Agency"
        '
        'IncentiveToolStripMenuItem
        '
        Me.IncentiveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchBusinesscaseToolStripMenuItem, Me.SearchAgreementToolStripMenuItem})
        Me.IncentiveToolStripMenuItem.Enabled = False
        Me.IncentiveToolStripMenuItem.Name = "IncentiveToolStripMenuItem"
        Me.IncentiveToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.IncentiveToolStripMenuItem.Text = "&Incentive"
        '
        'SearchBusinesscaseToolStripMenuItem
        '
        Me.SearchBusinesscaseToolStripMenuItem.Name = "SearchBusinesscaseToolStripMenuItem"
        Me.SearchBusinesscaseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SearchBusinesscaseToolStripMenuItem.Text = "Search &Businesscase"
        '
        'SearchAgreementToolStripMenuItem
        '
        Me.SearchAgreementToolStripMenuItem.Name = "SearchAgreementToolStripMenuItem"
        Me.SearchAgreementToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SearchAgreementToolStripMenuItem.Text = "Search Agreement"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 485)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Amadeus Document Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgencyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncentiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchBusinesscaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchAgreementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
