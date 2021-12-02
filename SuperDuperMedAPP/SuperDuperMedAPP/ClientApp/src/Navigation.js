import { React, useState } from 'react';
import { NavLink, useHistory } from "react-router-dom";
import { Navbar, Nav, CloseButton, Modal, Button, Form } from 'react-bootstrap';
import { getWithExpiry, Timer } from './LocalStorageTTLUtils';

function Navigation() {
    const currentUserSubject = getWithExpiry();
    const history = useHistory();

    const handleDoctorOption = () => { setSignupForDoctor(); setShowSignup(false); };
    const handlePatientOption = () => { setSignupForPatient(); setShowSignup(false); };
    const [showSignupModal, setShowSignup] = useState(false);
    const handleSignupShow = () => setShowSignup(true);
    const handleSignupClose = () => setShowSignup(false);

    function Logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        history.push("/");
        setTimeout(() => {
            window.location.reload();
        }, 1000);

    }


    function setSignupForDoctor() {
        window.location.href = "/doctorRegistration";
        setTimeout(() => {
            window.location.reload();
        }, 500);
    }

    function setSignupForPatient() {
        window.location.href = "/patientRegistration";
        setTimeout(() => {
            window.location.reload();
        }, 500);
    }

    if (!currentUserSubject || currentUserSubject === null) {
        return (
            <div className="navcontainer">
                <div className="modalcontainer">
                    <Modal
                        show={showSignupModal}
                        size="lg"
                        aria-labelledby="contained-modal-title-vcenter"
                        centered
                    >
                        <Modal.Header>
                            <Modal.Title id="contained-modal-title-vcenter">
                                Select account type
                            </Modal.Title>
                            <CloseButton onClick={handleSignupClose} />
                        </Modal.Header>
                        <Modal.Body>
                            <Form>
                                <Form.Group>
                                    <div className="d-grid gap-2 d-md-flex justify-content-md-center">
                                        <Button variant="btn btn-outline-success" className="btn-lg" onClick={handlePatientOption}><i className="fas fa-hospital-user"></i>Patient</Button>
                                        <Button variant="btn btn-outline-primary" className="btn-lg" onClick={handleDoctorOption}><i className="fas fa-user-md"></i>Doctor</Button>
                                    </div>
                                </Form.Group>
                            </Form>
                        </Modal.Body>
                    </Modal>
                </div>
                <Navbar className="navbar-dark bg-dark" expand="lg">
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav>
                            <NavLink className="d-inline p-2 bg-dark text-danger" to="/">
                                <h4><i className="fas fa-laptop-medical text-danger "></i>SuperDuperMedapp</h4>
                            </NavLink >
                            <NavLink className="d-inline p-2 bg-dark text-white" to="#" onClick={handleSignupShow} >
                                <i className="fas fa-user-plus"></i> Register
                            </NavLink >
                            <NavLink className="d-inline p-2 bg-dark text-white" to="/login">
                                <i className="fas fa-sign-in-alt"></i> Login
                            </NavLink >
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
            </div>
        )
    }
    else if (currentUserSubject.userRole === "doctor") {
        return (
            <div className="navcontainer">
                <Navbar className="navbar-dark bg-dark" expand="lg">
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav>
                            <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                                <h4><i className="fas fa-laptop-medical text-danger"></i></h4>
                            </NavLink >
                            <NavLink className="d-inline p-2 bg-dark text-white" to="/personal">
                                <i className="fas fa-user-md"></i> My Details
                            </NavLink>
                            <NavLink className="d-inline p-2 bg-dark text-white" to="/mypatients">
                                <i className="fas fa-clinic-medical"></i> My Patients
                            </NavLink>
                            <NavLink className="d-inline p-2 bg-dark text-white" to="/allpatients">
                                <i className="fas fa-book-medical"></i> Patient list
                            </NavLink>
                            <NavLink id="logout" className="d-inline p-2 bg-dark text-white" to="/" onClick={Logout}>
                                <i className="fas fa-sign-out-alt"></i> Logout
                            </NavLink>
                            <div id='session-timer'>
                                <Timer LT={currentUserSubject.expiry} />
                            </div>
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
            </div>
        )

    }
    else if (currentUserSubject.userRole === "patient") {
        return (
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
                <NavLink id="logout" className="d-inline p-2 bg-dark text-white" to="/" onClick={Logout}>
                <i className="fas fa-sign-out-alt"></i> Logout
                </NavLink>
                <div id='session-timer'>
                    <Timer LT={currentUserSubject.expiry} />
                </div>
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
        </h1></div>)
    }

}

export default Navigation;