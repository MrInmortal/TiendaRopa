namespace Tienda.Modelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
