
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
import InsertarHerramienta from './InsertarHerramienta';
export default class VisualizarHerramienta extends React.Component {
    state = {
      herramientas: [],
      insertarHerramientaModalAbierto: false, //controlar si la pestana de insertar sede esta abierta
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Herramienta`)
        .then(res => {
          const herramientas = res.data;
          this.setState({ herramientas });
        })
    }
  

    //Funcion para abrir el modal de Insertar Sede
    manejarInsertarHerramientaModal = () => {
      this.setState({ insertarHerramientaModalAbierto: true });
    };

    render() {
      return (
        <div style={{height : 400}}>
            <AbsoluteCenter top={"80px"} left={"600px"}>
        <Button
         onClick={this.manejarInsertarHerramientaModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Herramienta
         </Button>

         <Modal isOpen={this.state.insertarHerramientaModalAbierto} onClose={() => this.setState({ insertarHerramientaModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarHerramienta onClose={() => this.setState({ insertarHerramientaModalAbierto: false })} />
         </AbsoluteCenter>
         </Modal>

        <TableContainer>
          <Table>
            <Thead>
              <Tr>
              <Th>ID</Th>
              <Th>Nombre</Th>
              <Th>Descripción</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.herramientas.map((herramienta) => (
                  <Tr key={herramienta.herramienta.Id}>
                    <Td>{herramienta.herramientaId}</Td>
                    <Td>{herramienta.nombre}</Td>
                    <Td>{herramienta.descripcion}</Td>
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
         //  { this.state.sedes.map(sede => <li key={sede.sedeId}>Nombre: {sede.nombreSede} , Ubicación: {sede.ubicacionSede}</li>)}
        // </ul>
      )
    }
  } 
