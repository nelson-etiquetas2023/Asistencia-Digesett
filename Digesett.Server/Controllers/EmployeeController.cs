using Digesett.Shared.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;


namespace Digesett.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        readonly List<Employee> lista = [];
        private readonly string strconn= "Data Source=SERVER-ETIQUETA; Initial Catalog=DigesettNomina;User Id=Npino;Password=Jossycar5%;TrustServerCertificate=True;";
        private readonly string strconn2 = "Data Source=192.168.10.13,63520; Initial Catalog=BDBioAdminSQL;User Id=Npino;Password=Jossycar5%;TrustServerCertificate=True;";
        public string errorConn = "";
        public bool errorStatus = false;

        [HttpGet]
        public async Task<List<Employee>> GetDataEmployee() 
        {
            try
            {
                //contruir el objeto conexion de SQL a la base de datos.
                using SqlConnection conn = new(strconn);
                //construir el objeto comando SQL.
                SqlCommand comando = new("LoadDataEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //abrir la base de datos.
                await conn.OpenAsync();
                //Ejecutar el reader que hace la consulta y devuelve un SqlDataReader.
                SqlDataReader reader = comando.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    //creo una instancia del objeto punchdayly para incluirlo en la lista.
                    Employee emp = new()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Direction = reader.GetString("Direction"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        Cargo = reader.GetString("Cargo"),
                        Departament = reader.GetString("Departament"),
                        Email = reader.GetString("Email"),
                        Salary = reader.GetDecimal("Salario"),
                        Sexo = reader.GetBoolean("Sexo"),
                        BirthDate = reader.GetDateTime("BirthDate"),
                        Active = reader.GetBoolean("Active")
                    };
                    lista.Add(emp);
                }
                await reader.CloseAsync();  
            }
            catch (SqlException ex) 
            {
                errorConn = ex.Message;
                errorStatus = true;
            }
            return lista;
        }

        [HttpPost]
        public void Post(IEnumerable<Employee> employees)
        {
            SqlConnection conn = new(strconn2);
            conn.Open();
            foreach (var item in employees) 
            {
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO [dbo].[User] ([IdUser], [Name], [Gender],[Title],[BirthDay],[PhoneNumber],[MobileNumber],[Address],[IdentificationNumber],[Position],[IdDepartment]," +
                    " [Active], [Privilege]," +
                          "[HourSalary], [PreferredIdLanguage], [CreatedBy], [CreatedDatetime], [ModifiedBy]," + "[ModifiedDatetime], [UseShift]) VALUES (@p1 ,@p2 ,@p3 ,@p4 ,@p5 ,@p6 ,@p7 ,@p8 ,@p9,@p10 ,@p11, 1, 0, 0, 0, 0," +
                          "GETDATE(), 0, GETDATE(), 0)"
                };
                SqlParameter p1 = new("@p1", item.Id);
                SqlParameter p2 = new("@p2", item.Name);
                SqlParameter p3 = new("@p3", item.Genero);
                SqlParameter p4 = new("@p4", item.Title);
                SqlParameter p5 = new("@p5", item.BirthDate);
                SqlParameter p6 = new("@p6", item.PhoneNumber);
                SqlParameter p7 = new("@p7", item.MobileNumber);
                SqlParameter p8 = new("@p8", item.Direction);
                SqlParameter p9 = new("@p9", item.IdentificationNumber);
                SqlParameter p10 = new("@p10", item.Cargo);
                SqlParameter p11 = new("@p11", item.IdDepartment);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.Parameters.Add(p8);
                comando.Parameters.Add(p9);
                comando.Parameters.Add(p10);
                comando.Parameters.Add(p11);
                comando.ExecuteNonQuery();
            }
        }

        [HttpPost]
        [Route("/api/excel/loadDepartament")]
        public async Task<ActionResult> LoadDepartamentAsync(IEnumerable<Departament> departs) 
        {
            SqlConnection conn = new(strconn2);
            conn.Open();
            foreach (var item in departs)
            {
                SqlCommand comando = new()
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO department (IdParent,[dbo].Description,Comment) VALUES (@p1,@p2,@p3)"
                };
                SqlParameter p1 = new("@p1", item.IdParent);
                SqlParameter p2 = new("@p2", item.Name);
                SqlParameter p3 = new("@p3", item.Comment);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                await comando.ExecuteNonQueryAsync();
            }
            return Ok();
        } 
    }
}

