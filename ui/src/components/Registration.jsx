//import React from "react";
import { useState, useEffect} from "react";
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

const Registration = ({manejoClick, onclose}) => {
    const [nombreUsuario, setNombreUsuario] = useState("");
    const [contrasena, setContraseña] = useState("");
    const [noSede, setNoSede]  = useState(0);
    const [rol, setRol]        = useState('');

    
      const [sedes, setSedes] = useState([]);

      // const roles = ["Administrador", "Jefe de Mantenimiento"]
      const roles = ["admin", "jefe"]
      
  
  useEffect(() => {
    axios.get(`http://localhost:5103/api/Sede`)
      .then(res => {
        setSedes(res.data);
      })
      .catch(err => console.log(err));
  }, []);
  const ClickAceptar = async () => {
    
    if (!nombreUsuario || !contrasena) {
        alert("Ingrese un nombre de usuario y una contraseña.");
        return;
      }
  
        axios.post(`http://localhost:5103/api/Registration`,{
          Name : nombreUsuario,
          Password : contrasena,
          noSede: noSede,
          rol: rol
        })
        .then((response) => {
            console.log(response);
            alert("Usuario registrado.");
            manejoClick();
            onclose();
        }, (error) => {
            console.log(error);
            alert("No se ha registrado al usuario.")
        });

        
        }
        const handleCancelar = () => {
            // Cierra la ventana modal desde el componente padre.
            onClose();
          };
    return (
        <div style={{
            width: "400px",
            height: "650px",
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            backgroundColor: "white",
            flexDirection: "column",
            borderRadius: 20,
            border: "2px solid #5F89C1",
            position: "absolute", top: "5%", left: "65%", transform: "translateX(-50%)"
          }}>
             <img
        src="/public/ecocemlogo.png"
        alt="Logo"
        width={80}
        height={80}
        marginTop={20}
        marginBottom={0}
        
      />
      <FormLabel style={{marginLeft:10, fontSize: 20}}>Crear Usuario</FormLabel>
          <FormControl>
              <FormLabel style={{marginLeft:30}}>Nombre de usuario</FormLabel>
              <Input
                value={nombreUsuario}
                placeholder="Ingrese el nombre de usuario"
                onChange={(e) => setNombreUsuario(e.target.value)}
                marginTop={0.5}
                marginLeft={30}
                marginBottom={5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormControl>
              <FormLabel style = {{marginLeft:30}}>Contraseña</FormLabel>
              <Input
                type="password"
                value={contrasena}
                placeholder="Ingrese su contraseña"
                onChange={(e) => setContraseña(e.target.value)}
                marginTop={0.5}
                marginLeft={30}
                marginBottom={5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>

            <FormLabel style={{marginLeft:10, marginRight:300}}>Sede</FormLabel>
            <Select
          value={noSede}
          onChange={(e) => setNoSede(e.target.value)}
          width={80}
          marginLeft={5}
          marginRight={25}
          marginBottom={5}
        >
          {sedes.map((sede) => (
            <option key={sede.sedeId} value={sede.sedeId}>
              {sede.nombreSede}
              
            </option>
          ))}
        </Select>

        <FormLabel style={{marginLeft:10, marginRight:300}}>Rol</FormLabel>
            <Select
          value={rol}
          onChange={(e) => setRol(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {roles.map((rol) => (
            <option key={rol} value={rol}>
              {rol}
              
            </option>
          ))}
        </Select>


      <Flex>
            <Button
              variant="contained"
              color="primary"
              marginTop={6}
              style={{marginRight: 10}}
              onClick={ClickAceptar}
              type="submit"
            >
              Aceptar
            </Button>
            <Button variant="outline" colorScheme="red" marginTop={6} onClick={handleCancelar}>
    Cancelar
  </Button>
  </Flex>
          </div>
    );
  };

  export default Registration;