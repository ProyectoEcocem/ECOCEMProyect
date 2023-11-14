namespace ECOCEMProyect;

public class MedicionBascula
{
    public int VehiculoId { get; set; }
    public int BasculaId { get; set; }
    public DateTime FechaId {get; set;}

    public int Peso {get; set; }

    public Carga? Carga {get; set; }
    public Descarga? Descarga {get; set; }
}
