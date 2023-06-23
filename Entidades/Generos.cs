using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Generos
    {  //Propiedades
        private string IDGenero_GE;
        private string NombreGenero_GE;
        bool estado_GE;
        //constructor
        public Generos() { }
        public Generos(string iDGenero_GE, string nombreGenero_GE, bool estado_GE)
        {
            IDGenero_GE = iDGenero_GE;
            NombreGenero_GE = nombreGenero_GE;
            this.estado_GE = estado_GE;
        }

        public string IDGenero_GE1 { get => IDGenero_GE; set => IDGenero_GE = value; }
        public string NombreGenero_GE1 { get => NombreGenero_GE; set => NombreGenero_GE = value; }
        public bool Estado_GE { get => estado_GE; set => estado_GE = value; }
    }
}