import { useState } from "react";
import {
    Input,
    Button,
    Flex,
    TableContainer,
    Table,
    Tr,
    Th,
    Thead,
    Tbody,
    Td,
    TableCaption,
    FormLabel,
    Select,
    //BackgroundImage
  } from "@chakra-ui/react"; 

const InsertarParametrosTabla = () => {

    const [fecha, setFecha] = useState("");

    const [sede, setSede] = useState("");
  
    const [equipoId, setEquipoId] = useState("");
  
    const [tiempoRealParoFalla, setTiempoRealParoFalla] = useState(""); //Tiempo real de paro por falla, en horas.
  
    const [tiempoRealMant, setTiempoRealMant] = useState(""); //Tiempo de operación real en horas.
  
    const [tiempoOperacioReal, setTiempoOperacionReal] = useState(""); //Disponibilidad Real.
  
    const [tiempoParoTrabajosPlan, setTiempoParoTrabajosPlan] = useState(""); //Tiempo de paro por ejecución de trabjos planificados.
  
    const [tiempoParoMant, setTiempoParoMant] = useState(""); //Tiempo real de paro por mtto. Contempla intervenciones planificadas más imprevistas en horas tdm=Σtmp + Σtr. (tdm) 
  
    const [tiempoOperacionRequerido, setTiempoOperacionRequerido] = useState(""); //Tiempo de operación requerido según programa de producción en horas.
  
    const [tiempoRequeridoAccProgramadas, setTiempoRequeridoAccProgramadas] = useState(""); //Tiempo requerido para las intervenciones programadas  de mtto en horas.
  
    const [costoTotalMant, setCostoTotalMant] = useState(""); //Costo total de mantenimiento.
  
    const [facturacion, setFacturacion] = useState(""); //Facturación de la empresa en el periodo analizado.
  
    const [costoMantContratado, setCostoMantContratado] = useState(""); //Costo de los mttos contratados.
  //solo para testear, aquí irían las sedes en BD
  const sedes = [
    { id: 1, nombre: "Sede 1" },
    { id: 2, nombre: "Sede 2" },
    { id: 3, nombre: "Sede 3" },
  ]
  
  //solo para testear, aquí irían los equipos registrados en BD
  const equipos = [
    { id: 1},
    { id: 2},
    { id: 3},
  ]

  return (
    <div style={{width : 800 }}>
        <FormLabel style={{fontSize: 30}}>Insertar Parámetros</FormLabel>
    <Flex>
        <Input
          type="datetime-local"
          value={fecha}
          onChange={(e) => setFecha(e.target.value)}
          width={250}
          marginBottom={30}
         
        />

<Select
          value={sede}
          onChange={(e) => setSede(e.target.value)}
          width={150}
          marginBottom={30}
          marginLeft={10}
        >
          {sedes.map((sede) => (
            <option key={sede.id} value={sede.id}>
              {sede.nombre}
            </option>
          ))}
        </Select>

        <Select
          value={equipoId}
          onChange={(e) => setEquipoId(e.target.value)}
          width={150}
          marginBottom={30}
          marginLeft={10}
        >
          {equipos.map((equipo) => (
            <option key={equipo.id} value={equipo.id}>
              {equipo.id}
            </option>
          ))}
        </Select>

        </Flex>
    <TableContainer>
    <Table variant='simple'>
      <TableCaption>Parámetros</TableCaption>
      <Thead>
        <Tr>
          <Th>Parámetro</Th>
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
          <Td>Costo Mantenimiento Contratado</Td>
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

        <Flex>
        <Button variant="contained" color="primary" style={{ marginRight: 10, marginLeft: 340 }}>
          Aceptar
        </Button>
        </Flex>
        </div>
  );
};
export default InsertarParametrosTabla;
