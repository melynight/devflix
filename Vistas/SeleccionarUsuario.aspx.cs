using System;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.UI;

namespace Vistas
{
    public partial class SeleccionarUsuario : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        Cuenta cuentaAdminAux = new Cuenta();
        NegocioCuenta nCuenta = new NegocioCuenta();
        NegocioTipoSuscripcion nTipoSuscripcion = new NegocioTipoSuscripcion();
        TipoSuscripcion tipoSuscripcion = new TipoSuscripcion();
        NegocioSuscripcion nSuscripcion = new NegocioSuscripcion();
        Suscripcion suscripcion = new Suscripcion();


        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            cuenta = (Cuenta)Session["Cuenta"];
            

            if (!IsPostBack) {

                if (cuenta.GetIDRef_Cu() != 0 && cuenta.GetIDRef_Cu().ToString() != null) //no es admin
                {
                   cuentaAdminAux = nCuenta.GetByID((int)Session["IDAdmin"]);
                    CargarImgAdmin(cuentaAdminAux);
                    lblIDRef.Text = cuentaAdminAux.GetIDCuenta().ToString();
                    ocultarValidarPIN();
                    lblError.Text = "";
                }

                else
                {
                    Session["IDAdmin"] = cuenta.GetIDCuenta();
                    cuenta = (Cuenta)Session["Cuenta"];
                    CargarImgAdmin(cuenta);
                    Session["CantidadUsuariosAdmin"] = validarCantUsuariosMax(cuenta);

                    lblIDRef.Text = cuenta.GetIDCuenta().ToString();
                    lblNombreAdmin.Text = cuenta.GetNombre_Cu();

                    ocultarValidarPIN();
                }

            }
            



          


        }



        public int validarCantUsuariosMax(Cuenta cuenta)  
        {
            suscripcion = nSuscripcion.Get(cuenta.GetSus_Cu().CodSus_Sus1);
            tipoSuscripcion = nTipoSuscripcion.Get(suscripcion.CodTipo_Sus1.CodTipo_Ts1);

            int cantUsuariosMax = tipoSuscripcion.CantUsuarios_Ts1;

            int cantUsuarios = nCuenta.contarUsuariosAdmin((int)Session["IDAdmin"], (Cuenta)Session["Cuenta"]) + 1;

            if (cantUsuarios < cantUsuariosMax)
            {
                imgbtnAgregarUsuario.Visible = true;
                Session["AgregarUsuario"] = true;


            }
            else
            { imgbtnAgregarUsuario.Visible = false;
                Session["AgregarUsuario"] = true;
            }

            
                
                return cantUsuarios;

            
        }

        protected void btnAdmin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cuenta cuentaAdmin = new Cuenta();

            int ID = (int)Session["IDAdmin"];

            cuentaAdmin = nCuenta.GetByID(ID);
            Session["Cuenta"] = cuentaAdmin;
            Response.Redirect("Home.aspx");
        }



        protected void imgBtnUsuario1_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (e.CommandName == "ingresoUsuario")
            {


                cuenta = nCuenta.GetByIDStandard(Convert.ToInt32(e.CommandArgument));
                Session["Cuenta"] = cuenta;
                Response.Redirect("Home.aspx");


            }

        }

        protected void imgbtnAgregarUsuario_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            mostrarValidarPIN();

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (nCuenta.ValidarPINS(cuenta, txtPin.Text))
            {
                lblError.Text = "";
                ocultarValidarPIN();
                Session["AgregarUsuario"] = true;
                Response.Redirect("AgregarUsuario.aspx");
            } 

            else {

                lblError.Text = "El PIN ingreso no es correcto.";
                txtPin.Text = "";
                ocultarValidarPIN();

            }
        }

        public void CargarImgAdmin(Cuenta cuenta)
        {
            string URLImagen;
            int IDadmin = (int)Session["IDAdmin"];
            URLImagen = cuenta.URLImagenDefault1;
            btnAdmin.ImageUrl = URLImagen;
            lblNombreAdmin.Text = cuenta.GetNombre_Cu();

        }

        public void ocultarValidarPIN()
        {
            lblPin.Visible = false;
            txtPin.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
        }

        public void mostrarValidarPIN()
        {
            lblPin.Visible = true;
            txtPin.Visible = true;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
            imgbtnAgregarUsuario.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            imgbtnAgregarUsuario.Visible = true;
            ocultarValidarPIN();
        }
    }
}