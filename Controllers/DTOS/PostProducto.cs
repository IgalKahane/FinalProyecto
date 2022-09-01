namespace ProyectoFinalAppi.Controllers.DTOS
{
    public class PostProducto
    {
        //Variables.
        public int Id { get; set; }
        public int Costo { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
        public double PrecioDeVenta { get; set; }
        public string Descripcion { get; set; }
    }
}
