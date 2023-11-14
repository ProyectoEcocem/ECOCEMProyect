using ECOCEMProyect;

namespace ECOCEMProyect;

public class Herramientas
{
    public int HerramientasId { get; set; }
    public List<OrdenTrabajoHerramienta> OrdenTrabajoHerramientas {get; } = new();
    public List<HerramientaMantNecesario> HerramientaMantNecesarios {get; } = new();
}