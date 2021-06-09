using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//libreria de sql
using System.Text.RegularExpressions;//libreria correo
namespace LoginCuartoB
{
    public partial class Registrar : Form
    {
        //cadena de coneccion
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K33EK4L;Initial Catalog=loginFSAG;Integrated Security=True");
        public Registrar()
        {
            InitializeComponent();
        }
        // metodo para limpiar
        private void limpiar()
        {
            txt_nombre.Text = txt_cedula.Text = txt_direccion.Text = txt_nick.Text = txt_contraseña.Text = txt_correo.Text = "";
            cmb_tipousuario.Text = "";
        }
        private void cargar_tusu()
        {
            try
            {
                //abrimos coneccion
                con.Open();
                SqlCommand cmd = new SqlCommand("select tusu_id, tusu_nombre from Tbl_TipoUsuario where tusu_estado= 'A'",con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Columns.Add("tusu_id", typeof(int));
                dt.Columns.Add("tusu_nombre", typeof(string));
                dt.Rows.Add(0, "SELECCIONE");
                sda.Fill(dt);
                con.Close();
                //coje los datos dt o tabla
                cmb_tipousuario.DataSource = dt;
                cmb_tipousuario.DisplayMember = "tusu_nombre";
                cmb_tipousuario.ValueMember = "tusu_id";

            
            }
            catch (Exception )
            {
                MessageBox.Show( "Error al cargar usuario");
                throw;
            }
        } 
        private void Registrar_Load(object sender, EventArgs e)
        {
            btn_registrar.Enabled = false;
            //cargo mi metodo
            cargar_tusu();
            

        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            //muestra el formulario del login
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }
        private void validar_camposvacios()
        {

            var vr = !string.IsNullOrEmpty(txt_nombre.Text) &&
                     !string.IsNullOrEmpty(txt_cedula.Text) &&
                     !string.IsNullOrEmpty(txt_nick.Text) &&
                     !string.IsNullOrEmpty(txt_contraseña.Text) &&
                     !string.IsNullOrEmpty(txt_direccion.Text) &&
                     !string.IsNullOrEmpty(txt_correo.Text);
                
            btn_registrar.Enabled = vr; 
        }
     
        private void btn_registrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                // siempre tienen q igresar los valores tal y como esta en la base de datos y tener autoincrementable igual
                con.Open();

                string query = "insert into Tbl_Usuario values ( @nombre,@cedula,@nick,@contraseña,@direccion,@correo,'A',@tusu)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nombre", txt_nombre.Text.Trim());
                cmd.Parameters.AddWithValue("@cedula", txt_cedula.Text.Trim());
                cmd.Parameters.AddWithValue("@nick", txt_nick.Text.Trim());
                cmd.Parameters.AddWithValue("@contraseña", txt_contraseña.Text.Trim());
                cmd.Parameters.AddWithValue("@direccion", txt_direccion.Text.Trim());
                cmd.Parameters.AddWithValue("@correo", txt_correo.Text.Trim());
                cmd.Parameters.AddWithValue("@tusu", Convert.ToInt32 (cmb_tipousuario.SelectedValue));              
                cmd.ExecuteNonQuery();//ejecuta el query
                
                validar_camposvacios();
               
                MessageBox.Show("USUARIO REGISTRADO");
                
                
                limpiar();





            }
            catch (Exception ex)
            {
                
                throw;  
            }
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            validar_camposvacios();
        }

        private void txt_cedula_TextChanged(object sender, EventArgs e)
        {
            validar_camposvacios();
        }

        private void txt_nick_TextChanged(object sender, EventArgs e)
        {
            validar_camposvacios();
        }

        private void txt_contraseña_TextChanged(object sender, EventArgs e)
        {
            validar_camposvacios();
        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {
            validar_camposvacios();
        }

        private void txt_correo_TextChanged(object sender, EventArgs e)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(txt_correo.Text,expresion))
            {
                error_correo.Clear();
            }
            else
            {
                error_correo.SetError(this.txt_correo,"INGRESE UN CORREO VALIDO");
            }
            validar_camposvacios();
        }
    }
}
