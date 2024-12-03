namespace Tienda.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImagenURL { get; set; }
        public string Categoria { get; set; }
    }

}
