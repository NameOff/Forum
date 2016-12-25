<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Section.aspx.cs" Inherits="Forum.Section1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="color: red">Темы:</h3>
    <br/>
    <% if (IsUserLogined())
       { %>
        <asp:TextBox ID="SubjectName" runat="server"></asp:TextBox>
        <br/>
        <asp:Button Text="Создать новую тему" OnClick="OnClick" runat="server"/>
    <% } %>
    <% var subjects = GetAllSubjectsOfSection(GetSectionId());
       foreach (var subject in subjects)
       {
           %>
        <a class="forum-section" href="/Subject?subject=<%= subject.Id %>"><%= subject.Name %></a>
    <% if (IsUserAdmin())
           { %>
        <a style="color: red;" href="/Delete?subject=<%=subject.Id %>">Удалить тему</a>
    <% } %>
    <%
       } %>


</asp:Content>