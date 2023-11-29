using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class Trabajador
{
    public int TrabajadorId {get; set;}
    public string? NombreTrabajador {get; set;}
    public int SedeId {get; set;}

    [JsonIgnore]
    public  virtual Sede Sede {get; set;} =null!;
    //
    //public List<OrdenTrabajoAtendida> OrdenesTrabajoAtendidas {get;} = new();

    
}