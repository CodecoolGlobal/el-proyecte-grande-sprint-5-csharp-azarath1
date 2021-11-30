import { useState, useEffect, } from 'react';
import {Table} from 'react-bootstrap';
import { getWithExpiry } from './LocalStorageTTLUtils';


function PatientMedications() {
    const [meddata, setMeds] = useState(null);
    const [loginData] = useState(getWithExpiry())

    useEffect(() => {
        getData();

    async function getData() {
       
          const response = await fetch(process.env.REACT_APP_BASE_URL_PATIENT+loginData.id+'/medication/'+0, {headers:{Authorization: `Bearer ${loginData.token}`}});  
          const data = await response.json();
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
                            <th>Title</th>
                            <th>Dosage</th>
                            <th>Notes by the Doctor</th>
                        </tr>
                    </thead>
                    <tbody>
                        {meddata.map(dat=>
                            <tr key={dat.date}>
                                <td>{dat.date}</td>
                                <td>{dat.name}</td>
                                <td>{dat.dose}</td>
                                <td>{dat.doctorNote}</td>
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