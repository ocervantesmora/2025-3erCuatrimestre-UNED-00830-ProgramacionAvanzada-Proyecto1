﻿namespace CervantesOscar_Proyecto1
{
    partial class frmTop10
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
            dgvTop10 = new DataGridView();
            btnVolver = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTop10).BeginInit();
            SuspendLayout();
            // 
            // dgvTop10
            // 
            dgvTop10.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop10.Location = new Point(25, 82);
            dgvTop10.Name = "dgvTop10";
            dgvTop10.RowTemplate.Height = 25;
            dgvTop10.Size = new Size(725, 400);
            dgvTop10.TabIndex = 0;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(360, 516);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(271, 28);
            label1.Name = "label1";
            label1.Size = new Size(250, 32);
            label1.TabIndex = 2;
            label1.Text = "TOP 10 GANADORES";
            // 
            // frmTop10
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(label1);
            Controls.Add(btnVolver);
            Controls.Add(dgvTop10);
            Name = "frmTop10";
            Text = "Top 10 ganadores";
            Load += frmTop10_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTop10).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTop10;
        private Button btnVolver;
        private Label label1;
    }
}