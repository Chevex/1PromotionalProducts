<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="_1PromotionalProducts.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center;">
        <asp:Button ID="btnEdit" CausesValidation="false" runat="server" Text="Edit Contact Info"
            OnClick="btnEdit_Click" />
    </div>
    <div style="text-align: center; font-size: 35px;">
        Contact Us
    </div>
    <br />
    <div style="width: 405px; margin: auto;">
        Name:
        <asp:TextBox ID="tbxName" Width="250px" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ControlToValidate="tbxName"
            runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        <br />
        <br />
        Email:
        <asp:TextBox ID="tbxEmail" Width="300px" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
            ControlToValidate="tbxEmail" ErrorMessage="* Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <asp:CustomValidator ID="CustomValidator1" Display="Dynamic" runat="server" ErrorMessage="* We need a way to contact you."></asp:CustomValidator>
        <br />
        Phone:
        <asp:TextBox ID="tbxPhone" Width="300px" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
            ControlToValidate="tbxPhone" runat="server" ErrorMessage="RegularExpressionValidator"
            ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
        <br />
        <br />
        Comments/Questions:<br />
        <asp:TextBox ID="tbxBody" Width="400px" Height="150px" TextMode="MultiLine" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="tbxBody"
            runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />
        <br />
        <div id="contactinfo" runat="server">
        </div>
    </div>
</asp:Content>
