<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Vistas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

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

        <div style="font-family: 'Times New Roman', Times, serif; font-size: x-large; font-weight: bold; color: #FFFFFF; text-shadow: 0em 0em 5px #000000">
            Mi lista<br />
                        <asp:Button ID="Button1" runat="server" BackColor="#63B9CD" Text="Guardar cambios" />
                    <br />
<br />
            </div>
        <div>
        <asp:ListView ID="lvFavoritos" runat="server" DataSourceID="DataSourceFavoritos" GroupItemCount="3">
            <AlternatingItemTemplate>
                <td runat="server" style="padding: 10px; text-align: center">
                    <asp:Label ID="TituloContenido_CatLabel" runat="server" ForeColor="White" Text='<%# Eval("TituloContenido_Cat") %>' />
                    <br />
                    <asp:ImageButton ID="imgbtnPortada" runat="server" Height="375px" ImageUrl='<%# Eval("URLPortada_Cat") %>' Width="246px" />
                    <br />
                    <asp:CheckBox ID="cbEliminar" runat="server" ForeColor="White" Text="Eliminar de favoritos." />
                    <br /></td>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <td runat="server" style="">TituloContenido_Cat:
                    <asp:TextBox ID="TituloContenido_CatTextBox" runat="server" Text='<%# Bind("TituloContenido_Cat") %>' />
                    <br />URLPortada_Cat:
                    <asp:TextBox ID="URLPortada_CatTextBox" runat="server" Text='<%# Bind("URLPortada_Cat") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                    <br /></td>
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
                    <br />URLPortada_Cat:
                    <asp:TextBox ID="URLPortada_CatTextBox" runat="server" Text='<%# Bind("URLPortada_Cat") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                    <br /></td>
            </InsertItemTemplate>
            <ItemTemplate>
                <td runat="server" style="padding: 10px; text-align: center">
                    <asp:Label ID="TituloContenido_CatLabel" runat="server" Text='<%# Eval("TituloContenido_Cat") %>' ForeColor="White" />
                    <br />
                    <asp:ImageButton ID="imgbtnPortada" runat="server" Height="375px" ImageUrl='<%# Eval("URLPortada_Cat") %>' Width="246px" />
                    <br />
                    <asp:CheckBox ID="cbEliminar" runat="server" ForeColor="White" Text="Eliminar de favoritos." />
                    <br /></td>
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
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <td runat="server" style="">TituloContenido_Cat:
                    <asp:Label ID="TituloContenido_CatLabel" runat="server" Text='<%# Eval("TituloContenido_Cat") %>' />
                    <br />URLPortada_Cat:
                    <asp:Label ID="URLPortada_CatLabel" runat="server" Text='<%# Eval("URLPortada_Cat") %>' />
                    <br /></td>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="DataSourceFavoritos" runat="server" ConnectionString="<%$ ConnectionStrings:DevFlixDBConnectionString5 %>" SelectCommand="spCargarListViewFavoritos" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="IDcuenta" SessionField="IDCuenta" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>