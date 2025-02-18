using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Dominio;
using Negocio;

namespace Gestor_de_Articulos
{
    public partial class frmAgregar : Form
    {
        Articulo articulo = null;
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion2 conect = new Conexion2();
            try
            {
                articulo = new Articulo();
                articulo.codigoArt = txtCod.Text;
                articulo.nombreArt = txtNomb.Text;
                articulo.descripcionArt = txtDesc.Text;
                articulo.precio = decimal.Parse(txtPrecio.Text);
                articulo.categoria = (Categoria)cbxCat.SelectedItem;
                articulo.marca = (Marca)cbxMarc.SelectedItem;
                articulo.imgArt = txtUrl.Text;

                conect.AgregarArt(articulo);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            try
            {
                Categorias cat = new Categorias();
                cbxCat.Items.Clear();
                cbxCat.DataSource = cat.listarCat();
                //cbxCat.DisplayMember = "nombreCategoria";
                //cbxCat.ValueMember = "idCategoria";

                Marcas marc = new Marcas();
                cbxMarc.Items.Clear();
                cbxMarc.DataSource = marc.listarMarc();
                //cbxMarc.DisplayMember = "nombreMarca";
                //cbxMarc.ValueMember = "idMarca";

                }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            CargarImg(txtUrl.Text);
        }

        private void CargarImg(string url)
        {
             try
            {
                    pbxAgregar.Load(url);
            }
            catch (Exception)
            {
                pbxAgregar.Load("https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg");
            }
        }
    }
}
