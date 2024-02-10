
import React from 'react';
import InsertarTipoDeEquipo from './InsertarTipoDeEquipo';
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

export default class TiposEquipo extends React.Component {
    state = {
      tipoEquipos: [],
      insertarTipoEquipoModalAbierto: false, //controlar si la pestana de insertar tipo de equipo esta abierta
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/TipoEquipo`)
        .then(res => {
          const tipoEquipos= res.data;
          this.setState({ tipoEquipos });
        })
    }

    //Funcion para abrir el modal de Insertar Tipo de Equipo
    manejarInsertarTipoEquipoModal = () => {
      this.setState({ insertarTipoEquipoModalAbierto: true });
    };
  
    render() {
      return (
       <div style={{height : 400}}>

        <Button
         onClick={this.manejarInsertarTipoEquipoModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Tipo de Equipo
         </Button>

         <Modal isOpen={this.state.insertarTipoEquipoModalAbierto} onClose={() => this.setState({ insertarTipoEquipoModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarTipoDeEquipo onClose={() => this.setState({ insertarTipoEquipoModalAbierto: false })} />
         </AbsoluteCenter>
         </Modal>

        <TableContainer>
          <Table>
            <Thead>
              <Tr>
                <Th>ID</Th>
                <Th>Tipo de Equipo</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.tipoEquipos.map((tipoE) => (
                  <Tr key={tipoE.tipoEId}>
                    <Td>{tipoE.tipoEId}</Td>
                    <Td>{tipoE.tipoE}</Td>
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
  //  <ul>
         // { this.state.tipoEquipos.map(tipoE => <li key={tipoE.tipoEId}>Tipo: {tipoE.tipoE} </li>)}
       //  </ul>
