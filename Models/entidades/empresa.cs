namespace ECOCEMProject.Models; 

public class Empresa
 {
    public int EmpresaId {get; set;}
    public string? NombreEmpresa {get; }
    public required List<Sede> Sedes {get; set;} 

 }