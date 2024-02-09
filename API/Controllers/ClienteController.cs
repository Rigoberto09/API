using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace API.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private Basededatos basededatos;

        public ClienteController()
        {
            basededatos = new Basededatos();
        }
        //[HttpGet]
        //[Route("listar")]
        //public ActionResult<IEnumerable<Cliente>> ListarClientes()
        //{
        //    List<Cliente> clientes = new List<Cliente>();

        //    try
        //    {
        //        using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-KRV18GC\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Encrypt=True;"))
        //        {
        //            // Abre la conexión
        //            conexion.Open();

        //            // Consultar los datos de la base de datos
        //            string consulta = "select * from clientes"; // consulta SQL 

        //            // Crea un comando SQL con la consulta especificada y la conexión
        //            SqlCommand comando = new SqlCommand(consulta, conexion);

        //            // Ejecuta el comando y obtén los datos utilizando un DataReader
        //            using (SqlDataReader reader = comando.ExecuteReader())
        //            {
        //                // Lee los datos y mapea cada fila a un objeto Cliente
        //                while (reader.Read())
        //                {
        //                    Cliente cliente = new Cliente
        //                    {
        //                        primer_nombre = reader["primer_nombre"].ToString(),
        //                        segundo_nombre = reader["segundo_nombre"].ToString(),
        //                        primer_apellido = reader["primer_apellido"].ToString(),
        //                        segundo_apellido = reader["segundo_apellido"].ToString(),
        //                        direccion = reader["direccion"].ToString(),
        //                        telefono = reader["telefono"].ToString(),
        //                        correo = reader["correo"].ToString()
        //                    };

        //                    // Agrega el cliente a la lista
        //                    clientes.Add(cliente);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Maneja cualquier excepción que pueda ocurrir durante la consulta
        //        Console.WriteLine("Error al consultar la base de datos: " + ex.Message);
        //        // Devuelve un código de error HTTP 500 Internal Server Error
        //        return StatusCode(500);
        //    }

        //    // Devuelve la lista de clientes como resultado
        //    return clientes;
        //}


        [HttpGet]
        [Route("listar")]
        public ActionResult<IEnumerable<Cliente>> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            // Consultar los datos de la base de datos
            string consulta = "select * from clientes"; // consulta SQL
            DataTable resultados = basededatos.Consultar(consulta);

            // Si hay resultados, mapearlos a objetos Cliente y agregarlos a la lista
            if (resultados != null)
            {
                foreach (DataRow fila in resultados.Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        primer_nombre = fila["primer_nombre"].ToString(),
                        segundo_nombre = fila["segundo_nombre"].ToString(),
                        primer_apellido = fila["primer_apellido"].ToString(),
                        segundo_apellido = fila["segundo_apellido"].ToString(),
                        direccion = fila["direccion"].ToString(),
                        telefono = fila["telefono"].ToString(),
                        correo = fila["correo"].ToString()
                    };

                    clientes.Add(cliente);
                }
            }

            return clientes;
        }


        [HttpGet]
        [Route("listarl")]
        public ActionResult<string> Listar()
        {
            return "¡Lista de clientes!";
        }
    }
}
