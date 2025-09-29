/*
 * UNED III Cuatrimestre
 * 00830 - Programacion avanzada
 * Proyecto 1: Batallas Místicas
 * Estudiante: Oscar Eduardo Cervantes Mora
 * Fecha: 2025-09-28
 * @author ocervantesmora
 */
using Entidades;
using LogicaDeNegocio;


namespace CervantesOscar_Proyecto1
{
    public partial class frmRegistrarJugador : Form
    {
        private JugadorLN jugadorLN = new JugadorLN();
        public frmRegistrarJugador()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string nombre = txtNombre.Text;
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;

                string resultado = jugadorLN.RegistrarJugador(id, nombre, fechaNacimiento);
                if (resultado == "Jugador registrado con éxito.")
                {
                    txtId.Clear();
                    txtNombre.Clear();
                }
                MessageBox.Show(resultado, "Registro de Jugador", MessageBoxButtons.OK);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarJugadoressEnTabla();

        }

        private void CargarJugadoressEnTabla()
        {
            Jugador[] jugadores = jugadorLN.ObtenerTodosLosJugadores();
            dgvJugadores.DataSource = jugadores;
            dgvJugadores.Columns["Nivel"].Visible = false;
            dgvJugadores.Columns["NivelTexto"].HeaderText = "Nivel";
            dgvJugadores.Refresh();
        }

        private void frmRegistrarCriatura_Load(object sender, EventArgs e)
        {
            CargarJugadoressEnTabla();
        }

        private void dgvJugadores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvJugadores.Columns[e.ColumnIndex].Name == "FechaNacimiento")
            {
                if (e.Value != null)
                {
                    if (e.Value is DateTime fecha)
                    {
                        e.Value = fecha.ToShortDateString();
                        e.FormattingApplied = true;
                    }
                }
            }
        }
    }
}
