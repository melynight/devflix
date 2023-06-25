<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarUsuario.aspx.cs" Inherits="Vistas.SeleccionarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

   <link rel="icon" type="image/png" href="Recursos\\Imagenes\\favicon.png" />

    <title>Seleccionar Usuario | DevFlix</title>
    <style type="text/css">
        .auto-style1 {
            width: 121px;
            text-align: center;
            color: black;
        }
    </style>
</head>

<body style="background-image: url(Recursos/Imagenes/fondoSeleccionarUsuarios.jpg); background-size: cover; margin:0;">

    <link rel="stylesheet" type="text/css" href="Recursos/Estilos/SeleccionUsuarios.css" />

    <form id="titleSeleccionarUsuario" runat="server">

        <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Recursos/Imagenes/favicon.png" />

        <asp:Label ID="lblIDRef" runat="server" Visible="False"></asp:Label>

        <div class="seleccionarUsuario">

            <h1> SELECCIONAR USUARIO </h1>

        </div>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <div class="seleccion-usuarios">
                 
                <asp:SqlDataSource ID="DevFlix" runat="server" ConnectionString="<%$ ConnectionStrings:DevFlixDBConnectionString3 %>" SelectCommand="SELECT IDCuenta, IDRef_Cu, URLImagenDefault, Nombre_Cu FROM Cuentas WHERE (IDRef_Cu = @IDRef_Cu)" OnSelecting="DevFlix_Selecting">
                    <SelectParameters>
                        <asp:SessionParameter Name="IDRef_Cu" SessionField="IDAdmin" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                 
                <asp:SqlDataSource ID="DevFlix2" runat="server" ConnectionString="<%$ ConnectionStrings:DevFlixDBConnectionString3 %>" SelectCommand="SELECT top 1 [IDCuenta], [IDRef_Cu], [URLImagenDefault], [Nombre_Cu] FROM [Cuentas] WHERE ([IDRef_Cu] = @IDRef_Cu)" OnSelecting="DevFlix_Selecting">
                    <SelectParameters>
                        <asp:SessionParameter Name="IDRef_Cu" SessionField="IDAdmin" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                 
                <asp:SqlDataSource ID="DevFlix3" runat="server" ConnectionString="<%$ ConnectionStrings:DevFlixDBConnectionString3 %>" SelectCommand="SELECT top 3 [IDCuenta], [IDRef_Cu], [URLImagenDefault], [Nombre_Cu] FROM [Cuentas] WHERE ([IDRef_Cu] = @IDRef_Cu)" OnSelecting="DevFlix_Selecting">
                    <SelectParameters>
                        <asp:SessionParameter Name="IDRef_Cu" SessionField="IDAdmin" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:ListView ID="lvlUsers" runat="server" DataKeyNames="IDCuenta" DataSourceID="DevFlix">
                    <EditItemTemplate>
                        <td runat="server" style="">IDCuenta:
                            <asp:Label ID="IDCuentaLabel1" runat="server" Text='<%# Eval("IDCuenta") %>' />
                            <br />
                            IDRef_Cu:
                            <asp:TextBox ID="IDRef_CuTextBox" runat="server" Text='<%# Bind("IDRef_Cu") %>' />
                            <br />
                            URLImagenDefault:
                            <asp:TextBox ID="URLImagenDefaultTextBox" runat="server" Text='<%# Bind("URLImagenDefault") %>' />
                            <br />
                            Nombre_Cu:
                            <asp:TextBox ID="Nombre_CuTextBox" runat="server" Text='<%# Bind("Nombre_Cu") %>' />
                            <br />
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table style="">
                            
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <td runat="server" style="">IDRef_Cu:
                            <asp:TextBox ID="IDRef_CuTextBox" runat="server" Text='<%# Bind("IDRef_Cu") %>' />
                            <br />URLImagenDefault:
                            <asp:TextBox ID="URLImagenDefaultTextBox" runat="server" Text='<%# Bind("URLImagenDefault") %>' />
                            <br />Nombre_Cu:
                            <asp:TextBox ID="Nombre_CuTextBox" runat="server" Text='<%# Bind("Nombre_Cu") %>' />
                            <br />
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <td runat="server" class="auto-style1">
                            <asp:ImageButton ID="imgBtnUsuario1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" CommandArgument='<%# Eval("IDCuenta") %>' CommandName="ingresoUsuario" Height="128px" ImageAlign="Middle" ImageUrl='<%# Eval("URLImagenDefault") %>' OnCommand="imgBtnUsuario1_Command" Width="128px" />
                            <br />
                            <asp:Label ID="Nombre_CuLabel" runat="server" Text='<%# Eval("Nombre_Cu") %>'></asp:Label>
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
                            IDRef_Cu:
                            <asp:Label ID="IDRef_CuLabel" runat="server" Text='<%# Eval("IDRef_Cu") %>' />
                            <br />
                            URLImagenDefault:
                            <asp:Label ID="URLImagenDefaultLabel" runat="server" Text='<%# Eval("URLImagenDefault") %>' />
                            <br />
                            Nombre_Cu:
                            <asp:Label ID="Nombre_CuLabel" runat="server" Text='<%# Eval("Nombre_Cu") %>' />
                            <br />
                        </td>
                    </SelectedItemTemplate>
                </asp:ListView>
                <br />
                <br />
            
             <div class="Administrador">  
                <asp:ImageButton ID="btnAdmin" runat="server" Height="128px" ImageUrl="~/Recursos/Imagenes/usuario.png" Width="128px" OnClick="btnAdmin_Click" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" />
                
                 <br />
               <asp:Label ID="lblNombreAdmin" runat="server" ForeColor="Black"></asp:Label>
                <br />
&nbsp;
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblPin" runat="server">Ingrese PIN para agregar un usuario:</asp:Label>
                <asp:TextBox ID="txtPin" runat="server" MaxLength="4" TextMode="Password" Width="62px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvErrorPin" runat="server" ControlToValidate="txtPin" Display="Dynamic" ValidationGroup="validarPIN">*Debe ingresar un PIN para continuar.</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="btnAceptar" runat="server" BorderColor="#0099CC" BorderWidth="3px" OnClick="btnAceptar_Click" Text="Aceptar" Width="87px" ValidationGroup="validarPIN" />
                <asp:Button ID="btnCancelar" runat="server" BorderColor="#0099CC" BorderWidth="3px" OnClick="btnCancelar_Click" Text="Cancelar" Width="87px" />
                <br />
               </div>
                
          <asp:ImageButton ID="imgbtnAgregarUsuario" runat="server" DescriptionUrl="AgregarUsuario" ImageUrl="~/Recursos/Imagenes/boton-agregarUsuario.png" OnClick="imgbtnAgregarUsuario_Click" Width="32px" />
   </div>
        
            </form>
</body>
</html>