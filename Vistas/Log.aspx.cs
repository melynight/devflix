using System;

namespace Vistas
{
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ingreso.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}