<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactAddressPropertiesView.ascx.cs" Inherits="Accounts_Views_ContactAddressPropertiesView" %>
<div class="propertypagecontent">
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
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Title:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbTitle"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvTitle"
                    ErrorMessage="<br />Please enter a title"
                    InitialValue=""
                    ControlToValidate="tbTitle"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span><b>Address Type:</b></span>
                <div>
                    <idea:DropDownList
                    runat="server"
                    EmptyMessage="-- Select Type --"
                    ID="ddlAddressType">
                        <Items>
                            <telerik:RadComboBoxItem
                            Text=""
                            Value="" />
                            <telerik:RadComboBoxItem
                            Text="Primary"
                            Value="1" />
                            <telerik:RadComboBoxItem
                            Text="Billing"
                            Value="3" />
                            <telerik:RadComboBoxItem
                            Text="Shipping"
                            Value="2" />
                        </Items>
                    </idea:DropDownList>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvAddressType"
                    ErrorMessage="<br />Please select an address type"
                    InitialValue=""
                    ControlToValidate="ddlAddressType"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Address 1:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbAddress1"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvAddress1"
                    ErrorMessage="<br />Please enter address 1"
                    InitialValue=""
                    ControlToValidate="tbAddress1"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span>Address 2:</span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbAddress2"
                    Width="325px">
                    </idea:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>City:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbCity"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvCity"
                    ErrorMessage="<br />Please enter a city"
                    InitialValue=""
                    ControlToValidate="tbCity"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
                <span><b>State:</b></span>
                <div>
                    <idea:USStatesDDL
                    runat="server"
                    ID="ddlState">
                    </idea:USStatesDDL>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvState"
                    ErrorMessage="<br />Please select a state"
                    InitialValue=""
                    ControlToValidate="ddlState"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="propertypagecells">
                <span><b>Zip:</b></span>
                <div>
                    <idea:TextBox
                    Skin="Windows7"
                    runat="server"
                    ID="tbZip"
                    Width="325px">
                    </idea:TextBox>
                    <asp:RequiredFieldValidator
                    runat="server"
                    ID="rfvZip"
                    ErrorMessage="<br />Please enter a zip code"
                    InitialValue=""
                    ControlToValidate="tbZip"
                    Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
            <td>
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
