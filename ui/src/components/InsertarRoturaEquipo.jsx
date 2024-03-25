import React, { useState, useEffect } from "react";
import {
    FormLabel,
    Button,
    Flex,
    Select,
    Input,
    Modal,
    //BackgroundImage
  } from "@chakra-ui/react"; 
import axios from "axios";

const InsertarRoturaEquipo = ({onClose}) => {
  const [equipoId, setEquipoId] = useState("");
  const [roturaId, setRoturaId] = useState(1);
  const [fecha, setFecha] = useState(new Date());
  const [insertarRoturaEModalAbierto, setInsertarRoturaEModalAbierto] = useState(false);

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
      fechaId: fecha
    })
    .then((response) => {
      //console.log(response);
      alert("La Rotura de Equipo se ha insertado correctamente.")
      setInsertarRoturaEModalAbierto(false);
      onClose();
    }, (error) => {
      console.log(error);
      alert("La Rotura de Equipo no se ha insertado.")
    });
 };

 const handleCancelar = () => {
  // Cierra la ventana modal desde el componente padre.
  onClose();
 
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
          value={fecha.toISOString().substring(0,16)}
          onChange={(e) => setFecha(new Date(e.target.value))}
          width={80}
          marginBottom={30}
         
        />
       
<Flex justifyContent="space-between">
        <Button 
       variant="outline"
       colorScheme="blue"
        style={{ marginRight: 10 }}
        onClick={createRE}
        type="submit"
        >
          Aceptar
        </Button>

        <Button variant="outline" colorScheme="red" marginTop={0} onClick={handleCancelar}>
    Cancelar
  </Button>
  </Flex>

      </div>
  );
};


export default InsertarRoturaEquipo;