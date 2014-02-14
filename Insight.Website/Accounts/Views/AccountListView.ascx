<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountListView.ascx.cs" Inherits="Views_AccountListView" %>
<div runat="server" id="divHeader" class="propertypagecontent">
    <div>
        <h2>
            <idea:Label
            runat="server"
            ID="lblListTitle">
            </idea:Label>
        </h2>
    </div>
    <hr />
    <div>
        <telerik:RadGrid
        runat="server"
        ID="rgAccounts"
        AllowPaging="True"
        AllowCustomPaging="true"
        AutoGenerateColumns="false"
        AllowSorting="True" 
        GridLines="None" 
        ShowStatusBar="true"
        OnNeedDataSource="NeedDataSource"
        OnItemCommand="ItemCommand"
        ShowFooter="true"
        EnableEmbeddedSkins="false"
        Skin="Insight">
            <ClientSettings EnableRowHoverStyle="true">
            </ClientSettings>
            <MasterTableView 
            DataKeyNames="ID"
            CommandItemDisplay="None"
            EnableNoRecordsTemplate="true"
            NoMasterRecordsText="No Accounts Found.">
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
                    DataField="Name" 
                    HeaderText="Name" 
                    SortExpression="Name"
                    UniqueName="Name">
                        <ItemTemplate>
                            <%# Eval("Name")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="AccountManager.LastName" 
                    HeaderText="Account Manager ID" 
                    SortExpression="AccountManager.LastName"
                    UniqueName="AccountManager.LastName">
                        <ItemTemplate>
                            <%# Eval("AccountManager.FirstName").ToString() + " " + Eval("AccountManager.LastName").ToString() %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Phone" 
                    HeaderText="Phone" 
                    SortExpression="Phone"
                    UniqueName="Phone">
                        <ItemTemplate>
                            <%# Eval("Phone")%>
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
                    HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <idea:LinkButton
                            runat="server"
                            ID="lbEdit"
                            OnClick="ViewAccountClicked"
                            accountname='<%# Eval("name") %>'
                            accountid='<%# Eval("id").ToString() %>'>
                                <asp:Image
                                runat="server"
                                ID="imgEdit"
                                ToolTip="View Account"
                                ImageUrl="~/images/zoom.png"
                                Style="border: none;" />
                            </idea:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <PagerStyle Mode="NextPrevAndNumeric"  AlwaysVisible="false" Position="Bottom" />
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>
<br />
