
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
import InsertarVenta from './InsertarVenta'
import InsertarCarga from './InsertarCarga'
export default class Venta extends React.Component {
    state = {
      Ventas: [],
      insertarVentaModalAbierto: false,
      insertarCargaModalAbierto: false,
    }
  
    componentDidMount() {
      this.cargarBD();
    }

    cargarBD() {
      axios.get(`http://localhost:5103/api/Venta`)
      .then(res => {
        const Ventas= res.data;
        this.setState({ Ventas });
      })
    }

    manejarInsertarVentaModal = () => {
      this.setState({ insertarVentaModalAbierto: true });
    };

    manejarClickACarga = (venta) => {
      this.setState({ insertarCargaModalAbierto: true });
    }
  
    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "55%", transform: "translateX(-50%)" }}>
          <Button
         onClick={this.manejarInsertarVentaModal}
         marginBottom={5}
         marginTop={5}
         >
          Agregar Venta
         </Button>
         <Modal isOpen={this.state.insertarVentaModalAbierto} onClose={() => this.setState({ insertarVentaModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarVenta onClose={() => {this.setState({ insertarVentaModalAbierto: false }); this.cargarBD();} }/>

         </AbsoluteCenter>
         </Modal>

         <AbsoluteCenter>
         <Modal isOpen={this.state.insertarCargaModalAbierto} onClose={() => this.setState({ insertarCargaModalAbierto: false })}>
         
         <InsertarCarga onClose={() => this.setState({ insertarCargaModalAbierto: false })} />
         
         
         </Modal>
         </AbsoluteCenter>

        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Th>Sede Id</Th>
              <Th>Entidad Compradora Id</Th>
              <Th>Fecha</Th>
              <Th>Asociar Carga</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.Ventas.map((venta) => (
                <Tr key={venta.VentaId}>
                  <Td>{venta.sedeId}</Td>
                  <Td>{venta.entidadCompradoraId}</Td>
                  <Td>{venta.fechaVentaId}</Td>
                  <Td>
                    <Button onClick={() => this.manejarClickACarga(venta)}>+ Carga</Button>
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
          // { this.state.Ventas.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
        // </ul>
      )
    }
  } 