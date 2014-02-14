<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginView.ascx.cs" Inherits="Insight.Website.Views.LoginView" %>
<div style="margin-bottom: 30px;">
    &nbsp;
</div>
<div id="logincontainer">
    <div style="margin-left: 83px;">
        <telerik:RadBinaryImage
        runat="server"
        ID="imgLoginLogo"
        ImageUrl="~/Images/Logo.png" />
    </div>
    <div style="padding: 5px 0px; margin-left: 5px;">
        <b>Sign in below and start compiling Insight!</b>
    </div>
    <div id="logincontent" runat="server">
        <div>
            <div style="margin-bottom: 3px;">Username</div>
            <idea:TextBox
            runat="server"
            Width="279px"
            Skin="Windows7"
            ID="tbUsername">
            </idea:TextBox>
        </div><br />
        <div>
            <div style="margin-bottom: 3px;">Password</div>
            <idea:TextBox
            runat="server"
            Width="279px"
            Skin="Windows7"
            ID="tbPassword"
            TextMode="Password">
            </idea:TextBox>
        </div><br />
        <div style="margin-bottom: 5px;">
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
