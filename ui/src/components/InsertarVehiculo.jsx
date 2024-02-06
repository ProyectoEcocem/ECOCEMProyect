import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react";

const InsertarVehiculo = () => {
  const [numeroVehiculo, setNumeroVehiculo] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);

  const createVehiculo = async () => {
  
    axios.post(`http://localhost:5103/api/Vehiculo`, {
        VehiculoId: 0,
        NoSerie: numeroVehiculo
    })
    .then((response) => {
      console.log(response);
      alert("Se inserto")
    }, (error) => {
      console.log(error);
      alert("no")
    });
  };
 
  

  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroVehiculo]);

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
      <FormLabel style={{ fontSize: 30 }}>Insertar Vehiculo</FormLabel>

     <FormControl>
        <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          Nombre de Vehiculo
        </FormLabel>
        <Input
          value={numeroVehiculo}
          placeholder="Ingrese el Nombre de la Vehiculo"
          onChange={(e) => setNumeroVehiculo(e.target.value)}
          marginTop={0.5}
          width={80}
          backgroundColor="white"
        />
      </FormControl>


        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10, marginTop: 20 }}
          onClick={createVehiculo}
          type="submit"
          >
          {insertSuccess && (
            <div style={{ marginTop: 20 }}>
              <Alert status="success">La  se creó correctamente.</Alert>
            </div>
          )}
          Aceptar
        </Button>
      

    </div>
  );
};

export default InsertarVehiculo;
