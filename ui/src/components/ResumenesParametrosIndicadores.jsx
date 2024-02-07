import React, { useState, useEffect } from 'react';
import axios from 'axios';
import {
  Box,
  Button,
  FormControl,
  FormLabel,
  Select,
  Stack,
  Table,
  Thead,
  Tbody,
  Tr,
  Th,
  Td,
  Text,
} from '@chakra-ui/react';

const Resumenes = ({ lista }) => {
  const [fechaSeleccionada, setFechaSeleccionada] = useState({
    dia: '',
    mes: '',
    ano: '',
  });
  
  const [reportes, setReportes] = useState([]);

// Lista de días
const dias = Array.from({ length:  31 }, (_, i) => i +  1);

// Lista de meses
const meses = Array.from({ length:  12 }, (_, i) => i +  1);

// Lista de años
const anos = Array.from({ length:  100 }, (_, i) => new Date().getFullYear() - i);

  const handleChange = (e, tipo) => {
    setFechaSeleccionada({
      ...fechaSeleccionada,
      [tipo]: e.target.value,
    });
  };

  const filtrarLista = async () => {
    alert(fechaSeleccionada.ano)
    try {
      const response = await axios.get('http://localhost:5103/api/FiltroMantenimiento/GetReportes',{
        params: {
            dia: fechaSeleccionada.dia,
            mes: fechaSeleccionada.mes,
            anno: fechaSeleccionada.ano,
          },
      });
      setReportes(response.data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  useEffect(() => {
    if (lista) {
      filtrarLista();
    }
  }, [lista]);

  return (
    <Box>
      <Stack spacing={4}>
      <FormControl id="dia">
        <FormLabel>Día</FormLabel>
        <Select placeholder="Selecciona un día" value={fechaSeleccionada.dia} onChange={(e) => handleChange(e, 'dia')}>
            {dias.map((dia) => (
            <option key={dia} value={dia}>
                {dia}
            </option>
            ))}
        </Select>
        </FormControl>
        <FormControl id="mes">
        <FormLabel>Mes</FormLabel>
        <Select placeholder="Selecciona un mes" value={fechaSeleccionada.mes} onChange={(e) => handleChange(e, 'mes')}>
            {meses.map((mes) => (
            <option key={mes} value={mes}>
                {mes || 'Vacío'}
            </option>
            ))}
        </Select>
        </FormControl>
        <FormControl id="ano">
        <FormLabel>Año</FormLabel>
        <Select placeholder="Selecciona un año" value={fechaSeleccionada.ano} onChange={(e) => handleChange(e, 'ano')}>
            {anos.map((ano) => (
            <option key={ano} value={ano}>
                {ano || 'Vacío'}
            </option>
            ))}
        </Select>
        </FormControl>
        <Button onClick={filtrarLista}>Filtrar</Button>
      </Stack>
      <Text>Resultados</Text>
      <Table variant="simple">
        <Thead>
          <Tr>
          <Th>Equipo_Id</Th>
              <Th>Fecha</Th>
              <Th>trpf</Th>
              <Th>trm</Th>
              <Th>tor</Th>
              <Th>tptp</Th>
              <Th>ttpm</Th>
              <Th>tor</Th>
              <Th>trap</Th>
              <Th>ctm</Th>
              <Th>fact</Th>
              <Th>cmc</Th>
          </Tr>
        </Thead>
        <Tbody>
          {reportes.map((reporte) => (
            <Tr key={`${reporte.equipoId}-${reporte.fechaId}`}>
              <Td>{reporte.equipoId}</Td>
                  <Td>{reporte.fechaId}</Td>
                  <Td>{reporte.tiempoRealParoFalla}</Td>
                  <Td>{reporte.tiempoRealMant}</Td>
                  <Td>{reporte.tiempoOPeracionReal}</Td>
                  <Td>{reporte.tiempoParoTrabajosPlan}</Td>
                  <Td>{reporte.tiempoParoMant}</Td>
                  <Td>{reporte.tiempoOperacionRequerido}</Td>
                  <Td>{reporte.tiempoRequeridoAccProgramadas}</Td>
                  <Td>{reporte.costoTotalMant}</Td>
                  <Td>{reporte.facturacion}</Td>
                  <Td>{reporte.costoMantContratado}</Td>
            </Tr>
          ))}
        </Tbody>
      </Table>
    </Box>
  );
};

export default Resumenes;
