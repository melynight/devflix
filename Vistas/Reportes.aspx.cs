﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Reportes : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioFacturacion negFacturacion = new NegocioFacturacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            cuenta = (Cuenta)Session["Cuenta"];
            lblError.Visible = false;

            grvFacturacion.Columns[2].Visible = false;
            grvFacturacion.Columns[3].Visible = false;

            if (!IsPostBack)
            {
                DataTable ds = negFacturacion.GetTabla(cuenta.GetIDCuenta());
                grvFacturacion.DataSource = ds;
                grvFacturacion.DataBind();
                lblUserName.Text = cuenta.GetNombre_Cu();
                grvFacturacion.Visible = false;
            }

        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFechaDesde.Text.Trim()) && !string.IsNullOrEmpty(txtFechaHasta.Text.Trim()))
            {
                lblError.Visible = false;
                grvFacturacion.Visible = true;
                foreach (GridViewRow row in grvFacturacion.Rows)
                {
                    row.Visible = true;
                }
                
                DataTable filtrado = negFacturacion.GetTablaFecha(Convert.ToDateTime(txtFechaDesde.Text), Convert.ToDateTime(txtFechaHasta.Text), cuenta.GetIDCuenta());
                grvFacturacion.DataSource = filtrado;
                grvFacturacion.DataBind();

            }
            else
            {
                lblError.Visible = true;

            }
               

        }


        protected void grvFacturacion_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grvFacturacion.Columns[2].Visible = true;
            grvFacturacion.Columns[3].Visible = true;

        }
        protected void grvFacturacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grvFacturacion.SelectedIndex > -1)
            {
                foreach (GridViewRow row in grvFacturacion.Rows)
                {
                    row.Visible = false;
                }

                grvFacturacion.SelectedRow.Visible = true;
            }
        }

        protected void grvFacturacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Visible = true;
                
            }

        }

        protected void btnHistorialTodo_Click(object sender, EventArgs e)
        {
            grvFacturacion.Visible = true;
            DataTable ds = negFacturacion.GetTabla(cuenta.GetIDCuenta());
            grvFacturacion.DataSource = ds;

            grvFacturacion.DataBind();
        }

        protected void grvFacturacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFacturacion.PageIndex = e.NewPageIndex;
            grvFacturacion.Visible = true;
            DataTable ds = negFacturacion.GetTabla(cuenta.GetIDCuenta());
            grvFacturacion.DataSource = ds;
            grvFacturacion.DataBind();
        }
    }
}