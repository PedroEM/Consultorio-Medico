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

namespace ConsultorioMedico
{
    // Definición de la clase FormActualizarPac que hereda de la clase Form
    public partial class FormActualizarPac : Form
    {
        // Crea una instancia de ConexionDB para interactuar con la base de datos
        ConexionDB db = new ConexionDB("consultorio.db");

        // Crea una variable para almacenar el ID del paciente a actualizar
        int buscar;

        // Constructor de la clase que acepta el ID del paciente a actualizar
        public FormActualizarPac(int buscar)
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
            // Guarda el ID del paciente
            this.buscar = buscar;
        }

        // Método que se ejecuta al hacer clic en el botón 'botonActualizar'
        private void botonActualizar_Click(object sender, EventArgs e)
        {
            // Abre la conexión a la base de datos
            db.AbrirConexion();
            // Actualiza la información del paciente en la base de datos
            db.UpdatePaciente(buscar, textNombre.Text, dateFechaNacimiento.Value, comboGenero.Text, textDireccion.Text, textContacto.Text);
            // Cierra la conexión a la base de datos
            db.CerrarConexion();
            // Muestra un mensaje de confirmación
            MessageBox.Show("Paciente actualizado correctamente");
            // Cierra el formulario
            this.Close();
        }
    }
}
