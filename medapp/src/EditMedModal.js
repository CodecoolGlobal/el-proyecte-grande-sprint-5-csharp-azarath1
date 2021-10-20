import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditMedModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_BASE_URL+'medicine/'+this.props.medid,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                medicineID:event.target.medicineID.value,
                name:event.target.name.value,
                // manufacturer:event.target.manufacturer.value,
                // descriptionLink:event.target.descriptionLink.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            console.log(result);
        },
        (error)=>{
            alert('Failed');
        })
    }
    render(){
        return (
            <div className="container">

<Modal
{...this.props}
size="lg"
aria-labelledby="contained-modal-title-vcenter"
centered
>
    <Modal.Header closeButton={true}>
        <Modal.Title id="contained-modal-title-vcenter">
            Edit Medicine
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                <Form.Group controlId="medicineID">
                        <Form.Label>medicineID</Form.Label>
                        <Form.Control type="text" name="medicineID" required
                        disabled
                        defaultValue={this.props.medid} 
                        placeholder="medicineID"/>
                    </Form.Group>

                    <Form.Group controlId="name">
                        <Form.Label>name</Form.Label>
                        <Form.Control type="text" name="name" required 
                        defaultValue={this.props.medname}
                        placeholder="name"/>
                    </Form.Group>

                    {/* <Form.Group controlId="manufacturer">
                        <Form.Label>manufacturer</Form.Label>
                        <Form.Control type="text" name="manufacturer" required 
                        defaultValue={this.props.manufacturer}
                        placeholder="manufacturer"/>
                    </Form.Group>

                    <Form.Group controlId="descriptionLink">
                        <Form.Label>descriptionLink</Form.Label>
                        <Form.Control type="text" name="descriptionLink" required 
                        defaultValue={this.props.descriptionLink}
                        placeholder="descriptionLink"/>
                    </Form.Group> */}

                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Update Medicine
                        </Button>
                    </Form.Group>
                </Form>
            </Col>
        </Row>
    </Modal.Body>
    
    <Modal.Footer>
        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
    </Modal.Footer>

</Modal>

            </div>
        )
    }

}