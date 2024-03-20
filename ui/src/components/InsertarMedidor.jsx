import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react";

const InsertarMedidor = ({onClose}) => {
  const [numeroMedidor, setNumeroMedidor] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);
  const [insertarMedidorModalAbierto, setInsertarMedidorModalAbierto] = useState(false);

  const createMedidor = async () => {
  
    axios.post(`http://localhost:5103/api/Medidor`, {
        MedidorId: 0,
        NoSerie: numeroMedidor
    })
    .then((response) => {
      console.log(response);
      alert("El Medidor se ha insertado")
      setInsertarMedidorModalAbierto(false);
    }, (error) => {
      console.log(error);
      alert("El Medidor no se ha insertado")
    });
  };
 
  const handleCancelar = () => {
    // Cierra la ventana modal desde el componente padre.
    onClose();
  };

  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroMedidor]);

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
      <FormLabel style={{ fontSize: 30, marginBottom: 20 }}>Insertar Medidor</FormLabel>

     <FormControl>
        <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          Nombre de Medidor
        </FormLabel>
        <Input
          value={numeroMedidor}
          placeholder="Ingrese el Nombre de la Medidor"
          onChange={(e) => setNumeroMedidor(e.target.value)}
          marginTop={0.5}
          marginLeft={10}
          width={80}
          backgroundColor="white"
        />
      </FormControl>

      <Flex justifyContent="space-between">
        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10, marginTop: 40 }}
          onClick={createMedidor}
          type="submit"
          >
          {insertSuccess && (
            <div style={{ marginTop: 20 }}>
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

export default InsertarMedidor;
