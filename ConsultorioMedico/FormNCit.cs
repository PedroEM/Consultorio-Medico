// Importa las bibliotecas necesarias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConsultorioMedico
{
    // Define la clase FormNCit que hereda de la clase Form
    public partial class FormNCit : Form
    {
        // Instancia de la clase ConexionDB
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));

        // Constructor de la clase
        public FormNCit()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en el botón 'botonBuscar'
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            // Abre la conexión a la base de datos
            db.AbrirConexion();

            // Busca el paciente y asigna los resultados al origen de datos del dataGridView1
            dataGridView1.DataSource = db.BuscarPaciente(textoBuscar.Text);

            // Cierra la conexión a la base de datos
            db.CerrarConexion();
        }

        // Evento que se dispara al hacer clic en el botón 'botonCreCit'
        private void botonCreCit_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre la conexión a la base de datos
                db.AbrirConexion();

                // Busca el paciente y asigna los resultados al origen de datos del dataGridView1
                dataGridView1.DataSource = db.BuscarPaciente(textoBuscar.Text);

                // Obtiene el ID del paciente seleccionado
                int idpaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                // Agrega una nueva cita para el paciente
                db.AddCita(idpaciente, FechaHora.Value, textoMotivo.Text);

                // Cierra la conexión a la base de datos
                db.CerrarConexion();

                // Cierra el formulario
                this.Close();
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error
                MessageBox.Show("Busque un paciente para crear la cita");
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
