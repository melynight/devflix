<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DescripcionPelicula.aspx.cs" Inherits="Vistas.DescripcionPelicula" EnableEventValidation="true" %>

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

        ///vuelta de boton favoritos
        document.addEventListener("DOMContentLoaded", function (event) {
            document.getElementById("BtnFavoritos").addEventListener("click", function (event) {
                event.preventDefault();
                iterateFavs(this);
                return false;
            });
        });

        function getRandom(max) {
            return Math.floor(Math.random() * max);
        }
        function iterateFavs(obj) {
            obj.classList.add("vueltita");
            setTimeout(function () {
                obj.classList.remove("vueltita");
            }, spinSpeed);
        }

        function iterate(obj) {
            obj.classList.add("vueltita");
            setTimeout(function () {
                obj.classList.remove("vueltita");

                var params = new URLSearchParams(location.search);
                params.set('id', getRandom(100) + 1);
                window.location.search = params.toString();
            }, spinSpeed);
        }
    </script>
</head>

<body style="background-image: url(Recursos/Imagenes/fondo.jpg); background-size: cover; margin: 0; padding: 0;">

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
                <asp:Label ID="lblBienvenidoUsuario" runat="server"></asp:Label>
            </nav>
        </header>

        <main>
            <asp:Button ID="BtnFavoritos" title="Agregar este contenido a mi lista de favoritos" runat="server" Click="BtnFavoritos_Click" />
            <asp:Label ID="lblSeAgrego" runat="server" CssClass="Agregar"></asp:Label>

            <div class="video">

                <div class="descripcionVideo">
                    <asp:Button ID="BtnSorprendeme" runat="server" title="Sorprendeme con contenido aleatorio" />
                    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo"></asp:Label>
                    <asp:Label ID="lblDuracion" runat="server" CssClass="duracion"></asp:Label>
                    <asp:Label ID="lblSinopsis" runat="server" CssClass="sinopsis"></asp:Label>
                </div>

                <iframe id="trailer" runat="server" width="1260" height="900" title="Trailer" frameborder="0" allow="accelerometer; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen=""></iframe>
            </div>
        </main>
    </form>
</body>
</html>