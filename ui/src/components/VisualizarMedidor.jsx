
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
import InsertarMedidor from  './InsertarMedidor'
export default class Medidor extends React.Component {
    state = {
      Medidors: [],
      insertarMedidorModalAbierto: false,
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Medidor`)
        .then(res => {
          const Medidors= res.data;
          this.setState({ Medidors });
        })
    }

    manejarInsertarMedidorModal = () => {
      this.setState({ insertarMedidorModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{height : 400}}>
          <AbsoluteCenter top={"80px"} left={"550px"}>
          <Button
         onClick={this.manejarInsertarMedidorModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Medidor
         </Button>
         <Modal isOpen={this.state.insertarMedidorModalAbierto} onClose={() => this.setState({ insertarMedidorModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarMedidor onClose={() => this.setState({ insertarMedidorModalAbierto: false })} />
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
              this.state.Medidors.map((b) => (
                <Tr key={b.MedidorId}>
                  <Td>{b.medidorId}</Td>
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
          // { this.state.Medidors.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 