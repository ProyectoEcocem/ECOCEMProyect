import { 
    Tabs,
    TabList,
    TabPanels,
    Tab,
    TabPanel,
    TabIndicator
 } from '@chakra-ui/react'
import InsertarSede from './InsertarSede';
import InsertarTipoDeEquipo from './InsertarTipoDeEquipo';
import InsertarEquipo from './InsertarEquipo';
import InsertarRotura from './InsertarRotura';
import InsertarRoturaEquipo from './InsertarRoturaEquipo';
import InsertarParametros from './InsertarParametros';
import VisualizarSede from './VisualizarSede';
import VisualizarTipoEquipo from './VisualizarTipoEquipo';
import VisualizarEquipo from './VisualizarEquipo';
import VisualizarRotura from './VisualizarRotura';
import VisualizarRoturaEquipo from './VisualizarRoturaEquipo';
import VisualizarParametros from './VisualizarParametros';


 const VentanaPrincipal = () => {
 return(
<div>
 <Tabs isFitted variant="enclosed">

  <TabList>
    <Tab fontSize={24}>Visualizar Tablas</Tab>
    <Tab fontSize={24}>Introducir Datos</Tab>
  </TabList>



  <TabPanels>

    <TabPanel> {/*Panel para Visualizar Tablas*/}
      <Tabs isFitted variant="enclosed" colorScheme='orange'>
        <TabList>
            <Tab>Sedes</Tab>
            <Tab>Tipos de Equipo</Tab>
            <Tab>Equipos</Tab>
            <Tab>Rotura</Tab>
            <Tab>Roturas de Equipos</Tab>
            <Tab>Parámetros</Tab>
        </TabList>

        <TabIndicator
      mt="-1.5px"
      height="2px"
      bg="blue.500"
      borderRadius="1px"
    />

        <TabPanels>

            <TabPanel> {/*Panel para Visualizar Sede*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <VisualizarSede/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Visualizar Tipo de Equipo*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <VisualizarTipoEquipo/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Visualizar Equipo*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <VisualizarEquipo/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Visualizar Rotura*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <VisualizarRotura/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Visualizar Roturas de Equipos*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <VisualizarRoturaEquipo/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Visualizar parametros*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <VisualizarParametros/>
                </div>
            </TabPanel>

        </TabPanels>
      </Tabs>
    </TabPanel>

    <TabPanel> {/*Panel para Introducir Datos*/}
        <Tabs isFitted variant="enclosed" colorScheme='orange'>
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

            <TabPanel> {/*Panel para Insertar Rotura */}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                    <InsertarRotura/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar Rotura de Equipo */}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarRoturaEquipo/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar Parámetros */}
            <div>
                <InsertarParametros/>
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