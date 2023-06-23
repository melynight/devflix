using System;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;


namespace Vistas
{
    public partial class Configuraciones : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioCuenta nCuenta = new NegocioCuenta();
        public HtmlGenericControl menu;
        protected void Page_Load(object sender, EventArgs e)
        {
           ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
           cuenta = (Cuenta)Session["Cuenta"];
           menu = (HtmlGenericControl)FindControl("itemsConfiguracion");
            lblMensajeError.Text = "";
           

            if (!IsPostBack)
            {
                lblUserName.Text = cuenta.GetNombre_Cu();
                menu.Visible = false;

            }

                lblUserName.Text = cuenta.GetNombre_Cu();
                menu.Visible = false;
            

           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = "";
            if (nCuenta.ValidarPINS(cuenta, txtPin.Text))
            {
                
                menu.Visible = true;
            }
            else
            {
                menu.Visible = false;
                lblMensajeError.Text = "El pin ingresado no es correcto o no tiene permisos";
            }
            txtPin.Text = "";
        }
    }
}