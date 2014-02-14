<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactListView.ascx.cs" Inherits="Accounts_Views_ContactsListView" %>
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
                <table style="padding: 10px 0px 10px 0px; margin-right: 400px;">
                    <tr>
                        <td valign="top">
                            <asp:Image
                            runat="server"
                            Width="125px"
                            Height="125px"
                            ID="imgContact" />
                        </td>
                        <td style="padding: 0px 0px 10px 20px;" valign="top">
                            <table class="detailTable" valign="top">
                                <tr>
                                    <td>
                                        <span>Status: </span>
                                        <span class="lightBlue">
                                            <%# Eval("IsActive").ToString() == "True" ? "<font color='green'>Yes</font>" : "<font color='red'>No</font>"%> 
                                        </span>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Title: </span>
                                        <span class="lightBlue">
                                            <%# Eval("Title") %> 
                                        </span>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>First Name: </span>
                                        <span class="lightBlue">
                                            <%# Eval("FirstName") %> 
                                        </span>
                                    </td>
                                    <td>
                                        <span>Last Name: </span>
                                        <span class="lightBlue">
                                            <%# Eval("LastName") %> 
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Work: </span>
                                        <span class="lightBlue">
                                            <%# IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(Eval("WorkPhone").ToString())%> 
                                        </span>
                                    </td>
                                    <td>
                                        <span>Cell: </span>
                                        <span class="lightBlue">
                                            <%# IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(Eval("CellPhone").ToString()) %> 
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Account Name: </span>
                                        <span class="lightBlue">
                                            <idea:Label 
                                            runat="server" 
                                            ID="lblDetailAccountName">
                                            </idea:Label>
                                        </span>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                            </table>
                             <idea:LinkButton
                            runat="server"
                            ID="lbDetailViewItem"
                            itemname='<%# Eval("title") %>'
                            itemid='<%# Eval("id").ToString() %>'
                            OnClick="ViewItemClicked">
                                <asp:Image
                                runat="server"
                                ID="imgEditLastName"
                                ImageUrl="~/images/zoom.png" />
                                View
                            </idea:LinkButton>
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
            NoMasterRecordsText="No contacts found.">
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
                    DataField="LastName" 
                    HeaderText="Contact" 
                    SortExpression="LastName"
                    UniqueName="LastName">
                        <ItemTemplate>
                            <%# Eval("FirstName").ToString() + " " + Eval("LastName").ToString() %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Title" 
                    HeaderText="Title" 
                    SortExpression="Title"
                    UniqueName="Title">
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="AccountID" 
                    HeaderText="Account" 
                    SortExpression="AccountID"
                    UniqueName="AccountID">
                        <ItemTemplate>
                            <idea:Label
                            runat="server"
                            ID="lblAccount">
                            </idea:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="CellPhone" 
                    HeaderText="Cell Phone" 
                    SortExpression="CellPhone"
                    UniqueName="CellPhone">
                        <ItemTemplate>
                            <%# IdeaSeed.Core.Utils.Utilities.PrettyPhoneNumber(Eval("CellPhone").ToString())%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="IsActive" 
                    HeaderText="Status" 
                    SortExpression="IsActive"
                    UniqueName="IsActive">
                        <ItemTemplate>
                            <%# Eval("IsActive").ToString() == "True" ? "Active" : "Inactive"%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="IsKeyContact" 
                    HeaderText="Key Contact" 
                    SortExpression="State"
                    UniqueName="IsKeyContact">
                        <ItemTemplate>
                            <%# Eval("IsKeyContact").ToString() == "True" ? "Yes" : "No"%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Location" 
                    HeaderText="Location" 
                    SortExpression="Location"
                    UniqueName="Location">
                        <ItemTemplate>
                            <%# Eval("Location")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <idea:LinkButton
                            runat="server"
                            ID="lbEdit"
                            OnClick="ViewItemClicked"
                            itemname='<%# Eval("title") %>'
                            itemid='<%# Eval("id").ToString() %>'>
                                <asp:Image
                                runat="server"
                                ID="imgEdit"
                                ToolTip="View Contact"
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
