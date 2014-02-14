<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactEmailListView.ascx.cs" Inherits="Accounts_Views_ContactEmailListView" %>
<div runat="server" id="divContactList" class="propertypagecontent">
    <div>
        <h2>
            <idea:Label
            runat="server"
            ID="lblListTitle">
            </idea:Label>
        </h2>
    </div>
    <hr />
    <div runat="server" id="divListView">
        <telerik:RadListView
        runat="server"
        AllowPaging="true"
        ID="dlDetails"
        OnNeedDataSource="DetailsNeedDataSource"
        OnItemDataBound="DetailsItemDataBound"
        Width="100%"
        RepeatColumns="0">
            <ItemTemplate>
                <table class="detailTable" valign="top">
                    <tr>
                        <td>
                            <span>Email Type: </span>
                            <span class="lightBlue">
                                <%# ((Insight.Core.Domain.EmailType)Eval("EmailTypeID")).ToString()%> 
                            </span>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Email: </span>
                            <span class="lightBlue">
                                <%# Eval("Email") %> 
                            </span>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <hr />
            </ItemTemplate>
        </telerik:RadListView>
        <telerik:RadGrid
        runat="server"
        ID="rgList"
        AllowPaging="True"
        AllowCustomPaging="true"
        AutoGenerateColumns="false"
        AllowSorting="True" 
        Width="100%"
        GridLines="None" 
        ShowStatusBar="true"
        OnNeedDataSource="NeedDataSource"
        OnItemCommand="ItemCommand"
        OnItemDataBound="ItemDataBound"
        ShowFooter="true"
        EnableEmbeddedSkins="false"
        Skin="Insight">
            <ClientSettings EnableRowHoverStyle="true">
            </ClientSettings>
            <MasterTableView 
            DataKeyNames="ID"
            CommandItemDisplay="None"
            EnableNoRecordsTemplate="true"
            NoMasterRecordsText="No email accounts found.">
                <Columns>
                    <telerik:GridTemplateColumn 
                    UniqueName="CheckBoxTemplateColumn">
                        <HeaderTemplate>
                         <idea:CheckBox 
                         ID="cbSelectAllRows" 
                         style="cursor: default;"
                         OnCheckedChanged="ToggleGridSelectedState" 
                         AutoPostBack="True" 
                         runat="server">
                         </idea:CheckBox>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <idea:CheckBox 
                            ID="cbSelectRow" 
                            itemid='<%# Eval("ID") %>'
                            runat="server">
                            </idea:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="ID" 
                    HeaderText="ID" 
                    SortExpression="ID"
                    UniqueName="ID">
                        <ItemTemplate>
                            <%# Eval("ID")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="EmailTypeID" 
                    HeaderText="Type" 
                    SortExpression="EmailTypeID"
                    UniqueName="EmailTypeID">
                        <ItemTemplate>
                            <%# ((Insight.Core.Domain.EmailType)Eval("EmailTypeID")).ToString()%> 
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Email" 
                    HeaderText="Email" 
                    SortExpression="Email"
                    UniqueName="Email">
                        <ItemTemplate>
                            <%# Eval("Email")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <idea:LinkButton
                            runat="server"
                            ID="lbEdit"
                            OnClick="ViewItemClicked"
                            itemname='<%# Eval("Email") %>'
                            itemid='<%# Eval("ID").ToString() %>'>
                                <asp:Image
                                runat="server"
                                ID="imgEdit"
                                ToolTip="View Email Account"
                                ImageUrl="~/images/zoom.png"
                                Style="border: none;" />
                            </idea:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <PagerStyle Mode="NextPrevAndNumeric" 
                AlwaysVisible="false" 
                Position="Bottom" />
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>
<br />

