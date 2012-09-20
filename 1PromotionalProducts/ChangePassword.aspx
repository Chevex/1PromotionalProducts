<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="_1PromotionalProducts.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Current Password:
    <asp:TextBox ID="tbxCurrentPassword" TextMode="Password" Width="250px" runat="server">
    </asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbxCurrentPassword"
        Display="Dynamic" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="tbxCurrentPassword"
        Display="Dynamic" runat="server" ErrorMessage="* Invalid Password"></asp:CustomValidator>
    <br />
    New Password:
    <asp:TextBox ID="tbxNewPassword" TextMode="Password" Width="250px" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="tbxNewPassword"
        runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator>
    <br />
    Confirm New Password:
    <asp:TextBox ID="tbxConfirmPassword" TextMode="Password" Width="250px" runat="server"></asp:TextBox><br />
    <asp:CompareValidator ID="CompareValidator1" Display="Dynamic" ControlToCompare="tbxNewPassword"
        ControlToValidate="tbxConfirmPassword" runat="server" ErrorMessage="* Passwords do not match"></asp:CompareValidator>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Change Password" OnClick="btnSubmit_Click" />
</asp:Content>
