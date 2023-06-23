<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="Vistas.Log" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />
    <title>Sign Up | DevFlix</title>
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Log_Style.css" />

    <style>
h1 
{
    color: aqua;
}

* {
    box-sizing: border-box;
}

body {
    font-family: "Times New Roman";
    color: white;
    font-size: 12px;
    background: grey;
}

form {
    background: #111;
    width: 300px;
    margin: 30px auto;
    border-radius: 0.4em;
    border: 1px solid #191919;
    overflow: hidden;
    position: relative;
    box-shadow: 0 5px 10px 5px rgba(0,0,0,0.2);
}
<!-- los pseudoselectores after y before
permiten agregar elementos antes o despues de otro elemento
el linear gradient lo genere con una pagina online para que parezca
cristal-- >

form:after {
    content: "";
    display: block;
    position: absolute;
    height: 500px;
    width: 200px;
    left: 20%;
    background: linear-gradient(left, #111, #444, #b6b6b8, #444, #111);
    top: 0;
}

form:before {
    content: "";
    display: block;
    position: absolute;
    width: 0px;
    height: 0px;
    z-index:0;
    border-radius: 50%;
    left: 34%;
    top: -7px;
    box-shadow: 0 0 6px 4px #fff;
}

.inset {
    padding: 20px;
    border-top: 1px solid #19191a;
    z-index:1;
}

form h1 {
    font-size: 18px;
    text-shadow: 0 1px 0 black;
    text-align: center;
    padding: 15px 0;
    border-bottom: 1px solid rgba(0,0,0,1);
    position: relative;
}

    form h1:after {
        content: "";
        display: block;
        width: 500px;
        height: 200px;
        position: absolute;
        top: 0;
        left: 50px;
        pointer-events: none;
        transform: rotate(70deg);
        background: linear-gradient(50deg, rgba(255,255,255,0.15), rgba(0,0,0,0));
    }


.p-container {
    padding: 0 20px 20px 20px;
    z-index:1;
    align-items:center;
    align-content:center;
}

    .p-container:after {
        clear: both;
        display: table;
        content: "";
    }
        .p-container span {
        display: block;
        /**float: left;*/
        color: #0d93ff;
        padding-top: 8px;
    }

input[type=submit] {
    padding: 5px 20px;
    border: 1px solid rgba(0,0,0,0.4);
    text-shadow: 0 -1px 0 rgba(0,0,0,0.4);
    box-shadow: inset 0 1px 0 rgba(255,255,255,0.3), inset 0 10px 10px rgba(255,255,255,0.1);
    border-radius: 0.3em;
    background: #0184ff;
    color: white;
    font-weight: bold;
    cursor: pointer;
    font-size: 13px;
    align-items:center;
    align-content:center;
}

    input[type=submit]:hover {
        box-shadow: inset 0 1px 0 rgba(255,255,255,0.3), inset 0 -10px 10px rgba(255,255,255,0.1);
    }


</style>


</head>
<body style="background-image: url('Recursos\\Imagenes\\fondoHome.jpg'); background-size: cover;"">
    <form id="form1" runat="server">
        <h1>Registro</h1>
        <div class="inset">
            <p class="p-container">
            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp<asp:Button ID="btnInicioSesion" runat="server" Text="Iniciar Sesión" OnClick="btnInicioSesion_Click" />
            </p>
        
        <p class="p-container">
            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp;<asp:Button ID="btnRegistro" runat="server" Text="Registrarse" OnClick="btnRegistro_Click" />
        </p>
        <p class="p-container">
            &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp Conectar con
        </p>


        <p class="p-container"> &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
            <asp:ImageButton ID="imgGoogleApi" runat="server" Height="50px" ImageAlign="Middle" ImageUrl="~/Recursos/Imagenes/Glogo.png" />
            <asp:ImageButton ID="imgFacebookApi" runat="server" Height="50px" ImageAlign="Middle" ImageUrl="~/Recursos/Imagenes/Flogo.png" />
            <asp:ImageButton ID="imgTwitterApi" runat="server" Height="50px" ImageAlign="Middle" ImageUrl="~/Recursos/Imagenes/Tlogo.png" />
        </p>
    </div>
    </form>
</body>
</html>