<%@ Page Title="1PromotionalProducts.com" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1PromotionalProducts.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div id="flashnoauto" runat="server">
            <div style="width: 525px; height: 390px; margin-left: auto; margin-right: auto; border: solid 0px #000000;">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
                    width="525" height="390" id="Yourfilename" align="">
                    <param name="movie" value="1PromotionalIntro.swf">
                    <param name="quality" value="high">
                    <embed src="1PromotionalIntro.swf" quality="high" width="525" height="390" name="1PromotionalIntro"
                        align="" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer"></embed>
                </object>
            </div>
        </div>
        <div id="flashautoplay" runat="server">
            <div style="width: 525px; height: 390px; margin-left: auto; margin-right: auto; border: solid 0px #000000;">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
                    width="525" height="390" id="Object1" align="">
                    <param name="movie" value="1PromotionalIntroAutoPlay.swf">
                    <param name="quality" value="high">
                    <embed src="1PromotionalIntroAutoPlay.swf" quality="high" width="525" height="390"
                        name="1PromotionalIntro" align="" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer"></embed>
                </object>
            </div>
        </div>
        <br />
        <div style="font-size: 30px;">
            <a href="Special.aspx">Current Special</a>
        </div>
    </center>
</asp:Content>
