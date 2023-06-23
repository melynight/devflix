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
    public class DaoCuenta
    {

        AccesoDatos ds = new AccesoDatos();

        public Cuenta CargarCuenta(DataTable tabla, Cuenta cue)
        {
            Paises pais = new Paises();
            Suscripcion su = new Suscripcion();

            pais.IDPais_PA1 = Convert.ToString(tabla.Rows[0][1].ToString());
            su.CodSus_Sus1 = Convert.ToInt32(tabla.Rows[0][2].ToString());
            //convierto los datos de la tabla para setear las columnas en el objeto 
            cue.Set_Pais_Cu(pais);
            cue.SetCodSus_Cu(su);
            cue.SetIDCuenta(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            cue.SetEmail_Cu(tabla.Rows[0][3].ToString());
            cue.SetClave_Cu(tabla.Rows[0][4].ToString());
            cue.SetFechaCreacion_Cu(Convert.ToDateTime(tabla.Rows[0][5].ToString()));
            cue.SetNombre_Cu(tabla.Rows[0][6].ToString());
            cue.SetPIN_Cu(tabla.Rows[0][7].ToString());
            cue.SetEdad_Cu(Convert.ToInt32(tabla.Rows[0][8].ToString()));


            string valorIDRef = tabla.Rows[0][9].ToString();
            if (!string.IsNullOrEmpty(valorIDRef))
            {
                cue.SetIDRef_Cu(Convert.ToInt32(valorIDRef));
            }
            else
            {
                cue.SetIDRef_Cu(0);
            }

            cue.SetNROTarjeta_Cu(tabla.Rows[0][10].ToString());
            cue.URLImagenDefault1 = tabla.Rows[0][11].ToString();
            cue.SetEstado_Cu(Convert.ToBoolean(tabla.Rows[0][12].ToString()));

            return cue;
        }

        public Cuenta GetCuenta(Cuenta cue)
        {
            DataTable tabla = ds.ObtenerTabla("Cuentas", "Select * from Cuentas where Email_Cu= '" + cue.GetEmail_Cu() + "'");

            if (tabla.Rows.Count == 1)
            {
                return CargarCuenta(tabla, cue);
            }
            return cue;
        }

        public Cuenta GetCuentaByID(Cuenta cue)
        {
            DataTable tabla = ds.ObtenerTabla("Cuentas", "Select * from Cuentas where IDCuenta= " + cue.GetIDCuenta());
            //convierto los datos de la tabla para setear las columnas en el objeto 
            if (tabla.Rows.Count == 1)
            {
                return CargarCuenta(tabla, cue);
            }
            return cue;
        }

        public Cuenta GetStandard(Cuenta cue) //by IDCuenta => usuario no administrador
        {

            DataTable tabla = ds.ObtenerTabla("Cuentas", "Select * from Cuentas where IDCuenta= " + cue.GetIDCuenta());
            //convierto los datos de la tabla para setear las columnas en el objeto 
            if (tabla.Rows.Count == 1)
            {
                Paises pais = new Paises();
                Suscripcion su = new Suscripcion();
                cue.SetIDCuenta(Convert.ToInt32(tabla.Rows[0][0].ToString()));
                cue.Set_Pais_Cu(pais);
                cue.SetCodSus_Cu(su);
                cue.SetEmail_Cu(null);
                cue.SetClave_Cu(null);
                cue.SetFechaCreacion_Cu(Convert.ToDateTime(tabla.Rows[0][5].ToString()));
                cue.SetNombre_Cu(tabla.Rows[0][6].ToString());
                cue.SetPIN_Cu(null);
                cue.SetEdad_Cu(Convert.ToInt32(tabla.Rows[0][8].ToString()));
                cue.SetIDRef_Cu(Convert.ToInt32(tabla.Rows[0][9].ToString()));
                cue.SetNROTarjeta_Cu(null);
                cue.SetEstado_Cu(Convert.ToBoolean(tabla.Rows[0][12].ToString()));
            }
            return cue;

        }

        public Boolean ExisteCuenta(Cuenta cue)
        {
            String consulta = "Select * from Cuentas where Email_Cu='" + cue.GetEmail_Cu() + "' and Estado_Cu=1";
            return ds.existe(consulta);
        }
        public Boolean ExisteCuentaStd(Cuenta cue)
        {
            String consulta = "Select * from Cuentas where  IDCuenta='" + cue.GetIDCuenta() + "' and Estado_Cu=1";
            return ds.existe(consulta);
        }


        public Boolean CoincidenClaves(Cuenta cue)
        {
            String consulta = "Select * from Cuentas where Clave_Cu='" + cue.GetClave_Cu() + "'";
            return ds.existe(consulta);
        }

        public Boolean CoincidenPINS(Cuenta cu, string pin)
        {
            string consulta = "Select * from Cuentas where PIN_Cu ='" + pin + "' and IDCuenta = " + cu.GetIDCuenta();
            return ds.existe(consulta);
        }

        public DataTable GetTablaCuentas()
        {
            DataTable tabla = ds.ObtenerTabla("Cuentas", "Select * from Cuentas");
            return tabla;
        }

        private void ArmarParametrosCuentaEliminar(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDCuenta", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDCuenta();
        }
        public int EliminarCuenta(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCuentaEliminar(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarCuenta");
        }

        private void ArmarParametrosUserEliminar(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDref", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDRef_Cu();
        }

        public int EliminarUser(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUserEliminar(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarUsuario");
        }

        private void ArmarParametrosStdUserEliminar(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDcuenta", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDCuenta();
        }

        public int StdUserEliminar(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosStdUserEliminar(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "EliminarCuentaStandard");
        }
        private void ArmarParametrosStdUserModificarNombre(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDcuenta", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDCuenta();
            SqlParametros = Comando.Parameters.Add("@Nombre_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetNombre_Cu();
        }
        public int StdUserModificarNombre(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosStdUserModificarNombre(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "ModificarNombreCuentaStandard");
        }
        private void ArmarParametrosStdUserModificarEdad(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDcuenta", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDCuenta();
            SqlParametros = Comando.Parameters.Add("@Edad_Cu", SqlDbType.Int);
            SqlParametros.Value = cue.GetEdad_Cu();
        }
        public int StdUserModificarEdad(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosStdUserModificarEdad(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "ModificarEdadCuentaStandard");
        }
        private void ArmarParametrosStdUserModificarImg(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDcuenta", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDCuenta();
            SqlParametros = Comando.Parameters.Add("@URLimg", SqlDbType.VarChar);
            SqlParametros.Value = cue.URLImagenDefault1;
        }
        public int StdUserModificarImg(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosStdUserModificarImg(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "ModificarURLCuentaStandard");
        }

        private void ArmarParametrosCuentaCambiarPlan(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@CodSus", SqlDbType.Int);
            SqlParametros.Value = cue.GetSus_Cu().CodSus_Sus1;
            SqlParametros = Comando.Parameters.Add("@Email", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetEmail_Cu();
        }

        public int CuentaCambiarPlan(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCuentaCambiarPlan(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spCambiarPlan");
        }

        private void ArmarParametrosCuentaAgregar(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID_Pais_Cu", SqlDbType.Char);
            SqlParametros.Value = cue.Get_Pais_Cu().IDPais_PA1;
            SqlParametros = Comando.Parameters.Add("@CodSus_Cu", SqlDbType.Int);
            SqlParametros.Value = cue.GetSus_Cu().CodSus_Sus1;
            SqlParametros = Comando.Parameters.Add("@Email_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetEmail_Cu();
            SqlParametros = Comando.Parameters.Add("@Clave_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetClave_Cu();
            SqlParametros = Comando.Parameters.Add("@Nombre_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetNombre_Cu();
            SqlParametros = Comando.Parameters.Add("@PIN_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetPIN_Cu();
            SqlParametros = Comando.Parameters.Add("@Edad_Cu", SqlDbType.Int);
            SqlParametros.Value = cue.GetEdad_Cu();
            SqlParametros = Comando.Parameters.Add("@IDRef_Cu", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDRef_Cu();
            SqlParametros = Comando.Parameters.Add("@NROTarjeta_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetNROTarjeta_Cu();
            SqlParametros = Comando.Parameters.Add("@Estado_Cu", SqlDbType.Bit);
            SqlParametros.Value = cue.GetEstado_Cu();
        }
        public int AgregarCuenta(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCuentaAgregar(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarCuenta");
        }

        private void ArmarParametrosUsuarioAgregar(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Nombre_Cu", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetNombre_Cu();
            SqlParametros = Comando.Parameters.Add("@Edad_Cu", SqlDbType.Int);
            SqlParametros.Value = cue.GetEdad_Cu();
            SqlParametros = Comando.Parameters.Add("@IDRef_Cu", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDRef_Cu();
            SqlParametros = Comando.Parameters.Add("@Estado_Cu", SqlDbType.Bit);
            SqlParametros.Value = cue.GetEstado_Cu();
        }
        public int UsuarioAgregar(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuarioAgregar(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarUsuario");
        }

        private void ArmarParametroscambiarContrasenia(ref SqlCommand Comando, Cuenta cue)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDCuenta", SqlDbType.Int);
            SqlParametros.Value = cue.GetIDCuenta();
            SqlParametros = Comando.Parameters.Add("@ContraseniaNueva", SqlDbType.VarChar);
            SqlParametros.Value = cue.GetClave_Cu();
        }

        public int cambiarContrasenia(Cuenta cue)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametroscambiarContrasenia(ref comando, cue);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarContrasenia");
        }

        public int GetIDUltimaCuenta(Cuenta cuenta)
        {
            AccesoDatos ad = new AccesoDatos();
            return ad.ObtenerMaximo("Select * from Cuentas where Email_Cu='" + cuenta.GetEmail_Cu() + "'");
        }
    }
}
