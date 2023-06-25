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
    public class DaoTipoSuscripcion
    {
        AccesoDatos ds = new AccesoDatos();

        public TipoSuscripcion GetTipoSuscripcion(TipoSuscripcion tsus)
        {
            DataTable tabla = ds.ObtenerTabla("TipoSuscripciones", "SELECT * FROM TipoSuscripciones as ts WHERE ts.CodTipo_Ts= '" + tsus.CodTipo_Ts1 + "'");

            tsus.CodTipo_Ts1 = tabla.Rows[0][0].ToString();
            tsus.Nombre_Ts1 = tabla.Rows[0][1].ToString();
            tsus.Precio_Ts1 = (Convert.ToDecimal(tabla.Rows[0][2].ToString()));
            tsus.Beneficios_Ts1 = tabla.Rows[0][3].ToString();
            tsus.CantUsuarios_Ts1 = (Convert.ToInt32(tabla.Rows[0][4].ToString()));
            tsus.Estado_Ts1 = (Convert.ToBoolean(tabla.Rows[0][5].ToString()));

            return tsus;
        }

        public TipoSuscripcion GetTipoSuscripcionPorNombre(TipoSuscripcion tsus)
        {
            DataTable tabla = ds.ObtenerTabla("TipoSuscripciones", "SELECT * FROM TipoSuscripciones as ts WHERE ts.Nombre_Ts= '" + tsus.Nombre_Ts1 + "'");

            tsus.CodTipo_Ts1 = tabla.Rows[0][0].ToString();
            tsus.Nombre_Ts1 = tabla.Rows[0][1].ToString();
            tsus.Precio_Ts1 = (Convert.ToDecimal(tabla.Rows[0][2].ToString()));
            tsus.Beneficios_Ts1 = tabla.Rows[0][3].ToString();
            tsus.CantUsuarios_Ts1 = (Convert.ToInt32(tabla.Rows[0][4].ToString()));
            tsus.Estado_Ts1 = (Convert.ToBoolean(tabla.Rows[0][5].ToString()));

            return tsus;
        }


        public DataTable GetTablaTipoSuscripcion()
        {
            DataTable tabla = ds.ObtenerTabla("TipoSuscripciones", "SELECT * FROM TipoSuscripciones");
            return tabla;
        }

        private void ArmarParametrosTipoSuscripcionEliminar(ref SqlCommand Comando, TipoSuscripcion tsus)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CodTipo", SqlDbType.Char);
            SqlParametros.Value = tsus.CodTipo_Ts1;
        }

        public int EliminarTipoSuscripcion(TipoSuscripcion tsus)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTipoSuscripcionEliminar(ref comando, tsus);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarTipoSuscripcion");
        }

        public Boolean ExisteTipoSuscripcion(TipoSuscripcion tsus)
        {
            String consulta = "SELECT * FROM TipoSuscripciones as ts WHERE ts.CodTipo_Ts= '" + tsus.CodTipo_Ts1 + "'";
            return ds.existe(consulta);
        }

        private void ArmarParametrosTipoSuscripcionAgregar(ref SqlCommand Comando, TipoSuscripcion tsus)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@CodTipo", SqlDbType.Char);
            SqlParametros.Value = tsus.CodTipo_Ts1;
            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            SqlParametros.Value = tsus.Nombre_Ts1;
            SqlParametros = Comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            SqlParametros.Value = tsus.Precio_Ts1;
            SqlParametros = Comando.Parameters.Add("@Beneficios", SqlDbType.VarChar);
            SqlParametros.Value = tsus.Beneficios_Ts1;
            SqlParametros = Comando.Parameters.Add("@CantUsuarios", SqlDbType.Int);
            SqlParametros.Value = tsus.CantUsuarios_Ts1;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = tsus.Estado_Ts1;
        }

        public int agregarTipoSuscripcion(TipoSuscripcion tsus)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTipoSuscripcionAgregar(ref comando, tsus);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarTipoSuscripcion");
        }
    }
}

