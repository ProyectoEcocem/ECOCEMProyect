import { useState, fetch } from "react";
import {
    FormControl,
    FormLabel,
    Input,
    Button,
    Flex,
    //BackgroundImage
  } from "@chakra-ui/react"; 
//import axios from "axios";
//import { sedeController } from "../../../Controllers/Entidades"

const InsertarSede = () => {
  const [numeroSede, setNumeroSede] = useState("");
  const [nombreSede, setNombreSede] = useState("");
  const [ubicacion, setUbicacion] = useState("");

  function EnviarForm(){
    const sede = {
      numeroSede: numeroSede,
      nombreSede: nombreSede,
      ubicacion: ubicacion,
    };

    // Llama al método Post de SedeController
  fetch("/SedeController/Post", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(sede),
  })
    .then((response) => {
      if (response.status === 200) {
        // La sede se insertó correctamente
        alert("La sede se insertó correctamente");
      } else {
        // Ocurrió un error
        alert("Ocurrió un error al insertar la sede");
      }
    })
    .catch((error) => {
      // Ocurrió un error inesperado
      alert("Ocurrió un error inesperado");
    });

  }

  return (
    <div style={{
      width: "400px",
      height: "400px",
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      backgroundColor: "white",
      flexDirection: "column",
      borderRadius: 20,
      border: "2px solid #5F89C1",
    }}>
     
<FormLabel style={{fontSize: 30}}>
  Insertar Sede
</FormLabel>

  <FormControl>
              <FormLabel style={{margin: "0px 20px 0px 40px"}}>Número de Sede</FormLabel>
              <Input
                value={numeroSede}
                placeholder="Ingrese el Número de la Sede"
                onChange={(e) => setNumeroSede(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Nombre de la Sede</FormLabel>
              <Input
                value={nombreSede}
                placeholder="Ingrese el nombre de la Sede"
                onChange={(e) => setNombreSede(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>

            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Ubicación</FormLabel>
              <Input
                value={ubicacion}
                placeholder="Ingrese la ubicación"
                onChange={(e) => setUbicacion(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
                marginBottom={30}
              />
            </FormControl>
        <Flex>
        <Button variant="contained" color="primary" style={{ marginRight: 10, onClick:{EnviarForm}}}>
          Aceptar
        </Button>
        <Button variant="contained" color="secondary">
          Cancelar
        </Button>
        </Flex>
      </div>
  );
};

export default InsertarSede;

// ToDo: Verificar que ya no exista la sede creada (por el Id)
// ToDo: Evento con los botones.
// Question: Las sedes tienen un id propio en la vida real o es asignado por el programa?