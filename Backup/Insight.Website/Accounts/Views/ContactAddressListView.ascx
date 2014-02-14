<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactAddressListView.ascx.cs" Inherits="Accounts_Views_ContactAddressListView" %>
<div runat="server" id="divAddressList" class="propertypagecontent">
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
                <div style="padding: 10px 0px 10px 0px; margin-right: 450px;">
                    <div>
                        <span>Title: </span>
                        <span class="lightBlue"><%# Eval("Title") %> </span>
                    </div>
                    <div>
                        <span>Address Type: </span>
                        <span class="lightBlue"><%# Eval("AddressTypeID")%> </span>
                    </div>
                    <div>
                        <span>Address 1: </span>
                        <span class="lightBlue"><%# Eval("Address1") %> </span>
                    </div>
                    <div>
                        <span>Address 2:</span>
                        <span class="lightBlue"><%# Eval("Address2") %> </span>
                    </div>
                    <div>
                        <span>City: </span>
                        <span class="lightBlue"><%# Eval("City") %> </span>
                    </div>
                    <div>
                        <span>State: </span>
                        <span class="lightBlue"><%# Eval("State") %> </span>
                    </div>
                    <div>
                        <span>Zip: </span>
                        <span class="lightBlue"><%# Eval("Zip") %> </span>
                    </div>
                    <div>
                        <idea:LinkButton
                        runat="server"
                        ID="lbEditAddress"
                        itemname='<%# Eval("title") %>'
                        itemid='<%# Eval("id").ToString() %>'
                        OnClick="ViewItemClicked">
                            <asp:Image
                            runat="server"
                            ID="imgEditAddress"
                            ImageUrl="~/images/pencil.png" />
                            Edit
                        </idea:LinkButton>
                    </div>
                </div>
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
        GridLines="None" 
        Width="100%"
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
            NoMasterRecordsText="No addresses for account found.">
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
                    DataField="Title" 
                    HeaderText="Title" 
                    SortExpression="Title"
                    UniqueName="Title">
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="AddressType" 
                    HeaderText="Address Type" 
                    SortExpression="AddressType"
                    UniqueName="AddressType">
                        <ItemTemplate>
                            <%# ((Insight.Core.Domain.AddressType)Eval("AddressTypeID")).ToString()%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Address1" 
                    HeaderText="Address 1" 
                    SortExpression="Address1"
                    UniqueName="Address1">
                        <ItemTemplate>
                            <%# Eval("Address1")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Address2" 
                    HeaderText="Address 2" 
                    SortExpression="Address2"
                    UniqueName="Address2">
                        <ItemTemplate>
                            <%# Eval("Address2") %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="City" 
                    HeaderText="City" 
                    SortExpression="City"
                    UniqueName="City">
                        <ItemTemplate>
                            <%# Eval("City")%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="State" 
                    HeaderText="State" 
                    SortExpression="State"
                    UniqueName="State">
                        <ItemTemplate>
                            <%# Eval("State") %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn 
                    DataField="Zip" 
                    HeaderText="Zip" 
                    SortExpression="Zip"
                    UniqueName="Zip">
                        <ItemTemplate>
                            <%# Eval("Zip")%>
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
                                ToolTip="View Address"
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