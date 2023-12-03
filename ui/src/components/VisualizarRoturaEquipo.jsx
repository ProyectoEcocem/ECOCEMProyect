
import React from 'react';

import axios from 'axios';
export default class RoturaEquipo extends React.Component {
    state = {
      roturasE: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/RoturaEquipo`)
        .then(res => {
          const roturasE= res.data;
          this.setState({ roturasE });
        })
    }
  
    render() {
      return (
        
         <ul>
           { this.state.roturasE.map(roturaE => <li key={roturaE.roturaId}> Id:{roturaE.roturaId} Equipo: {roturaE.equipoId} Fecha:  Equipo: {roturaE.fechaId} </li>)}
         </ul>
      )
    }
  } 