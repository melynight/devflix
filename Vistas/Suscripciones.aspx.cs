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
        TipoSuscripcion tip = new TipoSuscripcion();
        Cuenta cuenta = new Cuenta();
        NegocioCuenta negCue = new NegocioCuenta();
        NegocioSuscripcion negSuscripcion = new NegocioSuscripcion();
        NegocioTipoSuscripcion tipoSus = new NegocioTipoSuscripcion();
        Suscripcion sus = new Suscripcion();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            cuenta = (Cuenta)Session["Cuenta"];

            ddlSuscripciones.Visible = false;
            btnPaquete.Visible = false;


            if (!IsPostBack)
            {
                lblBienvenidoUsuario.Text = "Bienvenid@ " + cuenta.GetNombre_Cu();
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
                foreach (DataRow dr in ds2.Rows)
                {
                    ListItem item = new ListItem(nombreS[i], idS[i]);
                    ddlSuscripciones.Items.Add(item);
                    i++;
                }
                ddlSuscripciones.DataBind();
                nombreS.Clear();
                idS.Clear();
            }

        }

        protected void btnPaquete_Click(object sender, EventArgs e)
        {
            bool cambio = false;
            cuenta = (Cuenta)Session["Cuenta"];
            cambio = negCue.CambiarPlan(Convert.ToInt32(ddlSuscripciones.SelectedValue), cuenta.GetEmail_Cu());
            Session["Cuenta"] = negCue.GetByID((int)Session["IDAdmin"]);
            lblMensajePlan.Text = "El cambio se ha realizado con exito!";
            /*if (Session["Cuenta"] != null)
            {
                sus = negSuscripcion.Get(cuenta.GetSus_Cu().CodSus_Sus1);
                tip = tipoSus.Get(sus.CodTipo_Sus1.CodTipo_Ts1);
                lblMensajePlan.Text = tip.Nombre_Ts1;
                cuenta.SetCodSus_Cu(sus);
                Session["Cuenta"] = cuenta;
            }
            else lblMensajePlan.Text = "es null";*/
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensajePlan.Text = "";
            lblMensajeError.Text = "El pin ingresado no es correcto o no tiene permisos";
            lblMensajeError.Visible = false;
            if (negCue.ValidarPINS(cuenta, txtPIN.Text))
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
                lblMensajeError.Visible = true;
            }
            txtPIN.Text = "";
        }
    }
}