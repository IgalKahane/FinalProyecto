using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto Vendido.
    [ApiController]
    [Route("[controller]")]

    public class VentaController : ControllerBase
    {
        [HttpGet]
        public List<Venta> GetVentas()
        {
            try
            {
                return VentaHandler.GetVentas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public bool EliminacionVenta([FromBody] int id)
        {
            try
            {
                return VentaHandler.EliminarVenta(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public bool ModificacionVenta([FromBody] PutVenta venta)
        {
            try
            {
                return VentaHandler.ModificarVenta(new Venta
                {
                    venta_Comentarios = venta.Comentarios,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public bool CreacionVenta([FromBody] PostVenta venta)
        {
            try
            {
                return VentaHandler.CrearVenta(new Venta
                {
                    venta_Id = venta.Id,
                    venta_Comentarios = venta.Comentarios,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}