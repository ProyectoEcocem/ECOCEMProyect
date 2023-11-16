namespace ECOCEMProject.Models; 

public class MedicionSilo
{
    public int SiloId {get; set;}
    public int MedidorId { get; set; }
    public DateTime FechaMId {get; set;}

    public int Nivel {get; set; }
    public int PesoM {get; set; }
    public int Volumen {get; set; }


    public int TipoCementoId { get; set; }
    public int VehiculoId { get; set; }
    public DateTime FechaCargaId {get; set;}
    public Carga? Carga {get; set; }
    public Descarga? Descarga {get; set; }

}
