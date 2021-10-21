import React,{Component} from 'react';
import {Table, ButtonToolbar, Button} from 'react-bootstrap';
import {ChangePatientDetailsModal} from './ChangePatientDetailsModal';

export class PatientMedications extends Component{

    constructor(props){
        super(props);
        this.state={meddata:[], editModalShow:false}
    }

    refreshList(){
         fetch(process.env.REACT_APP_BASE+'patient/'+1+'/medication',
                { method: 'GET',
                headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
                }})
            .then(response=>response.json())
            .then(data=>{
            this.setState({meddata:data});
            console.log(data);
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    // componentDidUpdate(){
    //     this.refreshList();
    // }

    render(){
        // const {meddata, patientid}=this.state;
        let editModalClose=()=>this.setState({editModalShow:false});
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
                        {/* {meddata.map(dat=>
                            <tr key={dat.date}>
                                <td>{dat.date}</td>
                                <td>{dat.name}</td>
                                <td>{dat.dosage}</td>
                                <td>{dat.doctorNotes}</td>
                            </tr>)} */}
                    </tbody>
                </Table>
                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({editModalShow:true})}>
                    Change my details</Button>

                    <ChangePatientDetailsModal show={this.state.editModalShow}
                    onHide={editModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}