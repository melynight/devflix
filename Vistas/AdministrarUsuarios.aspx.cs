using System;
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
            

            if (!IsPostBack)
            {
               // if ((bool)Session["AgregarUsuario"] == false && (int)Session["CantidadUsuariosAdmin"] < cantMax) btnAgregarUsuario.Enabled = false;
                CargarImgAdmin(cuenta);
                OcultarMenuModificar();
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();
                
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

            int cantUsuariosAdmin = negCue.contarUsuariosAdmin((int)Session["IDAdmin"], (Cuenta)Session["Cuenta"]) + 1;


            if (cantUsuariosAdmin < cantUsuariosMax) btnAgregarUsuario.Enabled = true;
            else btnAgregarUsuario.Visible = false;


            return cantUsuariosAdmin;


        }
        protected void btnEliminarUsuario_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "EliminarUsuario")
            {
                bool Elimino = false;
                int IdUser = Convert.ToInt32(e.CommandArgument);
                Elimino=negCue.EliminarCuentaStd(IdUser);
                if (Elimino)
                {
                    Response.Redirect("Configuraciones.aspx");
                }            
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

            if (!string.IsNullOrEmpty(txtNuevoNombre.Text)){
                if (cuenta.GetIDRef_Cu() > 0 )
                {
                   ModificoNombre = negCue.CambiarNombre((int)Session["IDStd"], txtNuevoNombre.Text.Trim());
                }
                else
                {
                   ModificoNombre = negCue.CambiarNombre((int)Session["IDAdmin"], txtNuevoNombre.Text.Trim());
                }                  
            }
            if (!string.IsNullOrEmpty(txtNuevaEdad.Text))
            {
                if(cuenta.GetIDRef_Cu()!=0 && cuenta.GetIDRef_Cu().ToString() != null)
                {
                    ModificoEdad = negCue.CambiarEdad((int)Session["IDStd"], Convert.ToInt32(txtNuevaEdad.Text));
                }
                else { ModificoEdad = negCue.CambiarEdad((int)Session["IDAdmin"], Convert.ToInt32(txtNuevaEdad.Text)); }
            }
            bool ModificoUrl=false;
            
            switch (ddlElegirImagen.SelectedIndex)
            {
                case 1: if (cuenta.GetIDRef_Cu()!=0 && cuenta.GetIDRef_Cu().ToString()!=null) 
                    { 
                        ModificoUrl = negCue.CambiarURL((int)Session["IDStd"], "Recursos/Imagenes/usuarioGafas.png"); 
                    }
                    else {
                        ModificoUrl = negCue.CambiarURL((int)Session["IDAdmin"], "Recursos/Imagenes/usuarioGafas.png"); 
                    }
                    break;
                case 2:if(cuenta.GetIDRef_Cu() != 0 && cuenta.GetIDRef_Cu().ToString() != null) {
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
            if (!ModificoUrl) lblFallo.Visible = true;
            if (!ModificoNombre) lblFallo.Visible = true;
            if (!ModificoEdad) lblFallo.Visible=true;

            Session["IDStd"] = null;
           cuenta = negCue.GetByID((int)Session["IDAdmin"]); //vuelve el control ADMIN
           Session["Cuenta"] = cuenta;
            int cantMax = validarCantUsuariosMax(cuenta);
            if ((int)Session["CantidadUsuariosAdmin"] == 1 || (int)Session["CantidadUsuariosAdmin"] < cantMax) CargarImgAdmin(cuenta);//validamos que no tenga usuarios ese admin
            
           Response.Redirect("AdministrarUsuarios.aspx");
        }
        public void CargarImgAdmin(Cuenta cuenta)
        {
            string URLImagen;
            int IDadmin = (int)Session["IDAdmin"];
            URLImagen = cuenta.URLImagenDefault1;
            imgAdmin.ImageUrl = URLImagen;
            lblNombreAdmin.Text = cuenta.GetNombre_Cu();
            
        }


        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            MostrarMenuModificar();

        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {

            Response.Redirect("AgregarUsuario.aspx"); 


        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarUsuario.aspx");
        }
    }
}