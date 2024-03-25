
import React from 'react';
import InsertarBrigada from './InsertarBrigada';
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
export default class VisualizarBrigada extends React.Component {
    state = {
      Brigadas: [],
      insertarBrigadaModalAbierto: false, //controlar si la pestana de insertar brigada esta abierta
    }
  
    componentDidMount() {
      this.cargarBD();
    }

    cargarBD() {
      axios.get(`http://localhost:5103/api/Brigada`)
      .then(res => {
        const Brigadas = res.data;
        this.setState({ Brigadas });
      })
    }

    manejarInsertarBrigadaModal = () => {
      this.setState({ insertarBrigadaModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "45%", transform: "translateX(-50%)" }}>
          <Button
         onClick={this.manejarInsertarBrigadaModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Brigada
         </Button>

         <Modal isOpen={this.state.insertarBrigadaModalAbierto} onClose={() => this.setState({ insertarBrigadaModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarBrigada onClose={() => {this.setState({ insertarBrigadaModalAbierto: false }); this.cargarBD();} } />
         </AbsoluteCenter>
         </Modal>


        <TableContainer>
          <Table>
            <Thead>
              <Tr>
                <Th>ID</Th>
                <Th>Descripción</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.Brigadas.map((brigada) => (
                  <Tr key={brigada.brigadaId}>
                    <Td>{brigada.brigadaId}</Td>
                    <Td>{brigada.descripcion}</Td>
                  </Tr>
                )
                )
              }
            </Tbody>
          </Table>
        </TableContainer>
</div>

        // <ul>
          // { this.state.Roturas.map(rotura => <li key={rotura.RoturaId}>Tipo: {rotura.nombreRotura} </li>)}
        // </ul>
      )
    }
  } 