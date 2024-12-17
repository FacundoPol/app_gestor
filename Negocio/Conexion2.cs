using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class Conexion2
    {
        public List<Articulo> MostrarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            Conexion c = new Conexion();
            try
            {
                c.SetearConsulta("select Codigo,Nombre,A.Descripcion,ImagenUrl,Precio,M.Descripcion as marca,C.Descripcion as categoria FROM ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                c.EjecutarLectura();

                while (c.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.codigoArt = (string)c.Lector["Codigo"];
                    art.nombreArt = (string)c.Lector["Nombre"];
                    art.descripcionArt = (string)c.Lector["Descripcion"];
                    art.imgArt = (string)c.Lector["ImagenUrl"];
                    art.precio = (decimal)c.Lector["Precio"];
                    art.marca = new Marca();
                    art.marca.nombreMarca = (string)c.Lector["marca"];
                    art.categoria = new Categoria();
                    art.categoria.nombreCategoria = (string)c.Lector["categoria"];
                    lista.Add(art);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                c.CerraConexion();
            }

            return lista;
        }
    }
}
