<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactEmailPropertiesView.ascx.cs" Inherits="Accounts_Views_ContactEmailPropertiesView" %>
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
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Email Type:</b></span>
                <div>
                    <idea:EmailTypeDDL
                    runat="server"
                    Skin="Windows7"
                    id="ddlEmailType">
                    </idea:EmailTypeDDL>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvEmailType"
                    ErrorMessage="<br />Please select email type"
                    InitialValue=""
                    ControlToValidate="ddlEmailType"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span><b>Email Address:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbEmail"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvEmail"
                    ErrorMessage="<br />Please enter an email address"
                    InitialValue=""
                    ControlToValidate="tbEmail"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator 
                    ID="valEmailAddress"
                    ControlToValidate="tbEmail"
                    ValidationExpression=".*@.*\..*" 
                    ErrorMessage="<br />Email address is invalid." 
                    Display="Dynamic" 
                    EnableClientScript="true"
                    Runat="server"/>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
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
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <br />   
    <hr /> 
</div>