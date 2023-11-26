//import { useState } from 'react'
//import reactLogo from './assets/react.svg'
//import viteLogo from '/vite.svg'
import './App.css'
import { ChakraProvider } from '@chakra-ui/react'
//import Login from './components/Login'
//import InsertarSede from './components/InsertarSede'
//import InsertarTipoDeEquipo from './components/InsertarTipoDeEquipo'
//import InsertarEquipo from './components/InsertarEquipo'
import InsertarRoturaEquipo from './components/InsertarRoturaEquipo'
//import InsertarTrabajador from './components/InsertarTrabajador'

function App() {
 // const [count, setCount] = useState(0)

  return (
    <ChakraProvider>
      <div>
      <InsertarRoturaEquipo/>
    </div>
  </ChakraProvider>
  )
}

export default App
