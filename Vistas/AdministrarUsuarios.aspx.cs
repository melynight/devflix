﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioCuenta negCue = new NegocioCuenta();
        NegocioTipoSuscripcion nTipoSuscripcion = new NegocioTipoSuscripcion();
        TipoSuscripcion tipoSuscripcion = new TipoSuscripcion();
        NegocioSuscripcion nSuscripcion = new NegocioSuscripcion();
        Suscripcion suscripcion = new Suscripcion();


        protected void Page_Load(object sender, EventArgs e)
        {


            cuenta = (Cuenta)Session["Cuenta"];
            Session["CantidadUsuariosAdmin"] = validarCantUsuariosMax(cuenta);

            MensajesAclarativos();

            if (!IsPostBack)
            {

                // if ((bool)Session["AgregarUsuario"] == false && (int)Session["CantidadUsuariosAdmin"] < cantMax) btnAgregarUsuario.Enabled = false;
                CargarImgAdmin(cuenta);
                OcultarMenuModificar();
                lblUserName.Text = cuenta.GetNombre_Cu();


            }
            if ((bool)Session["AgregarUsuario"] == false) btnAgregarUsuario.Enabled = false;
            CargarImgAdmin(cuenta);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Configuraciones.aspx");
        }
        protected void btnModificarUsuario_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "ModificarUsuario")
            {
                int IdUser = Convert.ToInt32(e.CommandArgument);
                Session["IDStd"] = IdUser;
                MostrarMenuModificar();
            }
        }

        public int validarCantUsuariosMax(Cuenta cuenta)
        {
            suscripcion = nSuscripcion.Get(cuenta.GetSus_Cu().CodSus_Sus1);
            tipoSuscripcion = nTipoSuscripcion.Get(suscripcion.CodTipo_Sus1.CodTipo_Ts1);

            int cantUsuariosMax = tipoSuscripcion.CantUsuarios_Ts1;

            if (cantUsuariosMax == 1)
            {
                ListView1.DataSourceID = "SqlDataSource1"; //top 0
                ListView1.DataBind();

            }
            else if (cantUsuariosMax == 2)
            {
                ListView1.DataSourceID = "SqlDataSource2"; //top 1
                ListView1.DataBind();
            }
            else
            {
                ListView1.DataSourceID = "SqlDataSource3"; //top 3
                ListView1.DataBind();
            }


            int cantUsuariosAdmin = negCue.contarUsuariosAdmin((int)Session["IDAdmin"], (Cuenta)Session["Cuenta"]) + 1;


            if (cantUsuariosAdmin < cantUsuariosMax) btnAgregarUsuario.Enabled = true;
            else btnAgregarUsuario.Visible = false;


            return cantUsuariosAdmin;


        }
        protected void btnEliminarUsuario_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "EliminarUsuario")
            {

                int IdUser = Convert.ToInt32(e.CommandArgument);
                negCue.EliminarCuentaStd(IdUser);
                string script = "alert('¡Usuario eliminado!');";
                Session["AvisoCuentaEliminada"] = script;
                Response.Redirect("AdministrarUsuarios.aspx");
            }

        }
        public void MostrarMenuModificar()
        {
            lblNombre.Visible = true;
            lblNuevaEdad.Visible = true;
            txtNuevaEdad.Visible = true;
            txtNuevoNombre.Visible = true;
            imgGafas1.Visible = true;
            imgGafas2.Visible = true;
            imgKids.Visible = true;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
            ddlElegirImagen.Visible = true;
        }

        public void OcultarMenuModificar()
        {
            lblNombre.Visible = false;
            lblNuevaEdad.Visible = false;
            txtNuevaEdad.Visible = false;
            txtNuevoNombre.Visible = false;
            imgGafas1.Visible = false;
            imgGafas2.Visible = false;
            imgKids.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            ddlElegirImagen.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            /*int IDRef = cuenta.GetIDRef_Cu();*/
            bool ModificoNombre = false;
            bool ModificoEdad = false;

            if (Session["IDStd"] != null)
            {
                cuenta = negCue.GetByIDStandard((int)Session["IDStd"]);
            }

            if (!string.IsNullOrEmpty(txtNuevoNombre.Text))
            {
                if (cuenta.GetIDRef_Cu() > 0)
                {
                    ModificoNombre = negCue.CambiarNombre((int)Session["IDStd"], txtNuevoNombre.Text.Trim());
                }
                else
                {
                    if (txtNuevoNombre.Text.ToString().Trim() != cuenta.GetNombre_Cu())
                    {
                        ModificoNombre = negCue.CambiarNombre((int)Session["IDAdmin"], txtNuevoNombre.Text.Trim());
                        //aca esta la cosa
                    }
                    else
                    {
                        ModificoNombre = false;
                        lblErrorNombre.Visible = true;
                        string script = "alert('¡No hubo cambios!');";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", script, true);
                        /*ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert ('ERROR DEBE COLOCAR DATOS EN LAS CAJAS DE TEXTO ')", true);*/
                    }

                }
            }
            if (!string.IsNullOrEmpty(txtNuevaEdad.Text))
            {
                if (cuenta.GetIDRef_Cu() != 0 && cuenta.GetIDRef_Cu().ToString() != null)
                {
                    ModificoEdad = negCue.CambiarEdad((int)Session["IDStd"], Convert.ToInt32(txtNuevaEdad.Text));
                    Session["EdadUsuario"] = Convert.ToInt32(txtNuevaEdad.Text);
                }
                else
                {
                    ModificoEdad = negCue.CambiarEdad((int)Session["IDAdmin"], Convert.ToInt32(txtNuevaEdad.Text));
                    Session["EdadUsuario"] = Convert.ToInt32(txtNuevaEdad.Text);
                    
                }
            }
            bool ModificoUrl = false;

            switch (ddlElegirImagen.SelectedIndex)
            {
                case 1:
                    if (cuenta.GetIDRef_Cu() != 0 && cuenta.GetIDRef_Cu().ToString() != null)
                    {
                        ModificoUrl = negCue.CambiarURL((int)Session["IDStd"], "Recursos/Imagenes/usuarioGafas.png");
                    }
                    else
                    {
                        ModificoUrl = negCue.CambiarURL((int)Session["IDAdmin"], "Recursos/Imagenes/usuarioGafas.png");
                    }
                    break;
                case 2:
                    if (cuenta.GetIDRef_Cu() != 0 && cuenta.GetIDRef_Cu().ToString() != null)
                    {
                        ModificoUrl = negCue.CambiarURL((int)Session["IDStd"], "Recursos/Imagenes/usuarioGafas2.png");
                    }
                    else { ModificoUrl = negCue.CambiarURL((int)Session["IDAdmin"], "Recursos/Imagenes/usuarioGafas2.png"); }

                    break;
                case 3:
                    if (cuenta.GetIDRef_Cu() != 0 && cuenta.GetIDRef_Cu().ToString() != null)
                    {
                        ModificoUrl = negCue.CambiarURL((int)Session["IDStd"], "Recursos/Imagenes/UsuarioKids.png");
                    }
                    else
                    {
                        ModificoUrl = negCue.CambiarURL((int)Session["IDAdmin"], "Recursos/Imagenes/UsuarioKids.png");
                    }
                    break;


            }

            /*if (!ModificoNombre)
            {
                lblErrorNombre.Visible = true;
            }
            else
            {
                Response.Redirect("AdministrarUsuarios.aspx");
            }*/
            /*if (!ModificoUrl) lblErrorNombre.Visible = true;
            if (!ModificoNombre) lblErrorNombre.Visible = true;
            if (!ModificoEdad) lblErrorNombre.Visible = true;*/



            //if ((int)Session["CantidadUsuariosAdmin"] == 1 || (int)Session["CantidadUsuariosAdmin"] < cantMax) CargarImgAdmin(cuenta);//validamos que no tenga usuarios ese admin
            if (ModificoNombre || ModificoEdad || ModificoUrl)
            {
                if (txtNuevoNombre.Text.ToString().Trim() != cuenta.GetNombre_Cu())
                {
                    lblCambiosExitosos.Visible = true;

                    string script = "alert('¡Cambios efectuados exitosamente!');";
                    Session["CambiosExito"] = script;

                }
                else
                {
                    string script = "alert('El nombre es igual al anterior!');";
                    Session["NombreIgual"] = script;
                }

            }
            else
            {
                string script = "alert('¡No hubo cambios!');";
                Session["Cambiosfallo"] = script;
                lblErrorNombre.Visible = true;
                lblCambiosExitosos.Visible = false;
            }
            Session["IDStd"] = null;
            cuenta = negCue.GetByID((int)Session["IDAdmin"]); //vuelve el control ADMIN
            Session["Cuenta"] = cuenta;
            int cantMax = validarCantUsuariosMax(cuenta);
            Response.Redirect("AdministrarUsuarios.aspx");
        }
        public void CargarImgAdmin(Cuenta cuenta)
        {
            string URLImagen;
            int IDadmin = (int)Session["IDAdmin"];
            URLImagen = cuenta.URLImagenDefault1;
            imgAdmin.ImageUrl = URLImagen;
            lblNombreAdmin.Text = cuenta.GetNombre_Cu();
            lblEdadAdmin.Text = Convert.ToString(cuenta.GetEdad_Cu());
            lblErrorNombre.Visible = false;
            lblCambiosExitosos.Visible = false;

        }


        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            MostrarMenuModificar();

        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario.aspx");
        }

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            OcultarMenuModificar();
        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarUsuario.aspx");
        }

        void MensajesAclarativos()
        {

            if (Session["AvisoCuentaEliminada"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", Convert.ToString(Session["AvisoCuentaEliminada"]), true);
                Session["AvisoCuentaEliminada"] = null;
            }

            if (Session["CambiosExito"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", Convert.ToString(Session["CambiosExito"]), true);
                Session["CambiosExito"] = null;
            }

            if (Session["NombreIgual"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", Convert.ToString(Session["NombreIgual"]), true);
                Session["NombreIgual"] = null;
            }

            if (Session["Cambiosfallo"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", Convert.ToString(Session["Cambiosfallo"]), true);
                Session["Cambiosfallo"] = null;
            }
        }
    }
}