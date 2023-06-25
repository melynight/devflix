using System;
using Entidades;
using Negocio;


namespace Vistas
{
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioCuenta negEliminar = new NegocioCuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            Cuenta cuenta = (Cuenta)Session["cuenta"];
            if (!IsPostBack)
                lblUserName.Text =  cuenta.GetNombre_Cu();
            

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Configuraciones.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblConfirmDelete.Visible = true;
                btnConfirmDelete.Visible = true;
                btnCancelDelete.Visible = true;
            }
        }
        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            Cuenta cuenta = (Cuenta)Session["cuenta"];
            negEliminar.EliminarCuenta(cuenta.GetIDCuenta());
            Response.Redirect("Log.aspx");
            
        }

        protected void cvErrorContrasenia_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            Cuenta cuenta = (Cuenta)Session["cuenta"];
            NegocioCuenta negValidar = new NegocioCuenta();
            string contra;
            contra = txtContraCuenta.Text;
            cuenta.SetClave_Cu(contra);
            args.IsValid = negValidar.validarContrasenia(cuenta);
        }

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            lblConfirmDelete.Visible = false;
            btnConfirmDelete.Visible = false;
            btnCancelDelete.Visible = false;
        }
    }
}