import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react"; 

const InsertarTipoDeEquipo = () => {
    const [tipoEquipoId, setTipoEquipoId] = useState("");
    const [tipoEquipo, setTipoEquipo] = useState("");
    const [insertSuccess, setInsertSuccess] = useState(false);
  
    const createTipoEquipo = async () => {
      const tipoE = {
        tipoEquipoId: tipoEquipoId,
        tipoEquipo: tipoEquipo
      };
      
      axios.post(`http://localhost:5103/api/TipoEquipo`, {
        tipoEquipoId: tipoEquipoId,
        tipoEquipo: tipoEquipo
      })
      .then((response) => {
        console.log(response);
        alert("ok")
      }, (error) => {
        console.log(error);
        alert("no ok")
      });
    };

    useEffect(() => {
      setInsertSuccess(false);
    }, [tipoEquipoId,tipoEquipo]);
  

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
  Insertar Tipo de Equipo
</FormLabel>
          <FormControl>
              <FormLabel style={{margin: "20px 20px 0px 40px"}}>ID del Tipo de Equipo</FormLabel>
              <Input
                value={tipoEquipoId}
                placeholder="Ingrese el Id del Tipo de Equipo"
                onChange={(e) => setTipoEquipoId(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Tipo de Equipo</FormLabel>
              <Input
                value={tipoEquipo}
                placeholder="Ingrese el Tipo de equipo"
                onChange={(e) => setTipoEquipo(e.target.value)}
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
          onClick={createTipoEquipo}
          type="submit"
          >
          Aceptar
        </Button>
        <Button variant="contained" color="secondary">
          Cancelar
        </Button>
        </Flex>
      </div>
  );
};

export default InsertarTipoDeEquipo;

// ToDO: Verificar si lo que se inserta es válido.
// ToDO: agregar evento con los botones.