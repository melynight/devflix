﻿using System;
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
            lblMensajePlan.Visible = true;
            lblMensajePlan.Text = "Esta seguro que desea cambiar su plan actual a " + ddlSuscripciones.SelectedItem + "?";
            btnSi.Visible = true;
            btnNo.Visible = true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false;
            lblMensajePlan.Visible = false;
            lblMensajeError.Visible = false;
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
                lblMensajeError.Text = "*El PIN ingresado no es correcto o no tiene permisos";
                lblMensajeError.Visible = true;
            }
            txtPIN.Text = "";
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            cuenta = (Cuenta)Session["Cuenta"];
            negCue.CambiarPlan(Convert.ToInt32(ddlSuscripciones.SelectedValue), cuenta.GetEmail_Cu());
            Session["Cuenta"] = negCue.GetByID((int)Session["IDAdmin"]);
            lblMensajePlan.Text = "El cambio se ha realizado con exito!";
            btnNo.Visible = false;
            btnSi.Visible = false;
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            btnPaquete.Visible = false;
            ddlSuscripciones.Visible = false;
            lblMensajeError.Visible = false;
            btnNo.Visible = false;
            btnSi.Visible = false;
            lblMensajePlan.Text = "Se ha cancelado la compra.";
            lblMensajePlan.Visible = true;
        }

        protected void cvDigitos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 4) args.IsValid = true;
            else args.IsValid = false;
        }
    }
}