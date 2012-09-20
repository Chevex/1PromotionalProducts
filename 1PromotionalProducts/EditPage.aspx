<%@ Page Title="Edit Page" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="_1PromotionalProducts.EditPage" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align: center; font-size: 35px;">
        Edit Page
    </div>
    <br />
    <CKEditor:CKEditorControl ID="rteBody" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
    <br />
    <center>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" OnClick="btnSubmit_Click" /></center>
</asp:Content>
