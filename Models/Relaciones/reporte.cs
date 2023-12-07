public class Reporte
{
    public int EquipoId {get; set;}
    public DateTime FechaId {get; set;}

//ToDo: Revisar cada uno de los indicadores y parametros sujetos a cambios.
// QUESTION: Hay intersección entre los parámetros e indicadores, ¿cómo se debe represent000000000000000000000000000000000000000ad.

    //Parámetros
    public double TiempoRealParoFalla {get; set;} //Tiempo real de paro por falla, en horas.
    public double TiempoRealMant {get; set;} //Tiempo real mtto, en horas-hombres.
    public double TiempoOPeracionReal {get; set;} //Tiempo de operación real en horas.
    public double TiempoParoTrabajosPlan {get; set;} //Tiempo de paro por ejecución de trabjos planificados.
    public double TiempoParoMant {get; set;} //Tiempo real de paro por mtto. Contempla intervenciones planificadas más imprevistas en horas tdm=Σtmp + Σtr. (tdm) 
    public double TiempoOperacionRequerido {get; set;} //Tiempo de operación requerido según programa de producción en horas.
    public double TiempoRequeridoAccProgramadas {get; set;} //Tiempo requerido para las intervenciones programadas  de mtto en horas.
    public double CostoTotalMant {get; set;} //Costo total de mantenimiento.
    public double Facturacion {get; set;} //Facturación de la empresa en el periodo analizado.
    public double CostoMantContratado {get; set;} //Costo de los mttos contratados.

}
