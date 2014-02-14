<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserListView.ascx.cs" Inherits="Insight.Website.Views.UserListView" %>
<%@ Register tagPrefix="idea" namespace="IdeaSeed.Web.UI" assembly="IdeaSeed.Web" %>
<%@ Register tagPrefix="telerik" namespace="Telerik.Web.UI" assembly="Telerik.Web.UI"  %>
<div runat="server" id="divViewWrapper" class="propertypagecontent">
    <div>
        <h2>
            <idea:Label
            runat="server"
            ID="lblViewTitle">
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
                <table style="padding: 10px 0px 10px 0px; margin-right: 400px; width: 500px;">
                    <tr>
                        <td valign="top">
                            <telerik:RadBinaryImage
                            AutoAdjustImageControlSize="true"
                            ResizeMode="Fit"
                            Width="125px"
                            Height="125px"
                            ID="imgUser"
                            runat="server" />
                        </td>
                        <td style="padding: 0px 0px 10px 0px;" valign="top">
                            <table class="detailTable" width="500px">
                                <tr>
                                    <td>
                                        <span>Status: </span>
                                        <span class="lightBlue">
                                            <%# Eval("IsActive").ToString() == "True" ? "<font color='green'>Active</font>" : "<font color='red'>Inactive</font>"%> 
                                        </span>
                                    </td>
                                    <td>
                                        <span>Username: </span>
                                        <span class="lightBlue">
                                            <%# Eval("UserName") %> 
                                        </span>
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
                                            <%# IdeaSeed.Core.Utils.Utilities.FormatPhoneNumberForDisplay(Eval("WorkPhone").ToString())%> 
                                        </span>
                                    </td>
                                    <td>
                                        <span>Cell: </span>
                                        <span class="lightBlue">
                                            <%# IdeaSeed.Core.Utils.Utilities.FormatPhoneNumberForDisplay(Eval("CellPhone").ToString()) %> 
                                        </span>
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
                                        <span>Department ID: </span>
                                        <span class="lightBlue">
                                            <%# Eval("DepartmentID") %> 
                                        </span>
                                    </td>
                                </tr>
                            </table>
                             <idea:LinkButton
                            runat="server"
                            ID="lbDetailViewItem"
                            itemname='<%# Eval("username") %>'
                            itemid='<%# Eval("id").ToString() %>'
                            OnClick="ViewItemClicked">
                                <asp:Image
                                runat="server"
                                ID="imgEditItem"
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
            NoMasterRecordsText="No users found.">
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
                    HeaderText="Name" 
                    SortExpression="LastName"
                    UniqueName="LastName">
                        <ItemTemplate>
                            <%# Eval("FirstName").ToString() + " " + Eval("LastName").ToString() %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="UserName" 
                    HeaderText="Username" 
                    SortExpression="UserName"
                    UniqueName="UserName">
                        <ItemTemplate>
                            <%# Eval("UserName")%>
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
                    DataField="CellPhone" 
                    HeaderText="Cell Phone" 
                    SortExpression="CellPhone"
                    UniqueName="CellPhone">
                        <ItemTemplate>
                            <%# IdeaSeed.Core.Utils.Utilities.FormatPhoneNumberForDisplay(Eval("CellPhone").ToString())%>
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
                    DataField="DepartmentID" 
                    HeaderText="Department" 
                    SortExpression="DepartmentID"
                    UniqueName="DepartmentID">
                        <ItemTemplate>
                            <%# Eval("DepartmentID")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn
                    HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <idea:LinkButton
                            runat="server"
                            ID="lbEdit"
                            OnClick="ViewItemClicked"
                            itemname='<%# Eval("username") %>'
                            itemid='<%# Eval("id").ToString() %>'>
                                <asp:Image
                                runat="server"
                                ID="imgEdit"
                                ToolTip="View User"
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
