import { Modal, Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';
import { DoctorsPatient } from './DoctorsPatient';
import { NavLink } from 'react-router-dom';


function DoctorsOwnPatientsPage() {
    const [patientdetails, setDetails] = useState(null);
    //   const [show, setShow] = useState(false);
    //   const handleShow = () => setShow(true);
    //   const handleClose = () => setShow(false);
    const [key, id] = document.cookie.valueOf().split('=');

    useEffect(() => {
        getData();

        async function getData() {

            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + id + '/patients');
            const data = await response.json();
            setDetails(data);
        }

        

    }, [key, id, patientdetails]);
    if (patientdetails) {
        return (
            <div>
                <h1>My Patients</h1>
                <div className="patientdetails">
                    <div>
                        <Table className="mt-4" striped bordered hover size="sm">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Social Security Number</th>
                                    <th>Options</th>
                                </tr>
                            </thead>
                            <tbody>
                                {patientdetails.map(patient =>
                                    <tr key={patient.id}>
                                        <td>{patient.name}</td>
                                        <td>{patient.socialSecurityNumber}</td>
                                        <td>
                                            <Button className="mr-2" variant="info">
                                                <NavLink to="/">
                                                    Patient's page
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
export default DoctorsOwnPatientsPage;