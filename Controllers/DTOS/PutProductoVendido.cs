namespace ProyectoFinalAppi.Controllers.DTOS
{
    public class PutProductoVendido
    {
        //variables.
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
        public int Stock { get; set; }
    }
}
