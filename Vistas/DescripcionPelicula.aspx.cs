using System;
using System.Web.UI.HtmlControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class DescripcionPelicula : System.Web.UI.Page
    {
        private Cuenta cuenta = new Cuenta();
        private Favoritos favoritos = new Favoritos();
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
            }
        }

        public void BtnFavoritos_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            NegocioFavorito negFavorito = new NegocioFavorito();
            NegocioCatalogo negCatalogo = new NegocioCatalogo();
            Catalogo catalogo = negCatalogo.Get(id);

            negFavorito.agregarFavorito(catalogo.IDContenido_Cat1, cuenta.GetIDCuenta());

            lblSeAgrego.Text = "Se agrego a favoritos";
        }

        //TO DO FUNCIONALIDAD SORPRENDEME
        /* if (!string.private IsNullOrEmpty(id))

         {
             // se busca en la base de datos la pelicula por id
             //lblRandomNumber.Text = id;
         }
         // si no lo encuentra o no se especifico el parametro
         else
         {
             // se carga una pelicula random
             private RandomNumberGenerator rng = new RandomNumberGenerator();

     private int randomValue = rng.GenerateRandomNumber(1, 18);
     //lblRandomNumber.Text = randomValue.ToString();

           public class RandomNumberGenerator
    {
        private static Random random = new Random();

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("El valor mínimo debe ser menor o igual al valor máximo.");
            }

            return random.Next(minValue, maxValue + 1);
        }
    }
 }*/
    }
}