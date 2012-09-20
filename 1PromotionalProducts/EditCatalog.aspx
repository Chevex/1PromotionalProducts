<%@ Page Title="Edit Catalog" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditCatalog.aspx.cs" Inherits="_1PromotionalProducts.EditCatalog" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="pagetitle" style="text-align: center; font-size: 35px;" runat="server">
        Edit Catalog
    </div>
    <br />
    <CKEditor:CKEditorControl ID="rteBody" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
    <br />
    <center>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" 
            onclick="btnSubmit_Click" /></center>
</asp:Content>
