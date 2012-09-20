<%@ Page Title="Add/Edit Post" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddEditPost.aspx.cs" Inherits="_1PromotionalProducts.AddEditPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: 35px; text-align: center;">
        Add/Edit Blog Post
    </div>
    <br />
    <asp:CheckBox ID="cbxDeletePost" Text="Delete this post." runat="server" />
    <br />
    <br />
    Title:<br />
    <asp:TextBox ID="tbxTitle" Width="300px" runat="server"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbxTitle"
        runat="server" ErrorMessage="* Title Required"></asp:RequiredFieldValidator>
    <br />
    Body:<br />
    <div id="editor">editor here</div>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>
