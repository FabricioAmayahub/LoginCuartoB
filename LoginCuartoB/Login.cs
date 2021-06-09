using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginCuartoB
{
    public partial class Login : Form
    {
        //cadena de coneccion siempre
        SqlConnection con = new SqlConnection ("Data Source=DESKTOP-K33EK4L;Initial Catalog = loginFSAG; Integrated Security = True");
        public Login()
        {
            InitializeComponent();
        }
    
     
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //llamamos al formulario registrar
            this.Hide();
            new Registrar().ShowDialog();
            this.Close();
        }
        
        private void logear(string nombre, string passw)
        {
            try
            {
                //es para ver si existe o no el usuario poner el con en command por eso solo cojo el usuario
                con.Open();
                SqlCommand cmd = new  SqlCommand("select * from Tbl_Usuario where usu_nomlogin= @nom  ", con);
                cmd.Parameters.AddWithValue("nom", nombre);// coji la variable de la sentencia y la del metodo  
                string nombreusu = nombre;//LO USU PARA CAPTURAR EL USUARIO DEL LOGIN
                
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 1)
                {
                    //comparamos datos
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select usu_nombre, tusu_id from Tbl_Usuario where usu_nomlogin= @nom and usu_password = @passw", con);
                    cmd1.Parameters.AddWithValue("nom", nombre);
                    cmd1.Parameters.AddWithValue("passw", passw);
                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable() ;
                    sda1.Fill(dt1);
                   
                    con.Close();
                    //vefirico si hay un dato
                    if (dt1.Rows.Count == 1)
                    {
                        this.Hide();
                        if (dt1.Rows[0][1].ToString() == "1")//
                        {
                            Admin capadmin = new Admin();
                            capadmin.lbl_admin.Text = nombreusu;
                            capadmin.ShowDialog();
                            //new Admin().ShowDialog();//show dialog muestra el formulario
                        }
                        else if (dt1.Rows[0][1].ToString() == "2")
                        {
                            Usuario capusu = new Usuario();//CAPTURO USU
                            capusu.lbl_BIENV_USU.Text = nombreusu;//al lbl lo hice publico 
                            capusu.ShowDialog();
                            //
                        }
                        this.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("USUARIO NO REGISTRADO");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("error al capturar una variable");
                throw;
            }
        }
        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            logear(txt_usu.Text, txt_pass.Text);
        }
    }
}
