<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="Vistas.CambiarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Configuraciones.css" />
    <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />

    <title>Cambiar Contraseña | DevFlix</title>
</head>
<body style="margin: 0; padding: 0;">
    <form id="form1" runat="server">

        <nav class="menu_principal">

                 <a class="botonesMenu" href="Home.aspx">HOME</a>
                <a class="botonesMenu" href="Suscripciones.aspx">SUSCRIPCIONES</a>
                <a class="botonesMenu" href="Favoritos.aspx">FAVORITOS</a>
                <a class="botonesMenu" href="DescripcionPelicula.aspx">SORPRENDEME </a>
                <a class="botonesMenu" href="Reportes.aspx">REPORTES </a>
                <a class="botonesMenu" href="SeleccionarUsuario.aspx">USUARIOS </a>
                <a class="botonesMenu" href="Configuraciones.aspx">AJUSTES </a>
                <a class="botonesMenu" href="Log.aspx">CERRAR SESION </a>
                <asp:Label ID="lblBienvenidoUsuario" runat="server"></asp:Label>
        </nav>
        <div class="nombreUsuario">
            </div>
        <section class="seccionEliminarUser">
            <h1 style="text-align: center;">CAMBIAR CONTRASEÑA</h1>
            <article class="FlexBoxCambiarPassword">
                <div class="MarginAdministrarUsers">
                    <span>INGRESE CONTRASEÑA ACTUAL </span>
                    <asp:TextBox ID="txtContraseniaActual" runat="server" TextMode="Password" ValidationGroup="contraActual"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvContraseniaActual" runat="server" ControlToValidate="txtContraseniaActual" Display="Dynamic" Font-Size="Smaller" ValidationGroup="confirmPass" ForeColor="Red">*Debe completar la contraseña actual</asp:RequiredFieldValidator>
                </div>
                <div class="MarginAdministrarUsers">
                    <span>INGRESE CONTRASEÑA NUEVA </span>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rvClave2" runat="server" ControlToValidate="txtNewPassword" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Font-Size="Smaller" ForeColor="Red">*Debe completar el campo</asp:RequiredFieldValidator>
                    <asp:Label ID="lblErrorIgualPassword" runat="server" Font-Size="Smaller" ForeColor="Red" Text="*La conttraseña nueva debe ser diferente a la antigua contraseña"></asp:Label>
                </div>
                <div class="MarginAdministrarUsers">
                    <span>CONFIRME CONTRASEÑA NUEVA </span>
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" ValidationGroup="confirmPass"></asp:TextBox>
                    <br />
                    <asp:CompareValidator ID="cvConfirmNewPassword" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmNewPassword" Display="Dynamic" Font-Size="Smaller" ValidationGroup="confirmPass" ForeColor="Red">*Las nuevas contraseñas deben coincidir.</asp:CompareValidator>
                    <br />
                    <asp:Label ID="lblExito" runat="server" ForeColor="Green" Text="La contraseña se cambio satisfactoriamente" Visible="False"></asp:Label>
                    <br />
                </div>
            </article>

            <article class="FlexBoxEliminarUsers">
                <div class="FlexBoxEliminarUsers">
                    <asp:Button ID="btnVolver" runat="server" Text="CANCELAR" CssClass="Botones" OnClick="btnVolver_Click" />
                    <asp:Button ID="btnAceptar" runat="server" Text="CONFIRMAR" CssClass="Botones" OnClick="btnAceptar_Click" ValidationGroup="confirmPass" />
                </div>
            </article>
        </section>
    </form>
</body>
</html>