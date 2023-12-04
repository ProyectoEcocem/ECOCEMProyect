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

const InsertarUsuarios = () => {
  const [nombreUsuario, setNombreUsuario] = useState("");
  const [constrasena, setContrasena] = useState("");

  const crearRegistro = async () => {
    const user = {
      name: nombreUsuario,
      password: contrasena,
      old_Password:"",
      email:""
    };
    const role = {
      name: nombreUsuario,
      description: ""
    };

    axios.post(`http://localhost:5103/api/Register`, {
      user,role
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
              <FormLabel style={{margin: "10px 20px 0px 40px"}}>Nombre del Usuario</FormLabel>
              <Input
                value={nombreUsuario}
                placeholder="Ingrese el nombre del Usuario"
                onChange={(e) => setNombreUsuario(e.target.value)}
                marginTop={0.5}
                marginBottom={10}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormControl>
              <FormLabel style={{margin: "0px 20px 0px 40px"}}>Contraseña</FormLabel>
              <Input
                value={descripcionRol}
                placeholder="Ingrese la contraseña"
                onChange={(e) => setContrasena(e.target.value)}
                marginTop={0.5}
                marginBottom={10}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>

        <Flex>
        <Button variant="contained" color="primary" style={{ marginRight: 10 }} onClick={crearRol}>
          Aceptar
        </Button>
        </Flex>
      </div>
  );
};

export default InsertarUsuarios;