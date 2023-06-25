using System;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.UI;

namespace Vistas
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioCuenta nCuenta = new NegocioCuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            cuenta = (Cuenta)Session["Cuenta"];
            if(!IsPostBack)
            lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarUsuarios.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Cuenta cuentaNueva = new Cuenta();
            cuentaNueva.SetNombre_Cu(txtNombreUsuario.Text.Trim());
            cuentaNueva.SetEdad_Cu(Convert.ToInt32(txtEdadUsuario.Text));
            cuentaNueva.SetIDRef_Cu((int)Session["IDAdmin"]);
            cuentaNueva.SetEstado_Cu(true);

            bool agrego = nCuenta.AgregarUsuario(cuentaNueva);

            if (agrego)
            {
                Session["CantidadUsuariosAdmin"] = (int)Session["CantidadUsuariosAdmin"] + 1;
            }


            txtEdadUsuario.Text = "";
            txtNombreUsuario.Text = "";
            Response.Redirect("AdministrarUsuarios.aspx");
        }
    }
}