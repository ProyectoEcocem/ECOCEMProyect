
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
export default class Trabajador extends React.Component {
    state = {
      Trabajadors: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Trabajador`)
        .then(res => {
          const Trabajadors= res.data;
          this.setState({ Trabajadors });
        })
    }
  
    render() {
      return (
        <div style={{height : 400}}>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Th>ID</Th>
              <Th>Nombre</Th>
              <Th>ID de sede</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Trabajadors.map((b) => (
                <Tr key={b.TrabajadorId}>
                  <Td>{b.trabajadorId}</Td>
                  <Td>{b.nombreTrabajador}</Td>
                  <Td>{b.sedeId}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Trabajadors.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 