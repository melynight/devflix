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
    public class NegocioPais
    {
        public DataTable getTabla()
        {
            DaoPaises dao = new DaoPaises();
            return dao.getTablaPaises();
        }

        public Paises Get(string id)
        {
            DaoPaises dao = new DaoPaises();
            Paises pais = new Paises();
            pais.IDPais_PA1 = id;
            return dao.GetPais(pais);
        }

        public bool EliminarPais(string id)
        {
            DaoPaises dao = new DaoPaises();
            Paises pais = new Paises();
            pais.Nombre_PA1 = id;
            int op = dao.EliminarPais(pais);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool agregarPais(string codPais,string Nombre_PA)
        {
            int cantFilas = 0;
            Paises pais = new Paises();
            pais.Nombre_PA1 = Nombre_PA;
            pais.IDPais_PA1 = codPais;
            DaoPaises dao = new DaoPaises();
            if (dao.existePais(pais) == false)
            {
                cantFilas = dao.agregarPais(pais);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
    }
}