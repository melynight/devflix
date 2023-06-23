<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suscripciones.aspx.cs" Inherits="Vistas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="icon" type="image/png" href="Recursos/Imagenes/favicon.png" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Suscripciones.css" />
    <title>Suscripciones | DevFlix</title>

    </head>
    <body style="background-image: url(Recursos/Imagenes/fondoHome2.jpg); background-size: cover; opacity: 10;">
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

        <div>
            <h2 id="titulo">MEMBERSÍAS</h2>
            <p style="color: #FFFFFF">Ingresar PIN de administrador: 
                <asp:TextBox ID="txtPIN" runat="server" MaxLength="4" TextMode="Password" ValidationGroup="PIN"></asp:TextBox>
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvPIN" runat="server" ControlToValidate="txtPIN" Display="Dynamic" ValidationGroup="PIN">*Debe ingresar un PIN para continuar.</asp:RequiredFieldValidator>
            </p>
            <p style="color: #FFFFFF">
                <asp:Button runat="server" Text="Aceptar" BorderColor="#63B9CD" Height="22px" Width="154px" ID="btnAceptar" OnClick="btnAceptar_Click" ValidationGroup="PIN"></asp:Button>
            </p>
        </div>

        <div>
            <asp:ListView ID="lvSuscripciones" runat="server" DataSourceID="SqlDataSourceSus" GroupItemCount="3">
                <AlternatingItemTemplate>
                    <td runat="server" style="border-color: #63b9cd; border-style: double; border-width: medium; border-spacing: 20px; color: #000000; text-align: center; background-color: #FFFFFF;">
                        <asp:Label ID="Nombre_TsLabel" runat="server" Text='<%# Eval("Nombre_Ts") %>' />
                        <br />
                        <asp:Label ID="Beneficios_TsLabel" runat="server" Text='<%# Eval("Beneficios_Ts") %>' />
                        <br />
                        <asp:Label ID="Precio_TsLabel" runat="server" Text='<%# Eval("Precio_Ts") %>'></asp:Label>
                        <br />
                        <br /></td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="">Nombre_Ts:
                        <asp:TextBox ID="Nombre_TsTextBox" runat="server" Text='<%# Bind("Nombre_Ts") %>' />
                        <br />Precio_Ts:
                        <asp:TextBox ID="Precio_TsTextBox" runat="server" Text='<%# Bind("Precio_Ts") %>' />
                        <br />Beneficios_Ts:
                        <asp:TextBox ID="Beneficios_TsTextBox" runat="server" Text='<%# Bind("Beneficios_Ts") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No se han devuelto datos.</td>
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
                    <td runat="server" style="">Nombre_Ts:
                        <asp:TextBox ID="Nombre_TsTextBox" runat="server" Text='<%# Bind("Nombre_Ts") %>' />
                        <br />Precio_Ts:
                        <asp:TextBox ID="Precio_TsTextBox" runat="server" Text='<%# Bind("Precio_Ts") %>' />
                        <br />Beneficios_Ts:
                        <asp:TextBox ID="Beneficios_TsTextBox" runat="server" Text='<%# Bind("Beneficios_Ts") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="border: medium double #63b9cd; border-spacing: 50px; color: #000000; background-color: #FFFFFF;">
                        <asp:Label ID="Nombre_TsLabel" runat="server" Text='<%# Eval("Nombre_Ts") %>' />
                        <br />
                        <asp:Label ID="Beneficios_TsLabel" runat="server" Text='<%# Eval("Beneficios_Ts") %>' />
                        <br />
                        <asp:Label ID="Precio_TsLabel" runat="server" Text='<%# Eval("Precio_Ts") %>' />
                        <br />
                        <br />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server" style="text-align: center">
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
                    <td runat="server" style="">Nombre_Ts:
                        <asp:Label ID="Nombre_TsLabel" runat="server" Text='<%# Eval("Nombre_Ts") %>' />
                        <br />Precio_Ts:
                        <asp:Label ID="Precio_TsLabel" runat="server" Text='<%# Eval("Precio_Ts") %>' />
                        <br />Beneficios_Ts:
                        <asp:Label ID="Beneficios_TsLabel" runat="server" Text='<%# Eval("Beneficios_Ts") %>' />
                        <br /></td>
                </SelectedItemTemplate>
            </asp:ListView>


        <article id="suscribirse">
            <asp:DropDownList ID="ddlSuscripciones" runat="server" Height="22px" Width="170px" Visible="False">
            </asp:DropDownList>
            <asp:Button runat="server" Text="Suscribirse al paquete" BorderColor="#63B9CD" Height="22px" Width="197px" ID="btnPaquete" OnClick="btnPaquete_Click" Visible="False"></asp:Button>
        </article>


            <asp:SqlDataSource ID="SqlDataSourceSus" runat="server" ConnectionString="<%$ ConnectionStrings:DevFlixDBConnectionString4 %>" SelectCommand="SELECT [CodTipo_Ts], [Nombre_Ts], [Precio_Ts], [Beneficios_Ts] FROM [TipoSuscripciones] WHERE [CodTipo_Ts] <> 'PUNIVERSAL'"></asp:SqlDataSource>
        </div>

        <div>
            <p> <asp:Label ID="lblMensajePlan" runat="server" ForeColor="White"></asp:Label></p>
        </div>

        <article>
            <p style="color: #FFFFFF">&#8226;Para cancelaciones de membersías©, por favor dirigirse a Ajustes → Eliminar Cuenta.</p>
        </article>

    </form>
</body>
</html>