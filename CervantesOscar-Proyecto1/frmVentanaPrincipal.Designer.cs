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
            btnInventario = new Button();
            btnEquipos = new Button();
            btnBatallas = new Button();
            btnSalir = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnRegistrarCriaturas
            // 
            btnRegistrarCriaturas.Location = new Point(12, 84);
            btnRegistrarCriaturas.Name = "btnRegistrarCriaturas";
            btnRegistrarCriaturas.Size = new Size(309, 66);
            btnRegistrarCriaturas.TabIndex = 0;
            btnRegistrarCriaturas.Text = "Criaturas";
            btnRegistrarCriaturas.UseVisualStyleBackColor = true;
            btnRegistrarCriaturas.Click += btnRegistrarCriaturas_Click;
            // 
            // btnRegistrarJugador
            // 
            btnRegistrarJugador.Location = new Point(12, 12);
            btnRegistrarJugador.Name = "btnRegistrarJugador";
            btnRegistrarJugador.Size = new Size(309, 66);
            btnRegistrarJugador.TabIndex = 1;
            btnRegistrarJugador.Text = "Jugadores";
            btnRegistrarJugador.UseVisualStyleBackColor = true;
            btnRegistrarJugador.Click += btnRegistrarJugador_Click;
            // 
            // btnInventario
            // 
            btnInventario.Location = new Point(12, 156);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(309, 66);
            btnInventario.TabIndex = 2;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += button1_Click;
            // 
            // btnEquipos
            // 
            btnEquipos.Location = new Point(12, 228);
            btnEquipos.Name = "btnEquipos";
            btnEquipos.Size = new Size(309, 66);
            btnEquipos.TabIndex = 3;
            btnEquipos.Text = "Equipos";
            btnEquipos.UseVisualStyleBackColor = true;
            btnEquipos.Click += button2_Click;
            // 
            // btnBatallas
            // 
            btnBatallas.Location = new Point(12, 300);
            btnBatallas.Name = "btnBatallas";
            btnBatallas.Size = new Size(309, 66);
            btnBatallas.TabIndex = 4;
            btnBatallas.Text = "Batallas";
            btnBatallas.UseVisualStyleBackColor = true;
            btnBatallas.Click += btnRegistrarBatallas_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(12, 490);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(309, 66);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 372);
            button1.Name = "button1";
            button1.Size = new Size(309, 66);
            button1.TabIndex = 6;
            button1.Text = "Top 10 ganadores";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // frmVentanaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 568);
            Controls.Add(button1);
            Controls.Add(btnSalir);
            Controls.Add(btnBatallas);
            Controls.Add(btnEquipos);
            Controls.Add(btnInventario);
            Controls.Add(btnRegistrarJugador);
            Controls.Add(btnRegistrarCriaturas);
            Name = "frmVentanaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MITICAX - Batallas Místicas";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRegistrarCriaturas;
        private Button btnRegistrarJugador;
        private Button btnInventario;
        private Button btnEquipos;
        private Button btnBatallas;
        private Button btnSalir;
        private Button button1;
    }
}