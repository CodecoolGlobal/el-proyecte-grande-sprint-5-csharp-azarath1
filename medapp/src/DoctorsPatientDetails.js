import { Button } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';
import { NavLink, useLocation } from 'react-router-dom';

function DoctorsPatientDetails()  {
    let location = useLocation();
    const [userkey, type, id, _] = document.cookie.valueOf().split('=');
    const [patientdetails, setDetails] = useState(null);
    const [patientmedications, setMedications] = useState(null);
    //   const [show, setShow] = useState(false);
    //   const handleShow = () => setShow(true);
    //   const handleClose = () => setShow(false);

    useEffect(() => {
        getData();
        getPatientMedications();

        async function getData() {
            
            const response = await fetch(process.env.REACT_APP_BASE_URL_PATIENT + location.state.patientid + '/details');
            const data = await response.json();
            console.log(data);
            setDetails(data);
        }

        async function getPatientMedications() {
            console.log("ez az" + location.state.patientid);
            
            const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + id + '/patients-medications/' + location.state.patientid);
            const data = await response.json();
            console.log(data);
            setMedications(data);
        }



    }, [location.state.patientid, id], [userkey, type, _, id, patientdetails, patientmedications]);
    if (patientdetails && patientmedications) {
        console.log(patientdetails);
        console.log(patientmedications);
        return (
            <div>
                <h1>My Patient</h1>
                <div className="patientdetails">
                    <div>
                        <Table className="mt-4" striped bordered hover size="sm">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Social Security Number</th>
                                    <th>Date of birth</th>
                                    <th>Email</th>
                                    <th>Phone number</th>
                                </tr>
                            </thead>
                            <tbody>
                                
                                    <tr key={patientdetails.id}>
                                        <td>{patientdetails.name}</td>
                                        <td>{patientdetails.socialSecurityNumber}</td>
                                        <td>{patientdetails.dateOfBirth}</td>
                                        <td>{patientdetails.email}</td>
                                        <td>{patientdetails.phoneNumber}</td>
                                    </tr>
                            </tbody>
                        </Table>
                    </div>
                </div>
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