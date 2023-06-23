using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Facturacion
    {
        int IDFacturacion;
        int IDCuenta_F;
        int CodSus_F;
        DateTime Fecha_F;
        decimal Importe_F;
        bool Estado_F;
        public Facturacion()
        {

        }

        public Facturacion(int iDFacturacion, int iDCuenta_F, int codSus_F, DateTime fecha_F, decimal importe_F, bool estado_F)
        {
            IDFacturacion = iDFacturacion;
            IDCuenta_F = iDCuenta_F;
            CodSus_F = codSus_F;
            Fecha_F = fecha_F;
            Importe_F = importe_F;
            Estado_F = estado_F;
        }

        public int IDFacturacion1 { get => IDFacturacion; set => IDFacturacion = value; }
        public int IDCuenta_F1 { get => IDCuenta_F; set => IDCuenta_F = value; }
        public int CodSus_F1 { get => CodSus_F; set => CodSus_F = value; }
        public DateTime Fecha_F1 { get => Fecha_F; set => Fecha_F = value; }
        public decimal Importe_F1 { get => Importe_F; set => Importe_F = value; }
        public bool Estado_F1 { get => Estado_F; set => Estado_F = value; }
    }
}
