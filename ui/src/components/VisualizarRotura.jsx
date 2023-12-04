
import React from 'react';

import axios from 'axios';
export default class TiposEquipo extends React.Component {
    state = {
      Roturas: []
    }
  
    componentDidMount() {
      axios.get(`http://localhost:5103/api/Rotura`)
        .then(res => {
          const Roturas= res.data;
          this.setState({ Roturas });
        })
    }
  
    render() {
      return (
        


         <ul>
           { this.state.Roturas.map(rotura => <li key={rotura.RoturaId}>Tipo: {rotura.nombreRotura} </li>)}
         </ul>
      )
    }
  } 