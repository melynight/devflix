<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Vistas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="icon" type="image/png" href="Recursos/Imagenes/favicon.png" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Suscripciones.css" />
    <title>Favoritos | DevFlix</title>

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
            <br />
            <p>&nbsp;&nbsp;</p>
            <p id="titulo">Mi lista</p>
        &nbsp;<asp:ListView ID="lvFavoritos" runat="server" DataSourceID="FavoritosDataSource" GroupItemCount="5">
                <AlternatingItemTemplate>
                    <td runat="server" style="padding: 20px; text-align: center">
                        <asp:Label ID="TituloContenido_CatLabel" runat="server" ForeColor="White" Text='<%# Eval("TituloContenido_Cat") %>'></asp:Label>
                        <br />
                        <asp:ImageButton ID="imgbtnPortada" runat="server" Height="375px" ImageUrl='<%# Eval("URLPortada_Cat") %>' Width="246px" />
                        <br />
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Eval("IDContenido_F") %>' CommandName="eventoSeleccionar" OnCommand="btnEliminar_Command" Text="Eliminar de favoritos" BorderColor="#63B9CD" />
                    </td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="">TituloContenido_Cat:
                        <asp:TextBox ID="TituloContenido_CatTextBox" runat="server" Text='<%# Bind("TituloContenido_Cat") %>' />
                        <br />
                    URLPortada_Cat:
                        <asp:TextBox ID="URLPortada_CatTextBox" runat="server" Text='<%# Bind("URLPortada_Cat") %>' />
                        <br />
                    IDContenido_F:
                        <asp:TextBox ID="IDContenido_FTextBox" runat="server" Text='<%# Bind("IDContenido_F") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                        <br />
                    </td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td style="font-family: 'Times New Roman', Times, serif; font-size: x-large; font-weight: bold; color: #FFFFFF; text-shadow: 0em 0em 5px #000000">No tiene favoritos.</td>
                        </tr>
                    </table>
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
                    IDContenido_F:
                        <asp:TextBox ID="IDContenido_FTextBox" runat="server" Text='<%# Bind("IDContenido_F") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br />
                    </td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="text-align: center">
                        <asp:Label ID="TituloContenido_CatLabel" runat="server" ForeColor="White" Text='<%# Eval("TituloContenido_Cat") %>'></asp:Label>
                        <br />
                        <asp:ImageButton ID="imgbtnPortada" runat="server" Height="375px" ImageUrl='<%# Eval("URLPortada_Cat") %>' Width="246px" />
                        <br />
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" CommandArgument='<%# Bind("IDContenido_F") %>' CommandName="eventoSeleccionar" OnCommand="btnEliminar_Command" Text="Eliminar de favoritos" BorderColor="#63B9CD" />
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
                        <tr runat="server">
                            <td runat="server" style="padding: 10px; text-align: center; color: #6699FF;">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
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
                    IDContenido_F:
                        <asp:Label ID="IDContenido_FLabel" runat="server" Text='<%# Eval("IDContenido_F") %>' />
                        <br />
                    </td>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
            <asp:SqlDataSource ID="FavoritosDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DevFlixDBConnectionString %>" SelectCommand="spCargarListViewFavoritos" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter Name="IDcuenta" SessionField="IDCuenta" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>