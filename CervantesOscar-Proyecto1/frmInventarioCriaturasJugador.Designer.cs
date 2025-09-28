namespace CervantesOscar_Proyecto1
{
    partial class frmInventarioCriaturasJugador
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
            dgvCriaturas = new DataGridView();
            dgvCriaturasAdquiridas = new DataGridView();
            cmbJugadores = new ComboBox();
            label1 = new Label();
            btnAgregar = new Button();
            btnVolver = new Button();
            label2 = new Label();
            lblCristales = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCriaturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCriaturasAdquiridas).BeginInit();
            SuspendLayout();
            // 
            // dgvCriaturas
            // 
            dgvCriaturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCriaturas.Location = new Point(12, 50);
            dgvCriaturas.Name = "dgvCriaturas";
            dgvCriaturas.RowTemplate.Height = 25;
            dgvCriaturas.Size = new Size(760, 189);
            dgvCriaturas.TabIndex = 0;
            // 
            // dgvCriaturasAdquiridas
            // 
            dgvCriaturasAdquiridas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCriaturasAdquiridas.Location = new Point(12, 345);
            dgvCriaturasAdquiridas.Name = "dgvCriaturasAdquiridas";
            dgvCriaturasAdquiridas.RowTemplate.Height = 25;
            dgvCriaturasAdquiridas.Size = new Size(760, 204);
            dgvCriaturasAdquiridas.TabIndex = 1;
            dgvCriaturasAdquiridas.CellFormatting += dgvCriaturasAdquiridas_CellFormatting;
            // 
            // cmbJugadores
            // 
            cmbJugadores.FormattingEnabled = true;
            cmbJugadores.Location = new Point(77, 302);
            cmbJugadores.Name = "cmbJugadores";
            cmbJugadores.Size = new Size(199, 23);
            cmbJugadores.TabIndex = 2;
            cmbJugadores.SelectedIndexChanged += cmbJugadores_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 305);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 3;
            label1.Text = "Jugador";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(461, 255);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(133, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar al Inventario";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(639, 255);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(133, 23);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(309, 26);
            label2.Name = "label2";
            label2.Size = new Size(156, 21);
            label2.TabIndex = 6;
            label2.Text = "Criaturas disponibles";
            // 
            // lblCristales
            // 
            lblCristales.AutoSize = true;
            lblCristales.Location = new Point(351, 305);
            lblCristales.Name = "lblCristales";
            lblCristales.Size = new Size(57, 15);
            lblCristales.TabIndex = 7;
            lblCristales.Text = "Cristales: ";
            // 
            // frmInventarioCriaturasJugador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(lblCristales);
            Controls.Add(label2);
            Controls.Add(btnVolver);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(cmbJugadores);
            Controls.Add(dgvCriaturasAdquiridas);
            Controls.Add(dgvCriaturas);
            Name = "frmInventarioCriaturasJugador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Criaturas al Inventario";
            Load += frmInventarioCriaturasJugador_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCriaturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCriaturasAdquiridas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCriaturas;
        private DataGridView dgvCriaturasAdquiridas;
        private ComboBox cmbJugadores;
        private Label label1;
        private Button btnAgregar;
        private Button btnVolver;
        private Label label2;
        private Label lblCristales;
    }
}