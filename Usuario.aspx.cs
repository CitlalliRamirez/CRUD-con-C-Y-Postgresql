using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;
using System.Windows;

namespace aplicacion1
{
    public partial class Default : System.Web.UI.Page
    {

        public String dato2;
        String cadena;
        String cadena2;
        String id="";
        String quer;
        String html = "";
      
        BaseDato reg = new BaseDato();
        BaseDato reg2 = new BaseDato();
        BaseDato regM = new BaseDato();
        DataTable dt;
        DataTable dt2;
        ListItem ii;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            reg.Conectar();
            reg.CrearComando("SELECT * FROM usuarios");
            reg.Ejec();
            dt = reg.EjecutarDataTable();

            if (dt.Rows.Count > 0)
            {
                html += "<table class='table table-striped table-bordered'>";
                html += "<thead><tr><td>Nombre</td><td>Apellido paterno</td><td>Apellido Materno</td><td>Edad</td><td>Calle</td><td>Colonia</td><td>Delegación</td><td>Número</td></tr></thead>";
                html += "<tbody>";
                foreach (DataRow dbRow in dt.Rows )
                {
                    
                    html += "<tr>";
                    html += "<td>" + dbRow["nombre"].ToString() + "</td>";
                    html += "<td>" + dbRow["apellidop"].ToString() + "</td>";
                    html += "<td>" + dbRow["apellidom"].ToString() + "</td>";
                    html += "<td>" + dbRow["edad"].ToString() + "</td>";
                    
                    ii = new ListItem(dbRow["Nombre"].ToString());
                    
                    CmbRegistro.Items.Add(ii);
                    cadena2 = "SELECT * FROM direcciones WHERE id_nomb ="+ dbRow["id_nomb"].ToString();
                    reg.CrearComando(cadena2);
                    reg.Ejec();
                    dt2 = reg.EjecutarDataTable();
                    if (dt2.Rows.Count > 0)
                    {
                        foreach (DataRow dbRow2 in dt2.Rows)
                        {
                            html += "<td>" + dbRow2["calle"].ToString() + "</td>";
                            html += "<td>" + dbRow2["colonia"].ToString() + "</td>";
                            html += "<td>" + dbRow2["delegacion"].ToString() + "</td>";
                            html += "<td>" + dbRow2["numero"].ToString() + "</td>";
                        }
                    }

                    html += "</tr>";
                }
               
                html += "</tbody>";
                html += "</table>";
            }
            else
            {
                html += "<table class='table table-striped table-bordered'>";
                html += "<tr><td>No hay registros</td></tr>";
                html += "</table>";
            }
             Literal1.Text = html;
            reg.Desconectar();
        }
        

