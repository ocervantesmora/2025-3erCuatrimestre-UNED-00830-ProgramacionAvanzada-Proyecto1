/*
 * UNED III Cuatrimestre
 * 00830 - Programacion avanzada
 * Proyecto 1: Batallas Místicas
 * Estudiante: Oscar Eduardo Cervantes Mora
 * Fecha: 2025-09-28
 * @author ocervantesmora
 */
namespace CervantesOscar_Proyecto1
{
    public partial class frmVentanaPrincipal : Form
    {
        public frmVentanaPrincipal()
        {
            InitializeComponent();
        }

        private void btnRegistrarCriaturas_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistrarCriatura frmRegistrarCriatura = new frmRegistrarCriatura();
            frmRegistrarCriatura.ShowDialog();
            this.Show();

        }

        private void btnRegistrarJugador_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistrarJugador frmRegistrarJugador = new frmRegistrarJugador();
            frmRegistrarJugador.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInventarioCriaturasJugador frmInventarioCriaturasJugador = new frmInventarioCriaturasJugador();
            frmInventarioCriaturasJugador.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistrarEquipos frmRegistrarEquipos = new frmRegistrarEquipos();
            frmRegistrarEquipos.ShowDialog();
            this.Show();
        }

        private void btnRegistrarBatallas_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegistrarBatallas frmRegistrarBatallas = new frmRegistrarBatallas();
            frmRegistrarBatallas.ShowDialog();
            this.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmTop10 frmTop10 = new frmTop10();
            frmTop10.ShowDialog();
            this.Show();
        }
    }
}