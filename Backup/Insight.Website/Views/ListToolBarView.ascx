<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListToolBarView.ascx.cs" Inherits="Views_ListToolBarView" %>
<div runat="server" id="divListToolBar">
    <telerik:RadToolBar 
    ID="rtbList"
    Width="100%"
    OnButtonClick="ButtonClicked"
    Skin="Default"
    runat="server">
      <Items>
        <telerik:RadToolBarButton 
        Text="Create New..." 
        ImageUrl="~/images/add.png"
        CommandName="CreateNew"
        style="margin-left: 10px; margin-right: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0" 
        CommandName="ListType">
            <ItemTemplate>
                <div style="padding-left:10px; ">
                    List Type: 
                    <telerik:RadComboBox
                    ID="ddlListType"
                    Skin="Windows7"
                    AutoPostBack="true"
                    runat="server"
                    OnSelectedIndexChanged="ListTypeSelectedIndexChanged"
                    Width="75px"
                    EmptyMessage="-- Select Type --">
                        <Items>
                            <telerik:RadComboBoxItem
                            ImageUrl="~/images/text_list_bullets.png"
                            style="margin-left: 2px; border:1px solid #617FB5; padding: 0"
                            Text="List"
                            Value="LIST" />
                            <telerik:RadComboBoxItem
                            ImageUrl="~/images/layout_content.png"
                            style="margin-left: 2px; border:1px solid #617FB5; padding: 0"
                            Text="Details"
                            Value="DETAIL" />
                        </Items>
                    </telerik:RadComboBox>
                </div>
            </ItemTemplate>
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        style="margin-left: 10px; border:1px solid #617FB5; padding: 0" 
        CommandName="Views">
            <ItemTemplate>
                <div style="padding-left:10px; ">
                    <telerik:RadComboBox
                    ID="ddlViews"
                    Skin="Windows7"
                    runat="server"
                    Width="75px"
                    EmptyMessage="-- Select View --">
                    </telerik:RadComboBox>
                </div>
            </ItemTemplate>
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Add" 
        ImageUrl="~/images/add.png"
        CommandName="AddView"
        style="margin-left: 10px; margin-right: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton 
        Text="Edit" 
        ImageUrl="~/images/pencil.png"
        CommandName="EditView"
        style="margin-right: 10px; border:1px solid #617FB5; padding: 0">
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
        <telerik:RadToolBarButton CommandName="GridPageSize">
            <ItemTemplate>
                <div style="padding-left:10px; ">
                    Page Size:&nbsp;
                    <idea:GridPageSizeDDL
                    Width="40px"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="GridPageSizeChanged"
                    ID="ddlGridPageSize"
                    runat="server">
                    </idea:GridPageSizeDDL>
                </div>
            </ItemTemplate>
        </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
</div>
