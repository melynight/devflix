using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paises
    {
        //Propiedades
        string IDPais_PA;
        string Nombre_PA;
        bool estado_PA;

        //constructor
        public Paises()
        {
        }

        public Paises(string iDPais_PA, string nombre_PA, bool estado_PA)
        {
            IDPais_PA = iDPais_PA;
            Nombre_PA = nombre_PA;
            this.estado_PA = estado_PA;
        }

        public string IDPais_PA1 { get => IDPais_PA; set => IDPais_PA = value; }
        public string Nombre_PA1 { get => Nombre_PA; set => Nombre_PA = value; }
        public bool Estado_PA { get => estado_PA; set => estado_PA = value; }
    }
}