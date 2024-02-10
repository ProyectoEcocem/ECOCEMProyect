
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
export default class TipoCemento extends React.Component {
    state = {
      TipoCementos: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/TipoCemento`)
        .then(res => {
          const TipoCementos= res.data;
          this.setState({ TipoCementos });
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
              <Th>Nombre del tipo de cemento</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.TipoCementos.map((b) => (
                <Tr key={b.TipoCementoId}>
                  <Td>{b.tipoCementoId}</Td>
                  <Td>{b.nombreTipoCemento}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.TipoCementos.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 