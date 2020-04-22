import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { About } from './components/About';
import { UserComponent } from './components/UserComponent';
import { DropComponent } from './components/DropComponent';
import { LinkComponent } from './components/LinkComponent';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/about' component={About} />
        <Route path='/user-data' component={UserComponent} />
        <Route path='/drop-data' component={DropComponent} />
        <Route path='/link-data' component={LinkComponent} />
      </Layout>
    );
  }
}
