using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class DaoFavoritos
    {
        private AccesoDatos ds = new AccesoDatos();

        public Favoritos GetFavorito(Favoritos favorito)

        {
            DataTable tabla = ds.ObtenerTabla("Favoritos", "Select * from favoritos as f where f.IDContenido_F  = '" + favorito.IDContenido_F1 + "' and f.ID_cuenta = " + favorito.IDCuenta_F1);

            favorito.IDContenido_F1 = (tabla.Rows[0][0].ToString());
            favorito.IDCuenta_F1 = (Convert.ToInt32(tabla.Rows[0][1].ToString()));

            return favorito;
        }

        public Boolean ExisteFavorito(Favoritos favorito)
        {
            string consulta = "select *from Favoritos as f where f.IDContenido_F = '" + favorito.IDContenido_F1 + "' and f.ID_cuenta = " + favorito.IDCuenta_F1;
            return ds.existe(consulta);
        }

        public DataTable getTablaFavorito()
        {
            DataTable tabla = ds.ObtenerTabla("Favoritos", "Select * from Favoritos");
            return tabla;
        }

        public bool MarcarFavorito(Favoritos favorito, bool eliminar)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosFavorito(ref comando, favorito);
            return ds.EjecutarProcedimientoAlmacenado(comando, (eliminar ? "spEliminarFavorito" : "spAgregarFavorito")) > 0;
            // if ternario
            // condicion ? true : false;
            // ej:
            // 1 > 0 ? "algo" : "";
        }

        private void ArmarParametrosFavoritoEliminar(ref SqlCommand comando, Favoritos favorito)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDContenido_F", SqlDbType.Char);
            sqlParametros.Value = favorito.IDContenido_F1;
            sqlParametros = comando.Parameters.Add("@ID_cuenta", SqlDbType.Int);
            sqlParametros.Value = favorito.IDCuenta_F1;
        }

            private void ArmarParametrosFavorito(ref SqlCommand comando, Favoritos favorito)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDContenido_F", SqlDbType.VarChar);
            sqlParametros.Value = favorito.IDContenido_F1;
            sqlParametros = comando.Parameters.Add("@ID_cuenta", SqlDbType.Int);
            sqlParametros.Value = favorito.IDCuenta_F1;
        }
        public int EliminarFavorito(Favoritos favorito)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosFavoritoEliminar(ref comando, favorito);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarFavorito");
        }
    }
}