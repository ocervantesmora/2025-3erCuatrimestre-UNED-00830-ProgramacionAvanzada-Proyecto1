namespace CervantesOscar_Proyecto1
{
    partial class frmRegistrarEquipos
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
            cmbJugador = new ComboBox();
            label1 = new Label();
            dgvEquipos = new DataGridView();
            dgvInventario = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtId = new MaskedTextBox();
            cmbCriatura1 = new ComboBox();
            cmbCriatura2 = new ComboBox();
            cmbCriatura3 = new ComboBox();
            btnRegistrar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // cmbJugador
            // 
            cmbJugador.FormattingEnabled = true;
            cmbJugador.Location = new Point(102, 33);
            cmbJugador.Name = "cmbJugador";
            cmbJugador.Size = new Size(271, 23);
            cmbJugador.TabIndex = 0;
            cmbJugador.SelectedIndexChanged += cmbJugador_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 36);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 1;
            label1.Text = "Jugador";
            // 
            // dgvEquipos
            // 
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(12, 77);
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.RowTemplate.Height = 25;
            dgvEquipos.Size = new Size(760, 218);
            dgvEquipos.TabIndex = 2;
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(12, 337);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.RowTemplate.Height = 25;
            dgvInventario.Size = new Size(423, 212);
            dgvInventario.TabIndex = 3;
            dgvInventario.CellFormatting += dgvInventario_CellFormatting;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(478, 379);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 4;
            label2.Text = "Id de Criatura";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(478, 424);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 5;
            label3.Text = "Id de Criatura";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(478, 465);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 6;
            label4.Text = "Id de Criatura";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(478, 337);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 7;
            label5.Text = "Id de equipo";
            // 
            // txtId
            // 
            txtId.Location = new Point(590, 334);
            txtId.Mask = "00000";
            txtId.Name = "txtId";
            txtId.Size = new Size(182, 23);
            txtId.TabIndex = 8;
            txtId.ValidatingType = typeof(int);
            // 
            // cmbCriatura1
            // 
            cmbCriatura1.FormattingEnabled = true;
            cmbCriatura1.Location = new Point(590, 376);
            cmbCriatura1.Name = "cmbCriatura1";
            cmbCriatura1.Size = new Size(182, 23);
            cmbCriatura1.TabIndex = 9;
            // 
            // cmbCriatura2
            // 
            cmbCriatura2.FormattingEnabled = true;
            cmbCriatura2.Location = new Point(590, 421);
            cmbCriatura2.Name = "cmbCriatura2";
            cmbCriatura2.Size = new Size(182, 23);
            cmbCriatura2.TabIndex = 10;
            // 
            // cmbCriatura3
            // 
            cmbCriatura3.FormattingEnabled = true;
            cmbCriatura3.Location = new Point(590, 462);
            cmbCriatura3.Name = "cmbCriatura3";
            cmbCriatura3.Size = new Size(182, 23);
            cmbCriatura3.TabIndex = 11;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(478, 516);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 12;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(697, 516);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 13;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmRegistrarEquipos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrar);
            Controls.Add(cmbCriatura3);
            Controls.Add(cmbCriatura2);
            Controls.Add(cmbCriatura1);
            Controls.Add(txtId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvInventario);
            Controls.Add(dgvEquipos);
            Controls.Add(label1);
            Controls.Add(cmbJugador);
            Name = "frmRegistrarEquipos";
            Text = "Equipos";
            Load += frmRegistrarEquipos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbJugador;
        private Label label1;
        private DataGridView dgvEquipos;
        private DataGridView dgvInventario;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private MaskedTextBox txtId;
        private ComboBox cmbCriatura1;
        private ComboBox cmbCriatura2;
        private ComboBox cmbCriatura3;
        private Button btnRegistrar;
        private Button btnVolver;
    }
}