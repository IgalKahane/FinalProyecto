using Microsoft.AspNetCore.Mvc;
using ProyectoFinalAppi.ADO_.NET;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto.
    [ApiController]
    [Route("[controller]")]

    public class InicioSesionController : ControllerBase
    {
        public object InicioSesionHandler { get; private set; }

        public bool VerificarUsuario([FromBody] string nombre, string password)
        {
            try
            {
                return InicioSesionHandler.VerificarUsuario(nombre, password);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
