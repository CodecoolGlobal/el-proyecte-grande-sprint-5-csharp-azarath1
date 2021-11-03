import { useState, useEffect, } from 'react';
import { Table, Button } from 'react-bootstrap';

function AllPatientsPage() {
  const [patientdetails, setDetails] = useState(null);
  const [key, id] = document.cookie.valueOf().split('=');

  useEffect(() => {
    getData();

    async function getData() {

      const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR+id+'/all-patients');
      const data = await response.json();
      setDetails(data);
    }
  }, [key, id, patientdetails]);
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
                                    <Button className="mr-2" variant="info" onClick={putIntoPractice}>
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
  function putIntoPractice() {
    fetch(process.env.REACT_APP_BASE_URL_DOCTOR+id+'/register-patient',{
        method:'PUT',
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        body:JSON.stringify({
            doctorID: id
        })
    })
    .then(res=>res.json())
    .then((result)=>{
    },
    (message)=>{
        alert('Saved Changes');
    })
  }  
}
export default AllPatientsPage;