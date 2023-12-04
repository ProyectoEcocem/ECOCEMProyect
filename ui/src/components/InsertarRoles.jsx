import { useState } from "react";
import {
    FormControl,
    FormLabel,
    Input,
    Button,
    Flex,
    Select,
    //BackgroundImage
  } from "@chakra-ui/react";
  import axios from "axios"; 

const InsertarRoles = () => {
  const [nombreRol, setNombreRol] = useState("");
  const [descripcionRol, setDescripcionRol] = useState("");

  const crearRol = async () => {
    const rol = {
      nombreRol: nombreRol,
      descripcionRol: descripcionRol
    };
      axios.post(`http://localhost:5103/api/Role`, {
      nombreRol: nombreRol,
      descripcionRol: descripcionRol
    })
    .then((response) => {
      console.log(response);
      alert("Ok")
    }, (error) => {
      console.log(error);
      alert("No ok")
    });
};

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
     
<FormLabel style={{fontSize: 30, marginTop: 10}}>
  Insertar Roles
</FormLabel>

  <FormControl>
              <FormLabel style={{margin: "10px 20px 0px 40px"}}>Nombre del Rol</FormLabel>
              <Input
                value={nombreRol}
                placeholder="Ingrese el nombre del Rol"
                onChange={(e) => setNombreRol(e.target.value)}
                marginTop={0.5}
                marginBottom={10}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormControl>
              <FormLabel style={{margin: "0px 20px 0px 40px"}}>Descripcion del Rol</FormLabel>
              <Input
                value={descripcionRol}
                placeholder="Ingrese la descripción del Rol"
                onChange={(e) => setDescripcionRol(e.target.value)}
                marginTop={0.5}
                marginBottom={10}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>

        <Flex>
        <Button 
        variant="contained" 
        color="primary" 
        style={{ marginRight: 10 }} 
        onClick={crearRol}
        type="submit"
        >
          Aceptar
        </Button>
        </Flex>
      </div>
  );
};

export default InsertarRoles;