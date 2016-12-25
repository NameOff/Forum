<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="Forum.Subject1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="color: red">Тема <%= GetSubjectName(GetSubjectId()) %>:</h3>
    <% var messages = GetAllMessagesOfSubject(GetSubjectId());
       foreach (var message in messages)
       {
           %>
        <div class="message">
            <pre><%= message.Content %></pre>
            <div>Автор: <%= GetUserName(message.Id) %> </div>
            <div>Дата: <%= GetTime(message.Id) %></div>
        </div>
    <% if (IsUserAdmin())
           { %>
        <a style="color: red;" href="/Delete?user=<%=message.UserId %>">Удалить автора сообщения</a>
        <br/>
    <% } %>
    <% if (IsUserAdmin() || message.UserId == User.Id)
       { %>
       <a style="color: red;" href="/Delete?message=<%=message.Id %>">Удалить сообщение</a>
        <br/>    
    <%   } %>
    <%
       } %>
    <% if (IsUserLogined())
       {
            %>
        <asp:TextBox ID="MessageText" TextMode="MultiLine" Width="400" runat="server"></asp:TextBox>
        <br/>
        <asp:Button OnClick="OnClick" Text="Отправить" runat="server"/>
    <%
       } %>
        

</asp:Content>
