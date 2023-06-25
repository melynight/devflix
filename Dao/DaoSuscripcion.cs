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
    public class DaoSuscripcion
    {
        AccesoDatos ds = new AccesoDatos();

        public Suscripcion GetSuscripcion(Suscripcion sus)
        {
            DataTable tabla = ds.ObtenerTabla("Suscripciones", "SELECT * FROM Suscripciones as s INNER JOIN TipoSuscripciones as ts ON ts.CodTipo_Ts=s.CodTipo_Sus WHERE s.CodSus_Sus=" + sus.CodSus_Sus1);

            TipoSuscripcion tipoSus = new TipoSuscripcion();


            tipoSus.CodTipo_Ts1 = tabla.Rows[0]["CodTipo_Ts"].ToString();
            tipoSus.Nombre_Ts1 = tabla.Rows[0]["Nombre_Ts"].ToString();
            tipoSus.Precio_Ts1 = Convert.ToDecimal(tabla.Rows[0]["Precio_Ts"]);
            tipoSus.Beneficios_Ts1 = tabla.Rows[0]["Beneficios_Ts"].ToString();
            tipoSus.CantUsuarios_Ts1 = Convert.ToInt32(tabla.Rows[0]["CantUsuarios_Ts"]);
            tipoSus.Estado_Ts1 = Convert.ToBoolean(tabla.Rows[0]["Estado_Ts"].ToString());
            

            sus.CodSus_Sus1 = (Convert.ToInt32(tabla.Rows[0][0].ToString()));
            sus.CodTipo_Sus1 = tipoSus;
            sus.Total_Sus = (Convert.ToDecimal(tabla.Rows[0][2].ToString()));
            sus.FechaCompra_Sus = (Convert.ToDateTime(tabla.Rows[0][3].ToString()));
            sus.Estado_Sus = (Convert.ToBoolean(tabla.Rows[0][4].ToString()));

            return sus;
        }

        public DataTable GetTablaSuscripcion()
        {
            DataTable tabla = ds.ObtenerTabla("Suscripciones", "SELECT * FROM Suscripciones");
            return tabla;
        }

        private void ArmarParametrosSuscripcionEliminar(ref SqlCommand Comando, Suscripcion sus)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CodSus", SqlDbType.Int);
            SqlParametros.Value = sus.CodSus_Sus1;
        }

        public int EliminarSuscripcion(Suscripcion sus)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosSuscripcionEliminar(ref comando, sus);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarSuscripcion");
        }

        public Boolean ExisteSuscripcion(Suscripcion sus)
        {
            String consulta = "SELECT * FROM Suscripciones as s WHERE s.CodSus_Sus=" + sus.CodSus_Sus1;
            return ds.existe(consulta);
        }

        private void ArmarParametrosSuscripcionAgregar(ref SqlCommand Comando, Suscripcion sus)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@CodTipo", SqlDbType.Int);
            SqlParametros.Value = sus.CodTipo_Sus1.CodTipo_Ts1;
            SqlParametros = Comando.Parameters.Add("@total", SqlDbType.Int);
            SqlParametros.Value = sus.Total_Sus;
            SqlParametros = Comando.Parameters.Add("@fechaCompra", SqlDbType.Date);
            SqlParametros.Value = sus.FechaCompra_Sus;
            SqlParametros = Comando.Parameters.Add("@estado", SqlDbType.Bit);
            SqlParametros.Value = sus.Estado_Sus;
        }

        public int agregarSuscripcion(Suscripcion sus)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosSuscripcionAgregar(ref comando, sus);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarSuscripcion");
        }
    }
}
