<%@ Page Title="Welcome To Insight!  Please Login" Language="C#" MasterPageFile="~/MasterPages/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="UtilityPages_Login" %>
<%@ Register TagPrefix="idea" TagName="LoginView" Src="~/Views/LoginView.ascx" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpContentHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpSideBar" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <idea:LoginView runat="server" id="loginView"></idea:LoginView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cpFooter" Runat="Server">
</asp:Content>

