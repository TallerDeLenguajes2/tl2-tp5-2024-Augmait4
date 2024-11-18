using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
public class ProductoRepository
{
    private readonly List<Productos> productos;
    public ProductoRepository(){
        productos = new List<Productos>();
    }
    public void CrearProducto(Productos producto){
        productos.Add(producto);
    }
    public bool ModificarProductos(int id, Productos producto){
        var productoExistente = productos.FirstOrDefault(p => p.IdProducto == id);
        if(productoExistente == null) return false;
        productoExistente.Descripcion = producto.Descripcion;
        productoExistente.Precio = producto.Precio;
        return true;
    }
    public List<Productos> ListarProductos(){
        return productos;
    }
    public Productos ObtenereDetalles(int id){
        return productos.FirstOrDefault(p => p.IdProducto == id);
    }
    public bool EliminarProducto(int id){
        var productoElegido = productos.FirstOrDefault(p => p.IdProducto == id);
        if(productoElegido == null)return false;
        productos.Remove(productoElegido);
        return true;
    }
}