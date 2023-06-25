using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Favoritos
    {
        //Propiedades
        Catalogo IDContenido_F;
        Cuenta IDCuenta_F;

        public Catalogo IDContenido_F1 { get => IDContenido_F; set => IDContenido_F = value; }
        public Cuenta IDCuenta_F1 { get => IDCuenta_F; set => IDCuenta_F = value; }

        //constructor
        public Favoritos()
        {

        }

        public Favoritos(Catalogo iDContenido_F, Cuenta iDCuenta_F)
        {
            IDContenido_F = iDContenido_F;
            IDCuenta_F = iDCuenta_F;
        }
    }
}