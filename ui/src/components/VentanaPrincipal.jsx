import React, {state, useState} from 'react';
import { 
    useDisclosure,
    Button,
    Accordion,
    AccordionItem,
    AccordionButton,
    AccordionPanel,
    AccordionIcon,
    Box,
    Input,
    Flex,
    List,
    ListItem,
    ListIcon,
    OrderedList,
    UnorderedList,
    Modal,
    AbsoluteCenter,
    Stack,
    Center,
    Text,
 } from '@chakra-ui/react'
 import VisualizarAccionMantenimiento from './VisualizarAccionmantenimiento';
 import Equipo from './VisualizarEquipo';
 import VisualizarOrdenTrabajo from './VisualizarOrdenTrabajo';
 import RoturaEquipo from './VisualizarRoturaEquipo';
 import Rotura from './VisualizarRotura';
 import VisualizarHerramienta from './VisualizarHerramienta';
 import Reporte from './Reporte';

 const VentanaPrincipal = () => {

        const { isOpen, onOpen, onClose } = useDisclosure()
        const btnRef = React.useRef()

        //Manejo de estado de los modales
        const [visualizarAccionMantenimientoEModalAbierto, setVisualizarAccionMantenimientoEModalAbierto] = useState(false);
        const [visualizarEquipoModalAbierto, setVisualizarEquipoModalAbierto] = useState(false);
        const [visualizarHerramientaModalAbierto, setVisualizarHerramientaModalAbierto] = useState(false);
        const [visualizarOrdenTrabajoModalAbierto, setVisualizarOrdenTrabajoModalAbierto] = useState(false);
        const [visualizarRoturaEquipoModalAbierto, setVisualizarRoturaEquipoModalAbierto] = useState(false);
        const [visualizarRoturaModalAbierto, setVisualizarRoturaModalAbierto] = useState(false);
        const [visualizarReporteModalAbierto, setVisualizarReporteModalAbierto] = useState(false);
        

        const abrirVisualizarAccionMantenimientoModal = () => {
          setVisualizarAccionMantenimientoEModalAbierto(true);
          setVisualizarEquipoModalAbierto(false);
          setVisualizarHerramientaModalAbierto(false);
          setVisualizarOrdenTrabajoModalAbierto(false);
          setVisualizarRoturaEquipoModalAbierto(false);
          setVisualizarRoturaModalAbierto(false);
          setVisualizarReporteModalAbierto(false);
         };

         const abrirVisualizarEquipoModal = () => {
          setVisualizarAccionMantenimientoEModalAbierto(false);
          setVisualizarEquipoModalAbierto(true);
          setVisualizarHerramientaModalAbierto(false);
          setVisualizarOrdenTrabajoModalAbierto(false);
          setVisualizarRoturaEquipoModalAbierto(false);
          setVisualizarRoturaModalAbierto(false);
          setVisualizarReporteModalAbierto(false);
         };

         const abrirVisualizarHerramientaModal = () => {
          setVisualizarAccionMantenimientoEModalAbierto(false);
          setVisualizarEquipoModalAbierto(false);
          setVisualizarHerramientaModalAbierto(true);
          setVisualizarOrdenTrabajoModalAbierto(false);
          setVisualizarRoturaEquipoModalAbierto(false);
          setVisualizarRoturaModalAbierto(false);
          setVisualizarReporteModalAbierto(false);
         }

         const abrirVisualizarOrdenTrabajoModal = () => {
          setVisualizarAccionMantenimientoEModalAbierto(false);
          setVisualizarEquipoModalAbierto(false);
          setVisualizarHerramientaModalAbierto(false);
          setVisualizarOrdenTrabajoModalAbierto(true);
          setVisualizarRoturaEquipoModalAbierto(false);
          setVisualizarRoturaModalAbierto(false);
          setVisualizarReporteModalAbierto(false);
         }

         const abrirVisualizarRoturaEquipoModal = () => {
          setVisualizarAccionMantenimientoEModalAbierto(false);
          setVisualizarEquipoModalAbierto(false);
          setVisualizarHerramientaModalAbierto(false);
          setVisualizarOrdenTrabajoModalAbierto(false);
          setVisualizarRoturaEquipoModalAbierto(true);
          setVisualizarRoturaModalAbierto(false);
          setVisualizarReporteModalAbierto(false);
         }

         const abrirVisualizarRoturaModal = () => {
          setVisualizarAccionMantenimientoEModalAbierto(false);
          setVisualizarEquipoModalAbierto(false);
          setVisualizarHerramientaModalAbierto(false);
          setVisualizarOrdenTrabajoModalAbierto(false);
          setVisualizarRoturaEquipoModalAbierto(false);
          setVisualizarRoturaModalAbierto(true);
          setVisualizarReporteModalAbierto(false);
         }

         const abrirVisualizarReporteModal = () => {
          setVisualizarAccionMantenimientoEModalAbierto(false);
          setVisualizarEquipoModalAbierto(false);
          setVisualizarHerramientaModalAbierto(false);
          setVisualizarOrdenTrabajoModalAbierto(false);
          setVisualizarRoturaEquipoModalAbierto(false);
          setVisualizarRoturaModalAbierto(false);
          setVisualizarReporteModalAbierto(true);
         }

 return(
<Flex width="100vw" height="100vh">
      {/* Panel fijo a la izquierda */}
      <Box flex="1" bg="white"  borderRight="2px solid gray" >
      <img
        src="/public/ecocemlogo.png"
        alt="Logo"
        width={100}
        height={100}
        style={{ margin: "auto" }}
      />
      <p style={{ textAlign: "center", fontSize: 40 }}>ECOCEM</p>
      <p style={{ textAlign: "center", fontSize: 20, marginTop: "5px", marginBottom: "10px"}}>Nombre de Usuario</p>

      <Accordion defaultIndex={[0]} allowMultiple>
  <AccordionItem>
    <h2>
      <AccordionButton>
        <Box as="span" flex='1' textAlign='left' >
          Gestión de Mantenimiento
        </Box>
        <AccordionIcon />
      </AccordionButton>
    </h2>
    <AccordionPanel pb={4}>
    <Stack direction='column' spacing={2} align="flex-start">
  <Button colorScheme='teal' variant='link' onClick= { abrirVisualizarAccionMantenimientoModal }
  >
    Acción de Mantenimiento
  </Button>
  
  <Button colorScheme='teal' variant='link' onClick={ abrirVisualizarEquipoModal }
  >
    Equipo
  </Button>
  <Button colorScheme='teal' variant='link' onClick={ abrirVisualizarHerramientaModal }
  >
    Herramienta 
  </Button>
  <Button colorScheme='teal' variant='link' onClick={ abrirVisualizarOrdenTrabajoModal }
  >
    Orden de Trabajo</Button>
  <Button colorScheme='teal' variant='link' onClick={ abrirVisualizarReporteModal }
  >
    Reporte
  </Button>

  <Button colorScheme='teal' variant='link' onClick={ abrirVisualizarRoturaEquipoModal }
  >
    Rotura de Equipo</Button>
  <Button colorScheme='teal' variant='link' onClick={ abrirVisualizarRoturaModal }>Tipo de Rotura</Button> 
  </Stack>
    </AccordionPanel>
  </AccordionItem>

  <AccordionItem>
    <h2>
      <AccordionButton>
        <Box as="span" flex='1' textAlign='left'>
          Cálculo del peso
        </Box>
        <AccordionIcon />
      </AccordionButton>
    </h2>
    <AccordionPanel pb={4}>
      Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
      tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
      veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
      commodo consequat.
    </AccordionPanel>
  </AccordionItem>
  <AccordionItem>
    <h2>
      <AccordionButton>
        <Box as="span" flex='1' textAlign='left' >
          Gestión de Admin
        </Box>
        <AccordionIcon />
      </AccordionButton>
    </h2>
    <AccordionPanel pb={4}>
    <UnorderedList textAlign='left'>
  <ListItem>Brigada</ListItem>
  <ListItem>Sede</ListItem>
  <ListItem>Sucursal</ListItem>
  <ListItem>Tipo de Equipo</ListItem>
  <ListItem>Trabajador</ListItem>
</UnorderedList>
    </AccordionPanel>
  </AccordionItem>
</Accordion>
      </Box>

      {/* Panel más grande a la derecha */}
      <Box flex="3" bg="white" flexDirection="column" justifyContent="flex-start">
      <Modal
      isOpen={visualizarAccionMantenimientoEModalAbierto}
      onClose={() => setVisualizarAccionMantenimientoEModalAbierto(false)}
      position="absolute"
      left="50%"
      top="50%"
      transform="translate(-50%, -50%)"
      width="500px"
      height="500px"
      zIndex={100}
    >
      <VisualizarAccionMantenimiento
        onClose={() => setVisualizarAccionMantenimientoEModalAbierto(false)}
      />
 </Modal>
 <Modal
 isOpen={visualizarEquipoModalAbierto}
 onClose={() => setVisualizarEquipoModalAbierto(false)}
 position="absolute"
 left="50%"
 top="50%"
      transform="translate(-50%, -50%)"
      width="500px"
      height="500px"
      zIndex={100}
 >
 <Equipo 
 onClose={() => setVisualizarEquipoModalAbierto(false)}/>
 </Modal>

 <Modal
 isOpen={visualizarHerramientaModalAbierto}
 onClose={() => setVisualizarHerramientaModalAbierto(false)}
 position="absolute"
 left="50%"
 top="50%"
      transform="translate(-50%, -50%)"
      width="500px"
      height="500px"
      zIndex={100}
 >
 <VisualizarHerramienta 
 onClose={() => setVisualizarHerramientaModalAbierto(false)}/>
 </Modal>


 <Modal
 isOpen={visualizarOrdenTrabajoModalAbierto}
 onClose={() => setVisualizarOrdenTrabajoModalAbierto(false)}
 position="absolute"
 left="50%"
 top="50%"
      transform="translate(-50%, -50%)"
      width="500px"
      height="500px"
      zIndex={100}
 >
 <VisualizarOrdenTrabajo 
 onClose={() => setVisualizarOrdenTrabajoModalAbierto(false)}/>
 </Modal>

 <Modal
 isOpen={visualizarRoturaEquipoModalAbierto}
 onClose={() => setVisualizarRoturaEquipoModalAbierto(false)}
 position="absolute"
 left="50%"
 top="50%"
      transform="translate(-50%, -50%)"
      width="500px"
      height="500px"
      zIndex={100}
 >
 <RoturaEquipo
 onClose={() => setVisualizarRoturaEquipoModalAbierto(false)}/>
 </Modal>

 <Modal
 isOpen={visualizarRoturaModalAbierto}
 onClose={() => setVisualizarRoturaModalAbierto(false)}
 position="absolute"
 left="50%"
 top="50%"
      transform="translate(-50%, -50%)"
      width="500px"
      height="500px"
      zIndex={100}
 >
 <Rotura
 onClose={() => setVisualizarRoturaModalAbierto(false)}/>
 </Modal>

 <Modal
 isOpen={visualizarReporteModalAbierto}
 onClose={() => setVisualizarReporteModalAbierto(false)}
 position="absolute"
 left="50%"
 top="50%"
      transform="translate(-50%, -50%)"
      width="500px"
      height="500px"
      zIndex={100}
 >
 <Reporte
 onClose={() => setVisualizarReporteModalAbierto(false)}/>
 </Modal>
      </Box>
    </Flex>
 );
 };
 export default VentanaPrincipal;