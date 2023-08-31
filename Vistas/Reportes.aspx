<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Vistas.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reportes</title>
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
        <main class="reporte">
            <asp:Label CssClass="tituloAgregar" ID="Label1" runat="server" Text="REPORTES"></asp:Label>
            <section class="contReporte">
                <asp:Label CssClass="subtituloReporte" ID="Label2" runat="server" Text="TOTAL GANADO ENTRE DOS FECHAS"></asp:Label>
                <asp:Label CssClass="descripcionReporte" ID="Label3" runat="server" Text="Ingrese dos fechas con el siguiente formato: Año-Mes-Dia (Ejemplo: 2023-05-20)"></asp:Label>
                <div class="delado">
                    <div class="abajo">
                        <asp:TextBox CssClass="txtreporte" ID="txtFecha1" runat="server" ValidationGroup="0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtRepoFecha1" runat="server" ControlToValidate="txtFecha1" ForeColor="Red" ValidationGroup="0">Debe Ingresar una fecha</asp:RequiredFieldValidator>
                    </div>
                    <div class="abajo">
                        <asp:TextBox CssClass="txtreporte" ID="txtFecha2" runat="server" ValidationGroup="0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtReporteFecha2" runat="server" ControlToValidate="txtFecha2" ForeColor="Red" ValidationGroup="0">Debe ingresar una fecha</asp:RequiredFieldValidator>
                    </div>
                    
                </div>
                <asp:Button CssClass="botonFiltro" ID="btnReporteFechas" runat="server" Text="Ver Reporte" OnClick="btnReporteFechas_Click" ValidationGroup="0" />
                <asp:GridView CssClass="gridRepo" ID="gridReporteFechas" runat="server"></asp:GridView>
            </section>
            <section class="contReporte">
                <asp:Label CssClass="subtituloReporte" ID="lblReporteTopJuegos" runat="server" Text="TOP 10 DE JUEGOS MAS VENDIDOS ENTRE DOS FECHAS"></asp:Label>
                <div class="delado">
                    <asp:Label ID="lblDesde" runat="server" Text="DESDE:"></asp:Label>
                    <div class="abajo">
                        <asp:TextBox CssClass="txtreporte" ID="txtFechaDesde" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblHasta" runat="server" Text="HASTA:"></asp:Label>   
                    <div class="abajo">
                        <asp:TextBox CssClass="txtreporte" ID="txtFechaHasta" runat="server"></asp:TextBox>
                    </div>                  
                </div>
                <div>
                    <asp:Button CssClass="botonFiltro" ID="btnTopVentas" runat="server" Text="Ver Reporte" OnClick="btnTopVentas_Click"/>
                    <asp:ScriptManager ID="ScripManagerGrid" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanelGrid" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>                           
                            <asp:GridView CssClass="gridRepo" ID="gridTopVentas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="CodJuego_JU" HeaderText="Código del Juego" />
                                    <asp:BoundField DataField="Nombre_JU" HeaderText="Nombre del Juego" />
                                    <asp:BoundField DataField="TotalVentas" HeaderText="Total de Ventas" />
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>  
                        </ContentTemplate>
                    </asp:UpdatePanel>                                  
                </div>  
            </section>
            <section class="contReporte">
                <asp:Label CssClass="subtituloReporte" ID="lblReporteUsuarios" runat="server" Text="TOP 5 USUARIOS QUE MAS COMPRAN"></asp:Label>
                <%--<div class="delado">
                    <asp:Label ID="lblAnio" runat="server" Text="AÑO:"></asp:Label>
                    <div class="abajo">
                        <asp:TextBox CssClass="txtreporte" ID="txtAnio" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblMes" runat="server" Text="MES:"></asp:Label>
                    <div class="abajo">
                        <asp:TextBox CssClass="txtreporte" ID="txtMes" runat="server"></asp:TextBox>
                    </div>
                </div>--%>
                <div>
                    <asp:Button CssClass="botonFiltro" ID="btnFiltroTopUsuarios" runat="server" Text="Ver Reporte" OnClick="btnFiltroTopUsuarios_Click" />
                    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                    <asp:UpdatePanel ID="UpdatePanelTopUsuarios" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="gridTopUsuarios" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="DniUsuario" HeaderText="DNI"/>
                                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario"/>
                                    <asp:BoundField DataField="TotalGastado" HeaderText="Total Gastado" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </section>
            <section class="contReporte">
                <asp:Label CssClass="subtituloReporte" ID="lblFiltroInventario" runat="server" Text="INVENTARIO"></asp:Label>
                <%--<div class="delado">
                    <asp:Label ID="lblAnio" runat="server" Text="AÑO:"></asp:Label>
                    <div class="abajo">
                        <asp:TextBox CssClass="txtreporte" ID="txtAnio" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblMes" runat="server" Text="MES:"></asp:Label>
                    <div class="abajo">
                        <asp:TextBox CssClass="txtreporte" ID="txtMes" runat="server"></asp:TextBox>
                    </div>
                </div>--%>
                <div>
                    <asp:Button CssClass="botonFiltro" ID="btnInventario" runat="server" Text="Ver Reporte" OnClick="btnInventario_Click" />
                    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                    <asp:UpdatePanel ID="UpdatePanelInventario" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridInventario" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Producto" HeaderText="Producto"/>
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha"/>
                                    <asp:BoundField DataField="CantidadVendida" HeaderText="Cantidad Vendida"/>
                                    <asp:BoundField DataField="StockActual" HeaderText="Stock Actual"/>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </section>
            <%--en estas etiquetas section de abajo deben seguir poniendo mas reportes , USEN LAS MISMAS CSSCLASS ASI SE VE BIEN,
            hagan el titulo de reporte y pongale la misma CssClass que tiene el titulo de arriba , igual con la descripcion ,etc.--%>

        <%--<section class="contReporte">

            </section>
            <section class="contReporte">

            </section>--%>
        </main>
    </form>
</body>
</html>
