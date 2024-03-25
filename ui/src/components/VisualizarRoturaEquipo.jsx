
import React from 'react';
import InsertarRoturaEquipo from './InsertarRoturaEquipo';
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
import InsertarOrdenTrabajoRE from  "./InsertarOrdenTrabajoRE"
export default class RoturaEquipo extends React.Component {
    state = {
      roturasE: [],
      insertarRoturaEModalAbierto: false,
      insertarOrdenTrabajoModalAbierto: false,
      selectedRoturaId: 1,
      selectedEquipoId: 1
    }
  
    componentDidMount() {
      this.cargarBD();
    }

    cargarBD() {
      axios.get(`http://localhost:5103/api/RoturaEquipo`)
      .then(res => {
        const roturasE= res.data;
        this.setState({ roturasE });
      })
    }

    manejarInsertarRoturaEModal = () => {
      this.setState({ insertarRoturaEModalAbierto: true });
    };

    manejarClickAOrdenTrabajo = (selectedEquipoId, selectedRoturaId) => {
      this.setState({ insertarOrdenTrabajoModalAbierto: true });
    }
  
    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "60%", transform: "translateX(-50%)" }}>

<Button
         onClick={this.manejarInsertarRoturaEModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Rotura de Equipo
         </Button>

         <Modal isOpen={this.state.insertarRoturaEModalAbierto} onClose={() => this.setState({ insertarRoturaEModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarRoturaEquipo onClose={() => {this.setState({ insertarRoturaEModalAbierto: false }); this.cargarBD();} }/>
         </AbsoluteCenter>
         </Modal>

         <AbsoluteCenter>
         <Modal isOpen={this.state.insertarOrdenTrabajoModalAbierto} onClose={() => this.setState({ insertarOrdenTrabajoModalAbierto: false })}>
         
         <InsertarOrdenTrabajoRE equipoId={this.state.selectedEquipoId} roturaId={this.state.selectedRoturaId} onClose={() => this.setState({ insertarOrdenTrabajoModalAbierto: false })} />
         
         
         </Modal>
         </AbsoluteCenter>

        <TableContainer>
          <Table>
            <Thead>
              <Tr>
                <Th>ID de la Rotura</Th>
                <Th>ID del Equipo</Th>
                <Th>Fecha</Th>
                <Th>Orden de Trabajo</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.roturasE.map((roturaE) => (
                  <Tr key={roturaE.roturaId}>
                    <Td>{roturaE.roturaId}</Td>
                    <Td>{roturaE.equipoId}</Td>
                    <Td>{roturaE.fechaId}</Td>
                    <Td>
                    <Button onClick={() => {this.manejarClickAOrdenTrabajo(roturaE.roturaId, roturaE.equipoId); this.setState({selectedEquipoId: roturaE.equipoId}); this.setState({selectedRoturaId: roturaE.roturaId})}}>+ Orden de Trabajo</Button>
                    
                  </Td>
                  
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