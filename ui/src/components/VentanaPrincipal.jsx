import { 
    Tabs,
    TabList,
    TabPanels,
    Tab,
    TabPanel
 } from '@chakra-ui/react'
 import InsertarSede from './InsertarSede';

 const VentanaPrincipal = () => {
 return(
<div>
 <Tabs isFitted variant='soft-rounded' colorScheme='blue'>

  <TabList>
    <Tab>Visualizar Tablas</Tab>
    <Tab>Introducir Datos</Tab>
  </TabList>

  <TabPanels>

    <TabPanel> {/*Panel para Visualizar Tablas*/}
      <p>one!</p>
    </TabPanel>

    <TabPanel> {/*Panel para Introducir Datos*/}
        <Tabs isFitted variant='soft-rounded' colorScheme='green'>
        <TabList>
            <Tab>Insertar Sede</Tab>
            <Tab>Insertar Tipo de Equipo</Tab>
            <Tab>Insertar Equipo</Tab>
            <Tab>Insertar Tipo de Rotura</Tab>
            <Tab>Insertar Rotura de Equipo</Tab>
            <Tab>Insertar Parámetros</Tab>
        </TabList>

        <TabPanels>

            <TabPanel> {/*Panel para Insertar Sede */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarSede/>
                </div>
            </TabPanel>

            <TabPanel>
            <p>two!</p>
            </TabPanel>

        </TabPanels>
        </Tabs>
    </TabPanel>

  </TabPanels>
</Tabs>
</div>
 );
 };

 export default VentanaPrincipal;