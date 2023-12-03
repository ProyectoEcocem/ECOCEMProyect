import { useState } from "react";
import axios from "axios";
import {
    FormControl,
    FormLabel,
    Input,
    Button,
    Flex,
    Select,
    //BackgroundImage
  } from "@chakra-ui/react"; 

const InsertarEquipo = () => {
  const [equipoId, setEquipoId] = useState("");
  const [tipoEquipo, setTipoEquipo] = useState("");
  const [sede, setSede] = useState("");

  /*const createEmpresa = async () => {
    const empresa = {
      numeroEmpresa: numeroEmpresa,
      nombreEmpresa: nombreEmpresa
    };
  
    axios.post(`http://localhost:5103/api/Empresa`, {
      numeroEmpresa: numeroEmpresa,
      nombreEmpresa: nombreEmpresa
    })
    .then((response) => {
      console.log(response);
    }, (error) => {
      console.log(error);
    });
  };*/


  //solo para testear, aquí irían los tipos de equipo en BD
  const tiposEquipos = [
    { id: 1, nombre: "Tipo de Equipo 1" },
    { id: 2, nombre: "Tipo de Equipo 2" },
    { id: 3, nombre: "Tipo de Equipo 3" },
  ]
  
  //solo para testear, aquí irían las sedes en BD
  const sedes = [
    { id: 1, nombre: "Sede 1" },
    { id: 2, nombre: "Sede 2" },
    { id: 3, nombre: "Sede 3" },
  ]

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
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormLabel style={{margin: "20px 210px 0px 0px"}}>Tipo de Equipo</FormLabel>

            <Select
          value={tipoEquipo}
          onChange={(e) => setTipoEquipo(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {tiposEquipos.map((tipoEquipo) => (
            <option key={tipoEquipo.id} value={tipoEquipo.id}>
              {tipoEquipo.nombre}
            </option>
          ))}
        </Select>

            <FormLabel style={{margin: "0px 140px 0px 0px"}}>Sede a la que pertenece</FormLabel>

            <Select
          value={sede}
          onChange={(e) => setSede(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {sedes.map((sede) => (
            <option key={sede.id} value={sede.id}>
              {sede.nombre}
            </option>
          ))}
        </Select>
           
        <Flex>
        <Button variant="contained" color="primary" style={{ marginRight: 10 }}>
          Aceptar
        </Button>
        <Button variant="contained" color="secondary">
          Cancelar
        </Button>
        </Flex>
      </div>
  );
};

// ToDo: Enlazar de forma que se muestren enlas listas desplegables los datos de sede y tipo de equipo que haya en la BD

// ToDo: Evento de los botones

// ToDO: Verificar que el Id sea valido

export default InsertarEquipo;