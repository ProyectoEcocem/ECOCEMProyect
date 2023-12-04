import { useState } from "react";
import {
    FormControl,
    FormLabel,
    Input,
    Button,
    Flex,
    Select,
    //BackgroundImage
  } from "@chakra-ui/react"; 

const InsertarTrabajador = () => {
  const [trabajadorId, setTrabajadorId] = useState("");
  const [nombre, setNombre] = useState("");
  const [sede, setSede] = useState("");

  //solo para testear, aquí irían las sedes en BD
  const sedes = [
    { id: 1, nombre: "Sede 1" },
    { id: 2, nombre: "Sede 2" },
    { id: 3, nombre: "Sede 3" },
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
  Insertar Trabajador
</FormLabel>

  <FormControl>
              <FormLabel style={{margin: "5px 20px 0px 40px"}}>ID del Trabajador</FormLabel>
              <Input
                value={trabajadorId}
                placeholder="Ingrese el ID del trabajador"
                onChange={(e) => setTrabajadorId(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
    
            <FormControl>
              <FormLabel style={{margin: "30px 20px 0px 40px"}}>Nombre</FormLabel>
              <Input
                value={nombre}
                placeholder="Ingrese el nombre del trabajador"
                onChange={(e) => setNombre(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
            

            <FormLabel style={{margin: "30px 140px 0px 0px"}}>Sede a la que pertenece</FormLabel>

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

// ToDo: Enlazar de forma que se muestren enlas listas desplegables los datos de sede que haya en la BD

// ToDo: Evento de los botones

// ToDO: Verificar que el Id sea valido

export default InsertarTrabajador;