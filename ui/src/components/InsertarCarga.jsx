import React, { useState, useEffect } from "react";
import {
    FormLabel,
    Button,
    Flex,
    Select,
    Input,
    AbsoluteCenter,
    //BackgroundImage
  } from "@chakra-ui/react"; 
import axios from "axios";
import Venta from "./VizualizarVenta";

const InsertarCarga = ({sedeId, entidadCompradoraId, fechaVentaId, onClose}) => {
  const [tipoCementoId, setTipoCementoId] = useState(1);
  const [siloId, setSiloId] = useState(1);
  const [vehiculoId, setVehiculoId] = useState(1);
  const [medidorId, setMedidorId] = useState(1);
  const [basculaId, setBasculaId] = useState(1);
  const [nivel, setNivel] = useState(1);
  const [pesoMedidor, setPesoMedidor] = useState(1);
  const [pesoBascula, setPesoBascula] = useState(1);
  const [volumen, setVolumen] = useState(1);
  const [fechaId, setFecha] = useState(new Date());
  const [insertarCargaModalAbierto, setInsertarCargaModalAbierto] = useState(false);

    //Lista de tipoCementos
    const [tipoCementos, setTipoCementos] = useState([]);
  
    useEffect(() => {
      axios.get(`http://localhost:5103/api/TipoCemento`)
        .then(res => {
          setTipoCementos(res.data);
        })
        .catch(err => console.log(err));
    }, []);

    //Lista de silos
  const [silos, setSilos] = useState([]);
  
  useEffect(() => {
      axios.get(`http://localhost:5103/api/Silo`)
      .then(res => {
        setSilos(res.data);
      })
      .catch(err => console.log(err));
  }, []);

      //Lista de vehiculos
      const [vehiculos, setVehiculos] = useState([]);
  
      useEffect(() => {
        axios.get(`http://localhost:5103/api/Vehiculo`)
          .then(res => {
            setVehiculos(res.data);
          })
          .catch(err => console.log(err));
      }, []);

      //Lista de medidores
      const [medidores, setMedidores] = useState([]);

      useEffect(() => {
        axios.get(`http://localhost:5103/api/Medidor`)
          .then(res => {
            setMedidores(res.data);
          })
          .catch(err => console.log(err));
      }, []);

      //Lista de basculas
      const [basculas, setBasculas] = useState([]);
  
      useEffect(() => {
        axios.get(`http://localhost:5103/api/Bascula`)
          .then(res => {
            setBasculas(res.data);
          })
          .catch(err => console.log(err));
      }, []);

      const carga = {
        tipoCementoId: tipoCementoId,
        siloId: siloId,
        vehiculoId: vehiculoId,
        fechaCargaId: fechaId
      }

      const medicionSilo = {

      }
  
  const createRE = async () => {
    axios.post(`http://localhost:5103/api/Carga`, {
      tipoCementoId: tipoCementoId,
      siloId: siloId,
      vehiculoId: vehiculoId,
      fechaCargaId: fechaId,
      sedeId: sedeId,
      entidadCompradoraId: entidadCompradoraId,
      fechaVentaId: fechaVentaId,
      medidorId: medidorId,
      nivel: nivel,
      pesoM: pesoMedidor,
      volumen: volumen,
      basculaId: basculaId,
      pesoB: pesoBascula,
      
    })
    .then((response) => {
      console.log(response);
      alert("La Carga se ha insertado correctamente")
      setInsertarVentaModalAbierto(false);
      onClose();
    }, (error) => {
      console.log(error);
      alert("Revise los datos insertados")
    });
 };

 const handleCancelar = () => {
  // Cierra la ventana modal desde el componente padre.
  onClose();
};

  return (
    <AbsoluteCenter marginTop={20}>
    <div style={{
      width: "400px",
      height: "1200px",
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      backgroundColor: "white",
      flexDirection: "column",
      borderRadius: 20,
      border: "2px solid #5F89C1",
    }}>
     
        <FormLabel style={{fontSize: 20}}>
        Insertar Carga
        </FormLabel>

        <FormLabel style={{marginLeft:10, marginBottom:10, marginTop:5, marginRight:200}}>Tipo de Cemento</FormLabel>

        <Select
        value={tipoCementoId}
        onChange={(e) => setTipoCementoId(e.target.value)}
        width={80}
        marginBottom={5}
        >
        {tipoCementos.map((tipoCemento) => (
        <option key={tipoCemento.tipoCementoId} value={tipoCemento.tipoCementoId}>
        {tipoCemento.nombreTipoCemento}
        </option>
        ))}
        </Select>


        <FormLabel style={{marginLeft: 10, marginRight:200, marginTop:2}}>Seleccionar Silo</FormLabel>
  
        <Select
          value={siloId}
          onChange={(e) => setSiloId(e.target.value)}
          width={80}
          marginBottom={5}
        >
          {silos.map((silo) => (
            <option key={silo.siloId} value={silo.siloId}>
              {silo.noSilo}
            </option>
          ))}
        </Select>

        <FormLabel style={{marginLeft: 10, marginTop: 10, marginTop:5, marginRight:180}}>Seleccionar Vehículo</FormLabel>
  
        <Select
          value={vehiculoId}
          onChange={(e) => setVehiculoId(e.target.value)}
          width={80}
          marginBottom={5}
        >
          {vehiculos.map((vehiculo) => (
            <option key={vehiculo.vehiculoId} value={vehiculo.vehiculoId}>
              {vehiculo.noSerie}
            </option>
          ))}
        </Select>

        <FormLabel style={{marginLeft: 10, marginTop: 10, marginTop:5, marginRight:190}}>Fecha de la carga:</FormLabel>

        <Input
          type="datetime-local"
          value={fechaId.toISOString().substring(0,16)}
          onChange={(e) => setFecha(new Date(e.target.value))}
          width={80}
          marginBottom={5}
        
        />

        <FormLabel style={{marginLeft: 10, marginTop: 10, marginTop:5}}>Medición Silo</FormLabel>
          
        <FormLabel style={{marginLeft: 10, marginTop: 10, marginTop:5, marginRight:180}}>Seleccionar Medidor</FormLabel>
          
          <Select
            value={medidorId}
            onChange={(e) => setMedidorId(e.target.value)}
            width={80}
            marginBottom={3}
          >
            {medidores.map((medidor) => (
              <option key={medidor.medidorId} value={medidor.medidorId}>
                {medidor.noSerie}
              </option>
            ))}
          </Select>

          <FormLabel style={{marginLeft: 10, marginTop:5, marginRight:280}}>Nivel</FormLabel>

          <Input
            value={nivel}
            placeholder="Ingrese el Nivel"
            onChange={(e) => setNivel(e.target.value)}
            marginTop={0.5}
            marginBottom={5}
            width={80}
            backgroundColor="white"

          />

          <FormLabel style={{marginLeft: 10, marginRight: 190, marginTop:5}}>Peso del medidor</FormLabel>

          <Input
            value={pesoMedidor}
            placeholder="Ingrese el Peso del medidor"
            onChange={(e) => setPesoMedidor(e.target.value)}
            marginTop={0.5}
            marginBottom={5}
            width={80}
            backgroundColor="white"

          />

          <FormLabel style={{marginLeft: 10, marginRight:250, marginTop:5}}>Volumen</FormLabel>

          <Input
            value={volumen}
            placeholder="Ingrese el volumen"
            onChange={(e) => setVolumen(e.target.value)}
            marginTop={0.5}
            width={80}
            backgroundColor="white"

          />
           <FormLabel style={{marginLeft: 10, marginTop: 20}}>Medición Báscula</FormLabel>

          <FormLabel style={{marginLeft: 10, marginRight:180, marginTop:5}}>Seleccionar Báscula</FormLabel>
          
          <Select
            value={basculaId}
            onChange={(e) => setBasculaId(e.target.value)}
            width={80}
            marginBottom={5}
          >
            {basculas.map((bascula) => (
              <option key={bascula.basculaId} value={bascula.basculaId}>
                {bascula.noSerie}
              </option>
            ))}
          </Select>

          <FormLabel style={{marginLeft: 10, marginRight:180, marginTop:5}}>Peso de la Báscula:</FormLabel>

          <Input
            value={pesoBascula}
            placeholder="Ingrese el Peso de la bascula"
            onChange={(e) => setPesoBascula(e.target.value)}
            marginTop={0.5}
            marginBottom={15}
            width={80}
            backgroundColor="white"

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
      </AbsoluteCenter>
  );
};


export default InsertarCarga;