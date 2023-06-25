<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Vistas.Home" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Home_Styles.css" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Home_Carousel_Styles.css" />
    <link rel="icon" type="image/png" href="Recursos/Imagenes/favicon.png" />

    <title>Home | DevFlix</title>
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            checkSearchBarShown(document.getElementById("txtBusqueda"));
        });

        function checkSearchBarShown(obj) {
            if (obj.value.length > 0) {
                obj.classList.add('show');
            } else {
                obj.classList.remove('show');
            }
        }
    </script>
</head>

<body style="background-image: url(Recursos/Imagenes/fondoSeleccionarUsuarios.jpg); background-size: cover; opacity: 10;">

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
                <asp:Label ID="lblBienvenidoUsuario" runat="server" Font-Size="15px"></asp:Label>
                <br />

            </nav>
        </header>

        <main>
            <div class="SearchBox">

                <asp:TextBox ID="txtBusqueda" class="SearchBox-input" runat="server" onkeyup="checkSearchBarShown(this)"> </asp:TextBox>
                <asp:ImageButton ID="imgbtnBuscar" class="SearchBox-button" runat="server" src="Recursos/Imagenes/lupaa.png" OnClick="imgBtnFiltrar_Click" Height="32px" Width="32px" />

            </div>

            <div class="ddl-Generos">
                <asp:DropDownList ID="ddlGeneros" runat="server" ForeColor="#0066FF">
                    <asp:ListItem Selected="True">--Seleccionar Género--</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnFiltrarGenero" runat="server" Text="Filtrar " Width="130px" BorderColor="#0066CC" BorderWidth="2px" ForeColor="#0066CC" OnClick="btnFiltrarGenero_Click" />
            </div>

            <div class="nombreUsuario">
            </div>

            <div class="list-view">

                <asp:ListView ID="lvCatalogo" runat="server" GroupItemCount="3" OnPagePropertiesChanging="lvCatalogo_PagePropertiesChanging" OnSelectedIndexChanged="lvCatalogo_SelectedIndexChanged">
                    <EditItemTemplate>
                        <td runat="server" style="">TituloContenido_Cat:
                            <asp:TextBox ID="TituloContenido_CatTextBox" runat="server" Text='<%# Bind("TituloContenido_Cat") %>' />
                            <br />
                            URLPortada_Cat:
                            <asp:TextBox ID="URLPortada_CatTextBox" runat="server" Text='<%# Bind("URLPortada_Cat") %>' />
                            <br />
                            Clasif_Edad_Cat:
                            <asp:TextBox ID="Clasif_Edad_CatTextBox" runat="server" Text='<%# Bind("Clasif_Edad_Cat") %>' />
                            <br />
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <br />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                            <br />
                        </td>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <td runat="server">
                             <asp:Label ID="lblEmptyResults" runat="server" Text='No se han encontrado resultados.' Font-Bold="True" Height="65px" Width="200px" Font-Size="X-Large" />
                       </td>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <td runat="server" />
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
                    </GroupTemplate>
                    <InsertItemTemplate>
                        <td runat="server" style="">TituloContenido_Cat:
                            <asp:TextBox ID="TituloContenido_CatTextBox" runat="server" Text='<%# Bind("TituloContenido_Cat") %>' />
                            <br />
                            URLPortada_Cat:
                            <asp:TextBox ID="URLPortada_CatTextBox" runat="server" Text='<%# Bind("URLPortada_Cat") %>' />
                            <br />
                            Clasif_Edad_Cat:
                            <asp:TextBox ID="Clasif_Edad_CatTextBox" runat="server" Text='<%# Bind("Clasif_Edad_Cat") %>' />
                            <br />
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <br />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                            <br />
                        </td>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <td runat="server" style="">&nbsp;<asp:Label ID="TituloContenido_CatLabel" runat="server" Text='<%# Eval("TituloContenido_Cat") %>' CssClass="tituloContenido" />
                            <br />
                            &nbsp;
                                <asp:ImageButton ID="imgBtnPortada" runat="server" ImageUrl='<%# Eval("URLPortada_Cat") %>' OnCommand="imgBtnPortada_Command" CommandName="eventoSeleccion" CommandArgument='<%# Eval("IDContenido_Cat") %>' />
                            <br />
                            <br />
                        </td>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                        <tr id="groupPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="">
                                    <asp:DataPager ID="DataPager1" PagedControlID="lvCatalogo" runat="server" PageSize="9">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonCssClass="botoncito-page" ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true" ShowNextPageButton="false" />
                                            <asp:NumericPagerField NumericButtonCssClass="botoncito-page" ButtonType="Link" />
                                            <asp:NextPreviousPagerField ButtonCssClass="botoncito-page" ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <td runat="server" style="">TituloContenido_Cat:
                            <asp:Label ID="TituloContenido_CatLabel" runat="server" Text='<%# Eval("TituloContenido_Cat") %>' />
                            <br />
                            URLPortada_Cat:
                            <asp:Label ID="URLPortada_CatLabel" runat="server" Text='<%# Eval("URLPortada_Cat") %>' />
                            <br />
                            Clasif_Edad_Cat:
                            <asp:Label ID="Clasif_Edad_CatLabel" runat="server" Text='<%# Eval("Clasif_Edad_Cat") %>' />
                            <br />
                        </td>
                    </SelectedItemTemplate>
                </asp:ListView>
            </div>

            <h2>PRÓXIMOS ESTRENOS EN DEVFLIX</h2>
            <div class="carousel">

                <img src="Recursos/Imagenes/1.jpg" alt="" class="pic" />
                <img src="Recursos/Imagenes/2.jpg" alt="" class="pic" />
                <img src="Recursos/Imagenes/3.jpg" alt="" class="pic" />
                <img src="Recursos/Imagenes/4.png" alt="" class="pic" />
                <img src="Recursos/Imagenes/5.jpg" alt="" class="pic" />
            </div>
        </main>
         <footer>
            <nav class="footer">
                <a class="botonesFooter" href="#"> <img src="Recursos/Imagenes/flechaArriba.png" alt="Home"/> </a>
                <p> Desarrolladores: Guido Benetti, Zoe Rouco, Patricio Bordón, Luciano Vitale, Melany Nahir Dalama</p>
            </nav>
        </footer>
    </form>
</body>
</html>
