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
{
    public partial class Registro : System.Web.UI.Page
    {
        Cuenta cuenta = new Cuenta();
        NegocioCuenta negCue = new NegocioCuenta();
        NegocioPais negPais = new NegocioPais();
        NegocioSuscripcion negSuscripcion = new NegocioSuscripcion();
        NegocioTipoSuscripcion tipoSus = new NegocioTipoSuscripcion();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                DataTable ds = negPais.getTabla();

                foreach (DataRow dr in ds.Rows)
                {
                    string idp = dr["IDPais_PA"].ToString(); 
                    string nombrep = dr["Nombre_PA"].ToString(); 
                    ListItem item = new ListItem(nombrep, idp);
                    ddlPaises.Items.Add(item);
                }

                ddlPaises.DataBind();

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
                    nombreS.Add( dr["Nombre_Ts"].ToString());
                    
                }
                int i = 0;
                foreach (DataRow dr in ds2.Rows)
                {
                    ListItem item = new ListItem(nombreS[i], idS[i]);
                    ddlSuscripcion.Items.Add(item);
                    i++;
                }

                ddlSuscripcion.DataBind();
                nombreS.Clear();
                idS.Clear();
            }
        }




        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            bool AgregadoCorrectamente = false;

            Paises pais = new Paises();
            Suscripcion sus = new Suscripcion();
            NegocioSuscripcion negSus = new NegocioSuscripcion();
            TipoSuscripcion tip = new TipoSuscripcion();
            NegocioTipoSuscripcion negTipo = new NegocioTipoSuscripcion();
            pais.Nombre_PA1 = ddlPaises.SelectedItem.Text; ;
            pais.IDPais_PA1 = ddlPaises.SelectedValue; ;

            int codigoSus = Convert.ToInt32(ddlSuscripcion.SelectedValue);
            sus = negSus.Get(codigoSus);
            tip= negTipo.GetxNombre(ddlSuscripcion.SelectedItem.Text);


            cuenta.SetEmail_Cu(txtConfirmarEmail.Text.Trim().ToLower());
            cuenta.SetClave_Cu(txtClave.Text);
            cuenta.SetEdad_Cu(Convert.ToInt32(txtEdad.Text));
            cuenta.SetEstado_Cu(true);
            cuenta.SetCodSus_Cu(sus);
            cuenta.Set_Pais_Cu(pais); 
            cuenta.SetNombre_Cu(txtNombre.Text.Trim().ToLower());
            cuenta.SetNROTarjeta_Cu(txtNroTarjeta.Text.Trim().ToLower());
            cuenta.SetPIN_Cu(txtPIN.Text.Trim().ToLower());
            cuenta.URLImagenDefault1 = "Recursos/Imagenes/usuario.png";
            Session["EdadUsuario"] =  cuenta.GetEdad_Cu();
            //La fecha se setea automaticamente como el id



            AgregadoCorrectamente = negCue.AgregarCuenta(cuenta);
            if (!AgregadoCorrectamente)
            {
                lblError.Visible = true;
                return;
            }
            
            lblError.Visible = false;

            int ID = negCue.GetIDUltimaCuenta(cuenta);
            Session["Cuenta"] = negCue.GetByID(ID);

            Application["tipoSuscripcion"] = tip;
            Session["NombreSus"] = tip.Nombre_Ts1;
            Session["IDAdmin"] = cuenta.GetIDCuenta();

            txtEmail.Text = "";
            txtNombre.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            txtConfirmarEmail.Text = "";
            txtEdad.Text = "";
            txtNroTarjeta.Text = "";
            txtPIN.Text = "";
            Session["IDAdmin"] = cuenta.GetIDCuenta();
            Response.Redirect("SeleccionarUsuario.aspx");
        }
    }
}