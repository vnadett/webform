<%@ Page Async="true" Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Peoduct.aspx.cs" Inherits="webformproba.Peoduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Peoduct.aspx.css" rel="stylesheet" />
    <main aria-labelledby="title">
        <asp:Button runat="server" Text="new" OnClick="Unnamed1_Click"></asp:Button>
        <asp:Panel runat="server" ID="panelNewFields" Visible="false">
            <asp:TextBox runat="server" ID="txtFieldProd" Placeholder="Termék" /><br />
            <asp:TextBox runat="server" ID="txtFieldManu" Placeholder="Gyártó" /><br />
            <asp:TextBox runat="server" ID="txtFieldPrice" Placeholder="Ár" /><br />
            <asp:Button runat="server" Text="Add Field" OnClick="Unnamed2_Click" />
        </asp:Panel>
        <asp:GridView runat="server" ID="grid" CssClass="custom-grid"></asp:GridView>
    </main>
</asp:Content>
