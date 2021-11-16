import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';


function DoctorsOwnPatientsPage() {
    const [patientdetails, setDetails] = useState(null);
    //   const [show, setShow] = useState(false);
    //   const handleShow = () => setShow(true);
    //   const handleClose = () => setShow(false);
    const [idcookie, userTypecookie] = document.cookie.valueOf().split(";");
    const [key, id] = idcookie.split("=");

    useEffect(() => {
        getData();

        async function getData() {
            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + id + '/patients/1',{credentials:'include'});
            const data = await response.json();
            setDetails(data);
        }
    }, [id, userTypecookie, key]);
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
                                                <NavLink to={{
                                                    pathname: '/doctorspatient',
                                                    state: {
                                                        patientid: patient.id }
                                                }}>
                                                    View patient data
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