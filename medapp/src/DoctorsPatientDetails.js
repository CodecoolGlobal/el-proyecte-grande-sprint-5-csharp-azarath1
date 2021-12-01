import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Card, Modal, Table, Form } from 'react-bootstrap';
import { useLocation } from 'react-router-dom';
import { getWithExpiry } from './LocalStorageTTLUtils';
const currentUserSubject = getWithExpiry();


function DoctorsPatientDetails()  {
    //let location = useLocation();
    let patientid = useQuery().get('id');
    const [patientmedications, setMedications] = useState(null);
    const [medicines, setMedicines] = useState(null);
    const [medicineID, setMedicineID] = useState(1);
    const [medicationName, setMedicationName] = useState(null);
    const [medicationDose, setMedicationDose] = useState(0);
    const [medicationNote, setMedicationNote] = useState("");
    const [showEditModal, setShowEditModal] = useState(false);
    const [showAddModal, setShowAddModal] = useState(false);

    const handleCloseEditModal = () => window.location.reload();
    const handleShowEditModal = () => setShowEditModal(true);
    const handleCloseAddModal = () => window.location.reload();
    const handleShowAddModal = () => setShowAddModal(true);


    function useQuery() {
        return new URLSearchParams(window.location.search);
    }

    function handleClickEditModal(event) {
        event.preventDefault();
        handleShowEditModal();
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

    function handleClickAddMedication(event) {
        event.preventDefault();
        handleShowAddModal();
    };

    async function handleAddMedication(event) {
        event.preventDefault();
        console.log(medicineID);
        console.log(medicationName);
        console.log(medicationDose);
        console.log(medicationNote);
        await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + currentUserSubject.id + '/medication/add', {
            method: 'post',
            mode: 'cors',
            credentials: 'include',
            headers: {
                'Authorization': `Bearer ${currentUserSubject.token}`,
                'Access-Control-Allow-Credentials': 'true',
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify({
                "Name": medicationName,
                "Dose": medicationDose,
                "DoctorNote": medicationNote,
                "PatientID": patientid,
                "MedicineID": medicineID
            }),
        }).then(res => res.json())
            .then(res => console.log(res));
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

    

    

    useEffect(() => {
        getPatientMedications();
        getMedicines();

        async function getPatientMedications() {

            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + currentUserSubject.id + '/patients-medications/' + patientid + "/" + 0, { headers: { Authorization: `Bearer ${currentUserSubject.token}` } });

            const data = await response.json();

            setMedications(data);
        }

        async function getMedicines() {

            const response = await fetch(process.env.REACT_APP_BASE_URL + 'medicine', {
                mode: 'cors',
                credentials: 'include',
                method: 'GET',
                headers: {
                    Authorization: `Bearer ${currentUserSubject.token}`
                }

            });

            const data = await response.json();

            setMedicines(data);
        }



    }, [] );
    if (patientmedications && medicines) {
        return (
            <div>
                <div className="flex-container">
                    <h1 className="flex-child">Medications</h1>
                    <Button className="flex-child" id="logout" variant="success" onClick={handleClickAddMedication}>
                        <i className="fas fa-hand-holding-medical"></i> Add Medication
                    </Button>
                </div>
                
                
                <div className = "patientMedications">
                    <div>
                        <Table className="mt-4" striped bordered hover size="sm">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Dose</th>
                                    <th>Doctor's note</th>
                                    <th>Options</th>
                                </tr>
                            </thead>
                            <tbody>
                                {patientmedications.map(medication =>
                                    <tr key={medication.medicationID}>
                                        <td width="25%">{medication.name}</td>
                                        <td width="25%">{medication.dose}</td>
                                        <td width="25%">
                                            <Card style={{ width: '18rem' }}>
                                                <Card.Body>{medication.doctorNote}</Card.Body>
                                            </Card>
                                        </td>
                                        <td width="25%">
                                            <Button style={{ margin: '10px' }} medicationname={medication.name} medicationdose={medication.dose} doctornote={ medication.doctorNote} variant="primary" onClick={handleClickEditModal}>
                                            <i class="fas fa-edit"></i> Edit
                                            </Button>                                            
                                            <Button value={ medication.medicationID } variant="danger" onClick={handleDelete}>
                                            <i class="fas fa-trash-alt"></i> Delete
                                            </Button>
                                        </td>
                                        <Modal show={showEditModal} onHide={handleCloseEditModal}>
                                            <Modal.Header closeButton>
                                                <Modal.Title>Update Medication</Modal.Title>
                                            </Modal.Header>


                                            <Form>
                                                <Form.Group controlId="medicationdose">
                                                    <Form.Label>Dose</Form.Label>
                                                    <Form.Control type="text" name="dose"
                                                        defaultValue={medication.dose}
                                                        placeholder="dose"
                                                        onChange={(event) => setMedicationDose(event.target.value)} />
                                                    <Button style={{ marginTop: '10px' }} variant="primary" type="submit" value={medication.medicationID} onClick={handleDoseUpdate}>
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
                                                    <Button style={{ marginTop: '10px' }} variant="primary" type="submit" value={medication.medicationID} onClick={handleNoteUpdate}>
                                                        Update note
                                                    </Button>
                                                </Form.Group>
                                            </Form>
                                                
                                            
                                            <Modal.Footer>
                                                <Button variant="secondary" onClick={handleCloseEditModal}>
                                                    Close
                                                </Button>
                                            </Modal.Footer>
                                        </Modal>
                                    </tr>)}
                            </tbody>
                        </Table>
                        
                            <Modal show={showAddModal} onHide={handleCloseAddModal}>
                                <Modal.Header closeButton>
                                    <Modal.Title>Add Medication</Modal.Title>
                                </Modal.Header>

                                <Form>

                                    <Form.Group controlId="medicationname">
                                        <Form.Label>Name of Medication</Form.Label>
                                    <Form.Control type="text" name="name"
                                        onChange={(event) => setMedicationName(event.target.value)} />
                                    </Form.Group>

                                    <Form.Group controlId="medicinename">
                                        <Form.Label>Medicine</Form.Label>
                                    <Form.Select aria-label="Default select example" onChange={(event) => setMedicineID(event.target.value)}>
                                        {medicines.map(medicine =>
                                            <option value={medicine.medicineID}>{ medicine.name}</option>
                                        )}
                                        </Form.Select>
                                    </Form.Group>

                                    <Form.Group controlId="medicationdose">
                                        <Form.Label>Dose</Form.Label>
                                    <Form.Control type="text" name="dose"
                                        onChange={(event) => setMedicationDose(event.target.value)} />
                                    </Form.Group>


                                    <Form.Group controlId="medicationnote">
                                        <Form.Label>Doctor's note</Form.Label>
                                    <Form.Control type="text" name="medicationnote"
                                        onChange={(event) => setMedicationNote(event.target.value)} />
                                    </Form.Group>


                                </Form>

                                <Modal.Footer>
                                    <Button variant="success" onClick={handleAddMedication}>
                                    <i class="fas fa-hand-holding-medical"></i> Add Medication
                                    </Button>
                                </Modal.Footer>

                                <Modal.Footer>
                                    <Button variant="secondary" onClick={handleCloseAddModal}>
                                        Close
                                    </Button>
                                </Modal.Footer>
                            </Modal>
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