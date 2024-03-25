import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react";

const InsertarTipoCemento = ({onClose}) => {
  const [numeroTipoCemento, setNumeroTipoCemento] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);
  const [insertarTipoCementoModalAbierto, setInsertarTipoCementoModalAbierto] = useState(false);

  const createTipoCemento = async () => {
  
    axios.post(`http://localhost:5103/api/TipoCemento`, {
        TipoCementoId: 0,
        NombreTipoCemento: numeroTipoCemento
    })
    .then((response) => {
      console.log(response);
      alert("El Tipo de Cemento se ha insertado")
      setInsertarTipoCementoModalAbierto(false);
      onClose();
    }, (error) => {
      console.log(error);
      alert("El Tipo de Cemento no se ha insertado")
    });
  };
 
  const handleCancelar = () => {
    // Cierra la ventana modal desde el componente padre.
    onClose();
  };


  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroTipoCemento]);

  return (
    <div
      style={{
        width: "400px",
        height: "400px",
        display: "flex",
        top: "5%",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "white",
        flexDirection: "column",
        borderRadius: 20,
        border: "2px solid #5F89C1",
      }}
    >
      <FormLabel style={{ fontSize: 30, marginBottom: 20 }}>Insertar Tipo Cemento</FormLabel>

     <FormControl>
        <FormLabel style={{ marginLeft: 40}}>
          Nombre de TipoCemento
        </FormLabel>
        <Input
          value={numeroTipoCemento}
          placeholder="Ingrese el Nombre del Tipo Cemento"
          onChange={(e) => setNumeroTipoCemento(e.target.value)}
          marginTop={0.5}
          marginLeft={10}
          width={80}
          backgroundColor="white"
        />
      </FormControl>

      <Flex>
        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10, marginTop: 40 }}
          onClick={createTipoCemento}
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

export default InsertarTipoCemento;
