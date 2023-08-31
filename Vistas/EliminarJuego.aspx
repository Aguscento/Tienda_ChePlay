<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarJuego.aspx.cs" Inherits="Vistas.EliminarJuego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Eliminar Juego</title>
    <link rel="StyleSheet" href="Estilo.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <header class="Cabecera">
            <asp:ImageButton class="logo" ID="Logo" runat="server" ImageUrl="~/Imagenes2/logoProg3.png" OnClick="Logo_Click" />
            <nav class="LinkCabecera">
                <asp:HyperLink class="linkC" ID="LinkAgregar" runat="server" NavigateUrl="~/AgregarJuego.aspx">Agregar Juego</asp:HyperLink>
                <asp:HyperLink class="linkC" ID="LinkEditar" runat="server" NavigateUrl="~/EditarJuego.aspx">Editar Juego</asp:HyperLink>
                <asp:HyperLink class="linkC" ID="LinkEliminar" runat="server" NavigateUrl="~/EliminarJuego.aspx">Eliminar Juego</asp:HyperLink>
                <asp:HyperLink class="linkC" ID="LinkHistorialVenta" runat="server" NavigateUrl="~/HistorialVenta.aspx">Historial De Venta</asp:HyperLink>
                <asp:HyperLink class="linkC" ID="LinkReportes" runat="server" NavigateUrl="~/Reportes.aspx">Reportes</asp:HyperLink>
            </nav>
        </header>
        <main>
            <section class="Eliminar">
                <div class="contEliminar">
                    <asp:Label CssClass="tituloEliminar" ID="Label1" runat="server" Text="Eliminar Juego"></asp:Label>
                    <asp:Label CssClass="lblEliminar" ID="Label2" runat="server" Text="Codigo del Juego a eliminar:"></asp:Label>
                    <asp:TextBox CssClass="txtEliminar" ID="txtCodigoEliminar" runat="server" Width="293px"></asp:TextBox>
                    <asp:Button CssClass="btnRegistrarse" ID="btnEliminarJuego" runat="server" Text="Eliminar" OnCommand="btnEliminarJuego_Command" CommandName="eventoEliminar" />
                    <asp:Label CssClass="lblEliminar" ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>
            </section>
        </main>
    </form>
</body>
</html>
