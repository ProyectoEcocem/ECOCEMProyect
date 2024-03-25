
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
import InsertarOrdenTrabajo from './Insertar OrdenTrabajo';
export default class VisualizarOrdenTrabajo extends React.Component {
    state = {
      ordenesTrabajo: [],
      insertarOrdenTrabajoModalAbierto: false,
    }
  
    componentDidMount() {
      this.cargarBD();
    }

    cargarBD() {
      axios.get(`http://localhost:5103/api/OrdenTrabajo`)
      .then(res => {
        const ordenesTrabajo= res.data;
        this.setState({ ordenesTrabajo });
      })
    }

    manejarInsertarOrdenesTrabajoModal = () => {
      this.setState({ insertarOrdenTrabajoModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "60%", transform: "translateX(-50%)" }}>

<Button
         onClick={this.manejarInsertarOrdenesTrabajoModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Orden de Trabajo
         </Button>

         <Modal isOpen={this.state.insertarOrdenTrabajoModalAbierto} onClose={() => this.setState({ insertarOrdenTrabajoModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarOrdenTrabajo onClose={() => {this.setState({ insertarOrdenTrabajoModalAbierto: false }); this.cargarBD();}} />
         </AbsoluteCenter>
         </Modal>

        <TableContainer>
          <Table>
            <Thead>
              <Tr> 
                <Th>ID del Equipo</Th>
                <Th>ID de la Brigada</Th>
                <Th>Id del Trabajador</Th>
                <Th>Fecha</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.ordenesTrabajo.map((ordenTrabajo) => (
                  <Tr key={ordenTrabajo.equipoId}>
                    <Td>{ordenTrabajo.equipoId}</Td>
                    <Td>{ordenTrabajo.brigadaId}</Td>
                    <Td>{ordenTrabajo.trabajadorId}</Td>
                    <Td>{ordenTrabajo.fechaId}</Td>
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