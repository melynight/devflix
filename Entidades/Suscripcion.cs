using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suscripcion
    {
		int CodSus_Sus;
		TipoSuscripcion CodTipo_Sus; //10
		decimal total_Sus;
		DateTime fechaCompra_Sus;
		Boolean estado_Sus;

        public Suscripcion() { }

        public Suscripcion(int codSus_Sus, TipoSuscripcion codTipo_Sus, decimal total_Sus, DateTime fechaCompra_Sus, bool estado_Sus)
        {
            CodSus_Sus = codSus_Sus;
            CodTipo_Sus = codTipo_Sus;
            this.total_Sus = total_Sus;
            this.fechaCompra_Sus = fechaCompra_Sus;
            this.estado_Sus = estado_Sus;
        }

        public int CodSus_Sus1 { get => CodSus_Sus; set => CodSus_Sus = value; }
        public TipoSuscripcion CodTipo_Sus1 { get => CodTipo_Sus; set => CodTipo_Sus = value; }
        public decimal Total_Sus { get => total_Sus; set => total_Sus = value; }
        public DateTime FechaCompra_Sus { get => fechaCompra_Sus; set => fechaCompra_Sus = value; }
        public bool Estado_Sus { get => estado_Sus; set => estado_Sus = value; }
    }
}
