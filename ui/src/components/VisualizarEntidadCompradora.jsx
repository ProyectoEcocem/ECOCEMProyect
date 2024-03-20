
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
import InsertarEntidadCompradora  from './InsertarEntidadCompradora'

export default class EntidadCompradora extends React.Component {
    state = {
      EntidadCompradoras: [],
      insertarEntidadCompradoraModalAbierto: false,
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/EntidadCompradora`)
        .then(res => {
          const EntidadCompradoras= res.data;
          this.setState({ EntidadCompradoras });
        })
    }

    manejarInsertarEntidadCompradoraModal = () => {
      this.setState({ insertarEntidadCompradoraModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{height : 400}}>
          <AbsoluteCenter top={"80px"} left={"550px"}>
          <Button
         onClick={this.manejarInsertarEntidadCompradoraModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Entidad Compradora
         </Button>
         <Modal isOpen={this.state.insertarEntidadCompradoraModalAbierto} onClose={() => this.setState({ insertarEntidadCompradoraModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarEntidadCompradora onClose={() => this.setState({ insertarEntidadCompradoraModalAbierto: false })} />
         </AbsoluteCenter>
         </Modal>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Th>ID</Th>
              <Th>Nombre</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.EntidadCompradoras.map((b) => (
                <Tr key={b.EntidadCompradoraId}>
                  <Td>{b.entidadCompradoraId}</Td>
                  <Td>{b.nombreEntidadCompradora}</Td>
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
          // { this.state.EntidadCompradoras.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 