import React, { Component } from 'react';

export class About extends Component {
    static displayName = About.name;


  render () {
    return (
      <div>
        <h1>About</h1>
            <p>This web application is used to explore and view the data of the RileyBot discord bot</p>
      </div>
    );
  }
}
