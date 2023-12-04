import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react";

const InsertarEmpresa = () => {
  const [numeroEmpresa, setNumeroEmpresa] = useState("");
  const [nombreEmpresa, setNombreEmpresa] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);

  const createEmpresa = async () => {
    const empresa = {
      numeroEmpresa: numeroEmpresa,
      nombreEmpresa: nombreEmpresa
    };
  
    axios.post(`http://localhost:5103/api/Empresa`, {
      numeroEmpresa: numeroEmpresa,
      nombreEmpresa: nombreEmpresa
    })
    .then((response) => {
      console.log(response);
    }, (error) => {
      console.log(error);
    });
  };
 
  

  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroEmpresa, nombreEmpresa]);

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
      <FormLabel style={{ fontSize: 30 }}>Insertar Empresa</FormLabel>

      <FormControl>
        <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          Número de Empresa
        </FormLabel>
        <Input
          value={numeroEmpresa}
          placeholder="Ingrese el Número de la Empresa"
          onChange={(e) => setNumeroEmpresa(e.target.value)}
          marginTop={0.5}
          width={80}
          backgroundColor="white"
        />
      </FormControl>

      <FormControl>
        <FormLabel style={{ margin: "20px 0px 0px 40px" }}>
          Nombre de la Empresa
        </FormLabel>
        <Input
          value={nombreEmpresa}
          placeholder="Ingrese el nombre de la Empresa"
          onChange={(e) => setNombreEmpresa(e.target.value)}
          marginTop={0.5}
          width={80}
          backgroundColor="white"
        />
      </FormControl>

        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10, marginTop: 20 }}
          onClick={createEmpresa}
          type="submit"
          >
          {insertSuccess && (
            <div style={{ marginTop: 20 }}>
              <Alert status="success">La empresa se creó correctamente.</Alert>
            </div>
          )}
          Aceptar
        </Button>
      

    </div>
  );
};

export default InsertarEmpresa;
