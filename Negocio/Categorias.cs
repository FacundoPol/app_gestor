using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class Categorias
    {
        public List<Categoria> listarCat()
        {
            List<Categoria> listcat = new List<Categoria>();
            Conexion conexion = new Conexion();
            try
            {
                conexion.SetearConsulta("SELECT * FROM CATEGORIAS");
                conexion.EjecutarLectura();

                while (conexion.Lector.Read())
                {
                    Categoria cat = new Categoria();
                    cat.idCategoria = (int)conexion.Lector["id"];
                    cat.nombreCategoria = (string)conexion.Lector["Descripcion"];
                    listcat.Add(cat);
                }

                return listcat;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.CerraConexion();
            }
        }

        
    }
}
