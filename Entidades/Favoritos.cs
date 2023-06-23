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
        public string IDContenido_F;

        public int IDCuenta_F;

        public string IDContenido_F1 { get => IDContenido_F; set => IDContenido_F = value; }
        public int IDCuenta_F1 { get => IDCuenta_F; set => IDCuenta_F = value; }

        //constructor
        public Favoritos()
        {
        }

        /*
        public string getIDContenido()
        {
            return IDContenido_F;
        }

        public void setIDContenido(string IDcontenido)
        {
            IDContenido_F = IDcontenido;
        }

        public int getIDCuenta()
        {
            return IDCuenta_F;
        }

        public void setIDCuenta(int ID_Cuenta)
        {
            IDCuenta_F = ID_Cuenta;
        }*/
    }
}