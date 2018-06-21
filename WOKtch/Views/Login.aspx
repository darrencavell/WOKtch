<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplatePage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WOKtch.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <h1>Login</h1>
        <asp:Panel ID="success_box" runat="server" Visible="false" CssClass="alert alert-dismissible alert-success">
            <asp:Label ID="notificationSuccess_label" runat="server" class="form-text text-success" Text=""></asp:Label>
        </asp:Panel>
        <asp:Panel ID="error_box" runat="server" Visible="false" CssClass="alert alert-dismissible alert-danger">
            <asp:Label ID="notificationError_label" runat="server" class="form-text text-danger" Text=""></asp:Label>
        </asp:Panel>
        <div class="form-group">
            <asp:Label runat="server" Text="UserEmail"></asp:Label>
            <asp:TextBox ID="inputUserEmail_textBox" class="form-control" runat="server" placeholder="Enter email"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="UserPassword"></asp:Label>
            <asp:TextBox ID="inputUserPassword_textBox" class="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:CheckBox ID="rememberMe_checkBox" runat="server" clas="form-check"/>
            <asp:Label ID="Label1" runat="server" class="form-check-label" Text="Remember Me"></asp:Label>
        </div>
        <asp:Button class="btn btn-primary" runat="server" Text="Login" OnClick="login_button_Click" />
    </div>
</asp:Content>
