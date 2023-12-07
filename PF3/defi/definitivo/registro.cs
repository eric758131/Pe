using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace definitivo
{

    public partial class registro : Form
    {
        static int O = 0;
        public registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegVehiculo multa = new RegVehiculo();

            O = 0;
            multa.Placa = txtPlaca.Text;
            multa.Modelo = txtModelo.Text;
            multa.Marca = txtMarca.Text;
            multa.Color = txtColor.Text;
            multa.Fecha = txtFecha.Text;
            multa.Lugar = txtLugar.Text;
            multa.Descripcion = txtDescip.Text;
            multa.Total = txtTotal.Text;

            Regex placaRegex = new Regex(@"^\d{4}[A-Za-z]{3}$");
            List<string> marcasPermitidas = new List<string>
{
    "Suzuki", "Toyota", "Nissan", "Ford", "BMW",
    "Mercedes", "Audi", "Lexus", "Renault", "Opel", "Seat"
};
            string marcaIngresada = txtMarca.Text.Trim();

            if (string.IsNullOrEmpty(txtPlaca.Text) || !placaRegex.IsMatch(txtPlaca.Text))
            {
                MessageBox.Show("Ingrese una placa válida");
            }
            else
            {
                O++;
            }

            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("Ingrese un modelo válido");
            }
            else
            {
                O++;
            }

            if (string.IsNullOrEmpty(txtMarca.Text) || !marcasPermitidas.Contains(marcaIngresada))
            {
                MessageBox.Show("Ingrese una marca válida");
            }
            else
            {
                O++;
            }

            if (string.IsNullOrEmpty(txtColor.Text))
            {
                MessageBox.Show("Ingrese un color válido");
            }
            else
            {
                O++;
            }

            if (string.IsNullOrEmpty(txtFecha.Text) || !txtFecha.Text.All(char.IsDigit) || !txtFecha.Text.Contains("/"))
            {
                MessageBox.Show("Ingrese una fecha válida");
            }
            else
            {
                O++;
            }

            if (string.IsNullOrEmpty(txtLugar.Text))
            {
                MessageBox.Show("Ingrese un lugar válido");
            }
            else
            {
                O++;
            }

            if (string.IsNullOrEmpty(txtDescip.Text))
            {
                MessageBox.Show("Ingrese una descripción válida");
            }
            else
            {
                O++;
            }

            if (string.IsNullOrEmpty(txtTotal.Text) || txtTotal.Text.All(char.IsDigit))
            {
                MessageBox.Show("Ingrese un monto válido");
            }
            else
            {
                O++;
            }


            if (dataGridView1.SelectedRows.Count == 1)
            {


                int Remision = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Remision"].Value);
                if (Remision != null)
                {
                    multa.Remision = Remision;
                    int result = RegVehiculoDal.ModificarVehiculo(multa);

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
                if (O == 8)
                {
                    int result = RegVehiculoDal.Agregarmulta(multa);

                    if (result > 0)
                    {
                        MessageBox.Show("Guardado exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar");
                    }
                }
            }
            refressPantalla();
        }

        private void registro_Load(object sender, EventArgs e)
        {
            refressPantalla();
            txtRemi.Enabled = false;
        }
        public void refressPantalla()
        {
            dataGridView1.DataSource = RegVehiculoDal.PresentarRegVehiculo();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtRemi.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Remision"].Value);
            txtPlaca.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Placa"].Value);
            txtModelo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
            txtMarca.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Marca"].Value);
            txtColor.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Color"].Value);
            txtFecha.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Fecha"].Value);
            txtLugar.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Lugar"].Value);
            txtDescip.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Descripcion"].Value);
            txtTotal.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Total"].Value);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtRemi.Clear();
            txtPlaca.Clear();
            txtModelo.Clear();
            txtMarca.Clear();
            txtColor.Clear();
            txtFecha.Clear();
            txtLugar.Clear();
            txtDescip.Clear();
            txtTotal.Clear();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int Remision = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Remision"].Value);
                int resultado = RegVehiculoDal.EliminarVehiculo(Remision);
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

