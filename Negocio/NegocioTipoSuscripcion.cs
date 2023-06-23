using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegocioTipoSuscripcion
    {
        public DataTable getTabla()
        {
            DaoTipoSuscripcion dao = new DaoTipoSuscripcion();
            return dao.GetTablaTipoSuscripcion();
        }

        public TipoSuscripcion Get(string cod)
        {
            DaoTipoSuscripcion dao = new DaoTipoSuscripcion();
            TipoSuscripcion tsus = new TipoSuscripcion();
            tsus.CodTipo_Ts1 = cod;
            return dao.GetTipoSuscripcion(tsus);
        }
        public TipoSuscripcion GetxNombre(string nombre)
        {
            DaoTipoSuscripcion dao = new DaoTipoSuscripcion();
            TipoSuscripcion tsus = new TipoSuscripcion();
            tsus.Nombre_Ts1 = nombre;
            return dao.GetTipoSuscripcionPorNombre(tsus);
        }



        public bool EliminarTipoSuscripcion(string cod)
        {
            DaoTipoSuscripcion dao = new DaoTipoSuscripcion();
            TipoSuscripcion tsus = new TipoSuscripcion();
            tsus.CodTipo_Ts1 = cod;
            int op = dao.EliminarTipoSuscripcion(tsus);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool agregarTipoSuscripcion(string codTipo)
        {
            int cantFilas = 0;
            TipoSuscripcion tsus = new TipoSuscripcion();
            tsus.CodTipo_Ts1 = codTipo;
            DaoTipoSuscripcion dao = new DaoTipoSuscripcion();
            if (dao.ExisteTipoSuscripcion(tsus) == false)
            {
                cantFilas = dao.agregarTipoSuscripcion(tsus);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
    }
}
