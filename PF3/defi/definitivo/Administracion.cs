using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace definitivo
{
    

    public partial class Administracion : Form
    {
        static int A = 0;

        public Administracion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona usuarios = new Persona();

            A = 0;

                usuarios.usuario = txtUsuario.Text;
                usuarios.Contraseña = txtContra.Text;
                usuarios.Nombre = txtNombre.Text;
                usuarios.ap_paterno = txtApPA.Text;
                usuarios.ap_materno = txtApMA.Text;
                usuarios.Correo = txtCorreo.Text;
                usuarios.Tipo_usuario = txtTipoUsu.Text;


                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("Ingrese un usuario válido");
                }
                else
                {
                    A++;
                }

                if (string.IsNullOrEmpty(txtContra.Text))
                {
                    MessageBox.Show("Ingrese una contraseña válida");
                }
                else
                {
                    A++;
                }

                if (string.IsNullOrEmpty(txtNombre.Text) || txtNombre.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Ingrese un nombre válido");
                }
                else
                {
                    A++;
                }

                if (string.IsNullOrEmpty(txtApPA.Text) || txtApPA.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Ingrese un primer apellido válido");
                }
                else
                {
                    A++;
                }

                if (string.IsNullOrEmpty(txtApMA.Text) || txtApMA.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Ingrese un segundo apellido válido");
                }
                else
                {
                    A++;
                }

                if (string.IsNullOrEmpty(txtCorreo.Text) || !txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains(".com"))
                {
                    MessageBox.Show("Ingrese un correo válido");
                }
                else
                {
                    A++;
                }

                if (string.IsNullOrEmpty(txtTipoUsu.Text) || (!txtTipoUsu.Text.Contains("administrador") && !txtTipoUsu.Text.Contains("usuario")))
                {
                    MessageBox.Show("Ingrese un tipo de usuario válido");
                }
                else
                {
                    A++;
                }

   

           

            if (dataGridView1.SelectedRows.Count == 1)
            {


                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                if (ID != null)
                {
                    usuarios.ID = ID;
                    int result = PersonaDal.ModificarPersona(usuarios);

                    if (result > 0)
                    {
                        MessageBox.Show("Modificado exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar");
                    }
                }
            }
            else
            {
                if (A == 7)
                {
                    int result = PersonaDal.AgregarPersonal(usuarios);

                    if (result > 0)
                    {
                        MessageBox.Show("Guardado exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar");
                    }
                }
                else {
                    A = 0;
                }
            }
            refressPantalla();
        }

        private void Administracion_Load(object sender, EventArgs e)
        {
            refressPantalla();
            txtID.Enabled = false;
        }

        public void refressPantalla()
        {
            dataGridView1.DataSource = PersonaDal.PresentarRegistro();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           

    // Asigna los valores a los cuadros de texto
    txtID.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ID"].Value);
    txtUsuario.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["usuario"].Value);
    txtContra.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Contraseña"].Value);
    txtNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
    txtApPA.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ap_paterno"].Value);
    txtApMA.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ap_materno"].Value);
    txtCorreo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Correo"].Value);
    txtTipoUsu.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Tipo_usuario"].Value);

    // Valida los cuadros de texto
 

    // Si todos los campos son válidos, muestra un mensaje

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtUsuario.Clear();
            txtContra.Clear();
            txtNombre.Clear();
            txtApPA.Clear();
            txtApMA.Clear();
            txtCorreo.Clear();
            txtTipoUsu.Clear();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                int resultado = PersonaDal.EliminarPersonal(ID);
                if (resultado > 0)
                {
                    MessageBox.Show("Eliminado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar");
                }
            }
            refressPantalla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
