namespace ECOCEMProject;

public class CargaDto
{
    public string NombreTipoCemento { get; set; } = string.Empty;
    public string NoSerieSilo { get; set; } = string.Empty;
    public string NoSerieVehiculo { get; set; } = string.Empty;
    public DateTime FechaId { get; set; }
    public int PesoBruto { get; set; }
    public int Tara { get; set; }
    public string NoSerieMedidor { get; set; } = string.Empty;
    public int Nivel { get; set; }
    public int PesoMedidor { get; set; }
    public double Volumen { get; set; }
    public string NoSerieBascula { get; set; } = string.Empty;
    public int PesoBascula { get; set; }
}