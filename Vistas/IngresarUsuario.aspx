<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarUsuario.aspx.cs" Inherits="Vistas.IngresarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ingresar Usuario</title>
    <link rel="StyleSheet" href="Estilo.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <section class="ingresar">
                <div class="contForm">
                    <asp:Label CssClass="tituloIngresar" ID="Label1" runat="server" Text="INGRESAR"></asp:Label>
                    <asp:Label CssClass="labelNom" ID="Label2" runat="server" Text="Ingrese su nombre de usuario"></asp:Label>
                    <asp:TextBox CssClass="txtBoxIng" ID="txtNomUsuarioIng" runat="server" Width="230px" ValidationGroup="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomUsuarioIng" ValidationGroup="1" Font-Size="Small" ForeColor="#CC0000">Ingrese un nombre de usuario</asp:RequiredFieldValidator>
                    <asp:Label CssClass="labelNom" ID="Label3" runat="server" Text="Ingrese su contraseña"></asp:Label>
                    <asp:TextBox CssClass="txtBoxIng" ID="txtContraseñaIng" runat="server" Width="230px" TextMode="Password" ValidationGroup="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContraseñaIng" ValidationGroup="1" Font-Size="Small" ForeColor="#CC0000">Ingrese su contraseña</asp:RequiredFieldValidator>
                    <asp:Button CssClass="btnIng" ID="btnIngresar" runat="server" Text="Iniciar Sesíon" OnClick="btnIngresar_Click" ValidationGroup="1" />
                    <div class="MandoRegistrarse">
                        <asp:Label CssClass="preguntaReg" ID="Label4" runat="server" Text="Aun no tenes cuenta en ChePlay?"></asp:Label>
                        <asp:HyperLink CssClass="linkRegis" ID="linkRegis" runat="server" NavigateUrl="~/Registrarse.aspx">Registrate</asp:HyperLink>
                    </div>
                    <asp:Label CssClass="noExiste" ID="lblNoExiste" runat="server" Text=""></asp:Label>
                </div>
            </section>
        </main>
    </form>
</body>
</html>
