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

const InsertarVenta = () => {
  const [sedeId, setSedeId] = useState(1);
  const [entidadCompradoraId, setEntidadCompradoraId] = useState(1);
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

    //Lista de entidadCompradoras
  const [entidadCompradoras, setEntidadCompradoras] = useState([]);
  
  useEffect(() => {
    axios.get(`http://localhost:5103/api/EntidadCompradora`)
      .then(res => {
        setEntidadCompradoras(res.data);
      })
      .catch(err => console.log(err));
  }, []);

  
  const createRE = async () => {
    axios.post(`http://localhost:5103/api/Venta`, {
      sedeId: sedeId,
      entidadCompradoraId: entidadCompradoraId,
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
        Insertar Venta
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


        <FormLabel style={{margin: "0px 250px 0px 40px"}}>Seleccionar entidadCompradora</FormLabel>
  
        <Select
          value={entidadCompradoraId}
          onChange={(e) => setEntidadCompradoraId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {entidadCompradoras.map((entidadCompradora) => (
            <option key={entidadCompradora.entidadCompradoraId} value={entidadCompradora.entidadCompradoraId}>
              {entidadCompradora.nombreEntidadCompradora}
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


export default InsertarVenta;