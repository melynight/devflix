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
            DataTable tabla = ds.ObtenerTabla("Catalogos", "Select * from Catalogos join [Generos] on IDGenero_Ge = IDGenero_Cat where IDContenido_Cat = '" + idCatalogo + "'");

            if (tabla.Rows.Count > 0)
            {
                var genero = new Generos
                {
                    IDGenero_GE1 = tabla.Rows[0]["IDGenero_Ge"].ToString(),
                    NombreGenero_GE1 = tabla.Rows[0]["NombreGenero_Ge"].ToString(),
                    Estado_GE = Convert.ToBoolean(tabla.Rows[0]["estado_GE"].ToString())
                };

                var catalogo = new Catalogo
                {
                    IDContenido_Cat1 = tabla.Rows[0]["IDContenido_Cat"].ToString(),
                    IDGenero_Cat2 = genero,
                    CodTipo_Cat1 = tabla.Rows[0]["CodTipo_Cat"].ToString(),
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

        public DataTable GetTablaCatalogo(int edad = 0, string titulo = "")
        {
            int filtros = 0;
            string filtroEdad = "", filtroTitulo = "";
            if (edad > 0)
            {
                filtroEdad = (filtros > 0 ? " and " : "") + "Clasif_Edad_Cat <= " + edad;
                filtros++;
            }

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                filtroTitulo = (filtros > 0 ? " and " : "") + "TituloContenido_Cat LIKE '%" + titulo + "%'";
                filtros++;
            }

            DataTable tabla = ds.ObtenerTabla("Catalogos", "Select * from Catalogos" + (filtros == 0 ? "" : " where " + filtroEdad + filtroTitulo));
            return tabla;
        }


        public Boolean ExisteCatalogo(Catalogo catalogo)
        {
            String consulta = "Select * from Catalogos where IDContenido_Cat= '" + catalogo.IDContenido_Cat1 + "'";
            return ds.existe(consulta);
        }

        public DataTable GetTablaCatalogo()
        {
            DataTable tabla = ds.ObtenerTabla("Catalogos", "Select * from Catalogos");
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
            SqlParametros.Value = catalogo.CodTipo_Cat1;
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
    }
}