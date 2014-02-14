<%@ Page Title="Welcome To Insight!  Please Login" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Insight.Website.UtilityPages.Login" %>
<%@ Register TagPrefix="idea" TagName="LoginView" Src="~/Views/LoginView.ascx" %>
<%@ MasterType VirtualPath="~/MasterPages/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpSideBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpMainContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="cpFullWidth" ID="login" runat="server">
    <idea:LoginView 
    runat="server" 
    id="loginView">
    </idea:LoginView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cpFooter" runat="server">
</asp:Content>
