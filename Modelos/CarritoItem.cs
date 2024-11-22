using Tienda.Modelos;

namespace Tienda.Modelos
{
    public class CarritoItem
    {
        public Producto Producto { get; set; } = new Producto();
        public int Cantidad { get; set; }
    }
}
