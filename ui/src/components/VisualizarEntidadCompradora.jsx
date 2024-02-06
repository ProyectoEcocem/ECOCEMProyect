
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
export default class EntidadCompradora extends React.Component {
    state = {
      EntidadCompradoras: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/EntidadCompradora`)
        .then(res => {
          const EntidadCompradoras= res.data;
          this.setState({ EntidadCompradoras });
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
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.EntidadCompradoras.map((b) => (
                <Tr key={b.EntidadCompradoraId}>
                  <Td>{b.entidadCompradoraId}</Td>
                  <Td>{b.nombreEntidadCompradora}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.EntidadCompradoras.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 