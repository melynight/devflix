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
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                
                cuenta = (Cuenta)Session["Cuenta"];
                Session["EdadUsuario"] = cuenta.GetEdad_Cu();
                MostrarCatalogo();
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();
            }
            MostrarCatalogo();
        }
   
        public void MostrarCatalogo()
        {
            DataTable tablaCatalogo = ncatalogo.getTablaContenidoXEdad((int)Session["EdadUsuario"]);
            lvCatalogo.DataSource = tablaCatalogo;
            lvCatalogo.DataBind();
        }

        public void MostrarContenidoXNombre(string busqueda)
        {
            DataTable catalogoBusqueda = ncatalogo.getTablaContenidoXEdadXBusqueda((int)Session["EdadUsuario"], busqueda);
            lvCatalogo.DataSource = catalogoBusqueda;
            lvCatalogo.DataBind();
            
        }

        protected void imgBtnPortada_Command(object sender, CommandEventArgs e)
        {
            Session["ID"] = e.CommandArgument;
            Response.Redirect("/DescripcionPelicula.aspx?id=");
        }

        protected void imgBtnFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            string busqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(txtBusqueda.Text))
            {
                MostrarCatalogo();
                return;
            }

            MostrarContenidoXNombre(busqueda);
            txtBusqueda.Text = "";
        }
    }
}