using System;
using System.Data;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
namespace Vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioFavorito nfav = new NegocioFavorito();

        protected void Page_Load(object sender, EventArgs e)
        {
            cuenta = (Cuenta)Session["Cuenta"];
            if (!IsPostBack)
            {
                lblUserName.Text = cuenta.GetNombre_Cu();
                Session["IDCuenta"] = cuenta.GetIDCuenta();
            }
            MostrarCatalogo();
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            string idCont = e.CommandArgument.ToString();
            if (e.CommandName == "eventoSeleccionar")
            {
                nfav.EliminarFavorito(idCont, cuenta.GetIDCuenta());
            }
            lvFavoritos.DataBind();
        }

        protected void imgbtnPortada_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccion")
            {
                Response.Redirect("/DescripcionPelicula.aspx?id=" + e.CommandArgument);
            }
        }

        public void MostrarCatalogo ()
        {
            string texto = txtBusqueda.Text;
            if (!string.IsNullOrWhiteSpace(texto))
            {
                lvFavoritos.DataSourceID = "filtroDataSource";
                lvFavoritos.DataBind();
            }
            else
            {
                lvFavoritos.DataSourceID = "FavoritosDataSource";
                lvFavoritos.DataBind();
            }
        }

        protected void imgBtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            MostrarCatalogo();
        }

        protected void lvFavoritos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var dataPager = lvFavoritos.FindControl("DataPager1") as DataPager;
            dataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            MostrarCatalogo();
        }
    }
}