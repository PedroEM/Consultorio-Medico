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
    // Define la clase FormModCita que hereda de la clase Form
    public partial class FormModCita : Form
    {
        // Instancia de la clase ConexionDB
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));

        // Variable para almacenar el ID de la cita que se modificará
        int id;

        // Constructor de la clase que recibe el ID de la cita a modificar
        public FormModCita(int id)
        {
            // Inicializa los componentes del formulario
            InitializeComponent();

            // Almacena el ID de la cita que se pasó como parámetro en la variable de instancia
            this.id = id;
        }

        // Evento que se dispara al hacer clic en el botón 'botonMod'
        private void botonMod_Click(object sender, EventArgs e)
        {
            // Abre la conexión a la base de datos
            db.AbrirConexion();

            // Llama al método UpdateCita para actualizar la información de la cita en la base de datos
            db.UpdateCita(id, dateTimePicker1.Value, textoMotivo.Text);

            // Cierra la conexión a la base de datos
            db.CerrarConexion();

            // Cierra el formulario
            this.Close();
        }
    }
}
