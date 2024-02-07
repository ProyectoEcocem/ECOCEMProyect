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

const InsertarSilo = () => {
  const [numeroSilo, setNumeroSilo] = useState("");
  const [radio, setRadio] = useState(1);
  const [noSede, setSedeId] = useState(1);
  const [altura, setAltura] = useState(1);
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
  const createSilo = async () => {
  
    axios.post(`http://localhost:5103/api/Silo`, {
        siloId: 0,
        noSilo: numeroSilo,
        noSede:noSede,
        radio:radio,
        altura:altura,
    })
    .then((response) => {
      console.log(response);
      alert("Se insertó correctamente")
    }, (error) => {
      console.log(error);
      alert("no se ha insertado, comprueba los datos de entrada")
    });
  };
 
  

  useEffect(() => {
    setInsertSuccess(false);
  }, [numeroSilo]);

  return (
    <div
      style={{
        width: "400px",
        height: "400px",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "white",
        flexDirection: "column",
        borderRadius: 20,
        border: "2px solid #5F89C1",
      }}
    >
      <FormLabel style={{ fontSize: 30 }}>Insertar Silo</FormLabel>

     <FormControl>
        <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          Nombre de Silo
        </FormLabel>
        <Input
          value={numeroSilo}
          placeholder="Ingrese el Nombre de la Silo"
          onChange={(e) => setNumeroSilo(e.target.value)}
          marginTop={0.5}
          width={80}
          backgroundColor="white"
        />
        <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          altura
        </FormLabel>
        <Input
          value={altura}
          placeholder="Ingrese la altura"
          onChange={(e) => setAltura(e.target.value)}
          marginTop={0.5}
          width={80}
          backgroundColor="white"
        />
        <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          radio
        </FormLabel>
        <Input
          value={radio}
          placeholder="Ingrese el radio"
          onChange={(e) => setRadio(e.target.value)}
          marginTop={0.5}
          width={80}
          backgroundColor="white"
        />
     
      <FormLabel style={{ margin: "0px 20px 0px 40px" }}>
          Seleccione la sede
        </FormLabel>
        </FormControl>
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
        
        <Flex>    
        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10, marginTop: 20 }}
          onClick={createSilo}
          type="submit"
          >
          {insertSuccess && (
            <div style={{ marginTop: 20 }}>
              <Alert status="success">La  se creó correctamente.</Alert>
            </div>
          )}
          Aceptar
        </Button>
        </Flex>

    </div>
  );
};

export default InsertarSilo;
