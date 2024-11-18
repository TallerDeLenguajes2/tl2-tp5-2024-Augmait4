using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
public interface IPresupuestoRepository
{
    List<Presupuestos> GetAll();
    Presupuestos GetById(int id);
    void Create(Presupuestos presupuesto);
    void Update(int id, Productos producto, int cantidad);
    void Delete (int id);

}
public class PresupuestosRepository : IPresupuestoRepository
{
    private readonly string _stringConnection;
    public PresupuestosRepository(string stringConnection){
        _stringConnection = stringConnection;
    }
    public PresupuestosRepository()
    {
        presupuestos = new List<Presupuestos>();
    }
    public void crearPresupuesto(Presupuestos presupuesto)
    {
        presupuestos.Add(presupuesto);
    }
    public List<Presupuestos> ListarPresupuestos()
    {
        return presupuestos;
    }
    public Presupuestos detallesPresupuesto(int id)
    {
        var presupuestoElgido = presupuestos.FirstOrDefault(pr => pr.IdPresupuesto == id);
        if (presupuestoElgido == null) return null;
        return presupuestoElgido;
    }
    public bool AgregarDatosPresupuesto(int id)
    {
        var presupuestoElgido = presupuestos.FirstOrDefault(pr => pr.IdPresupuesto == id);
        if (presupuestoElgido == null) return false;

    }
}