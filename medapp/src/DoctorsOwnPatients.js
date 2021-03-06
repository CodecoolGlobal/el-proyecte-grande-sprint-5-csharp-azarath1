import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';
import { getWithExpiry } from './LocalStorageTTLUtils';
const currentUserSubject = getWithExpiry();


function DoctorsOwnPatientsPage() {
    const [loginData] = useState(getWithExpiry())
    const [patientDetails, setDetails] = useState(null);
    const history = useHistory();


    function handleClick(event) {
        event.preventDefault();
        let id = event.target.value;
        let name = event.target.name;
        history.push("doctorspatient?id=" + id + "&name=" + name);
    }


    useEffect(() => {
        getData();

        async function getData() {
            if (!loginData) {
                setDetails(null)
            } else {
                const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + currentUserSubject.id + '/patients/' + 0, { headers: { Authorization: `Bearer ${currentUserSubject.token}` } });
                const data = await response.json();
                setDetails(data);
            }
        }
    }, [loginData]);
    if (patientDetails) {
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
                                {patientDetails.map(patient =>
                                    <tr key={patient.id}>
                                        <td>{patient.name}</td>
                                        <td>{patient.socialSecurityNumber}</td>
                                        <td>

                                            <Button className="mr-2" variant="info" value={patient.id} name={ patient.name } onClick={ handleClick }>
                                                    <i class="fas fa-search-plus"></i>View
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