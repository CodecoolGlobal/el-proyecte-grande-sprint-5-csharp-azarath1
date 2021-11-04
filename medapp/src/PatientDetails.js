import { useState, useEffect, } from 'react';
import { Modal, Button } from 'react-bootstrap';

function PatientPage() {
  const [patientdetails, setDetails] = useState(null);
  const [show, setShow] = useState(false);
  const handleShow = () => setShow(true);
  const handleClose = () => setShow(false);

  const [userkey, type, id, _] = document.cookie.valueOf().split('=');

  useEffect(() => {
    getData();

    async function getData() {

      const response = await fetch(process.env.REACT_APP_BASE_URL_PATIENT+id+"/details", {credentials:'include'});
      const data = await response.json();
      setDetails(data);
      console.log(type.split(";")[0]);
    }
  }, [userkey, type, id, _]);
  if(patientdetails){
    return (
        <div>
          <h1>My Profile Details</h1>
            <div className="patientdetails">
                <div>
                  <h5>{patientdetails.name}</h5>
                  <p><strong>Social Security Number: </strong>{patientdetails.socialSecurityNumber}</p>
                  <p><strong>Date of Birth: </strong>{patientdetails.dateOfBirth}</p>
                  <p><strong>E-mail address: </strong>{patientdetails.email}</p>
                  <p><strong>Phone Number: </strong>{patientdetails.phoneNumber}</p>
                  <p><strong>Username: </strong>{patientdetails.username}</p>
                </div>
                <Button variant="primary" onClick={handleShow}>
                   Change my details
                </Button>
                <Modal show={show}>
                  <Modal.Header closeButton={true} onClick={handleClose}>
                    <Modal.Title>My Details</Modal.Title>
                  </Modal.Header>
                  <Modal.Body>
                    <p></p>
                  </Modal.Body>
                  <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>Close</Button>
                    <Button variant="success" type="submit" onClick={() => {saveEditedDetails(); handleClose();}}>Save Changes</Button>
                  </Modal.Footer>
                </Modal>
            </div>
        </div>
      )
  }
  else{
    return (<div></div>)
  }
  function saveEditedDetails() {
    console.log(_);
  }  
}

export default PatientPage;


