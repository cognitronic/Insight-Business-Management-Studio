<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterOptionsCollectionView.ascx.cs" Inherits="Insight.Website.Views.FilterOptionsCollectionView" %>
<div>
    <span>
        <idea:DropDownList
        runat="server"
        Skin="Windows7"
        AutoPostBack="true"
        ID="ddlColumns">
        </idea:DropDownList>
    </span>
    <span>
        <idea:DropDownList
        runat="server"
        Skin="Windows7"
        ID="ddlOperators">
        </idea:DropDownList>
    </span>
    <span runat="server" id="criteriaDDL">
        <idea:DropDownList
        runat="server"
        Skin="Windows7"
        ID="ddlCriteria">
        </idea:DropDownList>
    </span>
    <span runat="server" id="criteriaText">
        <idea:TextBox
        runat="server"
        ID="tbCriteria"
        Skin="Windows7"
        Width="325px">
        </idea:TextBox>
    </span>
    <span>
        <idea:LinkButton
        runat="server"
        OnClick="DeleteClicked"
        OnClientClick="return confirm('Are you sure you want to remove this condition?');"
        ID="lbRemoveCondition">
            <asp:Image
            runat="server"
            ToolTip="Remove Condition"
            ID="imgRemoveCondition"
            ImageAlign="Middle"
            ImageUrl="~/Images/delete.png" />
        </idea:LinkButton>
    </span>
</div>
<br />