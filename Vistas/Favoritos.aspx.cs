using System;
using Entidades;
using Negocio;
namespace Vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            cuenta = (Cuenta)Session["Cuenta"];
            if (!IsPostBack)
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();
        }
    }
}