public class Sede
{
    public int IdSede {get; set;}
    public string NombreSede {get; set;}
    public string UbicacionSede {get; set;}
    public int IdEmpresa {get; set;}
    public Empresa Empresa {get; set;} = null!;
    
}