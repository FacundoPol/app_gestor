using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Gestor_de_Articulos
{
    public partial class Form1 : Form
    {

        private List<Articulo> Art;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {
            Conexion2 c = new Conexion2();
            Art = c.MostrarArticulos();
            dgvPrincipal.DataSource = Art;
            dgvPrincipal.Columns["imagen"].Visible = false;
        }
    }
}
