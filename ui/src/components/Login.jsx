//import React from "react";
import { useState } from "react";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  //BackgroundImage
} from "@chakra-ui/react"; 

const Login = () => {
    const [nombreUsuario, setNombreUsuario] = useState("");
    const [contraseña, setContraseña] = useState("");
  
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
             <img
        src="/public/ecocemlogo.png"
        alt="Logo"
        width={100}
        height={100}
        
      />
          <FormControl>
              <FormLabel style={{margin: "30px 20px 0px 40px"}}>Nombre de usuario</FormLabel>
              <Input
                value={nombreUsuario}
                placeholder="Ingrese su nombre de usuario"
                onChange={(e) => setNombreUsuario(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Contraseña</FormLabel>
              <Input
                type="password"
                value={contraseña}
                placeholder="Ingrese su contraseña"
                onChange={(e) => setContraseña(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <Button
              variant="contained"
              color="primary"
              marginTop={6}
            >
              Continuar
            </Button>
          </div>
    );
  };
  
  export default Login;