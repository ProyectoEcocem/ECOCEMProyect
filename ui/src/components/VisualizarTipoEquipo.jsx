
import React from 'react';

import axios from 'axios';
export default class TiposEquipo extends React.Component {
    state = {
      tipoEquipos: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/TipoEquipo`)
        .then(res => {
          const tipoEquipos= res.data;
          this.setState({ tipoEquipos });
        })
    }
  
    render() {
      return (
        

         <ul>
           { this.state.tipoEquipos.map(tipoE => <li key={tipoE.tipoEId}>Tipo: {tipoE.tipoE} </li>)}
         </ul>
      )
    }
  } 