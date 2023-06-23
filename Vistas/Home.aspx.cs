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
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();
            }
            MostrarCatalogo();
        }

        public void MostrarCatalogo()
        {
            DataTable tablaCatalogo = ncatalogo.getTablaContenido((int)Session["EdadUsuario"], txtBusqueda.Text);
            lvCatalogo.DataSource = tablaCatalogo;
            lvCatalogo.DataBind();
        }

        protected void imgBtnPortada_Command(object sender, CommandEventArgs e)
        {
            Session["ID"] = e.CommandArgument;
            Response.Redirect("/DescripcionPelicula.aspx?id=");
        }

        protected void imgBtnFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            var dataPager = lvCatalogo.FindControl("DataPager1") as DataPager;
            dataPager.SetPageProperties(0, 9, false);
            MostrarCatalogo();
        }

        protected void lvCatalogo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var dataPager = lvCatalogo.FindControl("DataPager1") as DataPager;
            dataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            MostrarCatalogo();
            Response.Redirect("/DescripcionPelicula.aspx?id=" + e.CommandArgument);
        }
    }
}