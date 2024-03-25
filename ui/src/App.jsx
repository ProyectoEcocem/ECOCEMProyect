//import { useState } from 'react'
//import reactLogo from './assets/react.svg'
//import viteLogo from '/vite.svg'
import './App.css'
import { ChakraProvider } from '@chakra-ui/react'
import Login from './components/Login'
import VentanaPrincipal from './components/VentanaPrincipal'
import InsertarRoles from './components/InsertarRoles'
import { useState } from 'react'
import Resumenes from './components/ResumenesParametrosIndicadores'
import InsertarDescarga from './components/InsertarDescarga'
import InsertarCarga from './components/InsertarCarga'

function App() {
 // const [count, setCount] = useState(0)

 //controlar estado de aparicion de la ventana de Login
 const [mostrarLogin, setMostrarLogin] = useState(true);

 const manejoClick = () => {
  setMostrarLogin(false);
 }

   return (
     <ChakraProvider>
      
      {mostrarLogin ? (
        <Login manejoClick={manejoClick} />
      ) : (
        <VentanaPrincipal />
      )}
    
  </ChakraProvider>
  )
}

export default App
