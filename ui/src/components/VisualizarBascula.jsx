
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
  AbsoluteCenter,
  Modal,
  //BackgroundImage
} from "@chakra-ui/react";
import axios from 'axios';
import InsertarBascula from './InsertarBascula';
export default class Bascula extends React.Component {
    state = {
      Basculas: [],
      insertarBasculaModalAbierto: false,
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Bascula`)
        .then(res => {
          const Basculas= res.data;
          this.setState({ Basculas });
        })
    }

    manejarInsertarBasculaModal = () => {
      this.setState({ insertarBasculaModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{height : 400}}>
          <AbsoluteCenter top={"80px"} left={"520px"}>
          <Button
         onClick={this.manejarInsertarBasculaModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Bascula
         </Button>

         <Modal isOpen={this.state.insertarBasculaModalAbierto} onClose={() => this.setState({ insertarBasculaModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarBascula onClose={() => this.setState({ insertarBasculaModalAbierto: false })} />
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
              this.state.Basculas.map((b) => (
                <Tr key={b.BasculaId}>
                  <Td>{b.basculaId}</Td>
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
          // { this.state.Basculas.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 