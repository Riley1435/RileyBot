import React, { Component } from 'react';
import { Container } from 'reactstrap';
import './Footer.css';

export class Footer extends Component {
    static displayName = Footer .name;

    constructor(props) {
        super(props);
    }

    render() {
        var date = new Date();
        var year = date.getFullYear();
        return (
            <div className="footer">
                <Container>
                    <p>Made By Riley Marsh {year}.</p>
                </Container>
            </div>
        );
    }
}
