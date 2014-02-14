<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MasterPageHeaderView.ascx.cs" Inherits="Insight.Website.Views.MasterPageHeaderView" %>
<div id="headerwrapper">
    <div id="headernav">
        <div runat="server" id="loggedinuser">
            The currently logged on user is:
            <idea:Label
            runat="server"
            ID="lblCurrentUser">
            </idea:Label>
        </div>
        <div runat="server" id="settingsLinks">
            <span>
                <idea:LinkButton
                runat="server"
                ID="lbMyPreferences">
                    My Preferences
                </idea:LinkButton> |
            </span>
            <span>
                <idea:LinkButton
                runat="server"
                ID="lbSupport">
                    Support
                </idea:LinkButton> |
            </span>
            <span>
                <idea:LinkButton
                runat="server"
                ID="lbFeedBack">
                    Feedback
                </idea:LinkButton> |
            </span>
            <span>
                <idea:LinkButton
                runat="server"
                OnClick="AdminClicked"
                ID="lbAdmin">
                    Admin
                </idea:LinkButton> |
            </span>
            <span>
                <idea:LinkButton
                runat="server"
                OnClick="LogoutClicked"
                ID="lbLogout">
                    Logout
                </idea:LinkButton>
            </span>
        </div>
        <div runat="server" id="headersearch">
            <span>
                <idea:TextBox ID="TextBox1"
                runat="server"
                Width="240px">
                </idea:TextBox>
            </span>
            <span>
                <div style="float: right; margin-top: 7px;" id="searchbutton">
                <idea:LinkButton
                runat="server"
                OnClick="SearchClicked"
                ID="lbHeaderSearch">
                    Search
                </idea:LinkButton>
                </div>
            </span>
        </div>
    </div>
    <div runat="server" id="logo">
    </div>
</div>
<div style="clear: both;"></div>
<div runat="server" id="primarynav">
</div>
<div style="clear: both;"></div>
<div runat="server" id="subnav">
    <%--<ul>
        <li>
            Orders
        </li>
        <li>
            Leads
        </li>
        <li>
            Marketing
        </li>
    </ul>--%>
</div>
<div style="clear: both;"></div>
