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
import InsertarParametrosTabla from './InsertarParametrosTabla';
import InsertarEmpresa from './InsertarEmpresa';
import VisualizarSede from './VisualizarSede';
import VisualizarTipoEquipo from './VisualizarTipoEquipo';
import VisualizarEquipo from './VisualizarEquipo';
import VisualizarRotura from './VisualizarRotura';
import VisualizarRoturaEquipo from './VisualizarRoturaEquipo';
import VisualizarParametros from './VisualizarParametros';
import VisualizarIndicadores from './VisualizarIndicadores';
import InsertarBascula from './InsertarBascula';
import InsertarFabrica from './InsertarFabrica';
import Reporte from './Reporte';
import InsertarMedidor from './InsertarMedidor';
import InsertarTipoCemento from './InsertarTipoCemento';
import InsertarVehiculo from './InsertarVehiculo';
import InsertarSilo from './InsertarSilo';
import Bascula from './VisualizarBascula';
import Fabrica from './VisualizarFabrica';
import Medidor from './VisualizarMedidor';
import InsertarCompra from './InsertarCompra';
import InsertarVenta from './InsertarVenta';
import InsertarEntidadCompradora from './InsertarEntidadCompradora';
import EntidadCompradora from './VisualizarEntidadCompradora';
import Venta from './VizualizarVenta';
import Compra from './VisualizarCompra';
import Resumenes from './ResumenesParametrosIndicadores';

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
            <Tab>Reporte</Tab>
            <Tab>Basculas</Tab>
            <Tab>Fabrica</Tab>
            <Tab>Entidad Compradora</Tab>
            <Tab>Medidor</Tab>
            <Tab>Compra</Tab>
            <Tab>Venta</Tab>
            <Tab>Visualizar Indicadores</Tab>
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

            <TabPanel> {/*Panel para Reporte*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <Reporte/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Bascula*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <Bascula/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Fabrica*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <Fabrica/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Fabrica*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <EntidadCompradora/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Medidor*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <Medidor/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Medidor*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <Compra/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Medidor*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <Venta/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Medidor*/}
            <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <VisualizarIndicadores/>
                </div>
            </TabPanel>

           
        </TabPanels>
      </Tabs>
    </TabPanel>

    <TabPanel> {/*Panel para Introducir Datos*/}
        <Tabs isFitted variant="enclosed" colorScheme='orange'>
        <TabList>
            <Tab>InsertarEmpresa</Tab>
            <Tab>Insertar Sede</Tab>
            <Tab>Insertar Tipo de Equipo</Tab>
            <Tab>Insertar Equipo</Tab>
            <Tab>Insertar Tipo de Rotura</Tab>
            <Tab>Insertar Rotura de Equipo</Tab>
            <Tab>Insertar Parámetros</Tab>
            <Tab>Insertar Bascula</Tab>
            <Tab>Insertar Fabrica</Tab>
            <Tab>Insertar Entidad Compradora</Tab>
            <Tab>Insertar Medidor</Tab>
            <Tab>Insertar Tipo de Cemento</Tab>
            <Tab>Insertar Vehiculo</Tab>
            <Tab>Insertar Compra</Tab>
            <Tab>Insertar Venta</Tab>
            <Tab>Resum</Tab>
        </TabList>

        <TabPanels>

        <TabPanel> {/*Panel para Insertar Empresa */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarEmpresa/>
                </div>
            </TabPanel>

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
                <InsertarParametrosTabla/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar Bascula */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarBascula/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar Fab */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarFabrica/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar EC */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarEntidadCompradora/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar Medidor */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarMedidor/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar Tipo Cemento */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarTipoCemento/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar vehiculo */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarVehiculo/>
                </div>
            </TabPanel>

          

            <TabPanel> {/*Panel para Insertar compra */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarCompra/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar compra */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <InsertarVenta/>
                </div>
            </TabPanel>

            <TabPanel> {/*Panel para Insertar compra */}
                <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                }}>
                <Resumenes/>
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