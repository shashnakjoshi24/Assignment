<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckIn.aspx.cs" Inherits="SLMS_Test.About" %>
<asp:Content runat="server" ID="ContentId1" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style2 {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 10px;
            font-style: normal;
            text-align: left;
            width: 182px;
        }

        .auto-style3 { width: 182px; }

        .auto-style4 { width: 208px; }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>return The Book.</h3>
    <table id="tblContent">
        <tr>
            <td class="text2">Borrower Name:</td>
            <td class="auto-style4">
                <asp:Label class="text" ID="lblName" runat="server"/>
            </td>
        </tr>

        <tr>
            <td class="text2">Mobile Number:</td>
            <td class="auto-style4">
                <asp:Label class="text" ID="lblMobile" runat="server"/>
            </td>
        </tr>

        <tr>
            <td class="text2">Return Date:</td>
            <td class="auto-style4">
                <asp:Label class="text" ID="lblReturnDate" runat="server"/>
            </td>
        </tr>

        <tr>
            <td class="text2">Required Returned Date:</td>
            <td class="auto-style4">
                <asp:Label class="text" ID="lblReqReturnDate" runat="server"/>
            </td>
        </tr>

        <tr>
            <td class="text2">Penalty Amount:</td>
            <td class="auto-style4">
                <asp:Label class="text" ID="lblPenaltyAmount" runat="server"/>
            </td>
        </tr>

        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style4" style="text-align: right">
                <asp:Button ID="btnCheckIn" CssClass="button" Text="Check ln" runat="server" OnClick="btnCheckIn_Click"/>
            </td>
        </tr>

    </table>
</asp:Content>