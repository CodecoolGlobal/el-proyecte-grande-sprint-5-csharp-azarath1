import React, { Component } from 'react';
// import { Form, Button } from 'react-bootstrap';


export class PatientRegistration extends Component {

    constructor(props) {
        super(props);
        this.state = {
            socialSecurityNumber: 0,
            name: "asd",
            DateOfBirth: "1990-01-01",
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
        else if (event.target.name === "dateOfBirth") {
            this.setState({ DateOfBirth: event.target.value })
        }
        else if (event.target.name === "email") {
            this.setState({ email: event.target.value })
        }
        else if (event.target.name === "phoneNumber") {
            this.setState({ phoneNumber: event.target.value })
        }
        else if (event.target.name === "username") {
            this.setState({ userName: event.target.value })
        }
        else if (event.target.name === "password") {
            this.setState({ password: event.target.value })
        }
        //alert(this.state.socialSecurityNumber+this.state.name+this.state.DateOfBirth+this.state.email+this.state.phoneNumber+this.state.userName+this.state.password)
    }

    handleSubmit(event) {
        event.preventDefault();
        fetch(process.eng.REACT_APP_BASE_URL_PATIENT+'register', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "SocialSecurityNumber": parseInt(this.state.socialSecurityNumber),
                "Name": this.state.name.toString(),
                "DateOfBirth": this.state.DateOfBirth.toString(),
                "Email": this.state.email.toString(),
                "PhoneNumber": this.state.phoneNumber.toString(),
                "Username": this.state.userName.toString(),
                "HashPassword": this.state.password.toString()
            }),
        })
            .then(res => res.json())
            .then((result) => {
                console.log(result);
                alert('Sucessfully Changed');
            },
                (error) => {
                    alert('Succesful registration!');
                })
    }

    render() {
        
        return (
            <form onSubmit={this.handleSubmit}>
                <div>
                <label>
                    Social Security Number:
                    <input
                        name="socialSecurityNumber"
                        type="number"
                        value={this.state.socialSecurityNumber}
                        onChange={this.handleInputChange} />
                </label>
                </div>
                <div>
                <label>
                    Name:
                    <input
                        name="name"
                        type="textarea"
                        value={this.state.name}
                        onChange={this.handleInputChange} />
                </label>
                </div>

                <div>
                <label>
                    Date of Birth:
                    <input
                        name="dateOfBirth"
                        type="textarea"
                        value={this.state.DateOfBirth}
                        onChange={this.handleInputChange} />
                </label>
                </div>
                <div>
                <label>
                    Email:
                    <input
                        name="email"
                        type="textarea"
                        value={this.state.email}
                        onChange={this.handleInputChange} />
                </label>
                </div>
                <div>
                <label>
                    Phone Number:
                    <input
                        name="phoneNumber"
                        type="number"
                        value={this.state.phoneNumber}
                        onChange={this.handleInputChange} />
                </label>
                </div>
                <div>
                <label>
                    Username:
                    <input
                        name="username"
                        type="textarea"
                        value={this.state.userName}
                        onChange={this.handleInputChange} />
                </label>
                </div>
                <div>
                <label>
                    Password:
                    <input
                        name="password"
                        type="textarea"
                        value={this.state.password}
                </label>
                </div>
                <br />
                <input type="submit" value="Submit" />
            </form>
        );
    }
}