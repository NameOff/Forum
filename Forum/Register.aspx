<%@ Page Title="Регистрация" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Forum.Register" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=9afc4d65b28c38c2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Name" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Login" CssClass="name" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Password" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="PasswordBox" TextMode="Password" runat="server" CssClass="password"></asp:TextBox>
            <br />
            <asp:Label ID="CheckPassword" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="PasswordBox2" TextMode="Password" runat="server" CssClass="password"></asp:TextBox>
            <br />
            <asp:Label ID="EmailText" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="Email" runat="server" CssClass="password"></asp:TextBox>
            <br />
            <asp:Label Visible="false" ID="lblResult" runat="server" />
            <recaptcha:RecaptchaControl
                ID="recaptcha"
                runat="server"
                Theme="red"
                PublicKey="6LcBAAAAAAAAAKtzVYRsIgOAAvCFge3iiMtf6hI9"
                PrivateKey="6LcBAAAAAAAAACQnFb_BI5tX7OxqC-C5RtROzx-S" />
            <br />
            <asp:Button ID="Submit" runat="server" CssClass="submit" OnClick="Submit_OnClick" />
            <br />
            <asp:Label ID="Result" runat="server"></asp:Label>
</asp:Content>
