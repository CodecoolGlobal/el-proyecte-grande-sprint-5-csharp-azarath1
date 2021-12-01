import { useState, useEffect, } from 'react';
import { Modal, Button } from 'react-bootstrap';
import { getWithExpiry } from './LocalStorageTTLUtils';

function PersonalDetails() {
  const [patientdetails, setDetails] = useState(null);
  const [doctordetails, setDoctorDetails] = useState(null);
  const [emailContact, setMail] = useState('');
  const [phoneContact, setPhone] = useState('');
  const [show, setShow] = useState(false);
  const handleShow = () => setShow(true);
  const handleClose = () => setShow(false);
  const [loginData,setLoginData] = useState(getWithExpiry())

  useEffect(() => {
    getData();

    async function getData() {
      if(!loginData){
        setDetails(null);
      }
      else if (loginData && loginData.userRole === "doctor"){
        const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR+loginData.id+"/details", {headers:{Authorization: `Bearer ${loginData.token}`}});  
        const data = await response.json();
        setDoctorDetails(data);
        setMail(data.email);
        setPhone(data.phoneNumber);
      }
      else {
        const response = await fetch(process.env.REACT_APP_BASE_URL_PATIENT+loginData.id+"/details", {headers:{Authorization: `Bearer ${loginData.token}`}});
        const data = await response.json();
        setDetails(data);
        setMail(data.email);
        setPhone(data.phoneNumber);
      }
      
    }
  }, [loginData]);
  if(patientdetails){
    return (
        <div>
          <h1>{patientdetails.name}</h1>
            <div className="userdetail">
                <div>
                  <p><strong>Social Security Number: </strong>{patientdetails.socialSecurityNumber}</p>
                  <p><strong>Date of Birth: </strong>{patientdetails.dateOfBirth}</p>
                  <p><strong>E-mail address: </strong>{emailContact}</p>
                  <p><strong>Phone Number: </strong>{phoneContact}</p>
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
  if(doctordetails){
    return (
        <div>
          <h1>{doctordetails.name}</h1>
            <div className="userdetail">
                <div>
                  <p><strong>Registration Number: </strong>{doctordetails.registrationNumber}</p>
                  <p><strong>Date of Birth: </strong>{doctordetails.dateOfBirth}</p>
                  <p><strong>E-mail address: </strong>{emailContact}</p>
                  <p><strong>Phone Number: </strong>{phoneContact}</p>
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
                    <input type="text" name="email" onChange={event => setMail(event.target.value)} placeholder={doctordetails.email}></input>
                    <br />
                    <label htmlFor="phoneNumber">Phone number:</label>
                    <br />
                    <input type="text" name="phone" onChange={event => setPhone(event.target.value)} placeholder={doctordetails.phoneNumber}></input>
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


  function saveEditedDetails() {
    setLoginData(getWithExpiry())
      const requestOptions = {
        method:'PUT',
        credentials: 'include',
        headers:{
            'Authorization': `Bearer ${loginData.token}`,
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        body:JSON.stringify({
          email: emailContact,
          phonenumber: phoneContact})
    };
    if (loginData.userRole === "patient") {
      fetch(process.env.REACT_APP_BASE_URL_PATIENT+loginData.id+"/edit-contacts", requestOptions)
        .then(async response => {
        const data = await response;
          if (!response.ok) {
            const error = (data && data.message) || response.status;
            return Promise.reject(error);
        }
    })
    .catch(error => {
        console.error('There was an error!', error);
      });
    }
    else {
      fetch(process.env.REACT_APP_BASE_URL_DOCTOR+loginData.id+"/edit-contacts", requestOptions)
        .then(async response => {
        const data = await response;
          if (!response.ok) {
            const error = (data && data.message) || response.status;
            return Promise.reject(error);
        }
    })
    .catch(error => {
        console.error('There was an error!', error);
    });
    }
    
  }
}

export default PersonalDetails;
