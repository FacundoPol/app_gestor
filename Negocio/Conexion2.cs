using System;
<<<<<<< HEAD
=======
using System.Collections;
>>>>>>> 91bdecf (actualizacion)
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
<<<<<<< HEAD
=======

        public List<Articulo> filtro_cbd(string seleccion1,string seleccion2)
        {
            List<Articulo> lista = new List<Articulo>();
            Conexion conexcbd = new Conexion();

            try
            {
                string filtro = "select a.Codigo,a.Nombre,a.Descripcion,m.Descripcion,c.Descripcion,a.ImagenUrl,a.Precio,M.Descripcion as marca,C.Descripcion as categoria from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdMarca = m.Id AND a.IdCategoria = C.Id and ";

                switch (seleccion1)
                {
                    case "MARCA":
                        filtro = filtro + "m.descripcion = '" + seleccion2 + "'";
                        break;
                    case "CATEGORIA":
                        filtro = filtro + "c.descripcion = '" + seleccion2 + "'";
                        break;
                }
                conexcbd.SetearConsulta(filtro);
                conexcbd.EjecutarLectura();

                while (conexcbd.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.codigoArt = (string)conexcbd.Lector["Codigo"];
                    art.nombreArt = (string)conexcbd.Lector["Nombre"];
                    art.descripcionArt = (string)conexcbd.Lector["Descripcion"];
                    art.imgArt = (string)conexcbd.Lector["ImagenUrl"];
                    art.precio = (decimal)conexcbd.Lector["Precio"];
                    art.marca = new Marca();
                    art.marca.nombreMarca = (string)conexcbd.Lector["marca"];
                    art.categoria = new Categoria();
                    art.categoria.nombreCategoria = (string)conexcbd.Lector["categoria"];
                    lista.Add(art);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexcbd.CerraConexion();
            }

            return lista;
        }
>>>>>>> 91bdecf (actualizacion)
    }
}
