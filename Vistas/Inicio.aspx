<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Vistas.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
<link rel="StyleSheet" href="Estilo.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <section class="inicio">
            <div class="contenedor">
                <asp:Label ID="lblInicio" runat="server" Text="ChePlay Entertainment"></asp:Label>
                <asp:Label ID="lblInfo" runat="server" Text="Ingresar como:"></asp:Label>
                <div class="contLinks">
                    <asp:HyperLink Class="link" ID="linkAdmin" runat="server" NavigateUrl="~/AgregarJuego.aspx">Administrador</asp:HyperLink>
                    <asp:HyperLink Class="link" ID="LinkUsuario" runat="server" NavigateUrl="~/IngresarUsuario.aspx">Usuario</asp:HyperLink>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
