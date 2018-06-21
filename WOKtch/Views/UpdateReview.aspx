<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplatePage.Master" AutoEventWireup="true" CodeBehind="UpdateReview.aspx.cs" Inherits="WOKtch.Views.ReviewUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <asp:Panel ID="reviewSection" runat="server" Visible="true">
            <h1>Update Review</h1>
            <asp:Label ID="notificationSuccess_label" runat="server" class="form-text text-success" Text=""></asp:Label>
            <asp:Label ID="notificationError_label" runat="server" class="form-text text-danger" Text=""></asp:Label>
            <div class="form-group">
                <asp:Label runat="server" Text="Rating"></asp:Label>
                <asp:TextBox ID="editRating_textBox" class="form-control" runat="server" placeholder="1-5"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Review"></asp:Label>
                <asp:TextBox ID="editReview_textBox" class="form-control" runat="server" placeholder="up to 255 characters"></asp:TextBox>
            </div>
            <asp:Button class="btn btn-primary" runat="server" Text="Update" OnClick="update_button_Click"/>
        </asp:Panel>
    </div>
</asp:Content>
