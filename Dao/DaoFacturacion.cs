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
    public class DaoFacturacion
    {
        private AccesoDatos ds = new AccesoDatos();

        public Facturacion GetFacturacion(Facturacion facturacion)
        {
            DataTable tabla = ds.ObtenerTabla("Facturacion", "Select * from Facturacion as f where IDFacturacion ='" + facturacion.IDFacturacion1 + "'");
            facturacion.IDFacturacion1 = (Convert.ToInt32(tabla.Rows[0][0].ToString()));
            facturacion.IDCuenta_F1 = (Convert.ToInt32(tabla.Rows[0][1].ToString()));
            facturacion.CodSus_F1 = (Convert.ToInt32(tabla.Rows[0][2].ToString()));
            facturacion.Fecha_F1 = (Convert.ToDateTime(tabla.Rows[0][3].ToString()));

            facturacion.Importe_F1 = (Convert.ToDecimal(tabla.Rows[0][4].ToString()));
            facturacion.Estado_F1 = (Convert.ToBoolean(tabla.Rows[0][5].ToString()));
            return facturacion;
        }

        public Boolean ExisteFacturacion(Facturacion facturacion)
        {
            string consulta = "select * from Facturacion as f  where  IDFacturacion='" + facturacion.IDFacturacion1 + "'";
            return ds.existe(consulta);
        }

        public DataTable GetTablaFacturacion(int ID)
        {
            DataTable tabla = ds.ObtenerTabla("Facturacion", "select * from Suscripciones as s inner join Facturacion as f on s.CodSus_Sus = f.CodSus_F " +
                "WHERE f.IDCuenta_F= " +
                ID+ "");
            return tabla;
        }

        public DataTable GetTablaFiltroFecha(DateTime desde, DateTime hasta, int id)
        {
            DataTable tabla = ds.ObtenerTabla("Facturacion", "select * from Suscripciones as s inner join Facturacion as f on s.CodSus_Sus = f.CodSus_F " +
                "where f.Fecha_F >= '" + desde + "' AND f.Fecha_F <= '" + hasta + "'" + " and " + "f.IDCuenta_F = " + id+"");
            return tabla;
        }

        public void ArmarParametrosFacturacionAgregar(ref SqlCommand comando, Facturacion facturacion)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDFacturacion", SqlDbType.Int);
            sqlParametros = comando.Parameters.Add("@IDCuenta_F"   , SqlDbType.Int);
            sqlParametros = comando.Parameters.Add("@CodSus_F"     , SqlDbType.Int);
            sqlParametros = comando.Parameters.Add("@Fecha_F"      , SqlDbType.Date);
            sqlParametros = comando.Parameters.Add("@Importe_F"    , SqlDbType.Decimal);
            sqlParametros = comando.Parameters.Add("@Estado_F"     , SqlDbType.Bit);
            sqlParametros.Value = facturacion.IDFacturacion1;
        }
        public int AgregarFacturacion(Facturacion facturacion)
        {
            facturacion.IDFacturacion1 = (ds.ObtenerMaximo("Select max(IDFacturacion) from Facturacion as f") + 1);
            SqlCommand comando = new SqlCommand();
            ArmarParametrosFacturacionAgregar(ref comando, facturacion);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarFacturacion");
        }
        private void ArmarParametrosFacturacionEliminar(ref SqlCommand comando, Facturacion facturacion)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDFacturacion", SqlDbType.Int);
            sqlParametros.Value = facturacion.IDFacturacion1;
        }

        public int EliminarFacturacion(Facturacion facturacion)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosFacturacionEliminar(ref comando, facturacion);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarFacturacion");
        }

       

    }
}
