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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private TipoSuscripcion tip = new TipoSuscripcion();
        private Cuenta cuenta = new Cuenta();
        private NegocioCuenta negCue = new NegocioCuenta();
        private NegocioSuscripcion negSuscripcion = new NegocioSuscripcion();
        private NegocioTipoSuscripcion tipoSus = new NegocioTipoSuscripcion();
        private Suscripcion sus = new Suscripcion();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            lblErrorPermiso.Visible = false;
            cuenta = (Cuenta)Session["Cuenta"];
            if (cuenta.GetSus_Cu().CodSus_Sus1 == 0)
            {
                Label1.Visible = false;
                Label2.Visible = false;
                txtPIN.Visible = false;
                lblErrorPermiso.Visible = true;
                btnPaquete.Visible = false;
                ddlSuscripciones.Visible = false;
                lblMensajeError.Visible = false;
                btnNo.Visible = false;
                btnSi.Visible = false;
                btnAceptar.Visible = false;
                lvSuscripciones.Visible = false;
                imgAlerta.Visible = false;
                lblAtencion.Visible = false;
                return;
            }
            RefrescarTipoSuscripcion();
            lblPlanActual.Text = "Tu plan actual es: " + (string)Session["NombreSus"];
            ddlSuscripciones.Visible = false;
            btnPaquete.Visible = false;
            Session["IDCuenta"] = cuenta.GetIDCuenta();
            if (!IsPostBack)
            {
                lblUserName.Text = cuenta.GetNombre_Cu();
                DataTable ds2 = negSuscripcion.getTabla();
                DataTable ds3 = tipoSus.getTabla();

                List<string> nombreS = new List<string>();
                List<string> idS = new List<string>();

                foreach (DataRow dr in ds2.Rows)
                {
                    idS.Add(dr["CodSus_Sus"].ToString());
                }
                foreach (DataRow dr in ds3.Rows)
                {
                    nombreS.Add(dr["Nombre_Ts"].ToString());
                }
                int i = 0;
                for (i = 0; i < 3; i++)
                {
                    ListItem item = new ListItem(nombreS[i], idS[i]);
                    ddlSuscripciones.Items.Add(item);
                }
                ddlSuscripciones.DataBind();
                nombreS.Clear();
                idS.Clear();
            }
        }

        protected void btnPaquete_Click(object sender, EventArgs e)
        {
            lblMensajePlan.Visible = true;
            if ((string)Session["NombreSus"] == ddlSuscripciones.SelectedItem.ToString())
            {
                lblMensajePlan.Text = ddlSuscripciones.SelectedItem + " ya es tu plan actual.";
                btnNo.Visible = false;
                btnSi.Visible = false;
                lblAtencion.Visible = false;
                imgAlerta.Visible = false;
            }
            else
            {
                lblMensajePlan.Text = "Esta seguro que desea cambiar su plan actual a " + ddlSuscripciones.SelectedItem + "?";
                btnSi.Visible = true;
                btnNo.Visible = true;
                lblAtencion.Visible = true;
                imgAlerta.Visible = true;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false;
            lblMensajePlan.Visible = false;
            lblMensajeError.Visible = false;
            imgAlerta.Visible = false;
            lblAtencion.Visible = false;
            btnSi.Visible = false;
            btnNo.Visible = false;
            if (negCue.ValidarPINS(cuenta, txtPIN.Text) && txtPIN.Text.Trim().Length != 0)
            {
                btnPaquete.Visible = true;
                ddlSuscripciones.Visible = true;
                Session["Cuenta"] = negCue.GetByID((int)Session["IDAdmin"]);
                lblMensajeError.Visible = false;
            }
            else
            {
                btnPaquete.Visible = false;
                ddlSuscripciones.Visible = false;
                lblMensajeError.Text = "*El PIN ingresado no es correcto";
                lblMensajeError.Visible = true;
            }
            txtPIN.Text = "";
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            cuenta = (Cuenta)Session["Cuenta"];
            negCue.CambiarPlan(Convert.ToInt32(ddlSuscripciones.SelectedValue), cuenta.GetEmail_Cu());
            Session["Cuenta"] = negCue.GetByID((int)Session["IDAdmin"]);
            lblPlanActual.Text = "Tu plan actual es: " + (string)Session["NombreSus"];
            btnNo.Visible = false;
            btnSi.Visible = false;
            lblAtencion.Visible = false;
            imgAlerta.Visible = false;
            Response.Redirect("Suscripciones.aspx");
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            btnPaquete.Visible = false;
            ddlSuscripciones.Visible = false;
            lblMensajeError.Visible = false;
            btnNo.Visible = false;
            btnSi.Visible = false;
            imgAlerta.Visible = false;
            lblAtencion.Visible = false;
            lblMensajePlan.Text = "Se ha cancelado la compra.";
            lblMensajePlan.Visible = true;
        }

        protected void cvDigitos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 4) args.IsValid = true;
            else args.IsValid = false;
        }

        protected void RefrescarTipoSuscripcion()
        {
            sus = negSuscripcion.Get(cuenta.GetSus_Cu().CodSus_Sus1);
            tip = tipoSus.Get(sus.CodTipo_Sus1.CodTipo_Ts1);

            Application["tipoSuscripcion"] = tip;
            Session["NombreSus"] = tip.Nombre_Ts1;
        }
    }
}