<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPropertiesView.ascx.cs" Inherits="Insight.Website.Views.UserPropertiesView" %>
<%@ Register tagPrefix="idea" namespace="IdeaSeed.Web.UI" assembly="IdeaSeed.Web" %>
<%@ Register tagPrefix="idea" namespace="Insight.Web.Controls" assembly="Insight.Web" %>
<%@ Register tagPrefix="idea" namespace="Insight.Accounts.Web.Controls" assembly="Insight.Accounts" %>
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
                <span>Username:</span>
                <span>
                    <idea:TextBox
                    runat="server"
                    Width="325px"
                    Skin="Windows7"
                    ID="tbUsername">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator1"
                    ErrorMessage="<br />Please enter username"
                    InitialValue=""
                    ControlToValidate="tbUsername"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </span>
            </td>
            <td>
                <span>Email:</span>
                <span>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbEmail"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator2"
                    ErrorMessage="<br />Please enter email"
                    InitialValue=""
                    ControlToValidate="tbEmail"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidator1"
                    ControlToValidate="tbEmail"
                    ValidationExpression=".*@.*\..*" 
                    ErrorMessage="<br />Email address is invalid." 
                    Display="Dynamic" 
                    EnableClientScript="true"
                    Runat="server"/>
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
                <span>DepartmentID:</span>
                <div>
                    <idea:DropDownList
                    runat="server"
                    ID="ddlDepartment"
                    Skin="Windows7">
                        <Items>
                            <telerik:RadComboBoxItem
                            Value="1"
                            Text="Software" />
                            <telerik:RadComboBoxItem
                            Value="2"
                            Text="IT" />
                        </Items>
                    </idea:DropDownList>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="RequiredFieldValidator3"
                    ErrorMessage="<br />Please select department"
                    InitialValue=""
                    ControlToValidate="ddlDepartment"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
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
            <td class="propertpagecells">
                <span>IM Handle:</span>
                <div>
                    <idea:TextBox
                    runat="server"
                    Skin="Windows7"
                    Width="325px"
                    ID="tbIMHandle">
                    </idea:TextBox>
                </div>
            </td>
            <td>
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
        </tr>
        <tr>
            <td>
                &nbsp;
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