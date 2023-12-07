
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