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

    <style type="text/css">
        .auto-style2 {
            height: 114px;
        }
    </style>

    </head>
    <body style="background-image: url(Recursos/Imagenes/fondoSeleccionarUsuarios.jpg); background-size: cover; opacity: 10;">
    <form id="form1" runat="server">

        <nav class="menu_principal">
                <a class="botonesMenu" href="Home.aspx"> <img src="Recursos/Imagenes/home.png" alt="Home"/> </a>
                <a class="botonesMenu" href="Suscripciones.aspx">SUSCRIPCIONES</a>
                <a class="botonesMenu" href="Favoritos.aspx">FAVORITOS</a>
                <a class="botonesMenu" href="DescripcionPelicula.aspx">SORPRENDEME </a>
                <a class="botonesMenu" href="Reportes.aspx">REPORTES </a>
                <a class="botonesMenu" href="SeleccionarUsuario.aspx">USUARIOS </a>
                <a class="botonesMenu" href="Configuraciones.aspx">AJUSTES </a>
                <a class="botonesMenu" href="Log.aspx">CERRAR SESION </a>
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
        </nav>
        <div>
          
            
            <p>&nbsp;</p>
            <p id="titulo">Membresías</p>
            <p>&nbsp;</p>
            <p style="color: #FFFFFF">Ingresar PIN de administrador: 
                <asp:TextBox ID="txtPIN" runat="server" MaxLength="4" TextMode="Password" ValidationGroup="PIN"></asp:TextBox>
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="White" Visible="False"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvPIN" runat="server" ControlToValidate="txtPIN" Display="Dynamic" ValidationGroup="PIN">*Debe ingresar un PIN para continuar</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvDigitos" runat="server" ControlToValidate="txtPIN" Display="Dynamic" OnServerValidate="cvDigitos_ServerValidate" ValidationGroup="PIN"> y el PIN ingresado debe ser de 4 digitos.</asp:CustomValidator>
                <asp:RegularExpressionValidator ID="revNumeros" runat="server" ControlToValidate="txtPIN" ValidationExpression="^\d+$" ValidationGroup="PIN" Display="Dynamic">*Debe ingresar solo numeros</asp:RegularExpressionValidator>
            </p>
            <p>&nbsp;</p>
            <p style="color: #FFFFFF">
                <asp:Button runat="server" Text="Aceptar" BorderColor="#63B9CD" Height="22px" Width="154px" ID="btnAceptar" OnClick="btnAceptar_Click" ValidationGroup="PIN"></asp:Button>
            </p>
            </div>

        <div class="list-view">
            <asp:ListView ID="lvSuscripciones" runat="server" DataSourceID="SqlDataSourceSus" GroupItemCount="3">
                <AlternatingItemTemplate>
                    <td runat="server" style="border-style: double; border-width: thin; border-color: #63b9cd; border-spacing: 20px; color: #000000; text-align: center; background-color: #EAEAEA; width: 450px; height: 200px;">                       
                        <br />
                        <asp:Label ID="Nombre_TsLabel" runat="server" Text='<%# Eval("Nombre_Ts") %>' Font-Bold="True" Height="65px" Width="200px" Font-Size="X-Large" />
                        <br />
                        <asp:Label ID="Beneficios_TsLabel" runat="server" Text='<%# Eval("Beneficios_Ts") %>'></asp:Label>
                        <br />
                        -Hasta
                        <asp:Label ID="CantUsuarios_TsLabel" runat="server" Text='<%# Eval("CantUsuarios_Ts") %>' />
                        &nbsp;usuario(s) disponibles para usar simultaneamente<br /> <br />
                        <br />
                        <asp:Label ID="Precio_TsLabel" runat="server" Text='<%# Eval("Precio_Ts") %>' BackColor="#66CCFF" BorderColor="Black" Width="300px" />
                        <br />
                        </td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="">Nombre_Ts:
                        <asp:TextBox ID="Nombre_TsTextBox" runat="server" Text='<%# Bind("Nombre_Ts") %>' />
                        <br />Precio_Ts:
                        <asp:TextBox ID="Precio_TsTextBox" runat="server" Text='<%# Bind("Precio_Ts") %>' />
                        <br />Beneficios_Ts:
                        <asp:TextBox ID="Beneficios_TsTextBox" runat="server" Text='<%# Bind("Beneficios_Ts") %>' />
                        <br />
                        CantUsuarios_Ts:
                        <asp:TextBox ID="CantUsuarios_TsTextBox" runat="server" Text='<%# Bind("CantUsuarios_Ts") %>' />
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
                        CantUsuarios_Ts:
                        <asp:TextBox ID="CantUsuarios_TsTextBox" runat="server" Text='<%# Bind("CantUsuarios_Ts") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="border-style: double; border-width: thin; border-color: #63b9cd; border-spacing: 20px; color: #000000; text-align: center; background-color: #EAEAEA; width: 450px; height: 200px;">
                        <br />
                        <asp:Label ID="Nombre_TsLabel" runat="server" Text='<%# Eval("Nombre_Ts") %>' Font-Bold="True" Height="65px" Width="200px" Font-Size="X-Large" />
                        <br />
                        <asp:Label ID="Beneficios_TsLabel" runat="server" Text='<%# Eval("Beneficios_Ts") %>' />
                        <br />
                        -Hasta
                        <asp:Label ID="CantUsuarios_TsLabel" runat="server" Text='<%# Eval("CantUsuarios_Ts") %>' />
                        &nbsp;usuario(s) disponibles para usar simultaneamente<br />
                        <br />
                        <br />
                        <asp:Label ID="Precio_TsLabel" runat="server" Text='<%# Eval("Precio_Ts") %>' BackColor="#66CCFF" BorderColor="Black" Width="300px" />
                        <br />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server" style="text-align: center; " class="auto-style2">
                                <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center"></td>
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
                        <br />CantUsuarios_Ts:
                        <asp:Label ID="CantUsuarios_TsLabel" runat="server" Text='<%# Eval("CantUsuarios_Ts") %>' />
                        <br />
                    </td>
                </SelectedItemTemplate>
            </asp:ListView>

            <br />

            </div>
            <br />
        <div class="Plan-Actual">
             <h4 class="TxtplanActual"><asp:Label ID="lblPlanActual" runat="server" ForeColor="White"></asp:Label></h4>
        </div>
       

        <article id="suscribirse">
            <asp:DropDownList ID="ddlSuscripciones" runat="server" Height="22px" Width="170px" Visible="False">
            </asp:DropDownList>
            <asp:Button runat="server" Text="Suscribirse al paquete" BorderColor="#63B9CD" Height="22px" Width="197px" ID="btnPaquete" OnClick="btnPaquete_Click" Visible="False"></asp:Button>
        </article>


        <div>
            <p> &nbsp;</p>
            <p> <asp:Label ID="lblMensajePlan" runat="server" ForeColor="White"></asp:Label></p>
            <p> 
                <asp:Button ID="btnSi" runat="server" BorderColor="#63B9CD" OnClick="btnSi_Click" Text="Si, deseo cambiar el plan." Visible="False" Width="276px" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNo" runat="server" BorderColor="#63B9CD" OnClick="btnNo_Click" Text="No, prefiero quedarme con el anterior." Visible="False" Width="276px" />
            </p>
            <p> &nbsp;</p>
        </div>

        <article>
            <p style="color: #FFFFFF">&#8226;Para cancelaciones de membresías©, por favor dirigirse a Ajustes → Eliminar Cuenta.<asp:SqlDataSource ID="SqlDataSourceSus" runat="server" ConnectionString="<%$ ConnectionStrings:DevFlixDBConnectionString4 %>" SelectCommand="SELECT [Nombre_Ts], [Precio_Ts], [Beneficios_Ts], [CantUsuarios_Ts] FROM [TipoSuscripciones] WHERE [CodTipo_Ts] <> 'PUNIVERSAL'"></asp:SqlDataSource>

            </p>
        </article>

    </form>
</body>
</html>