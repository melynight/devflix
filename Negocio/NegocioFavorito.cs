using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioFavorito
    {
        public DataTable getTabla()
        {
            DaoFavoritos dao = new DaoFavoritos();
            return dao.getTablaFavorito();
        }

        public Favoritos Get(string id)
        {
            DaoFavoritos dao = new DaoFavoritos();
            Favoritos favorito = new Favoritos();
            favorito.IDContenido_F1 = id;
            return dao.GetFavorito(favorito);
        }

        public bool EliminarFavorito(string idContenido, int idCuenta)
        {
            DaoFavoritos dao = new DaoFavoritos();
            Favoritos favorito = new Favoritos();
            favorito.IDContenido_F1 = idContenido;
            favorito.IDCuenta_F1 = idCuenta;
            int op = dao.EliminarFavorito(favorito);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool agregarFavorito(string idContenido, int idCuenta)
        {
            int cantFilas = 0;
            Favoritos favorito = new Favoritos();
            favorito.IDContenido_F1 = idContenido;
            favorito.IDCuenta_F1 = idCuenta;
            DaoFavoritos dao = new DaoFavoritos();
            if (dao.existeFavorito(favorito) == false)
            {
                cantFilas = dao.agregarFavorito(idContenido, idCuenta);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
    }
}