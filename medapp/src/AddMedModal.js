import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class AddMedModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch('medicines',{
            method:'POST',
            credentials:'include',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                name:event.target.name.value,
                manufacturer:event.target.manufacturer.value,
                descriptionlink:event.target.descriptionLink.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert('Sucessfully Changed');
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
            Add Medicine
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
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
                            Add Medicine
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