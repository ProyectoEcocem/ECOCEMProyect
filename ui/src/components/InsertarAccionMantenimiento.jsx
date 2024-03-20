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

const InsertarAccionMantenimiento = ({onClose}) => {
  const [equipoId, setEquipoId] = useState(0);
  const [brigadaId, setBrigadaId] = useState(0);
  const [trabajadorId, setTrabajadorId] = useState(0);
  const [fecha, setFecha] = useState(new Date());
  const [insertarAccionMantenimientoEModalAbierto, setInsertarAccionMantenimientoEModalAbierto] = useState(false);

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

   //Lista de trabajadores
   const [trabajadores, setTrabajadores] = useState([]);
  
   useEffect(() => {
     axios.get(`http://localhost:5103/api/Trabajador`)
       .then(res => {
         setTrabajadores(res.data);
       })
       .catch(err => console.log(err));
   }, []);

  const createAccionMantenimiento = async () => {
    axios.post(`http://localhost:5103/api/AccionMantenimiento`, {
      equipoId: equipoId,
      brigadaId: brigadaId,
      trabajadorId: trabajadorId,
      fecha: fecha
    })
    .then((response) => {
      //console.log(response);
      alert("La Acción de Mantenimiento se ha insertado correctamente.")
      setInsertarAccionMantenimientoEModalAbierto(false);
    }, (error) => {
      console.log(error);
      alert("La Acción de Mantenimiento no se ha insertado.")
    });
 };

 const handleCancelar = () => {
  // Cierra la ventana modal desde el componente padre.
  onClose();
 
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
   Insertar Accion de Mtto
 </FormLabel>

 <FormLabel style={{marginBottom: 0, marginLeft:0, marginRight: 250}}>Equipo</FormLabel>

 <Select
 value={equipoId}
 onChange={(e) => setEquipoId(e.target.value)}
 width={80}
 marginBottom={5}
 >
 {equipos.map((equipo) => (
 <option key={equipo.equipoId} value={equipo.equipoId}>
  {equipo.equipoId}
 </option>
 ))}
 </Select>


 <FormLabel style={{marginBottom: 0, marginLeft:0, marginRight: 250}}>Brigada</FormLabel>
  
 <Select
          value={brigadaId}
          onChange={(e) => setBrigadaId(e.target.value)}
          width={80}
          marginBottom={5}
        >
          {brigadas.map((brigada) => (
            <option key={brigada.brigadaId} value={brigada.brigadaId}>
              {brigada.brigadaId}
            </option>
          ))}
        </Select>

        <FormLabel style={{marginBottom: 0, marginLeft:0, marginRight: 250}}>Trabajador</FormLabel>
  
 <Select
          value={trabajadorId}
          onChange={(e) => setTrabajadorId(e.target.value)}
          width={80}
          marginBottom={5}
        >
          {trabajadores.map((trabajador) => (
            <option key={trabajador.trabajadorId} value={trabajador.trabajadorId}>
              {trabajador.trabajadorId}
            </option>
          ))}
        </Select>
      
           
        <FormLabel style={{marginBottom: 0, marginLeft:0, marginRight: 250}}>Fecha</FormLabel>

        <Input
          type="datetime-local"
          value={fecha.toISOString().substring(0,16)}
          onChange={(e) => setFecha(new Date(e.target.value))}
          width={80}
          marginBottom={10}
         
        />

<Flex justifyContent="space-between">
        <Button 
       variant="outline"
       colorScheme="blue"
        style={{ marginRight: 10 }}
        onClick={createAccionMantenimiento}
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


export default InsertarAccionMantenimiento;