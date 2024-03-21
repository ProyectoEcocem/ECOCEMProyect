
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
import InsertarSilo from  './InsertarSilo'
export default class Silo extends React.Component {
    state = {
      silos: [],
      insertarSiloModalAbierto: false,
    }
  
    componentDidMount() {
      this.cargarBD();
    }

    cargarBD() {
      axios.get(`http://localhost:5103/api/Silo`)
      .then(res => {
        const silos= res.data;
        this.setState({ silos });
      })
    }

    manejarInsertarSiloModal = () => {
      this.setState({ insertarSiloModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "50%", transform: "translateX(-50%)" }}>
          <Button
         onClick={this.manejarInsertarSiloModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Silo
         </Button>
         <Modal isOpen={this.state.insertarSiloModalAbierto} onClose={() => this.setState({ insertarSiloModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarSilo onClose={() => {this.setState({ insertarSiloModalAbierto: false }); this.cargarBD();}} />
         </AbsoluteCenter>
         </Modal>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Th>ID</Th>
              <Th>No. de serie</Th>
              <Th>Sede</Th>
              <Th>Radio</Th>
              <Th>Altura</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.silos.map((silo) => (
                <Tr key={silo.siloId}>
                  <Td>{silo.siloId}</Td>
                  <Td>{silo.noSilo}</Td>
                  <Td>{silo.noSede}</Td>
                  <Td>{silo.radio}</Td>
                  <Td>{silo.altura}</Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Medidors.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 