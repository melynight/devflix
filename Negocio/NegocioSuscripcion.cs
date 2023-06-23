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
    public class NegocioSuscripcion
    {
        public DataTable getTabla()
        {
            DaoSuscripcion dao = new DaoSuscripcion();
            return dao.GetTablaSuscripcion();
        }

        public Suscripcion Get(int cod)
        {
            DaoSuscripcion dao = new DaoSuscripcion();
            Suscripcion sus = new Suscripcion();
            sus.CodSus_Sus1 = cod;
            return dao.GetSuscripcion(sus);
        }

        public bool EliminarSuscripcion(int cod)
        {
            DaoSuscripcion dao = new DaoSuscripcion();
            Suscripcion sus = new Suscripcion();
            sus.CodSus_Sus1 = cod;
            int op = dao.EliminarSuscripcion(sus);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool agregarSuscripcion(int codSus)
        {
            int cantFilas = 0;
            Suscripcion sus = new Suscripcion();
            sus.CodSus_Sus1 = codSus;
            DaoSuscripcion dao = new DaoSuscripcion();
            if (dao.ExisteSuscripcion(sus) == false)
            {
                cantFilas = dao.agregarSuscripcion(sus);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
    }
}
