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

  const [tiempoOperacioReal, setTiempoOperacionReal] = useState(1); //Disponibilidad Real.

  const [tiempoParoTrabajosPlan, setTiempoParoTrabajosPlan] = useState(1); //Tiempo de paro por ejecución de trabjos planificados.

  const [tiempoParoMant, setTiempoParoMant] = useState(1); //Tiempo real de paro por mtto. Contempla intervenciones planificadas más imprevistas en horas tdm=Σtmp + Σtr. (tdm) 

  const [tiempoOperacionRequerido, setTiempoOperacionRequerido] = useState(1); //Tiempo de operación requerido según programa de producción en horas.

  const [tiempoRequeridoAccProgramadas, setTiempoRequeridoAccProgramadas] = useState(1); //Tiempo requerido para las intervenciones programadas  de mtto en horas.

  const [costoTotalMant, setCostoTotalMant] = useState(1); //Costo total de mantenimiento.

  const [facturacion, setFacturacion] = useState(1); //Facturación de la empresa en el periodo analizado.

  const [costoMantContratado, setCostoMantContratado] = useState(1); //Costo de los mttos contratados.

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

  const createRt = async () => {
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
      alert("Se insertó correctamente")
    }, (error) => {
      console.log(error);
      alert("no insertó correctamente")
    });
 };



  return (
    
       <div style={{width : 2000 }}>
       
     
 <FormLabel style={{fontSize: 30}}>
   Insertar Rotura de Equipo
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
            value={tiempoOperacioReal}
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