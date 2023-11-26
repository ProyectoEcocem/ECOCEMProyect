import { useState } from "react";
import {
    DatePicker,
    FormLabel,
    Button,
    Flex,
    Select,
    //BackgroundImage
  } from "@chakra-ui/react"; 

const InsertarRoturaEquipo = () => {
  const [roturaId, setRoturaId] = useState("");
  const [equipoId, setEquipoId] = useState("");
  const [fecha, setFecha] = useState("");

  //solo para testear, aquí irían las roturas registradas en BD
  const roturas = [
    { id: 1, nombre: "Tipo de Rotura 1" },
    { id: 2, nombre: "Tipo de Rotura 2" },
    { id: 3, nombre: "Tipo de Rotura 3" },
  ]
  
  //solo para testear, aquí irían los equipos registrados en BD
  const equipos = [
    { id: 1},
    { id: 2},
    { id: 3},
  ]

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
      <img
        src="/public/ecocemlogo.png"
        alt="Logo"
        width={80}
        height={80}
      />
<FormLabel style={{fontSize: 30}}>
  Insertar Rotura de Equipo
</FormLabel>

<FormLabel style={{margin: "0px 220px 0px 40px"}}>Tipo de Rotura</FormLabel>
  
<Select
          value={roturaId}
          onChange={(e) => setRoturaId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {roturas.map((rotura) => (
            <option key={rotura.id} value={rotura.id}>
              {rotura.nombre}
            </option>
          ))}
        </Select>
      
            <FormLabel style={{margin: "20px 210px 0px 0px"}}>Equipo</FormLabel>

            <Select
          value={equipoId}
          onChange={(e) => setEquipoId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {equipos.map((equipo) => (
            <option key={equipo.id} value={equipo.id}>
              {equipo.id}
            </option>
          ))}
        </Select>

        <FormLabel style={{margin: "20px 210px 0px 0px"}}>Fecha de la Rotura</FormLabel>

        <DatePicker
          defaultValue={fecha}
          onChange={(date) => setFecha(date)}
        />

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

// ToDo: Arreglar fecha

export default InsertarRoturaEquipo;