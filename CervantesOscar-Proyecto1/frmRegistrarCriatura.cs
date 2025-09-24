using Entidades;
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
        }

        private void frmRegistrarCriatura_Load(object sender, EventArgs e)
        {
            CargarCriaturasEnTabla();
        }
    }
}
