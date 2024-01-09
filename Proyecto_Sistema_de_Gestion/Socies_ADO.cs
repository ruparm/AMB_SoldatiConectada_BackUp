using Microsoft.VisualBasic.FileIO;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_Sistema_de_Gestion
{
    //CONEXIÓN CON BASE DE DATOS 
    public static class Socies_ADO  // CADENA DE CONEXIÓN - COMANDOS DE CONEXION Y CONEXION EN SI
    {
        private static string connectionString; // tipo de conexión 
        private static MySqlConnection connection; // objeto tipo conexión
        private static MySqlCommand command; // objeto tipo comando


        static Socies_ADO()
        {
            Socies_ADO.connectionString = "Server=localhost;Database=socios_ado;Uid=root;Pwd=;"; // valores de la conexión

            Socies_ADO.connection = new MySqlConnection(Socies_ADO.connectionString); //tipo de conexion

            Socies_ADO.command = new MySqlCommand(); // instancia de clase

            Socies_ADO.command.CommandType = System.Data.CommandType.Text; // instrucciones del tipo TEXTO
            Socies_ADO.command.Connection = Socies_ADO.connection;

        }

        public static bool Guardar(Socies socio)
        {
            bool resultado = true;

            //METODO PARA AGREGAR NUEVO SOCIO

            try    
            {
                string query = "INSERT INTO socios ( apellido, nombre, plan, fechaAlta) VALUES ( @apellido, @nombre, @plan, @fechaAlta)";
                connection.Open();
                command.CommandText = query;
                command.Parameters.Clear();

                
                command.Parameters.AddWithValue("@apellido", socio.Apellido);
                command.Parameters.AddWithValue("@nombre", socio.Nombre);
                command.Parameters.AddWithValue("@plan", socio.Plan);
                command.Parameters.AddWithValue("@fechaAlta", socio.FechaAlta);

                command.ExecuteNonQuery(); // Esto hace que ejecute la query

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            { 
                connection.Close();
            }
            return resultado;
        }

        public static int LeerSiguienteID()
        {
            int siguienteId = -1;
            try
            {
                string query = "SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_schema = 'socios_ado' AND TABLE_NAME = 'socios';";
                connection.Open();
                command.CommandText = query;

                //siguienteId= (int)command.ExecuteScalar();

                //DATA READER: exclusivo para leer objetos de BDD, solo lectura
                using (MySqlDataReader dataReader= command.ExecuteReader())
                {
                    //leer todo lo que tiene el data reader
                    while (dataReader.Read()) //hasta que sea false y se deja de ejecutar
                    {
                        siguienteId = dataReader.GetInt32(0);
                    } 
                }

            }
            catch (Exception ex) //ATRAPAR LA FALLA
            {

              throw new Exception (ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return siguienteId;
        }

        //SELECT FROM CLIENTES}

        // GENERAR LA QUERY
        //DEBEMOS EVALUAR SI ES CONSULTA DE LECTURA O DE INSERSIÓN - EXECUTE NON QUERY O EXECUTE READER
        public static List<Socies> TraerTodos() //ACA ME TRAE A TODOS LOS DE LA BASE
        {
            List<Socies> misSocios = new List<Socies>();

            try
            {
                string query = "SELECT * FROM socios";
                connection.Open();
                command.CommandText = query;

                using (MySqlDataReader dataReader = command.ExecuteReader()) // esta query es de lectura!
                {
                    //ARMO UN ARRAY QUE IDENTIFICA LA POSICIÓN QUR TIENE CADA VARIABLE EN LA TABLA DEL SQL
                    while (dataReader.Read())
                    {
                        int idSocie = dataReader.GetInt16(0);
                        string apellido = dataReader.GetString(1);
                        string nombre = dataReader.GetString(2);                       
                        string plan = dataReader.GetString(3);
                        string fechaAlta = dataReader.GetString(4);

                        Socies nuevoSocio = new Socies (idSocie, apellido, nombre, plan,  fechaAlta);
                        misSocios.Add (nuevoSocio);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error");
            }
            finally
            {
                connection.Close();
            }
            return misSocios;
        }
               

        public static List<Socies> FiltroPlan(string planMayor) 
        {
            List<Socies> misSocios = new List<Socies>();
           

            try
            {
                string query = "SELECT FROM socios WHERE Plan = @plan";

                connection.Open();
                command.CommandText = query;
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@plan", planMayor);


                using (MySqlDataReader dataReader = command.ExecuteReader()) // esta query es de lectura!
                {
                    //ARMO UN ARRAY QUE IDENTIFICA LA POSICIÓN QUR TIENE CADA VARIABLE EN LA TABLA DEL SQL
                    while (dataReader.Read())
                    {
                        Socies miSocio = new Socies();

                        int idSocie = dataReader.GetInt16(0);
                        string apellido = dataReader.GetString(1);
                        string nombre = dataReader.GetString(2);                        
                        string plan = dataReader.GetString(3);
                        string fechaAlta = dataReader.GetString(4);

                        miSocio.IdSocie= idSocie;                        
                        miSocio.Apellido= apellido;
                        miSocio.Nombre = nombre;
                        miSocio.Plan= plan;
                        miSocio.FechaAlta= fechaAlta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error");
            }
            finally
            {
                connection.Close();
            }
            return misSocios;
        }



        //QUERY PARA ACTUALIZAR/MODIFICAR

        public static bool Modificar (Socies socio)
        {
            bool resultado = true;
       
            try    
            {
                string query = "UPDATE socios SET  apellido=@apellido, nombre=@nombre, plan=@plan, fechaAlta=@fechaAlta WHERE idSocie=@id";
                connection.Open();
                command.CommandText = query;
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@id", socio.IdSocie);                
                command.Parameters.AddWithValue("@apellido", socio.Apellido);
                command.Parameters.AddWithValue("@nombre", socio.Nombre);
                command.Parameters.AddWithValue("@plan", socio.Plan);
                command.Parameters.AddWithValue("@fechaAlta", socio.FechaAlta);

                command.ExecuteNonQuery(); // Esto hace que ejecute la query

            }
            catch (Exception ex)
            {
                throw new Exception($"Error");
                resultado = false;
            }
            finally
            {
                connection.Close();
            }
            return resultado;
        }

        //ELIMINAR
        //DELETE * FROM `socios` WHERE IdSocie=@id
        public static bool Eliminar(int idBorrar)   
        {
            bool resultado = true;

            try
            {
                string query = "DELETE FROM socios WHERE idSocie=@id;";
                connection.Open();
                command.CommandText = query;
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@id", idBorrar);                
               

                command.ExecuteNonQuery(); // Esto hace que ejecute la query

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar");
                resultado = false;
            }
            finally
            {
                connection.Close();
            }
            return resultado;
        }

        public static void Guardar()
        {
            throw new NotImplementedException();
        }
    }








}
