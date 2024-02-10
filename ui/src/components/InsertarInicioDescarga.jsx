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
const InsertarDescarga = () => {
const [fecha, setFecha] = useState(new Date());
const [tipoCemento, setTipoC] = useState(1);
const [siloId, setSiloId] = useState(1);
const [vehiculoId, setVehiculoId] = useState(1);
const [compraId, setCompraId] = useState(1);
const [mSiloInicial, setMSI] = useState(1);
const [mSiloFinal, setMSF] = useState(1);
const [mBasculaInicial, setMBI] = useState(1);
const [mBasculaFinal, setMBF] = useState(1);





};
export default InsertarDescarga;