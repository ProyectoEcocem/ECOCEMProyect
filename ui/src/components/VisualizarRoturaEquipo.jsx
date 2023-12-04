
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
export default class RoturaEquipo extends React.Component {
    state = {
      roturasE: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/RoturaEquipo`)
        .then(res => {
          const roturasE= res.data;
          this.setState({ roturasE });
        })
    }
  
    render() {
      return (
        <div>
        <TableContainer>
          <Table>
            <Thead>
              <Tr>
                <Th>ID de la Rotura</Th>
                <Th>ID del Equipo</Th>
                <Th>Fecha</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.roturasE.map((roturaE) => (
                  <Tr key={roturaE.roturaId}>
                    <Td>{roturaE.roturaId}</Td>
                    <Td>{roturaE.equipoId}</Td>
                    <Td>{roturaE.fechaId}</Td>
                  </Tr>
                ))
              }
            </Tbody>
          </Table>
        </TableContainer>
        </div>
        // <ul>
          // { this.state.roturasE.map(roturaE => <li key={roturaE.roturaId}> Id:{roturaE.roturaId} Equipo: {roturaE.equipoId} Fecha:  Equipo: {roturaE.fechaId} </li>)}
        // </ul>
      )
    }
  } 