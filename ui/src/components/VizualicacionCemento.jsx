
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
  AbsoluteCenter,
  //BackgroundImage
} from "@chakra-ui/react";
import axios from 'axios';
export default class VisualizarCemento extends React.Component {
    state = {
        TipoCemento: [],
      insertarTipoCementoModalAbierto: false, //controlar si la pestana de insertar brigada esta abierta
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/FiltroMantenimientoController/GetCementos`)
        .then(res => {
          const TipoCemento = res.data;
          this.setState({ TipoCemento });
        })
    }

    manejarInsertarTipoCementoModal = () => {
      this.setState({ insertarTipoCementoModalAbierto: true });
    };
  
    render() {
      return (
        <div style={{height : 400}}>

          <Button
         onClick={this.manejarInsertarTipoCementoModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar TipoCemento
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
                <Th>Nombre</Th>
              </Tr>
            </Thead>
            <Tbody>
              {
                this.state.TipoCementos.map((tc) => (
                  <Tr key={tc.tipoCementoId}>
                    <Td>{tc.sedeId}</Td>
                    <Td>{tc.noSilo}</Td>
                    <Td>{tc.tipoCementoId}</Td>

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