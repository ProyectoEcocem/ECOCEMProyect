using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Silo
{
    public int SiloId {get; set;}
    public string? NoSilo {get; set;}
    public int NoSede {get; set;}
    public int radio{get; set;}
    public int altura{get; set;}

    // public int DiametroConoInferior { get; } = 145;
    // public double DiametroCilindro { get; } = 6.24;
    // public double DiametroConoSuperior { get; } = 0.2;
    // public double AlturaConoInferior { get; } = 4.6;
    // public double AlturaCilindroCalculado { get; } = 5.13;
    // public double AlturaConoSuperior { get; } = 0.75;
    // public double VolumenConoInferior { get; } = 60.84;
    // public double VolumenCilindro { get; } = 156.87;
    // public double VolumenConoSuperior { get; } = 7.89;
    // public double VolumenTotal { get; } = 225.62;
    // public int PesoVolumetrico { get; } = 144;
    // public int ToneladaCemento { get; } = 325;
}
