import { useState, useEffect } from "react";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
  Modal,
  AbsoluteCenter,
  //BackgroundImage
} from "@chakra-ui/react"; 
import axios from "axios";

const InsertarMantenimientoNecesario = ({onClose}) => {
    const [tipoEId, setTipoEId] = useState(0);
    const [AMId, setAMId] = useState("");
    const [horasExpId, sethorasExpId] = useState(0);
    const [InsertarMantenimientoNecesarioModalAbierto, setInsertarMantenimientoNecesarioModalAbierto] = useState(false);
    
    //Lista de tipos de equipos
    const [tiposEquipos, setTiposEquipos] = useState([]);
    
    useEffect(() => {
        axios.get(`http://localhost:5103/api/TipoEquipo`)
        .then(res => {
            setTiposEquipos(res.data);
        })
        .catch(err => console.log(err));
    }, []);
    
    
    //Lista de AMs
    const [AMIds, setAMIds] = useState([]);
    useEffect(() => {
        axios.get(`http://localhost:5103/api/AccionMantenimiento`)
        .then(res => {
            setAMIds(res.data);
        })
        .catch(err => console.log(err));
    }, []);

    const createMantenimientoNecesario = async () => {
        axios.post(`http://localhost:5103/api/MantenimientoNecesario`, {
        tipoEId: tipoEId,
        aMId: AMId,
        horasExpId: horasExpId
      })
      .then((response) => {
       // console.log(response);
        alert("La MantenimientoNecesario se ha insertado correctamente")
        setInsertarMantenimientoNecesarioModalAbierto(false);
      }, (error) => {
        console.log(error);
        alert("La MantenimientoNecesario no se ha insertado.")
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
          
<FormLabel style={{fontSize: 30, marginTop: 20}}>
  Insertar MantenimientoNecesario
</FormLabel>
            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>AMId</FormLabel>
              <Input
                value={horasExpId}
                placeholder="Ingrese las horas horas de explotacion"
                onChange={(a) => sethorasExpId(a.target.value)}
                marginTop={0.5}
                marginLeft={10}
                width={80}
                backgroundColor= "white"
                marginBottom={30}
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

            {/* falta el otro */}

            
            <Flex justifyContent="space-between">
        <Button 
        variant="outline"
        colorScheme="blue"
        style={{ marginRight: 10, marginTop: 15}}
        onClick={createMantenimientoNecesario}
        type="submit"
        >
          Aceptar
        </Button>
        <Button variant="outline" colorScheme="red" marginTop={4} onClick={handleCancelar}>
    Cancelar
  </Button>
  </Flex>
      </div>
  );
};

export default InsertarMantenimientoNecesario;
