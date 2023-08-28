namespace ConsultorioMedico
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.botonRegPac = new System.Windows.Forms.ToolStripButton();
            this.botonConAcPac = new System.Windows.Forms.ToolStripButton();
            this.botonAgendaC = new System.Windows.Forms.ToolStripButton();
            this.botonHisCli = new System.Windows.Forms.ToolStripButton();
            this.botonGenInf = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Teal;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonRegPac,
            this.botonConAcPac,
            this.botonAgendaC,
            this.botonHisCli,
            this.botonGenInf});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(959, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // botonRegPac
            // 
            this.botonRegPac.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.botonRegPac.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonRegPac.Name = "botonRegPac";
            this.botonRegPac.Size = new System.Drawing.Size(105, 22);
            this.botonRegPac.Text = "Registrar paciente";
            this.botonRegPac.Click += new System.EventHandler(this.botonRegPac_Click);
            // 
            // botonConAcPac
            // 
            this.botonConAcPac.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.botonConAcPac.Image = ((System.Drawing.Image)(resources.GetObject("botonConAcPac.Image")));
            this.botonConAcPac.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonConAcPac.Name = "botonConAcPac";
            this.botonConAcPac.Size = new System.Drawing.Size(210, 22);
            this.botonConAcPac.Text = "Consulta y Actualización de pacientes";
            this.botonConAcPac.ToolTipText = "Consulta y Actualización de pacientes";
            this.botonConAcPac.Click += new System.EventHandler(this.botonConAcPac_Click);
            // 
            // botonAgendaC
            // 
            this.botonAgendaC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.botonAgendaC.Image = ((System.Drawing.Image)(resources.GetObject("botonAgendaC.Image")));
            this.botonAgendaC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonAgendaC.Name = "botonAgendaC";
            this.botonAgendaC.Size = new System.Drawing.Size(95, 22);
            this.botonAgendaC.Text = "Agenda de citas";
            this.botonAgendaC.Click += new System.EventHandler(this.botonAgendaC_Click);
            // 
            // botonHisCli
            // 
            this.botonHisCli.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.botonHisCli.Image = ((System.Drawing.Image)(resources.GetObject("botonHisCli.Image")));
            this.botonHisCli.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonHisCli.Name = "botonHisCli";
            this.botonHisCli.Size = new System.Drawing.Size(89, 22);
            this.botonHisCli.Text = "Historia clínica";
            this.botonHisCli.Click += new System.EventHandler(this.botonHisCli_Click);
            // 
            // botonGenInf
            // 
            this.botonGenInf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.botonGenInf.Image = ((System.Drawing.Image)(resources.GetObject("botonGenInf.Image")));
            this.botonGenInf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonGenInf.Name = "botonGenInf";
            this.botonGenInf.Size = new System.Drawing.Size(97, 22);
            this.botonGenInf.Text = "Generar informe";
            this.botonGenInf.Click += new System.EventHandler(this.botonGenInf_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::ConsultorioMedico.Properties.Resources.Fondo1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(959, 486);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "Mateconburrito HC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton botonRegPac;
        private System.Windows.Forms.ToolStripButton botonConAcPac;
        private System.Windows.Forms.ToolStripButton botonAgendaC;
        private System.Windows.Forms.ToolStripButton botonHisCli;
        private System.Windows.Forms.ToolStripButton botonGenInf;
    }
}

