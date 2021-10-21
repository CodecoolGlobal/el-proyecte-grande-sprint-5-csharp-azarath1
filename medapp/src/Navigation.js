import React,{Component} from 'react';
import {NavLink} from 'react-router-dom';
import {Button,Navbar,Nav} from 'react-bootstrap';
import { SignUpModal } from './SignUpModal';

export class Navigation extends Component{

    constructor(props) {
        super(props);
        this.state = {SignUpModalShow: false}
    }

    render() {
        let SignUpModalClose = () => this.setState({ SignUpModalShow: false });
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
                </Button><SignUpModal show={this.state.SignUpModalShow}onHide={SignUpModalClose}/>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/medicines">
                    Medicine Api
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
                    Login
                </NavLink>
                </Nav>
                </Navbar.Collapse>
            </Navbar>
        )
    }
}