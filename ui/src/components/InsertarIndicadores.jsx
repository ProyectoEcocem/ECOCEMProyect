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

const InsertarIndicadores = () => {

  const [fecha, setFecha] = useState("");

  const [sede, setSede] = useState("");

  const [equipoId, setEquipoId] = useState("");

  const [indiceParoFalla, setIndiceParoFalla] = useState(""); //Índice del % de paro por falla y Mantenimiento.

  const [disponibilidadRequerida, setDisponibilidadRequerida] = useState(""); //Disponibilidad Requerida.

  const [disponibilidadReal, setDisponibilidadReal] = useState(""); //Disponibilidad Real.

  const [indiceRotura, setIndiceRotura] = useState(""); //Índice de Roturas.

  const [costoTotalMantFact, setCostoTotalMantFact] = useState(""); //Costo total de mantenimiento /Costo total de facturación.

  const [costoMantContratadoTotal, setCostoMantContratadoTotal] = useState(""); //Costo de mantenimiento contratado /costo total de mnto

  const [perdidaIndisponibilidad, setPerdidaIndisponibilidad] = useState(""); //Pérdida por la indisponibilidad.

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
    <div>
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
          <Td isNumeric>
            <Input type="number"
            value={indiceParoFalla}
            onChange={(e) => setIndiceParoFalla(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Disponibilidad Requerida</Td>
          <Td>%</Td>
          <Td isNumeric>
            <Input type="number"
            value={disponibilidadRequerida}
            onChange={(e) => setDisponibilidadRequerida(e.target.value)}  
            width={150}          
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Disponibilidad Real</Td>
          <Td>%</Td>
          <Td isNumeric>
            <Input type="number"
            value={disponibilidadReal}
            onChange={(e) => setDisponibilidadReal(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Índice de Roturas</Td>
          <Td>%</Td>
          <Td isNumeric>
            <Input type="number"
            value={indiceRotura}
            onChange={(e) => setIndiceRotura(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Costo Total de Mantenimiento / Costo de Facturación</Td>
          <Td>%</Td>
          <Td isNumeric>
            <Input type="number"
            value={costoTotalMantFact}
            onChange={(e) => setCostoTotalMantFact(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Costo del mantenimiento contratado / costo total del mantenimiento</Td>
          <Td>%</Td>
          <Td isNumeric>
            <Input type="number"
            value={costoMantContratadoTotal}
            onChange={(e) => setCostoMantContratadoTotal(e.target.value)}
            width={150}
            />
          </Td>
        </Tr>
        <Tr>
          <Td>Pérdida por la Indisponibilidad</Td>
          <Td>pesos</Td>
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

        <Flex>
        <Button variant="contained" color="primary" style={{ marginRight: 10, marginLeft: 350 }}>
          Aceptar
        </Button>
        <Button variant="contained" color="secondary">
          Cancelar
        </Button>
        </Flex>
        </div>
  );
};

// ToDo: Enlazar de forma que se muestren enlas listas desplegables los datos de sede y tipo de equipo que haya en la BD

// ToDo: Evento de los botones

// ToDO: Verificar que el Id sea valido

export default InsertarIndicadores;