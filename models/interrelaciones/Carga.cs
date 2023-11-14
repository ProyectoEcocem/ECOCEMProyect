namespace ECOCEMProyect;

public class Carga
{
    public int Id { get; set; }
    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public int VehiculoId { get; set; }
    public DateTime FechaId {get; set;}

    public required Venta Venta {get; set; }

    public required ICollection<MedicionSilo> MedicionesSilo {get; set; }
    public required ICollection<MedicionBascula> MedicionesBascula {get; set; }
}
