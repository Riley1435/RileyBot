import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
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
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/user-data' component={UserComponent} />
        <Route path='/drop-data' component={DropComponent} />
        <Route path='/link-data' component={LinkComponent} />
      </Layout>
    );
  }
}
