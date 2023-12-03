
import React from 'react';

import axios from 'axios';
export default class Sedes extends React.Component {
    state = {
      sedes: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Sede`)
        .then(res => {
          const sedes = res.data;
          this.setState({ sedes });
        })
    }
  
    render() {
      return (
        

         <ul>
           { this.state.sedes.map(sede => <li key={sede.sedeId}>Nombre: {sede.nombreSede} , Ubicación: {sede.ubicacionSede}</li>)}
         </ul>
      )
    }
  } 
