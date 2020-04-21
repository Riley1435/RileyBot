import React, { Component } from 'react';

export class DropComponent extends Component {
    static displayName = DropComponent.name;

    constructor(props) {
        super(props);
        this.state = { drops: [], loading: true };
    }

    componentDidMount() {
        this.populateDropData();
    }

    static renderDropTable(drops) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>DropId</th>
                        <th>Name</th>
                        <th>Points</th>
                        <th>Kill Count</th>
                    </tr>
                </thead>
                <tbody>
                    {drops.map(drop =>
                        <tr key={drop.dropId}>
                            <td>{drop.dropId}</td>
                            <td>{drop.name}</td>
                            <td>{drop.points}</td>
                            <td>{drop.killCount}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : DropComponent.renderDropTable(this.state.drops);

        return (
            <div>
                <h1 id="tabelLabel" >RileyBot Drops</h1>
                {contents}
            </div>
        );
    }

    async populateDropData() {
        const response = await fetch('api/v1.0/drop');
        const data = await response.json();
        this.setState({ drops: data, loading: false });
    }
}
