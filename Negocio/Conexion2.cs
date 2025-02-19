using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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
                c.SetearConsulta("select A.Id,Codigo,Nombre,A.Descripcion,ImagenUrl,Precio,M.Descripcion as marca,C.Descripcion as categoria,A.IdCategoria,A.IdMarca FROM ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                c.EjecutarLectura();

                while (c.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.idArt = (int)c.Lector["Id"];
                    art.codigoArt = (string)c.Lector["Codigo"];
                    art.nombreArt = (string)c.Lector["Nombre"];
                    art.descripcionArt = (string)c.Lector["Descripcion"];
                    art.imgArt = (string)c.Lector["ImagenUrl"];
                    art.precio = Math.Round((decimal)c.Lector["Precio"]);
                    art.marca = new Marca();
                    art.marca.nombreMarca = (string)c.Lector["marca"];
                    art.marca.idMarca = (int)c.Lector["IdMarca"];
                    art.categoria = new Categoria();
                    art.categoria.nombreCategoria = (string)c.Lector["categoria"];
                    art.categoria.idCategoria = (int)c.Lector["IdCategoria"];
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

        public void AgregarArt(Articulo art)
        {
            Conexion conex = new Conexion();
            try
            {
                conex.SetearConsulta("INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,Precio,IdCategoria,IdMarca,ImagenUrl) VALUES ('" + art.codigoArt + "','" + art.nombreArt + "','" + art.descripcionArt +"'," +art.precio + ",@idCat,@idMarc,'" + art.imgArt + "')");
                conex.SetearParametro("@idCat",art.categoria.idCategoria);
                conex.SetearParametro("@idMarc",art.marca.idMarca);
                conex.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conex.CerraConexion();
            }
        }

        public void ModificarArt(Articulo art)
        {
            Conexion conect = new Conexion(); 
            try
            {
                conect.SetearConsulta("UPDATE ARTICULOS SET Codigo =@codigo,Nombre =@Nombre,Descripcion = @Descripcion,IdMarca =@idMarca,IdCategoria =@idCategoria ,ImagenUrl = @imgUrl,Precio = @precio WHERE Id = @id");
                conect.SetearParametro("@codigo",art.codigoArt);
                conect.SetearParametro("@Nombre",art.nombreArt);
                conect.SetearParametro("@Descripcion",art.descripcionArt);
                conect.SetearParametro("@idMarca",art.marca.idMarca);
                conect.SetearParametro("@idCategoria",art.categoria.idCategoria);
                conect.SetearParametro("@imgUrl",art.imgArt);
                conect.SetearParametro("@precio",art.precio);
                conect.SetearParametro("@id",art.idArt);
                conect.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                conect.CerraConexion();
            }
        }


        public void EliminarArt(int id)
        {
            Conexion conexion = new Conexion();
            try
            {
                conexion.SetearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                conexion.SetearParametro("@id",id);
                conexion.EjecutarAccion();
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
