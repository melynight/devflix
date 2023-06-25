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
         NegocioCatalogo ncatalogo = new NegocioCatalogo();
         NegocioCuenta ncuenta = new NegocioCuenta();
         Cuenta cuenta = new Cuenta();
         Generos genero = new Generos();
         NegocioGenero nGenero = new NegocioGenero();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {

                cuenta = (Cuenta)Session["Cuenta"];
                Session["EdadUsuario"] = cuenta.GetEdad_Cu();
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();
                cargarGeneros();
            }

            
            MostrarCatalogo();
        }

        public void MostrarCatalogo()
        {
            DataTable tablaCatalogo = ncatalogo.getTablaContenido((int)Session["EdadUsuario"], txtBusqueda.Text, ddlGeneros.SelectedValue);
            lvCatalogo.DataSource = tablaCatalogo;
            lvCatalogo.DataBind();
        }

        public void cargarGeneros()
        {

            DataTable generos = nGenero.getTabla();

            foreach (DataRow dr in generos.Rows)
            {
                string IDGenero = dr["IDGenero_GE"].ToString();
                string nombreGenero = dr["NombreGenero_GE"].ToString();
                ListItem item = new ListItem(nombreGenero, IDGenero);
                ddlGeneros.Items.Add(item);
            }

            ddlGeneros.DataBind();
        }

        protected void imgBtnPortada_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccion")
            {
                Response.Redirect("/DescripcionPelicula.aspx?id=" + e.CommandArgument);
            }
        }

        protected void imgBtnFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            var dataPager = lvCatalogo.FindControl("DataPager1") as DataPager;
            if (dataPager != null)
            {
                dataPager.SetPageProperties(0, 9, false);
                
            }
            MostrarCatalogo();
        }

        protected void lvCatalogo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var dataPager = lvCatalogo.FindControl("DataPager1") as DataPager;
            dataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            MostrarCatalogo();
        }

        protected void btnFiltrarGenero_Click(object sender, EventArgs e)
        {
            MostrarCatalogo();
        }

        protected void lvCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}