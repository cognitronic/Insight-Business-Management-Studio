<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginView.ascx.cs" Inherits="Views_LoginView" %>
<div style="margin-bottom: 30px;">
    &nbsp;
</div>
<div id="logincontainer">
    <div id="logincontent" runat="server">
        <div>
            <div>Username:</div>
            <idea:TextBox
            runat="server"
            Width="275px"
            ID="tbUsername">
            </idea:TextBox>
        </div><br />
        <div>
            <div>Password:</div>
            <idea:TextBox
            runat="server"
            Width="275px"
            ID="tbPassword"
            TextMode="Password">
            </idea:TextBox>
        </div><br />
        <div>
            <idea:Label
            runat="server"
            ForeColor="#ff0000"
            ID="lblLoginMessage"
            Visible="false">
            </idea:Label>
        </div>
        <div>
            <span>
                <asp:Button
                    style="color: #000000 !important; width: 100px !important; height: 50px !important;"
                    runat="server"
                    ID="lbLogin"
                    Text="Login"
                    OnClick="LoginClicked" />
            </span>
            <span>
                <asp:Button
                    style="color: #000000 !important; width: 175px !important; height: 50px !important;"
                    runat="server"
                    ID="lbForgotPassword"
                    Text="Forgot Password?"
                    OnClick="ForgotPasswordClicked" />
            </span>
        </div>
    </div>
</div>
