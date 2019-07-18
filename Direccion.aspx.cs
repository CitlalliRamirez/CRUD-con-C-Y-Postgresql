using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace aplicacion1
{
    public partial class Direccion : System.Web.UI.Page
    {
        String cadena2;
        
        BaseDato reg2 = new BaseDato();
        DataTable dt3;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnGuardar2_Click(object sender, EventArgs e)
        {

            if (TxtCalle.Text != "" & Colon.Text != "" & Dele.Text != "" & Nume.Text != "")
            {
                try
                {
                    reg2.Conectar();

                    cadena2 = "SELECT * FROM direcciones ORDER BY id_dir DESC LIMIT 1";
                    reg2.CrearComando(cadena2);
                    reg2.Ejec();

                    dt3 = reg2.EjecutarDataTable();
                    if (dt3.Rows.Count > 0)
                    {
                        foreach (DataRow dbRow in dt3.Rows)
                        {
                           // MessageBox.Show(dbRow["id_dir"].ToString());
                            cadena2 = "UPDATE direcciones SET calle='"+TxtCalle.Text+"',colonia='"+Colon.Text+"',delegacion='"+Dele.Text+"',numero="+Nume.Text+" WHERE id_dir="+ dbRow["id_dir"].ToString();
                            reg2.CrearComando(cadena2);
                            reg2.Ejec();
                        }
                    }                                 
                    LblGuardar2.Text = "El registro se guardo correctamente";
                    TxtCalle.Text = "";
                    Colon.Text = "";
                    Dele.Text = "";
                    Nume.Text = "";                                     
                    reg2.Desconectar();
                    Response.Redirect("Usuario.aspx");

                }
                catch (Exception x)
                {
                    //MessageBox.Show(x.Message);
                }


            }
            else
            {
                LblGuardar2.Text = "Por favor completa los campos";
            }
        }
    }
}