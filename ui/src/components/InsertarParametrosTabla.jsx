import { useState, useEffect } from "react";
import axios from "axios";
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
    
  //Parametros
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

    //Indicadores
    const [indiceParoFalla, setIndiceParoFalla] = useState(""); //Índice del % de paro por falla y Mantenimiento.

  const [disponibilidadRequerida, setDisponibilidadRequerida] = useState(""); //Disponibilidad Requerida.

  const [disponibilidadReal, setDisponibilidadReal] = useState(""); //Disponibilidad Real.

  const [indiceRotura, setIndiceRotura] = useState(""); //Índice de Roturas.

  const [costoTotalMantFact, setCostoTotalMantFact] = useState(""); //Costo total de mantenimiento /Costo total de facturación.

  const [costoMantContratadoTotal, setCostoMantContratadoTotal] = useState(""); //Costo de mantenimiento contratado /costo total de mnto

  const [perdidaIndisponibilidad, setPerdidaIndisponibilidad] = useState(""); //Pérdida por la indisponibilidad.
  //solo para testear, aquí irían las sedes en BD
  const [equipos, setEquipos] = useState([]);
  useEffect(() => {
    axios.get(`http://localhost:5103/api/Equipo`)
      .then(res => {
        setEquipos(res.data);
      })
      .catch(err => console.log(err));
  }, []);
  
    const createReporte = async () => {
      // const reporte = {
      //   fecha: fecha,
      //   equipoId : equipoId,
      //   tiempoRealParoFall: tiempoRealParoFalla,
      //   tiempoRealMant: tiempoRealMant,
      //   tiempoOperacioReal: tiempoOperacioReal,
      //   tiempoParoTrabajosPlan:tiempoParoTrabajosPlan,
      //   tiempoParoMant: tiempoParoMant,
      //   tiempoOperacionRequerido:tiempoOperacionRequerido,
      //   tiempoRequeridoAccProgramadas:tiempoRequeridoAccProgramadas,
      //   costoTotalMant:costoTotalMant,
      //   facturacion:facturacion,
      //   costoMantContratado:costoMantContratado
      // };
  
      
      axios.post(`http://localhost:5103/api/Reporte`, {
        fechaId: fechaId,
        equipoId: equipoId,
        indiceParoFalla: indiceParoFalla,
        disponibilidadRequerida: disponibilidadRequerida,
        disponibilidadReal: disponibilidadReal,
        indiceRotura: indiceRotura,
        costoTotalMantFact: costoTotalMantFact,
        costoMantContratadoTotal: costoMantContratadoTotal,
        perdidaIndisponibilidad: perdidaIndisponibilidad,
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
        alert("Se ha insertado correctamente");
      }, (error) => {
        console.log(error);
        alert("Ha fallado la inserción");
      });
  
      };
      // useEffect(() => {
      //   setInsertSuccess(false);
      // }, [numeroEmpresa, nombreEmpresa]);

  return (
    <div style={{width : 2000 }}>
        <FormLabel style={{fontSize: 30}}>Insertar Reporte</FormLabel>
    <Flex>
        <Input
          type="datetime-local"
          value={fecha}
          onChange={(e) => setFecha(e.target.value)}
          width={250}
          marginBottom={30}
         
        />

{/* <Select
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
          </Select> */}

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
 
 {/*Tabla de Parametros*/}
        <Flex>
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

{/*Tabla para indicadores*/}
  <TableContainer marginLeft={10}>
    <Table variant='simple'>
      <TableCaption>Indicadores</TableCaption>
      <Thead>
        <Tr>
          <Th>Indicador</Th>
          <Th>UM</Th>
          <Th isNumeric>Valor</Th>
        </Tr>
      </Thead>
      <Tbody>
        <Tr>
          <Td>Índice de Paro por falla y mtto</Td>
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
          <Td>Costo Total de Mtto / Costo de Facturación</Td>
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
          <Td>Costo del mtto contratado / costo total del mtto</Td>
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

  </Flex>

        <Flex>
        <Button variant="contained" color="primary" style={{ marginRight: 10, marginLeft: 340 }} onClick={createReporte}>
          Aceptar
        </Button>
        </Flex>
        </div>
  );
};
export default InsertarParametrosTabla;
