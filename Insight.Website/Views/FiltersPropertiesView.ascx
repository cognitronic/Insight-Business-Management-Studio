<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltersPropertiesView.ascx.cs" Inherits="Insight.Website.Views.FiltersPropertiesView" %>
<%@ Register TagPrefix="idea" TagName="FilterOptionsView" Src="~/Views/FilterOptionsCollectionView.ascx" %>
<%@ Register tagPrefix="idea" namespace="IdeaSeed.Web.UI" assembly="IdeaSeed.Web" %>
<%@ Register tagPrefix="idea" namespace="Insight.Web.Controls" assembly="Insight.Web" %>
<%@ Register tagPrefix="idea" namespace="Insight.Accounts.Web.Controls" assembly="Insight.Accounts" %>
<%@ Register tagPrefix="telerik" namespace="Telerik.Web.UI" assembly="Telerik.Web.UI"  %>
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
            <idea:FilterOptionsView
            runat="server"
            ID="FilterOptionsView1" />
            <idea:FilterOptionsView
            runat="server"
            ID="FilterOptionsView2" />
        <div runat="server" id="divConditionsContainer">
            <asp:PlaceHolder
            runat="server"
            ID="phConditions">
            </asp:PlaceHolder>

        </div>
        <br />
        <div>
            Meet <b><span class="orange">ANY</span></b> of the following conditions:
        </div>
            <idea:FilterOptionsView
            runat="server"
            ID="FilterOptionsView6" />
            <idea:FilterOptionsView
            runat="server"
            ID="FilterOptionsView7" />
    </div>
    <div>
        <div style="float: right; margin-right: 10px;">
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