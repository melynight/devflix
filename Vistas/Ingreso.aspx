<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="Vistas.Ingreso1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />
    <title>Iniciar Sesión | DevFlix</title>
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Ingreso_Style.css" />

</head>
<body style="background-image: url('Recursos\\Imagenes\\fondo.jpg'); background-size: cover;">
    <form id="form1" runat="server">
        <h1>Iniciar Sesión</h1>
        <div class="inset">
            <p>
                EMAIL
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="30"></asp:TextBox>
            </p>
            <p>
                Contraseña&nbsp;
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Error al iniciar sesión" Visible="False"></asp:Label>
            &nbsp;</p>
        </div>
        <p class="p-container">
            &nbsp;<asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesion" OnClick="btnIniciarSesion_Click" />
        </p>
    </form>
</body>
</html>