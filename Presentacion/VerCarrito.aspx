<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerCarrito.aspx.cs" Inherits="Presentacion.VerCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form2" runat="server">
        <div class="container">
            <h2>Carrito de Compras</h2>
            <asp:Panel ID="PanelCarritoVacio" runat="server" Visible="false">
                <p>Tu carrito esta vacio</p>
            </asp:Panel>
            <asp:Panel ID="PanelCarritoCompras" runat="server" Visible="false">
                <%--<asp:Table></asp:Table>--%>
                <table class="table">
                    <thead>
                        <tr>
                            <td>Imagen</td>
                            <td>Producto</td>
                            <td>Precio</td>
                            <td>Cantidad</td>
                            <td>Total</td>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <img src="<%# Eval("UrlImagen") %>" alt="<%# Eval("NombreProducto") %>" style="width: 100px; height: 100px" /></td>
                                    <td><%# Eval("NombreProducto") %></td>
                                    <td><%# Eval("Precio") %></td>
                                    <td>1</td>
                                    <td><%# Eval("Precio") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <p class="text-right"><strong>Total: S/. <asp:Label ID="lblTotal" runat="server"></asp:Label></strong></p>
            </asp:Panel>
            <asp:Button ID="ConfirmarCompra" runat="server" Text="ConfirmarCompra" CssClass="btn btn-primary" OnClick="ConfirmarCompra_Click" />
        </div>
    </form>
</asp:Content>
