namespace Consulta_transaccion
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTransaccion = new System.Windows.Forms.TextBox();
            this.BtnCargar = new System.Windows.Forms.Button();
            this.dgViewConsulta = new System.Windows.Forms.DataGridView();
            this.BtnNuevaConsulta = new System.Windows.Forms.Button();
            this.SalirbuttonCte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transacción";
            // 
            // TxtTransaccion
            // 
            this.TxtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTransaccion.Location = new System.Drawing.Point(148, 40);
            this.TxtTransaccion.Name = "TxtTransaccion";
            this.TxtTransaccion.Size = new System.Drawing.Size(174, 31);
            this.TxtTransaccion.TabIndex = 1;
            // 
            // BtnCargar
            // 
            this.BtnCargar.Location = new System.Drawing.Point(359, 12);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(101, 80);
            this.BtnCargar.TabIndex = 2;
            this.BtnCargar.Text = "Generar consulta";
            this.BtnCargar.UseVisualStyleBackColor = true;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // dgViewConsulta
            // 
            this.dgViewConsulta.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgViewConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewConsulta.Location = new System.Drawing.Point(12, 123);
            this.dgViewConsulta.Name = "dgViewConsulta";
            this.dgViewConsulta.Size = new System.Drawing.Size(725, 150);
            this.dgViewConsulta.TabIndex = 3;
            // 
            // BtnNuevaConsulta
            // 
            this.BtnNuevaConsulta.Location = new System.Drawing.Point(496, 12);
            this.BtnNuevaConsulta.Name = "BtnNuevaConsulta";
            this.BtnNuevaConsulta.Size = new System.Drawing.Size(102, 80);
            this.BtnNuevaConsulta.TabIndex = 4;
            this.BtnNuevaConsulta.Text = "Nueva Consulta";
            this.BtnNuevaConsulta.UseVisualStyleBackColor = true;
            this.BtnNuevaConsulta.Click += new System.EventHandler(this.BtnNuevaConsulta_Click);
            // 
            // SalirbuttonCte
            // 
            this.SalirbuttonCte.Location = new System.Drawing.Point(634, 12);
            this.SalirbuttonCte.Name = "SalirbuttonCte";
            this.SalirbuttonCte.Size = new System.Drawing.Size(103, 80);
            this.SalirbuttonCte.TabIndex = 5;
            this.SalirbuttonCte.Text = "Salir";
            this.SalirbuttonCte.UseVisualStyleBackColor = true;
            this.SalirbuttonCte.Click += new System.EventHandler(this.SalirbuttonCte_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 569);
            this.Controls.Add(this.SalirbuttonCte);
            this.Controls.Add(this.BtnNuevaConsulta);
            this.Controls.Add(this.dgViewConsulta);
            this.Controls.Add(this.BtnCargar);
            this.Controls.Add(this.TxtTransaccion);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgViewConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTransaccion;
        private System.Windows.Forms.Button BtnCargar;
        private System.Windows.Forms.DataGridView dgViewConsulta;
        private System.Windows.Forms.Button BtnNuevaConsulta;
        private System.Windows.Forms.Button SalirbuttonCte;
    }
}

