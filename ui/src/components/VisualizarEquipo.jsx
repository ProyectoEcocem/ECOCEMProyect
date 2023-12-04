
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
export default class Equipo extends React.Component {
    state = {
      Equipos: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Equipo`)
        .then(res => {
          const Equipos= res.data;
          this.setState({ Equipos });
        })
    }
  
    render() {
      return (
        
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Th>ID</Th>
              <Th>Tipo de Equipo</Th>
              <Th>Sede</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Equipos.map((equipo) => (
                <Tr key={equipo.equipoId}>
                  <Td>{equipo.equipoId}</Td>
                  <Td>{equipo.tipoEId}</Td>
                  <Td>{equipo.sedeId}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
        // <ul>
          // { this.state.Equipos.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 