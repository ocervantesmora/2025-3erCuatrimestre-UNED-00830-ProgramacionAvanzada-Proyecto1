using AccesoADatos;
using Entidades;
using Entidades.Entidades;
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
        private EquipoLN equipoLN = new EquipoLN();
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
            CargarEquiposEnDgv();
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
                CargarCriaturasEnCombobox(jugadorSeleccionado, cmbCriatura1);
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Variables para almacenar los IDs
            int idEquipo;
            int idJugador;
            int idCriatura1;
            int idCriatura2;
            int idCriatura3;

            if (!int.TryParse(txtId.Text, out idEquipo))
            {
                MessageBox.Show("El ID del Equipo debe ser un número entero válido.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EquipoAD.ExisteIdEquipo(idEquipo))
            {
                MessageBox.Show("Error: Ya existe un equipo registrado con el ID " + idEquipo + ". El ID debe ser único.", "Error de Unicidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbJugador.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un Jugador.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Jugador jugadorSeleccionado = cmbJugador.SelectedItem as Jugador;
            idJugador = jugadorSeleccionado.IdJugador;

            Criatura c1 = cmbCriatura1.SelectedItem as Criatura;
            Criatura c2 = cmbCriatura2.SelectedItem as Criatura;
            Criatura c3 = cmbCriatura3.SelectedItem as Criatura;

            if (c1 == null || c2 == null || c3 == null)
            {
                MessageBox.Show("Debe seleccionar tres criaturas válidas para el equipo.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            idCriatura1 = c1.IdCriatura;
            idCriatura2 = c2.IdCriatura;
            idCriatura3 = c3.IdCriatura;

            if (idCriatura1 == idCriatura2 || idCriatura1 == idCriatura3 || idCriatura2 == idCriatura3)
            {
                MessageBox.Show("Las tres criaturas del equipo deben ser diferentes.", "Error de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string resultado = equipoLN.RegistrarEquipo(
                idEquipo,
                idJugador,
                idCriatura1,
                idCriatura2,
                idCriatura3
            );

            MessageBox.Show(resultado, "Registro de Equipo", MessageBoxButtons.OK);

            // Si el registro fue exitoso, puedes limpiar el campo de ID
            if (resultado.StartsWith("Equipo registrado"))
            {
                txtId.Clear();
                CargarEquiposEnDgv();
            }
        }

        private void CargarEquiposEnDgv()
        {
            Equipo[] equipos = equipoLN.ObtenerTodosLosEquipos();

            dgvEquipos.DataSource = equipos.Where(e => e != null).ToArray();

            FormatearDgvEquipos();
        }

        private void FormatearDgvEquipos()
        {
            if (dgvEquipos.Columns.Contains("IdJugador"))
            {
                dgvEquipos.Columns["IdJugador"].Visible = false;
            }
            if (dgvEquipos.Columns.Contains("IdCriatura1"))
            {
                dgvEquipos.Columns["IdCriatura1"].Visible = false;
            }
            if (dgvEquipos.Columns.Contains("IdCriatura2"))
            {
                dgvEquipos.Columns["IdCriatura2"].Visible = false;
            }
            if (dgvEquipos.Columns.Contains("IdCriatura3"))
            {
                dgvEquipos.Columns["IdCriatura3"].Visible = false;
            }

            if (dgvEquipos.Columns.Contains("IdEquipo"))
            {
                dgvEquipos.Columns["IdEquipo"].HeaderText = "ID Equipo";
                dgvEquipos.Columns["IdEquipo"].DisplayIndex = 0;
            }

            if (!dgvEquipos.Columns.Contains("NombreJugador"))
            {
                dgvEquipos.Columns.Add("NombreJugador", "Jugador");
            }

            if (!dgvEquipos.Columns.Contains("CriaturaDetalle1"))
            {
                dgvEquipos.Columns.Add("CriaturaDetalle1", "Criatura 1");
            }

            if (!dgvEquipos.Columns.Contains("CriaturaDetalle2"))
            {
                dgvEquipos.Columns.Add("CriaturaDetalle2", "Criatura 2");
            }

            if (!dgvEquipos.Columns.Contains("CriaturaDetalle3"))
            {
                dgvEquipos.Columns.Add("CriaturaDetalle3", "Criatura 3");
            }

            // Ajustar el orden
            dgvEquipos.Columns["NombreJugador"].DisplayIndex = 1;
            dgvEquipos.Columns["CriaturaDetalle1"].DisplayIndex = 2;
            dgvEquipos.Columns["CriaturaDetalle2"].DisplayIndex = 3;
            dgvEquipos.Columns["CriaturaDetalle3"].DisplayIndex = 4;

            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvEquipos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEquipos.Rows[e.RowIndex].DataBoundItem is Equipo equipoItem)
            {
                if (dgvEquipos.Columns[e.ColumnIndex].Name == "NombreJugador")
                {
                    Jugador jugador = jugadorLN.BuscarJugadorPorId(equipoItem.IdJugador);
                    if (jugador != null)
                    {
                        e.Value = jugador.ToString();
                        e.FormattingApplied = true;
                    }
                }

                else if (dgvEquipos.Columns[e.ColumnIndex].Name.StartsWith("CriaturaDetalle"))
                {
                    int idCriatura = 0;

                    if (dgvEquipos.Columns[e.ColumnIndex].Name == "CriaturaDetalle1")
                    {
                        idCriatura = equipoItem.IdCriatura1;
                    }
                    else if (dgvEquipos.Columns[e.ColumnIndex].Name == "CriaturaDetalle2")
                    {
                        idCriatura = equipoItem.IdCriatura2;
                    }
                    else if (dgvEquipos.Columns[e.ColumnIndex].Name == "CriaturaDetalle3")
                    {
                        idCriatura = equipoItem.IdCriatura3;
                    }

                    Criatura criatura = criaturaLN.BuscarCriaturaPorId(idCriatura);
                    if (criatura != null)
                    {
                        e.Value = criatura.ToString();
                        e.FormattingApplied = true;
                    }
                }
            }
        }
    }
}
