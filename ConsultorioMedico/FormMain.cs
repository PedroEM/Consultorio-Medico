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
    // Define la clase FormMain que hereda de la clase Form
    public partial class FormMain : Form
    {
        // Constructor de la clase
        public FormMain()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en el botón 'botonRegPac'
        private void botonRegPac_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario Form1 y la muestra
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        // Evento que se dispara al hacer clic en el botón 'botonConAcPac'
        private void botonConAcPac_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario Form2 y la muestra
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        // Evento que se dispara al hacer clic en el botón 'botonAgendaC'
        private void botonAgendaC_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario Form3 y la muestra
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.Show();
        }

        // Evento que se dispara al hacer clic en el botón 'botonHisCli'
        private void botonHisCli_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario Form4 y la muestra
            Form4 form4 = new Form4();
            form4.MdiParent = this;
            form4.Show();
        }

        // Evento que se dispara al hacer clic en el botón 'botonGenInf'
        private void botonGenInf_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario Form5 y la muestra
            Form5 form5 = new Form5();
            form5.MdiParent = this;
            form5.Show();
        }
    }
}
