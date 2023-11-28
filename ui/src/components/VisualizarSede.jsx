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

  const VisualizarSede = () => {

  //para testear
  const sedes = [
    {id: 1, nombre: "Sede1", ubicacion: "ubicacion1" },
    {id: 2, nombre: "Sede2", ubicacion: "ubicacion2" },
    {id: 3, nombre: "Sede3", ubicacion: "ubicacion3" },
    {id: 4, nombre: "Sede4", ubicacion: "ubicacion4" }
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
        <FormLabel style={{fontSize: 30}}>Sedes</FormLabel>

        <TableContainer>
            <Table>
                <Thead>
                    <Tr>
                        <Th>No. Sede</Th>
                        <Th>Nombre de Sede</Th>
                        <Th>Ubicación</Th>
                    </Tr>
                </Thead>
                <Tbody>
                    {sedes.map((sede) => (
                        <Tr key = {sede.id}>
                            <Td>{sede.id}</Td>
                            <Td>{sede.nombre}</Td>
                            <Td>{sede.ubicacion}</Td>
                        </Tr>
                    ))}
                </Tbody>
            </Table>
        </TableContainer>
    </div>
  );

  };
 export default VisualizarSede;