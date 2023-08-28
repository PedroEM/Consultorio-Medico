// Importación de bibliotecas necesarias
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
    // Definición de la clase principal del formulario
    public partial class Form1 : Form
    {
        // Creamos un objeto de la clase ConexionDB llamado 'db', y lo inicializamos con el camino al archivo de la base de datos
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));

        // Constructor del formulario principal
        public Form1()
        {
            // Inicializamos los componentes del formulario
            InitializeComponent();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonRegistrar'
        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            // Abrimos la conexión a la base de datos
            db.AbrirConexion();

            // Llamamos al método 'AddPaciente' de la clase ConexionDB, y pasamos como argumentos los valores ingresados en los campos de texto y seleccionados en los controles del formulario.
            // 'AddPaciente' devuelve un entero que indica el número de filas afectadas en la base de datos, y lo almacenamos en la variable 'result'.
            int result = db.AddPaciente(textNombre.Text, dateFechaNacimiento.Value, comboGenero.Text, textDireccion.Text, textContacto.Text);

            if (result > 0)
            {
                // Si el valor de 'result' es mayor que cero, significa que se insertó el registro correctamente, por lo que mostramos un mensaje de éxito.
                MessageBox.Show("Paciente registrado correctamente.");
            }
            else
            {
                // Si el valor de 'result' es cero, significa que no se insertó el registro, por lo que mostramos un mensaje de error.
                MessageBox.Show("Error al registrar paciente.");
            }

            // Cerramos la conexión a la base de datos
            db.CerrarConexion();

            // Cerramos el formulario
            this.Close();
        }
    }
}
