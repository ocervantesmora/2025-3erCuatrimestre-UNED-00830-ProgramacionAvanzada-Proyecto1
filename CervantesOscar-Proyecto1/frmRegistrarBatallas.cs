using Entidades;
using Entidades.Entidades;
using LogicaDeNegocio;

namespace CervantesOscar_Proyecto1
{
    public partial class frmRegistrarBatallas : Form
    {
        private JugadorLN jugadorLN = new JugadorLN();
        private EquipoLN equipoLN = new EquipoLN();
        private CriaturaLN criaturaLN = new CriaturaLN();
        private BatallaLN batallaLN = new BatallaLN();
        public frmRegistrarBatallas()
        {
            InitializeComponent();
        }

        private void frmRegistrarBatallas_Load(object sender, EventArgs e)
        {
            CargarJugadoresEnCombobox(cmbJugador1);
            CargarJugadoresEnCombobox(cmbJugador2);
            CargarBatallasEnDgv();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarJugadoresEnCombobox(ComboBox pComboBox)
        {
            Jugador[] jugadores = jugadorLN.ObtenerTodosLosJugadores();

            pComboBox.Items.Clear();

            foreach (Jugador jugador in jugadores)
            {
                if (jugador != null)
                {
                    pComboBox.Items.Add(jugador);
                }
            }
            pComboBox.SelectedIndex = -1;
        }

        private void CargarEquiposDelJugador(int pIdJugador, ComboBox pComboBoxEquipo)
        {
            Equipo[] equiposDelJugador = equipoLN.ObtenerEquiposPorIdJugador(pIdJugador);

            pComboBoxEquipo.Items.Clear();

            foreach (Equipo equipo in equiposDelJugador)
            {
                if (equipo != null)
                {
                    pComboBoxEquipo.Items.Add(equipo);
                }
            }

            pComboBoxEquipo.DisplayMember = "IdEquipo";
            pComboBoxEquipo.SelectedIndex = -1;
        }

        private void cmbJugador1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJugador1.SelectedItem != null)
            {
                Jugador jugadorSeleccionado = cmbJugador1.SelectedItem as Jugador;

                int idJugador = jugadorSeleccionado.IdJugador;

                CargarEquiposDelJugador(idJugador, cmbEquipo1);
            }
            else
            {
                cmbEquipo1.Items.Clear();
                dgvEquipo1.DataSource = null;
                cmbEquipo1.SelectedIndex = -1;
            }
        }

