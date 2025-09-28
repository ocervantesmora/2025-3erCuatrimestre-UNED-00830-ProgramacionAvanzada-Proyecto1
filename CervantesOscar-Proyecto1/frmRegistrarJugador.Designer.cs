using Entidades;
using LogicaDeNegocio;

namespace CervantesOscar_Proyecto1
{
    partial class frmRegistrarJugador
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
            dgvJugadores = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtId = new MaskedTextBox();
            txtNombre = new TextBox();
            btnRegistrar = new Button();
            btnVolver = new Button();
            label5 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).BeginInit();
            SuspendLayout();
            // 
            // dgvJugadores
            // 
            dgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadores.Location = new Point(12, 43);
            dgvJugadores.Name = "dgvJugadores";
            dgvJugadores.RowTemplate.Height = 25;
            dgvJugadores.Size = new Size(760, 201);
            dgvJugadores.TabIndex = 0;
            dgvJugadores.CellFormatting += dgvJugadores_CellFormatting;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(251, 9);
            label1.Name = "label1";
            label1.Size = new Size(284, 30);
            label1.TabIndex = 1;
            label1.Text = "JUGADORES REGISTRADOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 324);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 2;
            label2.Text = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(215, 356);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(215, 389);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 4;
            label4.Text = "Fecha de Nacimiento";
            // 
            // txtId
            // 
            txtId.Location = new Point(365, 316);
            txtId.Mask = "00000";
            txtId.Name = "txtId";
            txtId.Size = new Size(197, 23);
            txtId.TabIndex = 9;
            txtId.ValidatingType = typeof(int);
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(365, 356);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(197, 23);
            txtNombre.TabIndex = 10;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(191, 431);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(130, 64);
            btnRegistrar.TabIndex = 17;
            btnRegistrar.Text = "Registrar Jugador";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(457, 431);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(130, 64);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(329, 274);
            label5.Name = "label5";
            label5.Size = new Size(116, 21);
            label5.TabIndex = 19;
            label5.Text = "Nuevo Jugador";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(365, 389);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 20;
            // 
            // frmRegistrarJugador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(label5);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrar);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvJugadores);
            Name = "frmRegistrarJugador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Jugadores";
            Load += frmRegistrarCriatura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvJugadores;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private MaskedTextBox txtId;
        private TextBox txtNombre;
        private Button btnRegistrar;
        private Button btnVolver;
        private Label label5;
        private DateTimePicker dtpFechaNacimiento;
    }
}