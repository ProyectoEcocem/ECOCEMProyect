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

const InsertarRoturaEquipo = () => {
  const [equipoId, setEquipoId] = useState(0);
  const [roturaId, setRoturaId] = useState(0);
  const [fecha, setFecha] = useState("");

    //Lista de roturas
    const [roturas, setRoturas] = useState([]);
  
    useEffect(() => {
      axios.get(`http://localhost:5103/api/Rotura`)
        .then(res => {
          setRoturas(res.data);
        })
        .catch(err => console.log(err));
    }, []);

//Lista de equipos
  const [equipos, setEquipos] = useState([]);
  
  useEffect(() => {
    axios.get(`http://localhost:5103/api/Equipo`)
      .then(res => {
        setEquipos(res.data);
      })
      .catch(err => console.log(err));
  }, []);

  const createRE = async () => {
    axios.post(`http://localhost:5103/api/RoturaEquipo`, {
      equipoId: equipoId,
      roturaId: roturaId,
      fecha: fecha
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
  Insertar Rotura de Equipo
</FormLabel>

<FormLabel style={{margin: "0px 260px 0px 0px"}}>Equipo</FormLabel>

<Select
value={equipoId}
onChange={(e) => setEquipoId(e.target.value)}
width={80}
marginBottom={30}
>
{equipos.map((equipo) => (
<option key={equipo.equipoId} value={equipo.equipoId}>
  {equipo.equipoId}
</option>
))}
</Select>


<FormLabel style={{margin: "0px 250px 0px 40px"}}>Tipo de Rotura</FormLabel>
  
<Select
          value={roturaId}
          onChange={(e) => setRoturaId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {roturas.map((rotura) => (
            <option key={rotura.roturaId} value={rotura.roturaId}>
              {rotura.nombreRotura}
            </option>
          ))}
        </Select>
      
           
        <FormLabel style={{margin: "0px 180px 0px 0px"}}>Fecha de la Rotura</FormLabel>

        <Input
          type="datetime-local"
          value={fecha}
          onChange={(e) => setFecha(e.target.value)}
          width={80}
          marginBottom={30}
         
        />

        <Flex>
        <Button 
        variant="contained" 
        color="primary" 
        style={{ marginRight: 10 }}
        onClick={createRE}
        type="submit"
        >
          Aceptar
        </Button>
        </Flex>
      </div>
  );
};


export default InsertarRoturaEquipo;