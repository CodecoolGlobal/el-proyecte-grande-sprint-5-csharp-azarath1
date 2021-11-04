import React from 'react';
import { useState } from 'react';
import {NavLink} from 'react-router-dom';
import {Button,Navbar,Nav} from 'react-bootstrap';
import { SignUpModal } from './SignUpModal';
import { LoginModal } from './LoginModal';
import Logout from './Logout';

function Navigation() {
    const [showSignupModal, setShowSignup] = useState(false);
    const handleSignupShow = () => setShowSignup(true);
    const handleSignupClose = () => setShowSignup(false);
    const [show, setShow] = useState(false);
    const handleShow = () => setShow(true);
    const handleClose = () => setShow(false);
    return(
        <div>
            <Navbar bg="dark" expand="lg">
            <Navbar.Toggle aria-controls="basic-navbar-nav"/>
            <Navbar.Collapse id="basic-navbar-nav">
            <Nav>
            <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                Home
            </NavLink >
            <NavLink  className="d-inline p-2 bg-dark text-white" to="/personal">
                Personal Details Page
            </NavLink>
            <NavLink className="d-inline p-2 bg-dark text-white" to="/mypatients">
                My Patients
            </NavLink>
            <Button id="signup" className="d-inline p-2 bg-dark text-white" onClick={() => handleSignupShow}>
                Sign Up
            </Button>
            <Button id="login" className="d-inline p-2 bg-dark text-white" onClick={handleShow}>
                Login
            </Button>
            <Button id="logout" className="d-inline p-2 bg-dark text-white" onClick={console.log("")}>
                Logout
            </Button>
            </Nav>
            </Navbar.Collapse>
        </Navbar>
        <LoginModal onHide={handleClose}/>
        <SignUpModal onHide={handleSignupClose}/>
    </div>
    )
}

export default Navigation;