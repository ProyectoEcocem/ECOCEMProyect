
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
export default class Sedes extends React.Component {
    state = {
      sedes: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Sede`)
        .then(res => {
          const sedes = res.data;
          this.setState({ sedes });
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
              <Th>Ubicación</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.sedes.map((sede) => (
                  <Tr key={sede.sedeId}>
                    <Td>{sede.sedeId}</Td>
                    <Td>{sede.nombreSede}</Td>
                    <Td>{sede.ubicacionSede}</Td>
                  </Tr>
                )
                )
              }
            </Tbody>
          </Table>
        </TableContainer>
        </div>

        // <ul>
         //  { this.state.sedes.map(sede => <li key={sede.sedeId}>Nombre: {sede.nombreSede} , Ubicación: {sede.ubicacionSede}</li>)}
        // </ul>
      )
    }
  } 
