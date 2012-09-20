<%@ Page Title="Edit List" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditList.aspx.cs" Inherits="_1PromotionalProducts.EditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="pagetitle" style="text-align: center; font-size: 35px;" runat="server">
        Edit Left Sleeve Catalog List
    </div>
    <br />
    <div id="leftalign" runat="server">
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top; width: 150px; padding-right: 10px;">List Title:
                    <br />
                    <asp:TextBox ID="tbxListTitle1" Width="125px" runat="server"></asp:TextBox><asp:ImageButton
                        ID="imgRefresh1" CausesValidation="false" Width="20px" ImageUrl="images/bluerefresh.gif"
                        runat="server" OnClick="imgRefresh1_Click" />
                    <br />
                    <br />
                    <asp:ListBox ID="lbxCatalogs1" Width="150px" Height="200px" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="lbxCatalogs1_SelectedIndexChanged"></asp:ListBox>
                    <br />
                    <br />
                    <asp:Button ID="btnNewCatalog1" CausesValidation="false" runat="server" Text="New Catalog"
                        OnClick="btnNewCatalog1_Click" />
                </td>
                <td style="vertical-align: top; padding: 10px; border: solid 3px #7F79E6; background-color: #535684;">
                    <div style="width: 255px; margin: auto;">
                        <asp:CheckBox ID="cbxDeleteCatalog1" Text="Delete this catalog" runat="server" AutoPostBack="True"
                            OnCheckedChanged="cbxDeleteCatalog1_CheckedChanged" /><br />
                        <br />
                        Catalog Name:<br />
                        <asp:TextBox ID="tbxCatalogName1" Width="250px" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbxCatalogName1"
                            runat="server" Display="Dynamic" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                        <br />
                        Catalog URL:<br />
                        <asp:TextBox ID="tbxCatalogURL1" Width="250px" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbxCatalogURL1"
                            runat="server" Display="Dynamic" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CheckBox ID="cbxShowDescription1" Text="Show description when clicked." runat="server" /><br />
                        <br />
                        <div style="text-align: center;">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                Style="height: 26px" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="text-align: center;">
                        <asp:HyperLink ID="hlEditCatalog1" ForeColor="#ffff00" Font-Underline="true" Font-Size="20px"
                            runat="server">Edit This Catalog's Description</asp:HyperLink>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="rightalign" runat="server">
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top; padding: 10px; border: solid 3px #7F79E6; background-color: #535684;">
                    <div style="width: 255px; margin: auto;">
                        <asp:CheckBox ID="cbxDeleteCatalog2" Text="Delete this catalog" runat="server" AutoPostBack="True"
                            OnCheckedChanged="cbxDeleteCatalog1_CheckedChanged" /><br />
                        <br />
                        Catalog Name:<br />
                        <asp:TextBox ID="tbxCatalogName2" Width="250px" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbxCatalogName2"
                            runat="server" Display="Dynamic" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                        <br />
                        Catalog URL:<br />
                        <asp:TextBox ID="tbxCatalogURL2" Width="250px" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="tbxCatalogURL2"
                            runat="server" Display="Dynamic" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CheckBox ID="cbxShowDescription2" Text="Show description when clicked." runat="server" /><br />
                        <br />
                        <div style="text-align: center;">
                            <asp:Button ID="btnSubmit2" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                Style="height: 26px" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div style="text-align: center;">
                        <asp:HyperLink ID="hlEditCatalog2" ForeColor="#ffff00" Font-Underline="true" Font-Size="20px"
                            runat="server">Edit This Catalog's Description</asp:HyperLink>
                    </div>
                </td>
                <td style="vertical-align: top; width: 150px; padding-left: 10px; text-align: right;">List Title:
                    <br />
                    <asp:TextBox ID="tbxListTitle2" Width="125px" runat="server"></asp:TextBox><asp:ImageButton
                        ID="imgRefresh2" CausesValidation="false" Width="20px" ImageUrl="images/bluerefresh.gif"
                        runat="server" OnClick="imgRefresh2_Click" />
                    <br />
                    <br />
                    <asp:ListBox ID="lbxCatalogs2" Width="150px" Height="200px" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="lbxCatalogs1_SelectedIndexChanged"></asp:ListBox>
                    <br />
                    <br />
                    <asp:Button ID="btnNewCatalog2" CausesValidation="false" runat="server" Text="New Catalog"
                        OnClick="btnNewCatalog1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
