import { useState, useEffect } from "react";
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

const InsertarTrabajador = ({onClose}) => {
  const [trabajadorId, setTrabajadorId] = useState("");
  const [nombre, setNombre] = useState("");
  const [sede, setSede] = useState("");
  const [insertarTrabajadorModalAbierto, setInsertarTrabajadorModalAbierto] = useState(false);

  const [sedes, setSedes] = useState([]);
  
  useEffect(() => {
    axios.get(`http://localhost:5103/api/Sede`)
      .then(res => {
        setSedes(res.data);
      })
      .catch(err => console.log(err));
  }, []);

  const createTrabajador = async () => {

    axios.post(`http://localhost:5103/api/Trabajador`, {
      trabajadorId: trabajadorId,
      nombre: nombre,
      sedeId: sedeId
    })
    .then((response) => {
      console.log(response);
      alert("El Trabajador ha sido insertado correctamente.")
      setInsertarTrabajadorModalAbierto(false);
    }, (error) => {
      console.log(error);
      alert("El Trabajador no se ha insertado.")
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
                marginLeft={8}
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
                marginLeft={8}
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
              {sede.nombreSede}
            </option>
          ))}
        </Select>
           
        <Flex>
        <Button 
        variant="outline"
        colorScheme="blue" 
        style={{ marginRight: 10 }}
        onClick={createTrabajador}
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

// ToDo: Enlazar de forma que se muestren enlas listas desplegables los datos de sede que haya en la BD

// ToDo: Evento de los botones

// ToDO: Verificar que el Id sea valido

export default InsertarTrabajador;