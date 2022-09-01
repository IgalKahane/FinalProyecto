using Microsoft.AspNetCore.Mvc;
using ProyectoFinalAppi.ADO_.NET;
using ProyectoFinalAppi.Controllers.DTOS;
using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador de Producto Vendido.
    [ApiController]
    [Route("[controller]")]

    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet]
        public List<ProductoVendido> GetProductosVendidosPorId([FromBody] int id)
        {
            try
            {
                return ProductoVendidoHandler.GetProductosVendidosPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public bool EliminacionProductoVendido([FromBody] int id)
        {
            try
            {
                return ProductoVendidoHandler.EliminarProductoVendido(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public bool ModificacionProductoVendido([FromBody] PutProductoVendido productoVendido)
        {
            try
            {
                return ProductoVendidoHandler.ModificarProductoVendido(new ProductoVendido
                {
                    productoVendido_IdProducto = productoVendido.IdProducto,
                    productoVendido_IdVenta = productoVendido.IdVenta,
                    productoVendido_Stock = productoVendido.Stock,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public bool CreacionProductoVendido([FromBody] PostProductoVendido productoVendido)
        {
            try
            {
                return ProductoVendidoHandler.CreacionProductoVendido(new ProductoVendido
                {
                    productoVendido_Id = productoVendido.Id,
                    productoVendido_IdProducto = productoVendido.IdProducto,
                    productoVendido_IdVenta = productoVendido.IdVenta,
                    productoVendido_Stock = productoVendido.Stock,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}