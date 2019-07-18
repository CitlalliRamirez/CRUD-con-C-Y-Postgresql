using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows;
using Npgsql;

namespace aplicacion1
{

    public class BaseDato
    {

        public NpgsqlConnection con;
        public NpgsqlCommand cmd;
        private NpgsqlDataAdapter da;
        static DataTable dt;
        public void Conectar()
        {
            try
            {
                con = new NpgsqlConnection("Username=citla; Password= utm2019; Host=localhost;Port=5432; Database=warriors");
                con.Open();
                //MessageBox.Show("hecho");


            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

        }

        public void CrearComando(string consulta)
        {
            cmd = new NpgsqlCommand(consulta, con);
          
        }
        public void Ejec()
        {
            cmd.ExecuteNonQuery();
            
        }
       

        public void Desconectar()
        {
            con.Close();
        }
        public DataTable EjecutarDataTable()
        {
            dt = new DataTable();
            da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public void Eliminar(String n)
        {
            MessageBox.Show("eliminar");
        }
       
        
    }
}