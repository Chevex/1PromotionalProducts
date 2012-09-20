<%@ Page Title="Capability Statement" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="CapabilityStatement.aspx.cs" Inherits="_1PromotionalProducts.CapabilityStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center;">
        <asp:Button ID="btnEdit" runat="server" Text="Edit Capability Statement" CausesValidation="False"
            OnClick="btnEdit_Click" />
    </div>
    <div style="text-align: center; font-size: 35px;">
        Capability Statement
    </div>
    <br />
    <div id="capabilitystatement" runat="server">
    </div>
</asp:Content>
