public class Reporte
{
    public int EquipoId {get; set;}
    public DateTime FechaId {get; set;}

//ToDo: Revisar cada uno de los indicadores y parametros sujetos a cambios.
// QUESTION: Hay intersección entre los parámetros e indicadores, ¿cómo se debe represent000000000000000000000000000000000000000ad.

    //Parámetros
    public double TiempoRealParoFalla {get; set;} //tr Tiempo real de paro por falla, en horas.
    public double TiempoRealMant {get; set;} //tm Tiempo real mtto, en horas-hombres.
    public double TiempoOPeracionReal {get; set;} //top Tiempo de operación real en horas.
    public double TiempoParoTrabajosPlan {get; set;} //Tiempo de paro por ejecución de trabjos planificados.
    public double TiempoParoMant {get; set;} //tdm Tiempo real de paro por mtto. Contempla intervenciones planificadas más imprevistas en horas tdm=Σtmp + Σtr. (tdm) 
    public double TiempoOperacionRequerido {get; set;} //topr Tiempo de operación requerido según programa de producción en horas.
    public double TiempoRequeridoAccProgramadas {get; set;} //tdmr Tiempo requerido para las intervenciones programadas  de mtto en horas.
    public double CostoTotalMant {get; set;} //Costo total de mantenimiento.
    public double Facturacion {get; set;} //FTEP Facturación de la empresa en el periodo analizado.
    public double CostoMantContratado {get; set;} //Costo de los mttos contratados.
    //Indicadores
    // Im Indice de  paro por falla y  mantenimiento=>Im = (tr / tm) 100.
    public double IndiceParoFallas {get{ return TiempoRealParoFalla *100/ TiempoRealMant;} }
    //Disponibilidad requerida. Dr = topr *100/(topr + tdmr)        
   public double DisponibilidadRequerida{get{return TiempoOperacionRequerido*100/(TiempoOperacionRequerido + TiempoRequeridoAccProgramadas);}}
   //Disponibilidad real D = top *100/(top + tdm)
   public double DisponibilidadReal{get{return TiempoOPeracionReal*100/(TiempoOPeracionReal + TiempoParoMant);}} 
   // Indice de roturas Ir = tr *100/(tr + top)    
   public double IndiceRoturas{get{return TiempoRealParoFalla*100/(TiempoRealParoFalla + TiempoOPeracionReal);}} 
   //5. Costo total de mantenimiento / costo total de facturación CMFT=CTMN/FTEP*100 
    public double CostoMNFacturacion{get{return CostoTotalMant*100/Facturacion;}}
    //Costo de mantenimiento contratado / costo total de mantenimiento.
    public double CostoMantContratadoEntreCostoTotal{ get{ return CostoMantContratado*100/CostoTotalMant ;} }
    //7. Pérdida de la indisponibilidad.
     public double PerdidaIndisponibilidad{get;set; }

}
