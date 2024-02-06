
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
export default class Bascula extends React.Component {
    state = {
      Basculas: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Bascula`)
        .then(res => {
          const Basculas= res.data;
          this.setState({ Basculas });
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
              <Th>No de serie</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Basculas.map((b) => (
                <Tr key={b.BasculaId}>
                  <Td>{b.basculaId}</Td>
                  <Td>{b.noSerie}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Basculas.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 