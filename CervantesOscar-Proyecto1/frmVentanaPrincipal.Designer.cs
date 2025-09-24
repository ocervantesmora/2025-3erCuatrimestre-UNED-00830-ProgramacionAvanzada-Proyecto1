namespace CervantesOscar_Proyecto1
{
    partial class frmVentanaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRegistrarCriaturas = new Button();
            btnRegistrarJugador = new Button();
            SuspendLayout();
            // 
            // btnRegistrarCriaturas
            // 
            btnRegistrarCriaturas.Location = new Point(142, 69);
            btnRegistrarCriaturas.Name = "btnRegistrarCriaturas";
            btnRegistrarCriaturas.Size = new Size(192, 50);
            btnRegistrarCriaturas.TabIndex = 0;
            btnRegistrarCriaturas.Text = "Registrar Criatura";
            btnRegistrarCriaturas.UseVisualStyleBackColor = true;
            btnRegistrarCriaturas.Click += btnRegistrarCriaturas_Click;
            // 
            // btnRegistrarJugador
            // 
            btnRegistrarJugador.Location = new Point(142, 151);
            btnRegistrarJugador.Name = "btnRegistrarJugador";
            btnRegistrarJugador.Size = new Size(192, 50);
            btnRegistrarJugador.TabIndex = 1;
            btnRegistrarJugador.Text = "Registrar Jugador";
            btnRegistrarJugador.UseVisualStyleBackColor = true;
            btnRegistrarJugador.Click += btnRegistrarJugador_Click;
            // 
            // frmVentanaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegistrarJugador);
            Controls.Add(btnRegistrarCriaturas);
            Name = "frmVentanaPrincipal";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRegistrarCriaturas;
        private Button btnRegistrarJugador;
    }
}