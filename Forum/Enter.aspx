<%@ Page Title="Вход" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enter.aspx.cs" Inherits="Forum.Enter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Name" runat="server"></asp:Label>
    <br />
    <asp:TextBox ID="Login" CssClass="name" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Password" runat="server"></asp:Label>
    <br />
    <asp:TextBox ID="PasswordBox" TextMode="Password" runat="server" CssClass="password"></asp:TextBox>
    <br />
    <asp:Button ID="Submit" runat="server" CssClass="submit" OnClick="Submit_OnClick" />
    <br />
    <asp:Label ID="Result" runat="server"></asp:Label>
</asp:Content>