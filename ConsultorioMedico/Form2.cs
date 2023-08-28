// Importación de las bibliotecas necesarias
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
    // Definición de la clase Form2 que hereda de la clase Form
    public partial class Form2 : Form
    {
        // Creación de un objeto 'db' de la clase ConexionDB, inicializado con la ubicación de la base de datos 'ConsultorioMedico.db'
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));
        // Declaración de la variable 'buscar' que almacenará el ID del paciente a buscar
        int buscar;

        // Constructor de la clase Form2
        public Form2()
        {
            // Inicialización de los componentes de la interfaz gráfica
            InitializeComponent();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonBuscar'
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            // Se abre la conexión a la base de datos
            db.AbrirConexion();
            // Se busca al paciente por el nombre ingresado y el resultado se asigna como origen de datos al dataGridView1
            dataGridView1.DataSource = db.BuscarPaciente(textBuscar.Text);
            // Se cierra la conexión a la base de datos
            db.CerrarConexion();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonActualizar'
        private void botonActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se obtiene el ID del paciente seleccionado en el dataGridView1
                this.buscar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                // Se crea una nueva instancia del formulario FormActualizarPac y se pasa el ID del paciente a actualizar
                FormActualizarPac formA = new FormActualizarPac(buscar);
                // Se muestra el formulario formA
                formA.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha seleccionado un paciente");
            }
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonEliminar'
        private void botonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se abre la conexión a la base de datos
                db.AbrirConexion();
                // Se obtiene el ID del paciente seleccionado en el dataGridView1
                this.buscar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                // Se borra al paciente con el ID obtenido
                db.BorrarPaciente(buscar);
                //Mensaje de confirmación
                MessageBox.Show("Paciente eliminado");
                // Se actualiza el origen de datos del dataGridView1 con la lista actual de pacientes
                dataGridView1.DataSource = db.GetPacientes();
                // Se cierra la conexión a la base de datos
                db.CerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha seleccionado un paciente");
            }
        }
    }
}
