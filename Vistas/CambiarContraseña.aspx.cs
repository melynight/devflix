using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioCuenta negCue = new NegocioCuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Configuraciones.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool Exitoso = false;
            Cuenta cuenta = (Cuenta)Session["Cuenta"];
            if (txtContraseniaActual.Text == cuenta.GetClave_Cu())
            {
                Exitoso = negCue.CambiarContrasenia(cuenta.GetIDCuenta(),txtNewPassword.Text);
                if(Exitoso)
                {
                    int IDadmin = (int)Session["IDAdmin"];
                    Session["Cuenta"] = negCue.GetByID(IDadmin);
                    Response.Redirect("Configuraciones.aspx");
                }
            }
        }
    }
}