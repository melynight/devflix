<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Vistas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="icon" type="image/png" href="Recursos/Imagenes/favicon.png" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Home_Styles.css" />
    <title>Favoritos | DevFlix</title>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 261px;
        }

        .auto-style9 {
            height: 52px;
        }

        .auto-style10 {
            width: 261px;
            height: 52px;
        }
        .auto-style11 {
            width: 32px;
        }
        .auto-style12 {
            width: 32px;
            height: 26px;
        }
        .auto-style13 {
            height: 26px;
        }
        .auto-style14 {
            width: 100%;
            height: 87px;
        }
    </style>
</head>

<body style="background-image: url(Recursos/Imagenes/fondoHome2.jpg); background-size: cover; opacity: 10;">
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

        <div>
            <table class="auto-style14">
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12"></td>
                    <td style="font-family: 'Times New Roman', Times, serif; font-size: x-large; font-weight: bold; color: #FFFFFF; text-shadow: 0em 0em 5px #000000" class="auto-style13">Mi lista</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" BackColor="#63B9CD" Text="Guardar cambios" />
                    </td>
                </tr>
            </table>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style10" style="font-family: 'Times New Roman', Times, serif; font-size: x-large; font-weight: bold; color: #63B9CD;"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">
                        <asp:ImageButton ID="imgEjemploFavs" runat="server" Height="265px" ImageUrl="https://occ-0-2016-778.1.nflxso.net/dnm/api/v6/WNk1mr9x_Cd_2itp6pUM7-lXMJg/AAAABZTSMYfxyN9duLsgLoAqbcJepsGkmj7BGa4_L-nrP06ht9oqEU6B2UYfyuzLum2jLvheugGNkg9NHXcSsyADAJVH61T-XXncCUFu1E9T3uyq2ca_o63EI35mSvVc4mTriB-K6A.jpg?r=e07" Width="181px" />
                        <br />
                        <asp:CheckBox ID="cbEjFavs1" runat="server" ForeColor="Gray" Text="Eliminar de favoritos?" />
                    </td>
                    <td>
                        <asp:ImageButton ID="imgEjemploFavs0" runat="server" Height="265px" ImageUrl="~/Recursos/Imagenes/JustMercy.jpg" Width="181px" />
                        <br />
                        <asp:CheckBox ID="cbEjFavs0" runat="server" ForeColor="Gray" Text="Eliminar de favoritos?" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <asp:ListView ID="ListView1" runat="server">
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>