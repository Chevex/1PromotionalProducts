<%@ Page Title="About Us" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="_1PromotionalProducts.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center;">
        <asp:Button ID="btnEdit" CausesValidation="false" runat="server" Text="Edit About Info"
            OnClick="btnEdit_Click" />
    </div>
    <div style="text-align: center; font-size: 35px;">
        About Us
    </div>
    <br />
    <div id="aboutus" runat="server">
    </div>
</asp:Content>
