using Digesett.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using System.Data;


namespace Digesett.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        readonly List<Employee> lista = [];
        private readonly string strconn= "Data Source=SERVER-ETIQUETA; Initial Catalog=DigesettNomina;User Id=Npino;Password=Jossycar5%;TrustServerCertificate=True;";
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
    }
}
