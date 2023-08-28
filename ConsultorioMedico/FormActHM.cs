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
    // Definición de la clase FormActHM que hereda de la clase Form
    public partial class FormActHM : Form
    {
        // Creación de un objeto 'db' de la clase ConexionDB
        // Esta clase representa la conexión con la base de datos.
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));

        // Creación de una variable de instancia 'id'
        int id;

        // Constructor de la clase FormActHM
        public FormActHM(int id)
        {
            // Inicialización de los componentes de la interfaz gráfica
            InitializeComponent();

            // Asignación del parámetro 'id' a la variable de instancia 'id'
            this.id = id;
        }

        // Método que se ejecuta cuando se hace clic en el botón 'botonActualizar'
        private void botonActualizar_Click(object sender, EventArgs e)
        {
            // Se abre la conexión con la base de datos
            db.AbrirConexion();

            // Se intenta actualizar la historia médica y se almacena el resultado
            int result = db.UpdateHistoriaMedica(id, dateTimePicker1.Value, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            // Se cierra la conexión con la base de datos
            db.CerrarConexion();

            // Si el resultado es positivo
            if (result > 0)
            {
                // Se muestra un mensaje indicando que la actualización fue exitosa
                MessageBox.Show("Historia médica actualizada correctamente", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Se cierra el formulario
                this.Close();
            }
            else
            {
                // Si el resultado es negativo, se muestra un mensaje indicando que hubo un error
                MessageBox.Show("No se pudo actualizar la historia médica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
