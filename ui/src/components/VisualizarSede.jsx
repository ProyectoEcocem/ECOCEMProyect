
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
  Center,
  AbsoluteCenter,
  //BackgroundImage
} from "@chakra-ui/react";
import axios from 'axios';
import InsertarSede from './InsertarSede';
export default class Sedes extends React.Component {
    state = {
      sedes: [],
      insertarSedeModalAbierto: false, //controlar si la pestana de insertar sede esta abierta
    }
  
    componentDidMount() {
      this.cargarBD();
    }
    cargarBD() {
      axios.get(`http://localhost:5103/api/Sede`)
        .then(res => {
          const sedes = res.data;
          this.setState({ sedes });
        })
      }
  
    //Funcion para abrir el modal de Insertar Sede
    manejarInsertarSedeModal = () => {
      this.setState({ insertarSedeModalAbierto: true });
      this.cargarBD();
    };

    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "45%", transform: "translateX(-50%)" }}>
        <Button
         onClick={this.manejarInsertarSedeModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Sede
         </Button>

         <Modal isOpen={this.state.insertarSedeModalAbierto} onClose={() => {this.setState({ insertarSedeModalAbierto: false }); this.cargarBD();}}>
         <AbsoluteCenter>
         <InsertarSede onClose={() => {this.setState({ insertarSedeModalAbierto: false }); this.cargarBD();}} />
         </AbsoluteCenter>
         </Modal>

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
