import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react";

const InsertarVehiculo = ({onClose}) => {
  const [numeroVehiculo, setNumeroVehiculo] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);
  const [insertarVehiculoModalAbierto, setInsertarVehiculoModalAbierto] = useState(false);

  const createVehiculo = async () => {
  
    axios.post(`http://localhost:5103/api/Vehiculo`, {
        VehiculoId: 0,
        NoSerie: numeroVehiculo
    })
    .then((response) => {
      console.log(response);
      alert("El Vehículo se ha insertado correctamente")
      setInsertarVehiculoModalAbierto(false);
      onClose();
    }, (error) => {
      console.log(error);
      alert("El Vehículo no se ha insertado")
    });
  };
 
  

  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroVehiculo]);

  const handleCancelar = () => {
    // Cierra la ventana modal desde el componente padre.
    onClose();
  };

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
      <FormLabel style={{ fontSize: 30, marginBottom: 20 }}>Insertar Vehículo</FormLabel>

     <FormControl>
        <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          Nombre de Vehículo
        </FormLabel>
        <Input
          value={numeroVehiculo}
          placeholder="Ingrese el Nombre de la Vehículo"
          onChange={(e) => setNumeroVehiculo(e.target.value)}
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
          onClick={createVehiculo}
          type="submit"
          >
          {insertSuccess && (
            <div style={{ marginTop: 20 }}>
              <Alert status="success">El vehículo se creó correctamente.</Alert>
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

export default InsertarVehiculo;
