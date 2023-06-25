using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;


namespace Negocio
{
    public class NegocioCuenta
    {
        public DataTable GetTabla()
        {
            DaoCuenta dao = new DaoCuenta();
            return dao.GetTablaCuentas();
        }

        public Cuenta Get(string email)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            cue.SetEmail_Cu(email);
            return dao.GetCuenta(cue);
        }

        public Cuenta GetByID(int id)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            cue.SetIDCuenta(id);
            return dao.GetCuentaByID(cue);
        }

        public Cuenta GetByIDStandard(int id)
        {
            DaoCuenta dCuenta = new DaoCuenta();
            Cuenta cuenta = new Cuenta();
            cuenta.SetIDCuenta(id);
            return dCuenta.GetStandard(cuenta);
        }

        public bool EliminarCuenta(int id)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            cue.SetIDCuenta(id);
            int op = dao.EliminarCuenta(cue);
            if (op == 1)
                return true;
            else
                return false;
        }
        public bool EliminarCuentaStd(int id)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            cue.SetIDCuenta(id);
            int op = dao.StdUserEliminar(cue);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool CambiarNombre(int id, string nombre)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            cue.SetIDCuenta(id);
            cue.SetNombre_Cu(nombre);
            int op = dao.StdUserModificarNombre(cue);
            if (op == 1)
                return true;
            else
                return false;
        }
        public bool CambiarEdad(int id, int edad)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            cue.SetIDCuenta(id);
            cue.SetEdad_Cu(edad);            
            int op = dao.StdUserModificarEdad(cue);
            if (op == 1)
                return true;
            else
                return false;
        }
        public bool CambiarURL(int id, string Url)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            cue.SetIDCuenta(id);
            cue.URLImagenDefault1=Url;
            int op = dao.StdUserModificarImg(cue);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool CambiarContrasenia(int id, string contrasenia)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            cue.SetIDCuenta(id);
            cue.SetClave_Cu(contrasenia);
            int op = dao.cambiarContrasenia(cue);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool AgregarCuenta(Cuenta cue)
        {
            int cantFilas = 0;
            DaoCuenta dao = new DaoCuenta();
            if (dao.ExisteCuenta(cue) == false)
            {
                cantFilas = dao.AgregarCuenta(cue);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool AgregarUsuario(Cuenta cue)
        {
            int cantFilas = 0;
            DaoCuenta dao = new DaoCuenta();
            cantFilas = dao.UsuarioAgregar(cue);
            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool CambiarPlan(int codsus, string email)
        {
            DaoCuenta dao = new DaoCuenta();
            Cuenta cue = new Cuenta();
            Suscripcion sus = new Suscripcion();
            sus.CodSus_Sus1 = codsus;
            NegocioSuscripcion nsus = new NegocioSuscripcion();
            sus = nsus.Get(codsus);
            cue.SetEmail_Cu(email);
            cue.SetCodSus_Cu(sus);
            int op = dao.CuentaCambiarPlan(cue);
            if (op == 1)
                return true;
            else
                return false;
        }

        public Boolean ValidarInicioSesion(Cuenta cue)
        {
            DaoCuenta dao = new DaoCuenta();
            if (dao.ExisteCuenta(cue) && dao.CoincidenClaves(cue))
            {
                return true;
            }

            return false;
        }

        public Boolean ValidarPINS(Cuenta cu, string pin)
        {
            DaoCuenta dao = new DaoCuenta();
            if (dao.CoincidenPINS(cu, pin))
            {
                return true;
            }
            return false;
        }

        public Boolean validarContrasenia(Cuenta cu)
        {
            DaoCuenta dao = new DaoCuenta();
            if (dao.CoincidenClaves(cu))
            {
                return true;
            }
            return false;

        }

        public int contarUsuariosAdmin(int idAdmin, Cuenta cuentaAdmin)
        {
            int cantUsuariosAdmin = 0;

            DataTable ds = GetTabla();
            int IDRef = cuentaAdmin.GetIDCuenta();

            foreach (DataRow dr in ds.Rows) //recorro la tabla de cuentas buscando cuantos usuarios tiene el admin.
            {
                if(!Convert.IsDBNull(dr["IDRef_Cu"]))
                {
                    

                    if (IDRef == Convert.ToInt32(dr["IDRef_Cu"]))
                    {
                        cantUsuariosAdmin++;
                    }
                }


            }
            return cantUsuariosAdmin;
         }

        public int GetIDUltimaCuenta(Cuenta cuenta)
        {
            DaoCuenta dc = new DaoCuenta();
            return dc.GetIDUltimaCuenta(cuenta);
           
        }

    }
}


