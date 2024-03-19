//import { useState } from 'react'
//import reactLogo from './assets/react.svg'
//import viteLogo from '/vite.svg'
import './App.css'
import { ChakraProvider } from '@chakra-ui/react'
import { PrimeReactProvider, PrimeReactContext } from 'primereact/api';
import Login from './components/Login'
import VentanaPrincipal from './components/VentanaPrincipal'
import InsertarRoles from './components/InsertarRoles'
import VisualizarAccionMantenimiento from './components/VisualizarAccionmantenimiento';
import { useState } from 'react'
import Resumenes from './components/ResumenesParametrosIndicadores'

function App() {
 // const [count, setCount] = useState(0)

 //controlar estado de aparicion de la ventana de Login
 const [mostrarLogin, setMostrarLogin] = useState(true);

 const manejoClick = () => {
  setMostrarLogin(false);
 }

   return (
     <ChakraProvider>
      <div> <VentanaPrincipal/>
      {/*{mostrarLogin ? (
        <Login manejoClick={manejoClick} />
      ) : (
        <VentanaPrincipal />
      )}*/}
    </div>
  </ChakraProvider>
  )
}

export default App
