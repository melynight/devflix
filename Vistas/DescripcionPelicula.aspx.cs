using System;
using System.Web.UI.HtmlControls;
using Entidades;
using Negocio;
using System.Net;

namespace Vistas
{
    public partial class DescripcionPelicula : System.Web.UI.Page
    {
        private Cuenta cuenta = new Cuenta();
        private NegocioCatalogo negCatalogo = new NegocioCatalogo();

        protected void Page_Load(object sender, EventArgs e)
        {    // cargar el contenido que se va a mostrar
            // si existe parámetro id se busca ese id
            cuenta = (Cuenta)Session["Cuenta"];
            var id = Request["id"];

            if (!IsPostBack)

                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();

            Catalogo catalogo = negCatalogo.Get(id);

            if (Request["id"] != null) //catalogo
            {
                var tituloClean = catalogo.TituloContenido_Cat1.Replace(Environment.NewLine, "").Replace("\n", "").Replace("\r", "");

                if (!string.IsNullOrWhiteSpace(tituloClean))
                    titulo.Text = tituloClean + " | " + titulo.Text;

                lblTitulo.Text = tituloClean;
                lblDuracion.Text = negCatalogo.getDescripcionDuracion(catalogo.Duracion_Cat1);
                lblSinopsis.Text = catalogo.Sinopsis_Cat1;

                trailer.Attributes.Add("src", catalogo.URLVideo_Cat1.Replace("watch?v=", "embed/"));

                // rellena la estrellita si esta marcado como favorito
                if (new NegocioFavorito().ExisteFavorito(catalogo.IDContenido_Cat1, cuenta.GetIDCuenta()))
                    BtnFavoritos.CssClass = "filled";
            }
            else
            {
                string ID;

                ID = negCatalogo.IDCatalogoRandom();

                catalogo = negCatalogo.Get(ID);
                var tituloClean = catalogo.TituloContenido_Cat1.Replace(Environment.NewLine, "").Replace("\n", "").Replace("\r", "");

                if (!string.IsNullOrWhiteSpace(tituloClean))
                    titulo.Text = tituloClean + " | " + titulo.Text;

                lblTitulo.Text = tituloClean;
                lblDuracion.Text = negCatalogo.getDescripcionDuracion(catalogo.Duracion_Cat1);
                lblSinopsis.Text = catalogo.Sinopsis_Cat1;

                trailer.Attributes.Add("src", catalogo.URLVideo_Cat1.Replace("watch?v=", "embed/"));

                // rellena la estrellita si esta marcado como favorito
                if (new NegocioFavorito().ExisteFavorito(catalogo.IDContenido_Cat1, cuenta.GetIDCuenta()))
                    BtnFavoritos.CssClass = "filled";
            }
        }

        protected void BtnFavoritos_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            NegocioFavorito negFavorito = new NegocioFavorito();
            NegocioCatalogo negCatalogo = new NegocioCatalogo();
            Catalogo catalogo = negCatalogo.Get(id);

            var agregadoAFav = negFavorito.MarcarFavorito(catalogo.IDContenido_Cat1, cuenta.GetIDCuenta());

            if (agregadoAFav)
                BtnFavoritos.CssClass = "filled";
            else
                BtnFavoritos.CssClass = "";
        }

           protected void BtnSorprendeme_Click(object sender, EventArgs e)
           {
               
           }
    }
}