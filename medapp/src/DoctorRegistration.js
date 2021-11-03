//import React, { useState } from 'react';
import React, { Component } from 'react';



export class DoctorRegistration extends Component {

    constructor(props) {
        super(props);
        this.state = {
            registrationNumber: "99999999",
            name: "Your name",
            DateOfBirth: "1990-01-01",
            email: "youremail@email.com",
            phoneNumber: "999999999",
            userName: "Username",
            password: "Password"
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        if (event.target.name === "registrationNumber") {
            this.setState({ registrationNumber: event.target.value })
        }
        if (event.target.name === "name") {
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
        fetch('https://localhost:44314/doctor/register', {

            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify({
                "RegistrationNumber": this.state.registrationNumber,
                "Name": this.state.name,
                "DateOfBirth": this.state.DateOfBirth,
                "Email": this.state.email,
                "PhoneNumber": this.state.phoneNumber,
                "Username": this.state.userName,
                "HashPassword": this.state.password
            }),
        })
            .then(res => res.json())
            .then((result) => {
                console.log(result);
                alert('Sucessfully Changed');
            },
                (error) => {
                    console.log(error);
                    alert('Failed registration');
                })
    }

    render() {

        return (
            <form onSubmit={this.handleSubmit}>
                <div>
                <label>
                    Registration Number:
                    <input
                        name="registrationNumber"
                        type="textarea"
                        value={this.state.registrationNumber}
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
                            type="textarea"
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
                            onChange={this.handleInputChange} />
                    </label>
                </div>
                <br />
                <input type="submit" value="Submit" />
            </form>
        );
    }
}