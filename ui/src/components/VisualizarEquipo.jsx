
import React from 'react';

import axios from 'axios';
export default class Equipo extends React.Component {
    state = {
      Equipos: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Equipo`)
        .then(res => {
          const Equipos= res.data;
          this.setState({ Equipos });
        })
    }
  
    render() {
      return (
        
         <ul>
           { this.state.Equipos.map(equipo => <li key={equipo.equipoId}> Id:{equipo.equipoId} Tipo: {equipo.tipoEId} Sede: {equipo.sedeId} </li>)}
         </ul>
      )
    }
  } 