
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
  Modal, 
  AbsoluteCenter,
  //BackgroundImage
} from "@chakra-ui/react";
import axios from 'axios';
import InsertarVehiculo from  './InsertarVehiculo'
export default class Vehiculo extends React.Component {
    state = {
      Vehiculos: [],
      insertarVehiculoModalAbierto: false,
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Vehiculo`)
        .then(res => {
          const Vehiculos= res.data;
          this.setState({ Vehiculos });
        })
    }

    manejarInsertarVehiculoModal = () => {
      this.setState({ insertarVehiculoModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{height : 400}}>
          <AbsoluteCenter top={"80px"} left={"550px"}>
          <Button
         onClick={this.manejarInsertarVehiculoModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Vehículo
         </Button>
         <Modal isOpen={this.state.insertarVehiculoModalAbierto} onClose={() => this.setState({ insertarVehiculoModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarVehiculo onClose={() => this.setState({ insertarVehiculoModalAbierto: false })} />
         </AbsoluteCenter>
         </Modal>
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
              this.state.Vehiculos.map((b) => (
                <Tr key={b.VehiculoId}>
                  <Td>{b.vehiculoId}</Td>
                  <Td>{b.noSerie}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </AbsoluteCenter>
      </div>
        // <ul>
          // { this.state.Vehiculos.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 