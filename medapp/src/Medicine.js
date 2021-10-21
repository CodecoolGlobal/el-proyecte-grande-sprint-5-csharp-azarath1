import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddMedModal} from './AddMedModal';
import {EditMedModal} from './EditMedModal';

export class Medicine extends Component{

    constructor(props){
        super(props);
        this.state={meds:[], addModalShow:false, editModalShow:false}
    }

    refreshList(){
        fetch('https://localhost:44314/api/medicines',
                { method: 'GET',
                headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
                }})
            .then(response=>response.json())
            .then(data=>{
            this.setState({meds:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteMed(medid){
        if(window.confirm('Are you sure?')){
            fetch(process.env.REACT_APP_BASE_URL+'medicines/'+medid,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            })
        }
    }
    render(){
        const {meds, medid, medname, manufacturer, descriptionlink}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>medicineID</th>
                            <th>name</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {meds.map(med=>
                            <tr key={med.medicineID}>
                                <td>{med.medicineID}</td>
                                <td>{med.name}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button className="mr-2" variant="info"
                                    onClick={()=>this.setState({editModalShow:true,
                                        medid:med.medicineID,medname:med.name,manufacturer:med.manufacturer,descriptionlink:med.descriptionLink})}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                    onClick={()=>this.deleteMed(med.medicineID)}>
                                            Delete
                                        </Button>

                                        <EditMedModal show={this.state.editModalShow}
                                        onHide={editModalClose}
                                        medid={medid}
                                        medname={medname}
                                        manufacturer={manufacturer}
                                        descriptionlink={descriptionlink}
                                        />
                                </ButtonToolbar>
                            </td>
                        </tr>)}
                    </tbody>
                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Medicine</Button>

                    <AddMedModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}