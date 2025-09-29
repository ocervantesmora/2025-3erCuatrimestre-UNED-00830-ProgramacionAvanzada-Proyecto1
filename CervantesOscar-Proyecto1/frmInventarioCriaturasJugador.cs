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
    public partial class frmInventarioCriaturasJugador : Form
    {
        private CriaturaLN criaturaLN = new CriaturaLN();
        private JugadorLN jugadorLN = new JugadorLN();
        public frmInventarioCriaturasJugador()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventarioCriaturasJugador_Load(object sender, EventArgs e)
        {
            CargarCriaturasEnTabla();
            CargarJugadores();
        }

        private void CargarCriaturasEnTabla()
        {
            Criatura[] criaturas = criaturaLN.ObtenerTodasLasCriaturas();
            dgvCriaturas.DataSource = criaturas;
            dgvCriaturas.Columns["Nivel"].Visible = false;
            dgvCriaturas.Columns["NivelTexto"].HeaderText = "Nivel";
            dgvCriaturas.Refresh();
            dgvCriaturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCriaturas.ReadOnly = true;
            dgvCriaturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CargarJugadores()
        {
            Jugador[] jugadores = jugadorLN.ObtenerTodosLosJugadores();
            cmbJugadores.Items.Clear();
            foreach (var jugador in jugadores)
            {
                if (jugador != null)
                {
                    cmbJugadores.Items.Add(jugador);
                }
            }
        }

        private void cmbJugadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJugadores.SelectedItem != null)
            {
                Jugador jugadorSeleccionado = (Jugador)cmbJugadores.SelectedItem;
                dgvCriaturasAdquiridas.DataSource = jugadorSeleccionado.InventarioCriaturas;
                dgvCriaturasAdquiridas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lblCristales.Text = "Cristales: " + jugadorSeleccionado.Cristales.ToString();
                dgvCriaturasAdquiridas.Refresh();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Se valida que haya un jugador seleccionado en el ComboBox
            if (cmbJugadores.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un jugador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Se valida que haya una criatura seleccionada en el DataGridView
            if (dgvCriaturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una criatura para agregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Se obtiene el objeto del jugador y la criatura seleccionados
            Jugador jugadorSeleccionado = (Jugador)cmbJugadores.SelectedItem;
            Criatura criaturaSeleccionada = (Criatura)dgvCriaturas.SelectedRows[0].DataBoundItem;

            string resultado = jugadorLN.AgregarCriaturaAInventario(
                jugadorSeleccionado.IdJugador,
                criaturaSeleccionada.IdCriatura,
                criaturaSeleccionada.Poder,
                criaturaSeleccionada.Resistencia
            );

            MessageBox.Show(resultado, "Añadir Criatura a Inventario", MessageBoxButtons.OK);

            // Se refresca la interfaz
            cmbJugadores_SelectedIndexChanged(sender, e);
        }

        private void dgvCriaturasAdquiridas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvCriaturasAdquiridas.Columns[e.ColumnIndex].Name == "NombreCriatura")
            {
                Inventario inventario = dgvCriaturasAdquiridas.Rows[e.RowIndex].DataBoundItem as Inventario;

                if (inventario != null && inventario.IdCriatura > 0)
                {
                    Criatura criatura = criaturaLN.BuscarCriaturaPorId(inventario.IdCriatura);

                    if (criatura != null)
                    {
                        e.Value = criatura.Nombre;
                        e.FormattingApplied = true;
                    }
                }
            }
        }
    }
}
