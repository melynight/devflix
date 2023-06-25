<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DescripcionPelicula.aspx.cs" Inherits="Vistas.DescripcionPelicula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\DescripcionPelicula.css" />
    <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />
    <title id="titulo" runat="server">DevFlix</title>
    <script type="text/javascript">
        var spinSpeed = 1500;

        ///vuelta de boton sorprendeme
        document.addEventListener("DOMContentLoaded", function (event) {
            document.getElementById("BtnSorprendeme").addEventListener("click", function (event) {
                event.preventDefault();
                iterate(this);
                return false;
            });
        });

        function getRandom(max) {
            return Math.floor(Math.random() * max);
        }

        function iterate(obj) {
            obj.classList.add("vueltita");
            setTimeout(function () {
                obj.classList.remove("vueltita");

                var params = new URLSearchParams(location.search);
                params.delete('id');
                window.location.search = params.toString();

            }, spinSpeed);
        }
    </script>
</head>

<body style="background-image: url(Recursos/Imagenes/fondo.jpg); background-size: cover; margin: 0; padding: 0;">

    <form id="form1" runat="server">

        <header>

            <nav class="menu_principal">

                <a class="botonesMenu" href="Home.aspx"> <img src="Recursos/Imagenes/home.png" alt="Home"/> </a>
                <a class="botonesMenu" href="Suscripciones.aspx">SUSCRIPCIONES</a>
                <a class="botonesMenu" href="Favoritos.aspx">FAVORITOS</a>
                <a class="botonesMenu" href="DescripcionPelicula.aspx">SORPRENDEME </a>
                <a class="botonesMenu" href="Reportes.aspx">REPORTES </a>
                <a class="botonesMenu" href="SeleccionarUsuario.aspx">USUARIOS </a>
                <a class="botonesMenu" href="Configuraciones.aspx">AJUSTES </a>
                <a class="botonesMenu" href="Log.aspx">CERRAR SESION </a>
                <asp:Label ID="lblUserName" runat="server" ForeColor="White"></asp:Label>
            </nav>
        </header>

        <main>
            <div>
                 <asp:Button ID="BtnFavoritos" title="Marcar/Desmarcar como favorito" runat="server" OnClick="BtnFavoritos_Click" />
            <asp:Button ID="BtnSorprendeme" runat="server" title="Sorprendeme con contenido aleatorio" OnClick="BtnSorprendeme_Click" />
            </div>
           

            <div class="video">

                <div class="descripcionVideo">
                    
                    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo"></asp:Label>
                    <br />
                    <asp:Label ID="lblDuracion" runat="server" CssClass="duracion"></asp:Label>
                    <br />
                    <asp:Label ID="lblSinopsis" runat="server" CssClass="sinopsis"></asp:Label>
                </div>

                <iframe id="trailer" runat="server" width="1260" height="900" title="Trailer" frameborder="0" allow="accelerometer; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen=""></iframe>
            </div>
        </main>
    </form>
</body>
</html>