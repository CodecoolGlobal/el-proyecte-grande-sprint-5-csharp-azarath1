import React,{Component} from 'react';
import { Form, Button } from 'react-bootstrap';


export class PatientRegistration extends Component{

    constructor(props) {
        super(props);
        this.state = {
            socialSecurityNumber: 0,
            name: "asd",
            email: "youremail@gmail.com",
            phoneNumber: 67067700670,
            userName: "u name",
            password: "your password"
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        if (event.target.name === "socialSecurityNumber") {
            this.setState({ socialSecurityNumber: event.target.value })
        }
        else if (event.target.name === "name") {
            this.setState({ name: event.target.value })
        }
        else if (event.target.name === "email") {
            this.setState({ email: event.target.value })
        }
        else if (event.target.name === "phoneNumber") {
            this.setState({ phoneNumber: event.target.value })
        }
        else if (event.target.name === "userName") {
            this.setState({ userName: event.target.value })
        }
        else if (event.target.name === "password") {
            this.setState({ password: event.target.value })
        }
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch('https://localhost:44314/Patient/Create',{
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "socialSecurityNumber": this.state.socialSecurityNumber,
                "name": this.state.name,
                "email": this.state.email,
                "phoneNumber": this.state.phoneNumber,
                "userName": this.state.userName,
                "password": this.state.password
            })
        })
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Social Security Number:
                    <input
                        name="socialSecurityNumber"
                        type="number"
                        value={this.state.socialSecurityNumber}
                        onChange={this.handleInputChange} />
                </label>
                <br />
                <label>
                    Name:
                    <input
                        name="name"
                        type="textarea"
                        value={this.state.name}
                        onChange={this.handleInputChange} />
                </label>
                <br />
                <label>
                    Email:
                    <input
                        name="email"
                        type="textarea"
                        value={this.state.email}
                        onChange={this.handleInputChange} />
                </label>
                <br />
                <label>
                    Phone Number:
                    <input
                        name="phoneNumber"
                        type="number"
                        value={this.state.phoneNumber}
                        onChange={this.handleInputChange} />
                </label>
                <br />
                <label>
                    Username:
                    <input
                        name="Username"
                        type="textare"
                        value={this.state.userName}
                        onChange={this.handleInputChange} />
                </label>
                <br />
                <label>
                    Password:
                    <input
                        name="password"
                        type="textarea"
                        value={this.state.password}
                        onChange={this.handleInputChange} />
                </label>
                <br/>
                <input type="submit" value="Submit" />
            </form>
        );
    }
}