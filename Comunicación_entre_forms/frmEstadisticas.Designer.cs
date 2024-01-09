namespace Comunicación_entre_forms
{
    partial class frmEstadisticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadisticas));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSociosTotales = new System.Windows.Forms.Button();
            this.btnFacturacionTotal = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(778, 505);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSociosTotales
            // 
            this.btnSociosTotales.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSociosTotales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSociosTotales.ForeColor = System.Drawing.Color.White;
            this.btnSociosTotales.Location = new System.Drawing.Point(552, 39);
            this.btnSociosTotales.Name = "btnSociosTotales";
            this.btnSociosTotales.Size = new System.Drawing.Size(213, 39);
            this.btnSociosTotales.TabIndex = 1;
            this.btnSociosTotales.Text = "Socios Totales";
            this.btnSociosTotales.UseVisualStyleBackColor = false;
            this.btnSociosTotales.Click += new System.EventHandler(this.btnSociosTotales_Click);
            // 
            // btnFacturacionTotal
            // 
            this.btnFacturacionTotal.BackColor = System.Drawing.Color.Navy;
            this.btnFacturacionTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFacturacionTotal.ForeColor = System.Drawing.Color.White;
            this.btnFacturacionTotal.Location = new System.Drawing.Point(552, 84);
            this.btnFacturacionTotal.Name = "btnFacturacionTotal";
            this.btnFacturacionTotal.Size = new System.Drawing.Size(213, 39);
            this.btnFacturacionTotal.TabIndex = 2;
            this.btnFacturacionTotal.Text = "Facturación";
            this.btnFacturacionTotal.UseVisualStyleBackColor = false;
            this.btnFacturacionTotal.Click += new System.EventHandler(this.btnFacturacionTotal_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Navy;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(552, 129);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(213, 39);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 502);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnFacturacionTotal);
            this.Controls.Add(this.btnSociosTotales);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmEstadisticas";
            this.Text = "frmEstadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnSociosTotales;
        private Button btnFacturacionTotal;
        private Button btnCerrar;
    }
}