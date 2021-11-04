import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';
import { NavLink, useLocation } from 'react-router-dom';

function DoctorsPatientDetails()  {
    let location = useLocation();
    const [idcookie, userTypecookie] = document.cookie.valueOf().split(";");
    const [key, id] = idcookie.split("=");
    const [patientmedications, setMedications] = useState(null);
    //   const [show, setShow] = useState(false);
    //   const handleShow = () => setShow(true);
    //   const handleClose = () => setShow(false);

    useEffect(() => {
        getPatientMedications();


        async function getPatientMedications() {
            console.log("ez az" + location.state.patientid);
            
            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + id + '/patients-medications/' + location.state.patientid);
            const data = await response.json();
            console.log(data);
            setMedications(data);
        }
    }, [], [key, id, patientmedications]);
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
                                            <Button className="mr-2" variant="info">
                                                <NavLink to={{
                                                    pathname: '/doctorspatient',
                                                    state: {
                                                        patientid: medication.id
                                                    }
                                                }}>
                                                    Edit Medication
                                                </NavLink>
                                            </Button>
                                        </td>
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