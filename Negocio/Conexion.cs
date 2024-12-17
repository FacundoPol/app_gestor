using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//LIBRERIA PARA CONEXION SQL
using System.Data;

namespace Negocio
{
    public class Conexion
    {
        private SqlConnection _conexion;
        private SqlCommand _comando;
        private SqlDataReader _lector;

        public SqlDataReader Lector
        {
            get { return _lector; }
        }

        public Conexion()
        {
            _conexion = new SqlConnection("server = .\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true");
            _comando = new SqlCommand();
        }

        public void SetearConsulta(string consulta)
        {
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.CommandText = consulta;
        }

        public void EjecutarLectura()
        {
            _comando.Connection = _conexion;
            try
            {
                _conexion.Open();
                _lector = _comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EjecutarAccion()
        {
            _comando.Connection = _conexion;
            try
            {
                _conexion.Open();
                _comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void CerraConexion()
        {
            if (Lector != null)
                Lector.Close();
            _conexion.Close();
        }

        public void SetearParametro(string nomParamentro,object valor)
        {
            _comando.Parameters.AddWithValue(nomParamentro,valor);
        }

    }
}
