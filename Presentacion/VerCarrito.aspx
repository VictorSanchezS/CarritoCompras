<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerCarrito.aspx.cs" Inherits="Presentacion.VerCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form2" runat="server">
        <div class="container">
            <h2>Carrito de Compras</h2>
            <asp:Panel ID="CarritoCompras" runat="server" Visible="false"></asp:Panel>
        </div>
    </form>
</asp:Content>
