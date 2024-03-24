import React, { useState } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
  Modal,
} from "@chakra-ui/react"; 

const InsertarTipoDeEquipo = ({onClose}) => {
    const [tipoEquipo, setTipoEquipo] = useState("");
    const [insertarTipoEquipoModalAbierto, setInsertarTipoEquipoModalAbierto] = useState(false);

  
    const createTipoEquipo = async (event) => {
      event.preventDefault();

      
      axios.post(`http://localhost:5103/api/TipoEquipo`, {
        tipoEId: 0,
        tipoE: tipoEquipo
      })
      .then((response) => {
        //console.log(response);
        alert("El Tipo de Equipo ha sido insertado correctamente")
        setInsertarTipoEquipoModalAbierto(false)
        onClose();
      }, (error) => {
        console.log(error);
        alert("El Tipo de Equipo no se ha insertado correctamente")
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
          
          <FormLabel style={{fontSize: 30, marginTop: 10, marginBottom: 20}}>
            Insertar Tipo de Equipo
          </FormLabel>
      
            <FormControl>
              <FormLabel style = {{marginLeft:38}}>Tipo de Equipo</FormLabel>
              <Input
                value={tipoEquipo}
                placeholder="Ingrese el Tipo de equipo"
                onChange={(a) => setTipoEquipo(a.target.value)}
                marginTop={0.5}
                marginLeft={38}
                width={80}
                backgroundColor= "white"
                marginBottom={30}
              />
            </FormControl>

           <Flex justifyContent="space-between"> 
        <Button 
          variant="outline" 
          colorScheme="blue" 
          style={{ marginRight: 10,  marginTop: 15}}
          onClick={createTipoEquipo}
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

export default InsertarTipoDeEquipo;

