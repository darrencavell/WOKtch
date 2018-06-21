<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplatePage.Master" AutoEventWireup="true" CodeBehind="ProductShowcaseDetail.aspx.cs" Inherits="WOKtch.Views.ProductDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">

        <div class="product">
            <div class="showcase-image-preview">
                <asp:Image ID="image" runat="server" CssClass="image-show" alt="Product Image" />
            </div>
            <div class="showcase-product-preview">
                <div class="box">
                    <asp:Label ID="productName" runat="server" Text="" CssClass="display-2 product-preview-name"><h1></h1></asp:Label>
                    <div class="display-4">
                        $<asp:Label ID="productPrice" runat="server" Text="" CssClass="product-preview-price"><h3></h3></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="productStock" runat="server" Text="" CssClass="product-preview-quantity"><h3></h3></asp:Label> left
                    </div>
                    <p>
                        Some quick example text to build on the card title and make up the bulk of the card's content.
                    </p>
                    <asp:Panel ID="addToCartSection" runat="server" Visible="false">
                        <asp:TextBox ID="textbox_userId" runat="server" placeholder="Input quantity" CssClass="form-control w-50 custom-control-inline"></asp:TextBox>
                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Add To Cart" OnClick="add_button_Click" /> 
                    </asp:Panel>
                </div>
            </div>
        </div>

        <asp:Panel ID="Panel1" runat="server" CssClass="card mt-3">
            <asp:Repeater ID="review" runat="server" OnItemDataBound="review_ItemDataBound">
                <ItemTemplate>
                    <asp:Panel ID="Panel1" runat="server" CssClass="card text-white bg-dark mb-3 float-left">
                        <asp:HiddenField ID="userId" runat="server" Value='<%# Eval("UserId") %>' />
                        <%--<div class="card text-white bg-dark mb-3 float-left" style="max-width: 20rem;">--%>
                        <div class="card-header"><%# Eval("ReviewRating") %>/5</div>
                        <div class="card-body">
                            <%--<h4 class="card-title">Secondary card title</h4>--%>
                            <p class="card-text"><%# Eval("ReviewText") %></p>
                        </div>
                        <asp:Panel ID="editorAdmin" runat="server" CssClass="card-body" Visible="false">
                            <%--<div id="editorAdmin" runat="server" class="card-body" Visible="true">--%>
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="card-link" NavigateUrl='<%# string.Format("{0}?review={1}", "UpdateReview.aspx", Eval("ReviewId")) %>'>Edit</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="card-link" NavigateUrl='<%# string.Format("{0}?review={1}", "Delete.aspx", Eval("ReviewId")) %>'>Delete</asp:HyperLink>
                            <%--</div>--%>
                        </asp:Panel>
                    </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>

        <asp:Panel ID="reviewSection" runat="server" Visible="false" CssClass="mt-3">
            <h1>Review</h1>
            <asp:Label ID="notificationSuccess_label" runat="server" class="form-text text-success" Text=""></asp:Label>
            <asp:Label ID="notificationError_label" runat="server" class="form-text text-danger" Text=""></asp:Label>
            <div class="form-group">
                <asp:Label runat="server" Text="Rating"></asp:Label>
                <asp:TextBox ID="inputRating_textBox" class="form-control" runat="server" placeholder="1-5"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Review"></asp:Label>
                <asp:TextBox ID="inputReview_textBox" class="form-control" runat="server" placeholder="up to 255 characters"></asp:TextBox>
            </div>
            <asp:Button class="btn btn-primary" runat="server" Text="Add" OnClick="add_button_Click" />
        </asp:Panel>
    </div>
</asp:Content>
