import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
const currentUserSubject = JSON.parse(localStorage.getItem('currentUser'));


function DoctorsOwnPatientsPage() {
    const [patientdetails, setDetails] = useState(null);


    useEffect(() => {
        getData();

        async function getData() {
            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + currentUserSubject.id + '/patients/'+0,{headers:{Authorization: `Bearer ${currentUserSubject.token}`}});
            const data = await response.json();
            setDetails(data);
        }
    }, []);
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
                                                    <i class="fas fa-search-plus"></i> View
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