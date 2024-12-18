using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void Cargar()
        {
            Conexion2 c = new Conexion2();
            Art = c.MostrarArticulos();
            dgvPrincipal.DataSource = Art;
            ocultar_info();
        }

        private void dgvPrincipal_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrincipal.CurrentRow != null)
                {
                    Articulo seleccionado = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;
                    pbxArt.Load(seleccionado.imgArt);
                }
            }
            catch (Exception)
            {
                pbxArt.Load("https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Articulo> listfilt;
            string nombusq= tbxfilt.Text;
            if (nombusq != "")
            {
                listfilt = Art.FindAll(x => x.nombreArt.ToUpper().Contains(nombusq.ToUpper()) || x.descripcionArt.ToUpper().Contains(nombusq.ToUpper()) || x.categoria.nombreCategoria.ToUpper().Contains(nombusq.ToUpper()) || x.marca.nombreMarca.ToUpper().Contains(nombusq.ToUpper()));
                dgvPrincipal.DataSource = null;
                dgvPrincipal.DataSource = listfilt;
                ocultar_info();
            }
            else
            {
                dgvPrincipal.DataSource = Art;
                ocultar_info();
            }
        }

        private void ocultar_info()
        {
            dgvPrincipal.Columns["imgArt"].Visible = false;
        }
    }
}
