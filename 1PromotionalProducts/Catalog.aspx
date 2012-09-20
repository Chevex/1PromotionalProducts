<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="_1PromotionalProducts.CatalogPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center;">
        <asp:Button ID="btnEditCatalog" CausesValidation="false" runat="server" Text="Edit This Page"
            OnClick="btnEditCatalog_Click" />
    </div>
    <div id="pagetitle" style="font-size: 35px; text-align: center;" runat="server">
        Catalog Title</div>
    <br />
    <div id="catalogpagecontent" runat="server">
    </div>
    <br />
    <div style="text-align: center;">
        <asp:HyperLink ID="hlCatalogLink" Font-Size="25px" runat="server">Catalog Link</asp:HyperLink>
    </div>
</asp:Content>
