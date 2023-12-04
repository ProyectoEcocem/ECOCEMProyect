

namespace ECOCEMProject;

public class Herramienta
{
    public int HerramientaId { get; set; }
    public List<OrdenTrabajoHerramienta> OrdenTrabajoHerramientas {get; } = new();
    public List<HerramientaMantNecesario> HerramientaMantNecesarios {get; } = new();
}