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
        private Articulo articulo = null;

        public frmAgregar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }
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
                if(articulo == null)
                    articulo = new Articulo();
                articulo.codigoArt = txtCod.Text;
                articulo.nombreArt = txtNomb.Text;
                articulo.descripcionArt = txtDesc.Text;
                articulo.precio = decimal.Parse(txtPrecio.Text);
                articulo.categoria = (Categoria)cbxCat.SelectedItem;
                articulo.marca = (Marca)cbxMarc.SelectedItem;
                articulo.imgArt = txtUrl.Text;

                if (articulo.idArt == 0)
                {
                    conect.AgregarArt(articulo);
                    MessageBox.Show("AGREGADO EXITOSAMENTE");
                }
                else
                {
                    conect.ModificarArt(articulo);
                    MessageBox.Show("MODIFICADO EXITOSAMENTE");
                }
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
                cbxCat.DataSource = cat.listarCat();
                cbxCat.ValueMember = "idCategoria";  // Debe coincidir con la clase
                cbxCat.DisplayMember = "nombreCategoria";

                Marcas marc = new Marcas();
                cbxMarc.DataSource = marc.listarMarc();
                cbxMarc.ValueMember = "idMarca";
                cbxMarc.DisplayMember = "nombreMarca";

                if (articulo != null)
                {
                    txtCod.Text=articulo.codigoArt;
                    txtNomb.Text=articulo.nombreArt;
                    txtDesc.Text=articulo.descripcionArt;
                    txtPrecio.Text = articulo.precio.ToString();
                    txtUrl.Text = articulo.imgArt;
                    CargarImg(articulo.imgArt);
                    cbxMarc.SelectedValue = articulo.marca.idMarca;
                    cbxCat.SelectedValue = articulo.categoria.idCategoria;
                }

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
