using Entidades;
using LogicaDeNegocio;

namespace CervantesOscar_Proyecto1
{
    partial class frmRegistrarCriatura
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtId = new MaskedTextBox();
            txtNombre = new TextBox();
            txtPoder = new TextBox();
            txtResistencia = new TextBox();
            txtCosto = new TextBox();
            cmbTipo = new ComboBox();
            cmbNivel = new ComboBox();
            btnRegistrar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCriaturas).BeginInit();
            SuspendLayout();
            // 
            // dgvCriaturas
            // 
            dgvCriaturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCriaturas.Location = new Point(12, 43);
            dgvCriaturas.Name = "dgvCriaturas";
            dgvCriaturas.RowTemplate.Height = 25;
            dgvCriaturas.Size = new Size(760, 201);
            dgvCriaturas.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(251, 9);
            label1.Name = "label1";
            label1.Size = new Size(277, 30);
            label1.TabIndex = 1;
            label1.Text = "CRIATURAS REGISTRADAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 310);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 2;
            label2.Text = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 342);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 375);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 4;
            label4.Text = "Tipo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 408);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 5;
            label5.Text = "Nivel";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 446);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 6;
            label6.Text = "Poder";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(70, 485);
            label7.Name = "label7";
            label7.Size = new Size(65, 15);
            label7.TabIndex = 7;
            label7.Text = "Resistencia";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(70, 517);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 8;
            label8.Text = "Costo";
            // 
            // txtId
            // 
            txtId.Location = new Point(167, 302);
            txtId.Mask = "00000";
            txtId.Name = "txtId";
            txtId.Size = new Size(203, 23);
            txtId.TabIndex = 9;
            txtId.ValidatingType = typeof(int);
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(167, 339);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(203, 23);
            txtNombre.TabIndex = 10;
            // 
            // txtPoder
            // 
            txtPoder.Location = new Point(167, 443);
            txtPoder.Name = "txtPoder";
            txtPoder.Size = new Size(203, 23);
            txtPoder.TabIndex = 12;
            // 
            // txtResistencia
            // 
            txtResistencia.Location = new Point(167, 477);
            txtResistencia.Name = "txtResistencia";
            txtResistencia.Size = new Size(203, 23);
            txtResistencia.TabIndex = 13;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(167, 514);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(203, 23);
            txtCosto.TabIndex = 14;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Agua", "Tierra", "Aire", "Fuego" });
            cmbTipo.Location = new Point(167, 372);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(203, 23);
            cmbTipo.TabIndex = 15;
            // 
            // cmbNivel
            // 
            cmbNivel.FormattingEnabled = true;
            cmbNivel.Items.AddRange(new object[] { "01 - Iniciado", "02 - Aprendiz", "03 - Estudiante", "04 - Avanzado", "05 - Maestro" });
            cmbNivel.Location = new Point(167, 405);
            cmbNivel.Name = "cmbNivel";
            cmbNivel.Size = new Size(203, 23);
            cmbNivel.TabIndex = 16;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(532, 310);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(130, 64);
            btnRegistrar.TabIndex = 17;
            btnRegistrar.Text = "Registrar Criatura";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(532, 421);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(130, 64);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmRegistrarCriatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrar);
            Controls.Add(cmbNivel);
            Controls.Add(cmbTipo);
            Controls.Add(txtCosto);
            Controls.Add(txtResistencia);
            Controls.Add(txtPoder);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvCriaturas);
            Name = "frmRegistrarCriatura";
            Text = "Criaturas";
            Load += frmRegistrarCriatura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCriaturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCriaturas;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private MaskedTextBox txtId;
        private TextBox txtNombre;
        private TextBox txtPoder;
        private TextBox txtResistencia;
        private TextBox txtCosto;
        private ComboBox cmbTipo;
        private ComboBox cmbNivel;
        private Button btnRegistrar;
        private Button btnVolver;
    }
}