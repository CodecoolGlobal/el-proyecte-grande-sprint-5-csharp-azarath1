import React from 'react';
import { useState } from 'react';
import { useHistory } from "react-router-dom";
import {NavLink} from 'react-router-dom';
import {Navbar,Nav} from 'react-bootstrap';
import { SignUpModal } from './SignUpModal';
import { LoginModal } from './LoginModal';
import{getWithExpiry} from './LocalStorageTTLUtils.js';

function Navigation() {
    const currentUserSubject = getWithExpiry();
    const history = useHistory();

    const [showSignupModal, setShowSignup] = useState(false);
    const [show, setShow] = useState(false);

    const handleSignupShow = () => setShowSignup(true);
    const handleShow = () => setShow(true);

    const handleClose = () => setShow(false);
    const handleSignupClose = () => setShowSignup(false);
    
    function Logout() {
            // remove user from local storage to log user out
            localStorage.removeItem('currentUser');
            history.push("/");
                setTimeout(() => {
                    window.location.reload();    
                  }, 1000);
            
    }

    
    if (!currentUserSubject || currentUserSubject === null){
        return(
            <div className="navcontainer">
                <div className="modalcontainer">
                <LoginModal show={show} onHide={handleClose}/>
                <SignUpModal show={showSignupModal} onHide={handleSignupClose}/>
                </div>
                <Navbar className="navbar-dark bg-dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav>
                            <NavLink className="d-inline p-2 bg-dark text-danger" to="/">
                            <h4><i className="fas fa-laptop-medical text-danger "></i>SuperDuperMedapp</h4>
                            </NavLink >
                            <NavLink className="d-inline p-2 bg-dark text-white" to="#" onClick={handleSignupShow} >
                            <i className="fas fa-user-plus"></i> Register
                            </NavLink >
                            <NavLink className="d-inline p-2 bg-dark text-white" to="#" onClick={handleShow} >
                            <i className="fas fa-sign-in-alt"></i> Login
                            </NavLink >
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
            </div>
        )}
    else if (currentUserSubject.userRole==="doctor") {
        return(
            <div className="navcontainer">
                <Navbar className="navbar-dark bg-dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                <h4><i className="fas fa-laptop-medical text-danger"></i></h4> 
                </NavLink >
                <NavLink  className="d-inline p-2 bg-dark text-white" to="/personal">
                <i className="fas fa-user-md"></i> My Details
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/mypatients">
                <i className="fas fa-clinic-medical"></i> My Patients
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/allpatients">
                <i className="fas fa-book-medical"></i> Patient list
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/" onClick={Logout}>
                <i className="fas fa-sign-out-alt"></i> Logout
                </NavLink>
                </Nav>
                </Navbar.Collapse>
            </Navbar>
        </div>
        )

    }
    else if (currentUserSubject.userRole==="patient") {
        return(
            <div className="navcontainer">
                <Navbar className="navbar-dark bg-dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                <h4><i className="fas fa-laptop-medical text-danger"></i></h4> 
                </NavLink >
                <NavLink  className="d-inline p-2 bg-dark text-white" to="/personal">
                <i className="fas fa-user-injured"></i> My Details
                </NavLink>
                <NavLink  className="d-inline p-2 bg-dark text-white" to="/mymedications">
                <i className="fas fa-tablets"></i> My Medications
                </NavLink>
                <NavLink className="d-inline p-2 bg-dark text-white" to="/" onClick={Logout}>
                <i className="fas fa-sign-out-alt"></i> Logout
                </NavLink>
                </Nav>
                </Navbar.Collapse>
            </Navbar>
        </div>
        )
    }
    else { 
        return (<div><h1>
        <div className="spinner-border text-danger" role="status">
        <span className="visually-hidden">Loading...</span>
        </div>
        </h1></div>)} 

}

export default Navigation;