          protected void BtnGuardar_Click(object sender, EventArgs e)
          {
           
            if (Ed.Text != "" & TxtNombre.Text != "" & ApP.Text != "" & ApM.Text!=""){
                try
                {
                    reg.Conectar();
                    cadena = "INSERT INTO usuarios(nombre,apellidop,apellidom,edad) VALUES ('"+TxtNombre.Text+"','"+ApP.Text +"','"+ApM.Text+"',"+Ed.Text+")";
                    // MessageBox.Show(cadena);
                    reg.CrearComando(cadena);
                    reg.Ejec();
                    LblGuardar.Text = "El registro se guardo correctamente";
                    TxtNombre.Text = "";
                    ApP.Text = "";
                    ApM.Text = "";
                    Ed.Text = "";
                    cadena = "SELECT * FROM usuarios ORDER BY id_nomb DESC LIMIT 1";
                    reg.CrearComando(cadena);
                    reg.Ejec();
                    dt = reg.EjecutarDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dbRow in dt.Rows)
                        {
                            ////MessageBox.Show(dbRow["id_nomb"].ToString());
                            cadena= "INSERT INTO direcciones(id_nomb) VALUES ("+ dbRow["id_nomb"].ToString() + ")";
                            reg.CrearComando(cadena);
                            reg.Ejec();
                        }
                    }

                    
                    reg.Desconectar();
                    Response.Redirect("Direccion.aspx");
                }
                catch (Exception x)
                {
                    //MessageBox.Show(x.Message);
                }
                
              
            }else{
                  LblGuardar.Text = "Por favor completa los campos";
              }
          }



        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            
           
            if (CmbRegistro.Text != "")
            {

                
                reg.Conectar();
                cadena2 = "SELECT * FROM usuarios WHERE nombre='" + CmbRegistro.Text + "'";
                //MessageBox.Show(cadena2);
                reg.CrearComando(cadena2);
                reg.Ejec();
                dt = reg.EjecutarDataTable();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dbRow in dt.Rows)
                    {
                        
                        cadena = "DELETE FROM direcciones WHERE id_nomb=" + dbRow["id_nomb"].ToString();
                        reg.CrearComando(cadena);
                        reg.Ejec();
                    }
                }


                cadena2 = "DELETE FROM usuarios WHERE nombre ='"+ CmbRegistro.Text+"'";
                reg.CrearComando(cadena2);
                reg.Ejec();
                LblEliminar.Text = "El registro se elimino correctamente";
                reg.Desconectar();
                Response.Redirect("Usuario.aspx");

            }

        }



        protected void BtnModificar_Click(object sender, EventArgs e){

            if (CmbRegistro.Text != ""){

                reg.Conectar();
                cadena2 = "SELECT * FROM usuarios WHERE nombre='" + CmbRegistro.Text + "'";
                
                reg.CrearComando(cadena2);
                reg.Ejec();
                dt = reg.EjecutarDataTable();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dbRow in dt.Rows)
                    {
                        TxtNombre2.Text = dbRow["nombre"].ToString();
                        ApP2.Text = dbRow["apellidop"].ToString();
                        ApM2.Text = dbRow["apellidom"].ToString();
                        Ed2.Text = dbRow["edad"].ToString();
                        id = dbRow["id_nomb"].ToString();
                        cadena2 = "SELECT * FROM direcciones WHERE id_nomb="+ id;
                        reg.CrearComando(cadena2);
                        reg.Ejec();
                        dt = reg.EjecutarDataTable();
                        if (dt.Rows.Count>0)
                        {
                            foreach (DataRow dbRow2 in dt.Rows)
                            {
                                calle2.Text = dbRow2["calle"].ToString();
                                colonia2.Text = dbRow2["colonia"].ToString();
                                delega2.Text = dbRow2["delegacion"].ToString();
                                nume2.Text = dbRow2["numero"].ToString();
                            }
                        }
                    }
                }
                
                


            }

        }


        protected void BtnGuardarM_Click(object sender, EventArgs e)
        {
            //bsucando id
            reg2.Conectar();
            cadena = "SELECT * FROM usuarios WHERE nombre='" + CmbRegistro.Text + "'";
            reg2.CrearComando(cadena);
            reg2.Ejec();
            dt = reg2.EjecutarDataTable();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dbRow3 in dt.Rows)
                {
                    id = dbRow3["id_nomb"].ToString();
                }
            }

            
            if (id!="" & Ed2.Text != "" & TxtNombre2.Text != "" & ApP2.Text != "" & ApM2.Text != "" & calle2.Text != "" & colonia2.Text != "" & delega2.Text != "" & nume2.Text != "")
            {
                try
                {

                    regM.Conectar();
                    quer = "UPDATE usuarios SET nombre='" + TxtNombre2.Text + "',apellidop='" + ApP2.Text + "',apellidom='" + ApM2.Text + "',edad=" + Ed2.Text + " WHERE id_nomb=" + id;
                    //MessageBox.Show(quer);
                    regM.CrearComando(quer);
                    regM.Ejec();

                    quer = "UPDATE direcciones SET calle='" + calle2.Text + "', colonia='" + colonia2.Text + "',delegacion = '" + delega2.Text + "', numero=" + nume2.Text + " WHERE id_nomb=" + id;
                    regM.CrearComando(quer);
                    regM.Ejec();
                    //MessageBox.Show(quer);
                    LblGuardarM.Text = "El registro se guardo correctamente";
                    TxtNombre2.Text = "";
                    ApP2.Text = "";
                    ApM2.Text = "";
                    Ed2.Text = "";
                    calle2.Text = "";
                    colonia2.Text = "";
                    delega2.Text = "";
                    nume2.Text = "";

                    regM.Desconectar();
                    Response.Redirect("Usuario.aspx");
                }
                catch (Exception x)
                {
                    //MessageBox.Show(x.Message);
                }


            }
            else
            {
                LblGuardarM.Text = "Por favor completa los campos";
            }
        }



    }
}