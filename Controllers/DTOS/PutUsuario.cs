using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers.DTOS
{
    public class PutUsuario
    {
        //Variables.
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
