namespace ECOCEMProject;

public class MedicionSilo
{
    public int SiloId {get; set;}
    public int MedidorId { get; set; }
    public DateTime FechaMId {get; set;}

    // public int Nivel {get; set; }
    // public int PesoM {get; set; }
    // public int Volumen {get; set; }


    //public int TipoCementoId { get; set; }
    //public int VehiculoId { get; set; }
    
    //public DateTime FechaCargaId {get; set;}

    public Carga? Carga {get; set; }
    public Descarga? Descarga {get; set; }
    //veamos.....
    public double alturaCinta {get; set;}
    public double radioMayorConoInf{get;set;}
    public double radioMenorConoInferior{get;set;}
    
    public double volumenConoInferiorPredeterminado{get{return 60.84;}}
    public double volumenCilindroPredeterminado{get{return 156.87;}}
    public double alturaConoInferior{get{return 4.6;}}
    //volumen calculado....
    public double volumen {get{
        if(alturaCinta < 4.6){
            return (1/3)* Math.PI*(Math.Pow(radioMayorConoInf,2)+Math.Pow(radioMenorConoInferior,2)+radioMayorConoInf*radioMenorConoInferior)*alturaConoInferior;

        }
        else if(alturaCinta < 9.73){
            return (volumenConoInferiorPredeterminado+volumenCilindroPredeterminado)*(alturaConoInferior-alturaCinta);
        }
        else{//menor 10.7
        return volumenConoInferiorPredeterminado+volumenCilindroPredeterminado;

        }

    }}

}
