import React, { useState } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react"; 

const InsertarTipoDeEquipo = () => {
    const [tipoEquipoId, setTipoEquipoId] = useState(8);
    const [tipoEquipo, setTipoEquipo] = useState("te");

  
    const createTipoEquipo = async (event) => {
      event.preventDefault();

      const tipoEquipoData = {
        tipoEquipoId: parseInt(tipoEquipoId),
        tipoEquipo: tipoEquipo,
      };
      
      axios.post(`http://localhost:5103/api/TipoEquipo`, {
        tipoEId: tipoEquipoId,
        tipoE: tipoEquipo
      })
      .then((response) => {
        console.log(response);
        alert("ok")
      }, (error) => {
        console.log(error);
        alert("no ok")
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
                onChange={(a) => setTipoEquipo(a.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
                marginBottom={30}
              />
            </FormControl>
            
        <Button 
          variant="contained" 
          color="primary" 
          style={{ marginRight: 10 }}
          onClick={createTipoEquipo}
          type="submit"
          >
          Aceptar
        </Button>
      
      </div>
  );
};

export default InsertarTipoDeEquipo;

