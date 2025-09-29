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
    public partial class frmRegistrarCriatura : Form
    {
        private CriaturaLN criaturaLN = new CriaturaLN();
        public frmRegistrarCriatura()
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
                string tipo = cmbTipo.SelectedItem.ToString();
                int nivel = nivelEnInt(cmbNivel.SelectedItem.ToString());
                int poder = Convert.ToInt32(txtPoder.Text);
                int resistencia = Convert.ToInt32(txtResistencia.Text);
                int costo = Convert.ToInt32(txtCosto.Text);

                string resultado = criaturaLN.RegistrarCriatura(id, nombre, tipo, nivel, poder, resistencia, costo);
                MessageBox.Show(resultado, "Registro de Criatura", MessageBoxButtons.OK);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarCriaturasEnTabla();

        }

        private int nivelEnInt(string pNivel)
        {
            switch (pNivel)
            {
                case "01 - Iniciado":
                    return 1;
                case "02 - Aprendiz":
                    return 2;
                case "03 - Estudiante":
                    return 3;
                case "04 - Avanzado":
                    return 4;
                case "05 - Maestro":
                    return 5;
                default:
                    return 0; // Para cualquier otro valor no esperado
            }
        }

        private void CargarCriaturasEnTabla()
        {
            Criatura[] criaturas = criaturaLN.ObtenerTodasLasCriaturas();
            dgvCriaturas.DataSource = criaturas;
            dgvCriaturas.Columns["Nivel"].Visible = false;
            dgvCriaturas.Columns["NivelTexto"].HeaderText = "Nivel";
            dgvCriaturas.Refresh();
            dgvCriaturas.ReadOnly = true;
            dgvCriaturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void frmRegistrarCriatura_Load(object sender, EventArgs e)
        {
            CargarCriaturasEnTabla();
        }
    }
}
