import { useState, useEffect, } from 'react';
import { Table, Button } from 'react-bootstrap';

function AllPatientsPage() {
  const [patientdetails, setDetails] = useState(null);
  const [idcookie, userTypecookie] = document.cookie.valueOf().split(";");
  const [key, doctorId] = idcookie.split("=");

  useEffect(() => {
    getData();

    async function getData() {
      const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR+doctorId+'/all-patients/'+0, {credentials:'include'});
      const data = await response.json();
      setDetails(data);
    }
  }, [key, userTypecookie, doctorId]);
  if(patientdetails){
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
                    {patientdetails.map(patient=>
                            <tr key={patient.id}>
                                <td>{patient.name}</td>
                                <td>{patient.socialSecurityNumber}</td>
                                <td>
                                    <Button className="mr-2" value={patient.id} variant="info" onClick={putIntoPractice}>
                                        Put into practice
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
          'Access-Control-Allow-Credentials': 'true',
          'Accept':'application/json',
          'Content-Type':'application/json'
      },
      body: JSON.stringify(event.target.value),
  };
  fetch(process.env.REACT_APP_BASE_URL_DOCTOR+doctorId+'/register-patient', requestOptions)
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
export default AllPatientsPage;