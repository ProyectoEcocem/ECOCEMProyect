import { useState, useEffect } from "react";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
  Modal,
  AbsoluteCenter,
  //BackgroundImage
} from "@chakra-ui/react"; 
import axios from "axios";

const InsertarBrigada = ({onClose}) => {
    const [brigadaId, setBrigadaId] = useState(0);
    const [descripcion, setDescripcion] = useState("");
    const [insertarBrigadaModalAbierto, setInsertarBrigadaModalAbierto] = useState(false);

    const createBrigada = async () => {
      
        axios.post(`http://localhost:5103/api/Brigada`, {
        brigadaId: brigadaId,
        descripcion: descripcion
      })
      .then((response) => {
       // console.log(response);
        alert("La Brigada se ha insertado correctamente")
        setInsertarBrigadaModalAbierto(false);
      }, (error) => {
        console.log(error);
        alert("La Brigada no se ha insertado.")
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
  Insertar Brigada
</FormLabel>
      

            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Descripcion</FormLabel>
              <Input
                value={descripcion}
                placeholder="Ingrese la descripcion de la Brigada"
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
        onClick={createBrigada}
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

export default InsertarBrigada;
