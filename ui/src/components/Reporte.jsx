// import { useState, useEffect } from "react";
// import axios from "axios";
// import {
//     Input,
//     Flex,
//     TableContainer,
//     Table,
//     Tr,
//     Th,
//     Thead,
//     Tbody,
//     Td,
//     TableCaption,
//     FormLabel,
//     Select,
//     //BackgroundImage
//   } from "@chakra-ui/react"; 

// const Reporte = () => {

//   const [fechaId, setFechaId] = useState("");

//   const [equipoId, setEquipoId] = useState("");

//   const [equipos, setEquipos] = useState([]);

//   const [reportes, setReportes] = useState([]);

  
//   useEffect(() => {
//     axios.get(`http://localhost:5103/api/Equipo`)
//       .then(res => {
//         setEquipos(res.data);
//       })
//       .catch(err => console.log(err));
//   }, []);

//   useEffect(() => {
//     axios.get(`http://localhost:5103/api/Reporte`)
//       .then(res => {
//         setReportes(res.data);
//       })
//       .catch(err => console.log(err));
//   }, []);
//   const filtradosReportes = reportes.filter(reporte=> reporte.equipoId===equipoId && reporte.fechaId===fechaId)


//   return (
//     <div>
//         <FormLabel style={{fontSize: 30}}>Reporte</FormLabel> 
//     <Flex>
//         <Input
//           type="datetime-local"
//           value={fechaId}
//           onChange={(e) => setFechaId(e.target.value)}
//           width={250}
//           marginBottom={30}
         
//         />

// <Select
//           value={equipoId}
//           onChange={(e) => setEquipoId(e.target.value)}
//           width={80}
//           marginBottom={30}
//           >
//           {equipos.map((equipo) => (
//           <option key={equipo.equipoId} value={equipo.equipoId}>
//             {equipo.equipoId}
//           </option>
//           ))}
//         </Select>

//         </Flex>

//         <Flex>
//         {/*Tabla de Indicadores */} 
//         <TableContainer>
//     <Table variant='simple'>
//       <TableCaption>Indicadores</TableCaption>
//       <Thead>
//         <Tr>
//           <Th>Indicador</Th>
//           <Th>Unidad de Medida</Th>
//           <Th isNumeric>Valor</Th>
//         </Tr>
//       </Thead>
//       <Tbody>
//           <Tr>
//           <Td>Índice de Paro por falla y mantenimiento</Td>
//           <Td>%</Td>
//           <Td isNumeric>{filtradosReportes.indiceParoFalla}</Td>
//         </Tr>
//         <Tr>
//           <Td>Disponibilidad Requerida</Td>
//           <Td>%</Td>
//           <Td isNumeric>
//             {filtradosReportes.disponibilidadRequerida}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Disponibilidad Real</Td>
//           <Td>%</Td>
//           <Td isNumeric>
//            {filtradosReportes.disponibilidadReal}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Índice de Roturas</Td>
//           <Td>%</Td>
//           <Td isNumeric>
//            {filtradosReportes.indiceRotura}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Costo Total de Mantenimiento / Costo de Facturación</Td>
//           <Td>%</Td>
//           <Td isNumeric>
//             {filtradosReportes.costoTotalMantFact}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Costo del mtto contratado / costo total del mtto</Td>
//           <Td>%</Td>
//           <Td isNumeric>
//            {filtradosReportes.costoMantContratadoTotal}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Pérdida por la Indisponibilidad</Td>
//           <Td>pesos</Td>
//           <Td isNumeric>
//            {filtradosReportes.perdidaIndisponibilidad}
//           </Td>
//         </Tr>
        
//       </Tbody>
//     </Table>
//   </TableContainer>

// {/*Tabla para Parametros*/}
// <TableContainer marginLeft={10} >
//     <Table variant='simple'>
//       <TableCaption>Parametros</TableCaption>
//       <Thead>
//         <Tr>
//           <Th>Parametro</Th>
//           <Th isNumeric>Valor</Th>
//         </Tr>
//       </Thead>
//       <Tbody>
//         <Tr>
//           <Td>Tiempo real de paro por falla</Td>
          
//           <Td isNumeric>
//             {filtradosReportes.tiempoRealParoFalla}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Tiempo real de mantenimiento</Td>
          
//           <Td isNumeric>
//             {filtradosReportes.tiempoRealMant}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Tiempo Operacion Real</Td>
          
//           <Td isNumeric>
//             {filtradosReportes.tiempoOperacioReal}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Tiempo de paro por trabajos planificados</Td>
          
//           <Td isNumeric>
//             {filtradosReportes.tiempoParoTrabajosPlan}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Tiempo real de paro por mantenimiento</Td>
          
//           <Td isNumeric>
//             {filtradosReportes.tiempoParoMant}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>TiempoOperacionRequerido</Td>
          
//           <Td isNumeric>
//             {filtradosReportes.tiempoOperacionRequerido}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Tiempo Requerido Acciones Programadas</Td>
          
//           <Td isNumeric>
//            {filtradosReportes.tiempoRequeridoAccProgramadas}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Costo Total de Mantenimiento</Td>
          
//           <Td isNumeric>
//             {filtradosReportes.costoTotalMant}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Facturación</Td>
//           <Td isNumeric>
//             {filtradosReportes.facturacion}
//           </Td>
//         </Tr>
//         <Tr>
//           <Td>Costo Mantenimiento Contratado</Td>
//           <Td isNumeric>
//             {filtradosReportes.costoMantContratado}
//           </Td>
//         </Tr>
//       </Tbody>
//     </Table>
//   </TableContainer>
//   </Flex>

//         </div>
        
//   );
// };

// export default Reporte;

import React from 'react';
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
import axios from 'axios';
export default class Reporte extends React.Component {
    state = {
      Reportes: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Reporte`)
        .then(res => {
          const Reportes= res.data;
          this.setState({ Reportes });
        })
    }
  
    render() {
      return (
        <div style={{height : 400}}>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              
              <Th>Equipo_Id</Th>
              <Th>Fecha</Th>
              <Th>trpf</Th>
              <Th>trm</Th>
              <Th>tor</Th>
              <Th>tptp</Th>
              <Th>ttpm</Th>
              <Th>tor</Th>
              <Th>trap</Th>
              <Th>ctm</Th>
              <Th>fact</Th>
              <Th>cmc</Th>
          
              
             
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Reportes.map((reporte) => (
                <Tr key={[reporte.equipoId,reporte.fechaId]}>
                  <Td>{reporte.equipoId}</Td>
                  <Td>{reporte.fechaId}</Td>
                  <Td>{reporte.tiempoRealParoFalla}</Td>
                  <Td>{reporte.tiempoRealMant}</Td>
                  <Td>{reporte.tiempoOPeracionReal}</Td>
                  <Td>{reporte.tiempoParoTrabajosPlan}</Td>
                  <Td>{reporte.tiempoParoMant}</Td>
                  <Td>{reporte.tiempoOperacionRequerido}</Td>
                  <Td>{reporte.tiempoRequeridoAccProgramadas}</Td>
                  <Td>{reporte.costoTotalMant}</Td>
                  <Td>{reporte.facturacion}</Td>
                  <Td>{reporte.costoMantContratado}</Td>
                  
                
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Equipos.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 