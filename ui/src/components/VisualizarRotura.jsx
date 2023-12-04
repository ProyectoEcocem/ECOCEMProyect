
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
export default class TiposEquipo extends React.Component {
    state = {
      Roturas: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Rotura`)
        .then(res => {
          const Roturas= res.data;
          this.setState({ Roturas });
        })
    }
  
    render() {
      return (
        
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
                this.state.Roturas.map((rotura) => (
                  <Tr key={rotura.RoturaId}>
                    <Td>{rotura.RoturaId}</Td>
                    <Td>{rotura.nombreRotura}</Td>
                  </Tr>
                )
                )
              }
            </Tbody>
          </Table>
        </TableContainer>


        // <ul>
          // { this.state.Roturas.map(rotura => <li key={rotura.RoturaId}>Tipo: {rotura.nombreRotura} </li>)}
        // </ul>
      )
    }
  } 