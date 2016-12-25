<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Forum._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="color: red">Разделы:</h3>
    <% if (IsUserAdmin())
       { %>
    <asp:TextBox ID="SectionName" runat="server"></asp:TextBox>
    <br/>
    <asp:Button runat="server" OnClick="OnClick" Text="Создать раздел"/>
    <br/>
    <% } %>
    <% var sections = GetAllSections();
       foreach (var section in sections)
       {
           %>
        <a class="forum-section" href="/Section?section=<%= section.Id %>"><%= section.Name %></a>
        <% if (IsUserAdmin())
           { %>
        <a style="color: red;" href="/Delete?section=<%=section.Id %>">Удалить раздел</a>
    <% } %>
    <%
       } %>

</asp:Content>
