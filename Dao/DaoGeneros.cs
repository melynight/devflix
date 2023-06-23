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
    public class DaoGeneros
    {
        private AccesoDatos ds = new AccesoDatos();

        public Generos Getgenero(Generos genero)
        {
            DataTable tabla = ds.ObtenerTabla("generos", "Select *from Generos where NombreGenero_Ge ='" + genero.NombreGenero_GE1 + "'");
            genero.NombreGenero_GE1 = (tabla.Rows[0][1].ToString());

            return genero;
        }

        public Boolean existeGenero(Generos genero)
        {
            string consulta = "select *from Generos where NombreGenero_Ge ='" + genero.NombreGenero_GE1 + "'";
            return ds.existe(consulta);
        }

        public DataTable getTablaGeneros()
        {
            DataTable tabla = ds.ObtenerTabla("Generos", "Select * from Generos");
            return tabla;
        }

        public int agregarGenero(Generos genero)
        {
            
            SqlCommand comando = new SqlCommand();
            armarParametrosGeneroAgregar(ref comando, genero);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarGenero");
        }

        public int EliminarGenero(Generos genero)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosGeneroEliminar(ref comando, genero);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarGenero");
        }

        private void ArmarParametrosGeneroEliminar(ref SqlCommand comando, Generos genero)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@IDGenero_Ge", SqlDbType.Char);
            sqlParametros.Value = genero.IDGenero_GE1;
            sqlParametros = comando.Parameters.Add("@NombreGenero_GE", SqlDbType.VarChar);
            sqlParametros.Value = genero.NombreGenero_GE1;
        }

        public void armarParametrosGeneroAgregar(ref SqlCommand comando, Generos genero)
        {
            SqlParameter sqlParametros = new SqlParameter();
            sqlParametros = comando.Parameters.Add("@NombreGenero_Ge", SqlDbType.VarChar);
            sqlParametros.Value = genero.NombreGenero_GE1;
            sqlParametros = comando.Parameters.Add("@IDGenero_Ge", SqlDbType.Char);
            sqlParametros.Value = genero.IDGenero_GE1;
        }
    }
}