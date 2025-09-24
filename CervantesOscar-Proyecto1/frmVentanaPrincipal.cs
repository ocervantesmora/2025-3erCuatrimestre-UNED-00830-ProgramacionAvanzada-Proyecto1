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
    }
}