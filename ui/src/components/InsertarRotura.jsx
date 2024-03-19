import { useState, useEffect } from "react";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
  Modal,
  //BackgroundImage
} from "@chakra-ui/react"; 
import axios from "axios";

const InsertarRotura = ({onClose}) => {
    const [nombreRotura, setNombreRotura] = useState("");
    const [insertarRoturaModalAbierto, setInsertarRoturaModalAbierto] = useState(false);
    const [descripcion, setDescripcion] = useState("")

    const createRotura = async () => {
      
        axios.post(`http://localhost:5103/api/Rotura`, {
        roturaId: 0,
        nombreRotura: nombreRotura,
        descripcion: descripcion
      })
      .then((response) => {
       // console.log(response);
        alert("La Rotura se ha insertado correctamente")
        setInsertarRoturaModalAbierto(false);
      }, (error) => {
        console.log(error);
        alert("La Rotura no se ha insertado.")
      });
    };

    const handleCancelar = () => {
      // Cierra la ventana modal desde el componente padre.
      onClose();
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
          
<FormLabel style={{fontSize: 30, marginTop: 20}}>
  Insertar Tipo de Rotura
</FormLabel>
      
            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Nombre de la Rotura</FormLabel>
              <Input
                value={nombreRotura}
                placeholder="Ingrese el nombre de la Rotura"
                onChange={(a) => setNombreRotura(a.target.value)}
                marginTop={0.5}
                marginLeft={10}
                width={80}
                backgroundColor= "white"
                marginBottom={30}
              />
            </FormControl>

            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Descripción de la Rotura</FormLabel>
              <Input
                value={descripcion}
                placeholder="Ingrese una descripción"
                onChange={(a) => setDescripcion(a.target.value)}
                marginTop={0.5}
                marginLeft={10}
                width={80}
                backgroundColor= "white"
                marginBottom={30}
              />
            </FormControl>
            
            <Flex justifyContent="space-between">
        <Button 
        variant="outline"
        colorScheme="blue"
        style={{ marginRight: 10, marginTop: 15}}
        onClick={createRotura}
        type="submit"
        >
          Aceptar
        </Button>
        <Button variant="outline" colorScheme="red" marginTop={4} onClick={handleCancelar}>
    Cancelar
  </Button>
  </Flex>
      </div>
  );
};

export default InsertarRotura;
