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
            // Validar que haya un jugador seleccionado en el ComboBox
            if (cmbJugadores.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un jugador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que haya una criatura seleccionada en el DataGridView
            if (dgvCriaturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una criatura para agregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtiene el objeto del jugador y la criatura seleccionados
            Jugador jugadorSeleccionado = (Jugador)cmbJugadores.SelectedItem;
            Criatura criaturaSeleccionada = (Criatura)dgvCriaturas.SelectedRows[0].DataBoundItem;

            string resultado = jugadorLN.AgregarCriaturaAInventario(
                jugadorSeleccionado.IdJugador,
                criaturaSeleccionada.IdCriatura,
                criaturaSeleccionada.Poder,
                criaturaSeleccionada.Resistencia
            );

            MessageBox.Show(resultado, "Añadir Criatura a Inventario", MessageBoxButtons.OK);

            // Refresca la interfaz
            cmbJugadores_SelectedIndexChanged(sender, e);
        }

        private void dgvCriaturasAdquiridas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica si la columna actual es la que vamos a mostrar
            // Debes crear esta columna en el diseñador
            if (dgvCriaturasAdquiridas.Columns[e.ColumnIndex].Name == "NombreCriatura")
            {
                // Obtener el objeto de la fila actual (de tipo Inventario)
                Inventario inventario = dgvCriaturasAdquiridas.Rows[e.RowIndex].DataBoundItem as Inventario;

                // Validar que el objeto no sea nulo y que tenga un ID de criatura válido
                if (inventario != null && inventario.IdCriatura > 0)
                {
                    // Buscar la criatura por su ID usando la lógica de negocio
                    Criatura criatura = criaturaLN.BuscarCriaturaPorId(inventario.IdCriatura);

                    // Si la criatura se encuentra, mostrar su nombre en la celda
                    if (criatura != null)
                    {
                        e.Value = criatura.Nombre;
                        e.FormattingApplied = true; // Indica que el formato ha sido aplicado
                    }
                }
            }
        }
    }
}
