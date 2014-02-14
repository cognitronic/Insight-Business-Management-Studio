<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccountPropertiesView.ascx.cs" Inherits="Views_AccountPropertiesView" %>
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
    <table>
        <tr>
            <td class="propertypagecells">
                <span>ID:</span>
                <span>
                    <idea:Label
                    class="orange"
                    runat="server"
                    ID="lblID">
                    </idea:Label>
                </span>
            </td>
            <td>
                <span>Is Active?:</span>
                <span>
                    <idea:CheckBox
                    runat="server"
                    Skin="Windows7"
                    ID="cbIsActive" />
                </span>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Name:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbName"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvName"
                    ErrorMessage="<br />Please enter a name"
                    InitialValue=""
                    ControlToValidate="tbName"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span>Email Domain</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbEmailDomain"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Phone:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbPhone"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <span>Fax:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbFax"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Parent Account:</span>
                <div>
                    <idea:AccountsDDL
                    runat="server"
                    ID="ddlParentAccount">
                    </idea:AccountsDDL>
                </div>
            </td>
            <td>
                <span><b>Account Manager:</b></span>
                <div>
                    <idea:UsersDDL
                    runat="server"
                    ID="ddlAccountManager">
                    </idea:UsersDDL>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvAccountManager"
                    ErrorMessage="<br />Please select an account manager"
                    InitialValue=""
                    ControlToValidate="ddlAccountManager"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Industry Type:</b></span>
                <div>
                    <idea:IndustryTypesDDL
                    runat="server"
                    Skin="Windows7"
                    ID="ddlIndustryType">
                    </idea:IndustryTypesDDL>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvIndustryTye"
                    ErrorMessage="<br />Please select industry type"
                    InitialValue=""
                    ControlToValidate="ddlIndustryType"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span>Service Level Agreement:</span>
                <div>
                    <idea:ServiceLevelAgreementsDDL
                    runat="server"
                    Skin="Windows7"
                    ID="ddlServiceLevelAgreement">
                    </idea:ServiceLevelAgreementsDDL>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Website:</span>
                <div>
                    <idea:TextBox
                    runat="server"
                    Skin="Windows7"
                    Width="325px"
                    ID="tbWebsite">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <%--<span>Entered By:</span>
                <span>
                    <idea:Label
                    class="lightblue"
                    runat="server"
                    ID="lblEnteredBy" />
                </span><br />
                <span>Updated By:</span>
                <span>
                    <idea:Label
                    class="lightblue"
                    runat="server"
                    ID="lblUpdatedBy" />
                </span><br />--%>
                <span>Date Created:</span>
                <span>
                    <idea:Label
                    class="orange"
                    runat="server"
                    ID="lblDateCreated" />
                </span><br />
                <span>Last Updated:</span>
                <span>
                    <idea:Label
                    class="orange"
                    runat="server"
                    ID="lblLastUpdated" />
                </span><br />
            </td>
        </tr>
    </table>
</div>
<hr />
