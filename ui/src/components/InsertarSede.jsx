import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    FormControl,
    FormLabel,
    Input,
    Button,
    Flex,
    Modal,
    Select,
    //BackgroundImage
  } from "@chakra-ui/react"; 
//import { sedeController } from "../../../Controllers/Entidades"

const InsertarSede = ({onClose}) => {
  const [numeroSede, setNumeroSede] = useState(0);
  const [nombreSede, setNombreSede] = useState("");
  const [ubicacionSede, setUbicacion] = useState("");
  const [empresaId, setEmpresaId] = useState(1);
  const [insertSuccess, setInsertSuccess] = useState(false);
  const [insertarSedeModalAbierto, setInsertarSedeModalAbierto] = useState(false);
  const [empresas, setEmpresas] = useState([]);

  useEffect(() => {
    axios.get(`http://localhost:5103/api/Empresa`)
      .then(res => {
        setEmpresas(res.data);
      })
      .catch(err => console.log(err));
  }, []);


  const EnviarForm = async () => {
    const sede = {
      numeroSede: numeroSede,
      nombreSede: nombreSede,
      ubicacionSede: ubicacionSede,
      empresaId: empresaId
    };
    axios.post(`http://localhost:5103/api/Sede`, {
      numeroSede: numeroSede,
      nombreSede: nombreSede,
      ubicacionSede: ubicacionSede,
      empresaId: empresaId
    })
    .then((response) => {
      //console.log(response);
      alert("La sede ha sido insertada correctamente")
      setInsertarSedeModalAbierto(false); // Cierra el modal
    }, (error) => {
      console.log(error);
      alert(console.log(error))
      alert("La sede no se ha insertado.")
    });

    useEffect(() => {
      
  }, []); // El array vacío significa que este efecto se ejecuta solo una vez al montar el componente

  };


   useEffect(() => {
     setInsertSuccess(false);
   }, [numeroSede,nombreSede,ubicacionSede,empresaId]);
 

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
  Insertar Sede
</FormLabel>

 
      
            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Nombre de la Sede</FormLabel>
              <Input
                value={nombreSede}
                placeholder="Ingrese el nombre de la Sede"
                onChange={(e) => setNombreSede(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>

            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Ubicación</FormLabel>
              <Input
                value={ubicacionSede}
                placeholder="Ingrese la ubicación"
                onChange={(e) => setUbicacion(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
                marginBottom={1}
              />
            </FormControl>

              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>ID de la Empresa</FormLabel>
              <Select
          value={empresaId}
          onChange={(e) => setEmpresaId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {empresas.map((empresa) => (
            <option key={empresa.empresaId} value={empresa.empresaId}>
              {empresa.nombreEmpresa}
            </option>
          ))}
        </Select>
            
        <Flex justifyContent="space-between">
        <Button 
          variant="outline"
          colorScheme="blue" 
          style={{ marginRight: 10 }}
          onClick = {EnviarForm}
          type="submit"
          mt="4"
          >
          {insertSuccess && (
            <div style={{ marginTop: 5 }}>
              <Alert status="success">La sede se creó correctamente.</Alert>
            </div>
          )}
          Aceptar
        </Button>
        <Button variant="outline" colorScheme="red" marginTop={4} onClick={handleCancelar}>
    Cancelar
  </Button>
        </Flex>
        
    
      </div>
  );
};

export default InsertarSede;

// TODO:   Verificar que la ventana desaparezca al hacer click en aceptar
// TODO: Cambiar para que Empresa sea un seleccionable, no un input