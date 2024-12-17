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
                c.SetearConsulta("select Codigo,Nombre,Descripcion,ImagenUrl,Precio FROM ARTICULOS");
                c.EjecutarLectura();

                while (c.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    Marca marca = new Marca();
                    Articulo art = new Articulo();
                    art.codigoArt = (string)c.Lector["Codigo"];
                    art.nombreArt = (string)c.Lector["Nombre"];
                    art.descripcionArt = (string)c.Lector["Descripcion"];
                    art.imgArt = (string)c.Lector["ImagenUrl"];
                    art.precio = (double)c.Lector["Precio"];

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
