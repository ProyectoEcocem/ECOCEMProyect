import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react";

const InsertarFabrica = ({onClose}) => {
  const [numeroFabrica, setNumeroFabrica] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);
  const [insertarFabricaModalAbierto, setInsertarFabricaModalAbierto] = useState(false);

  const createFabrica = async () => {
  
    axios.post(`http://localhost:5103/api/Fabrica`, {
        FabricaId: 0,
        Nombre: numeroFabrica
    })
    .then((response) => {
      console.log(response);
      alert("Se ha insertado la Fábrica")
      setInsertarFabricaModalAbierto(false);
    }, (error) => {
      console.log(error);
      alert("No se ha insertado la Fábrica")
    });
  };
 
  const handleCancelar = () => {
    // Cierra la ventana modal desde el componente padre.
    onClose();
  };

  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroFabrica]);

  return (
    <div
      style={{
        width: "400px",
        height: "400px",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "white",
        flexDirection: "column",
        borderRadius: 20,
        border: "2px solid #5F89C1",
      }}
    >
      <FormLabel style={{ fontSize: 30, marginBottom:20 }}>Insertar Fabrica</FormLabel>

     <FormControl>
        <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          Nombre de la Fábrica
        </FormLabel>
        <Input
          value={numeroFabrica}
          placeholder="Ingrese el Nombre de la Fabrica"
          onChange={(e) => setNumeroFabrica(e.target.value)}
          marginTop={0.5}
          marginLeft={9}
          width={80}
          backgroundColor="white"
        />
      </FormControl>

      <Flex justifyContent="space-between">
        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10, marginTop: 40 }}
          onClick={createFabrica}
          type="submit"
          >
          {insertSuccess && (
            <div style={{ marginTop: 20 }}>
              <Alert status="success">La Fábrica se creó correctamente.</Alert>
            </div>
          )}
          Aceptar
        </Button>
      
        <Button variant="outline" colorScheme="red" marginTop={10} onClick={handleCancelar}>
    Cancelar
  </Button>
  </Flex>
    </div>
  );
};

export default InsertarFabrica;
