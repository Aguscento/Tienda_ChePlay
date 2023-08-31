<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Vistas.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Carrito</title>
    <link rel="StyleSheet" href="Estilo.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <header class="Cabecera">
            <asp:ImageButton class="logo" ID="Logo" runat="server" ImageUrl="~/Imagenes2/logoProg3.png"/>
            <nav class="LinkCabecera">
                <asp:Label CssClass="nomUser" ID="lblUsuario" runat="server"></asp:Label>
                <asp:HyperLink class="linkC" ID="Linktienda" runat="server" NavigateUrl="~/TiendaJuegos.aspx">Tienda</asp:HyperLink>
                <asp:HyperLink class="linkC" ID="Linkcarrito" runat="server" NavigateUrl="~/Carrito.aspx">Carrito</asp:HyperLink>
                <asp:Button CssClass="linkC" ID="btnCerrar" runat="server" Text="Cerrar Session" OnClick="btnCerrar_Click" />
            </nav>
        </header>
        <main>
            <section class="Editar">
                <div class="contCarrito">
                    <asp:Label CssClass="tituloAgregar" ID="Label1" runat="server" Text="Carrito"></asp:Label>
                    <asp:Label CssClass="labelNom" ID="Label2" runat="server" Text="Estos son los juegos que seleccionaste"></asp:Label>
                    <asp:GridView ID="GrdJuegosCarrito" runat="server" OnRowDeleting="GrdJuegosCarrito_RowDeleting">
                        <Columns>
                            <asp:CommandField DeleteText="Quitar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                    <asp:Button CssClass="btnRegistrarse" ID="btnComprar" runat="server" Text="Confirmar Compra" OnClick="btnComprar_Click" />
                    <br />
                    <asp:Label ID="lblPrueba" runat="server" Font-Bold="True"></asp:Label>
                </div>
            </section>
        </main>
    </form>
</body>
</html>
