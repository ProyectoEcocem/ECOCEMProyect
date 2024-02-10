
import React from 'react';
import InsertarEquipo from './InsertarEquipo';
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
export default class Equipo extends React.Component {
    state = {
      Equipos: [],
      insertarEquipoModalAbierto: false, //controlar si la pestana de insertar equipo esta abierta
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Equipo`)
        .then(res => {
          const Equipos= res.data;
          this.setState({ Equipos });
        })
    }
  
    //Funcion para abrir el modal de Insertar Sede
    manejarInsertarEquipoModal = () => {
      this.setState({ insertarEquipoModalAbierto: true });
    };

    render() {
      return (
        <div style={{height : 400}}>

<Button
         onClick={this.manejarInsertarEquipoModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Equipo
         </Button>

         <Modal isOpen={this.state.insertarEquipoModalAbierto} onClose={() => this.setState({ insertarEquipoModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarEquipo onClose={() => this.setState({ insertarEquipoModalAbierto: false })} />
         </AbsoluteCenter>
         </Modal>

        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Th>ID</Th>
              <Th>Tipo de Equipo</Th>
              <Th>Sede</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Equipos.map((equipo) => (
                <Tr key={equipo.equipoId}>
                  <Td>{equipo.equipoId}</Td>
                  <Td>{equipo.tipoEId}</Td>
                  <Td>{equipo.sedeId}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Equipos.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 