namespace ECOCEMProject;

public class VentaDto
{
    public int SedeId { get; set; }
    public int EntidadCompradoraId { get; set; }
    public string NombreEntidadCompradora { get; set; } = string.Empty;
    public DateTime FechaVentaId { get; set; }
}