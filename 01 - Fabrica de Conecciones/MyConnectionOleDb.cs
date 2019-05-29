using System;
//Namespaces necesarios para realizar la conexion 
using System.Data;
using System.Data.OleDb;
namespace _01___Fábrica_de_Conexiones
{
    class MyConnectionOleDb
    {
        //Constructor
        public MyConnectionOleDb(DataProvider theDataProvider) : base(theDataProvider)
        {
            //Crear la cadena de conexion
            OleDbConnection connectionString = new OleDbConnection(@"provider = sqloledb
                data source = (local)/sqlexpress; integrated security = sspi;");//sspi para modo de autenticacion de windows
            try
            {
                //Esctablecer conexión
                connectionString.Open();
                Console.WriteLine("Conexion establecida");

                //Detalles de la conexion
                this.DetallesConexion(connectionString);
            }
            catch (OleDbException e)
            {
                //Desplegar el error en la conexion
                Console.WriteLine("Error: {0} {1}", e.Message, e.StackTrace);
            }
            finally
            {
                //Cerrar la conexion
                connectionString.Close();
            }
        }

        protected void DetallesConexion(OleDbConnection connectionString)
        {
            Console.WriteLine("Conexion establecida");
            Console.WriteLine("\tConnection string: {0}", connectionString.ConnectionString);
            Console.WriteLine("\tBase de datos: {0}", connectionString.Database);
            Console.WriteLine("\tFuente de datos: {0}", connectionString.DataSource);
            Console.WriteLine("\tVersion del Servidor: {0}", connectionString.ServerVersion);
            Console.WriteLine("\tEstado: {0}", connectionString.State);// Con oldb no se puede saaber el workstation
            //Finalizacion de la clase MyConnectionOleDb con los detalles de conexion
        }
    }
}