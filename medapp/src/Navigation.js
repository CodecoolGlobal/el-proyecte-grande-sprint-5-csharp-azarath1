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
            <div>
                <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                <h4><i className="fas fa-laptop-medical text-danger"></i></h4> 
                </NavLink >
                <NavLink  className="d-inline p-2 bg-dark text-white" to="/personal">
                    Patient Details Page
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/mypatients">
                    My Patients
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/allpatients">
                    All Patients
                </NavLink>
                <Button id="signup" className="d-inline p-2 bg-dark text-white" onClick={() => this.setState({ SignUpModalShow: true })}>
                    Sign Up
                </Button>
                <Button id="login" className="d-inline p-2 bg-dark text-white" onClick={() => this.setState({ LoginModalShow: true })}>
                    Login
                </Button>
                </Nav>
                </Navbar.Collapse>
            </Navbar>
            <LoginModal show={this.state.LoginModalShow} onHide={LoginModalClose}/>
            <SignUpModal show={this.state.SignUpModalShow}onHide={SignUpModalClose}/>
        </div>
            
        )
    }
}