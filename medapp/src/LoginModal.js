import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class LoginModal extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.state = { LoginOption: "doctor" }
    }

    handleChange(event) {
        this.setState({ LoginOption: event.target.value })
    }

    render() {
        const LoginLink = `/${this.state.LoginOption}Login`;
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
                            Select account type
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>

                        <Row>
                            <Col sm={6}>
                                <Form>
                                    <Form.Group>
                                        <select value={this.state.LoginOption} onChange={this.handleChange}>
                                            <option value="patient">Patient</option>
                                            <option value="doctor">Doctor</option>
                                        </select>
                                    </Form.Group>

                                    <Form.Group>
                                        <Link to={LoginLink} onClick={this.props.onHide}>Confirm</Link>
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