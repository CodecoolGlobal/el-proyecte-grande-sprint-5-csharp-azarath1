import { useState, useEffect } from 'react';

function PatientPage() {
  const [patientdetails, setDetails] = useState(null);

  // + adding the use
  useEffect(() => {
    getData();

    // we will use async/await to fetch this data
    async function getData() {
      const response = await fetch("https://localhost:5001/patient/"+2+"/details");
      const data = await response.json();

      // store the data into our patientdetails variable
      setDetails(data);
    }
  }, []); // <- you may need to put the setDetails function in this array
  if(patientdetails){
    return (
        <div>
          <h1>My Profile Details</h1>
            <div className="patientdetails">
                <div>
                  <h5>{patientdetails.name}</h5>
                  <p>Social Security Number: {patientdetails.socialSecurityNumber}</p>
                  <p>Date of Birth: {patientdetails.dateOfBirth}</p>
                  <p>E-mail address: {patientdetails.email}</p>
                  <p>Phone Number: {patientdetails.phoneNumber}</p>
                  <p>Username: {patientdetails.username}</p>
                </div>
            </div>
        </div>
      )
  }
  else{
    return (<div></div>)
  }
  
}
export default PatientPage;