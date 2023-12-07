using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace definitivo
{
    public partial class Form1 : Form
    {

        private static string connectionString = @"Data Source =LAPTOP-BMBB8FBG\SQLEXPRESS;Initial Catalog=pou;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
         
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASE�A")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASE�A";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private bool CheckCredentials(string usuario, string contrase�a)
        {
            // Crear la conexi�n SQL.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el comando SQL.
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contrase�a = @Contrase�a", connection))
                {
                    // Agregar los par�metros al comando SQL.
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrase�a", contrase�a);

                    // Abrir la conexi�n y ejecutar el comando.
                    connection.Open();
                    int userCount = (int)command.ExecuteScalar();

                    // Si userCount es 1, entonces las credenciales son correctas.
                    return userCount == 1;
                }
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            string usuario = txtUser.Text;
            string contrase�a = txtPass.Text;
            if (CheckCredentials(usuario, contrase�a))
            {
                
                // Aqu� puedes abrir la siguiente ventana de tu aplicaci�n.
                // Aqu� puedes abrir la siguiente ventana de tu aplicaci�n.url, href, direct string link=    que sea bool 1 act 0 inact nueva tabla   verifica si es 0 o 1  lo muestra si lo es
                Menu Menu = new Menu();
                Menu.Show();//abriendo el formulario principal
                Hide();//esto sirve para ocultar el formulario de login
            }
            else
            {
                MessageBox.Show("Usuario o contrase�a incorrectos.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUser_Enter_1(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave_1(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter_1(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASE�A")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave_1(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASE�A";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }
    }

}