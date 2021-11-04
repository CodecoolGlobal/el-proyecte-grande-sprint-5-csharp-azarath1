import React,{Component} from 'react';
import {NavLink} from 'react-router-dom';
import {Button,Navbar,Nav} from 'react-bootstrap';
import { SignUpModal } from './SignUpModal';
import { LoginModal } from './LoginModal';

export class Navigation extends Component{

    constructor(props) {
        super(props);
        this.state = { SignUpModalShow: false, LoginModalShow: false }
    }

    render() {
        let SignUpModalClose = () => this.setState({ SignUpModalShow: false });
        let LoginModalClose = () => this.setState({ LoginModalShow: false });
        return(
            <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                    Home
                </NavLink>
                <Button className="d-inline p-2 bg-dark text-white" onClick={() => this.setState({ SignUpModalShow: true })}>
                    Sign Up
                </Button><SignUpModal show={this.state.SignUpModalShow} onHide={SignUpModalClose} />
                <NavLink className="d-inline p-2 bg-dark text-white" to="/personal">
                    Personal Details Page
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/mypatients">
                    My Patients
                </NavLink>
                <Button className="d-inline p-2 bg-dark text-white" onClick={() => this.setState({ LoginModalShow: true })}>
                    Login
                </Button><LoginModal show={this.state.LoginModalShow} onHide={LoginModalClose} />
                </Nav>
                </Navbar.Collapse>
            </Navbar>
        )
    }
}