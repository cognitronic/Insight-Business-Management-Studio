<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactPropertiesView.ascx.cs" Inherits="Accounts_Views_ContactPropertiesView" %>
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
                    Skin="Windows7"
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
                <span>Title:</span>
                <span>
                    <idea:TextBox
                    runat="server"
                    Width="325px"
                    Skin="Windows7"
                    ID="tbTitle">
                    </idea:TextBox>
                </span>
            </td>
            <td>
                <span>Is Key Contact?:</span>
                <span>
                    <idea:CheckBox
                    runat="server"
                    Skin="Windows7"
                    ID="cbIsKeyContact" />
                </span>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>First Name:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbFirstName"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvFirstName"
                    ErrorMessage="<br />Please enter first name"
                    InitialValue=""
                    ControlToValidate="tbFirstName"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span><b>Last Name:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbLastName"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvLastName"
                    ErrorMessage="<br />Please enter last name"
                    InitialValue=""
                    ControlToValidate="tbLastName"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Primary Email</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbPrimaryEmail"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RegularExpressionValidator 
                    ID="valEmailAddress"
                    ControlToValidate="tbPrimaryEmail"
                    ValidationExpression=".*@.*\..*" 
                    ErrorMessage="<br />Email address is invalid." 
                    Display="Dynamic" 
                    EnableClientScript="true"
                    Runat="server"/>
                </div>
            </td>
            <td>
                <span><b>Account:</b></span>
                <div>
                    <idea:AccountsDDL
                    Skin="Windows7"
                    runat="server"
                    ID="ddlAccount">
                    </idea:AccountsDDL>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvAccount"
                    ErrorMessage="<br />Please select an account"
                    InitialValue=""
                    ControlToValidate="ddlAccount"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Location:</span>
                <div>
                    <idea:TextBox
                    runat="server"
                    Width="325px"
                    Skin="Windows7"
                    ID="tbLocation">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <span>Work Phone:</span>
                <div>
                    <idea:TextBox
                    runat="server"
                    Width="325px"
                    Skin="Windows7"
                    ID="tbWorkPhone">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Cell Phone:</span>
                <div>
                    <idea:TextBox
                    runat="server"
                    Width="325px"
                    Skin="Windows7"
                    ID="tbCellPhone">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <span>Home Phone:</span>
                <div>
                    <idea:TextBox
                    runat="server"
                    Skin="Windows7"
                    Width="325px"
                    ID="tbHomePhone">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span>Avatar Path:</span>
                <div>
                    <idea:TextBox
                    runat="server"
                    Skin="Windows7"
                    Width="325px"
                    ID="tbAvatarPath">
                    </idea:TextBox>
                </div>
            </td>
            <td>
                <%--<span>Entered By:</span>
                <span>
                    <idea:Label
                    class="insightBlue"
                    runat="server"
                    ID="lblEnteredBy" />
                </span><br />
                <span>Updated By:</span>
                <span>
                    <idea:Label
                    class="insightBlue"
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
    <br />   
    <hr /> 
</div>