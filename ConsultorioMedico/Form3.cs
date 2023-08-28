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
    // Definición de la clase Form3 que hereda de la clase Form
    public partial class Form3 : Form
    {
        // Creación de un objeto 'db' de la clase ConexionDB, inicializado con la ubicación de la base de datos 'ConsultorioMedico.db'
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));

        // Constructor de la clase Form3
        public Form3()
        {
            // Inicialización de los componentes de la interfaz gráfica
            InitializeComponent();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonNCit'
        private void botonNCit_Click(object sender, EventArgs e)
        {
            // Se crea una nueva instancia del formulario FormNCit y se muestra
            FormNCit formNCit = new FormNCit();
            formNCit.ShowDialog();
        }

        // Evento que se dispara cuando la fecha seleccionada en el control monthCalendar1 cambia
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Se abre la conexión a la base de datos
            db.AbrirConexion();
            // Se obtienen las citas para la fecha seleccionada y se asignan como origen de datos al dataGridView1
            dataGridView1.DataSource = db.GetCitaPorFecha(monthCalendar1.SelectionStart);
            // Se cierra la conexión a la base de datos
            db.CerrarConexion();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonModCit'
        private void botonModCit_Click(object sender, EventArgs e)
        {
            try
            {
                // Se obtiene el ID de la cita seleccionada en el dataGridView1
                int buscar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                // Se crea una nueva instancia del formulario FormModCita y se pasa el ID de la cita a modificar
                FormModCita formModCita = new FormModCita(buscar);
                // Se muestra el formulario formModCita
                formModCita.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha seleccionado una cita");
            }
        }

        // Evento que se dispara cuando se hace clic en el botón 'button3'
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Se obtiene el ID de la cita seleccionada en el dataGridView1
                int buscar = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                // Se abre la conexión a la base de datos
                db.AbrirConexion();
                // Se cancela la cita con el ID obtenido
                db.CancelarCita(buscar);
                // Se cierra la conexión a la base de datos
                db.CerrarConexion();
                // Se muestra un mensaje informando que la cita ha sido eliminada
                MessageBox.Show("Cita eliminada");
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha seleccionado una cita");
            }
        }
    }
}
