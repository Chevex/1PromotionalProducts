<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="_1PromotionalProducts.Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="admin" runat="server">
        <asp:Button ID="btnEdit" CausesValidation="false" runat="server" Text="Edit This Blog Post"
            OnClick="btnEdit_Click" />
    </div>
    <div id="PostTitle" style="font-size: 35px; color: #ffffcc;" runat="server">
    </div>
    <div id="PostDate" runat="server">
    </div>
    <!-- AddThis Button BEGIN -->
    <a class="addthis_button" href="http://www.addthis.com/bookmark.php?v=250&amp;username=xa-4ba7804769466606">
        <img src="http://s7.addthis.com/static/btn/v2/lg-share-en.gif" width="125" height="16"
            alt="Bookmark and Share" style="border: 0" /></a><script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#username=xa-4ba7804769466606"></script>

    <!-- AddThis Button END -->
    <br />
    <div id="PostBody" runat="server">
    </div>
    <br />
    <hr />
    <br />
    <span id="commentcount" runat="server">0</span> Comment(s)
    <br />
    <br />
    <div id="comments" runat="server">
    </div>
    <br />
    <hr />
    <br />
    <div id="addcomment">
        <div style="font-size: 25px;">
            Add Comment</div>
        <br />
        Name:
        <asp:TextBox ID="tbxAuthor" Width="250px" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbxAuthor"
            runat="server" ErrorMessage="* Name required."></asp:RequiredFieldValidator>
        <br />
        Website:
        <asp:TextBox ID="tbxWebsite" Width="250px" runat="server"></asp:TextBox>
        (optional)
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbxWebsite"
            runat="server" ErrorMessage="Invalid URL. Don't forget HTTP://" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
        <br />
        Body:
        <br />
        <asp:TextBox ID="tbxComment" Width="400px" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbxComment"
            runat="server" ErrorMessage="* Comment cannot be blank."></asp:RequiredFieldValidator>
        <br />
        <img src="JpegImage.aspx" />
        <br />
        Enter the code above in the box below.
        <br />
        <asp:TextBox ID="tbxCode" runat="server"></asp:TextBox>
        <br />
        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="tbxCode" runat="server"
            ErrorMessage="* Invalid Code"></asp:CustomValidator>
        <br />
        <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" OnClick="btnAddComment_Click" />
    </div>
</asp:Content>
