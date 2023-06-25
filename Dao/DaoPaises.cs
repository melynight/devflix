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
    public class DaoPaises
    {
        private AccesoDatos ds = new AccesoDatos();

        public Paises GetPais(Paises pais)
        {
            DataTable tabla = ds.ObtenerTabla("Paises", "Select * from Paises as p where p.IDPais_PA ='" + pais.IDPais_PA1 + "'");
            pais.IDPais_PA1 = (Convert.ToString(tabla.Rows[0][0].ToString()));
            pais.Nombre_PA1 = (tabla.Rows[0][1].ToString());

            return pais;
        }

        public Boolean existePais(Paises pais)
        {
            string consulta = "select * from paises as p where p.NombrePais_PA ='" + pais.Nombre_PA1 + "'";
            return ds.existe(consulta);
        }

        public DataTable getTablaPaises()
        {
            DataTable tabla = ds.ObtenerTabla("Paises", "Select * from Paises");
            return tabla;
        }

        public int agregarPais(Paises pais)
        {
            
            SqlCommand comando = new SqlCommand();
            armarParametrosPaisAgregar(ref comando, pais);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarPais");
        }

        public int EliminarPais(Paises pais)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPaisEliminar(ref comando, pais);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarPais");
        }

        private void ArmarParametrosPaisEliminar(ref SqlCommand comando, Paises pais)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@Nombre_PA", SqlDbType.Int);
            sqlParametros.Value = pais.Nombre_PA1;
        }

        public void armarParametrosPaisAgregar(ref SqlCommand comando, Paises pais)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDPais_PA", SqlDbType.Char);
            sqlParametros.Value = pais.IDPais_PA1;
            sqlParametros = comando.Parameters.Add("@Nombre_Pa", SqlDbType.Int);
            sqlParametros.Value = pais.Nombre_PA1;
        }
    }
}