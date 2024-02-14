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

const InsertarMedicionSilo = () => {
  const [siloId, setSiloId] = useState(1);
  const [medidorId, setMedidorId] = useState(1);
  const [fechaId, setFecha] = useState(new Date());
  const [nivel, setNivel] = useState(1);
  const [pesoMedidor, setPesoMedidor] = useState(1);
  const [volumen, setVolumen] = useState(1);


    //Lista de silos
  const [silos, setSilos] = useState([]);
  
  useEffect(() => {
    axios.get(`http://localhost:5103/api/Silo`)
      .then(res => {
        setSilos(res.data);
      })
      .catch(err => console.log(err));
  }, []);

      //Lista de medidores
      const [medidores, setMedidores] = useState([]);

      useEffect(() => {
        axios.get(`http://localhost:5103/api/Medidor`)
          .then(res => {
            setMedidores(res.data);
          })
          .catch(err => console.log(err));
      }, []);


  const createRE = async () => {
    axios.post(`http://localhost:5103/api/MedicionSilo`, {
      siloId: siloId,
      medidorId: medidorId,
      fecha: fechaId,
      nivel: nivel,
      pesoM: pesoMedidor,
      volumen: volumen,
    })
    .then((response) => {
      console.log(response);
      alert("Se insertó correctamente")
    }, (error) => {
      console.log(error);
      alert("Revise los datos insertados")
    });
 };



  return (
    <div style={{
      width: "400px",
      height: "600px",
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      backgroundColor: "white",
      flexDirection: "column",
      borderRadius: 20,
      border: "2px solid #5F89C1",
    }}>
     
        <FormLabel style={{fontSize: 30}}>
        Insertar Medicion Silo:
        </FormLabel>


        <FormLabel style={{margin: "0px 250px 0px 40px"}}>Seleccionar silo:</FormLabel>
  
        <Select
          value={siloId}
          onChange={(e) => setSiloId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {silos.map((silo) => (
            <option key={silo.siloId} value={silo.siloId}>
              {silo.nombre}
            </option>
          ))}
        </Select>

        <FormLabel style={{margin: "0px 250px 0px 40px"}}>Seleccionar medidor:</FormLabel>
          
          <Select
            value={medidorId}
            onChange={(e) => setMedidorId(e.target.value)}
            width={80}
            marginBottom={30}
          >
            {medidores.map((medidor) => (
              <option key={medidor.medidorId} value={medidor.medidorId}>
                {medidor.noSerie}
              </option>
            ))}
          </Select>


        <FormLabel style={{margin: "0px 180px 0px 0px"}}>Fecha:</FormLabel>

        <Input
          type="datetime-local"
          value={fechaId.toISOString().substring(0,16)}
          onChange={(e) => setFecha(new Date(e.target.value))}
          width={80}
          marginBottom={30}
        
        />


          <FormLabel style={{margin: "0px 180px 0px 0px"}}>Nivel:</FormLabel>

          <Input
            value={nivel}
            placeholder="Ingrese el Nivel"
            onChange={(e) => setNivel(e.target.value)}
            marginTop={0.5}
            width={80}
            backgroundColor="white"

          />

          <FormLabel style={{margin: "0px 180px 0px 0px"}}>Peso del medidor:</FormLabel>

          <Input
            value={pesoMedidor}
            placeholder="Ingrese el Peso del medidor"
            onChange={(e) => setPesoMedidor(e.target.value)}
            marginTop={0.5}
            width={80}
            backgroundColor="white"

          />

          <FormLabel style={{margin: "0px 180px 0px 0px"}}>Volumen:</FormLabel>

          <Input
            value={volumen}
            placeholder="Ingrese el volumen"
            onChange={(e) => setVolumen(e.target.value)}
            marginTop={0.5}
            width={80}
            backgroundColor="white"

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


export default InsertarMedicionSilo;