namespace API.Models
{
    public class Cliente
    {
        public string id {  get; set; } 
        public int id_cliente { get; set; }
        public string primer_nombre {  get; set; }
        public string segundo_nombre {  get; set; }
        public string primer_apellido {  get; set; }
        public string segundo_apellido {  get; set; }
        public string direccion {  get; set; }
        public string telefono {  get; set; }
        public string correo {  get; set; }
        public string fecha_registro { get; set; } 
    public string usuario_creo {  get; set; }
        public string usuario_borro {  get; set; } 
    }
}
