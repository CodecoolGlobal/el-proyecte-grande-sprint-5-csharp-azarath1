import React,{Component} from 'react';
import {Table} from 'react-bootstrap';


export class PatientMedications extends Component{

    constructor(props){
        super(props);
        this.state={meddata:[]}
    }

    refreshList(){
         fetch(process.env.REACT_APP_BASE+'patient/'+this.props.patientid+'/medication',
                { method: 'GET',
                headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
                }})
            .then(response=>response.json())
            .then(data=>{
            this.setState({meddata:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    render(){
        const {meddata}=this.state;
        return(
            <div >
                <h2>Welcome!</h2>
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
                        {meddata.map(med=>
                            <tr key={med.date}>
                                <td>{med.date}</td>
                                <td>{med.name}</td>
                                <td>{med.dosage}</td>
                                <td>{med.doctorNotes}</td>
                            </tr>)}
                    </tbody>
                </Table>
                
            </div>
        )
    }
}