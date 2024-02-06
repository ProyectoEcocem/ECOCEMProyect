
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
export default class Fabrica extends React.Component {
    state = {
      Fabricas: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Fabrica`)
        .then(res => {
          const Fabricas= res.data;
          this.setState({ Fabricas });
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
              this.state.Fabricas.map((b) => (
                <Tr key={b.FabricaId}>
                  <Td>{b.fabricaId}</Td>
                  <Td>{b.nombre}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Fabricas.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 