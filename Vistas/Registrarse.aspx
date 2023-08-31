<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Vistas.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registrarse</title>
    <link rel="StyleSheet" href="Estilo.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <section class="Registrarse">
                <div class="ContFormRegis">
                    <asp:Label CssClass="tituloRegistrar" ID="Label1" runat="server" Text="REGISTRATE A CHEPLAY"></asp:Label>
                    <div class="DeDos">
                        <div class="cajasForm">
                            <asp:Label class="lblDatosReg" ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosReg" ID="txtNombreReg" runat="server" Width="210px" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Size="Small" ForeColor="Red" ControlToValidate="txtNombreReg" ValidationGroup="2">Ingrese su nombre</asp:RequiredFieldValidator>
                        </div>
                        <div class="cajasForm">
                            <asp:Label class="lblDatosReg" ID="Label3" runat="server" Text="Apellido:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosReg" ID="txtApellidoReg" runat="server" Width="210px" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Size="Small" ForeColor="Red" ControlToValidate="txtApellidoReg" ValidationGroup="2">Ingrese su apellido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                     <div class="DeDos">
                        <div class="cajasForm">
                            <asp:Label class="lblDatosReg" ID="Label4" runat="server" Text="DNI:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosReg" ID="txtDNIReg" runat="server" Width="210px" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Font-Size="Small" ForeColor="Red" ControlToValidate="txtDNIReg" ValidationGroup="2">Ingrese su DNI</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDNIReg" Font-Size="Small" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="2">Solo se permiten numeros</asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDNIReg" Font-Size="Small" ForeColor="Red" ValidationExpression="^[0-9]{8}$" ValidationGroup="2">Solo se permiten hasta 8 numeros</asp:RegularExpressionValidator>
                        </div>
                        <div class="cajasForm">
                            <asp:Label class="lblDatosReg" ID="Label5" runat="server" Text="Telefono:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosReg" ID="txtTelefonoReg" runat="server" Width="210px" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Font-Size="Small" ForeColor="Red" ControlToValidate="txtTelefonoReg" ValidationGroup="2">Ingrese su telefono</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTelefonoReg" Font-Size="Small" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="2">Solo se permiten numeros</asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="DeDos">
                        <div class="cajasForm">
                            <asp:Label class="lblDatosReg" ID="Label6" runat="server" Text="Direccion:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosReg" ID="txtDireccionReg" runat="server" Width="210px" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Font-Size="Small" ForeColor="Red" ControlToValidate="txtDireccionReg" ValidationGroup="2">Ingrese su direccion</asp:RequiredFieldValidator>
                        </div>
                        <div class="cajasForm">
                            <asp:Label class="lblDatosReg" ID="Label7" runat="server" Text="NickName:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosReg" ID="txtNickNameReg" runat="server" Width="210px" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Font-Size="Small" ForeColor="Red" ControlToValidate="txtNickNameReg" ValidationGroup="2">Ingrese su Nick Name</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="DeDos">
                        <div class="cajasForm">
                            <asp:Label class="lblDatosReg" ID="Label8" runat="server" Text="Contraseña:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosReg" ID="txtContraseñaReg" runat="server" Width="210px" TextMode="Password" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Font-Size="Small" ForeColor="Red" ControlToValidate="txtContraseñaReg" ValidationGroup="2">Ingrese su contraseña</asp:RequiredFieldValidator>
                        </div>
                        <div class="cajasForm">
                            <asp:Label class="lblDatosReg" ID="Label9" runat="server" Text="RepitaContraseña:"></asp:Label>
                            <asp:TextBox CssClass="txtDatosReg" ID="txtRepConstraseñaReg" runat="server" Width="210px" TextMode="Password" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Font-Size="Small" ForeColor="Red" ControlToValidate="txtRepConstraseñaReg" ValidationGroup="2">Repita su contraseña</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContraseñaReg" ControlToValidate="txtRepConstraseñaReg" Font-Size="Small" ForeColor="Red" ValidationGroup="2">La contraseña no coincide</asp:CompareValidator>
                        </div>
                    </div>
                    <asp:Button CssClass="btnRegistrarse" ID="BtnRegistrarse" runat="server" Text="Registrate" OnClick="BtnRegistrarse_Click" ValidationGroup="2" />
                    <div class="yaTengoCuenta">
                        <asp:Label CssClass="lblDatosReg" ID="Label10" runat="server" Text="Ya tenes Cuenta?"></asp:Label>
                        <asp:HyperLink CssClass="LinkMandaIniciarSession" ID="LinkIniciarSesion" runat="server" NavigateUrl="~/IngresarUsuario.aspx">Inicia Sesíon</asp:HyperLink>
                    </div>
                    <asp:Label ID="lblErorRegistro" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </div>
            </section>
        </main>
    </form>
</body>
</html>
