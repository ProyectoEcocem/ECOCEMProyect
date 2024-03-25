
import React from 'react';
import InsertarAccionMantenimiento from './InsertarAccionMantenimiento';
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
export default class VisualizarAccionMantenimiento extends React.Component {
    state = {
      accionesMantenimiento: [],
      insertarAccionMantenimientoEModalAbierto: false,
    }
  
    componentDidMount() {
      this.cargarBD();
    }

    cargarBD(){
      axios.get(`http://localhost:5103/api/AccionMantenimiento`)
      .then(res => {
        const accionesMantenimiento= res.data;
        this.setState({ accionesMantenimiento });
      })
  }
    

    manejarInsertarAccionMantenimientoModal = () => {
      this.setState({ insertarAccionMantenimientoEModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "55%", transform: "translateX(-50%)" }}>
<Button
         onClick={this. manejarInsertarAccionMantenimientoModal}
         marginBottom={10}
         marginLeft={10}
         >
          Agregar Accion de Mantenimiento
         </Button>

         <Modal isOpen={this.state.insertarAccionMantenimientoEModalAbierto} onClose={() => this.setState({ insertarAccionMantenimientoEModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarAccionMantenimiento onClose={() => {this.setState({ insertarAccionMantenimientoEModalAbierto: false }); cargarBD();} } />
         </AbsoluteCenter>
         </Modal>

        <TableContainer>
          <Table>
            <Thead>
              <Tr>
                <Th>ID de la Brigada</Th>
                <Th>ID del Equipo</Th>
                <Th>ID del Trabajador</Th>
                <Th>Fecha</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.accionesMantenimiento.map((accionMantenimiento) => (
                  <Tr key={accionMantenimiento.brigadaId}>
                    <Td>{accionMantenimiento.brigadaId}</Td>
                    <Td>{accionMantenimiento.equipoId}</Td>
                    <Td>{accionMantenimiento.trabajadorId}</Td>
                    <Td>{accionMantenimiento.fechaId}</Td>
                  </Tr>
                ))
              }
            </Tbody>
          </Table>
        </TableContainer>
        </div>
        // <ul>
          // { this.state.roturasE.map(roturaE => <li key={roturaE.roturaId}> Id:{roturaE.roturaId} Equipo: {roturaE.equipoId} Fecha:  Equipo: {roturaE.fechaId} </li>)}
        // </ul>
      )
    }
  } 