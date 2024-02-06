import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
} from "@chakra-ui/react";

const InsertarSilo = () => {
  const [numeroSilo, setNumeroSilo] = useState("");
  const [numeroEquipo, setnumeroEquipo] = useState("");
  const [insertSuccess, setInsertSuccess] = useState(false);

  const createSilo = async () => {
  
    axios.post(`http://localhost:5103/api/Silo`, {
        SiloId: 0,
        NoSilo: numeroSilo,
        EquipoId: numeroEquipo
    })
    .then((response) => {
      console.log(response);
      alert("Se inserto")
    }, (error) => {
      console.log(error);
      alert("no")
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
      </FormControl>

      <Select
          value={numeroEquipo}
          onChange={(e) => setnumeroEquipo(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {tiposEquipos.map((tipoEquipo) => (
            <option key={tipoEquipo.tipoEId} value={tipoEquipo.tipoEId}>
              {tipoEquipo.tipoE}
            </option>
          ))}
        </Select>

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
      

    </div>
  );
};

export default InsertarSilo;
