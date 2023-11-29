import { useState } from "react";
import {
    Input,
    Button,
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

const InsertarParametros = () => {

  const [fecha, setFecha] = useState("");

  const [sede, setSede] = useState("");

 // const [equipoId, setEquipoId] = useState("");

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

  // ToDo: Necesariamente debo poner reporte acá
  const equipos = [
    {id: 1, tipoEquipo: "Tipo1"},
     {id: 2, tipoEquipo: "Tipo2"},
     {id: 3, tipoEquipo: "Tipo3"},
  ]

  return (
    <div style={{ borderRadius: 20,
        border: "2px solid #5F89C1", width: 1200, height: "400px",
        backgroundColor: "white",}}>
        <FormLabel style={{fontSize: 30, marginTop:"20px", marginLeft:"450px"}}>Insertar Parámetros</FormLabel>
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
                {equipos.map((equipo) => (
                    <Tr key={equipo.id}>
                        <Td>{equipo.id}</Td>
                        <Td>{equipo.tipoEquipo}</Td>
                        <Td>
                        <Input type="number"
                        value={tiempoRealParoFalla}
                        onChange={(e) => setTiempoRealParoFalla(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <Td>
                        <Input type="number"
                        value={tiempoRealMant}
                        onChange={(e) => setTiempoRealMant(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <Td>
                        <Input type="number"
                        value={tiempoOperacioReal}
                        onChange={(e) => setTiempoOperacionReal(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <Td>
                        <Input type="number"
                        value={tiempoParoTrabajosPlan}
                        onChange={(e) => setTiempoParoTrabajosPlan(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <Td>
                        <Input type="number"
                        value={tiempoParoMant}
                        onChange={(e) => setTiempoParoMant(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <Td>
                        <Input type="number"
                        value={tiempoOperacionRequerido}
                        onChange={(e) => setTiempoOperacionRequerido(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <Td>
                        <Input type="number"
                        value={tiempoRequeridoAccProgramadas}
                        onChange={(e) => setTiempoRequeridoAccProgramadas(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <Td>
                        <Input type="number"
                        value={costoTotalMant}
                        onChange={(e) => setCostoTotalMant(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <Td>
                        <Input type="number"
                        value={facturacion}
                        onChange={(e) => setFacturacion(e.target.value)}
                        width={100}
                        />
                        </Td>
                        <td>
                        <Input type="number"
                        value={costoMantContratado}
                        onChange={(e) => setCostoMantContratado(e.target.value)}
                        width={100}
                        />
                        </td>
                    </Tr>
                ))}
            </Tbody>
        </Table>
    </TableContainer>

        <Flex>
        <Button variant="contained" color="primary" style={{ marginRight: 10, marginLeft: 450 }}>
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

export default InsertarParametros;