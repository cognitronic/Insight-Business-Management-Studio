<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PropertiesToolBarView.ascx.cs" Inherits="Views_PropertiesToolBarView" %>
<div runat="server" id="divPropertiesToolBar">
    <telerik:RadToolBar 
    ID="rtbProperties"
    Width="100%"
    Skin="Default"
    OnButtonClick="ButtonClicked"
    runat="server">
      <Items>
        <telerik:RadToolBarButton 
        Text="Create New..." 
        ImageUrl="~/images/add.png"
        CommandName="CreateNew"
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Clone" 
        ImageUrl="~/images/page_copy.png"
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Save" 
        ImageUrl="~/images/disk.png"
        CommandName="Save"
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Save & Return" 
        ImageUrl="~/images/disk.png"
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Cancel" 
        CausesValidation="false"
        ImageUrl="~/images/cancel.png"
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Undo" 
        CausesValidation="false"
        ImageUrl="~/images/arrow_undo.png"
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Delete" 
        ImageUrl="~/images/delete.png"
        style="margin-left: 10px; margin-right: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Print" 
        ImageUrl="~/images/printer.png"
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Email" 
        ImageUrl="~/images/email.png"
        style="margin-left: 10px; margin-right: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
        <telerik:RadToolBarButton CommandName="ExportDDL">
            <ItemTemplate>
                <div style="padding-left:10px; ">
                    <telerik:RadComboBox
                    ID="ddlExport"
                    runat="server"
                    Width="75px"
                    EmptyMessage="-- Select Format --">
                        <Items>
                            <telerik:RadComboBoxItem
                            ImageUrl="~/images/page_white_acrobat.png"
                            style="margin-left: 2px; border:1px solid #617FB5; padding: 0"
                            Text="PDF"
                            Value="PDF" />
                            <telerik:RadComboBoxItem
                            ImageUrl="~/images/page_excel.png"
                            style="margin-left: 2px; border:1px solid #617FB5; padding: 0"
                            Text="Excel"
                            Value="Excel" />
                        </Items>
                    </telerik:RadComboBox>
                </div>
            </ItemTemplate>
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Export" 
        ImageUrl="~/images/database_go.png"
        style="margin-left: 10px; margin-right: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
</div>
