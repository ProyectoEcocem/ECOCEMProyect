import { useState } from "react";
import {
    Input,
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

const Reporte = () => {

  const [fecha, setFecha] = useState("");

  const [sede, setSede] = useState("");

  const [equipoId, setEquipoId] = useState("");

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

  // ToDo: CAMBIAR
  const indicadores = [
    {I1: 1, I2: 2, I3: 3, I4: 4, I5:5, I6: 6, I7: 7}
  ]


  return (
    <div>
        <FormLabel style={{fontSize: 30}}>Reporte</FormLabel> 
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

        <Flex>
        {/*Tabla de Indicadores */} 
        <TableContainer>
    <Table variant='simple'>
      <TableCaption>Indicadores</TableCaption>
      <Thead>
        <Tr>
          <Th>Indicador</Th>
          <Th>Unidad de Medida</Th>
          <Th isNumeric>Valor</Th>
        </Tr>
      </Thead>
      <Tbody>
        <Tr>
          <Td>Índice de Paro por falla y mantenimiento</Td>
          <Td>%</Td>
          <Td isNumeric>{indicadores.I1}</Td>
        </Tr>
        <Tr>
          <Td>Disponibilidad Requerida</Td>
          <Td>%</Td>
          <Td isNumeric>
            {indicadores.I2}
          </Td>
        </Tr>
        <Tr>
          <Td>Disponibilidad Real</Td>
          <Td>%</Td>
          <Td isNumeric>
           {indicadores.I3}
          </Td>
        </Tr>
        <Tr>
          <Td>Índice de Roturas</Td>
          <Td>%</Td>
          <Td isNumeric>
           {indicadores.I4}
          </Td>
        </Tr>
        <Tr>
          <Td>Costo Total de Mantenimiento / Costo de Facturación</Td>
          <Td>%</Td>
          <Td isNumeric>
            {indicadores.I5}
          </Td>
        </Tr>
        <Tr>
          <Td>Costo del mtto contratado / costo total del mtto</Td>
          <Td>%</Td>
          <Td isNumeric>
           {indicadores.I6}
          </Td>
        </Tr>
        <Tr>
          <Td>Pérdida por la Indisponibilidad</Td>
          <Td>pesos</Td>
          <Td isNumeric>
           {indicadores.I7}
          </Td>
        </Tr>
      </Tbody>
    </Table>
  </TableContainer>

{/*Tabla para Parametros*/}
<TableContainer marginLeft={10}>
    <Table variant='simple'>
      <TableCaption>Parametros</TableCaption>
      <Thead>
        <Tr>
          <Th>Parametro</Th>
          <Th isNumeric>Valor</Th>
        </Tr>
      </Thead>
      <Tbody>
        <Tr>
          <Td>Tiempo real de paro por falla</Td>
          
          <Td isNumeric>
            1
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo real de mantenimiento</Td>
          
          <Td isNumeric>
            2
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo Operacion Real</Td>
          
          <Td isNumeric>
            3
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo de paro por trabajos planificados</Td>
          
          <Td isNumeric>
            4
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo real de paro por mantenimiento</Td>
          
          <Td isNumeric>
            5
          </Td>
        </Tr>
        <Tr>
          <Td>TiempoOperacionRequerido</Td>
          
          <Td isNumeric>
            6
          </Td>
        </Tr>
        <Tr>
          <Td>Tiempo Requerido Acciones Programadas</Td>
          
          <Td isNumeric>
            7
          </Td>
        </Tr>
        <Tr>
          <Td>Costo Total de Mantenimiento</Td>
          
          <Td isNumeric>
            8
          </Td>
        </Tr>
        <Tr>
          <Td>Facturación</Td>
          <Td isNumeric>
            9
          </Td>
        </Tr>
        <Tr>
          <Td>Costo Mantenimiento Contratado</Td>
          <Td isNumeric>
            10
          </Td>
        </Tr>
      </Tbody>
    </Table>
  </TableContainer>
  </Flex>
        </div>
  );
};

export default Reporte;