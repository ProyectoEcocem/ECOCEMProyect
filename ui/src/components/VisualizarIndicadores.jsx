
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
export default class Reporte extends React.Component {
    state = {
      Reportes: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Reporte`)
        .then(res => {
          const Reportes= res.data;
          this.setState({ Reportes });
        })
    }
  
    render() {
      return (
        <div style={{height : 400}}>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              
              <Th>Equipo_Id</Th>
              <Th>Fecha</Th>
              <Th>Indice Paro Fallas</Th>
              <Th>Disponibilidad Requerida</Th>
              <Th>Disponibilidad Real</Th>
              <Th>Indice Roturas</Th>
              <Th>CostoMNFacturacion</Th>
              <Th>CostoMantContratadoEntreCostoTotal</Th>
              
          
              
             
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Reportes.map((reporte) => (
                <Tr key={[reporte.equipoId,reporte.fechaId]}>
                  <Td>{reporte.equipoId}</Td>
                  <Td>{reporte.fechaId}</Td>
                  <Td>{reporte.indiceParoFallas}</Td>
                  <Td>{reporte.disponibilidadRequerida}</Td>
                  <Td>{reporte.disponibilidadReal}</Td>
                  <Td>{reporte.indiceRoturas}</Td>
                  <Td>{reporte.costoMNFacturacion}</Td>
                  <Td>{reporte.costoMantContratadoEntreCostoTotal}</Td>
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