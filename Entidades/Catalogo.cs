using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Catalogo
    {
        private string IDContenido_Cat;
        private Generos IDGenero_Cat;
        private TipoSuscripcion CodTipo_Cat; 
        private string Sinopsis_Cat;
        private int Duracion_Cat;
        private string URLPortada_Cat;
        private string TituloContenido_Cat;
        private int Season_Cat;
        private string URLVideo_Cat;
        private int Clasif_Edad_Cat;
        private Boolean estado;

        public Catalogo()
        { }

        public Catalogo(string iDContenido_Cat, Generos iDGenero_Cat, TipoSuscripcion codTipo_Cat, string sinopsis_Cat, 
            int duracion_Cat, string uRLPortada_Cat, string tituloContenido_Cat, int season_Cat, string uRLVideo_Cat, int clasif_Edad_Cat, bool estado)
        {
            IDContenido_Cat = iDContenido_Cat;
            IDGenero_Cat = iDGenero_Cat;
            CodTipo_Cat2 = codTipo_Cat;
            Sinopsis_Cat = sinopsis_Cat;
            Duracion_Cat = duracion_Cat;
            URLPortada_Cat = uRLPortada_Cat;
            TituloContenido_Cat = tituloContenido_Cat;
            Season_Cat = season_Cat;
            URLVideo_Cat = uRLVideo_Cat;
            Clasif_Edad_Cat = clasif_Edad_Cat;
            this.estado = estado;
        }

        public string IDContenido_Cat1 { get => IDContenido_Cat; set => IDContenido_Cat = value; }
        public Generos IDGenero_Cat2 { get => IDGenero_Cat; set => IDGenero_Cat = value; }
        public TipoSuscripcion CodTipo_Cat2 { get => CodTipo_Cat; set => CodTipo_Cat = value; }
        public string Sinopsis_Cat1 { get => Sinopsis_Cat; set => Sinopsis_Cat = value; }
        public int Duracion_Cat1 { get => Duracion_Cat; set => Duracion_Cat = value; }
        public string URLPortada_Cat1 { get => URLPortada_Cat; set => URLPortada_Cat = value; }
        public string TituloContenido_Cat1 { get => TituloContenido_Cat; set => TituloContenido_Cat = value; }
        public int Season_Cat1 { get => Season_Cat; set => Season_Cat = value; }
        public string URLVideo_Cat1 { get => URLVideo_Cat; set => URLVideo_Cat = value; }
        public int Clasif_Edad_Cat1 { get => Clasif_Edad_Cat; set => Clasif_Edad_Cat = value; }
        public bool Estado { get => estado; set => estado = value; }
        
    }
}