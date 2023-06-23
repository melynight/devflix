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
            DataTable tabla = ds.ObtenerTabla("Favoritos", "Select *from favoritos where IDContenido_F  = '" + favorito.IDContenido_F1 + "' and ID_cuenta = " + favorito.IDCuenta_F1);

            favorito.IDContenido_F1 = (tabla.Rows[0][0].ToString());
            favorito.IDCuenta_F1 = (Convert.ToInt32(tabla.Rows[0][1].ToString()));

            return favorito;
        }

        public Boolean existeFavorito(Favoritos favorito)
        {
            string consulta = "select *from Favoritos where IDContenido_F = '" + favorito.IDContenido_F1 + "' and ID_cuenta = " + favorito.IDCuenta_F1;
            return ds.existe(consulta);
        }

        public DataTable getTablaFavorito()
        {
            DataTable tabla = ds.ObtenerTabla("Favoritos", "Select * from Favoritos");
            return tabla;
        }

        public int agregarFavorito(string IdContenido, int idCuenta)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosFavoritoAgregar(ref comando, IdContenido, idCuenta);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarFavorito");
        }

        public int EliminarFavorito(Favoritos favorito)
        {
            // favorito.IDContenido_F1=(ds.ObtenerMaximo("Select count(*) from Favoritos where idCuenta_F") + 1);//-------------averiguar como hacer para eliminar un favorito.-

            SqlCommand comando = new SqlCommand();
            ArmarParametrosFavoritoEliminar(ref comando, favorito);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarFavorito");
        }

        private void ArmarParametrosFavoritoEliminar(ref SqlCommand comando, Favoritos favorito)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDContenido", SqlDbType.VarChar);
            sqlParametros.Value = favorito.IDContenido_F1;
            sqlParametros = comando.Parameters.Add("@ID_cuenta", SqlDbType.Int);
            sqlParametros.Value = favorito.IDCuenta_F1;
        }

        public void armarParametrosFavoritoAgregar(ref SqlCommand comando, string IdContenido, int idCuenta)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDContenido_F", SqlDbType.VarChar);
            sqlParametros.Value = IdContenido;
            sqlParametros = comando.Parameters.Add("@ID_cuenta", SqlDbType.Int);
            sqlParametros.Value = idCuenta;
        }
    }
}