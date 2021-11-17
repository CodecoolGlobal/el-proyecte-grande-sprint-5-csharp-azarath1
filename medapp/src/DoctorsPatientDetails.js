import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Modal, Table, Form } from 'react-bootstrap';
import { useLocation } from 'react-router-dom';
const currentUserSubject = JSON.parse(localStorage.getItem('currentUser'));


function DoctorsPatientDetails()  {
    let location = useLocation();
    const [idcookie, userTypecookie] = document.cookie.valueOf().split(";");
    const [key, id] = idcookie.split("=");
    const [patientmedications, setMedications] = useState(null);
    const [medicationDose, setMedicationDose] = useState(0);
    const [medicationNote, setMedicationNote] = useState("");
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    function handleClick(event) {
        event.preventDefault();
        handleShow();
    };

    async function handleNoteUpdate(event) {
        event.preventDefault();
        await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + currentUserSubject.id + '/medication/' + event.target.value + '/edit-note', {
            method: 'put',
            mode: 'cors',
            credentials: 'include',
            headers: {
                'Authorization': `Bearer ${currentUserSubject.token}`,
                'Access-Control-Allow-Credentials': 'true',
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify(
                medicationNote
            ),
        }).then(res => res.json())
            .then(res => console.log(res));
    };

    async function handleDelete(event) {
        event.preventDefault();
        await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + currentUserSubject.id + '/medication/' + event.target.value + '/delete', {
                method: 'delete',
                mode: 'cors',
                credentials: 'include',
                headers: {
                    'Authorization': `Bearer ${currentUserSubject.token}`,
                    'Access-Control-Allow-Credentials': 'true',
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
        })
            .then(res => res.json())
            .then(res => console.log(res));;
    };

    function handleNameUpdate(event) {

    };

    async function handleDoseUpdate(event) {
        event.preventDefault();
        await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + currentUserSubject.id + '/medication/' + event.target.value + '/edit-dosage', {
            method: 'put',
            mode: 'cors',
            credentials: 'include',
            headers: {
                'Authorization': `Bearer ${currentUserSubject.token}`,
                'Access-Control-Allow-Credentials': 'true',
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify(
                medicationDose
            ),
        }).then(res => res.json())
            .then(res => console.log(res));
    };


    //   const [show, setShow] = useState(false);
    //   const handleShow = () => setShow(true);
    //   const handleClose = () => setShow(false);

    useEffect(() => {
        getPatientMedications();


        async function getPatientMedications() {

            
            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + currentUserSubject.id + '/patients-medications/' + location.state.patientid+0, {headers:{Authorization: `Bearer ${currentUserSubject.token}`}});
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
                                                Update Medication
                                            </Button>
                                            <Button value={ medication.medicationID } variant="primary" onClick={handleDelete}>
                                                Delete Medication
                                            </Button>
                                        </td>
                                        <Modal show={show} onHide={handleClose}>
                                            <Modal.Header closeButton>
                                                <Modal.Title>Update Medication</Modal.Title>
                                            </Modal.Header>
                                            <Form>

                                                <Form.Group controlId="medicationname">
                                                    <Form.Label>Name of Medication</Form.Label>
                                                    <Form.Control type="text" name="name"
                                                        defaultValue={medication.name}
                                                        placeholder="name" />
                                                    <Button variant="primary" type="submit" onClick={ handleNameUpdate }>
                                                        Update Name
                                                    </Button>
                                                </Form.Group>

                                            </Form>

                                            <Form>
                                                <Form.Group controlId="medicationdose">
                                                    <Form.Label>Dose</Form.Label>
                                                    <Form.Control type="text" name="dose"
                                                        defaultValue={medication.dose}
                                                        placeholder="dose"
                                                        onChange={(event) => setMedicationDose( event.target.value )} />
                                                    <Button variant="primary" type="submit" value={ medication.medicationID} onClick={handleDoseUpdate}>
                                                        Update dose
                                                    </Button>
                                                </Form.Group>
                                            </Form>

                                            <Form>
                                                <Form.Group controlId="medicationnote">
                                                    <Form.Label>Doctor's note</Form.Label>
                                                    <Form.Control type="text" name="medicationnote"
                                                        defaultValue={medication.doctorNote}
                                                        placeholder="medicationnote"
                                                        onChange={(event) => setMedicationNote(event.target.value)} />
                                                    <Button variant="primary" type="submit" value={medication.medicationID} onClick={ handleNoteUpdate }>
                                                        Update note
                                                    </Button>
                                                </Form.Group>
                                            </Form>
                                                
                                            
                                            <Modal.Footer>
                                                <Button variant="secondary" onClick={handleClose}>
                                                    Close
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