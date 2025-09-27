using Entidades;
using Logica_de_Negocio;
using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CervantesOscar_Proyecto1
{
    public partial class frmRegistrarEquipos : Form
    {
        private JugadorLN jugadorLN = new JugadorLN();
        private CriaturaLN criaturaLN = new CriaturaLN();
        public frmRegistrarEquipos()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistrarEquipos_Load(object sender, EventArgs e)
        {
            CargarJugadoresEnComboBox();
        }

        private void CargarJugadoresEnComboBox()
        {
            Jugador[] jugadores = jugadorLN.ObtenerTodosLosJugadores();

            cmbJugador.Items.Clear();

            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i] != null)
                {
                    cmbJugador.Items.Add(jugadores[i]);
                }
            }
        }

        private void cmbJugador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJugador.SelectedItem != null)
            {
                Jugador jugadorSeleccionado = (Jugador)cmbJugador.SelectedItem;

                dgvInventario.DataSource = jugadorSeleccionado.InventarioCriaturas;

                dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                FormatearDgvInventario();
                CargarCriaturasEnCombobox(jugadorSeleccionado,cmbCriatura1);
                CargarCriaturasEnCombobox(jugadorSeleccionado, cmbCriatura2);
                CargarCriaturasEnCombobox(jugadorSeleccionado, cmbCriatura3);
            }
            else
            {
                dgvInventario.DataSource = null;
            }
        }

        private void dgvInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInventario.Columns[e.ColumnIndex].Name == "NombreCriatura" ||
        dgvInventario.Columns[e.ColumnIndex].Name == "NivelCriatura")
            {
                // Obtener el objeto Inventario asociado a la fila
                Inventario inventarioItem = dgvInventario.Rows[e.RowIndex].DataBoundItem as Inventario;

                if (inventarioItem != null)
                {
                    // Usar la lógica de negocio para obtener la Criatura completa
                    // Asume que 'criaturaLN' es la instancia de CriaturaLN en tu formulario
                    Criatura criatura = criaturaLN.BuscarCriaturaPorId(inventarioItem.IdCriatura);

                    if (criatura != null)
                    {
                        // Asignar el nombre de la Criatura a la columna "NombreCriatura"
                        if (dgvInventario.Columns[e.ColumnIndex].Name == "NombreCriatura")
                        {
                            e.Value = criatura.Nombre;
                        }

                        // Asignar el NivelTexto a la columna "NivelCriatura"
                        else if (dgvInventario.Columns[e.ColumnIndex].Name == "NivelCriatura")
                        {
                            e.Value = criatura.NivelTexto;
                        }

                        e.FormattingApplied = true; // Indica que ya aplicamos el formato
                    }
                }
            }
        }

        private void FormatearDgvInventario()
        {
            if (dgvInventario.Columns.Contains("IdJugador"))
            {
                dgvInventario.Columns["IdJugador"].Visible = false;
            }
            if (dgvInventario.Columns.Contains("IdCriatura"))
            {
                dgvInventario.Columns["IdCriatura"].Visible = true;
                dgvInventario.Columns["IdCriatura"].HeaderText = "ID";
            }

            if (!dgvInventario.Columns.Contains("NombreCriatura"))
            {
                dgvInventario.Columns.Add("NombreCriatura", "Criatura");
            }

            if (!dgvInventario.Columns.Contains("NivelCriatura"))
            {
                dgvInventario.Columns.Add("NivelCriatura", "Nivel");
            }

            dgvInventario.Columns["IdCriatura"].DisplayIndex = 0;
            dgvInventario.Columns["NombreCriatura"].DisplayIndex = 1;
            dgvInventario.Columns["NivelCriatura"].DisplayIndex = 2;

            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarCriaturasEnCombobox(Jugador pJugador, System.Windows.Forms.ComboBox pComboBox)
        {
            pComboBox.Items.Clear();

            var inventarioFiltrado = pJugador.InventarioCriaturas
                                             .Where(i => i != null);

            foreach (var inventarioItem in inventarioFiltrado)
            {
                Criatura criatura = criaturaLN.BuscarCriaturaPorId(inventarioItem.IdCriatura);

                if (criatura != null)
                {
                    pComboBox.Items.Add(criatura);
                }
            }
        }
    }
}
