namespace CervantesOscar_Proyecto1
{
    partial class frmRegistrarBatallas
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
            label1 = new Label();
            txtId = new MaskedTextBox();
            label2 = new Label();
            label3 = new Label();
            cmbJugador1 = new ComboBox();
            cmbEquipo1 = new ComboBox();
            dgvEquipo1 = new DataGridView();
            dgvEquipo2 = new DataGridView();
            cmbEquipo2 = new ComboBox();
            cmbJugador2 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            btnRegistrar = new Button();
            btnVolver = new Button();
            dgvBatallas = new DataGridView();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEquipo1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquipo2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBatallas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 268);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 0;
            label1.Text = "Id de batalla";
            // 
            // txtId
            // 
            txtId.Location = new Point(359, 265);
            txtId.Mask = "00000";
            txtId.Name = "txtId";
            txtId.Size = new Size(144, 23);
            txtId.TabIndex = 1;
            txtId.ValidatingType = typeof(int);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 291);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Jugador 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 338);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 3;
            label3.Text = "Equipo";
            // 
            // cmbJugador1
            // 
            cmbJugador1.FormattingEnabled = true;
            cmbJugador1.Location = new Point(148, 288);
            cmbJugador1.Name = "cmbJugador1";
            cmbJugador1.Size = new Size(139, 23);
            cmbJugador1.TabIndex = 4;
            cmbJugador1.SelectedIndexChanged += cmbJugador1_SelectedIndexChanged;
            // 
            // cmbEquipo1
            // 
            cmbEquipo1.FormattingEnabled = true;
            cmbEquipo1.Location = new Point(148, 335);
            cmbEquipo1.Name = "cmbEquipo1";
            cmbEquipo1.Size = new Size(139, 23);
            cmbEquipo1.TabIndex = 5;
            cmbEquipo1.SelectedIndexChanged += cmbEquipo1_SelectedIndexChanged;
            // 
            // dgvEquipo1
            // 
            dgvEquipo1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipo1.Location = new Point(12, 387);
            dgvEquipo1.Name = "dgvEquipo1";
            dgvEquipo1.RowTemplate.Height = 25;
            dgvEquipo1.Size = new Size(344, 112);
            dgvEquipo1.TabIndex = 6;
            dgvEquipo1.CellFormatting += dgvEquipo1_CellFormatting;
            // 
            // dgvEquipo2
            // 
            dgvEquipo2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipo2.Location = new Point(428, 387);
            dgvEquipo2.Name = "dgvEquipo2";
            dgvEquipo2.RowTemplate.Height = 25;
            dgvEquipo2.Size = new Size(344, 112);
            dgvEquipo2.TabIndex = 11;
            dgvEquipo2.CellFormatting += dgvEquipo2_CellFormatting;
            // 
            // cmbEquipo2
            // 
            cmbEquipo2.FormattingEnabled = true;
            cmbEquipo2.Location = new Point(566, 335);
            cmbEquipo2.Name = "cmbEquipo2";
            cmbEquipo2.Size = new Size(139, 23);
            cmbEquipo2.TabIndex = 10;
            cmbEquipo2.SelectedIndexChanged += cmbEquipo2_SelectedIndexChanged;
            // 
            // cmbJugador2
            // 
            cmbJugador2.FormattingEnabled = true;
            cmbJugador2.Location = new Point(566, 288);
            cmbJugador2.Name = "cmbJugador2";
            cmbJugador2.Size = new Size(139, 23);
            cmbJugador2.TabIndex = 9;
            cmbJugador2.SelectedIndexChanged += cmbJugador2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(488, 338);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 8;
            label4.Text = "Equipo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(488, 291);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 7;
            label5.Text = "Jugador 2";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(281, 526);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 12;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(428, 526);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 13;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // dgvBatallas
            // 
            dgvBatallas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBatallas.Location = new Point(12, 33);
            dgvBatallas.Name = "dgvBatallas";
            dgvBatallas.RowTemplate.Height = 25;
            dgvBatallas.Size = new Size(760, 168);
            dgvBatallas.TabIndex = 14;
            dgvBatallas.CellFormatting += dgvBatallas_CellFormatting;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(325, 226);
            label6.Name = "label6";
            label6.Size = new Size(144, 21);
            label6.TabIndex = 15;
            label6.Text = "Crear nueva batalla";
            // 
            // frmRegistrarBatallas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(label6);
            Controls.Add(dgvBatallas);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrar);
            Controls.Add(dgvEquipo2);
            Controls.Add(cmbEquipo2);
            Controls.Add(cmbJugador2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(dgvEquipo1);
            Controls.Add(cmbEquipo1);
            Controls.Add(cmbJugador1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "frmRegistrarBatallas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Batallas";
            Load += frmRegistrarBatallas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipo1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquipo2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBatallas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MaskedTextBox txtId;
        private Label label2;
        private Label label3;
        private ComboBox cmbJugador1;
        private ComboBox cmbEquipo1;
        private DataGridView dgvEquipo1;
        private DataGridView dgvEquipo2;
        private ComboBox cmbEquipo2;
        private ComboBox cmbJugador2;
        private Label label4;
        private Label label5;
        private Button btnRegistrar;
        private Button btnVolver;
        private DataGridView dgvBatallas;
        private Label label6;
    }
}