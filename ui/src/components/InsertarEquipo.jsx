import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    FormControl,
    FormLabel,
    Input,
    Button,
    Flex,
    Select,
    Modal,
    //BackgroundImage
  } from "@chakra-ui/react"; 

const InsertarEquipo = ({onClose}) => {
  const [equipoId, setEquipoId] = useState(0);
  const [tipoEId, setTipoEId] = useState(0);
  const [sedeId, setSedeId] = useState(0);
  const [insertarEquipoModalAbierto, setInsertarEquipoModalAbierto] = useState(false);

  //Lista de tipos de equipos
    const [tiposEquipos, setTiposEquipos] = useState([]);
  
    useEffect(() => {
      axios.get(`http://localhost:5103/api/TipoEquipo`)
        .then(res => {
          setTiposEquipos(res.data);
        })
        .catch(err => console.log(err));
    }, []);

//Lista de sedes
  const [sedes, setSedes] = useState([]);
  
  useEffect(() => {
    axios.get(`http://localhost:5103/api/Sede`)
      .then(res => {
        setSedes(res.data);
      })
      .catch(err => console.log(err));
  }, []);


  const createEquipo = async () => {

    axios.post(`http://localhost:5103/api/Equipo`, {
      equipoId: equipoId,
      tipoEId: tipoEId,
      sedeId: sedeId
    })
    .then((response) => {
      console.log(response);
      alert("El Equipo ha sido insertado correctamente.")
      setInsertarEquipoModalAbierto(false);
    }, (error) => {
      console.log(error);
      alert("El Equipo no se ha insertado.")
    });
  };

  const handleCancelar = () => {
    // Cierra la ventana modal desde el componente padre.
    onClose();
  };

  return (
    <div style={{
      width: "400px",
      height: "400px",
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      backgroundColor: "white",
      flexDirection: "column",
      borderRadius: 20,
      border: "2px solid #5F89C1",
    }}>
     
<FormLabel style={{fontSize: 30}}>
  Insertar Equipo
</FormLabel>

  <FormControl>
              <FormLabel style={{margin: "0px 20px 0px 40px"}}>Número de Serie del Equipo</FormLabel>
              <Input
                value={equipoId}
                placeholder="Ingrese el Número de serie del equipo"
                onChange={(e) => setEquipoId(e.target.value)}
                marginTop={0.5}
                marginLeft={9}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormLabel style={{margin: "20px 210px 0px 0px"}}>Tipo de Equipo</FormLabel>

          <Select
          value={tipoEId}
          onChange={(e) => setTipoEId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {tiposEquipos.map((tipoEquipo) => (
            <option key={tipoEquipo.tipoEId} value={tipoEquipo.tipoEId}>
              {tipoEquipo.tipoE}
            </option>
          ))}
        </Select>

            <FormLabel style={{margin: "0px 140px 0px 0px"}}>Sede a la que pertenece</FormLabel>

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
           
        <Flex>
        <Button 
        variant="outline"
        colorScheme="blue" 
        style={{ marginRight: 10 }}
        onClick={createEquipo}
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

export default InsertarEquipo;