using System.Data;
using System.Data.SqlClient;
namespace API.Data
{

    public class Basededatos
    {
        string datosConexion = "Data Source=DESKTOP-KRV18GC\\SQLEXPRESS;initial Catalog=master; Integrated Security=True";
        //string datosConexion = "Data Source=DESKTOP-KRV18GC\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Encrypt=True;";

        public SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-KRV18GC\\SQLEXPRESS;initial Catalog=master; Integrated Security=True;");

        public Basededatos()
        {
            conexion.ConnectionString = datosConexion;
        }

        public void abrir()
        {
            try
            {
                conexion.Open();
                Console.WriteLine("Conexion abierta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
        }

        public void cerrar()
        {
            conexion.Close();
        }

        public DataTable Consultar(string consulta)
        {
            DataTable resultados = new DataTable();

            try
            {
                // Abre la conexión
                abrir();

                // Crea un comando SQL con la consulta especificada y la conexión
                SqlCommand comando = new SqlCommand(consulta, conexion);

                // Ejecuta la consulta y llena los resultados en un DataTable
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                Console.WriteLine("consulta", resultados.ToString());
                adaptador.Fill(resultados);
                Console.WriteLine("consulta",resultados.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                // Cierra la conexión
                cerrar();
            }

            return resultados;
        }

    }
}
