namespace ECOCEMProject;

public class Empresa
 {
    public int EmpresaId {get; set;}
    public string NombreEmpresa {get; set;}
    public required List<Sede> Sedes {get; set;} 

 }