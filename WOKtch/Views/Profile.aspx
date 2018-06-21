<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplatePage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WOKtch.Views.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="container">

        <div class="jumbotron">
            <asp:Panel ID="Panel2" runat="server" CssClass="profileContainer">
                <asp:Panel ID="Panel3" runat="server" CssClass="profileItemPP">
                    <asp:Image ID="Image1" CssClass="resized" runat="server"/>
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" CssClass="profileItemBiodata">
                    <h1 class="display-3 profileItemBiodataList">
                        <asp:Label ID="name" runat="server" Text=""></asp:Label>   
                    </h1>
                    <p class="lead pl-1 profileItemBiodataList">
                        <asp:Label ID="email" runat="server" Text=""></asp:Label>
                    </p>
                    <hr class="my-4 profileItemBiodataList" />
                    <p class="lead pl-1 profileItemBiodataList">
                        <asp:Label ID="Label1" runat="server" Text="Gender" CssClass="profileItemBiodataRowList"></asp:Label>
                        <asp:Label ID="gender" runat="server" Text="" CssClass="profileItemBiodataRowList"></asp:Label>
                    </p>
                    <p class="lead pl-1 profileItemBiodataList">
                        <asp:Label ID="Label2" runat="server" Text="Phone Number" CssClass="profileItemBiodataRowList"></asp:Label>
                        <asp:Label ID="phoneNumber" runat="server" Text="" CssClass="profileItemBiodataRowList"></asp:Label>
                    </p>
                    <p class="lead pl-1 profileItemBiodataList">
                        <asp:Label ID="Label3" runat="server" Text="Address" CssClass="profileItemBiodataRowList"></asp:Label>
                        <asp:Label ID="address" runat="server" Text="" CssClass="profileItemBiodataRowList"></asp:Label>
                    </p>
                    <p class="lead pl-1 profileItemBiodataList">
                        <asp:Label ID="Label4" runat="server" Text="Role" CssClass="profileItemBiodataRowList"></asp:Label>
                        <asp:Label ID="role" runat="server" Text="" CssClass="profileItemBiodataRowList"></asp:Label>
                    </p>
                </asp:Panel>
            </asp:Panel>

        </div>
    </asp:Panel>
</asp:Content>
