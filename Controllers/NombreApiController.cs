using Microsoft.AspNetCore.Mvc;
using ProyectoFinalAppi.ADO_.NET;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto.
    [ApiController]
    [Route("[controller]")]

    public class NombreAppiController : ControllerBase
    {
        [HttpGet]
        public bool GetNombreAppi()
        {
            try
            {
                return NombreAppiHandler.GetNombreAppi();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
