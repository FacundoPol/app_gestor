using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
            cbxTipo.Items.Add("MARCA");
            cbxTipo.Items.Add("CATEGORIA");
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

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    List<Articulo> listfilt;
        //    string nombusq= tbxfilt.Text;
        //    if (nombusq != "")
        //    {
        //        listfilt = Art.FindAll(x => x.nombreArt.ToUpper().Contains(nombusq.ToUpper()) || x.descripcionArt.ToUpper().Contains(nombusq.ToUpper()) || x.categoria.nombreCategoria.ToUpper().Contains(nombusq.ToUpper()) || x.marca.nombreMarca.ToUpper().Contains(nombusq.ToUpper()));
        //        dgvPrincipal.DataSource = null;
        //        dgvPrincipal.DataSource = listfilt;
        //        ocultar_info();
        //    }
        //    else
        //    {
        //        dgvPrincipal.DataSource = Art;
        //        ocultar_info();
        //    }
        //}

        private void ocultar_info()
        {
            dgvPrincipal.Columns["imgArt"].Visible = false;
            dgvPrincipal.Columns["idArt"].Visible = false;
        }

        private void tbxfilt_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listfilt;
            string nombusq = tbxfilt.Text;
            if (nombusq.Length != 0)
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
        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = cbxTipo.SelectedItem.ToString();
            if (seleccion == "MARCA")
            {
                Marcas marc = new Marcas();
                cbxOpcion.DataSource = marc.listarMarc();
            }
            else
            {
                Categorias cat = new Categorias();
                cbxOpcion.DataSource = cat.listarCat();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string categoria = cbxTipo.SelectedItem.ToString();
            string tipo = cbxOpcion.SelectedItem.ToString();
            try
            {
                Conexion2 conect = new Conexion2();
                dgvPrincipal.DataSource = conect.filtro_cbd(categoria, tipo);
                ocultar_info();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.ShowDialog();
            Cargar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = new Articulo();
            seleccionado = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;
            frmAgregar modificar = new frmAgregar(seleccionado);
            modificar.ShowDialog();
            Cargar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = new Articulo();
            seleccionado = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;
            DialogResult resultado = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR ESTE REGISTRO?","ELIMINAR",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes)
            {
                Conexion2 conexion = new Conexion2();
                conexion.EliminarArt(seleccionado.idArt);
                MessageBox.Show("ELIMINADO EXITOSAMENTE");
            }
            else
                MessageBox.Show("NO HA SIDO ELIMINADO");

            Cargar();
        }
    }
}
