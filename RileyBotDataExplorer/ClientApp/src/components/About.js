import React, { Component } from 'react';
import newuser from './images/newuser.png'
import newdrop from './images/newdrop.png'
import newlink from './images/newlink.png'
import './About.css'

export class About extends Component {
    static displayName = About.name;


  render () {
    return (
    <div>
        <h1>About</h1>
            <p>This web application is used to explore and view
                the data of the RileyBot discord bot</p>

            <h2>Sample Commands</h2>

            <h3>Adding a new user</h3>
            <img src={newuser} alt="new user command"/>
            <br />

            <h3>Adding a new drop</h3>
            <img src={newdrop} alt="new drop command"/>
            <br />

            <h3>Adding a new link</h3>
            <img src={newlink} alt="new link command" />
            <br />
    </div>
    );
  }
}
