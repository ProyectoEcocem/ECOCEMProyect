import { useState } from "react";
import {
    Input,
    Flex,
    FormLabel,
    Select,
    Table,
    TableContainer,
    Thead,
    Tbody,
    Tr,
    Th,
    Td,
    //BackgroundImage
  } from "@chakra-ui/react"; 

const VisualizarParametros = () => {

  const [fecha, setFecha] = useState("");

  const [sede, setSede] = useState("");

  //solo para testear, aquí irían las sedes en BD
  const sedes = [
    { id: 1, nombre: "Sede 1" },
    { id: 2, nombre: "Sede 2" },
    { id: 3, nombre: "Sede 3" },
  ]

  const reportes = [
    {id: 1, tipoE: 1, P1: 11, P2: 12, P3: 13, P4: 14, P5:15, P6:16, P7:17, P8:18, P9:19, P10:110 },
    {id: 2, tipoE: 2, P1: 21, P2: 22, P3: 23, P4: 24, P5:25, P6:26, P7:27, P8:28, P9:29, P10:210 }
  ]

  return (
    <div style={{ borderRadius: 20,
        border: "2px solid #5F89C1", width: 1200, height: "400px",
        backgroundColor: "white",}}>
        <FormLabel style={{fontSize: 30, marginTop:"20px", marginLeft:"450px"}}>Visualizar Parámetros</FormLabel>
    <Flex>
        <Input
          type="date"
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
        </Flex>

        <TableContainer display="flex">
        <Table size="sm">
            <Thead>
                <Tr>
                    <Th> No. Equipo</Th>
                    <Th>Tipo de Equipo</Th>
                    <Th>Tiempo real de paro por falla</Th>
                    <Th> Tiempo de operación real</Th>
                    <Th>Disponibilidad Real</Th>
                    <Th flexGrow={1}>Tiempo de paro por ejecución de trabajos planificados</Th>
                    <Th>Tiempo real de paro por mantenimiento</Th>
                    <Th>Tiempo de operación requerido</Th>
                    <Th>Tiempo Requerido para Intervenciones Programadas de Mantenimiento</Th>
                    <Th>Costo Total de Mantenimiento</Th>
                    <Th>Facturación de la empresa en el período analizado</Th>
                    <Th>Costo de los mantenimientos contratados</Th>
                </Tr>
            </Thead>
            <Tbody>
                {reportes.map((reporte) => (
                    <Tr key={reporte.id}>
                        <Td>{reporte.id}</Td>
                        <Td>{reporte.tipoEquipo}</Td>
                        <Td>{reporte.P1}</Td>
                        <Td>{reporte.P2}</Td>
                        <Td>{reporte.P3}</Td>
                        <Td>{reporte.P4}</Td>
                        <Td>{reporte.P5}</Td>
                        <Td>{reporte.P6}</Td>
                        <Td>{reporte.P7}</Td>
                        <Td>{reporte.P8}</Td>
                        <Td>{reporte.P9}</Td>
                        <Td>{reporte.P10}</Td>
                    </Tr>
                ))}
            </Tbody>
        </Table>
    </TableContainer>
        </div>
  );
};

export default VisualizarParametros;