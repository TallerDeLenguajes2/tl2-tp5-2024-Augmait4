public class Presupuestos
{
    private int idPresupuesto;
    private string nombreDestinatario;
    private List<PresupuestosDetalle> detalle;
    Presupuestos(int idPresupuesto, string nombreDestinatario)
    {
        this.IdPresupuesto = idPresupuesto;
        this.NombreDestinatario = nombreDestinatario;
        detalle = new List<PresupuestosDetalle>();
    }
    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public List<PresupuestosDetalle> Detalle { get => detalle; set => detalle = value; }
    public static int montoPresupuesto(){
        int monto = 0;
        foreach (var item in )
        {
            
        }
        return monto;
    } 
}