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
    public class DaoCatalogo
    {
        private AccesoDatos ds = new AccesoDatos();

        public Catalogo GetCatalogo(string idCatalogo)
        {
            DataTable tabla = ds.ObtenerTabla("Catalogos", "Select * from Catalogos as c inner join Generos as g on g.IDGenero_Ge = c.IDGenero_Cat inner join TipoSuscripciones as ts " +
                "on ts.CodTipo_Ts = c.CodTipo_Cat where c.IDContenido_Cat = '" + idCatalogo + "'");
        
            if (tabla.Rows.Count > 0)
            {
                Generos genero = new Generos()
                {
                    IDGenero_GE1 = tabla.Rows[0]["IDGenero_Ge"].ToString(),
                    NombreGenero_GE1 = tabla.Rows[0]["NombreGenero_Ge"].ToString(),
                    Estado_GE = Convert.ToBoolean(tabla.Rows[0]["estado_GE"].ToString())
                };

                TipoSuscripcion tipoSus = new TipoSuscripcion()
                {
                    CodTipo_Ts1 = tabla.Rows[0]["CodTipo_Ts"].ToString(),
                    Nombre_Ts1 = tabla.Rows[0]["Nombre_Ts"].ToString(),
                    Precio_Ts1 = Convert.ToDecimal(tabla.Rows[0]["Precio_Ts"]),
                    Beneficios_Ts1 = tabla.Rows[0]["Beneficios_Ts"].ToString(),
                    CantUsuarios_Ts1 = Convert.ToInt32(tabla.Rows[0]["CantUsuarios_Ts"]),
                    Estado_Ts1 = Convert.ToBoolean(tabla.Rows[0]["Estado_Ts"].ToString())
                };

                Catalogo catalogo = new Catalogo()
                {
                    IDContenido_Cat1 = tabla.Rows[0]["IDContenido_Cat"].ToString(),
                    IDGenero_Cat2 = genero,
                    CodTipo_Cat2 = tipoSus,
                    Sinopsis_Cat1 = tabla.Rows[0]["Sinopsis_Cat"].ToString(),
                    Duracion_Cat1 = Convert.ToInt32(tabla.Rows[0]["Duracion_Cat"].ToString()),
                    URLPortada_Cat1 = tabla.Rows[0]["URLPortada_Cat"].ToString(),
                    TituloContenido_Cat1 = tabla.Rows[0]["TituloContenido_Cat"].ToString(),
                    Season_Cat1 = Convert.ToInt32(tabla.Rows[0]["Season_Cat"].ToString()),
                    URLVideo_Cat1 = tabla.Rows[0]["URLVideo_Cat"].ToString(),
                    Clasif_Edad_Cat1 = (Convert.ToInt32(tabla.Rows[0]["Clasif_Edad_Cat"].ToString())),
                    Estado = Convert.ToBoolean(tabla.Rows[0]["Estado_Cat"].ToString())
                };

                return catalogo;
            }

            return null;
        }

        public DataTable GetTablaCatalogo(int edad = 0, string titulo = "", string genero= "")
        {
            int filtros = 0;
            string filtroEdad = "", filtroTitulo = "", filtroGenero= "";
            if (edad > 0)
            {
                // pasa por falso en caso de que sea la primer condicion
                filtroEdad = (filtros > 0 ? " and " : "") + " c.Clasif_Edad_Cat <= " + edad;
                filtros++;
            }

            if (!string.IsNullOrWhiteSpace(titulo))
            {// pasa por falso en caso de que sea la primer condicion
                filtroTitulo = (filtros > 0 ? " and " : "") + " c.TituloContenido_Cat LIKE '%" + titulo + "%'";
                filtros++;
            }
            if (genero != "--Seleccionar Género--" )
            {// pasa por falso en caso de que sea la primer condicion
                filtroGenero = (filtros > 0 ? "and " : "") + " c.IDGenero_Cat LIKE '" + genero + "'";
                filtros++;
            }

            DataTable tabla = ds.ObtenerTabla("Catalogos", "Select * from Catalogos as c" + (filtros == 0 ? "" : " where " + filtroEdad + filtroTitulo + filtroGenero));
            return tabla;
        }


        public Boolean ExisteCatalogo(Catalogo catalogo)
        {
            String consulta = "Select * from Catalogos as c where c.IDContenido_Cat= '" + catalogo.IDContenido_Cat1 + "'";
            return ds.existe(consulta);
        }

        public DataTable GetTablaCatalogo()
        {
            DataTable tabla = ds.ObtenerTabla("Catalogos", "Select * from Catalogos as c");
            return tabla;
        }

        private void ArmarParametrosCatalogoEliminar(ref SqlCommand Comando, Catalogo catalogo)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDContenido", SqlDbType.Int);
            SqlParametros.Value = catalogo.IDContenido_Cat1;
        }

        public int EliminarCatalogo(Catalogo catalogo)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCatalogoEliminar(ref comando, catalogo);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarCatalogo");
        }

        private void ArmarParametrosCatalogoAgregar(ref SqlCommand Comando, Catalogo catalogo)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDContenido_Cat", SqlDbType.Int);
            SqlParametros.Value = catalogo.IDContenido_Cat1;
            SqlParametros = Comando.Parameters.Add("@IDGenero_Cat", SqlDbType.Int);
            SqlParametros.Value = catalogo.IDGenero_Cat2;
            SqlParametros = Comando.Parameters.Add("@CodTipo_Cat", SqlDbType.VarChar);
            SqlParametros.Value = catalogo.CodTipo_Cat2;
            SqlParametros = Comando.Parameters.Add("@Sinopsis_Cat", SqlDbType.VarChar);
            SqlParametros.Value = catalogo.Sinopsis_Cat1;
            SqlParametros = Comando.Parameters.Add("@Duracion_Cat", SqlDbType.DateTime);
            SqlParametros.Value = catalogo.Duracion_Cat1;
            SqlParametros = Comando.Parameters.Add("@URLPortada_Cat", SqlDbType.VarChar);
            SqlParametros.Value = catalogo.URLPortada_Cat1;
            SqlParametros = Comando.Parameters.Add("@TituloContenido_Cat", SqlDbType.VarChar);
            SqlParametros.Value = catalogo.TituloContenido_Cat1;
            SqlParametros = Comando.Parameters.Add("@Season_Cat", SqlDbType.Int);
            SqlParametros.Value = catalogo.Season_Cat1;
            SqlParametros = Comando.Parameters.Add("@URLVideo_Cat", SqlDbType.Int);
            SqlParametros.Value = catalogo.URLVideo_Cat1;
            SqlParametros = Comando.Parameters.Add("@Clasif_Edad_Cat", SqlDbType.VarChar);
            SqlParametros.Value = catalogo.Clasif_Edad_Cat1;
            SqlParametros = Comando.Parameters.Add("@estado", SqlDbType.Bit);
            SqlParametros.Value = catalogo.Estado;
        }

        public int agregarCatalogo(Catalogo catalogo)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCatalogoAgregar(ref comando, catalogo);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarCatalogo");
        }

        public int GetIDUltimoCatalogo()
        {
            AccesoDatos ad = new AccesoDatos();
            return ad.ObtenerMaximo("Select * from Catalogos as c");
        }
    }
}