<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Vistas.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />
    <title>Registro | DevFlix</title> 
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Registro_Style.css" />
</head>
<body style="background-image: url('Recursos\\Imagenes\\fondo.jpg'); background-size: cover;">
    <form id="form1" runat="server">
       
        <h1>Registro</h1>
        <p>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="El usuario ya existe" Visible="False"></asp:Label>
        </p>
        <div class="inset">
            <p>
                EMAIL&nbsp;
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="100%" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="El campo no puede quedar vacio" ForeColor="Red"></asp:RequiredFieldValidator>
            </p>
            <p>
                Confirmar EMAIL<asp:TextBox ID="txtConfirmarEmail" runat="server" TextMode="Email" Width="100%" MaxLength="30"></asp:TextBox>
                <asp:CompareValidator ID="VC_EMAILS" runat="server" ControlToCompare="txtEmail" ControlToValidate="txtConfirmarEmail" Display="Dynamic" ErrorMessage="* Los campos deben coincidir" ForeColor="Red"></asp:CompareValidator>
            </p>
            <p>
                Nombre</p>
            <p>
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="El campo no puedequedar vacio" ForeColor="Red"></asp:RequiredFieldValidator>
            </p>
            <p>
                Contraseña&nbsp;
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtClave" Display="Dynamic" ErrorMessage="El campo no puede quedar vacio" ForeColor="Red"></asp:RequiredFieldValidator>
            </p>
            <p>
                Confirmar Contraseña<asp:TextBox ID="txtConfirmarClave" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                <asp:CompareValidator ID="VC_Claves" runat="server" ControlToCompare="txtClave" ControlToValidate="txtConfirmarClave" Display="Dynamic" ErrorMessage="* Los campos deben coincidir" ForeColor="Red"></asp:CompareValidator>
            </p>
            <p>
                Región
                <asp:DropDownList ID="ddlPaises" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                NRO. TARJETA:
                <asp:TextBox ID="txtNroTarjeta" runat="server" TextMode="Number" Width="100%" BackColor="Black" ForeColor="Cyan" MaxLength="16"></asp:TextBox>
            </p>
            <p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNroTarjeta" Display="Dynamic" ErrorMessage="El campo no puede quedar vacio" ForeColor="Red"></asp:RequiredFieldValidator>
            </p>
            <p>
                PIN
            </p>
            <p>
                <asp:TextBox ID="txtPIN" runat="server" TextMode="Password" MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPIN" Display="Dynamic" ErrorMessage="El campo no puede quedar vacio" ForeColor="Red"></asp:RequiredFieldValidator>
            </p>
            <p>
                Edad</p>
            <p>
                <asp:TextBox ID="txtEdad" runat="server" TextMode="Number" BackColor="Black" ForeColor="Cyan"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtEdad" Display="Dynamic" ErrorMessage="Debe ser mayor de edad" ForeColor="Red" MaximumValue="125" MinimumValue="18" Type="Integer"></asp:RangeValidator>
            </p>
            <p>
                Suscripción
                <asp:DropDownList ID="ddlSuscripcion" runat="server">
                </asp:DropDownList>
            </p>
        </div>
        <p class="p-container">
            &nbsp;<asp:Button ID="btnIniciarSesion" runat="server" Text="Registrarse" OnClick="btnIniciarSesion_Click" />
        </p>
    </form>
</body>
</html>