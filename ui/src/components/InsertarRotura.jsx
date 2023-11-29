import { useState } from "react";
import {
  FormControl,
  FormLabel,
  Input,
  Button,
  Flex,
  //BackgroundImage
} from "@chakra-ui/react"; 

const InsertarRotura = () => {
    const [roturaId, setRoturaId] = useState("");
    const [nombreRotura, setNombreRotura] = useState("");
  
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
  Insertar Tipo de Rotura
</FormLabel>
          <FormControl>
              <FormLabel style={{margin: "20px 20px 0px 40px"}}>ID de la Rotura</FormLabel>
              <Input
                value={roturaId}
                placeholder="Ingrese el Id de la Rotura"
                onChange={(e) => setRoturaId(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
              />
            </FormControl>
      
            <FormControl>
              <FormLabel style = {{margin: "20px 0px 0px 40px"}}>Nombre de la Rotura</FormLabel>
              <Input
                value={nombreRotura}
                placeholder="Ingrese el nombre de la Rotura"
                onChange={(e) => setNombreRotura(e.target.value)}
                marginTop={0.5}
                width={80}
                backgroundColor= "white"
                marginBottom={30}
              />
            </FormControl>
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

export default InsertarRotura;

// ToDO: Verificar si lo que se inserta es válido.
// ToDO: agregar evento con los botones.