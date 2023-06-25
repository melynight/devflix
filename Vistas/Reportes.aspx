﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Vistas.Reportes" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reportes | DevFlix</title>
    <link rel="stylesheet" type="text/css" href="Recursos\\Estilos\\ReportesStyle.css" />
    <link rel="icon" type="image/png" href="Recursos/Imagenes/favicon.png" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 567px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="menu_principal">

                <a class="botonesMenu" href="Home.aspx">HOME</a>
                <a class="botonesMenu" href="Suscripciones.aspx">SUSCRIPCIONES</a>
                <a class="botonesMenu" href="Favoritos.aspx">FAVORITOS</a>
                <a class="botonesMenu" href="DescripcionPelicula.aspx">SORPRENDEME </a>
                <a class="botonesMenu" href="Reportes.aspx">REPORTES </a>
                <a class="botonesMenu"href="SeleccionarUsuario.aspx">USUARIOS </a>
                <a class="botonesMenu" href="Configuraciones.aspx">AJUSTES </a>
                <a class="botonesMenu" href="Log.aspx">CERRAR SESION </a>
                <asp:Label ID="lblBienvenidoUsuario" runat="server"></asp:Label>
                <br />
            </nav>
        </header>
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Historial de suscripciones:</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <p>
                Desde:
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
&nbsp;Hasta:
                <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                <asp:Button ID="btnHistorial" runat="server" BackColor="Blue" BorderColor="#3399FF" Font-Bold="True" Font-Italic="False" ForeColor="White" OnClick="btnHistorial_Click" Text="Ver" Width="99px" />
            </p>
            <p>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="*Debe seleccionar ambas fechas!"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnHistorialTodo" runat="server" BackColor="Blue" BorderColor="#3399FF" Font-Bold="True" Font-Italic="False" ForeColor="White" OnClick="btnHistorialTodo_Click" Text="Ver Todo" Width="99px" />
            </p>
            <p>
                <asp:GridView OnRowDataBound="grvFacturacion_RowDataBound" ID="grvFacturacion" CssClass="grvFacturacion" AutoPostBack="true" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grvFacturacion_SelectedIndexChanged" OnSelectedIndexChanging="grvFacturacion_SelectedIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:TemplateField HeaderText="  Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Bind("Fecha_F") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="  Nº de Transacción">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_N_Transaccion" runat="server" Text='<%# Bind("IDFacturacion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="  Suscripción">
                            <ItemTemplate>
                                <asp:Label ID="lbl_It_IDSuscripcion" runat="server" Text='<%# Bind("CodTipo_Sus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="  Importe">
                            <ItemTemplate>
                                <asp:Label ID="lbl_It_Importe" runat="server" Text='<%# Bind("Importe_F") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </p>
        </div>
    </form>
</body>
</html>
