import {
    FormLabel,
    Table,
    TableContainer,
    Thead,
    Tbody,
    Tr,
    Th,
    Td,
    //BackgroundImage
  } from "@chakra-ui/react"; 

  const VisualizarTipoEquipo = () => {

  //para testear
  const tipoEquipos = [
    {id: 1, tipoEquipo: "Tipo de Equipo 1"},
    {id: 2, tipoEquipo: "Tipo de Equipo 2"},
    {id: 3, tipoEquipo: "Tipo de Equipo 3"},
    {id: 4, tipoEquipo: "Tipo de Equipo 4"}
  ]

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
        <FormLabel style={{fontSize: 30}}>Tipos de Equipo</FormLabel>

        <TableContainer>
            <Table>
                <Thead>
                    <Tr>
                        <Th>No. Tipo de Equipo</Th>
                        <Th>Tipo de Equipo</Th>
                    </Tr>
                </Thead>
                <Tbody>
                    {tipoEquipos.map((tipoEquipo) => (
                        <Tr key = {tipoEquipo.id}>
                            <Td>{tipoEquipo.id}</Td>
                            <Td>{tipoEquipo.tipoEquipo}</Td>
                        </Tr>
                    ))}
                </Tbody>
            </Table>
        </TableContainer>
    </div>
  );

  };
 export default VisualizarTipoEquipo;