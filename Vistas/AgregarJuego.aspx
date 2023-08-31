<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarJuego.aspx.cs" Inherits="Vistas.AgregarJuego" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agregar Juego</title>
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
            <section class="Agregar">
                <div class="contAgregar">
                    <asp:Label CssClass="tituloAgregar" ID="Label3" runat="server" Text="Agregar Juego"></asp:Label>
                    <div class="contCostado">
                        <div class="costado">
                            <asp:Label CssClass="lblDatosAgregar" ID="Label11" runat="server" Text="Codigo de Juego:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosAgregar" ID="txtCodJuego" runat="server" Width="230px" OnTextChanged="txtCodJuego_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCodJuego" ErrorMessage="*Ingrese CODIGO" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revValidarCodigo" runat="server" ErrorMessage="Codigo Invalido[LETRA,NUM,NUM,NUM]" ControlToValidate="txtCodJuego" ValidationExpression="^[A-Za-z][0-9]{3}$" ValidationGroup="Grupo1" ></asp:RegularExpressionValidator>

                            <asp:Label CssClass="lblDatosAgregar" ID="Label12" runat="server" Text="Nombre del Juego"></asp:Label>
                            <asp:TextBox CssClass="txtDatosAgregar" ID="txtNomJuego" runat="server" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNomJuego" ErrorMessage="*Ingrese NOMBRE" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>

                            <asp:Label CssClass="lblDatosAgregar" ID="Label13" runat="server" Text="Descripcion"></asp:Label>
                            <asp:TextBox CssClass="txtDatosAgregar" ID="txtDescripcion" runat="server" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*Ingrese DESCRIPCION" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>

                            <asp:Label CssClass="lblDatosAgregar" ID="Label14" runat="server" Text="FechaDeLanzamiento"></asp:Label>
                            <asp:TextBox CssClass="txtDatosAgregar" ID="txtFechaLanz" runat="server" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaLanz" ErrorMessage="*Ingrese FECHA" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revValidarFecha" runat="server" ErrorMessage="Fecha Invalida [DD/MM/YYYY]" ControlToValidate="txtFechaLanz" ValidationGroup="Grupo1"  ValidationExpression="^(?:(?:(?:0[1-9]|1\d|2[0-8])/(?:0[1-9]|1[0-2])|(?:29/(?:0[13-9]|1[0-2]))|(?:30/(?:0[13-9]|1[0-2]))|(?:31/(?:0[13578]|1[02])))/(?:19|20)\d\d|29/02/(?:(?:19|20)(?:[2468][048]|[13579][26])|2000))$"></asp:RegularExpressionValidator>
                            
                            <asp:ScriptManager ID="ScripManagerCheckBox" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanelCheckBox" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <asp:Label CssClass="lblDatosAgregar" ID="lblModoDeJuego" runat="server" Text="Modo de Juego"></asp:Label>
                                    <asp:CheckBoxList ID="cblModoDeJuego" runat="server" AutoPostBack="True" vaHeight="25px"></asp:CheckBoxList>   

                                    <asp:Label CssClass="lblDatosAgregar" ID="lblCategoria" runat="server" Text="Categoria"></asp:Label>
                                    <asp:CheckBoxList ID="cblCategoria" runat="server" AutoPostBack="True" Height="25px"></asp:CheckBoxList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgressCheckBox" runat="server" AssociatedUpdatePanelID="UpdatePanelCheckBox">
                                <ProgressTemplate>
                                    Procesando, espere por favor...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                             
                        </div>
                        <div class="costado">
                            <asp:Label CssClass="lblDatosAgregar" ID="Label15" runat="server" Text="URL de la portada"></asp:Label>
                            <asp:TextBox CssClass="txtDatosAgregar" ID="txtUrlPortada" runat="server" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUrlPortada" ErrorMessage="*Ingrese URL" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>

                            <asp:Label CssClass="lblDatosAgregar" ID="Label16" runat="server" Text="Stock"></asp:Label>
                            <asp:TextBox CssClass="txtDatosAgregar" ID="TxtStock" runat="server" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtStock" ErrorMessage="*Ingrese STOCK" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revValidarStock" runat="server" ErrorMessage="Numero Invalido" ControlToValidate="Txtstock" ValidationExpression="^[1-9][0-9]*$" ValidationGroup="Grupo1" ></asp:RegularExpressionValidator>

                            <asp:Label CssClass="lblDatosAgregar" ID="Label17" runat="server" Text="Precio"></asp:Label>
                            <asp:TextBox CssClass="txtDatosAgregar" ID="txtPrecio" runat="server" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrecio" ErrorMessage="*Ingrese PRECIO" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revValidarPrecio" runat="server" ErrorMessage="Numero Invalido" ControlToValidate="txtPrecio"  ValidationExpression="^[1-9][0-9]*$" ValidationGroup="Grupo1" ></asp:RegularExpressionValidator>

                            <asp:Label CssClass="lblDatosAgregar" ID="Label18" runat="server" Text="Proveedor"></asp:Label>
                            <asp:DropDownList ID="ddlProveedores" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlProveedores" ErrorMessage="*Elija un PROVEEDOR" InitialValue="--Seleccionar--" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>

                            <asp:Label CssClass="lblDatosAgregar" ID="Label19" runat="server" Text="Plataforma"></asp:Label>
                            <asp:DropDownList ID="ddlPlataformas" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlPlataformas" ErrorMessage="*Elija una PLATAFORMA" InitialValue="--Seleccionar--" ValidationGroup="Grupo1" ></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    
                    <asp:Button CssClass="btnRegistrarse" ID="Button1" runat="server" Text="Agregar"  OnClick="btnAgregarJuego_Click" ValidationGroup="Grupo1" />
                    <asp:Label CssClass="lblDatosAgregar" ID="lblMensajeBtnAceptar" runat="server" ></asp:Label>
                </div>
            </section>
        </main>
    </form>
</body>
</html>
