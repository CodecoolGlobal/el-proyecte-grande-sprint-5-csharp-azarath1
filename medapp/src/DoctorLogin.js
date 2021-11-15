import React, { Component } from 'react';

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
        await fetch(process.env.REACT_APP_BASE_URL_DOCTOR + 'login', {
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
                "HashPassword": this.state.password.toString()
            }),
        })
            .then(res => res.json())
            .then((res) => {

                alert("Doctor " + res + " has signed in.");


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