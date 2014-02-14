<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DashboardToolBarView.ascx.cs" Inherits="Views_DashboardToolBarView" %>
<div runat="server" id="mainToolBar">
    <telerik:RadToolBar 
    ID="rtbMaster"
    Width="100%"
    Skin="Default"
    runat="server">
      <Items>
        <telerik:RadToolBarButton 
        Text="Refresh" 
        ImageUrl="~/images/arrow_refresh.png"
        style="margin-left: 10px; margin-right: 10px; border:1px solid #617FB5; padding: 0">
        </telerik:RadToolBarButton>
        <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
</div>
