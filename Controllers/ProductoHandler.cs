using Microsoft.AspNetCore.Mvc;
using ProyectoFinalAppi.ADO_.NET;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto.
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public List<Producto> GetProductosPorId([FromBody] int id)
        {
            try
            {
                return ProductoHandler.GetProductosPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public bool EliminarProductos([FromBody] int id)
        {
            try
            {
                return ProductoHandler.EliminarProducto(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public bool ModificacionProducto([FromBody] PutProducto producto)
        {
            try
            {
                return ProductoHandler.ModificacionProducto(new Producto
                {
                    producto_Costo = producto.Costo,
                    producto_Stock = producto.Stock,
                    producto_IdUsuario = producto.IdUsuario,
                    producto_PrecioDeVenta = producto.PrecioDeVenta,
                    producto_Descipcion = producto.Descripcion,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public bool CreacionProducto([FromBody] PostProducto producto)
        {
            try
            {
                return ProductoHandler.CreacionProducto(new Producto
                {
                    producto_Id = producto.Id,
                    producto_Costo = producto.Costo,
                    producto_Stock = producto.Stock,
                    producto_IdUsuario = producto.IdUsuario,
                    producto_PrecioDeVenta = producto.PrecioDeVenta,
                    producto_Descipcion = producto.Descripcion,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

