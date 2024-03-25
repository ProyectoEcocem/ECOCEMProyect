import React, { useState, useEffect } from "react";
import {
    FormLabel,
    Button,
    Flex,
    Select,
    Input,
    //BackgroundImage
  } from "@chakra-ui/react"; 
import axios from "axios";

const InsertarReporte = () => {
  
  const [equipoId, setEquipoId] = useState("");

  const [tiempoRealParoFalla, setTiempoRealParoFalla] = useState(1); //Tiempo real de paro por falla, en horas.

  const [tiempoRealMant, setTiempoRealMant] = useState(1); //Tiempo de operación real en horas.

  const [tiempoOperacioReal, setTiempoOperacionReal] = useState(1); //Disponibilidad Real.

  const [tiempoParoTrabajosPlan, setTiempoParoTrabajosPlan] = useState(1); //Tiempo de paro por ejecución de trabjos planificados.

  const [tiempoParoMant, setTiempoParoMant] = useState(1); //Tiempo real de paro por mtto. Contempla intervenciones planificadas más imprevistas en horas tdm=Σtmp + Σtr. (tdm) 

  const [tiempoOperacionRequerido, setTiempoOperacionRequerido] = useState(1); //Tiempo de operación requerido según programa de producción en horas.

  const [tiempoRequeridoAccProgramadas, setTiempoRequeridoAccProgramadas] = useState(1); //Tiempo requerido para las intervenciones programadas  de mtto en horas.

  const [costoTotalMant, setCostoTotalMant] = useState(1); //Costo total de mantenimiento.

  const [facturacion, setFacturacion] = useState(1); //Facturación de la empresa en el periodo analizado.

  const [costoMantContratado, setCostoMantContratado] = useState(1); //Costo de los mttos contratados.

  const [horasTotal, setHorasTotal] = useState(1); //horas total del equipo para mantenimiento

    //Lista de roturas
    const [roturas, setRoturas] = useState([]);
  
    const [equipos, setEquipos] = useState([]);
  
    useEffect(() => {
     axios.get(`http://localhost:5103/api/Equipo`)
       .then(res => {
         setEquipos(res.data);
       })
       .catch(err => console.log(err));
    }, []);

    useEffect(() => {
      try {
        const response = axios.get('http://localhost:5103/api/FiltroMantenimiento/GetHoras',{
          params: {
              equipoId: equipoId,
            },
        });
        setReportes(response.data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
     }, double);


     try {
      const response = axios.get('http://localhost:5103/api/FiltroMantenimiento/GetHoras',{
        params: {
            equipoId: equipoId,
          },
      });
      setReportes(response.data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }

  const createRt = async () => {
    alert("aqui")
    axios.post(`http://localhost:5103/api/Reporte`, {
      equipoId : equipoId,
      fechaId: fechaId,
      tiempoRealParoFall: tiempoRealParoFalla,
      tiempoRealMant: tiempoRealMant,
      tiempoOperacioReal: tiempoOperacioReal,
      tiempoParoTrabajosPlan:tiempoParoTrabajosPlan,
      tiempoParoMant: tiempoParoMant,
      tiempoOperacionRequerido:tiempoOperacionRequerido,
      tiempoRequeridoAccProgramadas:tiempoRequeridoAccProgramadas,
      costoTotalMant:costoTotalMant,
      facturacion:facturacion,
      costoMantContratado:costoMantContratado
    })
    .then((response) => {
      console.log(response);
      alert("ok")
    }, (error) => {
      console.log(error);
      alert("no ok")
    });

    try {
      const postResponse = await axios.post(`http://localhost:5103/api/Reporte`, {
        equipoId : equipoId,
        fechaId: fechaId,
        tiempoRealParoFall: tiempoRealParoFalla,
        tiempoRealMant: tiempoRealMant,
        tiempoOperacioReal: tiempoOperacioReal,
        tiempoParoTrabajosPlan:tiempoParoTrabajosPlan,
        tiempoParoMant: tiempoParoMant,
        tiempoOperacionRequerido:tiempoOperacionRequerido,
        tiempoRequeridoAccProgramadas:tiempoRequeridoAccProgramadas,
        costoTotalMant:costoTotalMant,
        facturacion:facturacion,
        costoMantContratado:costoMantContratado
      });
      alert("ok");
  } catch (error) {
      console.error("Error en la solicitud POST:", error);
      alert("no ok");
  }

    alert("voy a ver lo de las horas")
    try {
      const response = await axios.get('http://localhost:5103/api/FiltroMantenimiento/GetHoras',{
        params: {
            equipoId: equipoId,
          },
      });
      setReportes(response.data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
    //despues de insertar verif el top
    if( horasTotal > 10)
    {
      alert("Mantenimiento")
    }
 };



      return (
        <div style={{
          width: "400px",
          height: "430px",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          backgroundColor: "white",
          flexDirection: "column",
          borderRadius: 20,
          border: "2px solid #5F89C1",
        }}>
     
        <FormLabel style={{fontSize: 30}}>
          Insertar Rotura de Equipo
        </FormLabel>

        <FormLabel style={{margin: "0px 260px 0px 0px"}}>Equipo</FormLabel>

        <Select
        value={equipoId}
        onChange={(e) => setEquipoId(e.target.value)}
        width={80}
        marginBottom={30}
        >
        {equipos.map((equipo) => (
        <option key={equipo.equipoId} value={equipo.equipoId}>
          {equipo.equipoId}
        </option>
        ))}
        </Select>
          
           
        <FormLabel style={{margin: "0px 180px 0px 0px"}}>Fecha del  Reporte</FormLabel>

        <Input
          type="datetime-local"
          value={fecha}
          onChange={(e) => setFecha(e.target.value)}
          width={80}
          marginBottom={30}
         
        />

        <Button 
        variant="contained" 
        color="primary" 
        style={{ marginRight: 10 }}
        onClick={createRt}
        type="submit"
        >
          Aceptar
        </Button>
      </div>
  );
};


export default InsertarReporte;