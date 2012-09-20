<%@ Page Title="Our Blog" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Blog.aspx.cs" Inherits="_1PromotionalProducts.Blog" %>

<%@ Register TagPrefix="pn1" TagName="pagenav" Src="~/PageNav.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; font-size: 35px;">
        Our Blog
    </div>
    <div id="admin" style="text-align: center;" runat="server">
        <asp:Button ID="btnAddNewBlog" runat="server" Text="Add New Blog" OnClick="btnAddNewBlog_Click" />
    </div>
    <br />
    <pn1:pagenav ID="pageNav1" runat="server" />
    <div id="blogs" runat="server">
        No Blogs.
    </div>
    <pn1:pagenav ID="pageNav2" runat="server" />
</asp:Content>
