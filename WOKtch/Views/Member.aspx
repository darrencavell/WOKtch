<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplatePage.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WOKtch.Views.Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="px-3">
        <asp:Label ID="notificationSuccess_label" runat="server" class="form-text text-success" Text=""></asp:Label>
        <asp:Label ID="notificationError_label" runat="server" class="form-text text-danger" Text=""></asp:Label>
        <asp:Panel ID="Panel2" runat="server" CssClass="horizontal card bg-secondary">
            <div class="small-container">
                <label class="col-sm-2 w-25">UserId</label>
                <asp:TextBox ID="textbox_userId" runat="server" placeholder="Set userId" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="small-container">
                <label class="col-sm-2 w-25">New Role</label>
                <asp:TextBox ID="textbox_role" runat="server" placeholder="Assign new role" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="small-container">
                <asp:Button ID="changeRole" runat="server" Text="Change Role" CssClass="align-middle btn btn-primary w-100" OnClick="changeRole_button_Click" />
            </div>
        </asp:Panel>
        <%--<asp:Repeater ID="member" runat="server" OnItemDataBound="member_ItemDataBound">--%>
        <asp:Repeater ID="member" runat="server">
            <HeaderTemplate>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col"><%= members.Columns[0] %></th>
                            <th scope="col"><%= members.Columns[1] %></th>
                            <th scope="col"><%= members.Columns[2] %></th>
                            <th scope="col"><%= members.Columns[3] %></th>
                            <th scope="col"><%= members.Columns[4] %></th>
                            <th scope="col"><%= members.Columns[5] %></th>
                            <th scope="col"><%= members.Columns[6] %></th>
                            <th scope="col"><%= members.Columns[7] %></th>
                            <th scope="col"><%= members.Columns[8] %></th>
                            <th>Delete</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr class="table-active">
                        <th class="align-middle"><%# Eval("UserId") %></th>
                        <th class="align-middle"><%# Eval("UserName") %></th>
                        <td class="align-middle"><%# Eval("UserEmail") %></td>
                        <td class="align-middle"><%# Eval("UserGender") %></td>
                        <td class="align-middle"><%# Eval("UserBirthDate") %></td>
                        <td class="align-middle"><%# Eval("UserPhoneNumber") %></td>
                        <td class="align-middle"><%# Eval("UserAddress") %></td>
                        <td class="align-middle">
                            <asp:Image ID="image" CssClass="small-image" runat="server" ImageUrl='<%# string.Format("~/{0}", Eval("UserProfilePicture")) %>' /></td>
                        <td class="align-middle"><%# Eval("UserRole") %></td>
                        <%--<td class="align-middle">
                            <asp:HiddenField ID="userId" runat="server" Value='<%# Eval("UserId") %>'/>
                            <asp:TextBox ID="textbox_role" runat="server" placeholder="Assign new role" CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="changeRole" runat="server" Text="Button" CssClass="align-middle btn btn-primary" OnClick="changeRole_button_Click"/>
                        </td>--%>
                        <td class="align-middle">
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" CssClass="card-link" NavigateUrl='<%# string.Format("{0}?userId={1}", "Member.aspx", Eval("UserId")) %>'>Change Role</asp:HyperLink>--%>
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="card-link" NavigateUrl='<%# string.Format("{0}?userId={1}", "Delete.aspx", Eval("UserId")) %>'>Delete</asp:HyperLink>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table> 
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>
