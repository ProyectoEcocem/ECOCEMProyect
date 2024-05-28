namespace ECOCEMProject;

public class MedicionSilo
{
    public int SiloId {get; set;}
    public int MedidorId { get; set; }
    public DateTime FechaMId {get; set;}

    public int Nivel {get; set; }
    public int PesoM {get; set; }
    public int Volumen {get; set; }


    //public int TipoCementoId { get; set; }
    //public int VehiculoId { get; set; }
    
    //public DateTime FechaCargaId {get; set;}

    public Carga? Carga {get; set; }
    public Descarga? Descarga {get; set; }
    //veamos.....
    // public double alturaCinta {get; set;}

    // public double radioMayorConoInf{get;set;}
    // public double radioMenorConoInferior{get;set;}
    // public double radioMenorConoSuperior{get;set;}
    // public double radioMayorConoSuperior{get;set;}
    // public double volumenConoInferiorPredeterminado=60.84;
    // public double volumenCilindroPredeterminado=156.87;
    // public double alturaConoInferior=4.6;
    // public double diametroCilindro=6.24;

    // //volumen calculado....
    // public double volumen {get{
    //     if(alturaCinta < 4.6){
    //         return (1/3)* Math.PI*(Math.Pow(radioMayorConoInf,2)+Math.Pow(radioMenorConoInferior,2)+radioMayorConoInf*radioMenorConoInferior)*alturaCinta;

    //     }
    //     else if(alturaCinta < 9.73){
    //         return (volumenConoInferiorPredeterminado+volumenCilindroPredeterminado)*(alturaConoInferior-alturaCinta);
    //     }
    //     else{//menor 10.7
    //     var VolConInferior=(Math.PI*(Math.Pow(radioMayorConoInf,2)+Math.Pow(radioMenorConoInferior,2)+radioMayorConoInf*radioMenorConoInferior)*alturaConoInferior)/3;
    //     var alturaCilindro=5.13;
    //     var VolCilindro=Math.PI*Math.Pow(diametroCilindro/2,2)*alturaCilindro;  
    //     var alturaConoSuperior=alturaCinta-9.77;
    //     var VolConoSuperior=(Math.PI*(Math.Pow(radioMayorConoSuperior,2)+Math.Pow(radioMenorConoSuperior,2)+radioMayorConoSuperior*radioMenorConoSuperior)*alturaConoSuperior)/3;
    //     return VolConInferior + VolCilindro + VolConoSuperior;

    //     }

    // }}

}
