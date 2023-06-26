using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
    //oa
{
    public partial class Ingreso1 : System.Web.UI.Page
    {
        private Cuenta cuenta = new Cuenta();
        private NegocioCuenta negCuenta = new NegocioCuenta();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            cuenta.SetEmail_Cu(txtEmail.Text.Trim().ToLower());
            cuenta.SetClave_Cu(txtClave.Text.Trim().ToLower());

            if (negCuenta.ValidarInicioSesion(cuenta))
            {
                cuenta = negCuenta.Get(txtEmail.Text.Trim().ToLower());

                Paises pais = new Paises();
                NegocioPais negPais = new NegocioPais();
                Suscripcion sus = new Suscripcion();
                NegocioSuscripcion negSus = new NegocioSuscripcion();
                TipoSuscripcion tip = new TipoSuscripcion();
                NegocioTipoSuscripcion negTipo = new NegocioTipoSuscripcion();

                pais = negPais.Get(cuenta.Get_Pais_Cu().IDPais_PA1);
                sus = negSus.Get(cuenta.GetSus_Cu().CodSus_Sus1);
                tip = negTipo.Get(sus.CodTipo_Sus1.CodTipo_Ts1);

                sus.CodTipo_Sus1 = tip;
                cuenta.SetCodSus_Cu(sus);
                cuenta.Set_Pais_Cu(pais);

<<<<<<< HEAD
=======

                Session["Cuenta"] = cuenta;
                Application["tipoSuscripcion"] = tip;
                Session["NombreSus"] = tip.Nombre_Ts1;

>>>>>>> origin/main
                Session["EdadUsuario"] = cuenta.GetEdad_Cu();
                Session["IDAdmin"] = cuenta.GetIDCuenta();
                Session["EdadUsuario"] = cuenta.GetEdad_Cu();

<<<<<<< HEAD
                Session["Cuenta"] = cuenta;
                Application["tipoSuscripcion"] = tip;
                Session["NombreSus"] = tip.Nombre_Ts1;
=======
>>>>>>> origin/main

                lblError.Visible = false;
                txtClave.Text = "";
                txtEmail.Text = "";
                Response.Redirect("SeleccionarUsuario.aspx");
            }
            lblError.Visible = true;
        }
    }
}