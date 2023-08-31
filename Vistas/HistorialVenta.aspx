<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialVenta.aspx.cs" Inherits="Vistas.HistorialVenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Historial de Ventas</title>
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
        <main class="historial">
            <section class="contHistorial">
                <asp:Label CssClass="tituloAgregar" ID="Label1" runat="server" Text="Historial de Ventas"></asp:Label>
                <asp:GridView CssClass="grid" ID="gridVentas" runat="server" CellPadding="4" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gridVentas_SelectedIndexChanging" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Codigo de Venta">
                            <ItemTemplate>
                                <asp:Label class="lblVentas" ID="lblCodVenta" runat="server" Text='<%# Bind("CodVenta_VN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label class="lblVentas" ID="lblNombre" runat="server" Text='<%# Bind("Nombre_US") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <ItemTemplate>
                                <asp:Label class="lblVentas" ID="lblApellido" runat="server" Text='<%# Bind("Apellido_US") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total de venta">
                            <ItemTemplate>
                                <asp:Label class="lblVentas" ID="lblTotalVenta" runat="server" Text='<%# Bind("TotalVenta_VN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de compra">
                            <ItemTemplate>
                                <asp:Label class="lblVentas" ID="lblFecha" runat="server" Text='<%# Bind("FechaVenta_VN") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ChePlayConnectionString %>" SelectCommand="select CodVenta_VN,Nombre_US, Apellido_US,TotalVenta_VN,FechaVenta_VN from Ventas inner join Usuarios on DniUsuario_US_VN = DniUsuario_US"></asp:SqlDataSource>
                <div class="grillaDetalles">
                    <asp:GridView CssClass="grid" ID="gridDetalleVenta" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
            </section>
        </main>
    </form>
</body>
</html>
