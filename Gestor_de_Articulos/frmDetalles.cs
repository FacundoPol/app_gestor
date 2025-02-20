using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_Articulos
{
    public partial class frmDetalles : Form
    {
        private Articulo articulo = null;
        public frmDetalles(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }
        private void frmDetalles_Load(object sender, EventArgs e)
        {
            lblCod1.Text = articulo.codigoArt;
            lblNom2.Text = articulo.nombreArt;
            lblDesc3.Text = articulo.descripcionArt;
            lblPre4.Text = "$ " + articulo.precio.ToString();
            lblMarc5.Text = articulo.marca.nombreMarca;
            lblCat6.Text = articulo.categoria.nombreCategoria;
            lblUrl7.Text = articulo.imgArt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
