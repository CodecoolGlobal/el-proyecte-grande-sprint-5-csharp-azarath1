import { useState, useEffect, } from 'react';
import { Card, Button, Modal, Table } from 'react-bootstrap';
import { getWithExpiry } from './LocalStorageTTLUtils';
const currentUserSubject = JSON.parse(localStorage.getItem('currentUser'));



function PatientMedications() {
    const [meddata, setMeds] = useState(null);

    const [showNoteModal, setShowNoteModal] = useState(false);

    const handleCloseNoteModal = () => setShowNoteModal(false);
    const handleShowNoteModal = () => setShowNoteModal(true);

    function handleClickNoteModal(event) {
        event.preventDefault();
        handleShowNoteModal();
    };

    const [loginData] = useState(getWithExpiry())


    useEffect(() => {
        getData();

    async function getData() {
       
          const response = await fetch(process.env.REACT_APP_BASE_URL_PATIENT+loginData.id+'/medication/'+0, {headers:{Authorization: `Bearer ${loginData.token}`}});  
          const data = await response.json();
          console.log(data);
          setMeds(data);
        }

    }, [loginData]);
    if (meddata) {
        return(
            <div >
                <h4>Current medications:</h4>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Medicine</th>
                            <th>Dosage</th>
                            <th>Notes by the Doctor</th>
                        </tr>
                    </thead>
                    <tbody>
                        {meddata.map(dat=>
                            <tr key={dat.date}>
                                <td>{dat.date}</td>
                                <td><a href={dat.medicine.descriptionLink} target="_blank" rel="noreferrer">{dat.medicine.name}</a></td>
                                <td>{dat.dose}</td>
                                <td>
                                <Button style={{ margin: '10px' }}  variant="primary" onClick={handleClickNoteModal}>
                                    <i class="fas fa-edit"></i> See Note
                                </Button>     
                                </td>
                                <Modal show={showNoteModal} onHide={handleCloseNoteModal} scrollable={true}>
                                    <Modal.Header closeButton>
                                        <Modal.Title>Doctor's Note</Modal.Title>
                                    </Modal.Header>
                                    <Modal.Body>

                                        <Card>
                                            <Card.Body>{ dat.doctorNote }</Card.Body>
                                        </Card>
                                    </Modal.Body>
                                    <Modal.Footer>
                                        <Button variant="secondary" onClick={handleCloseNoteModal}>
                                            Close
                                        </Button>
                                    </Modal.Footer>

                                </Modal>
                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
    else {return (
        <div><h1>
        <div className="spinner-border text-danger" role="status">
        <span className="visually-hidden">Loading...</span>
        </div>
        </h1></div>
    )}
    
}

export default PatientMedications;