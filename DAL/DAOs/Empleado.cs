﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Net;
using System.Security.Cryptography;

namespace DAL.DAOs
{
    internal class Empleado
    {

        #region SingletonEmpleado, ConnectionString y Querys
        private Empleado() { }
        private static DAOs.Empleado instance;

        public static DAOs.Empleado GetInstance()
        {
            if (instance == null)
            {
                instance = new DAOs.Empleado();
            }
            return instance;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["Produccion"].ConnectionString;

        string QueryInsert = "INSERT INTO Empleado (Nombre, Apellido, DNI, Direccion, Telefono, FechaIngreso, ID_Linea)"+
            "VALUES (@Nombre, @Apellido, @DNI, @Direccion, @Telefono, @FechaDeingreso, @LineaPertenece)";

        string QueryDelete = "delete from empleado where legajo = @Legajo";

        string QuerySelect = "SELECT * FROM [ECSA].[dbo].[Empleado]";

        string QueryUpdate = "UPDATE Empleado " +
                         "SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, " +
                         "Direccion = @Direccion, Telefono = @Telefono, FechaIngreso = @FechaDeingreso, " +
                         "ID_Linea = @LineaPertenece " +
                         "WHERE Legajo = @Legajo";

        string QuerySelectByLegajo = "SELECT * FROM [ECSA].[dbo].[Empleado] where Legajo = @legajo";
        #endregion

        #region AgregarEmpleado
        public bool Agregar(string Nombre, string Apellido, DateTime FechaDeingreso, int DNI, string Telefono, string Direccion, int LineaPertenece)
        {
            bool returnValue = false;
            
            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Nombre", Nombre),
        new SqlParameter("@Apellido", Apellido),
        new SqlParameter("@FechaDeingreso", FechaDeingreso),
        new SqlParameter("@DNI", DNI),
        new SqlParameter("@Telefono", Telefono),
        new SqlParameter("@Direccion", Direccion),
        new SqlParameter("@LineaPertenece", LineaPertenece),
    };

            try
            {
                Console.WriteLine("Trying to execute insert operation...");
                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryInsert, parameters);
                returnValue = rowsAffected > 0;

                if (returnValue)
                {
                    Console.WriteLine("Empleado creado con éxito.");
                }
                else
                {
                    Console.WriteLine("No se insertó ninguna fila.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                returnValue = false;
            }

            return returnValue;
        }
        #endregion

        #region ListarEmpleados
        public List<BE.Empleado> Listar()
        {
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelect);
         

            return Mappers.Empleado.GetInstance().Map(table);
        }

        public List<BE.Empleado> Buscar(int Legajo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Legajo", Legajo),
        
    };
            DataTable table = SQLHelper.SqlHelper.GetInstance(connectionString).ExecuteDataTable(QuerySelectByLegajo, parameters);
            return Mappers.Empleado.GetInstance().Map(table);
        }
        #endregion

        #region ModificarEmpleado
        public bool Modificar(int Legajo,string Nombre, string Apellido, DateTime FechaDeingreso, int DNI, string Telefono, string Direccion, int LineaPertenece)
        {

            bool returnValue = false;

            

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Nombre", Nombre),
        new SqlParameter("@Apellido", Apellido),
        new SqlParameter("@FechaDeingreso", FechaDeingreso),
        new SqlParameter("@DNI", DNI),
        new SqlParameter("@Telefono", Telefono),
        new SqlParameter("@Direccion", Direccion),
        new SqlParameter("@LineaPertenece", LineaPertenece),
        new SqlParameter("@Legajo", Legajo) 
    };

            try
            {
                Console.WriteLine("Executing SQL: " + QueryUpdate);
                foreach (var param in parameters)
                {
                    Console.WriteLine($"{param.ParameterName}: {param.Value}");
                }

                int rowsAffected = SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryUpdate, parameters);
                returnValue = rowsAffected > 0;

                if (returnValue)
                {
                    Console.WriteLine("Empleado actualizado con éxito.");
                }
                else
                {
                    Console.WriteLine("No se actualizó ninguna fila.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                returnValue = false;
            }


            return returnValue;
        }

        #endregion

        #region ElimminarEmpleado
        public bool Eliminar(int Legajo)
        {
            bool returnValue = false;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
            new SqlParameter("@Legajo", Legajo),
            };

            SqlHelper.GetInstance(connectionString).ExecuteNonQuery(QueryDelete, parameters);
            returnValue = true;
            return returnValue;
        }

        #endregion

        #region ListarPorLegajo

        #endregion

    }
}
