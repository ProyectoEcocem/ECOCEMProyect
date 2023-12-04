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
//import { sedeController } from "../../../Controllers/Entidades"

const InsertarSede = () => {
  const [numeroSede, setNumeroSede] = useState("");
  const [nombreSede, setNombreSede] = useState("");
  const [ubicacionSede, setUbicacion] = useState("");
  const [empresaId, setEmpresaId] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);

  const EnviarForm = async () => {
    const sede = {
      numeroSede: numeroSede,
      nombreSede: nombreSede,
      ubicacionSede: ubicacionSede,
      empresaId: empresaId
    };
    axios.post(`http://localhost:5103/api/Sede`, {
      numeroSede: numeroSede,
      nombreSede: nombreSede,
      ubicacionSede: ubicacionSede,
      empresaId: empresaId
    })
    .then((response) => {
      console.log(response);
      alert("se inserto")
    }, (error) => {
      console.log(error);
      alert(console.log(error))
      alert("noo se inserto")
    });
  };

   useEffect(() => {
     setInsertSuccess(false);
   }, [numeroSede,nombreSede,ubicacionSede,empresaId]);
 

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
                value={ubicacionSede}
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
        <Button 
          variant="contained" 
          color="primary" 
          style={{ marginRight: 10 }}
          onClick = {EnviarForm}
          type="submit"
          mt="4"
          >
          {insertSuccess && (
            <div style={{ marginTop: 20 }}>
              <Alert status="success">La empresa se creó correctamente.</Alert>
            </div>
          )}
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