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

  const VisualizarEquipo = () => {

  //para testear
  const equipos = [
    {id: 1, tipoEquipo: "Tipo Equipo 1", sede: "sede 1" },
    {id: 2, tipoEquipo: "Tipo Equipo 2", sede: "sede 2" },
    {id: 3, tipoEquipo: "Tipo Equipo 3", sede: "sede 3" },
    {id: 4, tipoEquipo: "Tipo Equipo 4", sede: "sede 4" },
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
        <FormLabel style={{fontSize: 30}}>Equipos</FormLabel>

        <TableContainer>
            <Table>
                <Thead>
                    <Tr>
                        <Th>No. Equipo</Th>
                        <Th>Tipo de Equipo</Th>
                        <Th>Sede a la que pertenece</Th>
                    </Tr>
                </Thead>
                <Tbody>
                    {equipos.map((equipo) => (
                        <Tr key = {equipo.id}>
                            <Td>{equipo.id}</Td>
                            <Td>{equipo.tipoEquipo}</Td>
                            <Td>{equipo.sede}</Td>
                        </Tr>
                    ))}
                </Tbody>
            </Table>
        </TableContainer>
    </div>
  );

  };
 export default VisualizarEquipo;