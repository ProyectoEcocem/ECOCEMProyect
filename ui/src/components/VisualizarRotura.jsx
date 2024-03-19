
import React from 'react';
import InsertarRotura from './InsertarRotura';
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
export default class Rotura extends React.Component {
    state = {
      Roturas: [],
      insertarRoturaModalAbierto: false, //controlar si la pestana de insertar rotura esta abierta
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Rotura`)
        .then(res => {
          const Roturas= res.data;
          this.setState({ Roturas });
        })
    }

    manejarInsertarRoturaModal = () => {
      this.setState({ insertarRoturaModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{height : 400}}>
          <AbsoluteCenter top={"80px"} left={"600px"}>
          <Button
         onClick={this.manejarInsertarRoturaModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Rotura
         </Button>

         <Modal isOpen={this.state.insertarRoturaModalAbierto} onClose={() => this.setState({ insertarRoturaModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarRotura onClose={() => this.setState({ insertarRoturaModalAbierto: false })} />
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
                this.state.Roturas.map((rotura) => (
                  <Tr key={rotura.RoturaId}>
                    <Td>{rotura.RoturaId}</Td>
                    <Td>{rotura.nombreRotura}</Td>
                    <Td>{rotura.descripcion}</Td>
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
          // { this.state.Roturas.map(rotura => <li key={rotura.RoturaId}>Tipo: {rotura.nombreRotura} </li>)}
        // </ul>
      )
    }
  } 