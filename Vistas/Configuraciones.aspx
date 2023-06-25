<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuraciones.aspx.cs" Inherits="Vistas.Configuraciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />
     <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Configuraciones.css" />
    <title>Ajustes | DevFlix</title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 60px;
        }
    </style>
</head>

<body style="background-image: url(Recursos/Imagenes/fondoSeleccionarUsuarios.jpg); background-size: cover; margin:0;">
    <form id="form1" runat="server">
 
        <header>

            <nav class="menu_principal">

                <a class="botonesMenu" href="Home.aspx">HOME</a>
                <a class="botonesMenu" href="Suscripciones.aspx">SUSCRIPCIONES</a>
                <a class="botonesMenu" href="Favoritos.aspx">FAVORITOS</a>
                <a class="botonesMenu" href="DescripcionPelicula.aspx">SORPRENDEME </a>
                <a class="botonesMenu" href="Reportes.aspx">REPORTES </a>
                <a class="botonesMenu" href="SeleccionarUsuario.aspx">USUARIOS </a>
                <a class="botonesMenu" href="Configuraciones.aspx">AJUSTES </a>
                <a class="botonesMenu" href="Log.aspx">CERRAR SESION </a>
                <br />
                <br />
        <asp:Label ID="lblUserName" runat="server"></asp:Label>
            </nav>

        </header>

        <article>
            <div class="MenuConfig">

                <ul id="itemsConfiguracion" visible="false"  runat="server">
                    <li><a href="AdministrarUsuarios.aspx">ADMINISTRAR USUARIOS</a> </li>
                    <li><a href="EliminarUsuario.aspx">ELIMINAR CUENTA</a> </li>
                    <li><a href="CambiarContraseña.aspx">CAMBIAR CONTRASEÑA</a> </li>
                    <li><a href="Suscripciones.aspx">CAMBIAR PLAN</a> </li>
                </ul>

            </div>
        </article>
    <div class="IngresoPin">
        <asp:Label ID="lblPIN" runat="server" Text="Ingresar PIN de administrador:"></asp:Label>
        <asp:TextBox ID="txtPin" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPin" runat="server" Display="Dynamic" ControlToValidate="txtPin" ValidationGroup="ValidarPin">*Debe ingresar un PIN para continuar.</asp:RequiredFieldValidator>
  
        <p class="auto-style1">
            <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" Width="112px" ValidationGroup="ValidarPin" />
            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
    </p>
          </div>
    </form>
    </body>
</html>