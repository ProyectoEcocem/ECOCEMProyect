
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
import  InsertarMedicionSilo from './InsertarMedicionSilo'
import InsertarMedicionBascula from './InsertarMedicionBascula'

export default class Carga extends React.Component {
    state = {
      cargas: [],
      insertarMedMedidorModalAbierto: false,
      insertarMedBasculaModalAbierto: false,
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Carga`)
        .then(res => {
          const cargas= res.data;
          this.setState({ Ventas });
        })
    }

    manejarClickAMedidor = () => {
      this.setState({ insertarMedMedidorModalAbierto: true });
    };

    manejarClickABascula = () => {
      this.setState({ insertarMedBasculaModalAbierto: true });
    }
  
    render() {
      return (
        <div style={{ position: "absolute", top: "5%", left: "65%", transform: "translateX(-50%)" }}>

         <Modal isOpen={this.state.insertarMedMedidorModalAbierto} onClose={() => this.setState({ insertarMedMedidorModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarMedicionSilo onClose={() => this.setState({ insertarMedMedidorModalAbierto: false })} />

         </AbsoluteCenter>
         </Modal>

         <Modal isOpen={this.state.insertarMedBasculaModalAbierto} onClose={() => this.setState({ insertarMedBasculaModalAbierto: false })}>
         <AbsoluteCenter>
         <InsertarMedicionBascula onClose={() => this.setState({ insertarMedBasculaModalAbierto: false })} />
         
         </AbsoluteCenter>
         </Modal>
        <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Th>Sede Id</Th>
              <Th>Entidad Compradora Id</Th>
              <Th>Fecha</Th>
              <Th>Medición Medidor Final</Th>
              <Th>Medición Báscula Final</Th>
            </Tr>
          </Thead>
          <Tbody>
            {
              this.state.cargas.map((carga) => (
                <Tr key={carga.cargaId}>
                  <Td>{carga.tipoCementoId}</Td>
                  <Td>{carga.siloId}</Td>
                  <Td>{carga.vehiculoId}</Td>
                  <Td>{carga.sedeId}</Td>
                  <Td>{carga.entidadCompradoraId}</Td>
                  <Td>P{carga.fechaVentaId}</Td>
                  <Td>
                    <Button onClick={() => this.manejarClickAMedidor(carga)}>+ M. Medidor</Button>
                  </Td>
                  <Td>
                    <Button onClick={() => this.manejarClickABascula(carga)}>+ M. Medidor</Button>
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