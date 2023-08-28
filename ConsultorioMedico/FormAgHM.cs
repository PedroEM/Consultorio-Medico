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
    // Define la clase FormAgHM que hereda de la clase Form
    public partial class FormAgHM : Form
    {
        // Crea una instancia de ConexionDB para interactuar con la base de datos
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));

        // Constructor de la clase
        public FormAgHM()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
        }

        // Método que se ejecuta cuando se hace clic en el botón 'botonAgregar'
        private void botonAgregar_Click(object sender, EventArgs e)
        {
            // Abre la conexión a la base de datos
            db.AbrirConexion();
            // Intenta agregar la historia médica del paciente a la base de datos
            int result = db.AddHistoriaMedica(Convert.ToInt32(idPaciente.Value), fechaConsulta.Value, motivo.Text, detalleVisita.Text, estudioM.Text, MedSum.Text);
            // Cierra la conexión a la base de datos
            db.CerrarConexion();

            // Verifica si la operación fue exitosa
            if (result > 0)
            {
                // Si la operación fue exitosa, muestra un mensaje de confirmación
                MessageBox.Show("Historial médico agregado correctamente");
                // Cierra el formulario
                this.Close();
            }
            else
            {
                // Si la operación no fue exitosa, muestra un mensaje de error
                MessageBox.Show("Error al agregar historial médico");
            }
            // Cierra el formulario
            this.Close();
        }
    }
}
