import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    FormControl,
    FormLabel,
    Input,
    Button,
    Flex,
    Modal,
    Select,
    //BackgroundImage
  } from "@chakra-ui/react"; 
//import { sedeController } from "../../../Controllers/Entidades"

const InsertarHerramienta = ({onClose}) => {
  // const [herramientaId, setHerramientaId] = useState(0);
  const [nombre, setNombre] = useState("");
  const [descripcion, setDescripcion] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);
  const [insertarHerramientaModalAbierto, setInsertarHerramientaModalAbierto] = useState(false);


  const EnviarForm = async () => {

    axios.post(`http://localhost:5103/api/Herramienta`, {
      herramientaId: 0,
      nombre: nombre,
      descripcion: descripcion
    })
    .then((response) => {
      //console.log(response);
      alert("La Herramienta ha sido insertada correctamente")
      setInsertarHerramientaModalAbierto(false); // Cierra el modal
    }, (error) => {
      console.log(error);
      alert(console.log(error))
      alert("La Herramienta no se ha insertado.")
    });

    useEffect(() => {
      
  }, []); // El array vacío significa que este efecto se ejecuta solo una vez al montar el componente

  };


   useEffect(() => {
     setInsertSuccess(false);
   }, [nombre,descripcion]);
 

   const handleCancelar = () => {
    // Cierra la ventana modal desde el componente padre.
    onClose();
   
  };

  return (
    <div style={{
      width: "350px",
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
  Insertar Herramienta
</FormLabel>

 
      
            <FormControl>
              <FormLabel style = {{margin: "10px 0px 0px 20px"}}>Nombre de Herramienta</FormLabel>
              <Input
                value={nombre}
                placeholder="Ingrese el nombre de la Herramienta"
                onChange={(e) => setNombre(e.target.value)}
                marginTop={0.5}
                marginLeft={4}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>

            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 20px"}}>Descripción</FormLabel>
              <Input
                value={descripcion}
                placeholder="Ingrese una Descripción"
                onChange={(e) => setDescripcion(e.target.value)}
                marginTop={0.5}
                marginLeft={4}
                width={80}
                backgroundColor= "white"
                marginBottom={1}
              />
            </FormControl>

        <Flex justifyContent="space-between">
        <Button 
          variant="outline"
          colorScheme="blue" 
          style={{ marginRight: 10 }}
          onClick = {EnviarForm}
          type="submit"
          mt="4"
          >
          {insertSuccess && (
            <div style={{ marginTop: 5 }}>
              <Alert status="success">La Herramienta se creó correctamente.</Alert>
            </div>
          )}
          Aceptar
        </Button>
        <Button variant="outline" colorScheme="red" marginTop={4} onClick={handleCancelar}>
    Cancelar
  </Button>
        </Flex>
        
    
      </div>
  );
};

export default InsertarHerramienta;
