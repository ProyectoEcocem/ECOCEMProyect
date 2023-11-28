using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class Trabajador
{
    public int TrabajadorId {get; set;}
    public string? NombreTrabajador {get; set;}
    public int SedeId {get; set;}

    /*[JsonIgnore]
    public  Sede Sede {get; set;} = new();*/
    [JsonIgnore]
    public List<OrdenTrabajoAtendida> OrdenesTrabajoAtendidas {get;} = new();

    
}