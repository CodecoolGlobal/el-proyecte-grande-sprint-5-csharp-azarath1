import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Modal, Table } from 'react-bootstrap';
import { NavLink, useLocation } from 'react-router-dom';

function DoctorsPatientDetails()  {
    let location = useLocation();
    const [idcookie, userTypecookie] = document.cookie.valueOf().split(";");
    const [key, id] = idcookie.split("=");
    const [patientmedications, setMedications] = useState(null);
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    function handleClick(event) {
        event.preventDefault();
        handleShow();
        console.log(event.target);
    };

    let medicationName;
    let medicationDose;
    let medicationNote;
    //   const [show, setShow] = useState(false);
    //   const handleShow = () => setShow(true);
    //   const handleClose = () => setShow(false);

    useEffect(() => {
        getPatientMedications();


        async function getPatientMedications() {

            
            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + id + '/patients-medications/' + location.state.patientid, {credentials:'include'});
            const data = await response.json();

            setMedications(data);
        }
    }, [key, id, patientmedications, userTypecookie, location.state.patientid], [key, id, patientmedications, userTypecookie]);
    if (patientmedications) {
        return (
            <div>
                <h1>Medications</h1>
                <div className = "patientMedications">
                    <div>
                        <Table className="mt-4" striped bordered hover size="sm">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Dose</th>
                                    <th>Doctor's note</th>
                                </tr>
                            </thead>
                            <tbody>
                                {patientmedications.map(medication =>
                                    <tr key={medication.medicationID}>
                                        <td>{medication.name}</td>
                                        <td>{medication.dose}</td>
                                        <td>{medication.doctorNote}</td>
                                        <td>
                                            <Button medicationname={medication.name} medicationdose={medication.dose} doctornote={ medication.doctorNote} variant="primary" onClick={handleClick}>
                                                Launch demo modal
                                            </Button>
                                        </td>
                                        <Modal show={show} onHide={handleClose}>
                                            <Modal.Header closeButton>
                                                <Modal.Title>Modal heading</Modal.Title>
                                            </Modal.Header>
                                            <Modal.Body>{ medication.name }</Modal.Body>
                                            <Modal.Footer>
                                                <Button variant="secondary" onClick={handleClose}>
                                                    Close
                                                </Button>
                                                <Button variant="primary" onClick={handleClose}>
                                                    Save Changes
                                                </Button>
                                            </Modal.Footer>
                                        </Modal>
                                    </tr>)}
                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>           
        )
    }
    else {
        return (<div></div>)
    }
}
export default DoctorsPatientDetails;