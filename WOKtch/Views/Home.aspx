<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplatePage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WOKtch.Views.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <asp:Panel ID="Panel2" runat="server" CssClass="container">
            <h1 class="display-3">Hello,
            <asp:Label ID="name" runat="server" Text="Label"></asp:Label></h1>
            <p class="lead">A Binusian multinational watch-retail company known for its fast-fashion for men, women, teenagers and children. We are here to serve you better!</p>
            <hr class="my-4" />
            <p runat="server" id="prolog"></p>
            <p class="lead" runat="server" id="profile">
                <a class="btn btn-primary btn-lg" href="Profile.aspx" role="button">Check Profile</a>
            </p>
        </asp:Panel>
    </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="container">
        <asp:Repeater ID="catalog" runat="server" OnItemDataBound="catalog_ItemDataBound">
            <ItemTemplate>
                <asp:Panel ID="Panel1" runat="server" CssClass="card-container card bg-secondary mt-3 float-left">
                    <h1 class="card-header mt-3"><asp:HyperLink ID="HyperLink3" runat="server" CssClass="card-link" NavigateUrl='<%# string.Format("{0}?productId={1}", "ProductShowcaseDetail.aspx", Eval("ProductId")) %>'><%# Eval("ProductName") %></asp:HyperLink></h1>
                    <div runat="server" class="card-body">
                        <h5 class="card-title">Rp. <%# Eval("ProductPrice") %></h5>
                    </div>
                    <asp:Image ID="Image1" runat="server" CssClass="img-thumbnail img" ImageUrl='<%# string.Format("~/{0}", Eval("ProductImage")) %>' alt="Product Image" />
                    <div class="card-body">
                        <p class="card-text">
                            Some quick example text to build on the card title and make up the bulk of the card&#39;s content.
                        </p>
                    </div>
                    <asp:Panel ID="editorAdmin" runat="server" CssClass="card-body" Visible="false">
                        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="card-link btn btn-primary btn-sm" NavigateUrl='<%# string.Format("{0}?productId={1}", "Update.aspx", Eval("ProductId")) %>'>Update</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="card-link btn btn-primary btn-sm" NavigateUrl='<%# string.Format("{0}?productId={1}", "Delete.aspx", Eval("ProductId")) %>'>Delete</asp:HyperLink>
                    </asp:Panel>
                    <div class="card-footer text-muted alert-danger mb-3">
                        <%# Eval("ProductStock") %> left
                    </div>
                </asp:Panel>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

</asp:Content>
