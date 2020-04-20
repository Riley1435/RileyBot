import React, { Component } from 'react';

export class UserComponent extends Component {
  static displayName = UserComponent.name;

  constructor(props) {
    super(props);
    this.state = { users: [], loading: true };
  }

  componentDidMount() {
    this.populateUserData();
  }

  static renderUsersTable(users) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>UserId</th>
            <th>DiscordId</th>
            <th>Added Date</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user =>
              <tr key={user.userId}>
              <td>{user.userId}</td>
              <td>{user.discordId}</td>
              <td>{user.added}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : UserComponent.renderUsersTable(this.state.users);

    return (
      <div>
        <h1 id="tabelLabel" >RileyBot Users</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateUserData() {
    const response = await fetch('user');
    const data = await response.json();
    this.setState({ users: data, loading: false });
  }
}
