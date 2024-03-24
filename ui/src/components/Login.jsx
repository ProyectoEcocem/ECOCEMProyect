//import React from "react";
import { useState } from "react";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  //BackgroundImage
} from "@chakra-ui/react"; 
import axios from "axios"; 
axios.defaults.withCredentials = true;

const Login = ({manejoClick}) => {
    const [nombreUsuario, setNombreUsuario] = useState("");
    const [contrasena, setContraseña] = useState("");

    const ClickAceptar = async () => {

      if (!nombreUsuario || !contrasena) {
        alert("Ingrese un nombre de usuario y una contraseña.");
        return;
      }
        
        axios.post(`http://localhost:5103/api/Login`,{
          Name : nombreUsuario,
          Password : contrasena
        })
        .then((response) => {
          
            console.log(response);
            alert("Inicio de sesión exitoso");
            manejoClick();
        }, (error) => {
            console.log(error);
            alert("Nombre de usuario o contraseña inválidos.")
        });
    };
  
    return (
        <div style={{
            width: "400px",
            height: "580px",
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
      <FormLabel style={{margin: "30px 20px 0px 40px", fontSize: 30}}>Inicio de Sesión</FormLabel>
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
                value={contrasena}
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
              onClick={ClickAceptar}
              type="submit"
            >
              Continuar
            </Button>
          </div>
    );
  };

  export default Login;