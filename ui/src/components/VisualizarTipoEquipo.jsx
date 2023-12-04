
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
      tipoEquipos: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/TipoEquipo`)
        .then(res => {
          const tipoEquipos= res.data;
          this.setState({ tipoEquipos });
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
                <Th>Tipo de Equipo</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.tipoEquipos.map((tipoE) => (
                  <Tr key={tipoE.tipoEId}>
                    <Td>{tipoE.tipoEId}</Td>
                    <Td>{tipoE.tipoE}</Td>
                  </Tr>
                )
                )
              }
            </Tbody>
          </Table>
        </TableContainer>
       
       </div>
      )
    }
  } 
  //  <ul>
         // { this.state.tipoEquipos.map(tipoE => <li key={tipoE.tipoEId}>Tipo: {tipoE.tipoE} </li>)}
       //  </ul>
