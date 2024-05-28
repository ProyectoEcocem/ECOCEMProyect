namespace ECOCEMProject;

public class MedicionSilo
{
    public int SiloId {get; set;}
    public int MedidorId { get; set; }
    public DateTime FechaMId {get; set;}

    public int Nivel {get; set; }
    public int PesoM {get; set; }
    // public int Volumen {get; set; }


    //public int TipoCementoId { get; set; }
    //public int VehiculoId { get; set; }
    
    //public DateTime FechaCargaId {get; set;}

    public Carga? Carga {get; set; }
    public Descarga? Descarga {get; set; }
    
    //veamos.....
    public double AlturaCinta {get; set;}
    public double RadioMayorConoInf {get;set;}
    public double RadioMenorConoInferior {get;set;}
    public double RadioMenorConoSuperior {get;set;}
    public double RadioMayorConoSuperior {get;set;}
    public double VolumenConoInferiorPredeterminado = 60.84;
    public double VolumenCilindroPredeterminado = 156.87;
    public double AlturaConoInferior = 4.6;
    public double DiametroCilindro = 6.24;

    //volumen calculado....
    public double Volumen {
        get{
            if(AlturaCinta < 4.6){
                return (1/3)* Math.PI*(Math.Pow(RadioMayorConoInf,2)+Math.Pow(RadioMenorConoInferior,2)+RadioMayorConoInf*RadioMenorConoInferior)*AlturaCinta;

            }
            else if(AlturaCinta < 9.73){
                return (VolumenConoInferiorPredeterminado+VolumenCilindroPredeterminado)*(AlturaConoInferior-AlturaCinta);
            }
            else{ //menor 10.7
                var VolConInferior=(Math.PI*(Math.Pow(RadioMayorConoInf,2)+Math.Pow(RadioMenorConoInferior,2)+RadioMayorConoInf*RadioMenorConoInferior)*AlturaConoInferior)/3;
                var alturaCilindro=5.13;
                var VolCilindro=Math.PI*Math.Pow(DiametroCilindro/2,2)*alturaCilindro;  
                var alturaConoSuperior=AlturaCinta-9.77;
                var VolConoSuperior=(Math.PI*(Math.Pow(RadioMayorConoSuperior,2)+Math.Pow(RadioMenorConoSuperior,2)+RadioMayorConoSuperior*RadioMenorConoSuperior)*alturaConoSuperior)/3;
                return VolConInferior + VolCilindro + VolConoSuperior;
            }

        }
    }

}
