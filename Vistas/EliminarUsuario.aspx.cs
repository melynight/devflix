using System;
using Entidades;
using Negocio;


namespace Vistas
{
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioCuenta negEliminar = new NegocioCuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            Cuenta cuenta = (Cuenta)Session["cuenta"];
            if (!IsPostBack)
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Configuraciones.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Cuenta cuenta = (Cuenta)Session["cuenta"];

            bool EliminarExitoso = false;
            if (txtContraCuenta.Text == cuenta.GetClave_Cu())
            {
                EliminarExitoso = negEliminar.EliminarCuenta(cuenta.GetIDCuenta());
                Response.Redirect("Ingreso.aspx");
                
            }        
        }
    }
}