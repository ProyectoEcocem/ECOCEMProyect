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

  const VisualizarRotura = () => {

  //para testear
  const roturas = [
    {id: 1, nombre: "Rotura 1"},
    {id: 2, nombre: "Rotura 2"},
    {id: 3, nombre: "Rotura 3"},
    {id: 4, nombre: "Rotura 4"}
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
        <FormLabel style={{fontSize: 30}}>Tipos de Rotura</FormLabel>

        <TableContainer>
            <Table>
                <Thead>
                    <Tr>
                        <Th>No. Rotura</Th>
                        <Th>Nombre de Rotura</Th>
                    </Tr>
                </Thead>
                <Tbody>
                    {roturas.map((rotura) => (
                        <Tr key = {rotura.id}>
                            <Td>{rotura.id}</Td>
                            <Td>{rotura.nombre}</Td>
                        </Tr>
                    ))}
                </Tbody>
            </Table>
        </TableContainer>
    </div>
  );

  };
 export default VisualizarRotura;