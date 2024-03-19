import React, { useState, useEffect } from "react";
import {
    Button,
    Flex,
    Select,
    Input,
    TableContainer,
    Table,
    Tr,
    Th,
    Thead,
    Tbody,
    Td,
    TableCaption,
    FormLabel,
  
    //BackgroundImage
  } from "@chakra-ui/react"; 
import axios from "axios";

const InsertarReporte = () => {
  
  const [equipoId, setEquipoId] = useState(1);
  const [fechaId, setFecha] = useState(new Date());
  
  const [tiempoRealParoFalla, setTiempoRealParoFalla] = useState(1); //Tiempo real de paro por falla, en horas.

  const [tiempoRealMant, setTiempoRealMant] = useState(1); //Tiempo de operación real en horas.

  const [tiempoOperacionReal, setTiempoOperacionReal] = useState(1); //Disponibilidad Real.

  const [tiempoParoTrabajosPlan, setTiempoParoTrabajosPlan] = useState(1); //Tiempo de paro por ejecución de trabjos planificados.

  const [tiempoParoMant, setTiempoParoMant] = useState(1); //Tiempo real de paro por mtto. Contempla intervenciones planificadas más imprevistas en horas tdm=Σtmp + Σtr. (tdm) 

  const [tiempoOperacionRequerido, setTiempoOperacionRequerido] = useState(1); //Tiempo de operación requerido según programa de producción en horas.

  const [tiempoRequeridoAccProgramadas, setTiempoRequeridoAccProgramadas] = useState(1); //Tiempo requerido para las intervenciones programadas  de mtto en horas.

  const [costoTotalMant, setCostoTotalMant] = useState(1); //Costo total de mantenimiento.

  const [facturacion, setFacturacion] = useState(1); //Facturación de la empresa en el periodo analizado.

  const [costoMantContratado, setCostoMantContratado] = useState(1); //Costo de los mttos contratados.
  //temporal en verdad esto es un indicdor
  const [perdidaIndisponibilidad, setPerdidaIndisponibilidad]=useState(1);//PerdidaIndisponibilidad

  const [horasTotal, setHorasTotal] = useState([]); //horas total del equipo para mantenimiento

    //Lista de roturas
    const [roturas, setRoturas] = useState([]);
  
    const [equipos, setEquipos] = useState([]);
  
    const [equiposPorTE, setEquiposPorTE] = useState([]);
  
    useEffect(() => {
     axios.get(`http://localhost:5103/api/Equipo`)
       .then(res => {
         setEquipos(res.data);
       })
       .catch(err => console.log(err));
    }, []);



  const createRt = async () => {
    axios.post(`http://localhost:5103/api/Reporte`, {
      equipoId : equipoId,
      fechaId: fechaId,
      tiempoRealParoFalla: tiempoRealParoFalla,
      tiempoRealMant: tiempoRealMant,
      tiempoOperacionReal: tiempoOperacionReal,
      tiempoParoTrabajosPlan:tiempoParoTrabajosPlan,
      tiempoParoMant: tiempoParoMant,
      tiempoOperacionRequerido:tiempoOperacionRequerido,
      tiempoRequeridoAccProgramadas:tiempoRequeridoAccProgramadas,
      costoTotalMant:costoTotalMant,
      facturacion:facturacion,
      costoMantContratado:costoMantContratado,
      perdidaIndisponibilidad: perdidaIndisponibilidad
    })
    .then((response) => {
      console.log(response);
      alert("Se insertó correctamente")
    }, (error) => {
      console.log(error);
      alert("no se insertó correctamente")
    });

    try {
      const response = await axios.get('http://localhost:5103/api/FiltroMantenimiento/GetHoras',{
        params: {
            equipoId: equipoId,
          },
      });
      setHorasTotal(response.data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }

    try {
      const response = await axios.get('http://localhost:5103/api/FiltroMantenimiento/GetEquipos',{
        params: {
          TipoE: "compresor beltico",
          },
      });
      setEquiposPorTE(response.data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }

    if (equiposPorTE.includes(equipoId) != null)
    {
        // Aviso con una semana de antelacion 7 dias = 168h
        if( horasTotal % 8 <= 168) {
        alert("Verificar nivel de aceite/n Verificar test de lámparas indicadores de panel");
        }
        if( horasTotal % 50 <= 168) {
        alert("Purgar con densado del recipiente de aceite después de una parada de 4h minimo\nLimpiar filtro de aspiración");
        }
        if( horasTotal % 100 <= 168) {
        alert("Cambiar filtros de aspiración y aceite");
        }
        if( horasTotal % 200 <= 168) {
        alert("Cambiar aceite del cárter cuando sea necesario\nRevisar, limpiar y cambiar filtros de aspiración y aceite.\nCambiar aceite del cárter y filtro de aceite");
        }
        if( horasTotal % 1000 <= 168) {
        alert("Revisión válvulas de seguridad\nCambiar filtros de aspiración y aceite\nLimpiar radiadores\nLimpiar filtro de aspiración");
        }
        if( horasTotal % 6000 <= 168) {
        alert("Revisar y cambiar metales de las bielas\nChequear y/o corregir holgura de aros del pistón\nChequear y/o calibrar camisa del desplazamiento del cilindro.\nChequear y rectificar medidas de los muñones del cigüeñal\nChequeo y/o cambio del rodamiento del motor(serviciar motor)\nChequeo de los contadores eléctricos\nChequeo del funcionamiento correcto de las seguridades da cornictors\nChequeo y/o cambio de a instrumentacion\n(manómetros, termómetros, presostatos, etc\nLimpieza, revisión y barnizado del enrollado.\nCalibración de protecciones térmicas");
        }
        if( horasTotal % 8000 <= 168) {
        alert("Sustituir segmentos\nDesarme y revisión total del compresor");
        }
      }
    
 };



  return (
    
       <div style={{width : 2000 }}>
       
     
 <FormLabel style={{fontSize: 30}}>
   Insertar R
 </FormLabel>
 <Flex>

 <FormLabel style={{margin: "0px 260px 0px 0px"}}>EquipoId</FormLabel>
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
 </Flex>
        <Flex>
        <FormLabel style={{margin: "0px 180px 0px 0px"}}>Fecha del  Reporte</FormLabel>
        <Input
          type="datetime-local"
          value={fechaId.toISOString().substring(0,16)}
          onChange={(e) => setFecha(new Date(e.target.value))}
          width={80}
          marginBottom={30}
         
        />
        </Flex>
        <Flex>
    <TableContainer>
    <Table variant='simple'>
      <TableCaption>Parámetros</TableCaption>
      <Thead>
        <Tr>
          <Th>Parametros</Th>
          <Th isNumeric>Valor</Th>
        </Tr>
      </Thead>
      <Tbody>
        <Tr>
          <Td>Tiempo real de paro por falla</Td>
          
          <Td isNumeric>
            <Input type="number"
            value={tiempoRealParoFalla}
            onChange={(e) => setTiempoRealParoFalla(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo real de mantenimiento</Td>
          
          <Td isNumeric>
            <Input type="number"
            value={tiempoRealMant}
            onChange={(e) => setTiempoRealMant(e.target.value)}  
            width={150}          
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo Operacion Real</Td>
          
          <Td isNumeric>
            <Input type="number"
            value={tiempoOperacionReal}
            onChange={(e) => setTiempoOperacionReal(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo de paro por trabajos planificados</Td>
          
          <Td isNumeric>
            <Input type="number"
            value={tiempoParoTrabajosPlan}
            onChange={(e) => setTiempoParoTrabajosPlan(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo real de paro por mantenimiento</Td>
          
          <Td isNumeric>
            <Input type="number"
            value={tiempoParoMant}
            onChange={(e) => setTiempoParoMant(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>TiempoOperacionRequerido</Td>
          
          <Td isNumeric>
            <Input type="number"
            value={tiempoOperacionRequerido}
            onChange={(e) => setTiempoOperacionRequerido(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo Requerido Acciones Programadas</Td>
          
          <Td isNumeric>
            <Input type="number"
            value={tiempoRequeridoAccProgramadas}
            onChange={(e) => setTiempoRequeridoAccProgramadas(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Costo Total de Mantenimiento</Td>
          
          <Td isNumeric>
            <Input type="number"
            value={costoTotalMant}
            onChange={(e) => setCostoTotalMant(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Facturación</Td>
          <Td isNumeric>
            <Input type="number"
            value={facturacion}
            onChange={(e) => setFacturacion(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Costo Mtto Contratado</Td>
          <Td isNumeric>
            <Input type="number"
            value={costoMantContratado}
            onChange={(e) => setCostoMantContratado(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Perdida de la Indisponibilida</Td>
          <Td isNumeric>
            <Input type="number"
            value={perdidaIndisponibilidad}
            onChange={(e) => setPerdidaIndisponibilidad(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
      </Tbody>
    </Table>
  </TableContainer>
        </Flex>
        <Flex>
        <Button 
        variant="contained" 
        color="primary" 
        style={{ marginRight: 10 }}
        onClick={createRt}
        type="submit"
        >
          Aceptar
        </Button>
        </Flex>
      </div>
  );
};


export default InsertarReporte;
