import { useState, useEffect, } from 'react';
import { Modal, Button } from 'react-bootstrap';

function PatientPage() {
  const [patientdetails, setDetails] = useState(null);
  const [emailContact, setMail] = useState('');
  const [phoneContact, setPhone] = useState('');
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
      setMail(data.email);
      setPhone(data.phoneNumber);
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
                  <p><strong>E-mail address: </strong>{emailContact}</p>
                  <p><strong>Phone Number: </strong>{phoneContact}</p>
                  <p><strong>Username: </strong>{patientdetails.username}</p>
                </div>
                <Button variant="primary" onClick={handleShow}>
                   Change my contact info
                </Button>
                <Modal show={show}>
                  <Modal.Header closeButton={true} onClick={handleClose}>
                    <Modal.Title>Contact Info</Modal.Title>
                  </Modal.Header>
                  <Modal.Body>
                  <form action="submit">
                    <label htmlFor="email">Email:</label>
                    <br />
                    <input type="text" name="email" onChange={event => setMail(event.target.value)} placeholder={patientdetails.email}></input>
                    <br />
                    <label htmlFor="phoneNumber">Phone number:</label>
                    <br />
                    <input type="text" name="phone" onChange={event => setPhone(event.target.value)} placeholder={patientdetails.phoneNumber}></input>
                  </form>
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
    return (<div><h1>
      <div className="spinner-border text-danger" role="status">
      <span className="visually-hidden">Loading...</span>
      </div>
  </h1></div>)
  }


  async function saveEditedDetails() {
    try {
      fetch(process.env.REACT_APP_BASE_URL_PATIENT+id+"/edit-contacts",{
        method:'PUT',
        credentials: 'include',
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        body:JSON.stringify({   
          email: emailContact,
          phonenumber: phoneContact
        })
    })
    .then(res=>res.json())
    .then(alert("Saved Changes!"))
    } catch (error) {
      console.log(error);
    }  
  }  
}

export default PatientPage;


