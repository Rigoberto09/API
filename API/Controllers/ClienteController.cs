using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

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

        [HttpGet]
        [Route("listar")]
        public ActionResult<IEnumerable<Cliente>> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            // Consultar los datos de la base de datos
            string consulta = "select * from clientes"; // consulta de sql
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
