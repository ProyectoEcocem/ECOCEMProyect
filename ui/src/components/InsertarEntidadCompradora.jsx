import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react";

const InsertarEntidadCompradora = ({onClose}) => {
  const [numeroEntidadCompradora, setNumeroEntidadCompradora] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);
  const [insertarEntidadCompradoraModalAbierto, setInsertarEntidadCompradoraModalAbierto] = useState(false);

  const createEntidadCompradora = async () => {
  
    axios.post(`http://localhost:5103/api/EntidadCompradora`, {
        EntidadCompradoraId: 0,
        NombreEntidadCompradora: numeroEntidadCompradora
    })
    .then((response) => {
      console.log(response);
      alert("La Entidad Compradora se ha insertado exitosamente")
      setInsertarEntidadCompradoraModalAbierto(false);
      onClose();
    }, (error) => {
      console.log(error);
      alert("No se ha insertado.")
    });
  };
 
  const handleCancelar = () => {
    // Cierra la ventana modal desde el componente padre.
    onClose();
  };
  

  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroEntidadCompradora]);

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
      <FormLabel style={{ fontSize: 24, marginBottom: 50}}>Insertar Entidad Compradora</FormLabel>

     <FormControl>
        <FormLabel style={{ marginLeft: 20 }}>
          Nombre de la Entidad Compradora
        </FormLabel>
        <Input
          value={numeroEntidadCompradora}
          placeholder="Ingrese el Nombre de la Entidad Compradora"
          onChange={(e) => setNumeroEntidadCompradora(e.target.value)}
          marginTop={0.5}
          marginLeft={5}
          marginRight={20}
          width={80}
          backgroundColor="white"
        />
      </FormControl>

      <Flex justifyContent="space-between">
        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10, marginTop: 40 }}
          onClick={createEntidadCompradora}
          type="submit"
          >
          {insertSuccess && (
            <div style={{ marginTop: 40 }}>
              <Alert status="success">La  se creó correctamente.</Alert>
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

export default InsertarEntidadCompradora;
