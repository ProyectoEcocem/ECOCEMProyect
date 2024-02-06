
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
export default class Venta extends React.Component {
    state = {
      Ventas: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Venta`)
        .then(res => {
          const Ventas= res.data;
          this.setState({ Ventas });
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
              <Th>Entidad Compradora Id</Th>
              <Th>Fecha</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Ventas.map((b) => (
                <Tr key={b.VentaId}>
                  <Td>{b.sedeId}</Td>
                  <Td>{b.entidadCompradoraId}</Td>
                  <Td>{b.fechaVentaId}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Ventas.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 