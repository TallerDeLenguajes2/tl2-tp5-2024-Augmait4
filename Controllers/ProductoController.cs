using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_Augmait4.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private readonly ProductoRepository _productoRepository;
    private readonly ILogger<PresupuestoController> _logger;

    public PresupuestoController(ILogger<PresupuestoController> logger)
    {
        _logger = logger;
        _productoRepository = new ProductoRepository("Data Source=BD/Tienda.db;Cache = Shared");
    }

    [HttpPost("/api/Productos")]
    public ActionResult<Productos> Create([FromBody] Productos producto)
    {
        if (_productoRepository.ExistsByTitle(producto.Descripcion))
        {
            return BadRequest("Ya existe un elemnto con el Mismo Nmbre");
        }
        _productoRepository.Created(producto);
        return Created();
    }
    [HttpGet("/api/Productos")]
    public List<Productos> GetAll()
    {
        return _productoRepository.GetAll();
    }

    [HttpPut("/api/Productos")]
    public ActionResult<Productos> Update([FromBody] Productos producto, int idProducto)
    {
        _productoRepository.Update(idProducto, producto);
        return NoContent();
    }
}
