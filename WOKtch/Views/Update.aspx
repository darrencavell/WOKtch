<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplatePage.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="WOKtch.Views.Update" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <h1>Update Watch</h1>
        <asp:Label ID="notificationSuccess_label" runat="server" class="form-text text-success" Text=""></asp:Label>
        <asp:Label ID="notificationError_label" runat="server" class="form-text text-danger" Text=""></asp:Label>
        <div class="form-group">
            <asp:Image ID="image" runat="server" CssClass="img-thumbnail img" alt="Product Image"/>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="WatchName"></asp:Label>
            <asp:TextBox ID="inputWatchName_textBox" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="WatchPrice"></asp:Label>
            <asp:TextBox ID="inputUserWatchPrice_textBox" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Quantity"></asp:Label>
            <asp:TextBox ID="inputUserWatchQuantity_textBox" class="form-control" runat="server" placeholder="Insert Quantity" TextMode="Number"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="exampleInputFile">File input</label>
            <asp:FileUpload ID="upload" runat="server" class="form-control-file" aria-describedby="fileHelp"/>
            <small id="fileHelp" class="form-text text-muted">This is some placeholder block-level help text for the above input. It's a bit lighter and easily wraps to a new line.</small>
        </div>
        <asp:Label ID="test" runat="server" Text=""></asp:Label>
        <asp:Button class="btn btn-primary" runat="server" Text="Update" OnClick="update_button_Click" />
    </div>
</asp:Content>
