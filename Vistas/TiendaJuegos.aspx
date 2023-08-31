<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiendaJuegos.aspx.cs" Inherits="Vistas.TiendaJuegos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tienda</title>
<link rel="StyleSheet" href="Estilo.css" type="text/css"/>
    <style type="text/css">
        .auto-style1 {
            height: 612px;
        }
        </style>
    </head>
<body>
    <form id="form1" runat="server">
        <header class="Cabecera">
            <asp:ImageButton class="logo" ID="Logo" runat="server" ImageUrl="~/Imagenes2/logoProg3.png" />
            <nav class="LinkCabecera">
                <asp:Label CssClass="nomUser" ID="lblUsuario" runat="server"></asp:Label>
                <asp:HyperLink class="linkC" ID="Linktienda" runat="server" NavigateUrl="~/TiendaJuegos.aspx">Tienda</asp:HyperLink>
                <asp:HyperLink class="linkC" ID="Linkcarrito" runat="server" NavigateUrl="~/Carrito.aspx">Carrito</asp:HyperLink>
                <asp:Button CssClass="linkC" ID="btnCerrar" runat="server" Text="Cerrar Session" OnClick="btnCerrar_Click" />
            </nav>
        </header>
        <main>
            <section class="tienda">
                <div class="ContFiltro">
                    <asp:Label CssClass="tituloTienda" ID="Label1" runat="server" Text="TIENDA"></asp:Label>
                    <div class="filtro">
                        <asp:Label CssClass="textoFiltro" ID="Label2" runat="server" Text="Buscar Juego Por Nombre"></asp:Label>
                        <asp:TextBox ID="txtNombreFiltro" runat="server" Width="213px"></asp:TextBox>
                        <asp:Button CssClass="botonFiltro" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
                <div class="contenedorJuegos">
                    <div class="contFiltros">
                        <asp:CheckBoxList ID="chk_categorias" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="NombreDeCategoria_CT" DataValueField="CodCategoria_CT" OnSelectedIndexChanged="chk_categorias_SelectedIndexChanged">
                        </asp:CheckBoxList>
                        <asp:DropDownList ID="ddl_categoria" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="NombreDePlataforma_PL" DataValueField="CodPlataforma_PL" OnSelectedIndexChanged="ddl_categoria_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ChePlayConnectionString %>" SelectCommand="SELECT [CodCategoria_CT], [NombreDeCategoria_CT] FROM [Categorias]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ChePlayConnectionString %>" SelectCommand="SELECT [CodPlataforma_PL], [NombreDePlataforma_PL] FROM [Plataformas]"></asp:SqlDataSource>
                    </div>
                    <div class="ListaJuegos">
                        <asp:ListView ID="listJuegos" runat="server" GroupItemCount="3" OnLoad="chk_categorias_SelectedIndexChanged" OnPagePropertiesChanging="listJuegos_PagePropertiesChanging" EnableCaching="true" CacheDuration="100" style="height: 954px" OnInit="ddl_categoria_SelectedIndexChanged">
                            <%--<AlternatingItemTemplate>
                                <td runat="server" style="background-color:#FFF8DC;">Nombre_JU:
                                    <asp:Label ID="Nombre_JULabel" runat="server" Text='<%# Eval("Nombre_JU") %>' />
                                    <br />
                                    URLportada_JU:
                                    <asp:Label ID="URLportada_JULabel" runat="server" Text='<%# Eval("URLportada_JU") %>' />
                                    <br />
                                    Descripcion_JU:
                                    <asp:Label ID="Descripcion_JULabel" runat="server" Text='<%# Eval("Descripcion_JU") %>' />
                                    <br />
                                </td>
                            </AlternatingItemTemplate>--%>
                            <EditItemTemplate>
                                <td runat="server" style="background-color:#008A8C;color: #FFFFFF;">Nombre_JU:
                                    <asp:TextBox ID="Nombre_JUTextBox" runat="server" Text='<%# Bind("Nombre_JU") %>' />
                                    <br />
                                    URLportada_JU:
                                    <asp:TextBox ID="URLportada_JUTextBox" runat="server" Text='<%# Bind("URLportada_JU") %>' />
                                    <br />
                                    Descripcion_JU:
                                    <asp:TextBox ID="Descripcion_JUTextBox" runat="server" Text='<%# Bind("Descripcion_JU") %>' />
                                    <br />
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                                    <br />
                                </td>
                            </EditItemTemplate>
                            <EmptyDataTemplate>
                                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                    <tr>
                                        <td>No se han devuelto datos.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <EmptyItemTemplate>
                                <td runat="server" />
                            </EmptyItemTemplate>
                            <GroupTemplate>
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </GroupTemplate>
                            <InsertItemTemplate>
                                <td runat="server" style="">Nombre_JU:
                                    <asp:TextBox ID="Nombre_JUTextBox" runat="server" Text='<%# Bind("Nombre_JU") %>' />
                                    <br />
                                    URLportada_JU:
                                    <asp:TextBox ID="URLportada_JUTextBox" runat="server" Text='<%# Bind("URLportada_JU") %>' />
                                    <br />
                                    Descripcion_JU:
                                    <asp:TextBox ID="Descripcion_JUTextBox" runat="server" Text='<%# Bind("Descripcion_JU") %>' />
                                    <br />
                                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                                    <br />
                                </td>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <td runat="server" style="background-color:#DCDCDC;color: #000000;" class="caja">&nbsp;<asp:Label CssClass="nombreJuego" ID="lblNombreJuego" runat="server" Text='<%# Eval("Nombre_JU") %>' />
                                    <br />
                                    <asp:Image CssClass="imgLista" ID="Image1" runat="server" ImageUrl='<%# Eval("URLportada_JU") %>' />
                                    <br />
                                    <asp:Label CssClass="descripcion" ID="lblDescripcion" runat="server" Text='<%# Eval("Descripcion_JU") %>' />
                                    <br />
                                    <div class="precio">
                                        <asp:Label CssClass="precioUnitario" ID="lblPrecio" runat="server" Text='<%# Eval("PrecioUnitario_PXJ") %>'></asp:Label>
                                        <asp:Label CssClass="simboloPesos" ID="Label3" runat="server" Text="$"></asp:Label>
                                        <asp:Label CssClass="precioUnitario" ID="Label4" runat="server" Text='<%# Eval("NombreDePlataforma_PL") %>'></asp:Label>
                                        <br />
                                    </div>
                                    <asp:Button CssClass="botonCarrito" ID="btnCarrito" runat="server" Text="Agregar al Carrito" CommandName="AgregarAlCarrito" CommandArgument='<%# Eval("Nombre_JU") + "#" + Eval("NombreDePlataforma_PL") + "#" + Eval("PrecioUnitario_PXJ") %>' OnCommand="btnAgregar_Carrito" />
                                    <br />
                                </td>
                           </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server" class="auto-style1">
                                            <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                <tr id="groupPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                            <asp:DataPager ID="DataPager1" runat="server" PageSize="6">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    <asp:NumericPagerField />
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <SelectedItemTemplate>
                                <td runat="server" style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">Nombre_JU:
                                    <asp:Label ID="Nombre_JULabel" runat="server" Text='<%# Eval("Nombre_JU") %>' />
                                    <br />
                                    URLportada_JU:
                                    <asp:Label ID="URLportada_JULabel" runat="server" Text='<%# Eval("URLportada_JU") %>' />
                                    <br />
                                    Descripcion_JU:
                                    <asp:Label ID="Descripcion_JULabel" runat="server" Text='<%# Eval("Descripcion_JU") %>' />
                                    <br />
                                </td>
                            </SelectedItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <div>
                </div>
            </section>
        </main>
    </form>
</body>
</html>
