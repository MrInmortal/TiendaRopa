using Microsoft.JSInterop;
using System.Text.Json;
using Tienda.Modelos;

namespace Tienda.Servicios
{
    public class CarritoService
    {
        private const string CarritoKey = "carrito";
        private readonly IJSRuntime _jsRuntime;

        public CarritoService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        // Obtener carrito desde LocalStorage
        public async Task<List<CarritoItem>> ObtenerCarritoAsync()
        {
            var carritoJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", CarritoKey);
            return string.IsNullOrEmpty(carritoJson)
                ? new List<CarritoItem>()
                : JsonSerializer.Deserialize<List<CarritoItem>>(carritoJson) ?? new List<CarritoItem>();
        }

        // Guardar carrito en LocalStorage
        public async Task GuardarCarritoAsync(List<CarritoItem> carrito)
        {
            var carritoJson = JsonSerializer.Serialize(carrito);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", CarritoKey, carritoJson);
        }

        // Vaciar carrito
        public async Task VaciarCarritoAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", CarritoKey);
        }

        // Eliminar un producto del carrito
        public async Task EliminarProductoAsync(CarritoItem item)
        {
            var carrito = await ObtenerCarritoAsync();  // Obtener el carrito actual
            var productoAEliminar = carrito.FirstOrDefault(i => i.Producto.Id == item.Producto.Id); // Buscar el producto por ID

            if (productoAEliminar != null)
            {
                carrito.Remove(productoAEliminar); // Eliminar el producto del carrito
                await GuardarCarritoAsync(carrito);  // Guardar el carrito actualizado en LocalStorage
            }
        }
    }
}
