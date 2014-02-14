<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountListView.ascx.cs" Inherits="Views_AccountListView" %>
<div>
    Hello: 
    <idea:Label
    runat="server"
    ID="lblTest">
    </idea:Label>
</div>
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
    PageSize="5"
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
                DataField="AccountManagerID" 
                HeaderText="Account Manager ID" 
                SortExpression="AccountManagerID"
                UniqueName="AccountManagerID">
                    <ItemTemplate>
                        <%# Eval("AccountManagerID")%>
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
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>
<br />
