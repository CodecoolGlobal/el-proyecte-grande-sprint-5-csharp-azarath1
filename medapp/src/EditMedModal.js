import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditMedModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_BASE_URL+'medicines/'+this.props.medid,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                medicineID:event.target.medicineID.value,
                name:event.target.name.value,
                manufacturer:event.target.manufacturer.value,
                descriptionlink:event.target.descriptionLink.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
        },
        (message)=>{
            alert('Saved Changes');
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
                        <Form.Label>medicine ID</Form.Label>
                        <Form.Control type="text" name="medicineID" required
                        disabled
                        defaultValue={this.props.medid} 
                        placeholder="medicineID"/>
                    </Form.Group>

                    <Form.Group controlId="name">
                        <Form.Label>Name of Medicine</Form.Label>
                        <Form.Control type="text" name="name" 
                        defaultValue={this.props.medname}
                        placeholder="name"/>
                    </Form.Group>

                    <Form.Group controlId="manufacturer">
                        <Form.Label>Manufacturer</Form.Label>
                        <Form.Control type="text" name="manufacturer"  
                        defaultValue={this.props.manufacturer}
                        placeholder="manufacturer"/>
                    </Form.Group>

                    <Form.Group controlId="descriptionLink">
                        <Form.Label>Description Link</Form.Label>
                        <Form.Control type="text" name="descriptionLink" 
                        defaultValue={this.props.descriptionlink}
                        placeholder="description link"
                        />
                    </Form.Group>

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
        <Button variant="danger" className='mt-5' onClick={this.props.onHide}>Close</Button>
    </Modal.Footer>

</Modal>

            </div>
        )
    }

}