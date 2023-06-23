using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoSuscripcion
    {
        string CodTipo_Ts; //10
        string Nombre_Ts; //20
        decimal Precio_Ts;
        string Beneficios_Ts; //200
        int CantUsuarios_Ts;
        Boolean Estado_Ts;

        public TipoSuscripcion() { }

        public TipoSuscripcion(string codTipo_Ts, string nombre_Ts, decimal precio_Ts, string beneficios_Ts, int cantUsuarios_Ts, bool estado_Ts)
        {
            this.CodTipo_Ts1 = codTipo_Ts;
            this.Nombre_Ts1 = nombre_Ts;
            this.Precio_Ts1 = precio_Ts;
            this.Beneficios_Ts1 = beneficios_Ts;
            this.CantUsuarios_Ts1 = cantUsuarios_Ts;
            this.Estado_Ts1 = estado_Ts;
        }

        public string CodTipo_Ts1 { get => CodTipo_Ts; set => CodTipo_Ts = value; }
        public string Nombre_Ts1 { get => Nombre_Ts; set => Nombre_Ts = value; }
        public decimal Precio_Ts1 { get => Precio_Ts; set => Precio_Ts = value; }
        public string Beneficios_Ts1 { get => Beneficios_Ts; set => Beneficios_Ts = value; }
        public int CantUsuarios_Ts1 { get => CantUsuarios_Ts; set => CantUsuarios_Ts = value; }
        public bool Estado_Ts1 { get => Estado_Ts; set => Estado_Ts = value; }
    }
}
