﻿using System;

// Agregar los namespaces para la conexión con SQL Server
using System.Data;
using System.Data.SqlClient;

namespace _01___Fábrica_de_Conexiones
{
    class MyConnectionSql : MyConnection
    {
        public MyConnectionSql(DataProvider theDataProvider) : base(theDataProvider)
        {
            // Utilizando un ConnectionString para realizar la conexión
            // con el servidor SQL Server
            SqlConnection connectionString = new SqlConnection(@"server = (local)\sqlexpress; integrated security = true;");// con el @ tenemos mas libertad para la escritura
            try
            {
                //Abrir la conexion
                connectionString.Open();

                //Detalles de la conexion
                this.DetallesConexion(connectionString);
            }
            catch (SqlException e)
            {
                //Desplegar el mensaje de error
                Console.WriteLine("Error {0} {1}", e.Message, e.StackTrace);
            }
            finally
            {
                //cerrar la conexion
                connectionString.Close();
                Console.WriteLine("Conexion finalizada");
            }
        }

        protected void DetallesConexion(SqlConnection connectionString)
        {
            Console.WriteLine("Conexion establecida");
            Console.WriteLine("\tConnection string: {0}", connectionString.ConnectionString);
            Console.WriteLine("\tBase de datos: {0}", connectionString.Database);
            Console.WriteLine("\tFuente de datos: {0}", connectionString.DataSource);
            Console.WriteLine("\tVersion del Servidor: {0}", connectionString.ServerVersion);
            Console.WriteLine("\tEstado: {0}", connectionString.State);
            Console.WriteLine("\tId estacion de trabajo: {0}", connectionString.WorkstationId);
        }
    }
}