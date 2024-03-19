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
        

         const abrirModal = (modalAbierto, setModalAbierto) => {
          // Lista de todos los modales
          const modales = [
             ['VisualizarAccionMantenimientoEModalAbierto', setVisualizarAccionMantenimientoEModalAbierto],
             ['VisualizarEquipoModalAbierto',  setVisualizarEquipoModalAbierto],
             ['VisualizarHerramientaModalAbierto',  setVisualizarHerramientaModalAbierto],
             ['VisualizarOrdenTrabajoModalAbierto',  setVisualizarOrdenTrabajoModalAbierto],
             ['VisualizarRoturaEquipoModalAbierto', setVisualizarRoturaEquipoModalAbierto],
             ['VisualizarRoturaModalAbierto', setVisualizarRoturaModalAbierto],
             ['VisualizarReporteModalAbierto', setVisualizarReporteModalAbierto]
          ];
         
          // Función para establecer el estado de todos los modales en false
          const cerrarTodosLosModales = () => {
            modales.forEach(([nombreModal, setModal]) => {
              // Si el nombre del modal actual coincide con el modalAbierto, establece su estado en true
              if (nombreModal === modalAbierto) {
                setModal(true);
              } else {
                // De lo contrario, establece su estado en false
                setModal(false);
              }
           });
          };
         
          // Establecer el estado del modal especificado en true
          setModalAbierto(true);
         
          // Cerrar todos los demás modales
          cerrarTodosLosModales();
         };

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
  <Button colorScheme='teal' variant='link' onClick= { () => abrirModal('VisualizarAccionMantenimientoEModalAbierto', setVisualizarAccionMantenimientoEModalAbierto) }
  >
    Acción de Mantenimiento
  </Button>
  
  <Button colorScheme='teal' variant='link' onClick={ () => abrirModal('VisualizarEquipoModalAbierto', setVisualizarEquipoModalAbierto) }
  >
    Equipo
  </Button>
  <Button colorScheme='teal' variant='link' onClick={ () => abrirModal('VisualizarHerramientaModalAbierto', setVisualizarHerramientaModalAbierto) }
  >
    Herramienta 
  </Button>
  <Button colorScheme='teal' variant='link' onClick={ () => abrirModal('VisualizarOrdenTrabajoModalAbierto', setVisualizarOrdenTrabajoModalAbierto) }
  >
    Orden de Trabajo</Button>
  <Button colorScheme='teal' variant='link' onClick={ () => abrirModal('VisualizarReporteModalAbierto', setVisualizarReporteModalAbierto) }
  >
    Reporte
  </Button>

  <Button colorScheme='teal' variant='link' onClick={ () => abrirModal('VisualizarRoturaEquipoModalAbierto', setVisualizarRoturaEquipoModalAbierto) }
  >
    Rotura de Equipo</Button>
  <Button colorScheme='teal' variant='link' onClick={ () => abrirModal('VisualizarRoturaModalAbierto', setVisualizarRoturaModalAbierto) }>Tipo de Rotura</Button> 
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
      <Button colorScheme='teal' variant='link'>Báscula</Button>
      <Button colorScheme='teal' variant='link'>Entidad Compradora</Button>
      <Button colorScheme='teal' variant='link'>Fábrica</Button>
      <Button colorScheme='teal' variant='link'>Medidor</Button>
      <Button colorScheme='teal' variant='link'>Silo</Button>
      <Button colorScheme='teal' variant='link'>Tipo de Cemento</Button>
      <Button colorScheme='teal' variant='link'>Vehículo</Button>
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