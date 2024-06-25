using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Empresa
{
    public int EmpresaId {get; set;}
    public string? NombreEmpresa {get; set;}
    
    public List<Sede>? Sedes {get; } = new List<Sede>();

}