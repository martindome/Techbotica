using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DataAccessLayer
{
    public class Acceso_DAL
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        SqlTransaction transaccion;

        public void abrir()
        {
            conexion.Open();
        }

        public void cerrar()
        {
            conexion.Close();
        }

        private SqlCommand crear_comando(string storeprocedure, SqlParameter[] parametros)
        {
            // INSTANCIO UN COMANDO DE TIPO SQL COMMAND
            SqlCommand comando = new SqlCommand();
            // AL COMANDO INSTANCIADO LE PASO LA CONEXION
            comando.Connection = conexion;
            // LE INDICO EL TIPO DE COMANDO QUE SERA STORE PROCEDURE
            comando.CommandType = CommandType.StoredProcedure;
            // LE PASO EL COMMANDTEXT --> STRING storeprocedure
            comando.CommandText = storeprocedure;
            //SI LA TRANSACCION TIENE DATOS (ES TRANSACCION) 
            if (transaccion != null)
            {
                //LE PASO LA TRANSACCION A MI COMANDO
                comando.Transaction = transaccion;
            }
            if (parametros != null)
            {
                // SI HAY PARAMETROS, PASO PARAMETROS
                comando.Parameters.AddRange(parametros);
            }
            return comando;
        }

        public DataTable ejecutar_stored_procedure(string storeprocedure, SqlParameter[] parametros)
        {
            //CREAMOS EL OBJETO TABLA 
            DataTable tabla = new DataTable();
            //CREAMOS EL ADAPTADOR (puente para recuperar datos de la tabla)
            SqlDataAdapter adaptador = new SqlDataAdapter();
            //PASAMOS AL SELECT COMMAND EL COMANDO (DESDE EL METODO CREAR COMANDO QUE LO HACE TODO) 
            adaptador.SelectCommand = crear_comando(storeprocedure, parametros);
            // AGREGAMOS LAS FILAS A LA TABLA
            adaptador.Fill(tabla);
            adaptador = null;
            return tabla;
        }

        public DataTable ejecutar_query(string query)
        {
            //CREAMOS EL OBJETO TABLA 
            DataTable tabla = new DataTable();
            //CREAMOS EL ADAPTADOR (puente para recuperar datos de la tabla)
            SqlDataAdapter adaptador = new SqlDataAdapter();
            //PASAMOS AL SELECT COMMAND EL COMANDO (DESDE EL METODO CREAR COMANDO QUE LO HACE TODO) 
            adaptador.SelectCommand = new SqlCommand(query);
            adaptador.SelectCommand.Connection = conexion;
            abrir();
            // AGREGAMOS LAS FILAS A LA TABLA
            adaptador.Fill(tabla);
            cerrar();
            adaptador = null;
            return tabla;
        }

        public bool execute_query(string Query)
        {
            bool result = true;

            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conexion;
                comm.CommandType = CommandType.Text;
                comm.CommandText = string.Format(Query);
                conexion.Open();
                comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
                Console.WriteLine(Query);
            }
            finally
            {
                conexion.Close();
            }
            return result;
        }
    }
}
