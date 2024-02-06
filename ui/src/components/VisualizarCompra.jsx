
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
export default class Compra extends React.Component {
    state = {
      Compras: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Compra`)
        .then(res => {
          const Compras= res.data;
          this.setState({ Compras });
        })
    }
  
    render() {
      return (
        <div style={{height : 400}}>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
            <Th>Sede Id</Th>
            <Th>Fabrica Id</Th>
            <Th>Fecha</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Compras.map((b) => (
                <Tr key={b.CompraId}>
                  <Td>{b.sedeId}</Td>
                  <Td>{b.fabricaId}</Td>
                  <Td>{b.fechaId}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Compras.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 