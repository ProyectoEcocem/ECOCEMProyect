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

const InsertarMedicionBascula = () => {
  const [vehiculoId, setVehiculoId] = useState(1);
  const [basculaId, setBasculaId] = useState(1);
  const [fechaId, setFecha] = useState(new Date());
  const [pesoBascula, setPesoBascula] = useState(1);


      //Lista de vehiculos
      const [vehiculos, setVehiculos] = useState([]);
  
      useEffect(() => {
        axios.get(`http://localhost:5103/api/Vehiculo`)
          .then(res => {
            setVehiculos(res.data);
          })
          .catch(err => console.log(err));
      }, []);


      //Lista de basculas
      const [basculas, setBasculas] = useState([]);
  
      useEffect(() => {
        axios.get(`http://localhost:5103/api/Bascula`)
          .then(res => {
            setBasculas(res.data);
          })
          .catch(err => console.log(err));
      }, []);

  
  const createRE = async () => {
    axios.post(`http://localhost:5103/api/MedicionBascula`, {
      vehiculoId: vehiculoId,
      basculaId: basculaId,
      fecha: fechaId,
      pesoB: pesoBascula
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
      height: "500px",
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      backgroundColor: "white",
      flexDirection: "column",
      borderRadius: 20,
      border: "2px solid #5F89C1",
    }}>
     
        <FormLabel style={{fontSize: 30}}>
        Insertar Medicion Bascula:
        </FormLabel>


        <FormLabel style={{margin: "0px 250px 0px 40px"}}>Seleccionar vehiculo:</FormLabel>
  
        <Select
          value={vehiculoId}
          onChange={(e) => setVehiculoId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {vehiculos.map((vehiculo) => (
            <option key={vehiculo.vehiculoId} value={vehiculo.vehiculoId}>
              {vehiculo.noSerie}
            </option>
          ))}
        </Select>

        <FormLabel style={{margin: "0px 250px 0px 40px"}}>Seleccionar bascula:</FormLabel>
          
          <Select
            value={basculaId}
            onChange={(e) => setBasculaId(e.target.value)}
            width={80}
            marginBottom={30}
          >
            {basculas.map((bascula) => (
              <option key={bascula.basculaId} value={bascula.basculaId}>
                {bascula.noSerie}
              </option>
            ))}
          </Select>

        <FormLabel style={{margin: "0px 180px 0px 0px"}}>Fecha de la carga:</FormLabel>

        <Input
          type="datetime-local"
          value={fechaId.toISOString().substring(0,16)}
          onChange={(e) => setFecha(new Date(e.target.value))}
          width={80}
          marginBottom={30}
        
        />

      
         

          <FormLabel style={{margin: "0px 180px 0px 0px"}}>Peso de la bascula:</FormLabel>

          <Input
            value={pesoBascula}
            placeholder="Ingrese el Peso de la bascula"
            onChange={(e) => setPesoBascula(e.target.value)}
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


export default InsertarMedicionBascula;