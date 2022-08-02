using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PlantillaVentanas
{
    class Model 
    {
        private const string MYSQL = @"server=localhost;userid=root;password='';database=asesores_empresariales";
        private MySqlConnection conexion;

        public Model() 
        {
            conexion = new MySqlConnection(MYSQL);
        }

        public List<EmpresasEsquema> Buscar(string empresa)
        {
            List<EmpresasEsquema> empresas = new List<EmpresasEsquema>();

            try
            {
                conexion.Open();
                string sql = @"SELECT id,nombre 
                               FROM empresas_ae 
                               WHERE nombre LIKE @empresa";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@empresa", "%" + empresa + "%");//PARA EL USO DE LIKE
                cmd.Prepare();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    empresas.Add(new EmpresasEsquema
                    {
                        id = int.Parse(rdr["id"].ToString()),
                        nombre = rdr["nombre"].ToString()
                    });
                   
                }
                rdr.Close();

                return empresas;
            }
            catch (Exception){
                throw;
            }
            finally
            {
                conexion.Close();
            }
           
        }

        public List<EmpresasEsquema> GetEmpresas()
        {
            List<EmpresasEsquema> empresas = new List<EmpresasEsquema>();
            
            try
            {
                conexion.Open();
                string sql = @"SELECT id,nombre 
                               FROM empresas_ae";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    empresas.Add(new EmpresasEsquema {
                        id = int.Parse(rdr["id"].ToString()),
                        nombre = rdr["nombre"].ToString()
                    });
                }
                rdr.Close();

                return empresas;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

        }
    }
}
