
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
  AbsoluteCenter
  //BackgroundImage
} from "@chakra-ui/react";
import axios from 'axios';
import InsertarTipoCemento  from './InsertarTipoCemento'
export default class TipoCemento extends React.Component {
    state = {
      TipoCementos: [],
      insertarTipoCementoModalAbierto: false,
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/TipoCemento`)
        .then(res => {
          const TipoCementos= res.data;
          this.setState({ TipoCementos });
        })
    }

    manejarInsertarTipoCementoModal = () => {
      this.setState({ insertarTipoCementoModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{height : 400}}>
          <AbsoluteCenter top={"80px"} left={"600px"}>
          <Button
         onClick={this.manejarInsertarTipoCementoModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Tipo de Cemento
         </Button>
         <Modal isOpen={this.state.insertarTipoCementoModalAbierto} onClose={() => this.setState({ insertarTipoCementoModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarTipoCemento onClose={() => this.setState({ insertarTipoCementoModalAbierto: false })} />
         </AbsoluteCenter>
         </Modal>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Th>ID</Th>
              <Th>Nombre del tipo de cemento</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.TipoCementos.map((b) => (
                <Tr key={b.TipoCementoId}>
                  <Td>{b.tipoCementoId}</Td>
                  <Td>{b.nombreTipoCemento}</Td>
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
          // { this.state.TipoCementos.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 