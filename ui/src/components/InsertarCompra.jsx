import React, { useState, useEffect } from "react";
import {
    FormLabel,
    Button,
    Flex,
    Select,
    Input,
    //BackgroundImage
  } from "@chakra-ui/react"; 
import axios from "axios";

const InsertarCompra = () => {
  const [sedeId, setSedeId] = useState(1);
  const [fabricaId, setFabricaId] = useState(1);
  const [fechaId, setFecha] = useState(new Date());

    //Lista de sedes
    const [sedes, setSedes] = useState([]);
  
    useEffect(() => {
      axios.get(`http://localhost:5103/api/Sede`)
        .then(res => {
          setSedes(res.data);
        })
        .catch(err => console.log(err));
    }, []);

    //Lista de fabricas
  const [fabricas, setFabricas] = useState([]);
  
  useEffect(() => {
    axios.get(`http://localhost:5103/api/Fabrica`)
      .then(res => {
        setFabricas(res.data);
      })
      .catch(err => console.log(err));
  }, []);

  
  const createRE = async () => {
    axios.post(`http://localhost:5103/api/Compra`, {
      sedeId: sedeId,
      fabricaId: fabricaId,
      fecha: fechaId
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
      height: "430px",
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      backgroundColor: "white",
      flexDirection: "column",
      borderRadius: 20,
      border: "2px solid #5F89C1",
    }}>
     
        <FormLabel style={{fontSize: 30}}>
        Insertar Compra
        </FormLabel>

        <FormLabel style={{margin: "0px 260px 0px 0px"}}>Sede</FormLabel>

        <Select
        value={sedeId}
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


        <FormLabel style={{margin: "0px 250px 0px 40px"}}>Seleccionar fabrica</FormLabel>
  
        <Select
          value={fabricaId}
          onChange={(e) => setFabricaId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {fabricas.map((fabrica) => (
            <option key={fabrica.fabricaId} value={fabrica.fabricaId}>
              {fabrica.nombre}
            </option>
          ))}
        </Select>
      
           
        <FormLabel style={{margin: "0px 180px 0px 0px"}}>Fecha de la compra</FormLabel>

        <Input
          type="datetime-local"
          value={fechaId.toISOString().substring(0,16)}
          onChange={(e) => setFecha(new Date(e.target.value))}
          width={80}
          marginBottom={30}
         
        />

        <Button 
        variant="contained" 
        color="primary" 
        style={{ marginRight: 10 }}
        onClick={createRE}
        type="submit"
        >
          Aceptar
        </Button>
      </div>
  );
};


export default InsertarCompra;