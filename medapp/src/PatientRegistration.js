import React, { Component } from 'react';
// import { Form, Button } from 'react-bootstrap';
// import { BehaviorSubject } from 'rxjs';
// const currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')));


export class PatientRegistration extends Component {

    constructor(props) {
        super(props);
        this.state = {
            socialSecurityNumber: 99999999,
            name: "Your name",
            DateOfBirth: "1990-01-01",
            email: "youremail@email.com",
            phoneNumber: 999999999,
            userName: "Username",
            password: "Password"
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
        fetch(process.env.REACT_APP_BASE_URL+'register/patient', {

            method: 'post',
            credentials: 'include',
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
                "HashPassword": this.state.password.toString(),
                "Role": 'patient'
            }),
        })
            .then(res => res.json())
            .then((result) => {
                localStorage.setItem('currentUser', JSON.stringify(result));
                // currentUserSubject.next(result);
                alert('Successfully registered');
            },
                (error) => {
                    alert('Failed registration');
                })
    }

    render() {
        
        return (
            <form onSubmit={this.handleSubmit}>
                <div>
                <label>
                    Social Security Number:
                </label>
                <br/>
                    <input
                        name="socialSecurityNumber"
                        type="number"
                        placeholder="000999000"
                        onChange={this.handleInputChange}
                         />
                </div>
                <div>
                <label>
                    Name:
                </label>
                <br/>
                    <input
                        name="name"
                        type="textarea"
                        placeholder="Example Béla"
                        onChange={this.handleInputChange} />
                </div>
                <div>
                <label>
                    Date of Birth:
                </label>
                <br/>
                    <input
                        name="dateOfBirth"
                        type="date"
                        placeholder="1991.01.01"
                        onChange={this.handleInputChange} />
                </div>
                <div>
                <label>
                    Email:
                </label>
                <br/>
                    <input
                        name="email"
                        type="textarea"
                        placeholder="mail@mail.com"
                        onChange={this.handleInputChange} />
                </div>
                <div>
                <label>
                    Phone Number:
                </label>
                <br/>
                    <input
                        name="phoneNumber"
                        type="textarea"
                        placeholder="+36304443333"
                        onChange={this.handleInputChange} />
                </div>
                <div>
                <label>
                    Username:
                </label>
                <br/>
                    <input
                        name="username"
                        type="textarea"
                        placeholder="SnoopDoge"
                        onChange={this.handleInputChange} />
                </div>
                <div>
                <label>
                    Password:
                </label>
                <br/>
                    <input
                        name="password"
                        type="password"
                        onChange={this.handleInputChange}
                        />
                </div>
                <br />
                <input type="submit" value="Submit" />
            </form>
        );
    }
}