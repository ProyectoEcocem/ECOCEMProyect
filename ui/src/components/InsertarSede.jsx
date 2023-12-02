import React, { useState, useEffect } from "react";
import axios from "axios";
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
  const [empresaId, setEmpresaId] = useState("");

  function EnviarForm(){
    const sede = {
      numeroSede: numeroSede,
      nombreSede: nombreSede,
      ubicacion: ubicacion,
      empresaId: empresaId
    };
    axios.post(`http://localhost:5103/api/Sede`, {
      numeroSede: numeroSede,
      nombreSede: nombreSede,
      ubicacion: ubicacion,
      empresaId: empresaId
    })
    .then((response) => {
      console.log(response);
    }, (error) => {
      console.log(error);
    });
  };
  // useEffect(() => {
  //   setInsertSuccess(false);
  // }, [numeroSede,nombreSede,ubicacion,empresaId]);
 

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

            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>EmpresaId</FormLabel>
              <Input
                value={empresaId}
                placeholder="Ingrese la empresaId"
                onChange={(e) => setEmpresaId(e.target.value)}
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