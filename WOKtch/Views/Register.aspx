<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplatePage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WOKtch.Views.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <h1>Register</h1>
        <asp:Panel ID="success_box" runat="server" Visible="false" CssClass="alert alert-dismissible alert-success">
            <asp:Label ID="notificationSuccess_label" runat="server" class="form-text text-success" Text=""></asp:Label>
        </asp:Panel>
        <asp:Panel ID="error_box" runat="server" Visible="false" CssClass="alert alert-dismissible alert-danger">
            <asp:Label ID="notificationError_label" runat="server" class="form-text text-danger" Text=""></asp:Label>
        </asp:Panel>
        <div class="form-group">
            <asp:Label runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="inputUserName_textBox" class="form-control" runat="server" placeholder="Enter name"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="inputEmail_textBox" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="UserPassword"></asp:Label>
            <asp:TextBox ID="inputUserPassword_textBox" class="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="inputConfirmyUserPassword_textBox" class="form-control" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="inputGender_dropDown" class="form-control" runat="server">
                <asp:ListItem Text="Gender" Value="Gender"/>
                <asp:ListItem Text="Male" Value="Male"/>
                <asp:ListItem Text="Female" Value="Female"/>
            </asp:DropDownList>
        </div>
        <div class="form-group" >
            <asp:Label runat="server" Text="Birth Date"></asp:Label>
            <asp:Calendar ID="inputBirthDate_calendar" class="form-control" runat="server"></asp:Calendar>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Profile Picture"></asp:Label>
            <asp:FileUpload ID="upload" runat="server" class="form-control-file" aria-describedby="fileHelp"/>
            <small id="fileHelp" class="form-text text-muted">This is some placeholder block-level help text for the above input. It's a bit lighter and easily wraps to a new line.</small>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Phone Number"></asp:Label>
            <asp:TextBox ID="inputPhoneNumber_textBox" class="form-control" runat="server" placeholder="Enter Phone Number"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="inputAddress_textBox" class="form-control" runat="server" placeholder="Address"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-primary" runat="server" Text="Add" OnClick="register_button_Click" />
    </div>
</asp:Content>
