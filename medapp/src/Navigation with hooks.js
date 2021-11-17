import React from 'react';
import { useState } from 'react';
import {NavLink} from 'react-router-dom';
import {Button,Navbar,Nav} from 'react-bootstrap';
import { SignUpModal } from './SignUpModal';
import { LoginModal } from './LoginModal';
const currentUserSubject = JSON.parse(localStorage.getItem('currentUser'));

function Navigation() {
    const [showSignupModal, setShowSignup] = useState(false);
    const handleSignupShow = () => setShowSignup(true);
    const handleSignupClose = () => setShowSignup(false);
    const [show, setShow] = useState(false);
    const handleShow = () => setShow(true);
    const handleClose = () => setShow(false);
    
    if (!currentUserSubject || currentUserSubject === null){
        return(
            <div>
                <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                <h4><i className="fas fa-laptop-medical text-danger"></i></h4> 
                </NavLink >
                <Button id="signup" className="d-inline p-2 bg-dark text-white" onClick={() => handleSignupShow}>
                <i class="fas fa-user-plus"></i>Register
                </Button>
                <Button id="login" className="d-inline p-2 bg-dark text-white" onClick={handleShow}>
                <i class="fas fa-sign-in-alt"></i>Login
                </Button>
                </Nav>
                </Navbar.Collapse>
            </Navbar>
            <LoginModal onHide={handleClose}/>
            <SignUpModal onHide={handleSignupClose}/>
        </div>
        )}
    else if (currentUserSubject.userRole==="doctor") {
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
                <i class="fas fa-user-md"></i>My Details
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/mypatients">
                <i class="fas fa-clinic-medical"></i>My Patients
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/allpatients">
                <i class="fas fa-book-medical"></i>Patient list
                </NavLink>
                <Button id="logout" className="d-inline p-2 bg-dark text-white" onClick={console.log("")}>
                <i class="fas fa-sign-out-alt"></i>Logout
                </Button>
                </Nav>
                </Navbar.Collapse>
            </Navbar>
        </div>
        )

    }
    else if (currentUserSubject.userRole==="patient") {
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
                <i class="fas fa-user-injured"></i>My Details
                </NavLink>
                <Button id="logout" className="d-inline p-2 bg-dark text-white" onClick={console.log("")}>
                <i class="fas fa-sign-out-alt"></i>Logout
                </Button>
                </Nav>
                </Navbar.Collapse>
            </Navbar>
        </div>
        )
    }
    else { return "WOW! it's an error happening... marvelous!"} 

}

export default Navigation;