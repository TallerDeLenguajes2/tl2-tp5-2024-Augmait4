using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_Augmait4.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestosController : ControllerBase
{
    private readonly PresupuestosRepository _presupuestoRepository;
    private readonly ProductoRepository _productoRepository;
    private readonly ILogger<PresupuestoController> _logger;

    public PresupuestosController(ILogger<PresupuestoController> logger)
    {
        _logger = logger;
        _presupuestoRepository = new PresupuestosRepository("Data Source=BD/Tienda.db;Cache = Shared");
        _productoRepository = new ProductoRepository(@"Data Source=BD/Tienda.db;Cache=Shared");
    }

    [HttpPost("/api/Presupuestos")]
    public ActionResult<Productos> Create([FromBody] Presupuestos presupuesto)
    {
        _presupuestoRepository.Created(presupuesto);
        return Created();
    }
    [HttpGet("/api/Presupuestos")]
    public List<Presupuestos> GetAll()
    {
        return _presupuestoRepository.GetAll();
    }
    [HttpPut("api/Presupuesto/{id}/ProductoDetalle")]
    public ActionResult AddProduct(int id, [FromForm] int idP, [FromForm] int cantidad)
    {
        Productos producto = _productoRepository.GetById(idP);
        if (producto == null)
        {
            return NotFound($"Producto {idP} no encontrado.");
        }

        _presupuestoRepository.Update(id, producto, cantidad);
        return Ok(_presupuestoRepository.GetById(id));
    }
    [HttpGet("{id}")]
    public ActionResult<Presupuestos> GetById(int id)
    {
        var presupuesto = _presupuestoRepository.GetById(id);
        if (presupuesto == null)
        {
            return NotFound("Presupuesto no encontrado.");
        }
        return Ok(presupuesto);
    }

}
