import React, { useState, useEffect } from "react";
import {
    FormLabel,
    Button,
    Flex,
    Select,
    Input,
    Modal,
    AbsoluteCenter,
    //BackgroundImage
  } from "@chakra-ui/react"; 
import axios from "axios";

const InsertarOrdenTrabajo = ( {onClose}) => {
  const [equipoId, setEquipoId] = useState(1);
  const [brigadaId, setBrigadaId] = useState(1);
  const [trabajadorId, setTrabajadorId] = useState(1);
  const [fecha, setFecha] = useState(new Date());
  const [insertarOrdenTrabajoModalAbierto, setInsertarOrdenTrabajoModalAbierto] = useState(false);

    //Lista de brigadas
    const [brigadas, setBrigadas] = useState([]);
  
    useEffect(() => {
      axios.get(`http://localhost:5103/api/Brigada`)
        .then(res => {
          setBrigadas(res.data);
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

  const [trabajadores, setTrabajadores] = useState([]);

  useEffect(() => {
    axios.get(`http://localhost:5103/api/Trabajador`)
      .then(res => {
        setTrabajadores(res.data);
      })
      .catch(err => console.log(err));
  }, []);


  const createOT = async () => {
    axios.post(`http://localhost:5103/api/OrdenTrabajo`, {
      equipoId: equipoId,
      brigadaId: brigadaId,
      trabajadorId: trabajadorId,
      fechaId: fecha,
    })
    .then((response) => {
      //console.log(response);
      alert("La Orden de Trabajo se ha insertado correctamente.")
      setInsertarOrdenTrabajoModalAbierto(false)
      onClose();
    }, (error) => {
      console.log(error);
      alert("La Orden de Trabajo no se ha insertado.")
    });
 };

 const handleCancelar = () => {
  // Cierra la ventana modal desde el componente padre.
  onClose();
 
};


  return (
    <AbsoluteCenter>
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
   Insertar Orden de Trabajo
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


 <FormLabel style={{margin: "0px 300px 0px 40px"}}>Brigada</FormLabel>
  
 <Select
          value={brigadaId}
          onChange={(e) => setBrigadaId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {brigadas.map((brigada) => (
            <option key={brigada.brigadaId} value={brigada.brigadaId}>
              {brigada.brigadaId}
            </option>
          ))}
        </Select>

        <FormLabel style={{margin: "0px 280px 0px 40px"}}>Trabajador</FormLabel>
        <Select
          value={trabajadorId}
          onChange={(e) => setTrabajadorId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {trabajadores.map((trabajador) => (
            <option key={trabajador.trabajadorId} value={trabajador.trabajadorId}>
              {trabajador.nombreTrabajador}
            </option>
          ))}
        </Select>
      
           
        <FormLabel style={{margin: "0px 270px 0px 0px"}}>Fecha</FormLabel>

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
        onClick={createOT}
        type="submit"
        >
          Aceptar
        </Button>

        <Button variant="outline" colorScheme="red" marginTop={0} onClick={handleCancelar}>
    Cancelar
  </Button>
  </Flex>

      </div>
      </AbsoluteCenter>
  );
};


export default InsertarOrdenTrabajo;