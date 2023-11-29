import { useState } from "react";
import {
    FormLabel,
    Table,
    TableContainer,
    Thead,
    Tbody,
    Tr,
    Th,
    Td,
    Input,
    //BackgroundImage
  } from "@chakra-ui/react"; 

  const VisualizarRoturaEquipo = () => {

  //para testear
  const roturaEquipos = [
    {idE: 1, nombre: "RoturaE 1"},
    {idE: 2, nombre: "RoturaE 2"},
    {idE: 3, nombre: "RoturaE 3"},
    {idE: 4, nombre: "RoturaE 4"}
  ]

  const [fecha, setFecha] = useState("");

  return(

    <div style={{
        width: "500px",
        height: "400px",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "white",
        flexDirection: "column",
        borderRadius: 20,
        border: "2px solid #5F89C1",
      }}>
        <FormLabel style={{fontSize: 30}}>Roturas de Equipo</FormLabel>

        <Input
          type="date"
          value={fecha}
          onChange={(e) => setFecha(e.target.value)}
          width={200}
          marginBottom={30}
         
        />

        <TableContainer>
            <Table>
                <Thead>
                    <Tr>
                        <Th>No. Equipo</Th>
                        <Th>Tipo de Rotura</Th>
                    </Tr>
                </Thead>
                <Tbody>
                    {roturaEquipos.map((roturaE) => (
                        <Tr key = {roturaE.idE}>
                            <Td>{roturaE.idE}</Td>
                            <Td>{roturaE.nombre}</Td>
                        </Tr>
                    ))}
                </Tbody>
            </Table>
        </TableContainer>
    </div>
  );

  };
 export default VisualizarRoturaEquipo;