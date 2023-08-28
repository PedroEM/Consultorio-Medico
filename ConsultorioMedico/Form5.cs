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
    // Definición de la clase Form5 que hereda de la clase Form
    public partial class Form5 : Form
    {
        // Creación de un objeto 'gi' de la clase GenerarInformes
        GenerarInformes gi = new GenerarInformes();

        // Constructor de la clase Form5
        public Form5()
        {
            // Inicialización de los componentes de la interfaz gráfica
            InitializeComponent();
        }

        // Evento que se dispara cuando se hace clic en el botón 'botonGInf'
        private void botonGInf_Click(object sender, EventArgs e)
        {
            try
            {
                // Se obtiene el tipo de informe seleccionado
                string tipo = informeT.Text;
                // Si el tipo de informe es 'PDF'
                if (tipo == "PDF")
                {
                    // Se llama al método GenerarInformePDF de la clase GenerarInformes, pasando el id del paciente
                    gi.GenerarInformePDF(Convert.ToInt32(idPaciente.Value));
                }
                // Si el tipo de informe es 'Excel'
                else if (tipo == "Excel")
                {
                    // Se llama al método GenerarInformeExcel de la clase GenerarInformes, pasando el id del paciente
                    gi.GenerarInformeExcel(Convert.ToInt32(idPaciente.Value));
                }
                MessageBox.Show("Informe generado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el informe");
            }
        }
    }
}
