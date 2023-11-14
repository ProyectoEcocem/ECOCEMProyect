namespace ECOCEMProyect;

public class MedicionSilo
{
    public int Id { get; set; }
    public int SiloId {get; set;}
    public int MedidorId { get; set; }
    public DateTime FechaId {get; set;}

    public int Nivel {get; set; }
    public int Peso {get; set; }
    public int Volumen {get; set; }

    public Carga? Carga {get; set; }
    public Descarga? Descarga {get; set; }

}
