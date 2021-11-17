import React, { Component } from 'react';
import { BehaviorSubject } from 'rxjs';
const currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')));

export class DoctorLogin extends Component {
    

    constructor(props) {
        super(props);
        this.state = {
            userName: "Name",
            password: "Password"
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        if (event.target.name === "username") {
            this.setState({ userName: event.target.value })
        }
        else if (event.target.name === "password") {
            this.setState({ password: event.target.value })
        }
    }

    async handleSubmit(event) {
        event.preventDefault();
        await fetch(process.env.REACT_APP_BASE_URL + 'login', {
            method: 'post',
            mode: 'cors',
            credentials: 'include',
            headers: {
                'Access-Control-Allow-Credentials': 'true',
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify({
                "Username": this.state.userName.toString(),
                "Password": this.state.password.toString()
            }),
        })
            .then(res => res.json())
            .then((res) => {
                localStorage.setItem('currentUser', JSON.stringify(res));
                currentUserSubject.next(res);
                alert("Sign in successful.");


            })
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Username:
                </label>
                    <br />
                    <input
                        name="username"
                        type="textarea"
                        placeholder="eg. MaxMed11"
                        onChange={this.handleInputChange} />
                <br />
                <label>
                    Password:
                </label>
                <br />
                    <input
                        name="password"
                        type="password"
                        onChange={this.handleInputChange} />
                <br />
                <input type="submit" value="Submit" />
            </form>
        );
    }
}