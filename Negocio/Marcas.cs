using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class Marcas
    {
        public List<Marca> listarMarc()
        {
            List<Marca> listmarc=new List<Marca>();
            Conexion conexion = new Conexion();
            try
            {
                conexion.SetearConsulta("SELECT * FROM MARCAS");
                conexion.EjecutarLectura();
                while (conexion.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.idMarca = (int)conexion.Lector["Id"];
                    marca.nombreMarca = (string)conexion.Lector["Descripcion"];
                    listmarc.Add(marca);
                }

                return listmarc;
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
