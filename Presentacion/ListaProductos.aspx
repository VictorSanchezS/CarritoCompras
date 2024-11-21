<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="Presentacion.ListaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row" id="product-list">
                <asp:Repeater ID="RepeaterProductos" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card text-center">
                                <img src="<%# Eval("UrlImagen") %>" class="card-img-top mx-auto d-block" alt="<%# Eval("NombreProducto") %>" style="width:200px; height:200px"/>
                                <div class="card-body">
                                    <h5 class="card-title"> <%# Eval("NombreProducto") %></h5>
                                    <p class="card-text"> Precio S/.: <%# Eval("Precio") %></p>
                                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" 
                                        CssClass="btn btn-primary"
                                        CommandArgument='<%# Eval("IdProducto") %>'
                                        OnClick="btn_Agregar_Click" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</asp:Content>