        private void cmbJugador2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJugador2.SelectedItem != null)
            {
                Jugador jugadorSeleccionado = cmbJugador2.SelectedItem as Jugador;

                int idJugador = jugadorSeleccionado.IdJugador;

                CargarEquiposDelJugador(idJugador, cmbEquipo2);
            }
            else
            {
                cmbEquipo2.Items.Clear();
                dgvEquipo2.DataSource = null;
                cmbEquipo2.SelectedIndex = -1;
            }
        }

        private void CargarDetalleEquipo(Equipo pEquipo, DataGridView pDgv)
        {
            if (pEquipo == null)
            {
                pDgv.DataSource = null;
                return;
            }

            int[] idsCriaturas = new int[3];

            idsCriaturas[0] = pEquipo.IdCriatura1;
            idsCriaturas[1] = pEquipo.IdCriatura2;
            idsCriaturas[2] = pEquipo.IdCriatura3;

            pDgv.DataSource = idsCriaturas;

            FormatearDgvEquipo(pDgv);
        }

        private void FormatearDgvEquipo(DataGridView pDgv)
        {
            pDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pDgv.Columns.Clear();

            if (!pDgv.Columns.Contains("NombreCriatura"))
            {
                pDgv.Columns.Add("NombreCriatura", "Criatura");
            }

            if (!pDgv.Columns.Contains("NivelCriatura"))
            {
                pDgv.Columns.Add("NivelCriatura", "Nivel");
            }
        }

        private void cmbEquipo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Equipo equipoSeleccionado = cmbEquipo1.SelectedItem as Equipo;
            CargarDetalleEquipo(equipoSeleccionado, dgvEquipo1);
        }

        private void cmbEquipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Equipo equipoSeleccionado = cmbEquipo2.SelectedItem as Equipo;
            CargarDetalleEquipo(equipoSeleccionado, dgvEquipo2);
        }

        private void dgvEquipo1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEquipo1.Columns[e.ColumnIndex].Name == "NombreCriatura" ||
                dgvEquipo1.Columns[e.ColumnIndex].Name == "NivelCriatura")
            {
                if (dgvEquipo1.Rows[e.RowIndex].DataBoundItem is int idCriatura)
                {
                    Criatura criatura = criaturaLN.BuscarCriaturaPorId(idCriatura);

                    if (criatura != null)
                    {
                        if (dgvEquipo1.Columns[e.ColumnIndex].Name == "NombreCriatura")
                        {
                            e.Value = criatura.Nombre;
                        }
                        else if (dgvEquipo1.Columns[e.ColumnIndex].Name == "NivelCriatura")
                        {
                            e.Value = criatura.NivelTexto;
                        }

                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dgvEquipo2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEquipo2.Columns[e.ColumnIndex].Name == "NombreCriatura" ||
                dgvEquipo2.Columns[e.ColumnIndex].Name == "NivelCriatura")
            {
                if (dgvEquipo2.Rows[e.RowIndex].DataBoundItem is int idCriatura)
                {
                    Criatura criatura = criaturaLN.BuscarCriaturaPorId(idCriatura);

                    if (criatura != null)
                    {
                        if (dgvEquipo2.Columns[e.ColumnIndex].Name == "NombreCriatura")
                        {
                            e.Value = criatura.Nombre;
                        }
                        else if (dgvEquipo2.Columns[e.ColumnIndex].Name == "NivelCriatura")
                        {
                            e.Value = criatura.NivelTexto;
                        }

                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void CargarBatallasEnDgv()
        {
            Batalla[] batallas = batallaLN.ObtenerTodasLasBatallas();

            int contador = 0;
            foreach (Batalla b in batallas)
            {
                if (b != null) contador++;
            }

            Batalla[] batallasFiltradas = new Batalla[contador];
            int indice = 0;
            foreach (Batalla b in batallas)
            {
                if (b != null)
                {
                    batallasFiltradas[indice] = b;
                    indice++;
                }
            }
            dgvBatallas.DataSource = batallasFiltradas;
            FormatearDgvBatallas();
        }

        private void FormatearDgvBatallas()
        {
            if (dgvBatallas.Columns.Contains("IdJugador1")) dgvBatallas.Columns["IdJugador1"].Visible = false;
            if (dgvBatallas.Columns.Contains("IdJugador2")) dgvBatallas.Columns["IdJugador2"].Visible = false;
            if (dgvBatallas.Columns.Contains("Ganador")) dgvBatallas.Columns["Ganador"].Visible = false;

            if (dgvBatallas.Columns.Contains("IdEquipo1"))
            {
                dgvBatallas.Columns["IdEquipo1"].Visible = true;
                dgvBatallas.Columns["IdEquipo1"].HeaderText = "Jugador1 Equipo ID";
            }
            if (dgvBatallas.Columns.Contains("IdEquipo2"))
            {
                dgvBatallas.Columns["IdEquipo2"].Visible = true;
                dgvBatallas.Columns["IdEquipo2"].HeaderText = "Jugador2 Equipo ID";
            }

            if (!dgvBatallas.Columns.Contains("NombreJugador1")) dgvBatallas.Columns.Add("NombreJugador1", "Jugador 1");
            if (!dgvBatallas.Columns.Contains("NombreJugador2")) dgvBatallas.Columns.Add("NombreJugador2", "Jugador 2");
            if (!dgvBatallas.Columns.Contains("NombreGanador")) dgvBatallas.Columns.Add("NombreGanador", "Ganador");

            int displayIndexCounter = 0;
            if (dgvBatallas.Columns.Contains("IdBatalla"))
            {
                dgvBatallas.Columns["IdBatalla"].HeaderText = "ID";
                dgvBatallas.Columns["IdBatalla"].DisplayIndex = displayIndexCounter++;
            }

            dgvBatallas.Columns["NombreJugador1"].DisplayIndex = displayIndexCounter++;
            dgvBatallas.Columns["IdEquipo1"].DisplayIndex = displayIndexCounter++; 

            dgvBatallas.Columns["NombreJugador2"].DisplayIndex = displayIndexCounter++;
            dgvBatallas.Columns["IdEquipo2"].DisplayIndex = displayIndexCounter++; 

            dgvBatallas.Columns["NombreGanador"].DisplayIndex = displayIndexCounter++;

            if (dgvBatallas.Columns.Contains("Fecha")) dgvBatallas.Columns["Fecha"].DisplayIndex = displayIndexCounter++;

            dgvBatallas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvBatallas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBatallas.Rows[e.RowIndex].DataBoundItem is Batalla batallaItem)
            {
                int idJugadorABuscar = 0;
                string nombreColumna = dgvBatallas.Columns[e.ColumnIndex].Name;

                if (nombreColumna == "NombreJugador1")
                {
                    idJugadorABuscar = batallaItem.IdJugador1;
                }
                else if (nombreColumna == "NombreJugador2")
                {
                    idJugadorABuscar = batallaItem.IdJugador2;
                }
                else if (nombreColumna == "NombreGanador")
                {
                    idJugadorABuscar = batallaItem.Ganador;
                }

                if (idJugadorABuscar > 0)
                {
                    Jugador jugador = jugadorLN.BuscarJugadorPorId(idJugadorABuscar);

                    if (jugador != null)
                    {
                        e.Value = jugador.ToString();
                        e.FormattingApplied = true;
                    }
                }
                else if (nombreColumna == "NombreGanador" && batallaItem.Ganador == 0)
                {
                    e.Value = "Empate / N/A";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int idBatalla))
            {
                MessageBox.Show("El ID de la Batalla debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbJugador1.SelectedItem == null || cmbJugador2.SelectedItem == null ||
                cmbEquipo1.SelectedItem == null || cmbEquipo2.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un Jugador y un Equipo para ambos participantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idJugador1 = (cmbJugador1.SelectedItem as Jugador).IdJugador;
            int idJugador2 = (cmbJugador2.SelectedItem as Jugador).IdJugador;
            int idEquipo1 = (cmbEquipo1.SelectedItem as Equipo).IdEquipo;
            int idEquipo2 = (cmbEquipo2.SelectedItem as Equipo).IdEquipo;

            if (idJugador1 == idJugador2)
            {
                MessageBox.Show("No se puede registrar una batalla entre el mismo jugador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idGanadorInicial = 0;

            string resultado = batallaLN.RegistrarBatalla(
                idBatalla,
                idJugador1,
                idEquipo1,
                idJugador2,
                idEquipo2,
                idGanadorInicial
            );

            MessageBox.Show(resultado, "Registro de Batalla", MessageBoxButtons.OK);

            if (resultado.StartsWith("Batalla registrada"))
            {
                txtId.Clear();
                cmbJugador1.SelectedIndex = -1;
                cmbJugador2.SelectedIndex = -1;
                cmbEquipo1.Items.Clear();
                cmbEquipo2.Items.Clear();

                CargarBatallasEnDgv();
            }
        }
    }
}
