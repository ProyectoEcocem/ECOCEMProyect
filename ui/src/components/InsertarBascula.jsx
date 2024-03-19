import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Select,
  Flex,
} from "@chakra-ui/react";

const InsertarBascula = () => {
  const [numeroBascula, setNumeroBascula] = useState("");
  const [descripcion, setDescripcion] = useState("");
  const [noSede, setSedeId] = useState(1);
  const [insertarBasculaModalAbierto, setInsertarBasculaModalAbierto] = useState(false);
  const [insertSuccess, setInsertSuccess] = useState(false);
  //Lista de sedes
  const [sedes, setSedes] = useState([]);
  
useEffect(() => {
  axios.get(`http://localhost:5103/api/Sede`)
    .then(res => {
      setSedes(res.data);
    })
    .catch(err => console.log(err));
}, []);

  const createBascula = async () => {
  
    axios.post(`http://localhost:5103/api/Bascula`, {
        
        basculaId: 0,
        noSerie: numeroBascula,
        noSede:noSede,
        descripcion:descripcion

    })
    .then((response) => {
      console.log(response);
      alert("La Báscula se ha insertado correctamente")
      setInsertarBasculaModalAbierto(false);
    }, (error) => {
      console.log(error);
      alert("Revise que no exista otra bascula con ese número de serie")
    });
  };

  const handleCancelar = () => {
    // Cierra la ventana modal desde el componente padre.
    onClose();
  };
 
  

  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroBascula]);




  return (
    <div
      style={{
        width: "400px",
        height: "500px",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "white",
        flexDirection: "column",
        borderRadius: 20,
        border: "2px solid #5F89C1",
      }}
    >
      <FormLabel style={{ fontSize: 30 }}>Insertar Bascula</FormLabel>

     
        <FormLabel style={{ marginLeft: 0, marginRight: 100 }}>
          Número de Serie de Bascula
        </FormLabel>
        <Input
          value={numeroBascula}
          placeholder="Ingrese el Número de Serie de la Bascula"
          onChange={(e) => setNumeroBascula(e.target.value)}
          marginTop={0.5}
          width={80}
          backgroundColor="white"
        />
       
      
        <FormLabel style={{ marginTop: 20, marginRight: 230 }}>
        Descripción
        </FormLabel>  
        <Input
          value={descripcion}
          placeholder="Descripción"
          onChange={(e) => setDescripcion(e.target.value)}
          marginTop={0.5}
          width={80}
          backgroundColor="white"
        />
         <FormLabel style={{ marginTop:20, marginRight: 130 }}>
        Sede a la que pertenece
      </FormLabel>

        <Select
          value={noSede}
          onChange={(e) => setSedeId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {sedes.map((sede) => (
            <option key={sede.sedeId} value={sede.sedeId}>
              {sede.nombreSede}
              
            </option>
          ))}
        </Select>

      

        <Flex justifyContent="space-between">    
        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10, marginTop: 20 }}
          onClick={createBascula}
          type="submit"
          >
          {insertSuccess && (
            <div style={{ marginTop: 20 }}>
              <Alert status="success">La empresa se creó correctamente.</Alert>
            </div>
          )}
          Aceptar
        </Button>

        <Button variant="outline" colorScheme="red" marginTop={5} onClick={handleCancelar}>
    Cancelar
  </Button>
        </Flex>

    </div>
  );
};

export default InsertarBascula;
