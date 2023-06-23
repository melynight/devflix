using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuenta
    {
        //Tienen el mismo nombre de columnas que en la bd
        int IDCuenta;
        Paises pais;
        Suscripcion suscripcion; //codsus
        string Email_Cu;//30 (longitud)
        string Clave_Cu;//20 (longitud)
        DateTime FechaCreacion_Cu;
        string Nombre_Cu;//50 (longitud)
        string PIN_Cu;//4 (longitud)
        int Edad_Cu;
        int IDRef_Cu;
        string NROTarjeta_Cu;//16 (longitud)
        string URLImagenDefault;
        Boolean Estado_Cu;//Boolean es lo mismo que bool pero Boolean funciona en VB.Net y C# a la vez

        public Cuenta()
        {

        }

        public Cuenta(int iDCuenta, Paises pais, Suscripcion suscripcion, string email_Cu, string clave_Cu, DateTime fechaCreacion_Cu, string nombre_Cu,
            string pIN_Cu, int edad_Cu, int iDRef_Cu, string nROTarjeta_Cu, string uRLImagenDefault, bool estado_Cu)
        {
            IDCuenta = iDCuenta;
            this.pais = pais;
            this.suscripcion = suscripcion;
            Email_Cu = email_Cu;
            Clave_Cu = clave_Cu;
            FechaCreacion_Cu = fechaCreacion_Cu;
            Nombre_Cu = nombre_Cu;
            PIN_Cu = pIN_Cu;
            Edad_Cu = edad_Cu;
            IDRef_Cu = iDRef_Cu;
            NROTarjeta_Cu = nROTarjeta_Cu;
            URLImagenDefault1 = uRLImagenDefault;
            Estado_Cu = estado_Cu;
        }

        public Boolean GetEstado_Cu() { return Estado_Cu; }
        public void SetEstado_Cu(Boolean estado) { Estado_Cu = estado; }

        public DateTime GetFechaCreacion_Cu() { return FechaCreacion_Cu; }
        public void SetFechaCreacion_Cu(DateTime fecha) { FechaCreacion_Cu = fecha; }

        public int GetIDCuenta() { return IDCuenta; }
        public void SetIDCuenta(int ID) { IDCuenta = ID; }

        public Paises Get_Pais_Cu() { return pais; }
        public void Set_Pais_Cu(Paises pais) { this.pais = pais; }

        public Suscripcion GetSus_Cu() { return suscripcion; }
        public void SetCodSus_Cu(Suscripcion sus) { suscripcion = sus; }

        public int GetEdad_Cu() { return Edad_Cu; }
        public void SetEdad_Cu(int edad) { Edad_Cu = edad; }

        public int GetIDRef_Cu() { return IDRef_Cu; }
        public void SetIDRef_Cu(int id) { IDRef_Cu = id; }

        public string GetEmail_Cu() { return Email_Cu; }
        public void SetEmail_Cu(string email) { Email_Cu = email; }

        public string GetClave_Cu() { return Clave_Cu; }
        public void SetClave_Cu(string clave) { Clave_Cu = clave; }

        public string GetNombre_Cu() { return Nombre_Cu; }
        public void SetNombre_Cu(string nombre) { Nombre_Cu = nombre; }

        public string GetPIN_Cu() { return PIN_Cu; }
        public void SetPIN_Cu(string pin) { PIN_Cu = pin; }

        public string GetNROTarjeta_Cu() { return NROTarjeta_Cu; }
        public void SetNROTarjeta_Cu(string nro) { NROTarjeta_Cu = nro; }
        public string URLImagenDefault1 { get => URLImagenDefault; set => URLImagenDefault = value; }
    }

}
