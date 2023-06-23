using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioFacturacion
    {
        public DataTable GetTabla(int ID)
        {
            DaoFacturacion dao = new DaoFacturacion();
            return dao.GetTablaFacturacion(ID);
        }

        public DataTable GetTablaFecha(string desde, string hasta, int ID)
        {
            DaoFacturacion dao = new DaoFacturacion();
            return dao.GetTablaFiltroFecha(desde, hasta, ID);
        }

        public Facturacion Get(int id)
        {
            DaoFacturacion dao = new DaoFacturacion();
            Facturacion fac = new Facturacion();
            fac.IDFacturacion1=id;
            return dao.GetFacturacion(fac);
        }

        public bool EliminarFacturacion(int id)
        {
            DaoFacturacion dao = new DaoFacturacion();
            Facturacion fac = new Facturacion();
            fac.IDFacturacion1= id;
            int op = dao.EliminarFacturacion(fac);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool AgregarFacturacion(Facturacion fac)
        {
            int cantFilas = 0;
            DaoFacturacion dao = new DaoFacturacion();
            if (dao.ExisteFacturacion(fac) == false)
            {
                cantFilas = dao.AgregarFacturacion(fac);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

    }
}
