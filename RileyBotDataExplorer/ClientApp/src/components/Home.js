import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Riley Bot Data Explorer</h1>
        <p>Welcome to My Discord Bot Web Application built with:</p>
        <ul>
          <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
          <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
          <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
            </ul>
            <p>This application displays the data from the Riley Bot Discord bot application. It showcases
                how easy it is to utilize npm packages that can aid in development of web applications.</p>
      </div>
    );
  }
}
