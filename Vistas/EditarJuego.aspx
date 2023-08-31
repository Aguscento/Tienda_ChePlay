<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarJuego.aspx.cs" Inherits="Vistas.EditarJuego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Editar Juego</title>
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
            <section class="Editar">
                <div class="contGrillaEditar">
                    <asp:Label CssClass="tituloEliminar" ID="Label1" runat="server" Text="Editar Juego"></asp:Label>
                    <asp:GridView CssClass="grilla" ID="grdEditar" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="True" OnPageIndexChanging="grdEditar_PageIndexChanging" AutoGenerateEditButton="True" OnRowCancelingEdit="grdEditar_RowCancelingEdit" OnRowEditing="grdEditar_RowEditing" OnRowUpdating="grdEditar_RowUpdating" OnRowDataBound="grdEditar_RowDataBound">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                    <asp:Label CssClass="lblEliminar" ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>
            </section>
        </main>
    </form>
</body>
</html>
