<%@ Page Async="true" Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Peoduct.aspx.cs" Inherits="webformproba.Peoduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Peoduct.aspx.css" rel="stylesheet" />
    <main aria-labelledby="title">
        <asp:Button runat="server" Text="new" CssClass="newButton" OnClick="Unnamed1_Click"></asp:Button>
        <asp:Button runat="server" ID="btnEdit" CssClass="newButton" Text="Edit" OnClick="btnEdit_Click" Visible="false" />
        <asp:Button runat="server" ID="btnDelete" CssClass="deleteButton" Text="Delete" OnClick="btnDelete_Click" Visible="false" />

        <asp:Panel runat="server" ID="panelNewFields" CssClass="panelNewFields" Visible="false">
            <asp:TextBox runat="server" ID="txtFieldProd" Placeholder="Termék" /><br />
            <asp:TextBox runat="server" ID="txtFieldManu" Placeholder="Gyártó" /><br />
            <asp:TextBox runat="server" ID="txtFieldPrice" Placeholder="Ár" /><br />
            <asp:Button runat="server" Text="Add Field" CssClass="AddButton" OnClick="Unnamed2_Click" />
        </asp:Panel>
        <asp:Panel runat="server" ID="paneledit" CssClass="panelNewFields" Visible="false">
            <asp:TextBox runat="server" ID="TextBoxId" Visible="false" /><br />
            <asp:TextBox runat="server" ID="TextBox1" Placeholder="Termék" /><br />
            <asp:TextBox runat="server" ID="TextBox2" Placeholder="Gyártó" /><br />
            <asp:TextBox runat="server" ID="TextBox3" Placeholder="Ár" /><br />
            <asp:Button runat="server" Text="Edit Field" CssClass="AddButton" OnClick="Edit_Click" />
        </asp:Panel>
        <asp:GridView runat="server" ID="grid" CssClass="custom-grid" AutoGenerateSelectButton="true" OnSelectedIndexChanged="grid_SelectedIndexChanged"></asp:GridView>
    </main>
</asp:Content>
