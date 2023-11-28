import { 
    Tabs,
    TabList,
    TabPanels,
    Tab,
    TabPanel
 } from '@chakra-ui/react'
 import InsertarSede from './InsertarSede';
 import InsertarTipoDeEquipo from './InsertarTipoDeEquipo';
 import InsertarEquipo from './InsertarEquipo';

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
        <Tabs isFitted variant='soft-rounded' colorScheme='orange'>
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

            <TabPanel> {/*Panel para Insertar Tipo de Equipo */}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarTipoDeEquipo/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar Equipo */}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarEquipo/>
                </div>
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