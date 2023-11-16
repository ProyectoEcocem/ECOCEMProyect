namespace ECOCEMProject.Models; 

public class Silo
{
    public int SiloId {get; set;}
    public int EquipoId {get; set;}
    public required Equipo Equipo {get;set;}
}
