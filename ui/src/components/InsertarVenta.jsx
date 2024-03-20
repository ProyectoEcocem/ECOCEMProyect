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

const InsertarVenta = ({onClose}) => {
  const [sedeId, setSedeId] = useState(1);
  const [entidadCompradoraId, setEntidadCompradoraId] = useState(1);
  const [fechaId, setFecha] = useState(new Date());
  const [insertarVentaModalAbierto, setInsertarVentaModalAbierto] = useState(false);

    //Lista de sedes
    const [sedes, setSedes] = useState([]);
  
    useEffect(() => {
      axios.get(`http://localhost:5103/api/Sede`)
        .then(res => {
          setSedes(res.data);
        })
        .catch(err => console.log(err));
    }, []);

    //Lista de entidadCompradoras
  const [entidadCompradoras, setEntidadCompradoras] = useState([]);
  
  useEffect(() => {
    axios.get(`http://localhost:5103/api/EntidadCompradora`)
      .then(res => {
        setEntidadCompradoras(res.data);
      })
      .catch(err => console.log(err));
  }, []);

  
  const createRE = async () => {
    axios.post(`http://localhost:5103/api/Venta`, {
      sedeId: sedeId,
      entidadCompradoraId: entidadCompradoraId,
      fecha: fechaId
    })
    .then((response) => {
      console.log(response);
      alert("La Venta se ha insertado correctamente.")
      setInsertarVentaModalAbierto(false);
      onClose();
    }, (error) => {
      console.log(error);
      alert("La Venta no se ha insertado correctamente.")
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
        Insertar Venta
        </FormLabel>

        <FormLabel style={{marginLeft: 0, marginRight:270}}>Sede</FormLabel>

        <Select
        value={sedeId}
        onChange={(e) => setSedeId(e.target.value)}
        width={80}
        marginRight={10}
        marginLeft={10}
        marginBottom={30}
        >
        {sedes.map((sede) => (
        <option key={sede.sedeId} value={sede.sedeId}>
        {sede.nombreSede}
        </option>
        ))}
        </Select>


        <FormLabel style={{marginLeft: 2, marginRight:70}}>Seleccionar Entidad Compradora</FormLabel>
  
        <Select
          value={entidadCompradoraId}
          onChange={(e) => setEntidadCompradoraId(e.target.value)}
          width={80}
          marginBottom={30}
        >
          {entidadCompradoras.map((entidadCompradora) => (
            <option key={entidadCompradora.entidadCompradoraId} value={entidadCompradora.entidadCompradoraId}>
              {entidadCompradora.nombreEntidadCompradora}
            </option>
          ))}
        </Select>
      
           
        <FormLabel style={{margin: "0px 180px 0px 0px"}}>Fecha de la compra</FormLabel>

        <Input
          type="datetime-local"
          value={fechaId.toISOString().substring(0,16)}
          onChange={(e) => setFecha(new Date(e.target.value))}
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

        <Button variant="outline" colorScheme="red" marginTop={0} onClick={handleCancelar}>
    Cancelar
  </Button>
  </Flex>
      </div>
  );
};


export default InsertarVenta;