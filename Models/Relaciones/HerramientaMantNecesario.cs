
using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class HerramientaMantNecesario
{
    public int HerramientasId {get; set;}
    [JsonIgnore]
    public Herramienta? Herramienta {get; set;}

    //llaves de Mantenimiento necesario
    public int TipoEquipoId {get; set;}
    public int AMId {get; set;}
    public double HorasExpId {get; set; }

    [JsonIgnore]
    public MantenimientoNecesario? MantenimientoNecesario {get; set;}
    

    public string UnidadMedidaR {get; set;} =null!;
    public int CantidadR {get; set;}
}