using System;
using System.Web.UI;
using System.Data;
using Entidades;
using Negocio;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Home : System.Web.UI.Page
    {
        private NegocioCatalogo ncatalogo = new NegocioCatalogo();
        private NegocioCuenta ncuenta = new NegocioCuenta();
        private Cuenta cuenta = new Cuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cuenta = (Cuenta)Session["Cuenta"];
                Session["EdadUsuario"] = cuenta.GetEdad_Cu();
                // DataTable tablaCatalogo = ncatalogo.getTablaContenidoXEdad(cuenta.GetEdad_Cu());
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();
            }
        }

        protected void imgbtnAdelante_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void lvCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void imgBtnPortada_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("/DescripcionPelicula.aspx?id=" + e.CommandArgument);
        }
    }
}