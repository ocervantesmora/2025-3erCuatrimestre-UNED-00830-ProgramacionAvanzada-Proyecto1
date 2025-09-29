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
    public partial class frmTop10 : Form
    {
        JugadorLN jugadorLN = new JugadorLN();
        public frmTop10()
        {
            InitializeComponent();
        }

        private void frmTop10_Load(object sender, EventArgs e)
        {
            LlenarDgvTop10();
            dgvTop10.Refresh();
        }

        private void LlenarDgvTop10()
        {
            JugadorLN jugadorLN = new JugadorLN();
            Jugador[] topJugadores = jugadorLN.ObtenerTop10JugadoresOrdenados();

            dgvTop10.DataSource = topJugadores;

            if (dgvTop10.Columns.Count > 0) AjustarColumnasDGV(dgvTop10);
            dgvTop10.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTop10.ReadOnly = true;
            dgvTop10.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void AjustarColumnasDGV(DataGridView dgv)
        {
            // Ocultar las propiedades que no son necesarias
            if (dgv.Columns.Contains("InventarioCriaturas"))
                dgv.Columns["InventarioCriaturas"].Visible = false;

            if (dgv.Columns.Contains("CantidadCriaturas"))
                dgv.Columns["CantidadCriaturas"].Visible = false;

            if (dgv.Columns.Contains("Nivel"))
                dgv.Columns["Nivel"].Visible = false; // Oculta el nivel numérico

            // Renombrar y dar formato
            if (dgv.Columns.Contains("IdJugador"))
                dgv.Columns["IdJugador"].HeaderText = "ID";

            if (dgv.Columns.Contains("Nombre"))
                dgv.Columns["Nombre"].HeaderText = "Nombre de Jugador";

            if (dgv.Columns.Contains("NivelTexto"))
                dgv.Columns["NivelTexto"].HeaderText = "Nivel";

            if (dgv.Columns.Contains("BatallasGanadas"))
                dgv.Columns["BatallasGanadas"].HeaderText = "Victorias";

            if (dgv.Columns.Contains("Cristales"))
                dgv.Columns["Cristales"].HeaderText = "Cristales";

            if (dgv.Columns.Contains("FechaNacimiento"))
            {
                dgv.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
                dgv.Columns["FechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
