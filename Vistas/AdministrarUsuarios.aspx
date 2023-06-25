<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="Vistas.CrearUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Home_Styles.css" />
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\Configuraciones.css" />
    <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />

    <title>Administrar Usuario | DevFlix</title>
    <style type="text/css">
        .auto-style1 {
            width: 160px;
        }
    </style>
</head>
<body style="background-image: url(Recursos/Imagenes/fondoSeleccionarUsuarios.jpg); background-size: cover;">
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
        <article class="RecuadroAdministrarUser">
            <div class="FlexBoxAdministrarUsers">
                <div>
                    <asp:Image ID="imgAdmin" runat="server" Width="160px" />
                </div>
                <div>
                    <asp:Label ID="lblNombreAdmin" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Button ID="btnAgregarUsuario" runat="server" Text="CREAR USUARIO" Width="160px" class="MarginAdministrarUsers" OnClick="btnAgregarUsuario_Click" />
                    <br />
                    <asp:Button ID="btnModificarUsuario" runat="server" Text="MODIFICAR USUARIO" Width="160px" class="MarginAdministrarUsers" OnClick="btnModificarUsuario_Click" />
                </div>
                <div>
                    <asp:Button ID="btnEliminarUsuario" runat="server" Text="ELIMINAR USUARIO" Width="160px" class="MarginAdministrarUsers" OnClick="btnEliminarUsuario_Click" />
                    <br />
                    <br />
                    <br />
                   
                </div>
            </div>
        </article>
         <asp:Label ID="lblErrorNombre" runat="server" Text="El nombre ya existe!!" ForeColor="#CC0000" Font-Size="XX-Large"></asp:Label>
        <article class="RecuadroUsers">
            <div class="FlexBoxAdministrarUsers">
                <div class="listview">
                    <asp:ListView ID="ListView1" runat="server" DataKeyNames="IDCuenta" DataSourceID="SqlDataSource1">
                        <EditItemTemplate>
                            <td runat="server" style="">IDCuenta:
                                <asp:Label ID="IDCuentaLabel1" runat="server" Text='<%# Eval("IDCuenta") %>' />
                                <br />
                                Nombre_Cu:
                                <asp:TextBox ID="Nombre_CuTextBox" runat="server" Text='<%# Bind("Nombre_Cu") %>' />
                                <br />
                                Edad_Cu:
                                <asp:TextBox ID="Edad_CuTextBox" runat="server" Text='<%# Bind("Edad_Cu") %>' />
                                <br />
                                URLImagenDefault:
                                <asp:TextBox ID="URLImagenDefaultTextBox" runat="server" Text='<%# Bind("URLImagenDefault") %>' />
                                <br />
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                            </td>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <table style="">
                                <tr>
                                    <td>No se han devuelto datos.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <InsertItemTemplate>
                            <td runat="server" style="">Nombre_Cu:
                                <asp:TextBox ID="Nombre_CuTextBox" runat="server" Text='<%# Bind("Nombre_Cu") %>' />
                                <br />Edad_Cu:
                                <asp:TextBox ID="Edad_CuTextBox" runat="server" Text='<%# Bind("Edad_Cu") %>' />
                                <br />URLImagenDefault:
                                <asp:TextBox ID="URLImagenDefaultTextBox" runat="server" Text='<%# Bind("URLImagenDefault") %>' />
                                <br />
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                            </td>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <td runat="server" style="border-style: solid; border-width: 1px; border-spacing: 15px" class="auto-style1">
                                <asp:Image ID="imgUser" runat="server" ImageUrl='<%# Eval("URLImagenDefault") %>' Width="100px" />
                                <br />
                                <asp:Label ID="Nombre_CuLabel" runat="server" Text='<%# Eval("Nombre_Cu") %>' />
                                <br />
                                <asp:Label ID="Edad_CuLabel" runat="server" Text='<%# Eval("Edad_Cu") %>' />
                                <br />
                                <asp:Button ID="btnModificarUsuario" runat="server" class="MarginAdministrarUsers" CommandArgument='<%# Eval("IDCuenta") %>' CommandName="ModificarUsuario" OnCommand="btnModificarUsuario_Command" Text="MODIFICAR USUARIO" Width="160px" />
                                <br />
                                <asp:Button ID="btnEliminarUsuario" runat="server" class="MarginAdministrarUsers" CommandArgument='<%# Eval("IDCuenta") %>' CommandName="EliminarUsuario" Text="ELIMINAR USUARIO" Width="160px" OnCommand="btnEliminarUsuario_Command" />
                                <br />
                            </td>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <table runat="server" border="0" style="">
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </table>
                            <div style="">
                            </div>
                        </LayoutTemplate>
                        <SelectedItemTemplate>
                            <td runat="server" style="">IDCuenta:
                                <asp:Label ID="IDCuentaLabel" runat="server" Text='<%# Eval("IDCuenta") %>' />
                                <br />
                                Nombre_Cu:
                                <asp:Label ID="Nombre_CuLabel" runat="server" Text='<%# Eval("Nombre_Cu") %>' />
                                <br />
                                Edad_Cu:
                                <asp:Label ID="Edad_CuLabel" runat="server" Text='<%# Eval("Edad_Cu") %>' />
                                <br />
                                URLImagenDefault:
                                <asp:Label ID="URLImagenDefaultLabel" runat="server" Text='<%# Eval("URLImagenDefault") %>' />
                                <br />
                            </td>
                        </SelectedItemTemplate>
                    </asp:ListView>
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DevFlixDBConnectionString4 %>" SelectCommand="SELECT [Nombre_Cu], [Edad_Cu], [IDRef_Cu], [IDCuenta], [URLImagenDefault] FROM [Cuentas] WHERE ([IDRef_Cu] = @IDRef_Cu)">
                        <SelectParameters>
                            <asp:SessionParameter Name="IDRef_Cu" SessionField="IDAdmin" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Button ID="btnVolver" runat="server" OnClick="btnCancelar_Click" Text="VOLVER" Width="160px" class="MarginAdministrarUsers" Height="50px" />
                </div>

                <div class="menu">
                    
                    <asp:Label ID="lblNombre" runat="server" Text="Actualizar nombre:" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNuevoNombre" runat="server" Visible="False" ValidationGroup="ErrorNombre"></asp:TextBox>
                    <asp:Label ID="lblNuevaEdad" runat="server" Text="Actualizar edad:" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNuevaEdad" runat="server" MaxLength="3" TextMode="Number" Visible="False" ValidationGroup="ErrorEdad"></asp:TextBox>
                    &nbsp;<br />
&nbsp;<asp:Image ID="imgGafas1" runat="server" ImageUrl="~/Recursos/Imagenes/usuarioGafas.png" Visible="False" />
                    <asp:Image ID="imgGafas2" runat="server" ImageUrl="~/Recursos/Imagenes/usuarioGafas2.png" Visible="False" />
                    <asp:Image ID="imgKids" runat="server" ImageUrl="~/Recursos/Imagenes/UsuarioKids.png" Visible="False" Width="128px" />
                    <br />
                    <asp:DropDownList ID="ddlElegirImagen" runat="server" Visible="False">
                        <asp:ListItem Selected="True" Value="0">--Seleccione Icono--</asp:ListItem>
                        <asp:ListItem Value="1">Chico</asp:ListItem>
                        <asp:ListItem Value="2">Chica</asp:ListItem>
                        <asp:ListItem Value="3">Kids</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" Visible="False" ValidationGroup="ErrorNombre" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="False" OnClick="btnCancelar_Click1" />
                </div>
            </div>
        </article>
    </form>
</body>
</html>