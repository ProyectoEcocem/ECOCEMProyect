
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
import InsertarCompra from './InsertarCompra'
import InsertarDescarga from './InsertarDescarga'
export default class Compra extends React.Component {
    state = {
      Compras: [],
      insertarCompraModalAbierto: false,
      insertarDescargaModalAbierto: false,
      selectedSedeId:1,
      selectedFabricaId:1,
      selectedFechaCompra: new Date()
    }
  
    componentDidMount() {
      this.cargarBD();
    }

    cargarBD() {
      axios.get(`http://localhost:5103/api/Compra`)
      .then(res => {
        const Compras= res.data;
        this.setState({ Compras });
      })
    }
    manejarInsertarCompraModal = () => {
      this.setState({ insertarCompraModalAbierto: true });
    };

    manejarClickADescarga = (selectedSedeId, selectedFabricaId, seectedFechaCompra) => {
      this.setState({ insertarDescargaModalAbierto: true });
    }
  
    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "60%", transform: "translateX(-50%)" }}>
          <Button
         onClick={this.manejarInsertarCompraModal}
         marginBottom={5}
         marginTop={5}
         >Agregar Compra</Button>
         <Modal isOpen={this.state.insertarCompraModalAbierto} onClose={() => this.setState({ insertarCompraModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarCompra onClose={() => {this.setState({ insertarCompraModalAbierto: false }); this.cargarBD();} }/>

         </AbsoluteCenter>
         </Modal>
         <AbsoluteCenter>
         <Modal isOpen={this.state.insertarDescargaModalAbierto} onClose={() => this.setState({ insertarDescargaModalAbierto: false })}>
         
         <InsertarDescarga sedeId={this.state.selectedSedeId} fabricaId={this.state.selectedFabricaId} fechaCompraId={this.state.selectedFechaCompra} onClose={() => this.setState({ insertarDescargaModalAbierto: false })} />
         
         
         </Modal>
         </AbsoluteCenter>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
            <Th>Sede Id</Th>
            <Th>Fabrica Id</Th>
            <Th>Fecha</Th>
            <Th>Asociar Descarga</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Compras.map((compra) => (
                <Tr key={compra.CompraId}>
                  <Td>{compra.sedeId}</Td>
                  <Td>{compra.fabricaId}</Td>
                  <Td>{compra.fechaId}</Td>
                  <Td>
                    <Button onClick={() => {this.manejarClickADescarga(compra.sedeId, compra.entidadCompradoraId, compra.fechaId); this.setState({selectedSedeId: compra.sedeId}); this.setState({selectedFabricaId: compra.fabricaId}); this.setState({selectedFechaCompra: compra.fechaCompraId})}}>+ Descarga</Button>
                  </Td>
                </Tr>
              )
              )
            }
          </Tbody>
        </Table>
      </TableContainer>
      </div>
        // <ul>
          // { this.state.Compras.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 