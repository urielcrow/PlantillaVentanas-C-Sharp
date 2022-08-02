using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantillaVentanas
{
    public partial class FormMain : Form
    {
        private Controller _c;
        public FormMain()
        {
            InitializeComponent();
            _c = new Controller();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            List<EmpresasEsquema> empresas = _c.GetEmpresas();
            dataGridView1.DataSource = empresas;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List <EmpresasEsquema> empresas = _c.Buscar(inputBuscador.Text);
            dataGridView1.DataSource = empresas;
        }

        private void cleanBtn_Click(object sender, EventArgs e)
        {
            inputBuscador.Text = "";

            this.LoadData();
        }
    }
}
