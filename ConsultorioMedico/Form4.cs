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
    // Definición de la clase Form4 que hereda de la clase Form
    public partial class Form4 : Form
    {
        // Creación de un objeto 'db' de la clase ConexionDB, inicializado con la ubicación de la base de datos 'ConsultorioMedico.db'
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));

        // Constructor de la clase Form4
        public Form4()
        {
            // Inicialización de los componentes de la interfaz gráfica
            InitializeComponent();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonBuscar'
        private void botonBuscar_Click(object sender, EventArgs e)
        {
            // Se abre la conexión a la base de datos
            db.AbrirConexion();
            // Se obtiene la historia médica del paciente ingresado y se asigna como origen de datos al dataGridView1
            dataGridView1.DataSource = db.GetHistoriaMedica(textBox1.Text);
            // Se cierra la conexión a la base de datos
            db.CerrarConexion();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonAgregar'
        private void botonAgregar_Click(object sender, EventArgs e)
        {
            // Se crea una nueva instancia del formulario FormAgHM y se muestra
            FormAgHM form = new FormAgHM();
            form.ShowDialog();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonAc'
        private void botonAc_Click(object sender, EventArgs e)
        {
            try
            {
                // Se obtiene el ID de la historia médica seleccionada en el dataGridView1
                FormActHM form = new FormActHM(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                // Se muestra el formulario formActHM
                form.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha seleccionado una historia médica");
            }
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonEliminar'
        private void botonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se abre la conexión a la base de datos
                db.AbrirConexion();
                // Se elimina la historia médica con el ID obtenido y se guarda el resultado de la operación
                int result = db.BorrarHistoriaMedica(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                // Se cierra la conexión a la base de datos
                db.CerrarConexion();
                // Si el resultado de la operación es mayor que 0, significa que la historia médica fue eliminada correctamente
                if (result > 0)
                {
                    // Se muestra un mensaje informando que la historia médica ha sido eliminada correctamente
                    MessageBox.Show("Historia médica eliminada correctamente", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Se abre la conexión a la base de datos
                    db.AbrirConexion();
                    // Se actualiza la vista de las historias médicas del paciente ingresado
                    dataGridView1.DataSource = db.GetHistoriaMedica(textBox1.Text);
                    // Se cierra la conexión a la base de datos
                    db.CerrarConexion();
                }
                else
                {
                    // Si el resultado de la operación es 0 o negativo, significa que hubo un error al intentar eliminar la historia médica
                    // Se muestra un mensaje informando que no se pudo eliminar la historia médica
                    MessageBox.Show("No se pudo eliminar la historia médica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                // Si se produce una excepción, se muestra un mensaje informando que no se ha seleccionado una historia médica
                MessageBox.Show("No se ha seleccionado una historia médica");
            }
        }
    }
}
