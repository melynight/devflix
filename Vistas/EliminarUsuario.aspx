﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarUsuario.aspx.cs" Inherits="Vistas.EliminarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Configuraciones.css" />
    <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />

    <title>Eliminar Cuenta | DevFlix</title>
</head>
<body style="background-image: url(Recursos/Imagenes/fondoSeleccionarUsuarios.jpg);background-size: cover; margin: 0; padding: 0;">
    <form id="form1" runat="server">

        <nav class="menu_principal">

                <a class="botonesMenu" href="Home.aspx"> <img src="Recursos/Imagenes/home.png" alt="Home"/> </a>
                <a class="botonesMenu" href="Suscripciones.aspx">SUSCRIPCIONES</a>
                <a class="botonesMenu" href="Favoritos.aspx">FAVORITOS</a>
                <a class="botonesMenu" href="DescripcionPelicula.aspx">SORPRENDEME </a>
                <a class="botonesMenu" href="Reportes.aspx">REPORTES </a>
                <a class="botonesMenu" href="SeleccionarUsuario.aspx">USUARIOS </a>
                <a class="botonesMenu" href="Configuraciones.aspx">AJUSTES </a>
                <a class="botonesMenu" href="Log.aspx">CERRAR SESION </a>
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
        </nav>
        <section class="seccionEliminarUser">
            <article class="FlexBoxEliminarUsers">
                <div class="MarginAdministrarUsers">
                    <span>&nbsp;<asp:Label ID="lblTitulo" runat="server" Text="INGRESE CONTRASEÑA DE LA CUENTA PARA ELIMINAR"></asp:Label>
                    </span>
                </div>
            </article>

            <article class="FlexBoxEliminarUsers">
                <div class="MarginAdministrarUsers">
                    <asp:TextBox ID="txtContraCuenta" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:CustomValidator ID="cvErrorContrasenia" runat="server" ControlToValidate="txtContraCuenta" OnServerValidate="cvErrorContrasenia_ServerValidate" ValidationGroup="contrasenia" Display="Dynamic" ForeColor="#990033">Contraseña erronea. Verifique los datos</asp:CustomValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContraCuenta" ForeColor="#990033" ValidationGroup="contrasenia" Display="Dynamic">Debe completar el campo!</asp:RequiredFieldValidator>
                </div>
            </article>

            <article class="FlexBoxEliminarUsers">
                <div class="FlexBoxEliminarUsers">
                    <asp:Button ID="btnCancelar" runat="server" Text="CANCELAR" CssClass="Botones" OnClick="btnVolver_Click" />
                    <asp:Button ID="btnAceptar" runat="server" Text="ACEPTAR" CssClass="Botones" OnClick="btnAceptar_Click" ValidationGroup="contrasenia" />
                </div>
            </article>         
            <article class="FlexBoxEliminarUsers">
                <div class="FlexBoxEliminarUsers">
                    <asp:Label ID="lblConfirmDelete" runat="server" ForeColor="Black" Text="Esta realmente seguro de borrar la cuenta? Ingrese nuevamente la contraseña." Visible="False" CssClass="lblClassDelete"></asp:Label>
                    <br />
                    <asp:Button ID="btnCancelDelete" runat="server" Text="CANCELAR" CssClass="Botones" OnClick="btnCancelDelete_Click" Visible="False" />
                    <asp:Button ID="btnConfirmDelete" runat="server" Text="BORRAR PERMANENTE" CssClass="Botones" OnClick="btnConfirmDelete_Click" ValidationGroup="contrasenia" Visible="False" Width="155px" />
                </div>
            </article>
        </section>
    </form>
</body>
</html>