import { useState, useEffect, } from 'react';
import { Table, Button } from 'react-bootstrap';
import { getWithExpiry } from './LocalStorageTTLUtils';



function AllPatientsPage() {
  const [loginData] = useState(getWithExpiry())
  const [patientDetails, setDetails] = useState(null);

  useEffect(() => {
    getData();

    async function getData() {
if(!loginData){
  setDetails(null)
}else{
      const response = await fetch('all-patients/'+ 0, {headers:{Authorization: `Bearer ${loginData.token}`}});
      const data = await response.json();
      setDetails(data);
    }
  }
  }, [loginData]);
  if(patientDetails){
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
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                    {patientDetails.map(patient=>
                            <tr key={patient.id}>
                                <td>{patient.name}</td>
                                <td>{patient.socialSecurityNumber}</td>
                                <td>
                                    <Button className="mr-2" value={patient.id} variant="success" onClick={putIntoPractice}>
                                    <i class="fas fa-user-plus"></i> Add to practice
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
  else{
    return (<div></div>)
  }
  
  
  
  function putIntoPractice(event) {
    event.preventDefault();
    const requestOptions = {
      method: 'PUT',
      credentials: 'include',
      mode: 'cors',
      headers:{
          'Authorization': `Bearer ${loginData.token}`,
          'Access-Control-Allow-Credentials': 'true',
          'Accept':'application/json',
          'Content-Type':'application/json'
      },
      body: JSON.stringify(event.target.value),
  };
  if(window.confirm('Are you sure you want to add this patient?')){
  fetch('doctor/'+loginData.id+'/register-patient/'+event.target.value, requestOptions)
      .then(async response => {
      const data = await response;
      alert("Sucessfuly added!")
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
export default AllPatientsPage;