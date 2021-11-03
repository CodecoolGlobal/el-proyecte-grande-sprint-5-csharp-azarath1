import { Modal, Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';


function DoctorsOwnPatientsPage() {
    const [patientdetails, setDetails] = useState(null);
    //   const [show, setShow] = useState(false);
    //   const handleShow = () => setShow(true);
    //   const handleClose = () => setShow(false);
    const [key, id] = document.cookie.valueOf().split('=');

    useEffect(() => {
        getData();

        async function getData() {

            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + id + '/all-patients');
            const data = await response.json();
            setDetails(data);
        }
    }, [key, id, patientdetails]);
    if (patientdetails) {
        return (
            <div>
                <h1>All Patients</h1>
                <div className="patientdetails">
                    <div>
                        <Table className="mt-4" striped bordered hover size="sm">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Social Security Number</th>
                                </tr>
                            </thead>
                            <tbody>
                                {patientdetails.map(patient =>
                                    <tr key={patient.id}>
                                        <td>{patient.name}</td>
                                        <td>{patient.socialSecurityNumber}</td>
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