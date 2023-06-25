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
            DataTable tabla = ds.ObtenerTabla("Favoritos", "select * from Favoritos as f inner join Catalogos as c on c.IDContenido_Cat = f.IDContenido_F where f.IDContenido_F  = '" + favorito.IDContenido_F1.IDContenido_Cat1 + "' and f.ID_cuenta = " + favorito.IDCuenta_F1.GetIDCuenta());
           
            Cuenta cuenta = new Cuenta();
            Catalogo catalogo = new Catalogo();
            
            catalogo.IDContenido_Cat1 = Convert.ToString(tabla.Rows[0][0].ToString());
            catalogo.TituloContenido_Cat1 = Convert.ToString(tabla.Rows[0][9].ToString());
            cuenta.SetIDCuenta(Convert.ToInt32(tabla.Rows[0][1].ToString()));

            favorito.IDContenido_F1 = catalogo;
            favorito.IDCuenta_F1 = cuenta;

            return favorito;
        }

        public Boolean ExisteFavorito(Favoritos favorito)
        {
            string consulta = "select * from Favoritos as f where f.IDContenido_F = '" + favorito.IDContenido_F1.IDContenido_Cat1 + "' and f.ID_cuenta = " + favorito.IDCuenta_F1.GetIDCuenta();            
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
            sqlParametros.Value = favorito.IDContenido_F1.IDContenido_Cat1;
            sqlParametros = comando.Parameters.Add("@ID_cuenta", SqlDbType.Int);
            sqlParametros.Value = favorito.IDCuenta_F1.GetIDCuenta();
        }

        private void ArmarParametrosFavorito(ref SqlCommand comando, Favoritos favorito)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDContenido_F", SqlDbType.Char);
            sqlParametros.Value = favorito.IDContenido_F1.IDContenido_Cat1;
            sqlParametros = comando.Parameters.Add("@ID_cuenta", SqlDbType.Int);
            sqlParametros.Value = favorito.IDCuenta_F1.GetIDCuenta();
        }
        public int EliminarFavorito(Favoritos favorito)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosFavoritoEliminar(ref comando, favorito);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarFavorito");
        }
    }
}