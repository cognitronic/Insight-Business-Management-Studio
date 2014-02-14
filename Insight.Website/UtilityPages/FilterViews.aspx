<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="FilterViews.aspx.cs" Inherits="Insight.Website.UtilityPages.FilterViews" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpSideBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpMainContent" runat="server">
    <div runat="server" id="divHeader" class="propertypagecontent">
    <div>
        <h2>
            <idea:Label
            runat="server"
            ID="lblPropertiesTitle">
            </idea:Label>
        </h2>
    </div>
    <hr />
    <div>
        <div style="margin-bottom: 5px;">
            <div><b>View Title:</b></div>
            <span>
                <idea:TextBox
                runat="server"
                ID="tbViewTitle"
                Skin="Windows7"
                Width="660px">
                </idea:TextBox>
            </span>
        </div>
        <div style="margin-bottom: 5px;">
            <div>Make Default View?</div>
            <idea:CheckBox
            id="cbIsDefault"
            runat="server" />
        </div>
    </div>
    <div class="shadedContentArea">
        <div>
            Meet <b><span class="orange">ALL</span></b> of the following conditions:
        </div>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
        <telerik:RadAjaxPanel runat="server" ID="pnl" LoadingPanelID="RadAjaxLoadingPanel1">
        <div runat="server" style="width: 678px;" id="divConditionsContainer">
            <asp:PlaceHolder
            runat="server"
            ID="phConditions">
            </asp:PlaceHolder>
            <div style="float: right; ">
                <idea:LinkButton
                runat="server"
                OnClick="AddAndConditionClicked"
                ID="lbAddAndCondtion">
                    <asp:Image
                    runat="server"
                    ID="imgAddAndCondition"
                    ImageAlign="Top"
                    ImageUrl="~/Images/add.png" />
                    Add Condition
                </idea:LinkButton>
            </div>
        </div>
        </telerik:RadAjaxPanel>
        <br />
        <div>
            Meet <b><span class="orange">ANY</span></b> of the following conditions:
        </div>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" />
        <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="RadAjaxLoadingPanel1">
        <div runat="server" style="width: 678px;" id="div1">
            <asp:PlaceHolder
            runat="server"
            ID="phOrConditions">
            </asp:PlaceHolder>
            <div style="float: right; ">
                <idea:LinkButton
                runat="server"
                OnClick="AddOrConditionClicked"
                ID="lbOrCondition">
                    <asp:Image
                    runat="server"
                    ID="Image1"
                    ImageAlign="Top"
                    ImageUrl="~/Images/add.png" />
                    Add Condition
                </idea:LinkButton>
            </div>
        </div>
        </telerik:RadAjaxPanel>
        <br />
    </div>
    <div>
    </div>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger 
            ControlID="lbAddAndCondition" 
            EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <br />   
    <hr /> 
</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cpFooter" runat="server">
</asp:Content>
