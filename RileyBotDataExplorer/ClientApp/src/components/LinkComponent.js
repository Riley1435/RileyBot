import React, { Component } from 'react';

export class LinkComponent extends Component {
    static displayName = LinkComponent.name;

    constructor(props) {
        super(props);
        this.state = { links: [], loading: true };
    }

    componentDidMount() {
        this.populateLinkData();
    }

    static renderLinkTable(links) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>LinkId</th>
                        <th>Url</th>
                    </tr>
                </thead>
                <tbody>
                    {links.map(link =>
                        <tr key={link.linkId}>
                            <td>{link.linkId}</td>
                            <td>{link.linkUrl}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : LinkComponent.renderLinkTable(this.state.links);

        return (
            <div>
                <h1 id="tabelLabel" >RileyBot Links</h1>
                {contents}
            </div>
        );
    }

    async populateLinkData() {
        const response = await fetch('api/v1.0/link');
        const data = await response.json();
        this.setState({ links: data, loading: false });
    }
}
